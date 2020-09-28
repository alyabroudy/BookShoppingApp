using BookShopping;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShoppingApp.DataModel.Entity
{
     class Session
    {
        private Person user;

        public Session(Person customer)
        {
            User = customer;
        }

        internal Person User { get => user; set => user = value; }
    }
}
