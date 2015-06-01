/*******************************************************************************************************************************************************************
	File	:	ViewCrossComparison.cs
	Project	:	MSec
	Author	:	Byron Worms
    Links   :   http://www.codeproject.com/Articles/17502/Simple-Popup-Control, http://dynamiclinq.azurewebsites.net/GettingStarted,
                http://www.codeproject.com/Articles/35197/Undocumented-List-View-Features#virtualgroups
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Threading;
using Luminous.Windows.Forms;
using BrightIdeasSoftware;
using System.Text.RegularExpressions;
using System.Runtime.Remoting;
using System.Xml.Linq;

/*******************************************************************************************************************************************************************
	Class: ViewImageVsImage
*******************************************************************************************************************************************************************/
namespace MSec
{
    public class ViewCrossComparison : ViewWithTechniqueSelection
    {
        // Constants
        private static readonly int     LIST_RESULTS_COLUMN_COUNT           = 7;
        private static readonly int     LIST_RESULTS_COLUMN_SOURCE0_PATH    = 0;
        private static readonly int     LIST_RESULTS_COLUMN_SOURCE1_PATH    = 1;
        private static readonly int     LIST_RESULTS_COLUMN_MR_RADISH       = 2;
        private static readonly int     LIST_RESULTS_COLUMN_MR_DCT          = 3;
        private static readonly int     LIST_RESULTS_COLUMN_MR_WAVELET      = 4;
        private static readonly int     LIST_RESULTS_COLUMN_MR_BMB          = 5;
        private static readonly int     LIST_RESULTS_COLUMN_MR_AVG          = 6;

        private static readonly string  LIST_RESULTS_COLUMN_TAG_MR_RADISH   = "MatchRateRADISH";
        private static readonly string  LIST_RESULTS_COLUMN_TAG_MR_DCT      = "MatchRateDCT";
        private static readonly string  LIST_RESULTS_COLUMN_TAG_MR_WAVELET  = "MatchRateWavelet";
        private static readonly string  LIST_RESULTS_COLUMN_TAG_MR_BMB      = "MatchRateBMB";
        private static readonly string  LIST_RESULTS_COLUMN_TAG_MR_AVG      = "MatchRateAverage";

        private static readonly string  ACTION_IDLE                 = "Waiting for user input...";
        private static readonly string  ACTION_LOADING_FILES        = "Loading and analysing files...";
        private static readonly string  ACTION_READY                = "Ready for the comparison...";
        private static readonly string  ACTION_EXECUTION            = "The comparison is being executed...";
        private static readonly string  ACTION_FILTERING            = "Filtering is being executed...";

        private static readonly string  CUSTOM_ACTION_HASHING       = "Hashes are being computed: {0}/{1}";
        private static readonly string  CUSTOM_ACTION_COMPARISON    = "Hashes are being compared";
        private static readonly string  CUSTOM_ACTION_PROCESS_DATA  = "Post-processing data...";

        private static readonly string  STRING_FORMAT_NUM_SOURCES   = "Image source count: {0}";
        private static readonly string  STRING_FORMAT_NUM_RESULTS   = "Result count: {0}";

        private static readonly Color   COLOR_RESULT_ACCEPTED       = Color.FromArgb(46, 176, 51);
        private static readonly Color   COLOR_RESULT_DENIED         = Color.FromArgb(255, 51, 51);
        private static readonly int     NUM_MIDPOINTS_COLOR_RESULT  = 10;

        // Delegate declarations
        private delegate IEnumerable<UnfoldedBindingComparisonPair>     delegate_sorter_func(int _index);
        private delegate object                                         delegate_sorter_element_selecter_func(UnfoldedBindingComparisonPair _pair);

        // All possible states
        private enum eState
        {
            STATE_NONE,                 // Just for initialization!
            STATE_IDLE,
            STATE_LOADING_FILES,
            STATE_READY,
            STATE_EXECUTING,
            STATE_FILTERING
        }

        // A simple node for listing files and directories
        private class TreeNode
        {
            // The node's ID
            public int NodeID
            {
                get { return m_nodePath.GetHashCode(); }
                private set { }
            }

            // The current path of this node
            private string m_nodePath = "";
            public string NodePath
            {
                get { return m_nodePath; }
                set { m_nodePath = value; }
            }

            // List with the sub-nodes
            private List<TreeNode> m_subNodeList = new List<TreeNode>();

            // List with the image sources
            private List<ImageSource> m_imageSourceList = new List<ImageSource>();

            // Number of sub-nodes
            public int NumSubNodes
            {
                get { return m_subNodeList.Count; }
                private  set {  }
            }

            // Number of found image sources
            public int NumImageSources
            {
                get { return m_imageSourceList.Count; }
                private set {  }
            }

            // Number of image source in the sub-tree
            private int m_imageSourceCountSubTree = 0;
            public int NumImagesSourcesSubTree
            {
                get { return m_imageSourceCountSubTree; }
                set { m_imageSourceCountSubTree = value; }
            }

            // Number of all image source (current level + sub-tree)
            public int NumAllImageSources
            {
                get { return NumImagesSourcesSubTree + NumImageSources; }
                private set { }
            }

            // Adds a new node
            public void addNode(TreeNode _node)
            {
                if(_node != null)
                    m_subNodeList.Add(_node);
            }

            // Returns a certain tree node or null of the index is invalid
            public TreeNode getNodeAt(int _index)
            {
                if (_index >= m_subNodeList.Count)
                    return null;
                return m_subNodeList[_index];
            }

            // Add a new image source
            public void addImageSource(ImageSource _src)
            {
                if (_src != null)
                    m_imageSourceList.Add(_src);
            }

            // Returns a certain image source or null of the index is invalid
            public ImageSource getImageSourceAt(int _index)
            {
                if (_index >= m_imageSourceList.Count)
                    return null;
                return m_imageSourceList[_index];
            }
        }

        // A simple class for holding pre-defined filter
        private class PredefinedFilter
        {
            // True to auto-execute the filter on selection
            private bool m_autoExecute = false;
            public bool AutoExecute
            {
                get { return m_autoExecute; }
                private set { }
            }

            // Name of the filter
            private string m_name = "";
            public string Name
            {
                get { return m_name; }
                private set { }
            }

            // The command of the filter
            private string m_command;
            public string Command
            {
                get { return m_command; }
                private set { }
            }
        
            // Constructor
            public PredefinedFilter(string _name, string _command, bool _autoExecute)
            {
                m_name = _name;
                m_command = _command;
                m_autoExecute = _autoExecute;
            }

            // Override: ToString
            public override string ToString()
            {
                return m_name;
            }
        }

        // Stores data for the filter processing
        private class FilterBinaryData
        {
            // The queryable interface
            private IQueryable m_queryable = null;
            public IQueryable Queryable
            {
                get { return m_queryable; }
                set { m_queryable = value; }
            }

            // The instructions
            private string m_code = "";
            public string Code
            {
                get { return m_code; }
                private set { }
            }

            // True if the queryable stores grouped data
            private bool m_isGrouped;
            public bool IsGrouped
            {
                get { return m_isGrouped; }
                set { m_isGrouped = value; }
            }

