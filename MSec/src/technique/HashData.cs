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
	Interface: HashData
*******************************************************************************************************************************************************************/
namespace MSec
{
    public interface HashData
    {
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
        Type m_dataType = typeof(_T);

        // The hash data
        private _T m_data = default(_T);
        public _T Data
        {
            get { return m_data; }
            set { m_data = value; }
        }

        // The convert to string function
        private delegate_convertToString m_funcConv = null;
        public delegate_convertToString FuncConvertToString
        {
            private get { return m_funcConv; }
            set { m_funcConv = value; }
        }

        // Constructor
        public HashData(_T _data, delegate_convertToString _funcConv = null)
        {
            // Copy
            m_data = _data;
            m_funcConv = _funcConv;
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
