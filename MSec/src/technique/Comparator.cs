/*******************************************************************************************************************************************************************
	File	:	Comparator.cs
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
    public class Comparator
    {
        // The comparator's ID (combined hashes of both sources!)
        private int m_comparatorID = 0;
        public int ComparatorID
        {
            get { return m_comparatorID; }
            private set { }
        }

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
            private set { }
        }

        // Constructor
        public Comparator(ImageSource _source0, ImageSource _source1, Technique _technique)
        {
            // Copy parameters
            m_source0 = _source0;
            m_source1 = _source1;
            m_technique = _technique;

            // Compute comparator's ID
            m_comparatorID = 17;
            m_comparatorID = m_comparatorID * 31 + m_source0.FilePath.GetHashCode();
            m_comparatorID = m_comparatorID * 31 + m_source1.FilePath.GetHashCode();
            m_comparatorID = m_comparatorID * 31 + _technique.ID.GetHashCode();
        }

        // Compares both defined sources (can be null!)
        public ComparativeData compareSources(bool _recompute = false)
        {
            // Check parameter
            if (m_source0 == null || m_source1 == null || m_technique == null)
                return null;

            // Hashes available?
            if (m_technique.containsHashDataDefaultValue(m_source0.getHashDataForTechnique(m_technique.ID)) == true ||
                m_technique.containsHashDataDefaultValue(m_source1.getHashDataForTechnique(m_technique.ID)) == true)
                return null;

            // Recompute?
            if (m_compData != null && _recompute == false)
            {
                // Default value?
                if (m_technique.containsComparativeDataDefaultValue(m_compData) == false)
                    return m_compData;
            }

            // Compare hashes
            m_compData = m_technique.compareHashData(m_source0.getHashDataForTechnique(m_technique.ID), m_source1.getHashDataForTechnique(m_technique.ID));

            return m_compData;
        }
    }
}
