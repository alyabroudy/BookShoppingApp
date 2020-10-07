using BookShopping;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShoppingApp.DataModel.Entity
{
     class Session
    {
        public static Person user;

        public Session(Person user)
        {
            Session.user = user;
        }

        public Person User { get => user;}
    }
}
