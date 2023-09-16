using ProductExplorer.Models;
using ProductExplorer.Views;
using System.Drawing;

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
            ShowProductDetails(_prodcut.Name, _prodcut.Price);
        }

        public void ShowProductDetails(string name, decimal price)
        {
            _view.ProductName = name;
            _view.ProductPrice = price;
            
            _view.ShowView();
        }
    }
}
