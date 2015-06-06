using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSec
{
    public partial class StepByStepLargerImage : UserControl
    {
        public StepByStepLargerImage()
        {
            InitializeComponent();
        }

        public void setBackgroundImage(Image _image)
        {
            SS_Picture_LargeView.BackgroundImage = _image;
        }
    }
}
