using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataLayer;
namespace RepositoryLayer
{
    public class OnlineShoppingContext:DbContext
    {
        public OnlineShoppingContext(DbContextOptions<OnlineShoppingContext> options)
           : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new UserMap(modelBuilder.Entity<User>());
            new CartMap(modelBuilder.Entity<Cart>());
            new ImageMap(modelBuilder.Entity<Image>());
            new OrderMap(modelBuilder.Entity<Order>());
            new ProductMap(modelBuilder.Entity<Product>());
            modelBuilder.Entity<User>().HasData(new User
            {
                ID = Guid.NewGuid(),
                Name = "Basma"

            }, new User
            {
                ID = Guid.NewGuid(),
                Name = "Ola"
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ID = Guid.NewGuid(),
                ProductName = "P1",
                Description = "this is the first product",
                Price = 100,
                Quantity=5

            }, new Product
            {
                ID = Guid.NewGuid(),
                ProductName = "P2",
                Description = "this is the second product",
                Price = 200,
                Quantity=10
            });


        }
    }
}
