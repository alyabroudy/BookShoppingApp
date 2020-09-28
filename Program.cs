using BookShopping;
using BookShoppingApp;
using BookShoppingApp.Controller;
using BookShoppingApp.DataModel;
using BookShoppingApp.DataModel.Fixtures;
using System;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main()
        {
            Console.Out.WriteLine("main");

             EntityContext db = new EntityContext();
            // ModelManager mg = new ModelManager();
            PurchaseProductFixtures purchaseProductFixtures = new PurchaseProductFixtures();
           // purchaseProductFixtures.importProducts();

            loginController loginC = new loginController(db);

            ModelManager<Person> pmd = new ModelManager<Person>();

            Person p1 = new Person();
            p1.GivenName="sam";
            p1.Surname="soso";
            p1.Email = "soso@gmail.com";
            p1.Password = "123";

            //db.Persons.Add(p1);
           //db.SaveChanges();
            //pmd.GetAll();
            loginC.loginUser(p1);



            //Type t = typeof(Person);
            //mg.addData(p1, typeof(Person));

            //mg.getData(1, typeof(Person));
            
            Console.Out.WriteLine("mainEnd");

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