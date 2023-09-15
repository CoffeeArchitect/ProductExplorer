using ProductExplorer.Views;
using System.Drawing;

namespace ProductExplorer.Presenters
{
    public class ProductPresenter
    {
        private readonly IProductView view;

        public ProductPresenter(IProductView view)
        {
            this.view = view;
        }

        public void ShowProductDetails(string name, decimal price, Image image)
        {
            view.ProductName = name;
            view.ProductPrice = price;
            view.ProductImage = image;
            view.ShowView();
        }
    }
}
