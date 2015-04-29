/*******************************************************************************************************************************************************************
	File	:	ViewCrossComparison.cs
	Project	:	MSec
	Author	:	Byron Worms
    Links   :   http://www.codeproject.com/Articles/17502/Simple-Popup-Control
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Threading;
using Luminous.Windows.Forms;

/*******************************************************************************************************************************************************************
	Class: ViewImageVsImage
*******************************************************************************************************************************************************************/
namespace MSec
{
    public class ViewCrossComparison : ViewWithTechniqueSelection
    {
        // Constants
        private static readonly string  ACTION_IDLE                 = "Waiting for user input...";
        private static readonly string  ACTION_LOADING_FILES        = "Loading & analysing files...";
        private static readonly string  ACTION_READY                = "Ready for the comparison...";
        private static readonly string  ACTION_EXECUTION            = "The comparison is being executed...";

        private static readonly string  CUSTOM_ACTION_HASHING       = "Hashes are being computed: {0}/{1}";
        private static readonly string  CUSTOM_ACTION_COMPARISON    = "Hashes are being compared: {0}/{1}";
        private static readonly string  CUSTOM_ACTION_PROCESS_DATA  = "Post-processing data...";

        private static readonly string  STRING_FORMAT_NUM_SOURCES   = "Image source count: {0}";

        private static readonly Color   COLOR_RESULT_ACCEPTED       = Color.FromArgb(46, 176, 51);
        private static readonly Color   COLOR_RESULT_DENIED         = Color.FromArgb(255, 51, 51);
        private static readonly int     NUM_MIDPOINTS_COLOR_RESULT  = 10;

        // All possible states
        private enum eState
        {
            STATE_NONE,                 // Just for initialization!
            STATE_IDLE,
            STATE_LOADING_FILES,
            STATE_READY,
            STATE_EXECUTING
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

        // The data lock
        private object                  m_dataLock = new object();

        // The loaded data 
        private TreeNode                m_loadedData = null;

        // The comparison data
        private Dictionary<int,ComparisonPair> m_comparisonPairs = null;

        // The sorter for the list-view (column-based)
        private ListViewColumnSorter    m_listResultsSorter = null;

        // State stuff
        private eState                  m_currentState = eState.STATE_NONE;
        private Action                  m_onStateEnter = delegate { };
        private Action                  m_onStateExit = delegate { };

        // Comparison details stuff
        private CC_ComparisonDetails    m_comparatorDetails = null;
        private Popup                   m_popupWindow = null;
        private Rectangle               m_popupPosition;

        // Controls
        private ListView                m_listResults = null;
        private TextBox                 m_textReferenceFolder = null;
        private Button                  m_buttonReferenceFolderSelect = null;
        private Button                  m_buttonReferenceFolderDelete = null;
        private Button                  m_buttonReferenceFolderStart = null;
        private Label                   m_labelReferenceFolderNumImageSources = null;
        private ToolStripLabel          m_labelAction = null;
        private ToolStripProgressBar    m_progressBar = null;

