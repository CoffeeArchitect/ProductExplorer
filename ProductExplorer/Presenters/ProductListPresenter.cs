using ProductExplorer.DAL.Repositories;
using ProductExplorer.Views;

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
            
        }

        private void EditProduct()
        {
            
        }

        private void DeleteProduct()
        {
            
        }
    }
}
