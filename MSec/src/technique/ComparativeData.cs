/*******************************************************************************************************************************************************************
	File	:	ComparativeData.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************************************************************************************************************************
	Interface: ComparativeData
*******************************************************************************************************************************************************************/
namespace MSec
{
    public interface ComparativeData
    {
        // Returns the type of the hash data
        Type getDataType();

        // Converts the hash into a readable format
        string convertToString();
    }
}

/*******************************************************************************************************************************************************************
	Class: ComparativeData<_T>
*******************************************************************************************************************************************************************/
namespace MSec
{
    public class ComparativeData<_T> : ComparativeData
        where _T : new()
    {
        // Delegate for the hashing function
        public delegate string delegate_convertToString(_T _data);

        // The hash data
        private _T m_data = default(_T);
        public _T Data
        {
            get { return m_data; }
            private set { }
        }

        // The convert to string function
        private delegate_convertToString m_funcConv = null;
        public delegate_convertToString FuncConvertToString
        {
            private get { return m_funcConv; }
            set { m_funcConv = value; }
        }

        // Constructor
        public ComparativeData(_T _data, delegate_convertToString _funcConv = null)
        {
            // Copy
            m_data = _data;
            m_funcConv = _funcConv;
        }

        // Override: ComparativeData::getDataType
        public Type getDataType()
        {
            return typeof(_T);
        }

        // Override: ComparativeData::convertToString
        public string convertToString()
        {
            if (m_funcConv != null)
                return m_funcConv(m_data);
            return m_data.ToString();
        }
    }
}
