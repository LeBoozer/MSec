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

        private ViewCrossComparison m_viewCrossComparison = null;
        public ViewCrossComparison ViewCrossComparison
        {
            get { return m_viewCrossComparison; }
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
            m_viewCrossComparison = new ViewCrossComparison(tabCtrl.TabPages["pageCrossComparison"]);

            return true;
        }

        // Drops MSec
        public bool drop()
        {
            return true;
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

        // Opens a link with the standard browser
        public void onOpenLinkInBrowser(string _url)
        {
            // Open URL
            System.Diagnostics.Process.Start(_url);
        }

        // Shows the about dialogue
        public void onShowAboutDialog()
        {
            // Show about box
            new AboutBox().ShowDialog();
        }
    }
}
