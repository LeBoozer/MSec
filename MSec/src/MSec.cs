/*******************************************************************************************************************************************************************
	File	:	MSec.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;

/*******************************************************************************************************************************************************************
	Class: MSec
*******************************************************************************************************************************************************************/
namespace MSec
{
    public sealed class MSec
    {
        // Singleton stuff
        private static MSec m_singleton = null;
        public static MSec Instance
        {
            get
            {
                if (m_singleton == null)
                    m_singleton = new MSec();
                return m_singleton;
            }

            private set { }
        }

        // The main menu window
        private MainDialog m_mainDialog = null;
        public MainDialog MainWindow
        {
            get { return m_mainDialog; }
            private set { }
        }

        // The view instances
        private ViewImageVsImage m_viewImageVsImage = null;
        public ViewImageVsImage ViewImageVsImage
        {
            get { return m_viewImageVsImage; }
            private set { }
        }

        // Initializes MSec
        public bool initialize(MainDialog _handle)
        {
            // Local parameters
            TabControl tabCtrl = null;

            // Copy parameters
            m_mainDialog = _handle;

            // Get tab control handle
            tabCtrl = m_mainDialog.Controls.Find("MainDialog_MainTab", true)[0] as TabControl;

            // Create views
            m_viewImageVsImage = new ViewImageVsImage(tabCtrl.TabPages["pageImageVsImage"]);

            return true;
        }

        // Drops MSec
        public bool drop()
        {
            return true;
        }

        // Sets a new technique
        public void changeTechnique(TechniqueID _type)
        {
        }

        // Starts a new job (process dialog is modal!)
        public void startJob(Action _job, string _jobDesc)
        {
            // Local variables
            ProcessDialog d = null;

            // Check parameter
            if (_job == null)
                return;

            // Create dialog
            d = new ProcessDialog(_jobDesc, _job);
            d.ShowDialog();
        }

        // Opens the file selection dialog for pictures
        public string dialogSelectPictureFile()
        {
            // Local variables
            OpenFileDialog dialog = new OpenFileDialog();

            // Set filter
            dialog.Filter = "Image files (*bmp, *.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *bmp; *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.FilterIndex = 0;

            // Disable multiselections
            dialog.Multiselect = true;

            // Show dialog
            if (dialog.ShowDialog() == DialogResult.OK)
                return dialog.FileName;

            return null;
        }
    }
}
