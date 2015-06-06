/*******************************************************************************************************************************************************************
	File	:	CC_MultiSelectionStats.cs
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
	Class: CC_MultiSelectionStats
*******************************************************************************************************************************************************************/
namespace MSec
{
    public partial class CC_MultiSelectionStats : UserControl
    {
        // Controls
        private TextBox     m_textNumberOfItems = null;
        private TextBox     m_textAVGMatchRateRADISH = null;
        private TextBox     m_textAVGMatchRateDCT = null;
        private TextBox     m_textAVGMatchRateWavelet = null;
        private TextBox     m_textAVGMatchRateBMB = null;
        private TextBox     m_textAVGMatchRateAVG = null;

        // Constructor
        public CC_MultiSelectionStats()
        {
            // Initialize the user control's component
            InitializeComponent();

            // Get controls
            m_textNumberOfItems = this.CC_Text_NumberOfItems;
            m_textAVGMatchRateRADISH = this.CC_Text_AVGMatchRate_RADISH;
            m_textAVGMatchRateDCT = this.CC_Text_AVGMatchRate_DCT;
            m_textAVGMatchRateWavelet = this.CC_Text_AVGMatchRate_Wavelet;
            m_textAVGMatchRateBMB = this.CC_Text_AVGMatchRate_BMB;
            m_textAVGMatchRateAVG = this.CC_Text_AVGMatchRate_AVG;
        }

        // Sets the selected items
        public void setSelectedItems(IEnumerable<UnfoldedBindingComparisonPair> _pairs)
        {
            // Local variables
            int count = 0;
            int avgRADISH = -1;
            int minRADISH = int.MaxValue;
            int maxRADISH = int.MinValue;
            int numBelowThresholdRADISH = 0;
            int avgDCT = -1;
            int minDCT = int.MaxValue;
            int maxDCT = int.MinValue;
            int numBelowThresholdDCT = 0;
            int avgWavelet = -1;
            int minWavelet = int.MaxValue;
            int maxWavelet = int.MinValue;
            int numBelowThresholdWavelet = 0;
            int avgBMB = -1;
            int minBMB = int.MaxValue;
            int maxBMB = int.MinValue;
            int numBelowThresholdBMB = 0;
            int avgAVG = -1;
            int minAVG = int.MaxValue;
            int maxAVG = int.MinValue;
            int numBelowThresholdAVG = 0;

            // Loop through all items
            foreach(var item in _pairs)
            {
                // RADISH
                avgRADISH += item.MatchRateRADISH;
                if (minRADISH > item.MatchRateRADISH)
                    minRADISH = item.MatchRateRADISH;
                if (maxRADISH < item.MatchRateRADISH)
                    maxRADISH = item.MatchRateRADISH;
                if (item.MatchRateRADISH < item.Threshold)
                    ++numBelowThresholdRADISH;

                // DCT
                avgDCT += item.MatchRateDCT;
                if (minDCT > item.MatchRateDCT)
                    minDCT = item.MatchRateDCT;
                if (maxDCT < item.MatchRateDCT)
                    maxDCT = item.MatchRateDCT;
                if (item.MatchRateDCT < item.Threshold)
                    ++numBelowThresholdDCT;

                // Wavelet
                avgWavelet += item.MatchRateWavelet;
                if (minWavelet > item.MatchRateWavelet)
                    minWavelet = item.MatchRateWavelet;
                if (maxWavelet < item.MatchRateWavelet)
                    maxWavelet = item.MatchRateWavelet;
                if (item.MatchRateWavelet < item.Threshold)
                    ++numBelowThresholdWavelet;

                // BMB
                avgBMB += item.MatchRateBMB;
                if (minBMB > item.MatchRateBMB)
                    minBMB = item.MatchRateBMB;
                if (maxBMB < item.MatchRateBMB)
                    maxBMB = item.MatchRateBMB;
                if (item.MatchRateBMB < item.Threshold)
                    ++numBelowThresholdBMB;

                // AVG
                avgAVG += item.MatchRateAVG;
                if (minAVG > item.MatchRateAVG)
                    minAVG = item.MatchRateAVG;
                if (maxAVG < item.MatchRateAVG)
                    maxAVG = item.MatchRateAVG;
                if (item.MatchRateAVG < item.Threshold)
                    ++numBelowThresholdAVG;

                // Increase counter
                ++count;
            }

            // Create averages
            avgRADISH /= count;
            avgDCT /= count;
            avgWavelet /= count;
            avgBMB /= count;
            avgAVG /= count;

            // Set stats
            m_textNumberOfItems.Text = count.ToString();
            m_textAVGMatchRateRADISH.Text = String.Format("{0} / {1} / {2}\t({3} < t, {4} >= t)", minRADISH, avgRADISH, maxRADISH, numBelowThresholdRADISH, count - numBelowThresholdRADISH);
            m_textAVGMatchRateDCT.Text = String.Format("{0} / {1} / {2}\t({3} < t, {4} >= t)", minDCT, avgDCT, maxDCT, numBelowThresholdDCT, count - numBelowThresholdDCT);
            m_textAVGMatchRateWavelet.Text = String.Format("{0} / {1} / {2}\t({3} < t, {4} >= t)", minWavelet, avgWavelet, maxWavelet, numBelowThresholdWavelet, count - numBelowThresholdWavelet);
            m_textAVGMatchRateBMB.Text = String.Format("{0} / {1} / {2}\t({3} < t, {4} >= t)", minBMB, avgBMB, maxBMB, numBelowThresholdBMB, count - numBelowThresholdBMB);
            m_textAVGMatchRateAVG.Text = String.Format("{0} / {1} / {2}\t({3} < t, {4} >= t)", minAVG, avgAVG, maxAVG, numBelowThresholdAVG, count - numBelowThresholdAVG);
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
