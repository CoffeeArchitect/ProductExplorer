using ProductExplorer.Presenters;
using ProductExplorer.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProductExplorer
{
    public partial class ProductListView : Form, IProductListView
    {
        private readonly ProductListPresenter presenter;

        public ProductListView()
        {
            InitializeComponent();
            presenter = new ProductListPresenter(this);
        }

        public event EventHandler ImportExcelClicked
        {
            add { btnImportExcel.Click += value; }
            remove { btnImportExcel.Click -= value; }
        }

        public event EventHandler EditProductClicked
        {
            add { btnEdit.Click += value; }
            remove { btnEdit.Click -= value; }
        }

        public event EventHandler DeleteProductClicked
        {
            add { btnDelete.Click += value; }
            remove { btnDelete.Click -= value; }
        }

        public event EventHandler ExitClicked
        {
            add { btnExit.Click += value; }
            remove { btnExit.Click -= value; }
        }

        public DataGridView DataGridView => productGridView;

        public void ShowView()
        {
            Show();
        }

        public void CloseView()
        {
            Close();
        }
    }
}
