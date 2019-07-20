using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer
{
    public class Repository<T> : IRepository<T> where T:BaseEntity
    {
        private readonly OnlineShoppingContext context;
        private DbSet<T> entities;
       
        public Repository(OnlineShoppingContext _context)
        {
            context = _context;
            entities = context.Set<T>();
        }
        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }

        public T Get(Guid ID)
        {
            return entities.FirstOrDefault(t=>t.ID == ID);
        }

        public IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

       

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}
