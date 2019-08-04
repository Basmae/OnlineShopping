using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public async void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T> Get(Guid ID)
        {
            return await entities.FirstOrDefaultAsync(t=>t.ID == ID);
        }

        public IEnumerable<T> GetAll()
        {
            return  entities.AsEnumerable();
        }

       

        public async void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            await entities.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public void Remove(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
        }

        public async void SaveChanges()
        {
           await context.SaveChangesAsync();
        }

        public async void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
