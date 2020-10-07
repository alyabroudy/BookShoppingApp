using BookShoppingApp.DataModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShopping.DataModel.Entity
{
    class Customer : Person
    {
        private Card card;

        public Card Card { get => card; set => card = value; }
    }
}
