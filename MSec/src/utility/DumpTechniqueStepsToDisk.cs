/*******************************************************************************************************************************************************************
	File	:	DumpTechniqueStepsToDisk.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

/*******************************************************************************************************************************************************************
	Class: DumpTechniqueStepsToDisk
*******************************************************************************************************************************************************************/
namespace MSec
{
    public static class DumpTechniqueStepsToDisk
    {
        // Constant values
        public static readonly string   TARGET_FOLDER = "TempData\\";

        public static readonly int      RADISH_PATH_COUNT           = 5;
        public static readonly string   RADISH_PATH_GRAYSCALE       = "radish_{0}_grayscale.jpeg";
        public static readonly string   RADISH_PATH_BLURRED         = "radish_{0}_blurred.jpeg";
        public static readonly string   RADISH_PATH_RADONMAP        = "radish_{0}_radonmap.jpeg";
        public static readonly string   RADISH_PATH_FEATUREVECTOR   = "radish_{0}_featurevector.jpeg";
        public static readonly string   RADISH_PATH_DCT             = "radish_{0}_dct.jpeg";

        public static readonly int      DCT_PATH_COUNT              = 6;
        public static readonly string   DCT_PATH_MEANFILTER         = "dct_{0}_meanfilter.jpeg";
        public static readonly string   DCT_PATH_RESIZED            = "dct_{0}_resized.jpeg";
        public static readonly string   DCT_PATH_DCTMATRIX          = "dct_{0}_dctmatrix.jpeg";
        public static readonly string   DCT_PATH_DCTIMAGE           = "dct_{0}_dctimage.jpeg";
        public static readonly string   DCT_PATH_DCTIMAGE_SUBSEC    = "dct_{0}_dctimagesubsec.jpeg";
        public static readonly string   DCT_PATH_MEDIAN             = "dct_{0}_median.jpeg";

        public static readonly int      WAVELET_PATH_COUNT          = 4;
        public static readonly string   WAVELET_PATH_BLURRED        = "wavelet_{0}_blurred.jpeg";
        public static readonly string   WAVELET_PATH_KERNEL         = "wavelet_{0}_kernel.jpeg";
        public static readonly string   WAVELET_PATH_EDGES          = "wavelet_{0}_edges.jpeg";
        public static readonly string   WAVELET_PATH_BLOCKS         = "wavelet_{0}_blocks.jpeg";

        public static readonly int      BMB_PATH_COUNT              = 3;
        public static readonly string   BMB_PATH_RESIZED            = "bmb_{0}_resized.jpeg";
        public static readonly string   BMB_PATH_BLOCK_MEDIANS      = "bmb_{0}_blockmedians.jpeg";
        public static readonly string   BMB_PATH_MEDIAN             = "bmb_{0}_median.jpeg";

        // Dumps a compairison pair for the technique "RADISH" to disk 
        public static bool dumpRadishStepsToDiskFor(UnfoldedBindingComparisonPair _pair)
        {
            // Local variables
            Technique t = Technique.createTechniqueRadish();
            string[] pathesSource0 = new string[RADISH_PATH_COUNT];
            string[] pathesSource1 = new string[RADISH_PATH_COUNT];

            // Create pathes
            pathesSource0[0] = TARGET_FOLDER + string.Format(RADISH_PATH_GRAYSCALE, 0);
            pathesSource0[1] = TARGET_FOLDER + string.Format(RADISH_PATH_BLURRED, 0);
            pathesSource0[2] = TARGET_FOLDER + string.Format(RADISH_PATH_RADONMAP, 0);
            pathesSource0[3] = TARGET_FOLDER + string.Format(RADISH_PATH_FEATUREVECTOR, 0);
            pathesSource0[4] = TARGET_FOLDER + string.Format(RADISH_PATH_DCT, 0);

            pathesSource1[0] = TARGET_FOLDER + string.Format(RADISH_PATH_GRAYSCALE, 1);
            pathesSource1[1] = TARGET_FOLDER + string.Format(RADISH_PATH_BLURRED, 1);
            pathesSource1[2] = TARGET_FOLDER + string.Format(RADISH_PATH_RADONMAP, 1);
            pathesSource1[3] = TARGET_FOLDER + string.Format(RADISH_PATH_FEATUREVECTOR, 1);
            pathesSource1[4] = TARGET_FOLDER + string.Format(RADISH_PATH_DCT, 1);

            // First source
            var j0 = new Job<bool?>((JobParameter<bool?> _params) =>
            {
                // Dump to disk
                return t.dumpIntermediateResultsToDisk(_pair.Source0, pathesSource0);
            },
            (JobParameter<bool?> _params) =>
            {}
            );

            // Second source
            var j1 = new Job<bool?>((JobParameter<bool?> _params) =>
            {
                // Dump to disk
                return t.dumpIntermediateResultsToDisk(_pair.Source1, pathesSource1);
            },
            (JobParameter<bool?> _params) =>
            {}
            );

            // Wait for jobs
            j0.waitForDone();
            j1.waitForDone();

            return j0.Result.Value && j1.Result.Value;
        }

