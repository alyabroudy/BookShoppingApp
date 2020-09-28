using BookShopping;
using BookShopping.DataModel;
using BookShoppingApp.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShoppingApp.Controller
{
    class ModelManager<T> 
    {
        private EntityContext db= new EntityContext();
        // Create database if not exist

            public ModelManager()
        {
            db.Database.EnsureCreated();
        }

        public void GetAll()
        {
            Type type = typeof(T);
            //DbSet collection = db.GetType().GetProperty(typeof(T).Name + "s").GetValue(db, null);
          //  return db.GetType().GetProperty(typeof(T).Name + "s").GetValue(db, null);
            // T data = new Person();

            //T data = db.Find(typeof(T),  dataId);
            Console.Out.WriteLine("hier is entityContext get object, " + db.Persons + "..");
            //  T data = new Person();
            //T data = db.Find(dataType, id);
        }
  
            public T Get(int dataId)
        {
           // T data = new Person();

            //T data = db.Find(typeof(T),  dataId);
            Console.Out.WriteLine("hier is entityContext get object, " + db.Persons + "..");
            //  T data = new Person();
            //T data = db.Find(dataType, id);

            
            throw new NotImplementedException();
          //  return this;
        }

        public T GetBy(string property)
        {
            // T data = new Person();

            //T data = db.Find(typeof(T),  dataId);
            Console.Out.WriteLine("hier is entityContext get object, " + db.Persons + "..");
            //  T data = new Person();
            //T data = db.Find(dataType, id);


            throw new NotImplementedException();
            //  return this;
        }

        public T add(T data)
        {
            Console.Out.WriteLine("hier is entityContext add object, " + data + "..");

            db.Add(data);
            db.SaveChanges();
            Console.Out.WriteLine("added: one " + typeof(T).Name); 
            //  T data = new Person();
            //T data = db.Find(dataType, id);

            return data;
        }

        public T update(T data)
        {
            throw new NotImplementedException();
        }

        public bool deleteData(T data)
        {
            throw new NotImplementedException();
            return true;
        }

        public T Save(T data)
        {
            throw new NotImplementedException();
        }

        public object findBy(string propertyName, Type dataType)
        {
            throw new NotImplementedException();
        }
    }
}
