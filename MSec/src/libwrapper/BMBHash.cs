/*******************************************************************************************************************************************************************
	File	:	BMBHash.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

/*******************************************************************************************************************************************************************
	Class: BMBHash
*******************************************************************************************************************************************************************/
namespace MSec
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public class BMBHash
    {
        public IntPtr   m_data;
        public int      m_dataLength = 0;
        public int      m_byteIndex = 0;
        public byte     m_bitmask = 0;

        ~BMBHash()
        {
            // Free memory
            if (m_data != IntPtr.Zero)
            {
              //  Marshal.FreeCoTaskMem(m_coeffs);
                m_data = IntPtr.Zero;
            }
        }
    }
}