        // Dumps a compairison pair for the technique "DCT" to disk 
        public static bool dumpDCTStepsToDiskFor(UnfoldedBindingComparisonPair _pair)
        {
            // Local variables
            Technique t = Technique.createTechniqueDCT();
            string[] pathesSource0 = new string[DCT_PATH_COUNT];
            string[] pathesSource1 = new string[DCT_PATH_COUNT];

            // Create pathes
            pathesSource0[0] = TARGET_FOLDER + string.Format(DCT_PATH_MEANFILTER, 0);
            pathesSource0[1] = TARGET_FOLDER + string.Format(DCT_PATH_RESIZED, 0);
            pathesSource0[2] = TARGET_FOLDER + string.Format(DCT_PATH_DCTMATRIX, 0);
            pathesSource0[3] = TARGET_FOLDER + string.Format(DCT_PATH_DCTIMAGE, 0);
            pathesSource0[4] = TARGET_FOLDER + string.Format(DCT_PATH_DCTIMAGE_SUBSEC, 0);
            pathesSource0[5] = TARGET_FOLDER + string.Format(DCT_PATH_MEDIAN, 0);

            pathesSource1[0] = TARGET_FOLDER + string.Format(DCT_PATH_MEANFILTER, 1);
            pathesSource1[1] = TARGET_FOLDER + string.Format(DCT_PATH_RESIZED, 1);
            pathesSource1[2] = TARGET_FOLDER + string.Format(DCT_PATH_DCTMATRIX, 1);
            pathesSource1[3] = TARGET_FOLDER + string.Format(DCT_PATH_DCTIMAGE, 1);
            pathesSource1[4] = TARGET_FOLDER + string.Format(DCT_PATH_DCTIMAGE_SUBSEC, 1);
            pathesSource1[5] = TARGET_FOLDER + string.Format(DCT_PATH_MEDIAN, 1);

            // First source
            var j0 = new Job<bool?>((JobParameter<bool?> _params) =>
            {
                // Dump to disk
                return t.dumpIntermediateResultsToDisk(_pair.Source0, pathesSource0);
            },
            (JobParameter<bool?> _params) =>
            {
                if (_params.Error != null)
                    MessageBox.Show(_params.Error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            );

            // Second source
            var j1 = new Job<bool?>((JobParameter<bool?> _params) =>
            {
                // Dump to disk
                return t.dumpIntermediateResultsToDisk(_pair.Source1, pathesSource1);
            },
            (JobParameter<bool?> _params) =>
            {
                if (_params.Error != null)
                    MessageBox.Show(_params.Error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            );

            // Wait for jobs
            j0.waitForDone();
            j1.waitForDone();

            return j0.Result.Value && j1.Result.Value;
        }

        // Dumps a compairison pair for the technique "Wavelet" to disk 
        public static bool dumpWaveletStepsToDiskFor(UnfoldedBindingComparisonPair _pair)
        {
            // Local variables
            Technique t = Technique.createTechniqueWavelet();
            string[] pathesSource0 = new string[WAVELET_PATH_COUNT];
            string[] pathesSource1 = new string[WAVELET_PATH_COUNT];

            // Create pathes
            pathesSource0[0] = TARGET_FOLDER + string.Format(WAVELET_PATH_BLURRED, 0);
            pathesSource0[1] = TARGET_FOLDER + string.Format(WAVELET_PATH_KERNEL, 0);
            pathesSource0[2] = TARGET_FOLDER + string.Format(WAVELET_PATH_EDGES, 0);
            pathesSource0[3] = TARGET_FOLDER + string.Format(WAVELET_PATH_BLOCKS, 0);

            pathesSource1[0] = TARGET_FOLDER + string.Format(WAVELET_PATH_BLURRED, 1);
            pathesSource1[1] = TARGET_FOLDER + string.Format(WAVELET_PATH_KERNEL, 1);
            pathesSource1[2] = TARGET_FOLDER + string.Format(WAVELET_PATH_EDGES, 1);
            pathesSource1[3] = TARGET_FOLDER + string.Format(WAVELET_PATH_BLOCKS, 1);

            // First source
            var j0 = new Job<bool?>((JobParameter<bool?> _params) =>
            {
                // Dump to disk
                return t.dumpIntermediateResultsToDisk(_pair.Source0, pathesSource0);
            },
            (JobParameter<bool?> _params) =>
            {
                if (_params.Error != null)
                    MessageBox.Show(_params.Error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            );

            // Second source
            var j1 = new Job<bool?>((JobParameter<bool?> _params) =>
            {
                // Dump to disk
                return t.dumpIntermediateResultsToDisk(_pair.Source1, pathesSource1);
            },
            (JobParameter<bool?> _params) =>
            {
                if (_params.Error != null)
                    MessageBox.Show(_params.Error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            );

            // Wait for jobs
            j0.waitForDone();
            j1.waitForDone();

            return j0.Result.Value && j1.Result.Value;
        }

        // Dumps a compairison pair for the technique "BMB" to disk 
        public static bool dumpBMBStepsToDiskFor(UnfoldedBindingComparisonPair _pair)
        {
            // Local variables
            Technique t = Technique.createTechniqueBMB();
            string[] pathesSource0 = new string[BMB_PATH_COUNT];
            string[] pathesSource1 = new string[BMB_PATH_COUNT];

            // Create pathes
            pathesSource0[0] = TARGET_FOLDER + string.Format(BMB_PATH_RESIZED, 0);
            pathesSource0[1] = TARGET_FOLDER + string.Format(BMB_PATH_BLOCK_MEDIANS, 0);
            pathesSource0[2] = TARGET_FOLDER + string.Format(BMB_PATH_MEDIAN, 0);

            pathesSource1[0] = TARGET_FOLDER + string.Format(BMB_PATH_RESIZED, 1);
            pathesSource1[1] = TARGET_FOLDER + string.Format(BMB_PATH_BLOCK_MEDIANS, 1);
            pathesSource1[2] = TARGET_FOLDER + string.Format(BMB_PATH_MEDIAN, 1);

            // First source
            var j0 = new Job<bool?>((JobParameter<bool?> _params) =>
            {
                // Dump to disk
                return t.dumpIntermediateResultsToDisk(_pair.Source0, pathesSource0);
            },
            (JobParameter<bool?> _params) =>
            {
                if (_params.Error != null)
                    MessageBox.Show(_params.Error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            );

            // Second source
            var j1 = new Job<bool?>((JobParameter<bool?> _params) =>
            {
                // Dump to disk
                return t.dumpIntermediateResultsToDisk(_pair.Source1, pathesSource1);
            },
            (JobParameter<bool?> _params) =>
            {
                if (_params.Error != null)
                    MessageBox.Show(_params.Error.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            );

            // Wait for jobs
            j0.waitForDone();
            j1.waitForDone();

            return j0.Result.Value && j1.Result.Value;
        }

        // Delete all files in the target folder
        public static void cleanTargetFolder()
        {
            // Local variables
            DirectoryInfo dirInfo = new DirectoryInfo(TARGET_FOLDER);

            // Delete all files
            foreach (FileInfo file in dirInfo.GetFiles())
                file.Delete();
        }
    }
}