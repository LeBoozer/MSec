/*******************************************************************************************************************************************************************
	File	:	Utility.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

/*******************************************************************************************************************************************************************
	Class: Utility
*******************************************************************************************************************************************************************/
namespace MSec
{
    public static class Utility
    {
        public delegate void delegate_runInControlThread(params object[] _params);

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

        // Opens the dialog to pick an image file
        // Returns the path of the file or an empty string in cases the user pressed abort
        public static string openSelectImageDialog()
        {
            // Local variables
            OpenFileDialog dialog = new OpenFileDialog();

            // Set filter
            dialog.Filter = "Image files (*bmp, *.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *bmp; *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.FilterIndex = 0;

            // Disable multiselections
            dialog.Multiselect = false;

            // Show dialog
            if (dialog.ShowDialog() == DialogResult.OK)
                return dialog.FileName;

            return "";
        }

        // Opens the dialog to pick an folder
        // Returns the path of the folder or an empty string in cases the user pressed abort
        public static string openSelectFolderDialog()
        {
            // Local variables
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            // Set options
            dialog.RootFolder = Environment.SpecialFolder.Desktop;

            // Show dialog
            if (dialog.ShowDialog() == DialogResult.OK)
                return dialog.SelectedPath;

            return "";
        }

        // Executes the defined action in the control's main thread
        public static void invokeInGuiThread(Control _ctrl, Action _action)
        {
            // Invoke required?
            if (_ctrl.InvokeRequired == true)
                _ctrl.Invoke(_action);
            else
                _action();
        }

        // Executes the defined action in the form's main thread
        public static void invokeInGuiThread(Form _form, Action _action)
        {
            // Invoke required?
            if (_form.InvokeRequired == true)
                _form.Invoke(_action);
            else
                _action();
        }
    }
}
