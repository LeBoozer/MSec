/*******************************************************************************************************************************************************************
	File	:	ViewImageVsImage.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*******************************************************************************************************************************************************************
	Class: ViewImageVsImage
*******************************************************************************************************************************************************************/
namespace MSec
{
    public sealed class ViewImageVsImage : ViewWithTechniqueSelection
    {
        // Constants
        private static readonly string MSG_ERROR_IMAGES_NOT_SET = "Image data is invalid/not set!";
        private static readonly string MSG_ERROR_COMPUTATION    = "Unknown error!";
        private static readonly string STATE_COMPUTING_HASH     = "Hash is being computed...";

        // The data lock
        private object               m_dataLock = new object();

        // Controls
        private ImageSourceSelection m_controlImageSourceSelection0 = null;
        private ImageSourceSelection m_controlImageSourceSelection1 = null;
        private Button               m_controlButtonCompute = null;
        private Label                m_controlLabelResult = null;
        private ProgressBar          m_controlProgressBar = null;

        // Comparator stuff
        private int                  m_numSetImageSources = 0;

        // Delegate functions
        private delegate void       delegate_enableButtonCompute(bool _enable);

        // Constructor
        public ViewImageVsImage(TabPage _tabPage) :
            base(_tabPage, "Selection_Technique")
        {
            // Extract image source selection controls
            m_controlImageSourceSelection0 = _tabPage.Controls.Find("Selection_ImageSource0", true)[0] as ImageSourceSelection;
            m_controlImageSourceSelection1 = _tabPage.Controls.Find("Selection_ImageSource1", true)[0] as ImageSourceSelection;

            // Add event handler to technique selction control
            ControlTechniqueSel.OnAttributeChanged += onTechniqueAttributeChanged;
            ControlTechniqueSel.OnTechniqueChanged += (TechniqueID _nextTechnique) => { onTechniqueAttributeChanged(); };

            // Add event handler to source selection controls
            m_controlImageSourceSelection0.OnImageSourceChanged += OnImageSourceChanged;
            m_controlImageSourceSelection1.OnImageSourceChanged += OnImageSourceChanged;

            // Extract button: compute
            m_controlButtonCompute = _tabPage.Controls.Find("Button_ImageVsImage_Compute", true)[0] as Button;
            m_controlButtonCompute.Click += onButtonComputeClicked;

            // Extract label, progress bar
            m_controlLabelResult = _tabPage.Controls.Find("Label_ImageVsImage_Result", true)[0] as Label;
            m_controlProgressBar = _tabPage.Controls.Find("Progress_ImageVsImage", true)[0] as ProgressBar;
        }

        // Clears all displays of texts
        private void clearDisplayText()
        {
            // Clear instruction texts
            Utility.invokeInGuiThread(m_tabPage, delegate
            {
                m_controlImageSourceSelection0.setInstructionText("");
                m_controlImageSourceSelection1.setInstructionText("");

                m_controlLabelResult.ForeColor = System.Drawing.Color.Black;
                m_controlLabelResult.Text = "-";
            });
        }

        // Will be called as soon as an attribute of the currently set technique has been changed
        private void onTechniqueAttributeChanged()
        {
            // Clear text
            clearDisplayText();
        }

        // Event: ImageSourceSelection::OnImageSourceChanged
        private void OnImageSourceChanged(bool _deleted = false)
        {
            // Local variables
            bool changeState = false;

            // Adjust counter
            lock(m_dataLock)
            {
                m_numSetImageSources += (_deleted == true) ? -1 : 1;
                if (m_numSetImageSources < 0)
                    m_numSetImageSources = 0;
                else if (m_numSetImageSources > 2)
                    m_numSetImageSources = 2;
            }

            // Clear text
            clearDisplayText();

            // Disable/enable button
            if (m_controlButtonCompute.Enabled == true && m_numSetImageSources < 2)
                changeState = true;
            else if (m_controlButtonCompute.Enabled == false && m_numSetImageSources == 2)
                changeState = true;

            // Change button state
            if (changeState == true)
            {
                // Run in GUI thread
                Utility.invokeInGuiThread(m_tabPage, delegate
                {
                    m_controlButtonCompute.Enabled = !m_controlButtonCompute.Enabled;
                });
            }
        }

        // Event: Button::Click: Compute
        private void onButtonComputeClicked(object _sender, EventArgs _e)
        {
            // Local variables
            Job<ComparativeData> jg = null;

            // Validate
            if(m_controlImageSourceSelection0.Source == null || m_controlImageSourceSelection1.Source == null)
            {
                MessageBox.Show(MSG_ERROR_IMAGES_NOT_SET, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Prepare 
            m_controlButtonCompute.Enabled = false;
            lockTechniqueSelection();
            m_controlImageSourceSelection0.lockImageSourceSelection();
            m_controlImageSourceSelection1.lockImageSourceSelection();
            m_controlProgressBar.Visible = m_controlProgressBar.Enabled = true;

            // Set states: computing
            m_controlImageSourceSelection0.setInstructionText(STATE_COMPUTING_HASH);
            m_controlImageSourceSelection1.setInstructionText(STATE_COMPUTING_HASH);

            // Create job
            jg = new Job<ComparativeData>((JobParameter<ComparativeData> _params) =>
            {
                // Local variables
                ComparativeData result = null;
                Job<HashData> j0 = null, j1 = null;

                // Create jobs: computing hashes
                j0 = Job<HashData>.createJobComputeHash(m_controlImageSourceSelection0.Source, CurrentTechnique,
                    (JobParameter<HashData> _r) =>
                    {
                        // Display hash
                        m_controlImageSourceSelection0.setInstructionText(_r.Result.convertToString());
                    },
                    false);
                j1 = Job<HashData>.createJobComputeHash(m_controlImageSourceSelection1.Source, CurrentTechnique,
                    (JobParameter<HashData> _r) =>
                    {
                        // Display hash
                        m_controlImageSourceSelection1.setInstructionText(_r.Result.convertToString());
                    },
                    false);

                // Start jobs
                Job<HashData>.enqueue(j0);
                Job<HashData>.enqueue(j1);

                // Wait for jobs
                j0.waitForDone();
                j1.waitForDone();

                // Compare hashes
                result = CurrentTechnique.compareHashData(m_controlImageSourceSelection0.Source, m_controlImageSourceSelection1.Source);

                return result;
            },
            (JobParameter<ComparativeData> _r) =>
            {
                // Run in GUI thread
                Utility.invokeInGuiThread(m_tabPage, delegate
                {
                    // Set result or error
                    if (_r.Error != null)
                        m_controlLabelResult.Text = _r.Error.Message;
                    else if (_r == null)
                        m_controlLabelResult.Text = MSG_ERROR_COMPUTATION;
                    else
                        m_controlLabelResult.Text = _r.Result.convertToString();

                    // Accepted?
                    if (_r.Result.isAccepted() == true)
                        m_controlLabelResult.ForeColor = System.Drawing.Color.DarkGreen;
                    else
                        m_controlLabelResult.ForeColor = System.Drawing.Color.DarkRed;

                    // Undo the preparations 
                    m_controlButtonCompute.Enabled = true;
                    unlockTechniqueSelection();
                    m_controlImageSourceSelection0.unlockImageSourceSelection();
                    m_controlImageSourceSelection1.unlockImageSourceSelection();
                    m_controlProgressBar.Visible = m_controlProgressBar.Enabled = false;
                });
            });
        }
    }
}
