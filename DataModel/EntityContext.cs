using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using BookShopping;
using BookShoppingApp.DataModel.Entity;
using System.Reflection;

namespace BookShoppingApp.DataModel
{
    class EntityContext: DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<PurchaseProduct> PurchaseProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Card> Cards { get; set; }
        //public DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=bookShopping10.db");

    }
}
