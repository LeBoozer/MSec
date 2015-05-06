﻿/*******************************************************************************************************************************************************************
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
        public UnfoldedBindingComparisonPair(int _threshold, ImageSource _src0, ImageSource _src1, ComparativeData _radish,
            ComparativeData _dct, ComparativeData _wavelet, ComparativeData _bmb)
        {
            // Copy
            m_threshold = _threshold;
            m_sourceBinding0 = _src0;
            m_sourceBinding1 = _src1;
            m_compDataRADISH = _radish;
            m_compDataDCT = _dct;
            m_compDataWavelet = _wavelet;
            m_compDataBMB = _bmb;
        }
    }
}
