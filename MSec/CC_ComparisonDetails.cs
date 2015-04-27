/*******************************************************************************************************************************************************************
	File	:	CC_ComparisonDetails.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*******************************************************************************************************************************************************************
	Class: CC_ComparisonDetails
*******************************************************************************************************************************************************************/
namespace MSec
{
    public partial class CC_ComparisonDetails : UserControl
    {
        // The current set comparison pair
        private ComparisonPair m_pair = null;
        public ComparisonPair CurrentPair
        {
            get { return m_pair; }
            private set { }
        }

        // Controls
        private PictureBox m_pictureSource0 = null;
        private PictureBox m_pictureSource1 = null;
        private TextBox    m_textSource0 = null;
        private TextBox    m_textSource1 = null;

        // Constructor
        public CC_ComparisonDetails()
        {
            // Initialize the user control's component
            InitializeComponent();

            // Get controls
            m_pictureSource0 = this.CC_Picture_Source0;
            m_pictureSource1 = this.CC_Picture_Source_1;
            m_textSource0    = this.CC_Text_Source0;
            m_textSource1    = this.CC_Text_Source1;
        }

        // Updates the control's content with a comparison pair (null to delete content)
        public void setComparisonPair(ComparisonPair _pair)
        {
            // Run in GUI thread
            Utility.invokeInGuiThread(this, delegate
            {
                // Reset GUI content
                m_pictureSource0.Image = m_pictureSource1.Image = null;
                m_textSource0.Text = m_textSource1.Text = "";

                m_pair = null;
            });

            // Check parameter
            if (_pair == null)
                return;

            // Copy parameter
            m_pair = _pair;

            // Run in GUI thread
            Utility.invokeInGuiThread(this, delegate
            {
                // Set content: source 0
                if (m_pair.Source0 != null)
                {
                    // Set preview
                    m_pictureSource0.Image = m_pair.Source0.createSystemImage();

                    // Set patch
                    m_textSource0.Text = m_pair.Source0.FilePath;
                }
                if (m_pair.Source1 != null)
                {
                    // Set preview
                    m_pictureSource1.Image = m_pair.Source1.createSystemImage();

                    // Set patch
                    m_textSource1.Text = m_pair.Source1.FilePath;
                }
            });
        }

        // Override: UserControl::OnPaint
        protected override void OnPaint(PaintEventArgs _e)
        {
            // Call parental function
            base.OnPaint(_e);

            // Draw custom border
            ControlPaint.DrawBorder(_e.Graphics, ClientRectangle,
                                         Color.DimGray, 1, ButtonBorderStyle.Inset,
                                         Color.DimGray, 2, ButtonBorderStyle.Inset,
                                         Color.DimGray, 2, ButtonBorderStyle.Inset,
                                         Color.DimGray, 2, ButtonBorderStyle.Inset);
        }
    }
}
