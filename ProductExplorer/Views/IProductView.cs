using System.Drawing;

namespace ProductExplorer.Views
{
    public interface IProductView
    {
        string ProductArticle { get; set; }
        string ProductName { get; set; }
        decimal ProductPrice { get; set; }
        int ProductQuantity { get; set; }
        Image ProductImage { get; set; }

        void ShowView();
        void CloseView();
    }
}
