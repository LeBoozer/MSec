/*******************************************************************************************************************************************************************
	File	:	ViewCrossComparison.cs
	Project	:	MSec
	Author	:	Byron Worms
    Links   :   http://www.codeproject.com/Articles/17502/Simple-Popup-Control
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Luminous.Windows.Forms;

/*******************************************************************************************************************************************************************
	Class: ViewImageVsImage
*******************************************************************************************************************************************************************/
namespace MSec
{
    public class ViewCrossComparison : ViewWithTechniqueSelection
    {
        // Constants
        private static readonly string  ACTION_IDLE = "Waiting for user input...";

        // All possible states
        private enum eState
        {
            STATE_NONE, // Just initialization!
            STATE_IDLE
        }

        // The data lock
        private object                  m_dataLock = new object();

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
        private ToolStripLabel          m_labelAction = null;
        private ToolStripProgressBar    m_progressBar = null;

        // Constructor
        public ViewCrossComparison(TabPage _tabPage) :
            base(_tabPage, "CC_Selection_Technique")
        {
            // Local variables
            int x = 0;
            int y = 0;

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
            m_labelAction = (_tabPage.Controls.Find("CC_ToolStrip", true)[0] as ToolStrip).Items.Find("CC_ToolStrip_Label_Action", true)[0] as ToolStripLabel;
            m_progressBar = (_tabPage.Controls.Find("CC_ToolStrip", true)[0] as ToolStrip).Items.Find("CC_ToolStrip_Progress", true)[0] as ToolStripProgressBar;

            // Add events to: list of results
            m_listResults.ItemSelectionChanged += onItemSelectionChanged;

            // Add events to: buttons
            m_buttonReferenceFolderSelect.Click += onButtonReferenceFolderSelectClick;
            m_buttonReferenceFolderDelete.Click += onButtonReferenceFolderDeleteClick;

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

                // Execute state changes
                Utility.invokeInGuiThread(m_tabPage, m_onStateEnter);
            }
        }

        #region Events: Controls
        // Event List::onItemSelectionChanged
        void onItemSelectionChanged(object _sender, ListViewItemSelectionChangedEventArgs _e)
        {
            // Show pip-up window
            m_popupWindow.Show(m_listResults, m_popupPosition);
        }

        // Event Button::onButtonReferenceFolderSelect_Click
        void onButtonReferenceFolderSelectClick(object sender, EventArgs e)
        {
        }

        // Event Button::onButtonReferenceFolderDeleteClick
        void onButtonReferenceFolderDeleteClick(object sender, EventArgs e)
        {
        }
        #endregion Events: Controls
    }
}
