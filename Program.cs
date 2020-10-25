using BookShopping;
using BookShoppingApp;
using BookShoppingApp.Controller;
using BookShoppingApp.DataModel;
using BookShoppingApp.DataModel.Entity;
using BookShoppingApp.DataModel.Fixtures;
using System;
using System.Globalization;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main()
        {
            System.Console.Out.WriteLine("main");
            // initiate EntityManager
            EntityContext db = new EntityContext();

            // Create database if not exist
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            // initiate LoginController 
            LoginController loginC = new LoginController(db);

            // initiate ProductController 
            ProductController pc = new ProductController(db);

            // initiate ConsoleManager
            ConsoleManager cm = new ConsoleManager(db, loginC, pc);

            Person p = new Person("soso", "jodo");

               p.Email = "soso@gmail.com";
               p.Password = "123";
               p.Card = new Card();
              // db.Cards.Add(p.Card);
               db.Add(p);
               //db.SaveChanges();

               
            
            Product p1 = new Product();
            p1.Author = "Owens, Delia";
            p1.Title = "Der Gesang der Flusskrebse";
            p1.Ean = "9783446264199";
            p1.Publisher = "hanserblau";
            p1.ReleaseDate = DateTime.Parse("Juli 2019", new CultureInfo("de-DE"));
            p1.Price = 22.00;
            p1.Category = "Belletristik";
            p1.Format = "Hardcover";
            PurchaseProduct pp1 = new PurchaseProduct(p1,1);

            pc.CreateOrder(p, pp1);


            db.Add(pp1);
            db.SaveChanges();
            
            

            cm.start();


            // ModelManager mg = new ModelManager();
            // PurchaseProductFixtures purchaseProductFixtures = new PurchaseProductFixtures();
            // purchaseProductFixtures.importProducts();



            /*  EntityManager<Person> pmd = new EntityManager<Person>();

              Person p1 = new Person();
              p1.GivenName="sam";
              p1.Surname="soso";
              p1.Email = "soso@gmail.com";
              p1.Password = "123";

              //db.Persons.Add(p1);
             //db.SaveChanges();
              //pmd.GetAll();
              loginC.loginUser(p1);
              */


            //Type t = typeof(Person);
            //mg.addData(p1, typeof(Person));

            //mg.getData(1, typeof(Person));

            System.Console.Out.WriteLine("mainEnd");

            /*
            using (var db = new BloggingContext())
            {
                // Create database if not exist
                db.Database.EnsureCreated();

                // Create 
                Console.WriteLine("Inserting a new blog");
                db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
                db.SaveChanges();

                // Read
                Console.WriteLine("Querying for a blog");
                var blog = db.Blogs
                    .OrderBy(b => b.BlogId)
                    .First();

                // Update
                Console.WriteLine("Updating the blog and adding a post");
                blog.Url = "https://devblogs.microsoft.com/dotnet";
                blog.Posts.Add(
                    new Post
                    {
                        Title = "Hello World",
                        Content = "I wrote an app using EF Core!"
                    });
                db.SaveChanges();

                // Delete
                Console.WriteLine("Delete the blog");
                db.Remove(blog);
                db.SaveChanges();
            }
            */
        }
    }
}