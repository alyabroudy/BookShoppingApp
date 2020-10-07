using BookShopping;
using BookShopping.DataModel.Entity;
using BookShoppingApp.DataModel;
using BookShoppingApp.DataModel.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShoppingApp.Controller
{
    class ProductController
    {

        private EntityContext db;

        public ProductController()
        {
            db = new EntityContext();
        }

        /*
        * get all purchaseProducts
        */
        public DbSet<PurchaseProduct> GetProducts()
        {
            DbSet<PurchaseProduct> products = db.PurchaseProducts; 

            return products;
        }

        /*
        * creates an Order
        */
        public Order CreateOrder(Person customer, PurchaseProduct purchaseProduct)
        {
            Order order = new Order(customer, purchaseProduct.Product,1,1);
            customer.Card.AddOrder(order);
            purchaseProduct.Quantity = purchaseProduct.Quantity - 1;
            db.SaveChanges();

            return order;
        }

        /*
        * complete an Order
        */
        public Order CompleteOrder(Order order)
        {
            order.State = Order.SOLD_STATE;
            order.Customer.Card.CompleteOrder(order);
            db.SaveChanges();

            return order;
        }


        public bool removeOrderFromCard(Person customer, Order order)
        {
            bool deleted= customer.Card.RemoveOrder(order);
            db.SaveChanges();

            return deleted;
        }

    }
}
