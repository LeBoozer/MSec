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
    public partial class StepByStepBMB : Form
    {
        // Constant values
        private static readonly string LABEL_GROUP              = "Source {0} ({1})";
        private static readonly string LABEL_LOADING            = "Image data is being computed...";
        private static readonly string LABEL_ORIGINAL           = "Original image";
        private static readonly string LABEL_RESIZED            = "1. Grayscale and resize image";
        private static readonly string LABEL_BLOCK_MEDIANS      = "2. Compute blocks' medians";
        private static readonly string LABEL_MEDIAN             = "3. Median of the blocks";

        private StepByStepLargerImage   m_largerImageView = null;
        private Popup                   m_popupWindow = null;

        // Constructor
        public StepByStepBMB(UnfoldedBindingComparisonPair _pair)
        {
            InitializeComponent();

            // Set labels to loading
            SS_Label_BMB_Original.Text      = LABEL_LOADING;
            SS_Label_BMB_Resized.Text       = LABEL_LOADING;
            SS_Label_BMB_BlockMedians.Text  = LABEL_LOADING;
            SS_Label_BMB_Median.Text        = LABEL_LOADING;

            // Create pop-up window (larger view)
            m_largerImageView = new StepByStepLargerImage();
            m_popupWindow = new Popup(m_largerImageView);
            m_popupWindow.HidingAnimation = PopupAnimations.None;
            m_popupWindow.ShowingAnimation = PopupAnimations.None;
            m_popupWindow.FocusOnOpen = false;

            // Add click events to picture boxes
            addLargerImageViewPopupTo(SS_Picture_BMB_Original_0);
            addLargerImageViewPopupTo(SS_Picture_BMB_Resized_0);
            addLargerImageViewPopupTo(SS_Picture_BMB_BlockMedians_0);
            addLargerImageViewPopupTo(SS_Picture_BMB_Median_0);

            addLargerImageViewPopupTo(SS_Picture_BMB_Original_1);
            addLargerImageViewPopupTo(SS_Picture_BMB_Resized_1);
            addLargerImageViewPopupTo(SS_Picture_BMB_BlockMedians_1);
            addLargerImageViewPopupTo(SS_Picture_BMB_Median_1);

            // Set group labels
            SS_Group_BMB_0.Text = string.Format(LABEL_GROUP, 0, _pair.Source0.FilePath);
            SS_Group_BMB_1.Text = string.Format(LABEL_GROUP, 1, _pair.Source1.FilePath);

            // Create job
            new Job<bool?>((JobParameter<bool?> _params) =>
            {
                // Dump pair to disk
                if (!DumpTechniqueStepsToDisk.dumpBMBStepsToDiskFor(_pair))
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
                    SS_Label_BMB_Original.Text      = LABEL_ORIGINAL;
                    SS_Label_BMB_Resized.Text       = LABEL_RESIZED;
                    SS_Label_BMB_BlockMedians.Text  = LABEL_BLOCK_MEDIANS;
                    SS_Label_BMB_Median.Text        = LABEL_MEDIAN;

                    // Source 0
                    SS_Picture_BMB_Original_0.BackgroundImage = Image.FromFile(_pair.Source0.FilePath);
                    SS_Picture_BMB_Resized_0.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.BMB_PATH_RESIZED, 0));
                    SS_Picture_BMB_BlockMedians_0.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.BMB_PATH_BLOCK_MEDIANS, 0));
                    SS_Picture_BMB_Median_0.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.BMB_PATH_MEDIAN, 0));

                    // Source 1
                    SS_Picture_BMB_Original_1.BackgroundImage = Image.FromFile(_pair.Source1.FilePath);
                    SS_Picture_BMB_Resized_1.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.BMB_PATH_RESIZED, 1));
                    SS_Picture_BMB_BlockMedians_1.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.BMB_PATH_BLOCK_MEDIANS, 1));
                    SS_Picture_BMB_Median_1.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.BMB_PATH_MEDIAN, 1));
                });
            });
        }

        // Event: Form::Closing
        private void StepByStepBMB_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dispose images
            disposeBackgroundImageFrom(SS_Picture_BMB_Original_0);
            disposeBackgroundImageFrom(SS_Picture_BMB_Resized_0);
            disposeBackgroundImageFrom(SS_Picture_BMB_BlockMedians_0);
            disposeBackgroundImageFrom(SS_Picture_BMB_Median_0);

            disposeBackgroundImageFrom(SS_Picture_BMB_Original_1);
            disposeBackgroundImageFrom(SS_Picture_BMB_Resized_1);
            disposeBackgroundImageFrom(SS_Picture_BMB_BlockMedians_1);
            disposeBackgroundImageFrom(SS_Picture_BMB_Median_1);
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
