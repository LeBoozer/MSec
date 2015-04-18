/*******************************************************************************************************************************************************************
	File	:	Utility.cs
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
	Class: Utility
*******************************************************************************************************************************************************************/
namespace MSec
{
    public static class Utility
    {
        // Converts an integer pointer to a readable string (hex format)
        public static string toHexString(IntPtr _data, int _size)
        {
            // Local variables
            byte[] buffer = new byte[_size];
            StringBuilder sb = new StringBuilder();

            // Check
            if (_data == null)
                return "";

            // Copy data
            Marshal.Copy(_data, buffer, 0, _size);
            
            // Convert to string
            foreach (var b in buffer)
                sb.AppendFormat("{0:x2}", b);
            return sb.ToString();
        }

        // Converts a simple C# structure (no nested structures or intptr!) to an unmanaged representation
        public static IntPtr convertSimpleStructureToUnmanagedPtr<_T>(_T _struct)
        {
            // Local variables
            IntPtr result = IntPtr.Zero;
            int sizeStruct = 0;

            // Convert
            sizeStruct = Marshal.SizeOf(typeof(_T));
            result = Marshal.AllocHGlobal(sizeStruct);
            Marshal.StructureToPtr(_struct, result, false);

            return result;
        }

        // Converts an unmanaged representation of a simple! C# structure back to a managed representation
        public static void convertUnmanagedPtrToSimpleStructure<_T>(IntPtr _src, ref _T _dst)
        {
            // Convert
            Marshal.PtrToStructure(_src, _dst);

            // Free unmanaged memory
            clearUnmanagedPtr<_T>(_src);
        }

        // Free the memory owned by an unmanaged pointer
        public static void clearUnmanagedPtr<_T>(IntPtr _src)
        {
            // Free unmanaged memory
            Marshal.DestroyStructure(_src, typeof(_T));
            Marshal.FreeHGlobal(_src);
            _src = IntPtr.Zero;
        }
    }
}
