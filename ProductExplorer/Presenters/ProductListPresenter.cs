using NPOI.SS.Formula.Functions;
using ProductExplorer.DAL.Repositories;
using ProductExplorer.Forms;
using ProductExplorer.Models;
using ProductExplorer.Services;
using ProductExplorer.Views;
using System.Collections.Generic;
using System.Transactions;
using System.Windows.Forms;

namespace ProductExplorer.Presenters
{
    public class ProductListPresenter
    {
        private readonly IProductListView _view;
        private BindingSource _bindingSource;
        private IProductRepository _repository;
        private IEnumerable<Product> products;
        public Product Product { get; set; }

        public ProductListPresenter(IProductListView view, IProductRepository repository)
        {
            _bindingSource = new BindingSource();
            _view = view;
            _repository = repository;
            WireUpEvents();
            _view.SetProductListBindingSource(_bindingSource);
            LoadProducts();
            _view.ShowView();
        }

        private void WireUpEvents()
        {
            _view.ImportExcelClicked += (sender, args) => ImportExcel();
            _view.EditProductClicked += (sender, args) => EditProduct();
            _view.DeleteProductClicked += (sender, args) => DeleteProduct();
            _view.ExitClicked += (sender, args) => _view.CloseView();
        }

        private void LoadProducts()
        {
            var products = _repository.GetAll();
            _bindingSource.DataSource = products;
        }

        private void ImportExcel()
        {
            ExcelImporter excelImporter = new ExcelImporter();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы Excel|*.xlsx";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                List<Product> importedProducts = excelImporter.ImportFromExcel(filePath);
                foreach (var product in importedProducts)
                {
                    _repository.Add(product);
                }
                LoadProducts();
            }
        }

        private void EditProduct()
        {
            Product = (Product)_bindingSource.Current;
            if (Product != null)
            {
                ProductView productEditView = new ProductView();
                ProductPresenter productPresenter = new ProductPresenter(productEditView, Product);
                
            }
        }
        /// <summary>
        /// Удалить выбранный товар из базы данных
        /// </summary>
        private void DeleteProduct()
        {
            //if (_view.DataGridView.SelectedRows.Count > 0)
            //{
            //    int selectedRowIndex = _view.DataGridView.SelectedRows[0].Index;
            //    int selectedProductId = (int)_view.DataGridView.Rows[selectedRowIndex].Cells[0].Value;

            //    using (var scope = new TransactionScope())
            //    {
            //        _repository.Delete(selectedProductId);
            //        LoadProducts();

            //        scope.Complete();
            //    }
            //}
        }
    }
}
