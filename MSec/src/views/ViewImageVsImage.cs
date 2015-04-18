/*******************************************************************************************************************************************************************
	File	:	ViewImageVsImage.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*******************************************************************************************************************************************************************
	Class: ViewImageVsImage
*******************************************************************************************************************************************************************/
namespace MSec
{
    public sealed class ViewImageVsImage : ViewWithTechniqueSelection
    {
        private Button m_buttonLock = null;
        private Button m_buttonUnlock = null;

        // Constructor
        public ViewImageVsImage(TabPage _tabPage) :
            base(_tabPage, "Selection_Technique")
        {
            // Get buttons
            m_buttonLock = _tabPage.Controls.Find("button1", true)[0] as Button;
            m_buttonUnlock = _tabPage.Controls.Find("button2", true)[0] as Button;

            m_buttonLock.Click += m_buttonLock_Click;
            m_buttonUnlock.Click += m_buttonUnlock_Click;
        }

        void m_buttonUnlock_Click(object sender, EventArgs e)
        {
            unlockTechniqueSelection();
        }

        void m_buttonLock_Click(object sender, EventArgs e)
        {
            lockTechniqueSelection();
        }
    }
}
