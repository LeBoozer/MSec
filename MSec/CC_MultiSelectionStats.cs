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
            int avgDCT = -1;
            int minDCT = int.MaxValue;
            int maxDCT = int.MinValue;
            int avgWavelet = -1;
            int minWavelet = int.MaxValue;
            int maxWavelet = int.MinValue;
            int avgBMB = -1;
            int minBMB = int.MaxValue;
            int maxBMB = int.MinValue;
            int avgAVG = -1;
            int minAVG = int.MaxValue;
            int maxAVG = int.MinValue;

            // Loop through all items
            foreach(var item in _pairs)
            {
                // RADISH
                avgRADISH += item.MatchRateRADISH;
                if (minRADISH > item.MatchRateRADISH)
                    minRADISH = item.MatchRateRADISH;
                if (maxRADISH < item.MatchRateRADISH)
                    maxRADISH = item.MatchRateRADISH;

                // DCT
                avgDCT += item.MatchRateDCT;
                if (minDCT > item.MatchRateDCT)
                    minDCT = item.MatchRateDCT;
                if (maxDCT < item.MatchRateDCT)
                    maxDCT = item.MatchRateDCT;

                // Wavelet
                avgWavelet += item.MatchRateWavelet;
                if (minWavelet > item.MatchRateWavelet)
                    minWavelet = item.MatchRateWavelet;
                if (maxWavelet < item.MatchRateWavelet)
                    maxWavelet = item.MatchRateWavelet;

                // BMB
                avgBMB += item.MatchRateBMB;
                if (minBMB > item.MatchRateBMB)
                    minBMB = item.MatchRateBMB;
                if (maxBMB < item.MatchRateBMB)
                    maxBMB = item.MatchRateBMB;

                // AVG
                avgAVG += item.MatchRateAVG;
                if (minAVG > item.MatchRateAVG)
                    minAVG = item.MatchRateAVG;
                if (maxAVG < item.MatchRateAVG)
                    maxAVG = item.MatchRateAVG;

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
            m_textAVGMatchRateRADISH.Text = String.Format("{0} / {1} / {2}", minRADISH, avgRADISH, maxRADISH);
            m_textAVGMatchRateDCT.Text = String.Format("{0} / {1} / {2}", minDCT, avgDCT, maxDCT);
            m_textAVGMatchRateWavelet.Text = String.Format("{0} / {1} / {2}", minWavelet, avgWavelet, maxWavelet);
            m_textAVGMatchRateBMB.Text = String.Format("{0} / {1} / {2}", minBMB, avgBMB, maxBMB);
            m_textAVGMatchRateAVG.Text = String.Format("{0} / {1} / {2}", minAVG, avgAVG, maxAVG);
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