        // Constructor
        public ViewCrossComparison(TabPage _tabPage) :
            base(_tabPage, "CC_Selection_Technique")
        {
            // Local variables
            int x = 0;
            int y = 0;
            
            #region List-view sorter (result list)
            // Comparison function for image index based compares
            ListViewColumnSorter.delegate_compare_item funcImageIndexCompare = (ListViewItem _x, ListViewItem _y) =>
            {
                return _x.ImageIndex.CompareTo(_y.ImageIndex);
            };

            // Comparison function for text based compares
            ListViewColumnSorter.delegate_compare funcTextCompare = (ListViewItem.ListViewSubItem _x, ListViewItem.ListViewSubItem _y) =>
            {
                return _x.Text.CompareTo(_y.Text);
            };

            // Comparison function for double based compares
            ListViewColumnSorter.delegate_compare funcDoubleCompare = (ListViewItem.ListViewSubItem _x, ListViewItem.ListViewSubItem _y) =>
            {
                return double.Parse(_x.Text).CompareTo(double.Parse(_y.Text));
            };

            // Create list-view sorter
            m_listResultsSorter = new ListViewColumnSorter(funcImageIndexCompare, funcTextCompare, funcTextCompare, funcTextCompare, funcTextCompare, funcDoubleCompare);
            #endregion List-view sorter (result list)

            // Create pop-up window
            m_comparatorDetails = new CC_ComparisonDetails();
            m_popupWindow = new Popup(m_comparatorDetails);
            m_popupWindow.HidingAnimation = PopupAnimations.None;
            m_popupWindow.ShowingAnimation = PopupAnimations.None;
            m_popupWindow.FocusOnOpen = false;

            // Extract controls
            m_listResults = _tabPage.Controls.Find("CC_List_Results", true)[0] as ListView;
            m_textReferenceFolder = _tabPage.Controls.Find("CC_Text_ReferenceFolder_Path", true)[0] as TextBox;
            m_buttonReferenceFolderSelect = _tabPage.Controls.Find("CC_Button_ReferenceFolder_Select", true)[0] as Button;
            m_buttonReferenceFolderDelete = _tabPage.Controls.Find("CC_Button_ReferenceFolder_Delete", true)[0] as Button;
            m_buttonReferenceFolderStart = _tabPage.Controls.Find("CC_Button_ReferenceFolder_Start", true)[0] as Button;
            m_labelReferenceFolderNumImageSources = _tabPage.Controls.Find("CC_Label_ReferenceFolder_NumSources", true)[0] as Label; 
            m_labelAction = (_tabPage.Controls.Find("CC_ToolStrip", true)[0] as ToolStrip).Items.Find("CC_ToolStrip_Label_Action", true)[0] as ToolStripLabel;
            m_progressBar = (_tabPage.Controls.Find("CC_ToolStrip", true)[0] as ToolStrip).Items.Find("CC_ToolStrip_Progress", true)[0] as ToolStripProgressBar;

            // Add events to: list of results
            m_listResults.ListViewItemSorter = m_listResultsSorter;
            m_listResults.ItemSelectionChanged += onItemSelectionChanged;
            m_listResults.ColumnClick += onColumnClick;
            m_listResults.ColumnWidthChanging += onColumnWidthChanging;

            // Add events to: buttons
            m_buttonReferenceFolderSelect.Click += onButtonReferenceFolderSelectClick;
            m_buttonReferenceFolderDelete.Click += onButtonReferenceFolderDeleteClick;
            m_buttonReferenceFolderStart.Click += onButtonReferenceFolderStartClick;

            // Define pop-up position
            x = m_listResults.Width;
            y = (m_listResults.Height / 2) - (m_comparatorDetails.Height / 2);
            m_popupPosition = new Rectangle(x, y, 1, 1);

            // Set start state: idle
            setNextState(eState.STATE_IDLE);
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
                        m_buttonReferenceFolderStart.Enabled = true;
                    };

                    // Exit
                    m_onStateExit = delegate
                    {
                        m_buttonReferenceFolderStart.Enabled = false;
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
                        m_buttonReferenceFolderStart.Enabled = false;
                        m_listResults.Enabled = false;
                        lockTechniqueSelection();
                    };

                    // Exit
                    m_onStateExit = delegate
                    {
                        m_buttonReferenceFolderSelect.Enabled = true;
                        m_buttonReferenceFolderDelete.Enabled = true;
                        m_buttonReferenceFolderStart.Enabled = true;
                        m_listResults.Enabled = true;
                        unlockTechniqueSelection();
                    };
                }
                #endregion State: Execution

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

