/*******************************************************************************************************************************************************************
	File	:	CC_ComparisonDetails.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*******************************************************************************************************************************************************************
	Class: CC_ComparisonDetails
*******************************************************************************************************************************************************************/
namespace MSec
{
    public partial class CC_ComparisonDetails : UserControl
    {
        // Constants
        private static readonly string TEXT_LOADING_IMAGE_SOURCE = "Loading image source...";

        // The data lock
        private object m_dataLock = new object();

        // The current set comparison pair
        private UnfoldedBindingComparisonPair m_pair = null;
        public UnfoldedBindingComparisonPair CurrentPair
        {
            get { return m_pair; }
            private set { }
        }

        // Controls
        private PictureBox m_pictureSource0 = null;
        private PictureBox m_pictureSource1 = null;
        private TextBox    m_textSource0 = null;
        private TextBox    m_textSource1 = null;

        // Loading jobs
        private Job<Image> m_jobLoadingSource0 = null;
        private Job<Image> m_jobLoadingSource1 = null;

        // Constructor
        public CC_ComparisonDetails()
        {
            // Initialize the user control's component
            InitializeComponent();

            // Get controls
            m_pictureSource0 = this.CC_Picture_Source0;
            m_pictureSource1 = this.CC_Picture_Source_1;
            m_textSource0    = this.CC_Text_Source0;
            m_textSource1    = this.CC_Text_Source1;
        }

        // Updates the control's content with a comparison pair (null to delete content)
        public void setComparisonPair(UnfoldedBindingComparisonPair _pair)
        {
            // Local variables
            Job<Image>.delegate_job func = null;
            Job<Image>.delegate_job_done funcDone = null;

            // Lock data
            lock(m_dataLock)
            {
                // Cancel old jobs
                if(m_jobLoadingSource0 != null)
                {
                    m_jobLoadingSource0.cancel();
                    m_jobLoadingSource0 = null;
                }
                if(m_jobLoadingSource1 != null)
                {
                    m_jobLoadingSource1.cancel();
                    m_jobLoadingSource1 = null;
                }

                // Run in GUI thread
                Utility.invokeInGuiThread(this, delegate
                {
                    // Delete images
                    if (m_pictureSource0.Image != null)
                    {
                        m_pictureSource0.Image.Dispose();
                        m_pictureSource0.Image = null;
                    }
                    if (m_pictureSource1.Image != null)
                    {
                        m_pictureSource1.Image.Dispose();
                        m_pictureSource1.Image = null;
                    }

                    // Reset GUI content
                    if (_pair == null)
                        m_textSource0.Text = m_textSource1.Text = "";
                    else
                        m_textSource0.Text = m_textSource1.Text = TEXT_LOADING_IMAGE_SOURCE;
                });
            }

            // Copy
            m_pair = _pair;
            if (m_pair == null)
                return;

            // Job function
            func = (JobParameter<Image> _params) =>
            {
                // Cancelled?
                if (_params.IsCancellationRequested == true)
                    _params.dropJob();

                // Create bitmap
                return (_params.Data[0] as ImageSource).createSystemImage();
            };

            // Job done function
            funcDone = (JobParameter<Image> _params) =>
            {
                // Lock data
                lock (m_dataLock)
                {
                    // Cancelled?
                    if (_params.IsCancellationRequested == true)
                    {
                        // Delete image
                        _params.Result.Dispose();

                        // Drop
                        _params.dropJob();
                    }

                    // Run in GUI thread
                    Utility.invokeInGuiThread(this, delegate
                    {
                        // Set image
                        (_params.Data[1] as PictureBox).Image = _params.Result;

                        // Set text
                        (_params.Data[2] as TextBox).Text = (_params.Data[0] as ImageSource).FilePath;
                    });
                }
            };

            // Create jobs
            m_jobLoadingSource0 = new Job<Image>(func, funcDone, true, new object[] { _pair.Source0, m_pictureSource0, m_textSource0 });
            m_jobLoadingSource1 = new Job<Image>(func, funcDone, true, new object[] { _pair.Source1, m_pictureSource1, m_textSource1 });
        }

        // Override: UserControl::OnPaint
        protected override void OnPaint(PaintEventArgs _e)
        {
            // Call parental function
            base.OnPaint(_e);

            // Draw custom border
            ControlPaint.DrawBorder(_e.Graphics, ClientRectangle,
                                         Color.DimGray, 1, ButtonBorderStyle.Inset,
                                         Color.DimGray, 2, ButtonBorderStyle.Inset,
                                         Color.DimGray, 2, ButtonBorderStyle.Inset,
                                         Color.DimGray, 2, ButtonBorderStyle.Inset);
        }
    }
}