            // The group key
            private string m_groupKey = "";
            public string GroupKey
            {
                get { return m_groupKey; }
                private set { }
            }

            // Constructor
            public FilterBinaryData(IQueryable _q, string _c, string _key = "")
            {
                // Copy
                m_queryable = _q;
                m_code = _c;
                m_groupKey = _key;
            }
        }

        // The data lock
        private object                  m_dataLock = new object();

        // The loaded data 
        private TreeNode                m_loadedData = null;

        // The comparison data
        private List<UnfoldedBindingComparisonPair> m_listUnfoldedComparisonItems = null;
        private List<UnfoldedBindingComparisonPair> m_listUnfoldedDisplayComparisonItems = null;

        // The sorter stuff for the list-view (results)
        private delegate_sorter_element_selecter_func[] m_listResultsSorterFuncs = null;
        private int                     m_listResultsSortColumnIndex = -1;
        private SortOrder               m_listResultsSortOrder = SortOrder.None;

        // Configurations
        private bool                    m_isShowResultColors = true;

        // State stuff
        private eState                  m_currentState = eState.STATE_NONE;
        private Action                  m_onStateEnter = delegate { };
        private Action                  m_onStateExit = delegate { };

        // Comparison details stuff
        private CC_ComparisonDetails    m_comparatorDetails = null;
        private CC_MultiSelectionStats  m_multiSelectionStats = null;
        private Popup                   m_popupWindow = null;
        private Popup                   m_popupWindowStats = null;
        private Rectangle               m_popupPosition;

        // Misc. stuff
        private Color[]                 m_colorListMidpoints = null;

        // Controls
        private FastObjectListView      m_listResults = null;
        private TextBox                 m_textReferenceFolder = null;
        private System.Windows.Forms.ComboBox m_textFilter = null;
        private Button                  m_buttonReferenceFolderSelect = null;
        private Button                  m_buttonReferenceFolderDelete = null;
        private Button                  m_buttonControlsStart = null;
        private Button                  m_buttonControlsCollapseGroups = null;
        private Label                   m_labelReferenceFolderNumImageSources = null;
        private Label                   m_labelResultCount = null;
        private ToolStripDropDownButton m_toolStripDropDown = null;
        private ToolStripLabel          m_labelAction = null;
        private ToolStripProgressBar    m_progressBar = null;
        private ToolStripMenuItem       m_toolStripItemShowColors = null;

        // List-view-column (result list)
        private OLVColumn               m_listResultColumnMRRadish = null;
        private OLVColumn               m_listResultColumnMRDCT = null;
        private OLVColumn               m_listResultColumnMRWavelet = null;
        private OLVColumn               m_listResultColumnMRBMB = null;
        private OLVColumn               m_listResultColumnMRAVG = null;

        // Constructor
        public ViewCrossComparison(TabPage _tabPage) :
            base(_tabPage, "CC_Selection_Technique")
        {
            // Local variables
            int x = 0;
            int y = 0;
            delegate_sorter_element_selecter_func funcTemp = null;
            IEnumerable<XElement> xmlElements = null;
            List<PredefinedFilter> filterList = new List<PredefinedFilter>();

            #region App config
            // Get all filters from app config
            xmlElements = MSec.Instance.getXmlElementsByType("filter");
            if (xmlElements != null && xmlElements.Count() > 0)
            {
                // Local variables
                bool autoExecute = false;
                string desc = "";
                string command = "";

                // Process all filter
                foreach(var e in xmlElements)
                {
                    // Get desc
                    autoExecute = bool.Parse(e.Attribute("autoexecute").Value);
                    desc = e.Element("desc").Value;
                    command = e.Element("command").Value;

                    // Create filter
                    filterList.Add(new PredefinedFilter(desc, command, autoExecute));
                }
            }
            #endregion App config

            #region List-view sorter: element selecter (result list)
            // Create list
            m_listResultsSorterFuncs = new delegate_sorter_element_selecter_func[LIST_RESULTS_COLUMN_COUNT];

            // Register function: sorting based on text level (image source0 path)
            funcTemp = (UnfoldedBindingComparisonPair _pair) =>
            {
                return _pair.Source0.FilePath;
            };
            m_listResultsSorterFuncs[LIST_RESULTS_COLUMN_SOURCE0_PATH] = funcTemp;

            // Register function: sorting based on text level (image source1 path)
            funcTemp = (UnfoldedBindingComparisonPair _pair) =>
            {
                return _pair.Source1.FilePath;
            };
            m_listResultsSorterFuncs[LIST_RESULTS_COLUMN_SOURCE1_PATH] = funcTemp;

            // Register function: sorting based on the match rate (RADISH)
            funcTemp = (UnfoldedBindingComparisonPair _pair) =>
            {
                return _pair.MatchRateRADISH;
            };
            m_listResultsSorterFuncs[LIST_RESULTS_COLUMN_MR_RADISH] = funcTemp;

            // Register function: sorting based on the match rate (DCT)
            funcTemp = (UnfoldedBindingComparisonPair _pair) =>
            {
                return _pair.MatchRateDCT;
            };
            m_listResultsSorterFuncs[LIST_RESULTS_COLUMN_MR_DCT] = funcTemp;

            // Register function: sorting based on the match rate (BMB)
            funcTemp = (UnfoldedBindingComparisonPair _pair) =>
            {
                return _pair.MatchRateBMB;
            };
            m_listResultsSorterFuncs[LIST_RESULTS_COLUMN_MR_BMB] = funcTemp;

            // Register function: sorting based on the match rate (Wavelet)
            funcTemp = (UnfoldedBindingComparisonPair _pair) =>
            {
                return _pair.MatchRateWavelet;
            };
            m_listResultsSorterFuncs[LIST_RESULTS_COLUMN_MR_WAVELET] = funcTemp;

            // Register function: sorting based on the match rate (Average)
            funcTemp = (UnfoldedBindingComparisonPair _pair) =>
            {
                return _pair.MatchRateAVG;
            };
            m_listResultsSorterFuncs[LIST_RESULTS_COLUMN_MR_AVG] = funcTemp;
            #endregion List-view sorter: element selecter (result list)

            // Create pop-up window (comparison details)
            m_comparatorDetails = new CC_ComparisonDetails();
            m_popupWindow = new Popup(m_comparatorDetails);
            m_popupWindow.HidingAnimation = PopupAnimations.None;
            m_popupWindow.ShowingAnimation = PopupAnimations.None;
            m_popupWindow.FocusOnOpen = false;

            // Create pop-up window (multi-selection stats)
            m_multiSelectionStats = new CC_MultiSelectionStats();
            m_popupWindowStats = new Popup(m_multiSelectionStats);
            m_popupWindowStats.HidingAnimation = PopupAnimations.None;
            m_popupWindowStats.ShowingAnimation = PopupAnimations.None;
            m_popupWindowStats.FocusOnOpen = false;

            // Extract controls
            m_listResults = _tabPage.Parent.Controls.Find("CC_List_Results", true)[0] as FastObjectListView;
            m_textReferenceFolder = _tabPage.Controls.Find("CC_Text_ReferenceFolder_Path", true)[0] as TextBox;
            m_textFilter = _tabPage.Controls.Find("CC_Text_Filter", true)[0] as System.Windows.Forms.ComboBox;
            m_buttonReferenceFolderSelect = _tabPage.Controls.Find("CC_Button_ReferenceFolder_Select", true)[0] as Button;
            m_buttonReferenceFolderDelete = _tabPage.Controls.Find("CC_Button_ReferenceFolder_Delete", true)[0] as Button;
            m_buttonControlsStart = _tabPage.Controls.Find("CC_Button_ReferenceFolder_Start", true)[0] as Button;
            m_buttonControlsCollapseGroups = _tabPage.Controls.Find("CC_Button_Controls_CollapseGroups", true)[0] as Button;
            m_labelReferenceFolderNumImageSources = _tabPage.Controls.Find("CC_Label_ReferenceFolder_NumSources", true)[0] as Label;
            m_toolStripDropDown = (_tabPage.Controls.Find("CC_ToolStrip", true)[0] as ToolStrip).Items.Find("CC_ToolStrip_DropDown", true)[0] as ToolStripDropDownButton;
            m_labelAction = (_tabPage.Controls.Find("CC_ToolStrip", true)[0] as ToolStrip).Items.Find("CC_ToolStrip_Label_Action", true)[0] as ToolStripLabel;
            m_labelResultCount = _tabPage.Controls.Find("CC_Label_ResultCount", true)[0] as Label;
            m_progressBar = (_tabPage.Controls.Find("CC_ToolStrip", true)[0] as ToolStrip).Items.Find("CC_ToolStrip_Progress", true)[0] as ToolStripProgressBar;
            m_toolStripItemShowColors = m_toolStripDropDown.DropDownItems.Find("CC_ToolStrip_DropDown_ShowColors", true)[0] as ToolStripMenuItem;

            // Add events to: technique selection
            ControlTechniqueSel.OnTechniqueIDsChanged += onTechniqueSelectionIDsChanged;

            // Add events to: text boxes
            m_textFilter.Items.AddRange(filterList.ToArray());
            m_textFilter.MouseWheel += onFilterMouseWheel;
            m_textFilter.KeyDown += onFilterKeyDown;
            m_textFilter.SelectionChangeCommitted += onFilterSelectionChangeComitted;

            // Add events to: list of results
            extractColumnsByTag();
            (m_listResults.Columns[LIST_RESULTS_COLUMN_SOURCE0_PATH] as OLVColumn).GroupKeyGetter += onListResultsGroupKeyGetter;
           // m_listResults.ItemSelectionChanged += onItemSelectionChanged;
            m_listResults.SelectionChanged += onSelectionChanged;
            m_listResults.FormatCell += onListResultsFormatCell;
           // m_listResults.ColumnClick += onColumnClick;
            m_listResults.ColumnWidthChanging += onColumnWidthChanging;

            // Add events to: buttons
            m_buttonReferenceFolderSelect.Click += onButtonReferenceFolderSelectClick;
            m_buttonReferenceFolderDelete.Click += onButtonReferenceFolderDeleteClick;
            m_buttonControlsStart.Click += onButtonReferenceFolderStartClick;
            m_buttonControlsCollapseGroups.Click += onButtonControlCollapseGroupsClick;

            // Add events to tool strip items
            m_toolStripItemShowColors.CheckedChanged += onToolStripItemShowColorsClick;

            // Define pop-up position
            x = m_listResults.Width;
            y = (m_listResults.Height / 2) - (m_comparatorDetails.Height / 2);
            m_popupPosition = new Rectangle(x, y, 1, 1);

            // Generate midpoint colors
            m_colorListMidpoints = Utility.generateMidpointColors(COLOR_RESULT_ACCEPTED, COLOR_RESULT_DENIED, NUM_MIDPOINTS_COLOR_RESULT);

            // Determine columns's visibility
            showColumnsByTechniqueIDs(ControlTechniqueSel.CurrentTechniqueIDs);

            // Set start state: idle
            setNextState(eState.STATE_IDLE);
        }

