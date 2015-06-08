/*******************************************************************************************************************************************************************
	File	:	HashData.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************************************************************************************************************************
	Class: HashDataTimings
*******************************************************************************************************************************************************************/
namespace MSec
{
    public sealed class HashDataTimings
    {
        // The image loading time in (ms)
        private double m_imageLoadingTimeMS = 0;
        public double ImageLoadingTimeMS
        {
            get { return m_imageLoadingTimeMS; }
            set { m_imageLoadingTimeMS = value; }
        }

        // The hash computation time in (ms)
        private double m_hashComputationTimeMS = 0;
        public double HashComputationTimeMS
        {
            get { return m_hashComputationTimeMS; }
            set { m_hashComputationTimeMS = value; }
        }

        // Constructor
        public HashDataTimings(double _loadingTimeMS, double _computationTimeMS)
        {
            m_imageLoadingTimeMS = _loadingTimeMS;
            m_hashComputationTimeMS = _computationTimeMS;
        }

        // Returns the formatted loading time
        public string getFormattedLoadingTime()
        {
            return m_imageLoadingTimeMS.ToString("#0.000");
        }

        // Returns the formatted computation time
        public string getFormattedComputationTime()
        {
            return m_hashComputationTimeMS.ToString("#0.000");
        }

        // Returns the formatted total time
        public string getFormattedTotalTime()
        {
            return (m_imageLoadingTimeMS + m_hashComputationTimeMS).ToString("#0.000");
        }
    }
}

/*******************************************************************************************************************************************************************
	Interface: HashData
*******************************************************************************************************************************************************************/
namespace MSec
{
    public interface HashData
    {
        // Returns the calculated timings for the hash computation (if provided by the algorithm!)
        HashDataTimings getTimings();

        // Returns the type of the hash data
        Type getDataType();

        // Converts the hash into a readable format
        string convertToString();
    }
}

/*******************************************************************************************************************************************************************
	Class: HashData<_T>
*******************************************************************************************************************************************************************/
namespace MSec
{
    public sealed class HashData<_T> : HashData
        where _T : new()
    {
        // Delegate for the hashing function
        public delegate string delegate_convertToString(_T _data);

        // The hash data type
        private Type m_dataType = typeof(_T);

        // The hash data
        private _T m_data = default(_T);
        public _T Data
        {
            get { return m_data; }
            set { m_data = value; }
        }

        // The computation timings
        private HashDataTimings m_computationTimings = null;

        // The convert to string function
        private delegate_convertToString m_funcConv = null;
        public delegate_convertToString FuncConvertToString
        {
            private get { return m_funcConv; }
            set { m_funcConv = value; }
        }

        // Constructor
        public HashData(_T _data, delegate_convertToString _funcConv = null, HashDataTimings _timings = null)
        {
            // Copy
            m_data = _data;
            m_funcConv = _funcConv;
            m_computationTimings = _timings;
        }

        // Override: HashData::getTimings
        public HashDataTimings getTimings()
        {
            return m_computationTimings;
        }

        // Override: HashData::getDataType
        public Type getDataType()
        {
            return m_dataType;
        }

        // Override: HashData::convertToString
        public string convertToString()
        {
            if (m_funcConv != null)
                return m_funcConv(m_data);
            return m_data.ToString();
        }
    }
}
