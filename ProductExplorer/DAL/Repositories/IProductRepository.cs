using System.Collections.Generic;

namespace ProductExplorer.DAL.Repositories
{
    public interface IProductRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(int id);
        void Save(T entity);
    }
}
