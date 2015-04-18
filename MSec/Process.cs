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
    public partial class ProcessDialog : Form
    {
        // Constructor
        public ProcessDialog(string _jobDesc, Action _job)
        {
            // Initialize components
            InitializeComponent();

            // Start job
            Task t = new Task(_job);
            Task.Factory.ContinueWhenAll(new Task[] { t }, (Task[] _a) => { this.Close(); });
            t.Start();
        }
    }
}
