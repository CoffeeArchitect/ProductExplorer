using ProductExplorer.DAL.Repositories;
using ProductExplorer.Models;
using ProductExplorer.Views;
using System;
using System.Drawing;
using System.IO;
using System.Windows;

namespace ProductExplorer.Presenters
{
    /// <summary>
    /// Класс-презентер для формы ProductView
    /// </summary>
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
        /// <summary>
        /// Метод для отображения детальной информации о товаре в форме ProductView
        /// </summary>
        /// <param name="article">Артикул</param>
        /// <param name="name">Наименование</param>
        /// <param name="price">Цена</param>
        /// <param name="qty">Кол-во</param>
        public void ShowProductDetails(string article, string name, decimal price, int qty)
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", $"{article}.jpg");
                _view.ProductArticle = article;
                _view.ProductName = name;
                _view.ProductPrice = price;
                _view.ProductQuantity = qty;

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


        // TODO: Добавить метод для сохранения изменений в базе данных
        

    }
}
