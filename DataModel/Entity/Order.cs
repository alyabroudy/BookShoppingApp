using System;
using System.Collections.Generic;
using System.Text;
using BookShopping;

namespace BookShoppingApp.DataModel.Entity
{
    class Order
    {
        private int id;
        private Person person;
        private Product product;
        private DateTime date;
        private int quantity;
        private int state;
        private double sum;

        public const int ON_SHOP_STATE= 0;
        public const int ON_CARD_STATE= 1;
        public const int COMPLETED_STATE= 2;

        public Order() { }

        //public Order(Person person, Product product, int quantity=1, int state=0)
        public Order(Person customer, Product product)
        {
            this.person = customer;
            this.product = product;
            this.date = DateTime.Now;
            this.quantity = 1;
            this.state = 0;
            this.sum = product.Price;
            //this.sum = product.Price * quantity;
        }

        public int Id { get => id; set => id = value; }
        public Person Customer { get => person; set => person = value; }
        public Product Product { get => product; set => product = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public int State { get => state; set => state = value; }
        public double Sum { get => sum; set => sum = value; }
        public override string ToString()
        {
            return product.ToString() +
                String.Format("{0,-15} | {1,-10}", "Quantity: ", Quantity + "\n") +
                String.Format("{0,-15} | {1,-10}", "Order State: ", State + "\n") +
                String.Format("{0,-15} | {1,-10}", "Order Price: ", Sum + "\n") +
                "---\n";

        }

    }

}
