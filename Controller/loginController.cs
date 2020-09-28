using System;
using System.Collections.Generic;
using System.Text;
using BookShopping;
using BookShopping.DataModel;
using BookShoppingApp.Controller;
using BookShoppingApp.DataModel;
using BookShoppingApp.DataModel.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookShoppingApp
{
    class loginController
    {
        private EntityContext db;
        private Session session;

        public loginController(EntityContext entityContext)
        {
            Console.Out.WriteLine("loginController Constructor");
            db = entityContext;
        }
        public bool loginUser(Person person)
        {
            Console.Out.WriteLine("loginController loginUser");

            DbSet<Person> ps = db.Persons;
            foreach (Person p in ps)
            {
                bool isValid = (person.Email == p.Email && person.Password == p.Password);
                if (isValid)
                {
                    session = new Session(p);
                   Console.Out.WriteLine("Login success!! Welcome: "+ p.GivenName);
                    return true;
                }

            }
            return false;
        }

        public Person registerUser(Person person)
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

        public void logout()
        {
            session.User = null;
        }
    }
}
