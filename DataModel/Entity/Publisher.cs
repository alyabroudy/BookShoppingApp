using BookShopping;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShoppingApp.DataModel.Entity
{
    class Publisher : Person
    {
        public Publisher(string Surname)
        {
            this.Surname = Surname;
        }
    }
}
