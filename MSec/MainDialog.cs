using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSec
{
    public partial class MainDialog : Form
    {
        public MainDialog()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Forward event to main class
            MSec.Instance.onShowAboutDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Forward event to main class
            MSec.Instance.onOpenLinkInBrowser("http://www.freepik.com/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Forward event to main class
            MSec.Instance.onOpenLinkInBrowser("http://www.flaticon.com");
        }
    }
}
