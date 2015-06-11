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
    public partial class StepByStepWavelet : Form
    {
        // Constant values
        private static readonly string LABEL_GROUP              = "Source {0} ({1})";
        private static readonly string LABEL_LOADING            = "Image data is being computed...";
        private static readonly string LABEL_ORIGINAL           = "Original image";
        private static readonly string LABEL_BLURRED            = "1. Blur, resize and equalize";
        private static readonly string LABEL_KERNEL             = "2. Kernel";
        private static readonly string LABEL_EDGES              = "3. Edge-detection";
        private static readonly string LABEL_BLOCKS             = "4. Compute blocks' medians";


        private StepByStepLargerImage   m_largerImageView = null;
        private Popup                   m_popupWindow = null;

        // Constructor
        public StepByStepWavelet(UnfoldedBindingComparisonPair _pair)
        {
            InitializeComponent();

            // Set labels to loading
            SS_Label_Wavelet_Original.Text      = LABEL_LOADING;
            SS_Label_Wavelet_Blurred.Text       = LABEL_LOADING;
            SS_Label_Wavelet_Kernel.Text        = LABEL_LOADING;
            SS_Label_Wavelet_Edges.Text         = LABEL_LOADING;
            SS_Label_Wavelet_Blocks.Text        = LABEL_LOADING;

            // Create pop-up window (larger view)
            m_largerImageView = new StepByStepLargerImage();
            m_popupWindow = new Popup(m_largerImageView);
            m_popupWindow.HidingAnimation = PopupAnimations.None;
            m_popupWindow.ShowingAnimation = PopupAnimations.None;
            m_popupWindow.FocusOnOpen = false;

            // Add click events to picture boxes
            addLargerImageViewPopupTo(SS_Picture_Wavelet_Original_0);
            addLargerImageViewPopupTo(SS_Picture_Wavelet_Blurred_0);
            addLargerImageViewPopupTo(SS_Picture_Wavelet_Kernel_0);
            addLargerImageViewPopupTo(SS_Picture_Wavelet_Edges_0);
            addLargerImageViewPopupTo(SS_Picture_Wavelet_Blocks_0);

            addLargerImageViewPopupTo(SS_Picture_Wavelet_Original_1);
            addLargerImageViewPopupTo(SS_Picture_Wavelet_Blurred_1);
            addLargerImageViewPopupTo(SS_Picture_Wavelet_Kernel_1);
            addLargerImageViewPopupTo(SS_Picture_Wavelet_Edges_1);
            addLargerImageViewPopupTo(SS_Picture_Wavelet_Blocks_1);

            // Set group labels
            SS_Group_Wavelet_0.Text = string.Format(LABEL_GROUP, 0, _pair.Source0.FilePath);
            SS_Group_Wavelet_1.Text = string.Format(LABEL_GROUP, 1, _pair.Source1.FilePath);

            // Create job
            new Job<bool?>((JobParameter<bool?> _params) =>
            {
                // Dump pair to disk
                if (!DumpTechniqueStepsToDisk.dumpWaveletStepsToDiskFor(_pair))
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
                    SS_Label_Wavelet_Original.Text      = LABEL_ORIGINAL;
                    SS_Label_Wavelet_Blurred.Text       = LABEL_BLURRED;
                    SS_Label_Wavelet_Kernel.Text        = LABEL_KERNEL;
                    SS_Label_Wavelet_Edges.Text         = LABEL_EDGES;
                    SS_Label_Wavelet_Blocks.Text        = LABEL_BLOCKS;

                    // Source 0
                    SS_Picture_Wavelet_Original_0.BackgroundImage = Image.FromFile(_pair.Source0.FilePath);
                    SS_Picture_Wavelet_Blurred_0.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.WAVELET_PATH_BLURRED, 0));
                    SS_Picture_Wavelet_Kernel_0.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.WAVELET_PATH_KERNEL, 0));
                    SS_Picture_Wavelet_Edges_0.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.WAVELET_PATH_EDGES, 0));
                    SS_Picture_Wavelet_Blocks_0.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.WAVELET_PATH_BLOCKS, 0));

                    // Source 1
                    SS_Picture_Wavelet_Original_1.BackgroundImage = Image.FromFile(_pair.Source1.FilePath);
                    SS_Picture_Wavelet_Blurred_1.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.WAVELET_PATH_BLURRED, 1));
                    SS_Picture_Wavelet_Kernel_1.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.WAVELET_PATH_KERNEL, 1));
                    SS_Picture_Wavelet_Edges_1.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.WAVELET_PATH_EDGES, 1));
                    SS_Picture_Wavelet_Blocks_1.BackgroundImage = Image.FromFile(DumpTechniqueStepsToDisk.TARGET_FOLDER + string.Format(DumpTechniqueStepsToDisk.WAVELET_PATH_BLOCKS, 1));
                });
            });
        }

        // Event: Form::Closing
        private void StepByStepWavelet_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Dispose images
            disposeBackgroundImageFrom(SS_Picture_Wavelet_Original_0);
            disposeBackgroundImageFrom(SS_Picture_Wavelet_Blurred_0);
            disposeBackgroundImageFrom(SS_Picture_Wavelet_Kernel_0);
            disposeBackgroundImageFrom(SS_Picture_Wavelet_Edges_0);
            disposeBackgroundImageFrom(SS_Picture_Wavelet_Blocks_0);

            disposeBackgroundImageFrom(SS_Picture_Wavelet_Original_1);
            disposeBackgroundImageFrom(SS_Picture_Wavelet_Blurred_1);
            disposeBackgroundImageFrom(SS_Picture_Wavelet_Kernel_1);
            disposeBackgroundImageFrom(SS_Picture_Wavelet_Edges_1);
            disposeBackgroundImageFrom(SS_Picture_Wavelet_Blocks_1);
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
