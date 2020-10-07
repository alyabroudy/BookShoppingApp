using System;
using System.Collections.Generic;
using System.Text;
using BookShopping;

namespace BookShoppingApp.DataModel.Entity
{
    class Order
    {
        private int id;
        private Person customer;
        private Product product;
        private DateTime date;
        private int quantity;
        private int state;
        private float sum;

        public const int ON_SHOP_STATE= 0;
        public const int ON_CARD_STATE= 1;
        public const int SOLD_STATE= 2;

        public Order(Person customer, Product product, int quantity=1, int state=0)
        {
            this.customer = customer;
            this.product = product;
            this.date = DateTime.Now;
            this.quantity = quantity;
            this.state = state;
            this.sum = product.Price * quantity;
        }

        public int Id { get => id; set => id = value; }
        internal Person Customer { get => customer; set => customer = value; }
        internal Product Product { get => product; set => product = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int State { get => state; set => state = value; }
        public float Sum { get => sum; set => sum = value; }
    }
}
