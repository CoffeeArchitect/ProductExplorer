using System;
using System.Windows.Forms;

namespace ProductExplorer.Views
{
    public interface IProductListView
    {
        event EventHandler ImportExcelClicked;
        event EventHandler EditProductClicked;
        event EventHandler DeleteProductClicked;
        event EventHandler ExitClicked;

        //DataGridView DataGridView { get; }


        void SetProductListBindingSource(BindingSource bindingSource);

        void ShowView();
        void CloseView();
    }
}
