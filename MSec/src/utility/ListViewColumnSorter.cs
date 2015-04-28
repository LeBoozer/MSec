/*******************************************************************************************************************************************************************
	File	:	ListViewColumnSorter.cs
	Project	:	MSec
	Author	:	Byron Worms
*******************************************************************************************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*******************************************************************************************************************************************************************
	Class: ListViewColumnSorter
*******************************************************************************************************************************************************************/
namespace MSec
{
    public sealed class ListViewColumnSorter : IComparer
    {
        // Delegate functions
        public delegate int delegate_compare_item(ListViewItem _x, ListViewItem _y);
        public delegate int delegate_compare(ListViewItem.ListViewSubItem _x, ListViewItem.ListViewSubItem _y);

        // The sort-order
        private SortOrder m_sortOrder = SortOrder.None;
        public SortOrder SortOrder
        {
            get { return m_sortOrder; }
            set { m_sortOrder = value; }
        }

        // The column index
        private int m_columnIndex = 0;
        public int ColumnIndex
        {
            get { return m_columnIndex; }
            set { m_columnIndex = value; }
        }

        // List with the function for the comparison
        private delegate_compare_item m_compareItemFunc = null;
        private List<delegate_compare> m_compareFuncList = new List<delegate_compare>();

        // Constructor
        public ListViewColumnSorter(delegate_compare_item _compareItem = null, params delegate_compare[] _funcs)
        {
            // Add all functions
            m_compareItemFunc = _compareItem;
            m_compareFuncList.AddRange(_funcs);
        }

        // Override: IComparer::Compare
        public int Compare(object _x, object _y)
        {
            // Local variables
            int result = 0;
            ListViewItem itemX = _x as ListViewItem;
            ListViewItem itemY = _y as ListViewItem;

            // Check index and sort order
            if (m_columnIndex >= m_compareFuncList.Count + 1 || m_sortOrder == System.Windows.Forms.SortOrder.None)
                return 0;

            // Compare
            if (m_columnIndex == 0)
                result = m_compareItemFunc(itemX, itemY);
            else
                result = m_compareFuncList[m_columnIndex - 1](itemX.SubItems[m_columnIndex], itemY.SubItems[m_columnIndex]);

            // Invert result?
            if (m_sortOrder == System.Windows.Forms.SortOrder.Descending)
                result = -result;

            return result;
        }
    }
}
