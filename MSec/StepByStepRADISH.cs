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
    public partial class StepByStepRADISH : Form
    {
        // Constant values
        private static readonly string LABEL_LOADING            = "Image data is being computed...";
        private static readonly string LABEL_ORIGINAL           = "Original image";
        private static readonly string LABEL_GRAYSCALE          = "1. Convert to grayscale image";
        private static readonly string LABEL_BLURRED            = "2. Blur and gamma-correct image";
        private static readonly string LABEL_RADON_MAP          = "3. Radon projection";
        private static readonly string LABEL_FEATURE_VECTOR     = "4. Extract feature vector";
        private static readonly string LABEL_DCT                = "5. DCT of the feature vector";

        private StepByStepLargerImage   m_largerImageView = null;
        private Popup                   m_popupWindow = null;

        // Constructor
        public StepByStepRADISH(UnfoldedBindingComparisonPair _pair)
        {
            InitializeComponent();

            // Set labels to loading
            SS_Label_Radish_Original.Text       = LABEL_LOADING;
            SS_Label_Radish_Blurred.Text        = LABEL_LOADING;
            SS_Label_Radish_DCT.Text            = LABEL_LOADING;
            SS_Label_Radish_FeatureVector.Text  = LABEL_LOADING;
            SS_Label_Radish_Grayscale.Text      = LABEL_LOADING;
            SS_Label_Radish_RadonMap.Text       = LABEL_LOADING;

            // Create pop-up window (larger view)
            m_largerImageView = new StepByStepLargerImage();
            m_popupWindow = new Popup(m_largerImageView);
            m_popupWindow.HidingAnimation = PopupAnimations.None;
            m_popupWindow.ShowingAnimation = PopupAnimations.None;
            m_popupWindow.FocusOnOpen = false;

            // Add click events to picture boxes
            addLargerImageViewPopupTo(SS_Picture_Radish_Original_0);
            addLargerImageViewPopupTo(SS_Picture_Radish_Grayscale_0);
            addLargerImageViewPopupTo(SS_Picture_Radish_Blurred_0);
            addLargerImageViewPopupTo(SS_Picture_Radish_Radon_0);
            addLargerImageViewPopupTo(SS_Picture_Radish_Feature_0);
            addLargerImageViewPopupTo(SS_Picture_Radish_DCT_0);

            addLargerImageViewPopupTo(SS_Picture_Radish_Original_1);
            addLargerImageViewPopupTo(SS_Picture_Radish_Grayscale_1);
            addLargerImageViewPopupTo(SS_Picture_Radish_Blurred_1);
            addLargerImageViewPopupTo(SS_Picture_Radish_Radon_1);
            addLargerImageViewPopupTo(SS_Picture_Radish_Feature_1);
            addLargerImageViewPopupTo(SS_Picture_Radish_DCT_1);

            // Create job
            new Job<bool?>((JobParameter<bool?> _params) =>
            {
                // Dump pair to disk
                if (!DumpTechniqueStepsToDisk.dumpRadishStepsToDiskFor(_pair))
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
                    SS_Label_Radish_Original.Text       = LABEL_ORIGINAL;
                    SS_Label_Radish_Blurred.Text        = LABEL_BLURRED;
                    SS_Label_Radish_DCT.Text            = LABEL_DCT;
                    SS_Label_Radish_FeatureVector.Text  = LABEL_FEATURE_VECTOR;
                    SS_Label_Radish_Grayscale.Text      = LABEL_GRAYSCALE;
                    SS_Label_Radish_RadonMap.Text       = LABEL_RADON_MAP;

                    // Source 0
                    SS_Picture_Radish_Original_0.BackgroundImage = Image.FromFile(_pair.Source0.FilePath);
                    SS_Picture_Radish_Grayscale_0.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.RADISH_PATH_GRAYSCALE, 0));
                    SS_Picture_Radish_Blurred_0.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.RADISH_PATH_BLURRED, 0));
                    SS_Picture_Radish_Radon_0.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.RADISH_PATH_RADONMAP, 0));
                    SS_Picture_Radish_Feature_0.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.RADISH_PATH_FEATUREVECTOR, 0));
                    SS_Picture_Radish_DCT_0.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.RADISH_PATH_DCT, 0));

                    // Source 1
                    SS_Picture_Radish_Original_1.BackgroundImage = Image.FromFile(_pair.Source1.FilePath);
                    SS_Picture_Radish_Grayscale_1.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.RADISH_PATH_GRAYSCALE, 1));
                    SS_Picture_Radish_Blurred_1.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.RADISH_PATH_BLURRED, 1));
                    SS_Picture_Radish_Radon_1.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.RADISH_PATH_RADONMAP, 1));
                    SS_Picture_Radish_Feature_1.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.RADISH_PATH_FEATUREVECTOR, 1));
                    SS_Picture_Radish_DCT_1.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.RADISH_PATH_DCT, 1));
                });
            });
        }

        // Event: Form::Closing
        private void StepByStepRADISH_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dispose images
            disposeBackgroundImageFrom(SS_Picture_Radish_Original_0);
            disposeBackgroundImageFrom(SS_Picture_Radish_Grayscale_0);
            disposeBackgroundImageFrom(SS_Picture_Radish_Blurred_0);
            disposeBackgroundImageFrom(SS_Picture_Radish_Radon_0);
            disposeBackgroundImageFrom(SS_Picture_Radish_Feature_0);
            disposeBackgroundImageFrom(SS_Picture_Radish_DCT_0);

            disposeBackgroundImageFrom(SS_Picture_Radish_Original_1);
            disposeBackgroundImageFrom(SS_Picture_Radish_Grayscale_1);
            disposeBackgroundImageFrom(SS_Picture_Radish_Blurred_1);
            disposeBackgroundImageFrom(SS_Picture_Radish_Radon_1);
            disposeBackgroundImageFrom(SS_Picture_Radish_Feature_1);
            disposeBackgroundImageFrom(SS_Picture_Radish_DCT_1);
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
