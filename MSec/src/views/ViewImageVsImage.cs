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

        // The data lock
        private object               m_dataLock = new object();

        // Controls
        private ImageSourceSelection m_controlImageSourceSelection0 = null;
        private ImageSourceSelection m_controlImageSourceSelection1 = null;
        private Button               m_controlButtonCompute = null;

        // Comparator stuff
        private int                  m_numSetImageSources = 0;
        private Comparator           m_imageSourceCompartor = null;

        // Delegate functions
        private delegate void       delegate_enableButtonCompute(bool _enable);

        // Constructor
        public ViewImageVsImage(TabPage _tabPage) :
            base(_tabPage, "Selection_Technique")
        {
            // Extract image source selection controls
            m_controlImageSourceSelection0 = _tabPage.Controls.Find("Selection_ImageSource0", true)[0] as ImageSourceSelection;
            m_controlImageSourceSelection1 = _tabPage.Controls.Find("Selection_ImageSource1", true)[0] as ImageSourceSelection;

            // Add event handler to source selection controls
            m_controlImageSourceSelection0.OnImageSourceChanged += OnImageSourceChanged;
            m_controlImageSourceSelection1.OnImageSourceChanged += OnImageSourceChanged;

            // Extract button: compute
            m_controlButtonCompute = _tabPage.Controls.Find("Button_ImageVsImage_Compute", true)[0] as Button;
            m_controlButtonCompute.Click += onButtonComputeClicked;
        }

        // Event: ImageSourceSelection::OnImageSourceChanged
        public void OnImageSourceChanged(bool _deleted = false)
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
        }
    }
}
