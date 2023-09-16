using ProductExplorer.DAL.Repositories;
using ProductExplorer.Presenters;
using ProductExplorer.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace ProductExplorer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string connectionString = ConfigurationManager.ConnectionStrings["СonnectToLocalDb"].ConnectionString;
            IProductListView view = new ProductListView();
            IProductRepository repository = new ProductRepository(connectionString);
            ProductListPresenter presenter = new ProductListPresenter(view, repository);
            Application.Run((Form)view);
        }
    }
}
