/*******************************************************************************************************************************************************************
	File	:	UnfoldedBindingComparisonPair.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************************************************************************************************************************
	Class: UnfoldedBindingComparisonPair
*******************************************************************************************************************************************************************/
namespace MSec
{
    public sealed class UnfoldedBindingComparisonPair
    {
        // The pair's tag (can be used differently and can also be null!)
        private object m_tag = null;
        public object Tag
        {
            get { return m_tag; }
            set { m_tag = value; }
        }

        // The threshold (range: 0-100)
        private int m_threshold = 0;
        public int Threshold
        {
            get { return m_threshold; }
            private set { }
        }

        // The first binding
        private ImageSourceBinding m_binding0 = null;
        public ImageSourceBinding Binding0
        {
            get { return m_binding0; }
            private set { }
        }

        // The second binding
        private ImageSourceBinding m_binding1 = null;
        public ImageSourceBinding Binding1
        {
            get { return m_binding1; }
            private set { }
        }

        // The first image source
        private ImageSource m_sourceBinding0 = null;
        public ImageSource Source0
        {
            get { return m_sourceBinding0; }
            private set { }
        }

        // The second image source
        private ImageSource m_sourceBinding1 = null;
        public ImageSource Source1
        {
            get { return m_sourceBinding1; }
            private set { }
        }

        // Comparison data for: RADISH
        private ComparativeData m_compDataRADISH = null;
        public ComparativeData DataRADISH
        {
            get { return m_compDataRADISH; }
            private set { }
        }

        // Comparison data for: DCT
        private ComparativeData m_compDataDCT = null;
        public ComparativeData DataDCT
        {
            get { return m_compDataDCT; }
            private set { }
        }

        // Comparison data for: Wavelet
        private ComparativeData m_compDataWavelet = null;
        public ComparativeData DataWavelet
        {
            get { return m_compDataWavelet; }
            private set { }
        }

        // Comparison data for: BMB
        private ComparativeData m_compDataBMB = null;
        public ComparativeData DataBMB
        {
            get { return m_compDataBMB; }
            private set { }
        }

        #region Definitions for DLinQ und object-list-view

        // Image source 0: RADISH
        public ImageSource Source0RADISH
        {
            get { return m_binding0.getComparisonDataFor(TechniqueID.RADISH); }
            private set { }
        }

        // Image source 0: DCT
        public ImageSource Source0DCT
        {
            get { return m_binding0.getComparisonDataFor(TechniqueID.DCT); }
            private set { }
        }

        // Image source 0: Wavelet
        public ImageSource Source0Wavelet
        {
            get { return m_binding0.getComparisonDataFor(TechniqueID.WAVELET); }
            private set { }
        }

        // Image source 0: BMB
        public ImageSource Source0BMB
        {
            get { return m_binding0.getComparisonDataFor(TechniqueID.BMB); }
            private set { }
        }

        // Image source 1: RADISH
        public ImageSource Source1RADISH
        {
            get { return m_binding1.getComparisonDataFor(TechniqueID.RADISH); }
            private set { }
        }

        // Image source 1: DCT
        public ImageSource Source1DCT
        {
            get { return m_binding1.getComparisonDataFor(TechniqueID.DCT); }
            private set { }
        }

        // Image source 1: Wavelet
        public ImageSource Source1Wavelet
        {
            get { return m_binding1.getComparisonDataFor(TechniqueID.WAVELET); }
            private set { }
        }

        // Image source 1: BMB
        public ImageSource Source1BMB
        {
            get { return m_binding1.getComparisonDataFor(TechniqueID.BMB); }
            private set { }
        }

        // Average match rate
        public int MatchRateAVG
        {
            get
            {
                // Local variables
                int avg = 0;
                int counter = 0;

                if(MatchRateRADISH > -1)
                {
                    avg += MatchRateRADISH;
                    ++counter;
                }
                if (MatchRateDCT > -1)
                {
                    avg += MatchRateDCT;
                    ++counter;
                }
                if (MatchRateWavelet > -1)
                {
                    avg += MatchRateWavelet;
                    ++counter;
                }
                if (MatchRateBMB > -1)
                {
                    avg += MatchRateBMB;
                    ++counter;
                }
                return avg / counter;
            }
        }

        // Match rate: RADISH
        public int MatchRateRADISH
        {
            get { if (m_compDataRADISH == null) return -1; else return (int)(m_compDataRADISH.getMatchRate().Value * 100); }
        }

        // Match rate: DCT
        public int MatchRateDCT
        {
            get { if (m_compDataDCT == null) return -1; else return (int)(m_compDataDCT.getMatchRate().Value * 100); }
        }

        // Match rate: Wavelet
        public int MatchRateWavelet
        {
            get { if (m_compDataWavelet == null) return -1; else return (int)(m_compDataWavelet.getMatchRate().Value * 100); }
        }

        // Match rate: BMB
        public int MatchRateBMB
        {
            get { if (m_compDataBMB == null) return -1; else return (int)(m_compDataBMB.getMatchRate().Value * 100); }
        }

        #endregion Definitions for DLinQ und object-list-view

        // Constructor
        public UnfoldedBindingComparisonPair(int _threshold, ImageSourceBinding _binding0, ImageSourceBinding _binding1, 
            ImageSource _src0, ImageSource _src1, ComparativeData _radish,
            ComparativeData _dct, ComparativeData _wavelet, ComparativeData _bmb)
        {
            // Copy
            m_threshold = _threshold;
            m_binding0 = _binding0;
            m_binding1 = _binding1;
            m_sourceBinding0 = _src0;
            m_sourceBinding1 = _src1;
            m_compDataRADISH = _radish;
            m_compDataDCT = _dct;
            m_compDataWavelet = _wavelet;
            m_compDataBMB = _bmb;
        }

        public UnfoldedBindingComparisonPair cloneWithNewTag(object _tag)
        {
            var item = new UnfoldedBindingComparisonPair(Threshold, Binding0, Binding1, Source0, Source1, DataRADISH, DataDCT, DataWavelet, DataBMB);
            item.Tag = _tag;
            return item;
        }
    }
}
