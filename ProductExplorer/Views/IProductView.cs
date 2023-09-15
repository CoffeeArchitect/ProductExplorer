using System.Drawing;

namespace ProductExplorer.Views
{
    public interface IProductView
    {
        string ProductName { get; set; }
        decimal ProductPrice { get; set; }
        Image ProductImage { get; set; }

        void ShowView();
        void CloseView();
    }
}