        // Extracts the list-view columns by their tags
        private void extractColumnsByTag()
        {
            // Loop through all columns
            foreach(OLVColumn c in m_listResults.AllColumns)
            {
                if ((c.Tag as string) == LIST_RESULTS_COLUMN_TAG_MR_RADISH)
                    m_listResultColumnMRRadish = c;
                else if ((c.Tag as string) == LIST_RESULTS_COLUMN_TAG_MR_DCT)
                    m_listResultColumnMRWavelet = c;
                else if ((c.Tag as string) == LIST_RESULTS_COLUMN_TAG_MR_WAVELET)
                    m_listResultColumnMRDCT = c;
                else if ((c.Tag as string) == LIST_RESULTS_COLUMN_TAG_MR_BMB)
                    m_listResultColumnMRBMB = c;
                else if ((c.Tag as string) == LIST_RESULTS_COLUMN_TAG_MR_AVG)
                    m_listResultColumnMRAVG = c;
            }
        }

        // Shows/hides the columns based on the selected techniques
        private void showColumnsByTechniqueIDs(TechniqueID _ids)
        {
            // Local variables
            bool radish = (_ids & TechniqueID.RADISH) == TechniqueID.RADISH;
            bool dct = (_ids & TechniqueID.DCT) == TechniqueID.DCT;
            bool wavelet = (_ids & TechniqueID.WAVELET) == TechniqueID.WAVELET;
            bool bmb = (_ids & TechniqueID.BMB) == TechniqueID.BMB;

            // Update visibility
            m_listResultColumnMRRadish.IsVisible = radish;
            m_listResultColumnMRDCT.IsVisible = dct;
            m_listResultColumnMRWavelet.IsVisible = wavelet;
            m_listResultColumnMRBMB.IsVisible = bmb;

            // Notify list-view
            m_listResults.RebuildColumns();

            // The average column is always the last one!
            m_listResultColumnMRAVG.DisplayIndex = m_listResults.Columns.Count - 1;
        }

