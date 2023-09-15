using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductExplorer.DAL.Repositories
{
    public interface IProductRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Save();
    }
}