        // Starts the comparison (hashing)
        private void startComparisonHashing()
        {
            // Local variables
            ImageSource[] sources = null;
            ConcurrentQueue<ImageSource> sourceQueue = null;

            // Set state
            setNextState(eState.STATE_EXECUTING);

            // Reset comparison data
            lock(m_dataLock)
            {
                m_comparisonPairs = null;
            }

            // Clear list view
            Utility.invokeInGuiThread(m_listResults, delegate
            {
                m_listResults.Items.Clear();
            });
           
            // Spawn watch job
            new Job<bool?>((JobParameter<bool?> _params) =>
            {
                #region Watch job
                // Local variables
                Job<bool?>[] jobList = null;
                int jobCount = 0;
                bool result = true;
                int numImageHashesComputed = 0;
                string oldActionText = "";

                // Get all image sources
                sources = extractImageSourcesFromNode(m_loadedData, true);
                if (sources == null || sources.Length == 0)
                    return false;
                sourceQueue = new ConcurrentQueue<ImageSource>(sources);

                // Get current action text
                oldActionText = setCustomActionText(String.Format(CUSTOM_ACTION_HASHING, numImageHashesComputed, sources.Length));

                // Spawn woker jobs
                jobCount = Math.Min(sources.Length, Environment.ProcessorCount);
                jobList = new Job<bool?>[jobCount];
                for (int i = 0; i < jobCount; ++i)
                {
                    #region Worker job
                    // Create worker
                    jobList[i] = new Job<bool?>((JobParameter<bool?> _data) =>
                    {
                        // Local variables
                        ImageSource src = null;

                        // Get source
                        while (sourceQueue.TryDequeue(out src) == true)
                        {
                            // Compute
                            if (CurrentTechnique.computeHash(src, true) == null)
                                return false;

                            // Update GUI
                            lock(m_dataLock)
                            {
                                // Increment counter
                                ++numImageHashesComputed;

                                // Set text
                                setCustomActionText(String.Format(CUSTOM_ACTION_HASHING, numImageHashesComputed, sources.Length));
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
                    if (j.Result == null || j.Result == false)
                        result = false;
                }

                // Reset action text
                setCustomActionText(oldActionText);

                return result;
                #endregion Watch job
            },
            (JobParameter<bool?> _params) =>
            {
                // Failed?
                if(_params.Result == null || _params.Result == false)
                {
                    setNextState(eState.STATE_READY);
                    MessageBox.Show("Hash computation for the selected image sources failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if(_params.Error != null)
                {
                    setNextState(eState.STATE_READY);
                    MessageBox.Show("An unknown error occurred during the computation of the image hashes!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Continue comparison
                continueComparison(sources);
            });
        }

        // Continues the comparison step (hashing was before!)
        private void continueComparison(ImageSource[] _sourceList)
        {
            // Local variables
            List<ComparisonPair> pairs = new List<ComparisonPair>();
            ConcurrentQueue<ComparisonPair> pairQueue = null;

            // Spawn watch job
            new Job<bool?>((JobParameter<bool?> _params) =>
            {
                #region Watch job
                // Local variables
                Job<bool?>[] jobList = null;
                int jobCount = 0;
                bool result = true;
                int numComparisonsDone = 0;
                string oldActionText = "";

                // Create pairs
                for (int i = 0; i < _sourceList.Length; ++i)
                {
                    for (int j = i; j < _sourceList.Length; ++j)
                    {
                        // Create pair
                        var pair = new ComparisonPair(_sourceList[i], _sourceList[j], CurrentTechnique);
                        pairs.Add(pair);
                    }
                }
                pairQueue = new ConcurrentQueue<ComparisonPair>(pairs);

                // Get current action text
                oldActionText = setCustomActionText(String.Format(CUSTOM_ACTION_COMPARISON, numComparisonsDone, pairs.Count));

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
                        ComparisonPair pair = null;

                        // Get source
                        while (pairQueue.TryDequeue(out pair) == true)
                        {
                            // Compute
                            compResult = pair.ComparatorTechnique.compareHashData(pair.Source0, pair.Source1);
                            if (compResult == null)
                                return false;
                            pair.ComparativeResult = compResult;

                            // Update GUI
                            lock (m_dataLock)
                            {
                                // Increment counter
                                ++numComparisonsDone;

                                // Set text
                                setCustomActionText(String.Format(CUSTOM_ACTION_COMPARISON, numComparisonsDone, pairs.Count));
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
                    if (j.Result == null || j.Result == false)
                        result = false;
                }

                // Add all pairs to the list view
                lock (m_dataLock)
                {
                    m_comparisonPairs = new Dictionary<int, ComparisonPair>(pairs.Count);
                    numComparisonsDone = 0;

                    // Set status
                    setCustomActionText(CUSTOM_ACTION_PROCESS_DATA);

                    // Add pairs to dictionary
                    foreach (ComparisonPair p in pairs)
                    {
                        // Add to dictionary
                        m_comparisonPairs.Add(p.PairID, p);
                    }

                    // Add pairs to list
                    addComparisonPairsToListView(pairs.ToArray());
                }

                // Reset action text
                setCustomActionText(oldActionText);

                return result;
                #endregion Watch job
            },
            (JobParameter<bool?> _params) =>
            {
                // Failed?
                if (_params.Result == null || _params.Result == false)
                {
                    setNextState(eState.STATE_READY);
                    MessageBox.Show("Hash comparison for the selected image sources failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (_params.Error != null)
                {
                    setNextState(eState.STATE_READY);
                    MessageBox.Show("An unknown error occurred during the comparison of the image hashes!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Done
                setNextState(eState.STATE_READY);
            });
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

        // Adds a new comparison pair to the list view
        private void addComparisonPairsToListView(ComparisonPair[] _pairs)
        {
            // Local variables
            ListViewItem[] items = null;
            double match = 0.0;
            double threshold = 0.0;
            decimal tempDecimal = 0.0m;
            Color backgroundColor = Color.White;
            Technique currentTechnique = null;
            Color[] midpointColors = null;

            // Check
            if (_pairs == null || _pairs.Length == 0)
                return;

            // Get technique (all pairs were generated by the same technique)
            currentTechnique = _pairs[0].ComparatorTechnique;
            currentTechnique.getAttribute<decimal>(Technique.ATT_GENERAL_THRESHOLD, out tempDecimal);
            threshold = Convert.ToSingle(tempDecimal) / 100.0;

            // Generate midpoint colors
            midpointColors = generateResultMidpointColors(COLOR_RESULT_ACCEPTED, COLOR_RESULT_DENIED, NUM_MIDPOINTS_COLOR_RESULT);

            // Create items
            items = new ListViewItem[_pairs.Length];
            for (int i = 0; i < _pairs.Length; ++i)
            {
                // Get match rate
                if (_pairs[i].ComparativeResult.getMatchRate() != null)
                    match = (double)_pairs[i].ComparativeResult.getMatchRate();

                // Set background color
                backgroundColor = midpointColors[calculateMidpointColorIndex(threshold, match, NUM_MIDPOINTS_COLOR_RESULT)];

                // Create item
                items[i] = new ListViewItem();
                items[i].Tag = _pairs[i].PairID;
                items[i].ImageIndex = _pairs[i].ComparativeResult.isAccepted() == true ? 0 : 1;
                items[i].BackColor = backgroundColor;

                // Add sub-items: source0, source1, hash0, hash1, match
                items[i].SubItems.Add(Path.GetFileName(_pairs[i].Source0.FilePath));
                items[i].SubItems.Add(Path.GetFileName(_pairs[i].Source1.FilePath));
                items[i].SubItems.Add(_pairs[i].Source0.getHashDataForTechnique(_pairs[i].ComparatorTechnique.ID).convertToString());
                items[i].SubItems.Add(_pairs[i].Source1.getHashDataForTechnique(_pairs[i].ComparatorTechnique.ID).convertToString());
                items[i].SubItems.Add(((int)(match * 100)).ToString());
            }

            // Run in GUI thread
            Utility.invokeInGuiThread(m_listResults, delegate
            {
                // Add to list
                m_listResults.Items.AddRange(items);
            });
        }

        // Generates the midpoint color values for the result list
        private Color[] generateResultMidpointColors(Color _start, Color _end, int _midPointCount)
        {
            // Local variables
            Color[] result = new Color[_midPointCount];
            int stepR = (_end.R - _start.R) / _midPointCount;
            int stepG = (_end.G - _start.G) / _midPointCount;
            int stepB = (_end.B - _start.B) / _midPointCount;
            int curR = _start.R;
            int curG = _start.G;
            int curB = _start.B;

            // Generate values
            for (int i = 0; i < _midPointCount; ++i)
            {
                // Save current color
                result[i] = Color.FromArgb(curR, curG, curB);

                // Increase color value by the step size
                curR += stepR;
                curG += stepG;
                curB += stepB;
            }

            return result;
        }

        // Calculates the index for the midpoint color from the threshold and the match-rate
        // 0 -> accepted, n -> denied
        private int calculateMidpointColorIndex(double _threshold, double _matchRate, int _midPointCount)
        {
            // Get the ratio between the match rate and the threshold
            double ratio = _matchRate / _threshold;

            // Limit it to 100% (if the match rate exceeds the threshold, the ratio will be higher than 100%!)
            if (ratio > 1.0) ratio = 1.0;

            // Invert the ration and calculate the index (zero-based)
            return (int)Math.Floor((1.0 - ratio) * _midPointCount);
        }

        #region Events: Controls
        // Event List::onColumnWidthChanging
        void onColumnWidthChanging(object _sender, ColumnWidthChangingEventArgs _e)
        {
            _e.NewWidth = m_listResults.Columns[_e.ColumnIndex].Width;
            _e.Cancel = true;
        }

        // Event List::onColumnClick
        void onColumnClick(object _sender, ColumnClickEventArgs _e)
        {
            // Same column
            if (_e.Column == m_listResultsSorter.ColumnIndex)
            {
                // Reverse the current sort direction for this column.
                if (m_listResultsSorter.SortOrder == SortOrder.Ascending)
                    m_listResultsSorter.SortOrder = SortOrder.Descending;
                else
                    m_listResultsSorter.SortOrder = SortOrder.Ascending;
            }
            else
            {
                // Set the column index (default to ascending)
                m_listResultsSorter.ColumnIndex = _e.Column;
                m_listResultsSorter.SortOrder = SortOrder.Ascending;
            }

            // Sort list
            m_listResults.Sort();
        }

        // Event List::onItemSelectionChanged
        void onItemSelectionChanged(object _sender, ListViewItemSelectionChangedEventArgs _e)
        {
            // Contains pair's ID
            if(m_comparisonPairs.ContainsKey((int)_e.Item.Tag) == false)
            {
                m_popupWindow.Hide();
                return;
            }

            // Show pip-up window
            m_popupWindow.Show(m_listResults, m_popupPosition);

            // Set data
            m_comparatorDetails.setComparisonPair(m_comparisonPairs[(int)_e.Item.Tag]);
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
                startComparisonHashing();
        }
        #endregion Events: Controls
    }
}