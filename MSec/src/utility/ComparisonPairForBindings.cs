/*******************************************************************************************************************************************************************
	File	:	ComparisonPairForBindings.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************************************************************************************************************************
    Struct: ComparisonPairForBindings
*******************************************************************************************************************************************************************/
namespace MSec
{
    public class ComparisonPairForBindings
    {
        // The pair's ID (combined hashes of both sources!)
        private int m_pairID = 0;
        public int PairID
        {
            get { return m_pairID; }
            private set { }
        }

        // The first source binding
        private ImageSourceBinding m_binding0 = null;
        public ImageSourceBinding Binding0
        {
            get { return m_binding0; }
            private set { }
        }

        // The second source
        private ImageSourceBinding m_binding1 = null;
        public ImageSourceBinding Binding1
        {
            get { return m_binding1; }
            private set {  }
        }

        // The comparison data for the techniques
        private Dictionary<TechniqueID, ComparativeData> m_comparisonData = new Dictionary<TechniqueID, ComparativeData>();

        // Constructor
        public ComparisonPairForBindings(ImageSourceBinding _binding0, ImageSourceBinding _binding1)
        {
            // Copy parameters
            m_binding0 = _binding0;
            m_binding1 = _binding1;

            // Compute comparator's ID
            m_pairID = 17;
            m_pairID = m_pairID * 31 + m_binding0.SourceReference.FilePath.GetHashCode();
            m_pairID = m_pairID * 31 + m_binding1.SourceReference.FilePath.GetHashCode();
        }

        // Adds the comparison data for a certain technique
        public void setComparisonDataFor(TechniqueID _id, ComparativeData _data)
        {
            m_comparisonData.Add(_id, _data);
        }

        // Returns the comparison data for a certain technique (can be null!)
        public ComparativeData getComparisonDataFor(TechniqueID _id)
        {
            if(m_comparisonData.ContainsKey(_id) == false)
                return null;
            return m_comparisonData[_id];
        }
    }
}
