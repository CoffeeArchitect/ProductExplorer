using NPOI.SS.Formula.Functions;
using ProductExplorer.DAL.Repositories;
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
        private readonly IProductListView view;
        private readonly ProductRepository productRepository;

        public ProductListPresenter(IProductListView view)
        {
            this.view = view;
            productRepository = new ProductRepository();
            WireUpEvents();
            LoadProducts();
        }

        private void WireUpEvents()
        {
            view.ImportExcelClicked += (sender, args) => ImportExcel();
            view.EditProductClicked += (sender, args) => EditProduct();
            view.DeleteProductClicked += (sender, args) => DeleteProduct();
            view.ExitClicked += (sender, args) => view.CloseView();
        }

        private void LoadProducts()
        {
            var products = productRepository.GetAll();
            view.DataGridView.DataSource = products;
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
                    productRepository.Add(product);
                }
                LoadProducts();
            }
        }

        private void EditProduct()
        {
            Product product = productRepository.GetById(productId); // Получение данных о продукте по идентификатору
            view.ShowView(productView(product);
        }
        /// <summary>
        /// Удалить выбранный товар из базы данных
        /// </summary>
        private void DeleteProduct()
        {
            if (view.DataGridView.SelectedRows.Count > 0)
            {
                int selectedRowIndex = view.DataGridView.SelectedRows[0].Index;
                int selectedProductId = (int)view.DataGridView.Rows[selectedRowIndex].Cells[0].Value;

                using (var scope = new TransactionScope())
                {
                    productRepository.Delete(selectedProductId);
                    LoadProducts();

                    scope.Complete();
                }
            }
        }
    }
}
