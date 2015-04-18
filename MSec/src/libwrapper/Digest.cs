/*******************************************************************************************************************************************************************
	File	:	Digest.cs
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
	Struct: Digest
*******************************************************************************************************************************************************************/
namespace MSec
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public sealed class Digest
    {
        [MarshalAs(UnmanagedType.LPStr)]
        public string m_hashID = "";
        public IntPtr m_coeffs = IntPtr.Zero;
        public int    m_size   = 0;

        ~Digest()
        {
            // Free memory
            if (m_coeffs != IntPtr.Zero)
            {
              //  Marshal.FreeCoTaskMem(m_coeffs);
                m_coeffs = IntPtr.Zero;
            }
        }
    }
}
