using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using BookShopping;
using BookShoppingApp.DataModel.Entity;
using BookShopping.DataModel.Entity;

namespace BookShoppingApp.DataModel
{
    class EntityContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<PurchaseProduct> PurchaseProduct { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<Card> Card { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        //public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=bookShopping3.db");
    }
}
