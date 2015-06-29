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
using System.IO;

/*******************************************************************************************************************************************************************
	Class: CC_ComparisonDetails
*******************************************************************************************************************************************************************/
namespace MSec
{
    public partial class CC_ComparisonDetails : UserControl
    {
        // Constants
        private static readonly string TEXT_LOADING_IMAGE_SOURCE = "Loading image source...";
        private static readonly string TEXT_TEMPLATE_TIMING      = "{0}s / {1}s";

        // The data lock
        private object m_dataLock = new object();

        // The host view
        private ViewCrossComparison m_hostView = null;

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
        public void setComparisonPair(ViewCrossComparison _hostView, UnfoldedBindingComparisonPair _pair)
        {
            // Local variables
            Job<Image>.delegate_job func = null;
            Job<Image>.delegate_job_done funcDone = null;

            // Set host
            m_hostView = _hostView;

            // Lock data
            lock (m_dataLock)
            {
                // Cancel old jobs
                if (m_jobLoadingSource0 != null)
                {
                    m_jobLoadingSource0.cancel();
                    m_jobLoadingSource0 = null;
                }
                if (m_jobLoadingSource1 != null)
                {
                    m_jobLoadingSource1.cancel();
                    m_jobLoadingSource1 = null;
                }

                // Run in GUI thread
                Utility.invokeInGuiThread(this, delegate
                {
                    // Delete images
                    if (m_pictureSource0.BackgroundImage != null)
                    {
                        m_pictureSource0.BackgroundImage.Dispose();
                        m_pictureSource0.BackgroundImage = null;
                    }
                    if (m_pictureSource1.BackgroundImage != null)
                    {
                        m_pictureSource1.BackgroundImage.Dispose();
                        m_pictureSource1.BackgroundImage = null;
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
                        // Local variables
                        DirectoryInfo dirInfo = new DirectoryInfo((_params.Data[0] as ImageSource).FilePath);

                        // Set image
                        (_params.Data[1] as PictureBox).BackgroundImage = _params.Result;

                        // Set text
                        (_params.Data[2] as TextBox).Text = dirInfo.Parent.Name + "\\" + dirInfo.Name;
                    });
                }
            };

            // Create jobs
            m_jobLoadingSource0 = new Job<Image>(func, funcDone, true, new object[] { _pair.Source0, m_pictureSource0, m_textSource0 });
            m_jobLoadingSource1 = new Job<Image>(func, funcDone, true, new object[] { _pair.Source1, m_pictureSource1, m_textSource1 });

            // Set timings
            setTimingsFor(TechniqueID.RADISH, _pair.Binding0, _pair.Binding1);
            setTimingsFor(TechniqueID.DCT, _pair.Binding0, _pair.Binding1);
            setTimingsFor(TechniqueID.WAVELET, _pair.Binding0, _pair.Binding1);
            setTimingsFor(TechniqueID.BMB, _pair.Binding0, _pair.Binding1);
        }

        // Sets the timings for a certain technique
        private void setTimingsFor(TechniqueID _id, ImageSourceBinding _b0, ImageSourceBinding _b1)
        {
            // Local variables
            Label loadingLabel = null;
            Label computationLabel = null;
            Label totalLabel = null;
            bool validData = false;
            string loadingString0 = "-";
            string computationString0 = "-";
            string totalString0 = "-";
            string loadingString1 = "-";
            string computationString1 = "-";
            string totalString1 = "-";

            // Get label references
            if(_id == TechniqueID.RADISH)
            {
                // Set references
                loadingLabel = CC_Label_Loading_RADISH;
                computationLabel = CC_Label_Computation_RADISH;
                totalLabel = CC_Label_Total_RADISH;
            }
            else if(_id == TechniqueID.DCT)
            {
                // Set references
                loadingLabel = CC_Label_Loading_DCT;
                computationLabel = CC_Label_Computation_DCT;
                totalLabel = CC_Label_Total_DCT;
            }
            else if (_id == TechniqueID.WAVELET)
            {
                // Set references
                loadingLabel = CC_Label_Loading_Wavelet;
                computationLabel = CC_Label_Computation_Wavelet;
                totalLabel = CC_Label_Total_Wavelet;
            }
            else
            {
                // Set references
                loadingLabel = CC_Label_Loading_BMB;
                computationLabel = CC_Label_Computation_BMB;
                totalLabel = CC_Label_Total_BMB;
            }

            // Get timings for the first image
            if(_b0.getComparisonDataFor(_id) != null && _b0.getComparisonDataFor(_id).HashData.getTimings() != null)
            {
                loadingString0 = _b0.getComparisonDataFor(_id).HashData.getTimings().getFormattedLoadingTime();
                computationString0 = _b0.getComparisonDataFor(_id).HashData.getTimings().getFormattedComputationTime();
                totalString0 = _b0.getComparisonDataFor(_id).HashData.getTimings().getFormattedTotalTime();
                validData = true;
            }

            // Get timings for the second image
            if (_b1.getComparisonDataFor(_id) != null && _b1.getComparisonDataFor(_id).HashData.getTimings() != null)
            {
                loadingString1 = _b1.getComparisonDataFor(_id).HashData.getTimings().getFormattedLoadingTime();
                computationString1 = _b1.getComparisonDataFor(_id).HashData.getTimings().getFormattedComputationTime();
                totalString1 = _b1.getComparisonDataFor(_id).HashData.getTimings().getFormattedTotalTime();
                validData = true;
            }

            // Set timings
            if (loadingLabel != null)
            {
                if (validData == true)
                {
                    loadingLabel.Text = string.Format(TEXT_TEMPLATE_TIMING, loadingString0, loadingString1);
                    computationLabel.Text = string.Format(TEXT_TEMPLATE_TIMING, computationString0, computationString1);
                    totalLabel.Text = string.Format(TEXT_TEMPLATE_TIMING, totalString0, totalString1);
                }
                else
                {
                    loadingLabel.Text = "-";
                    computationLabel.Text = "-";
                    totalLabel.Text = "-";
                }
            }
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

        private void CC_Button_StepByStep_RADISH_Click(object sender, EventArgs e)
        {
            m_hostView.dumpToDiskAndShowStepByStepFor(TechniqueID.RADISH, CurrentPair);
        }

        private void CC_Button_StepByStep_DCT_Click(object sender, EventArgs e)
        {
            m_hostView.dumpToDiskAndShowStepByStepFor(TechniqueID.DCT, CurrentPair);
        }

        private void CC_Button_StepByStep_Wavelet_Click(object sender, EventArgs e)
        {
            m_hostView.dumpToDiskAndShowStepByStepFor(TechniqueID.WAVELET, CurrentPair);
        }

        private void CC_Button_StepByStep_BMB_Click(object sender, EventArgs e)
        {
            m_hostView.dumpToDiskAndShowStepByStepFor(TechniqueID.BMB, CurrentPair);
        }
    }
}
