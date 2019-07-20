using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer
{
    public interface IRepository<T> where T:BaseEntity
    {
        IEnumerable<T> GetAll();
        T Get(Guid ID);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges();
    }
}
