using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSec
{
    public partial class HashingInformation : Form
    {
        // Constant values
        private static readonly string TEXT_TEMPLATE_TIMING = "{0}s";
        private static readonly string TEXT_TEMPLATE_RATIO = "{0}%";

        // Constructor
        public HashingInformation()
        {
            InitializeComponent();
        }

        // Updates the hashing information
        public void setData(ImageSourceBinding[] _bindings)
        {
            // Local variables
            int countDCT = 0;
            int countRADISH = 0;
            int countWavelet = 0;
            int countBMB = 0;
            int countAVG = 0;

            double timeLoadingTemp = 0.0, timeComputationTemp = 0.0;
            double timeLoadingDCT = 0.0, timeComputationDCT = 0.0;
            double timeLoadingRADISH = 0.0, timeComputationRADISH = 0.0;
            double timeLoadingWavelet = 0.0, timeComputationWavelet = 0.0;
            double timeLoadingBMB = 0.0, timeComputationBMB = 0.0;
            double timeLoadingAVG = 0.0, timeComputationAVG = 0.0;

            double ratioRADISH = 0.0;
            double ratioDCT = 0.0;
            double ratioWavelet = 0.0;
            double ratioBMB = 0.0;
            double ratioAVG = 0.0;

            // Loop through all bindings
            foreach(var b in _bindings)
            {
                // RADISH
                if(getTimingsFor(b, TechniqueID.RADISH, out timeLoadingTemp, out timeComputationTemp) == true)
                {
                    timeLoadingRADISH += timeLoadingTemp;
                    timeComputationRADISH += timeComputationTemp;
                    ++countRADISH;
                }

                // DCT
                if (getTimingsFor(b, TechniqueID.DCT, out timeLoadingTemp, out timeComputationTemp) == true)
                {
                    timeLoadingDCT += timeLoadingTemp;
                    timeComputationDCT += timeComputationTemp;
                    ++countDCT;
                }

                // Wavelet
                if (getTimingsFor(b, TechniqueID.WAVELET, out timeLoadingTemp, out timeComputationTemp) == true)
                {
                    timeLoadingWavelet += timeLoadingTemp;
                    timeComputationWavelet += timeComputationTemp;
                    ++countWavelet;
                }

                // BMB
                if (getTimingsFor(b, TechniqueID.BMB, out timeLoadingTemp, out timeComputationTemp) == true)
                {
                    timeLoadingBMB += timeLoadingTemp;
                    timeComputationBMB += timeComputationTemp;
                    ++countBMB;
                }
            }

            // Compute average, ratio
            if(countRADISH > 0)
            {
                timeLoadingRADISH /= countRADISH;
                timeComputationRADISH /= countRADISH;
                ratioRADISH = timeComputationRADISH / (timeComputationRADISH + timeLoadingRADISH);
                ++countAVG;
            }
            if (countDCT > 0)
            {
                timeLoadingDCT /= countDCT;
                timeComputationDCT /= countDCT;
                ratioDCT = timeComputationDCT / (timeComputationDCT + timeLoadingDCT);
                ++countAVG;
            }
            if (countWavelet > 0)
            {
                timeLoadingWavelet /= countWavelet;
                timeComputationWavelet /= countWavelet;
                ratioWavelet = timeComputationWavelet / (timeComputationWavelet + timeLoadingWavelet);
                ++countAVG;
            }
            if (countBMB > 0)
            {
                timeLoadingBMB /= countBMB;
                timeComputationBMB /= countBMB;
                ratioBMB = timeComputationBMB / (timeComputationBMB + timeLoadingBMB);
                ++countAVG;
            }
            if (countAVG > 0)
            {
                timeLoadingAVG = (timeLoadingRADISH + timeLoadingDCT + timeLoadingWavelet + timeLoadingBMB) / countAVG;
                timeComputationAVG = (timeComputationRADISH + timeComputationDCT + timeComputationWavelet + timeComputationBMB) / countAVG;
                ratioAVG = timeComputationAVG / (timeComputationAVG + timeLoadingAVG);
            }

            // Set text
            Label_Loading_RADISH.Text = countRADISH == 0 ? "-" : string.Format(TEXT_TEMPLATE_TIMING, timeLoadingRADISH.ToString("#0.000"));
            Label_Computation_RADISH.Text = countRADISH == 0 ? "-" : string.Format(TEXT_TEMPLATE_TIMING, timeComputationRADISH.ToString("#0.000"));
            Label_Total_RADISH.Text = countRADISH == 0 ? "-" : string.Format(TEXT_TEMPLATE_TIMING, (timeLoadingRADISH + timeComputationRADISH).ToString("#0.000"));
            Label_LC_RADISH.Text = countRADISH == 0 ? "-" : string.Format(TEXT_TEMPLATE_RATIO, (int)(ratioRADISH * 100.0));

            Label_Loading_DCT.Text = countDCT == 0 ? "-" : string.Format(TEXT_TEMPLATE_TIMING, timeLoadingDCT.ToString("#0.000"));
            Label_Computation_DCT.Text = countDCT == 0 ? "-" : string.Format(TEXT_TEMPLATE_TIMING, timeComputationDCT.ToString("#0.000"));
            Label_Total_DCT.Text = countDCT == 0 ? "-" : string.Format(TEXT_TEMPLATE_TIMING, (timeLoadingDCT + timeComputationDCT).ToString("#0.000"));
            Label_LC_DCT.Text = countDCT == 0 ? "-" : string.Format(TEXT_TEMPLATE_RATIO, (int)(ratioDCT * 100.0));

            Label_Loading_Wavelet.Text = countWavelet == 0 ? "-" : string.Format(TEXT_TEMPLATE_TIMING, timeLoadingWavelet.ToString("#0.000"));
            Label_Computation_Wavelet.Text = countWavelet == 0 ? "-" : string.Format(TEXT_TEMPLATE_TIMING, timeComputationWavelet.ToString("#0.000"));
            Label_Total_Wavelet.Text = countWavelet == 0 ? "-" : string.Format(TEXT_TEMPLATE_TIMING, (timeLoadingWavelet + timeComputationWavelet).ToString("#0.000"));
            Label_LC_Wavelet.Text = countWavelet == 0 ? "-" : string.Format(TEXT_TEMPLATE_RATIO, (int)(ratioWavelet * 100.0));

            Label_Loading_BMB.Text = countBMB == 0 ? "-" : string.Format(TEXT_TEMPLATE_TIMING, timeLoadingBMB.ToString("#0.000"));
            Label_Computation_BMB.Text = countBMB == 0 ? "-" : string.Format(TEXT_TEMPLATE_TIMING, timeComputationBMB.ToString("#0.000"));
            Label_Total_BMB.Text = countBMB == 0 ? "-" : string.Format(TEXT_TEMPLATE_TIMING, (timeLoadingBMB + timeComputationBMB).ToString("#0.000"));
            Label_LC_BMB.Text = countBMB == 0 ? "-" : string.Format(TEXT_TEMPLATE_RATIO, (int)(ratioBMB * 100.0));

            Label_Loading_AVG.Text = countAVG == 0 ? "-" : string.Format(TEXT_TEMPLATE_TIMING, timeLoadingAVG.ToString("#0.000"));
            Label_Computation_AVG.Text = countAVG == 0 ? "-" : string.Format(TEXT_TEMPLATE_TIMING, timeComputationAVG.ToString("#0.000"));
            Label_Total_AVG.Text = countAVG == 0 ? "-" : string.Format(TEXT_TEMPLATE_TIMING, (timeLoadingAVG + timeComputationAVG).ToString("#0.000"));
            Label_LC_AVG.Text = countAVG == 0 ? "-" : string.Format(TEXT_TEMPLATE_RATIO, (int)(ratioAVG * 100.0));
        }

        // Retrieves the timings for a certain image and technique
        private bool getTimingsFor(ImageSourceBinding _binding, TechniqueID _id, out double _loadingTime, out double _computationTime)
        {
            // Local variables
            HashDataTimings timings = null;

            // Check parameter
            if (_binding == null || _binding.getComparisonDataFor(_id) == null || _binding.getComparisonDataFor(_id).HashData.getTimings() == null)
            {
                _loadingTime = _computationTime = 0.0;
                return false;
            }
            timings = _binding.getComparisonDataFor(_id).HashData.getTimings();

            // Set data
            _loadingTime = timings.ImageLoadingTimeMS;
            _computationTime = timings.HashComputationTimeMS;

            return true;
        }
    }
}
