using ProductExplorer.Models;
using System.Collections.Generic;

namespace ProductExplorer.DAL.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Delete(int id);
        void Update(Product product);
        void Save(Product product);
    }
}
