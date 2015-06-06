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
using System.Xml.Linq;

/*******************************************************************************************************************************************************************
	Class: MSec
*******************************************************************************************************************************************************************/
namespace MSec
{
    public sealed class MSec
    {
        // Constants
        private static readonly string APP_CONFIG_FILE = "config.cfg";

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

        // Configuration stuff
        private XDocument m_xmlDocument = null;

        // Initializes MSec
        public bool initialize(MainDialog _handle)
        {
            // Local parameters
            TabControl tabCtrl = null;

            // Copy parameters
            m_mainDialog = _handle;

            // Try to load app configuration
            try
            {
                m_xmlDocument = XDocument.Load(APP_CONFIG_FILE);
            }
            catch(Exception _ex)
            {
                m_xmlDocument = null;
                MessageBox.Show(_ex.Message, "Error while parsin application configuration!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
            // Clean folder "TempData"
            DumpTechniqueStepsToDisk.cleanTargetFolder();

            return true;
        }

        // Returns a list with all elements which can be found under the specified type (can be null!)
        public IEnumerable<XElement> getXmlElementsByType(string _type)
        {
            if (m_xmlDocument == null)
                return null;
            return m_xmlDocument.Root.Descendants(_type);
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
