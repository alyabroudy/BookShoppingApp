using System;
using System.Collections.Generic;
using System.Text;

namespace BookShoppingApp.DataModel.Entity
{
    class OrderProduct
    {
        private int id;
        private Product product;
        private int quantity;

        public int Id { get => id; set => id = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        internal Product Product { get => product; set => product = value; }
    }
}
