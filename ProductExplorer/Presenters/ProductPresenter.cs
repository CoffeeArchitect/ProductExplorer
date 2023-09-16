using NPOI.SS.Formula.Functions;
using ProductExplorer.Models;
using ProductExplorer.Properties;
using ProductExplorer.Views;
using System;
using System.Drawing;
using System.IO;
using System.Windows;

namespace ProductExplorer.Presenters
{
    public class ProductPresenter
    {
        private readonly IProductView _view;
        private readonly Product _prodcut;

        public ProductPresenter(IProductView view, Product product)
        {
            _view = view;
            _prodcut = product;
            ShowProductDetails(_prodcut.Article, _prodcut.Name, _prodcut.Price, _prodcut.Quantity);
        }

        public void ShowProductDetails(string article, string name, decimal price, int qty)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", $"{article}.jpg");
                _view.ProductArticle = article;
                _view.ProductName = name;
                _view.ProductPrice = price;
                _view.ProductQuantity = qty;

                //_view.ProductImage = Image.FromFile(@"C:\Users\sergey.korolev.MICROS.000\source\repos\ProductExplorer\ProductExplorer\Resources\3A2915-R0M.jpg");
                _view.ProductImage = Image.FromFile(path);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке изображения: " + ex.Message);
            }
            finally
            {
                _view.ShowView();
            }
            
        }
    }
}
