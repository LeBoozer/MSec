using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Luminous.Windows.Forms;

namespace MSec
{
    public partial class StepByStepDCT : Form
    {
        // Constant values
        private static readonly string LABEL_LOADING            = "Image data is being computed...";
        private static readonly string LABEL_MEAN_ORIGINAL      = "Original image";
        private static readonly string LABEL_MEAN_FILTER        = "1. Apply mean filter";
        private static readonly string LABEL_RESIZED            = "2. Resize image to 32x32";
        private static readonly string LABEL_DCT_MATRIX         = "3. Generated DCT matrix";
        private static readonly string LABEL_DCT_IMAGE          = "4. Image frequencies";
        private static readonly string LABEL_DCT_IMAGE_SUBSEC   = "5. Low image frequencies";
        private static readonly string LABEL_MEDIAN             = "6. Median of low frequencies";

        private StepByStepLargerImage   m_largerImageView = null;
        private Popup                   m_popupWindow = null;

        // Constructor
        public StepByStepDCT(UnfoldedBindingComparisonPair _pair)
        {
            InitializeComponent();

            // Set labels to loading
            SS_Label_DCT_Original.Text          = LABEL_LOADING;
            SS_Label_DCT_MeanFilter.Text        = LABEL_LOADING;
            SS_Label_DCT_Resized.Text           = LABEL_LOADING;
            SS_Label_DCT_DCTMatrix.Text         = LABEL_LOADING;
            SS_Label_DCT_DCTImage.Text          = LABEL_LOADING;
            SS_Label_DCT_DCTImageSubSec.Text    = LABEL_LOADING;
            SS_Label_DCT_Median.Text            = LABEL_LOADING;

            // Create pop-up window (larger view)
            m_largerImageView = new StepByStepLargerImage();
            m_popupWindow = new Popup(m_largerImageView);
            m_popupWindow.HidingAnimation = PopupAnimations.None;
            m_popupWindow.ShowingAnimation = PopupAnimations.None;
            m_popupWindow.FocusOnOpen = false;

            // Add click events to picture boxes
            addLargerImageViewPopupTo(SS_Picture_DCT_Original_0);
            addLargerImageViewPopupTo(SS_Picture_DCT_MeanFilter_0);
            addLargerImageViewPopupTo(SS_Picture_DCT_Resized_0);
            addLargerImageViewPopupTo(SS_Picture_DCT_DCTMatrix_0);
            addLargerImageViewPopupTo(SS_Picture_DCT_DCTImage_0);
            addLargerImageViewPopupTo(SS_Picture_DCT_DCTImageSubSec_0);
            addLargerImageViewPopupTo(SS_Picture_DCT_Median_0);

            addLargerImageViewPopupTo(SS_Picture_DCT_Original_1);
            addLargerImageViewPopupTo(SS_Picture_DCT_MeanFilter_1);
            addLargerImageViewPopupTo(SS_Picture_DCT_Resized_1);
            addLargerImageViewPopupTo(SS_Picture_DCT_DCTMatrix_1);
            addLargerImageViewPopupTo(SS_Picture_DCT_DCTImage_1);
            addLargerImageViewPopupTo(SS_Picture_DCT_DCTImageSubSec_1);
            addLargerImageViewPopupTo(SS_Picture_DCT_Median_1);

            // Create job
            new Job<bool?>((JobParameter<bool?> _params) =>
            {
                // Dump pair to disk
                if (!DumpTechniqueStepsToDisk.dumpDCTStepsToDiskFor(_pair))
                    return false;

                return true;
            },
            (JobParameter<bool?> _params) =>
            {
                // Failed?
                if (_params.Error != null)
                {
                    MessageBox.Show(_params.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (_params.Result == null || _params.Result == false)
                {
                    MessageBox.Show("Dumping to disk failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Set image location
                Utility.invokeInGuiThread(this, delegate
                {
                    // Set labels to loading
                    SS_Label_DCT_Original.Text          = LABEL_MEAN_ORIGINAL;
                    SS_Label_DCT_MeanFilter.Text        = LABEL_MEAN_FILTER;
                    SS_Label_DCT_Resized.Text           = LABEL_RESIZED;
                    SS_Label_DCT_DCTMatrix.Text         = LABEL_DCT_MATRIX;
                    SS_Label_DCT_DCTImage.Text          = LABEL_DCT_IMAGE;
                    SS_Label_DCT_DCTImageSubSec.Text    = LABEL_DCT_IMAGE_SUBSEC;
                    SS_Label_DCT_Median.Text            = LABEL_MEDIAN;

                    // Source 0
                    SS_Picture_DCT_Original_0.BackgroundImage = Image.FromFile(_pair.Source0.FilePath);
                    SS_Picture_DCT_MeanFilter_0.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.DCT_PATH_MEANFILTER, 0));
                    SS_Picture_DCT_Resized_0.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.DCT_PATH_RESIZED, 0));
                    SS_Picture_DCT_DCTMatrix_0.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.DCT_PATH_DCTMATRIX, 0));
                    SS_Picture_DCT_DCTImage_0.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.DCT_PATH_DCTIMAGE, 0));
                    SS_Picture_DCT_DCTImageSubSec_0.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.DCT_PATH_DCTIMAGE_SUBSEC, 0));
                    SS_Picture_DCT_Median_0.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.DCT_PATH_MEDIAN, 0));

                    // Source 1
                    SS_Picture_DCT_Original_1.BackgroundImage = Image.FromFile(_pair.Source1.FilePath);
                    SS_Picture_DCT_MeanFilter_1.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.DCT_PATH_MEANFILTER, 1));
                    SS_Picture_DCT_Resized_1.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.DCT_PATH_RESIZED, 1));
                    SS_Picture_DCT_DCTMatrix_1.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.DCT_PATH_DCTMATRIX, 1));
                    SS_Picture_DCT_DCTImage_1.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.DCT_PATH_DCTIMAGE, 1));
                    SS_Picture_DCT_DCTImageSubSec_1.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.DCT_PATH_DCTIMAGE_SUBSEC, 1));
                    SS_Picture_DCT_Median_1.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.DCT_PATH_MEDIAN, 1));
                });
            });
        }

        // Event: Form::Closing
        private void StepByStepDCT_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dispose images
            disposeBackgroundImageFrom(SS_Picture_DCT_Original_0);
            disposeBackgroundImageFrom(SS_Picture_DCT_MeanFilter_0);
            disposeBackgroundImageFrom(SS_Picture_DCT_Resized_0);
            disposeBackgroundImageFrom(SS_Picture_DCT_DCTMatrix_0);
            disposeBackgroundImageFrom(SS_Picture_DCT_DCTImage_0);
            disposeBackgroundImageFrom(SS_Picture_DCT_DCTImageSubSec_0);
            disposeBackgroundImageFrom(SS_Picture_DCT_Median_0);

            disposeBackgroundImageFrom(SS_Picture_DCT_Original_1);
            disposeBackgroundImageFrom(SS_Picture_DCT_MeanFilter_1);
            disposeBackgroundImageFrom(SS_Picture_DCT_Resized_1);
            disposeBackgroundImageFrom(SS_Picture_DCT_DCTMatrix_1);
            disposeBackgroundImageFrom(SS_Picture_DCT_DCTImage_1);
            disposeBackgroundImageFrom(SS_Picture_DCT_DCTImageSubSec_1);
            disposeBackgroundImageFrom(SS_Picture_DCT_Median_1);
        }

        // Add a click event to the target, to pop-up the larger image view 
        private void addLargerImageViewPopupTo(PictureBox _target)
        {
            // Add event
            _target.Click += (object _sender, EventArgs _e) =>
            {
                // Set image location and show pop-up window
                m_largerImageView.setBackgroundImage(_target.BackgroundImage);
                m_popupWindow.Show(_target);
            };
        }

        // Disposes the background image from the given target
        private void disposeBackgroundImageFrom(PictureBox _target)
        {
            if (_target.BackgroundImage != null)
                _target.BackgroundImage.Dispose();
        }
    }
}