        // Sets a new state
        private void setNextState(eState _next)
        {
            // Check parameter
            if (m_currentState == _next)
                return;

            // Lock operations
            lock(m_dataLock)
            {
                // Set new state
                m_currentState = _next;

                // Execute previous state action
                if (m_onStateExit != null)
                    Utility.invokeInGuiThread(m_tabPage, m_onStateExit);

                // Define actions based on the selected state
                #region State: Idle
                if (m_currentState == eState.STATE_IDLE)
                {
                    // Enter
                    m_onStateEnter = delegate
                    {
                        m_labelAction.Text = ACTION_IDLE;
                    };

                    // Exit
                    m_onStateExit = null;
                }
                #endregion State: Idle

                #region State: Loading files
                else if(m_currentState == eState.STATE_LOADING_FILES)
                {
                    // Enter
                    m_onStateEnter = delegate
                    {
                        m_labelAction.Text = ACTION_LOADING_FILES;
                        m_buttonReferenceFolderSelect.Enabled = false;
                        m_buttonReferenceFolderDelete.Enabled = false;
                    };

                    // Exit
                    m_onStateExit = delegate
                    {
                        m_buttonReferenceFolderSelect.Enabled = true;
                        m_buttonReferenceFolderDelete.Enabled = true;
                    };
                }
                #endregion State: Loading files

                #region State: Ready
                else if (m_currentState == eState.STATE_READY)
                {
                    // Enter
                    m_onStateEnter = delegate
                    {
                        m_labelAction.Text = ACTION_READY;
                        m_buttonControlsStart.Enabled = true;
                        m_buttonControlsCollapseGroups.Enabled = true;
                    };

                    // Exit
                    m_onStateExit = delegate
                    {
                        m_buttonControlsStart.Enabled = false;
                        m_buttonControlsCollapseGroups.Enabled = false;
                    };
                }
                #endregion State: Ready

                #region State: Execution
                else if (m_currentState == eState.STATE_EXECUTING)
                {
                    // Enter
                    m_onStateEnter = delegate
                    {
                        m_labelAction.Text = ACTION_EXECUTION;
                        m_buttonReferenceFolderSelect.Enabled = false;
                        m_buttonReferenceFolderDelete.Enabled = false;
                        m_buttonControlsStart.Enabled = false;
                        m_buttonControlsCollapseGroups.Enabled = false;
                        m_listResults.Enabled = false;
                        m_textFilter.Enabled = false;
                        m_toolStripDropDown.Enabled = false;
                        lockTechniqueSelection();
                    };

                    // Exit
                    m_onStateExit = delegate
                    {
                        m_buttonReferenceFolderSelect.Enabled = true;
                        m_buttonReferenceFolderDelete.Enabled = true;
                        m_buttonControlsStart.Enabled = true;
                        m_buttonControlsCollapseGroups.Enabled = true;
                        m_listResults.Enabled = true;
                        m_textFilter.Enabled = true;
                        m_toolStripDropDown.Enabled = true;
                        unlockTechniqueSelection();
                    };
                }
                #endregion State: Execution

                #region State: Filtering
                else if (m_currentState == eState.STATE_FILTERING)
                {
                    // Enter
                    m_onStateEnter = delegate
                    {
                        m_labelAction.Text = ACTION_FILTERING;
                        m_buttonReferenceFolderSelect.Enabled = false;
                        m_buttonReferenceFolderDelete.Enabled = false;
                        m_buttonControlsStart.Enabled = false;
                        m_buttonControlsCollapseGroups.Enabled = false;
                        m_listResults.Enabled = false;
                        m_textFilter.Enabled = false;
                        m_toolStripDropDown.Enabled = false;
                        lockTechniqueSelection();
                    };

                    // Exit
                    m_onStateExit = delegate
                    {
                        m_buttonReferenceFolderSelect.Enabled = true;
                        m_buttonReferenceFolderDelete.Enabled = true;
                        m_buttonControlsStart.Enabled = true;
                        m_buttonControlsCollapseGroups.Enabled = true;
                        m_listResults.Enabled = true;
                        m_textFilter.Enabled = true;
                        m_toolStripDropDown.Enabled = true;
                        unlockTechniqueSelection();
                    };
                }
                #endregion State: Filtering

                // Execute state changes
                Utility.invokeInGuiThread(m_tabPage, m_onStateEnter);
            }
        }

        // Creates a set of source images from the selected path (if any is found!)
        private void createSourceFiles(string _path)
        {
            // Local variables
            Job<TreeNode> job = null;

            // Set state
            setNextState(eState.STATE_LOADING_FILES);

            // Create job
            job = new Job<TreeNode>((JobParameter<TreeNode> _params) =>
            {
                // Local variables
                string currentPath = _params.Data[0] as string;
                TreeNode root = null;

                // Create node tree
                root = createTreeNodeAtLevel(currentPath);

                return root;
            },
            (JobParameter<TreeNode> _params) =>
            {
                // Set loaded data
                lock(m_dataLock)
                {
                    m_loadedData = _params.Result;
                }

                // Update GUI
                Utility.invokeInGuiThread(m_tabPage, delegate
                {
                    m_textReferenceFolder.Text = _params.Result.NodePath;
                    m_labelReferenceFolderNumImageSources.Text = String.Format(STRING_FORMAT_NUM_SOURCES, _params.Result.NumAllImageSources);
                });

                // Set state
                setNextState(eState.STATE_READY);
            },
            true, new object[]{_path});
        }

        // Resets the source files
        private void resetSourceFiles()
        {
            // Set state
            setNextState(eState.STATE_IDLE);

            // Clear loaded data
            lock(m_dataLock)
            {
                m_loadedData = null;
            }

            // Update GUI
            Utility.invokeInGuiThread(m_tabPage, delegate
            {
                m_textReferenceFolder.Text = "";
                m_labelReferenceFolderNumImageSources.Text = String.Format(STRING_FORMAT_NUM_SOURCES, 0);
            });
        }

        // Create a new tree node (recursive for all other sub directories!)
        private TreeNode createTreeNodeAtLevel(string _path)
        {
            // Local variables
            TreeNode node = null;
            TreeNode tempNode = null;

            // Create node
            node = new TreeNode();
            node.NodePath = _path;

            // Get image files in this directory
            var files = Directory.EnumerateFiles(_path, "*.*", SearchOption.TopDirectoryOnly).Where(s =>
                {
                    // *bmp, *.jpg, *.jpeg, *.jpe, *.jfif, *.png
                    return s.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                        s.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        s.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                        s.EndsWith(".jpe", StringComparison.OrdinalIgnoreCase) ||
                        s.EndsWith(".jfif", StringComparison.OrdinalIgnoreCase) ||
                        s.EndsWith(".png", StringComparison.OrdinalIgnoreCase);
                });
            if (files != null)
            {
                // Create image sources and add to tree
                foreach (string f in files)
                    node.addImageSource(new ImageSource(f));
            }

            // Get sub directories
            var dirs = Directory.EnumerateDirectories(_path, "*", SearchOption.TopDirectoryOnly);
            if (dirs != null)
            {
                // Add sub-nodes
                foreach (string f in dirs)
                {
                    // Create node
                    tempNode = createTreeNodeAtLevel(f);
                    if (tempNode != null && tempNode.NumAllImageSources > 0)
                    {
                        node.NumImagesSourcesSubTree += tempNode.NumAllImageSources;
                        node.addNode(tempNode);
                    }
                }
            }

            return node;
        }

