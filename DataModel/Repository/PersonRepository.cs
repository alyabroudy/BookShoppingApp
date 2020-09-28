using BookShopping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BookShoppingApp.DataModel.Repository
{
    class PersonRepository //: EntityRepositoryInterface
    {
        private EntityContext db = new EntityContext();
        public Person add(Person person)
        {
            db.Persons.Add(person);
            db.SaveChanges();
            return person;
        }

        public bool deleteDate(Person person)
        {
            db.Persons.Remove(person);
            db.SaveChanges();
            return true;
        }

        public Person findBy(string propertyName, string value)
        {
            PropertyInfo pinfo = typeof(Person).GetProperty(propertyName);
            
            var persons = db.Persons;
            foreach(var p in persons)
            {
                var originalValue = p.GetType().GetProperty(propertyName).GetValue(p, null);
                if ( originalValue == value)
                {
                    return p;
                }
            }
            return null;
                   
        }

        public Person find(int primaryKey)
        {
            Person person = db.Persons.Find(primaryKey);
            return person;
        }

        public DbSet<Person> Getall()
        {
            var persons = db.Persons;
            return persons;
        }

        public bool SaveDate(object data, Type dataType)
        {
            throw new NotImplementedException();
        }

        public object updateDate(object data, Type dataType)
        {
            throw new NotImplementedException();
        }
    }
}
