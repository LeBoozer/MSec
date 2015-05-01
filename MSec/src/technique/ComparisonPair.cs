/*******************************************************************************************************************************************************************
	File	:	ComparisonPair.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************************************************************************************************************************
	Struct: Comparator
*******************************************************************************************************************************************************************/
namespace MSec
{
    public class ComparisonPair
    {
        // The pair's ID (combined hashes of both sources!)
        private int m_pairID = 0;
        public int PairID
        {
            get { return m_pairID; }
            private set { }
        }

        // The pair's tag (can be used differently and can also be null!)
        private object m_tag = null;
        public object Tag
        {
            get { return m_tag; }
            set { m_tag = value; }
        }

        // The data lock
        private object m_dataLock = new object();

        // The first source
        private ImageSource m_source0 = null;
        public ImageSource Source0
        {
            get { return m_source0; }
            private set { m_source0 = value; }
        }

        // The second source
        private ImageSource m_source1 = null;
        public ImageSource Source1
        {
            get { return m_source1; }
            private set { m_source1 = value; }
        }

        // The technique
        private Technique m_technique = null;
        public Technique ComparatorTechnique
        {
            get { return m_technique; }
            private set { }
        }

        // The comparative result data
        private ComparativeData m_compData = null;
        public ComparativeData ComparativeResult
        {
            get { return m_compData; }
            set 
            {
                if (value == null)
                    return;
                lock(m_dataLock)
                {
                    m_compData = value;
                }
            }
        }

        #region Wrapper for the object-list-view and DLinq
        // Wrapper for the match rate
        public int MatchRate
        {
            get { return (int)(m_compData.getMatchRate().Value * 100); }
            private set { }
        }

        // Wrapper for the match rate
        public bool IsAccepted
        {
            get { return m_compData.isAccepted(); }
            private set { }
        }
        #endregion Wrapper for DLinq

        // Constructor
        public ComparisonPair(ImageSource _source0, ImageSource _source1, Technique _technique)
        {
            // Copy parameters
            m_source0 = _source0;
            m_source1 = _source1;
            m_technique = _technique;

            // Compute comparator's ID
            m_pairID = 17;
            m_pairID = m_pairID * 31 + m_source0.FilePath.GetHashCode();
            m_pairID = m_pairID * 31 + m_source1.FilePath.GetHashCode();
        }
    }
}
