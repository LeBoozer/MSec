/*******************************************************************************************************************************************************************
	File	:	ViewCrossComparison.cs
	Project	:	MSec
	Author	:	Byron Worms
    Links   :   http://www.codeproject.com/Articles/17502/Simple-Popup-Control
*******************************************************************************************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Luminous.Windows.Forms;

/*******************************************************************************************************************************************************************
	Class: ViewImageVsImage
*******************************************************************************************************************************************************************/
namespace MSec
{
    public class ViewCrossComparison : ViewWithTechniqueSelection
    {
        // Comparison details stuff
        private Popup       m_popupWindow = null;
        private Rectangle   m_popupPosition;

        // Controls
        private ListView m_listResults = null;

        // Constructor
        public ViewCrossComparison(TabPage _tabPage) :
            base(_tabPage, "CC_Selection_Technique")
        {
            // Local variables
            CC_ComparisonDetails ccDetails = new CC_ComparisonDetails();
            int x = 0;
            int y = 0;

            // Create pop-up window
            m_popupWindow = new Popup(ccDetails);
            m_popupWindow.HidingAnimation = PopupAnimations.None;
            m_popupWindow.ShowingAnimation = PopupAnimations.None;
            m_popupWindow.FocusOnOpen = false;

            // Extract controls
            m_listResults = _tabPage.Controls.Find("CC_List_Results", true)[0] as ListView;

            // Add events to: list of results
            m_listResults.ItemSelectionChanged += onItemSelectionChanged;

            // Define pop-up position
            x = m_listResults.Width;
            y = (m_listResults.Height / 2) - (ccDetails.Height / 2);
            m_popupPosition = new Rectangle(x, y, 1, 1);
        }

        #region Events: Controls
        // Event List::onItemSelectionChanged
        void onItemSelectionChanged(object _sender, ListViewItemSelectionChangedEventArgs _e)
        {
            // Show pip-up window
            m_popupWindow.Show(m_listResults, m_popupPosition);
        }
        #endregion Events: Controls
    }
}
