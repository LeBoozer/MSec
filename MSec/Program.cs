using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSec
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Local variables
            MainDialog d = null;

            // Set settings
            Application.SetCompatibleTextRenderingDefault(false);

           
            // Create main dialog and initialize MSec
            d = new MainDialog();
            MSec.Instance.initialize(d);

            // Enable visual styles and run application
            Application.EnableVisualStyles();
            Application.Run(d);

            // Drop MSec
            MSec.Instance.drop();
        }
    }
}
