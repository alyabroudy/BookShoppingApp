using BookShopping;
using BookShoppingApp.DataModel;
using BookShoppingApp.DataModel.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShoppingApp.Controller
{
    class ProductController
    {

        private EntityContext db;

        public ProductController(EntityContext db)
        {
            this.db = db;
        }

        /*
        * get all purchaseProducts
        */
        public List<PurchaseProduct> GetPurchaseProducts()
        {
            var purchaseProducts = db.PurchaseProducts.Include("Product").ToList();
           
            return purchaseProducts;
        }

        public List<Order> GetUserCompletedOrders(Person person)
        {
            var completedOrders = person.Card.CompletedOrders.ToList();

            return completedOrders;
        }

        /*
        * creates an Order
        */
        public Order CreateOrder(Person person, PurchaseProduct purchaseProduct)
        {
            Order order = new Order(person, purchaseProduct.Product);
            person.Card.AddOrder(order);
            purchaseProduct.Quantity = purchaseProduct.Quantity - 1;
            
            db.SaveChanges();

            return order;
        }

        /*
        * complete an Order
        */
        public Order CompleteOrder(Order order)
        {
            order.State = Order.COMPLETED_STATE;
            order.Customer.Card.CompleteOrder(order);
            db.SaveChanges();

            return order;
        }


        public bool removeOrderFromCard(Person person, Order order)
        {
            bool deleted= person.Card.RemoveOrder(order);
            db.SaveChanges();

            return deleted;
        }

    }
}
