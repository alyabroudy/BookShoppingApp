using System;
using System.Collections.Generic;
using System.Text;
using BookShopping;
using BookShoppingApp.Controller;
using BookShoppingApp.DataModel;
using BookShoppingApp.DataModel.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookShoppingApp
{
    class LoginController
    {
        private EntityContext db;
        //private Session session;

        public LoginController(EntityContext db)
        {
            this.db = db;
        }
        public bool loginUser(string email, string password)
        {
            if(null != Session.user)
            {
                Console.Out.WriteLine("Welcome mr. "+Session.user.GivenName + ". you are already logged-in");
                return true;
            }
            DbSet<Person> ps = db.Persons;
            foreach (Person p in ps)
            {
                bool isValid = (email == p.Email && password == p.Password);
                if (isValid)
                {
                    Session.user = p;
                   Console.Out.WriteLine("Login success!! Welcome: "+ p.GivenName);
                    return true;
                }

            }
            return false;
        }
        /*
        public Person RegisterUser(Person person)
        {
            bool isNotValid = false; ;
            DbSet<Person> ps = db.Persons;
            foreach (Person p in ps)
            {
                isNotValid = (person.Email == p.Email);
            }
            if (isNotValid)
            {
                Console.Out.WriteLine(person.Email+" already registerd please login");
                return null;
            }
            else
            {
                db.Persons.Add(person);
                db.SaveChanges();
                return person;
            }
        }
        */
        public void logout()
        {
            Session.user = null;
        }
    }
}
