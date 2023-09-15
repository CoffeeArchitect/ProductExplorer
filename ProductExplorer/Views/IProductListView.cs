using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProductExplorer.Views
{
    public interface IProductListView
    {
        event EventHandler ImportExcelClicked;
        event EventHandler EditProductClicked;
        event EventHandler DeleteProductClicked;
        event EventHandler ExitClicked;

        DataGridView DataGridView { get; }

        void ShowView();
        void CloseView();
    }
}