        // Starts computing the image hashes for the selected techniques
        private void startHashing()
        {
            // Local variables
            ImageSourceBinding[] bindings = null;
            ConcurrentQueue<ImageSourceBinding> bindingQueue = null;

            // Set state
            setNextState(eState.STATE_EXECUTING);

            // Reset comparison data
            lock (m_dataLock)
            {
                // Reset data structures
                m_listUnfoldedComparisonItems = m_listUnfoldedDisplayComparisonItems = null;
                updateLabelResultCount();
            }

            // Clear list view
            Utility.invokeInGuiThread(m_listResults, delegate
            {
                m_listResults.ClearObjects();
                m_listResults.ShowGroups = false;
            });

            // Spawn watch job
            new Job<bool?>((JobParameter<bool?> _params) =>
            {
                // Local variables
                ImageSource[] sources = null;
                Job<bool?>[] jobList = null;
                int jobCount = 0;
                bool result = true;
                int numImageHashesComputed = 0;
                string oldActionText = "";

                // Get all image sources
                sources = extractImageSourcesFromNode(m_loadedData, true);
                if (sources == null || sources.Length == 0)
                    return false;

                // Create bindings
                bindings = new ImageSourceBinding[sources.Length];
                for (int i = 0; i < sources.Length; ++i)
                    bindings[i] = new ImageSourceBinding(sources[i]);
                bindingQueue = new ConcurrentQueue<ImageSourceBinding>(bindings);
                sources = null;

                // Get current action text
                oldActionText = setCustomActionText(String.Format(CUSTOM_ACTION_HASHING, numImageHashesComputed, bindings.Length));

                // Spawn woker jobs
                jobCount = Math.Min(bindings.Length, Environment.ProcessorCount);
                jobList = new Job<bool?>[jobCount];
                for (int i = 0; i < jobCount; ++i)
                {
                    #region Worker job
                    // Create worker
                    jobList[i] = new Job<bool?>((JobParameter<bool?> _data) =>
                    {
                        // Local variables
                        ImageSource cpy = null;
                        ImageSourceBinding bin = null;
 
                        // Get source
                        while (bindingQueue.TryDequeue(out bin) == true)
                        {
                            // Loop through all selected techniques
                            foreach (Technique t in MultipleModeTechniques)
                            {
                                // Copy image source
                                cpy = new ImageSource(bin.SourceReference.FilePath);

                                // Compute hash
                                if (t.computeHash(cpy) == null)
                                    continue;

                                // Update binding
                                bin.setComparisonDataFor(t.ID, cpy);
                            }

                            // Update GUI
                            lock (m_dataLock)
                            {
                                // Increment counter
                                ++numImageHashesComputed;

                                // Set text
                                setCustomActionText(String.Format(CUSTOM_ACTION_HASHING, numImageHashesComputed, bindings.Length));
                            }
                        }

                        return true;
                    },
                    (JobParameter<bool?> _result) =>
                    {
                        // Ignore result here!
                    },
                    true);
                    #endregion Worker job
                }

                // Wait for jobs and validate result
                foreach (var j in jobList)
                {
                    j.waitForDone();
                    if (j.Error != null)
                        throw j.Error;
                    else if (j.Result == null || j.Result == false)
                        result = false;
                }

                // Reset action text
                setCustomActionText(oldActionText);

                return result;
            },
            (JobParameter<bool?> _params) =>
            {
                // Failed?
                if (_params.Error != null)
                {
                    setNextState(eState.STATE_READY);
                    MessageBox.Show(_params.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (_params.Result == null || _params.Result == false)
                {
                    setNextState(eState.STATE_READY);
                    MessageBox.Show("Hash computation for the selected image sources failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Start comparison
                startComparison(bindings);
            });
        }

        // Starts the comparison of the computed image hashes
        private void startComparison(ImageSourceBinding[] _bindings)
        {
            // Local variables
            List<ComparisonPairForBindings> pairs = new List<ComparisonPairForBindings>();
            ConcurrentQueue<ComparisonPairForBindings> pairQueue = null;

            // Spawn watch job
            new Job<bool?>((JobParameter<bool?> _params) =>
            {
                // Local variables
                Job<bool?>[] jobList = null;
                int jobCount = 0;
                bool result = true;
                string oldActionText = "";

                // Create pairs
                for (int i = 0; i < _bindings.Length; ++i)
                {
                    for (int j = i; j < _bindings.Length; ++j)
                    {
                        // Create pair
                        var pair = new ComparisonPairForBindings(_bindings[i], _bindings[j]);
                        pairs.Add(pair);
                    }
                }
                pairQueue = new ConcurrentQueue<ComparisonPairForBindings>(pairs);
                _bindings = null;

                // Get current action text
                oldActionText = setCustomActionText(CUSTOM_ACTION_COMPARISON);

                // Spawn woker jobs
                jobCount = Math.Min(pairs.Count, Environment.ProcessorCount);
                jobList = new Job<bool?>[jobCount];
                for (int i = 0; i < jobCount; ++i)
                {
                    #region Worker job
                    // Create worker
                    jobList[i] = new Job<bool?>((JobParameter<bool?> _data) =>
                    {
                        // Local variables
                        ComparativeData compResult = null;
                        ComparisonPairForBindings pair = null;

                        // Get source
                        while (pairQueue.TryDequeue(out pair) == true)
                        {
                            // Loop through all techniques
                            foreach(Technique t in MultipleModeTechniques)
                            {
                                // Compare data
                                compResult = t.compareHashData(pair.Binding0.getComparisonDataFor(t.ID), pair.Binding1.getComparisonDataFor(t.ID));
                                if (compResult == null)
                                    continue;

                                // Set data
                                pair.setComparisonDataFor(t.ID, compResult);
                            }
                        }

                        return true;
                    },
                    (JobParameter<bool?> _result) =>
                    {
                        // Ignore result here!
                    },
                    true);
                    #endregion Worker job
                }

                // Wait for jobs and validate result
                foreach (var j in jobList)
                {
                    j.waitForDone();
                    if (j.Error != null)
                        throw j.Error;
                    else if (j.Result == null || j.Result == false)
                        result = false;
                }

                // Reset action text
                setCustomActionText(oldActionText);

                return result;
            },
            (JobParameter<bool?> _params) =>
            {
                // Failed?
                if (_params.Error != null)
                {
                    setNextState(eState.STATE_READY);
                    MessageBox.Show(_params.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (_params.Result == null || _params.Result == false)
                {
                    setNextState(eState.STATE_READY);
                    MessageBox.Show("Hash comparison for the selected image sources failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Start unfolding
                startUnfolding(pairs.ToArray());
            });
        }

        // Starts the unfolding of the compared image hashes
        private void startUnfolding(ComparisonPairForBindings[] _pairs)
        {
            // Spawn job
            new Job<bool?>((JobParameter<bool?> _params) =>
            {
                // Local variables
                List<UnfoldedBindingComparisonPair> unfoldedPairs = new List<UnfoldedBindingComparisonPair>(_pairs.Length);
                Technique technique = MultipleModeTechniques[0];
                decimal threshold = 0;

                // Set status
                setCustomActionText(CUSTOM_ACTION_PROCESS_DATA);

                // Get threshold
                technique.getAttribute<decimal>(Technique.ATT_GENERAL_THRESHOLD, out threshold);

                // Unfold pairs
                foreach(ComparisonPairForBindings cp in _pairs)
                {
                    unfoldedPairs.Add(new UnfoldedBindingComparisonPair(Convert.ToInt32(threshold), cp.Binding0.SourceReference, cp.Binding1.SourceReference, 
                        cp.getComparisonDataFor(TechniqueID.RADISH), cp.getComparisonDataFor(TechniqueID.DCT),
                        cp.getComparisonDataFor(TechniqueID.WAVELET), cp.getComparisonDataFor(TechniqueID.BMB)));
                }

                // Add all pairs to the list view
                lock (m_dataLock)
                {
                    // Set status
                    setCustomActionText(CUSTOM_ACTION_PROCESS_DATA);

                    // Save computed pairs and update list-view
                    m_listUnfoldedComparisonItems = unfoldedPairs;
                    m_listUnfoldedDisplayComparisonItems = unfoldedPairs;
                    Utility.invokeInGuiThread(m_listResults, delegate
                    {
                        m_listResults.SetObjects(m_listUnfoldedDisplayComparisonItems);
                        updateLabelResultCount();
                    });
                }

                return true;
            },
            (JobParameter<bool?> _params) =>
            {
                // Failed?
                if (_params.Error != null)
                {
                    setNextState(eState.STATE_READY);
                    MessageBox.Show(_params.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (_params.Result == null || _params.Result == false)
                {
                    setNextState(eState.STATE_READY);
                    MessageBox.Show("Hash comparison for the selected image sources failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Done
                setNextState(eState.STATE_READY);
            });
        }

        // Parses and executes the defined filter
        private bool executeFilter2(string _filter)
        {
            // Local variables
            string[] groups = null;
            string[] sections = null;
            string[] groupKey = null;
            string code = "";
            bool isGrouped = false;
            List<FilterBinaryData> groupList = new List<FilterBinaryData>();
            List<UnfoldedBindingComparisonPair> displayList = new List<UnfoldedBindingComparisonPair>();

            // Check parameter
            if (m_listUnfoldedDisplayComparisonItems == null || m_listUnfoldedDisplayComparisonItems.Count == 0)
                return false;

            // Empty?
            if (_filter == null || _filter.Length == 0)
            {
                m_listResults.ShowGroups = false;
                m_listUnfoldedDisplayComparisonItems = m_listUnfoldedComparisonItems;
                m_listResults.SetObjects(m_listUnfoldedDisplayComparisonItems);
                updateLabelResultCount();
                return true;
            }

            // Spawn watch job
            new Job<bool?>((JobParameter<bool?> _params) =>
            {
                // Local variables
                Job<bool?>[] jobList = null;
                int jobCount = 0;
                bool result = true;
                ConcurrentQueue<FilterBinaryData> groupQueue = null;

                // Set state
                setNextState(eState.STATE_FILTERING);

                #region Create groups
                // Split string into groups starting with "[" and ending with "]"
                groups = Regex.Split(_filter, @"\[(.*?)\]", RegexOptions.IgnoreCase);
                if (groups != null && groups.Length > 0)
                {
                    // Loop through all groups
                    foreach (string g in groups)
                    {
                        // Local variables
                        string key = "";

                        // Validate group
                        if (g == null || g.Length == 0)
                            continue;
                        code = g;

                        // Extract group key (if available)
                        groupKey = Regex.Split(g, @"\@\(([^)]*)\)", RegexOptions.IgnoreCase);
                        if (groupKey != null && groupKey.Length == 3)
                        {
                            key = groupKey[1];
                            code = groupKey[2];
                        }

                        // Create new group
                        groupList.Add(new FilterBinaryData(m_listUnfoldedComparisonItems.AsQueryable(), code.Trim(), key.Trim()));
                    }
                }
                else
                {
                    // Create just one group
                    groupList.Add(new FilterBinaryData(m_listUnfoldedComparisonItems.AsQueryable(), _filter));
                }
                if (groupList.Count == 0)
                    return false;

                // Create queue
                groupQueue = new ConcurrentQueue<FilterBinaryData>(groupList);
                #endregion Create groups

                // Spawn woker jobs
                jobCount = Math.Min(groupQueue.Count, Environment.ProcessorCount);
                jobList = new Job<bool?>[jobCount];
                for (int i = 0; i < jobCount; ++i)
                {
                    #region Worker job
                    // Create worker
                    jobList[i] = new Job<bool?>((JobParameter<bool?> _data) =>
                    {
                        // Local variables
                        FilterBinaryData group = null;

                        // Get source
                        while (groupQueue.TryDequeue(out group) == true)
                        {
                            #region Execute group
                            // Split string into sections
                            sections = Regex.Split(group.Code, @"\s(?=(?:WHERE|GROUPBY|ORDERBY|TAKE|SKIP)[^)]*?)", RegexOptions.IgnoreCase);
                            if (sections == null || sections.Length == 0)
                                return false;
                            sections = sections.Reverse().ToArray();

                            // Get queryable
                            foreach (string s in sections)
                            {
                                // Get keyword and command
                                string keyword = s.Substring(0, s.IndexOf(' ')).ToLower().Trim();
                                string command = s.Substring(s.IndexOf(' ')).Trim();

                                // Where clause?
                                if (keyword == "where")
                                {
                                    // Execute query
                                    group.Queryable = group.Queryable.Where(command);
                                }

                                // Group by clause?
                                else if (keyword == "groupby")
                                {
                                    // Query is grouped now!
                                    group.IsGrouped = true;

                                    // Execute query
                                    group.Queryable = group.Queryable.GroupBy(command, "it").Select("new (it.Key as Key, it as Pairs)");
                                }

                                // Order-by clause?
                                else if (keyword == "orderby")
                                {
                                    // Execute query
                                    group.Queryable = group.Queryable.OrderBy(command);
                                }

                                // Take clause?
                                else if (keyword == "take")
                                {
                                    // Execute query
                                    group.Queryable = group.Queryable.Take(int.Parse(command));
                                }

                                // Skip clause?
                                else if (keyword == "skip")
                                {
                                    // Execute query
                                    group.Queryable = group.Queryable.Skip(int.Parse(command));
                                }

                            }
                            #endregion Execute group
                        }

                        return true;
                    },
                    (JobParameter<bool?> _result) =>
                    {
                        // Ignore result here!
                    },
                    true);
                    #endregion Worker job
                }

                // Wait for jobs and validate result
                foreach (var j in jobList)
                {
                    j.waitForDone();
                    if (j.Error != null)
                        throw j.Error;
                    else if (j.Result == null || j.Result == false)
                        result = false;
                }
                if (result == false)
                    return false;

                #region Merging data
                // Loop through all groups
                foreach (var g in groupList)
                {
                    // Grouped?
                    if (g.IsGrouped == true)
                    {
                        // Assign groups to the pairs
                        foreach (dynamic qg in g.Queryable)
                        {
                            foreach (dynamic item in qg.Pairs)
                            {
                                // Local variables
                                object tag = qg.Key;

                                // Generate tag
                                if (g.GroupKey != null && g.GroupKey.Length > 0)
                                    tag = g.GroupKey + " (" + qg.Key + ")";

                                // Item in use?
                                if (item.Tag == null)
                                {
                                    // Add to list
                                    item.Tag = tag;
                                    displayList.Add(item);
                                }
                                else
                                {
                                    // Clone with new tag and add to display list
                                    displayList.Add(item.cloneWithNewTag(tag));
                                }
                            }
                        }

                        // Set flag
                        isGrouped = true;
                    }
                    else
                    {
                        // Generate items for clauses without grouping
                        var list = (g.Queryable as IQueryable<UnfoldedBindingComparisonPair>).ToList();
                        foreach (var item in list)
                        {
                            // Local variables
                            object tag = "Unkown";

                            // Add custom group tag (if available)
                            if (g.GroupKey != null && g.GroupKey.Length > 0)
                                tag = g.GroupKey;

                            // Add to list
                            displayList.Add(item.cloneWithNewTag(tag));
                        }
                    }
                }
                #endregion Merging data

                return true;
            },
            (JobParameter<bool?> _params) =>
            {
                // Failed?
                if (_params.Error != null)
                {
                    setNextState(eState.STATE_READY);
                    MessageBox.Show(_params.Error.Message, "Query failed or is invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (_params.Result == null || _params.Result == false)
                {
                    setNextState(eState.STATE_READY);
                    MessageBox.Show("Filtering failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Run in GUI thread
                Utility.invokeInGuiThread(m_listResults, delegate
                {
                    // Configure list-view
                    m_listResults.ShowGroups = isGrouped;
                    m_listUnfoldedDisplayComparisonItems = displayList;
                    m_listResults.SetObjects(m_listUnfoldedDisplayComparisonItems);
                    updateLabelResultCount();
                });

                // Set state
                setNextState(eState.STATE_READY);
            });

            return true;
        }

        // Extracts the image sources from a given tree-node (and its sub-nodes)
        private ImageSource[] extractImageSourcesFromNode(TreeNode _node, bool _considerSubNodes = true)
        {
            // Local variables
            List<ImageSource> sourceList = new List<ImageSource>();
            Queue<TreeNode> nodeList = new Queue<TreeNode>();
            TreeNode currentNode = null;

            // Extract all image sources
            nodeList.Enqueue(m_loadedData);
            while (nodeList.Count > 0)
            {
                // Get head
                currentNode = nodeList.Dequeue();

                // Add sub-nodes
                if (_considerSubNodes == true)
                {
                    for (int s = 0; s < currentNode.NumSubNodes; ++s)
                        nodeList.Enqueue(currentNode.getNodeAt(s));
                }

                // Extract all image sources
                for (int i = 0; i < currentNode.NumImageSources; ++i)
                    sourceList.Add(currentNode.getImageSourceAt(i));
            }

            return sourceList.ToArray();
        }

        // Sets a custom action text
        // Returns the previously set text
        private string setCustomActionText(string _text)
        {
            // Local variables
            string result = "";

            // Lock
            lock(m_dataLock)
            {
                // Run in GUI thread
                Utility.invokeInGuiThread(m_tabPage, delegate
                {
                    result = m_labelAction.Text;
                    m_labelAction.Text = _text;
                });
            }

            return result;
        }

        // Updates the label: result count
        private void updateLabelResultCount()
        {
            // Local variables
            int count = 0;

            // Check parameter
            if (m_listUnfoldedDisplayComparisonItems != null && m_listUnfoldedDisplayComparisonItems.Count != 0)
                count = m_listUnfoldedDisplayComparisonItems.Count;

            // Run in GUI thread
            Utility.invokeInGuiThread(m_labelResultCount, delegate
            {
                m_labelResultCount.Text = String.Format(STRING_FORMAT_NUM_RESULTS, count);
            });
        }

        // Parses and executes the defined filter
        private bool executeFilter(string _filter)
        {
            // Local variables
            string[] sections = null;
            IQueryable queryable = null;
            bool isGrouped = false;
            List<UnfoldedBindingComparisonPair> displayList = new List<UnfoldedBindingComparisonPair>();

            // Check parameter
            if (m_listUnfoldedDisplayComparisonItems == null || m_listUnfoldedDisplayComparisonItems.Count == 0)
                return false;

            // Empty?
            if (_filter == null || _filter.Length == 0)
            {
                m_listResults.ShowGroups = false;
                m_listUnfoldedDisplayComparisonItems = m_listUnfoldedComparisonItems;
                m_listResults.SetObjects(m_listUnfoldedDisplayComparisonItems);
                updateLabelResultCount();
                return true;
            }

            // Execute query
            try
            {
                // Split string into sections
                sections = Regex.Split(_filter, @"\s(?=(?:WHERE|GROUPBY|ORDERBY|TAKE|SKIP)[^)]*?)", RegexOptions.IgnoreCase);
                if (sections == null || sections.Length == 0)
                    return false;
                sections = sections.Reverse().ToArray();

                // Get queryable from list
                queryable = m_listUnfoldedComparisonItems.AsQueryable();
                foreach (string s in sections)
                {
                    // Get keyword and command
                    string keyword = s.Substring(0, s.IndexOf(' ')).ToLower();
                    string command = s.Substring(s.IndexOf(' '));

                    // Where clause?
                    if (keyword == "where")
                    {
                        // Execute query
                        queryable = queryable.Where(command);
                    }

                    // Group by clause?
                    else if (keyword == "groupby")
                    {
                        if (isGrouped == true)
                            throw new Exception("The data can be grouped just one time!\nSeveral \"groupby\" keywords are not supported yet.");
                        queryable = queryable.GroupBy(command, "it").Select("new (it.Key as Key, it as Pairs)");
                        isGrouped = true;
                    }

                    // Order-by clause?
                    else if (keyword == "orderby")
                    {
                        // Execute query
                        queryable = queryable.OrderBy(command);
                    }

                    // Take clause?
                    else if (keyword == "take")
                    {
                        // Execute query
                        queryable = queryable.Take(int.Parse(command));
                    }

                    // Skip clause?
                    else if (keyword == "skip")
                    {
                        // Execute query
                        queryable = queryable.Skip(int.Parse(command));
                    }
                }

                // Group clause?
                if (isGrouped)
                {
                    // Assign groups to the pairs
                    foreach (dynamic g in queryable)
                    {
                        foreach (dynamic item in g.Pairs)
                        {
                            // Set item's tag
                            item.Tag = g.Key;

                            // Add to display list
                            displayList.Add(item);
                        }
                    }

                    // Assign to list-view's list
                    m_listUnfoldedDisplayComparisonItems = displayList;
                }

                // List clause!
                else
                    m_listUnfoldedDisplayComparisonItems = (queryable as IQueryable<UnfoldedBindingComparisonPair>).ToList();

                // Configure list-view
                m_listResults.ShowGroups = isGrouped;
                m_listResults.SetObjects(m_listUnfoldedDisplayComparisonItems);
                updateLabelResultCount();
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.Message, "Query failed or is invalid!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        #region Events: Controls
        // Event TechniqueSelection::OnTechniqueIDsChanged
        void onTechniqueSelectionIDsChanged(TechniqueID _ids)
        {
            // Update column visibility
            showColumnsByTechniqueIDs(_ids);
        }

        // Event List::onColumnWidthChanging
        object onListResultsGroupKeyGetter(object _sender)
        {
            // Local variables
            UnfoldedBindingComparisonPair pair = _sender as UnfoldedBindingComparisonPair;

            return pair.Tag.ToString();
        }

        // Event List::onListResultsFormatCell
        void onListResultsFormatCell(object _sender, FormatCellEventArgs _e)
        {
            // Local variables
            UnfoldedBindingComparisonPair pair = _e.Model as UnfoldedBindingComparisonPair;
            Color background = Color.White;
            double match = 0.0;
            double threshold = 0.0;
            decimal tempDecimal = 0.0m;
            int index = 0;
            string tag = m_listResults.Columns[_e.ColumnIndex].Tag as string;

            // Color background activated?
            if (m_isShowResultColors == false)
                return;

            // Get match rate
            if (tag == LIST_RESULTS_COLUMN_TAG_MR_RADISH)
                match = pair.MatchRateRADISH / 100.0;
            else if (tag == LIST_RESULTS_COLUMN_TAG_MR_DCT)
                match = pair.MatchRateDCT / 100.0;
            else if (tag == LIST_RESULTS_COLUMN_TAG_MR_WAVELET)
                match = pair.MatchRateWavelet / 100.0;
            else if (tag == LIST_RESULTS_COLUMN_TAG_MR_BMB)
                match = pair.MatchRateBMB / 100.0;
            else if (tag == LIST_RESULTS_COLUMN_TAG_MR_AVG)
                match = pair.MatchRateAVG / 100.0;
            else
                return;
            if (match < 0)
                return;

            // Get technique (all pairs were generated by the same threshold)
            MultipleModeTechniques[0].getAttribute<decimal>(Technique.ATT_GENERAL_THRESHOLD, out tempDecimal);
            threshold = Convert.ToSingle(tempDecimal) / 100.0;

            // Set color
            index = Utility.calculateMidpointColorIndex(threshold, match, NUM_MIDPOINTS_COLOR_RESULT);
            background = m_colorListMidpoints[index];

            // Set color to sub-item
            _e.SubItem.BackColor = background;
        }

        // Event List::onColumnClick
        void onColumnClick(object _sender, ColumnClickEventArgs _e)
        {
            // Local variables
            delegate_sorter_func sorterFunc = null;

            // Check
            if (m_listUnfoldedDisplayComparisonItems == null || m_listUnfoldedDisplayComparisonItems.Count == 0)
                return;

            // Same column
            if (m_listResultsSortColumnIndex == _e.Column)
            {
                // Reverse the sort order
                if (m_listResultsSortOrder == SortOrder.Ascending)
                    m_listResultsSortOrder = SortOrder.Descending;
                else
                    m_listResultsSortOrder = SortOrder.Ascending;
            }
            else
            {
                // Set the column index (default to ascending)
                m_listResultsSortColumnIndex = _e.Column;
                m_listResultsSortOrder = SortOrder.Ascending;
            }

            // Define sorter function
            if (m_listResultsSortOrder == SortOrder.Ascending)
            {
                sorterFunc = (int _index) =>
                {
                    return from item in m_listUnfoldedDisplayComparisonItems
                           orderby m_listResultsSorterFuncs[_index](item)
                           select item;
                };
            }
            else
            {
                sorterFunc = (int _index) =>
                {
                    return from item in m_listUnfoldedDisplayComparisonItems
                           orderby m_listResultsSorterFuncs[_index](item) descending
                           select item;
                };
            }

            // Sort list
            m_listUnfoldedDisplayComparisonItems = sorterFunc(_e.Column).ToList();

            // Update list-view
            m_listResults.ClearObjects();
            m_listResults.SetObjects(m_listUnfoldedDisplayComparisonItems);
            m_listResults.RedrawItems(0, m_listUnfoldedDisplayComparisonItems.Count - 1, true);
        }

        // Event List::onColumnWidthChanging
        void onColumnWidthChanging(object _sender, ColumnWidthChangingEventArgs _e)
        {
            _e.NewWidth = m_listResults.Columns[_e.ColumnIndex].Width;
            _e.Cancel = true;
        }

        // Event List::onSelectionChanged
        void onSelectionChanged(object _sender, EventArgs _e)
        {
            try
            {
                // Get list with selected items
                var list = m_listResults.SelectedObjects;

                // None selected?
                if (list == null || list.Count == 0)
                {
                    // Hide windows
                    m_popupWindowStats.Hide();
                    m_popupWindow.Hide();
                }

                // Just one selected?
                else if (list.Count == 1)
                {
                    // Show pop-up window
                    m_popupWindowStats.Hide();
                    m_popupWindow.Show(m_listResults, m_popupPosition);

                    // Set data
                    m_comparatorDetails.setComparisonPair(list[0] as UnfoldedBindingComparisonPair);
                }
                else
                {
                    // Show pop-up window
                    m_popupWindow.Hide();
                    m_popupWindowStats.Show(m_listResults, m_popupPosition);

                    // Set data
                    m_multiSelectionStats.setSelectedItems(list.OfType<UnfoldedBindingComparisonPair>());
                }
            }
            catch(Exception _ex)
            {
                MessageBox.Show(_ex.Message);
            }
        }

        // Event Button::onButtonReferenceFolderSelect_Click
        void onButtonReferenceFolderSelectClick(object sender, EventArgs e)
        {
            // Local variables
            string path = "";

            // Select folder
            path = Utility.openSelectFolderDialog();
            if (path != null && path.Length > 0)
                createSourceFiles(path);
        }

        // Event Button::onButtonReferenceFolderDeleteClick
        void onButtonReferenceFolderDeleteClick(object sender, EventArgs e)
        {
            // Reset source files
            if(MessageBox.Show("Delete source files?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                resetSourceFiles();
        }

        // Event Button::onButtonReferenceFolderStartClick
        void onButtonReferenceFolderStartClick(object sender, EventArgs e)
        {
            // Start comparison
            if (MessageBox.Show("Do you want to start the cross comparison of the selected image sources? This may take a while...",
                "Start the comparison?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                startHashing();//startComparisonHashing();
        }

        // Event Button::onButtonControlCollapseGroupsClick
        void onButtonControlCollapseGroupsClick(object sender, EventArgs e)
        {
            // Grouping enabled?
            if (m_listResults.ShowGroups == false)
                return;

            // Loop through all groups
            foreach (OLVGroup g in m_listResults.OLVGroups)
                g.Collapsed = true;
        }

        // Event TextBox::onFilterMouseWheel
        void onFilterMouseWheel(object _sender, MouseEventArgs _e)
        {
            // Mark as handled
            ((HandledMouseEventArgs)_e).Handled = true;
        }

        // Event TextBox::onFilterKeyDown
        void onFilterKeyDown(object _sender, KeyEventArgs _e)
        {
            // Check parameter
            if (_e.KeyCode != Keys.Enter && _e.KeyCode != Keys.Return)
                return;

            // Execute filter
            executeFilter2(m_textFilter.Text);
        }

        // Event TextBox::onFilterSelectedValueChanged
        void onFilterSelectionChangeComitted(object _sender, EventArgs _e)
        {
            // Get filter
            PredefinedFilter filter = m_textFilter.SelectedItem as PredefinedFilter;

            // Update text
            m_textFilter.BeginInvoke((MethodInvoker)delegate { this.m_textFilter.Text = filter.Command; });

            // Execute query
            if (filter.AutoExecute == true)
                executeFilter2(filter.Command);
        }

        #region Events: ToolStrip
        // Event List::onColumnClick
        void onToolStripItemShowColorsClick(Object _sender, EventArgs _e)
        {
            /*/ Invert attribute
            m_isShowResultColors = !m_isShowResultColors;

            // Update list-view
            if(m_listDisplayComparisonItems != null && m_listDisplayComparisonItems.Count > 0)
                m_listResults.RedrawItems(0, m_listDisplayComparisonItems.Count - 1, true);    */  
        }
        #endregion Events: ToolStrip
        #endregion Events: Controls
    }
}