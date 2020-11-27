using BookShoppingApp.Controller;
using BookShoppingApp.DataModel.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BookShopping;


namespace BookShoppingApp.DataModel.Fixtures
{
    class DataFixtures
    {
        private EntityContext db;

        public DataFixtures()
        {
            db = new EntityContext();
        }
        Person pe = new Person();
        /**
         *@param file: file path and name of the productlist  
         * 
         * imports products inpformation from a file  and save it to database
         */
        public void ImportProducts(string fileName = "spiegel-bestseller.txt")
        {
            //Console.WriteLine();
            string filePath= Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, @fileName);
           System. Console.WriteLine(filePath);
            using (
                 StreamReader sw = new StreamReader(filePath, Encoding.GetEncoding("iso-8859-1"))
                 )
            {
                if (!sw.EndOfStream)
                {
                        while (!sw.EndOfStream)
                        {
                            //string[] line = sw.ReadLine().Split(';');   //EXCEL
                            string[] line = sw.ReadLine().Split(':');   //EXCEL  
                        PurchaseProduct pp= new PurchaseProduct();
                        
                        pp.Quantity = 5;
                        Product p = new Product();
                        switch (line[0])
                        {
                            case "AUTHOR":
                                string[] names = line[1].Split(',');
                               // p.Author = new Author(names[0], line[1]);
                                p.Author = line[1];
                                break;
                            case "TITLE":
                                p.Title = line[1];
                                break;
                            case "ean":
                                p.Ean = line[1];
                                break;
                            case "PUBLISHER":
                                //p.Publisher = new Publisher(line[1]);
                                p.Publisher = line[1];
                                break;
                            case "DATE":
                                p.ReleaseDate = DateTime.ParseExact(line[1],"MMMM yyyy", null);
                                //p.ReleaseDate = line[1];
                                break;
                            case "PRICE":
                               string newValue = line[1].Substring(0, 3).Replace(",", ".");
                                p.Price = float.Parse(newValue);
                                pp.Product = p;
                                db.Add(pp);
                                break;
                        }
                        
                        }
                }
            }
           // Console.WriteLine("{0} {1} geladen", count - 1, count == 1 ? "Datensatz wurde" : "Datensätze wurden");
        }


        public void ImportPersons(string fileName = "fake-persons.txt")
        {
            string filePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, @fileName);
           System.Console.WriteLine(filePath);
            List<Product> allPersons = new List<Product>();

            List<string> productlines = File.ReadAllLines(filePath).ToList();

            //Remove the first line
            productlines.RemoveAt(0);

            foreach (string line in productlines)
            {
                string[] parts = line.Split(',');
                
                //Person pe = new Person();
                pe.Gender = parts[0];
                pe.GivenName = parts[1];
                pe.Surname= parts[2];
                pe.StreetAddress= parts[3];
                pe.ZipCode= Convert.ToInt32 (parts[4]);
                pe.City= parts[5];
                pe.Email= parts[6];
                pe.Username= parts[7];
                pe.Password= parts[8];
                pe.Birthday= Convert.ToDateTime (parts[9]);
               

                //allPersons.Add(parts);
            }
        }
    }
}
