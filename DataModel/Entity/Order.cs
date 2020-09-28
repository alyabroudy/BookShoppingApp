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
        private OrderProduct orderProduct;

        public int Id { get => id; set => id = value; }
        public Person Customer { get => customer; set => customer = value; }
        internal OrderProduct OrderProduct { get => orderProduct; set => orderProduct = value; }
    }
}
