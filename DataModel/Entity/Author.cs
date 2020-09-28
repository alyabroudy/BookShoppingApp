using BookShopping;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShoppingApp.DataModel.Entity
{
    class Author : Person
    {

        public Author(string givenName, string surname)
        {
            this.GivenName = givenName;
            this.Surname = surname;
        }
    }
}
