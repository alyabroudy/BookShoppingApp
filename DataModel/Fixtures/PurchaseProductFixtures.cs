using BookShoppingApp.Controller;
using BookShoppingApp.DataModel.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookShoppingApp.DataModel.Fixtures
{
    class PurchaseProductFixtures
    {
        private ModelManager<PurchaseProduct> pmd;

        public PurchaseProductFixtures()
        {
            pmd = new ModelManager<PurchaseProduct>();
        }

        /**
         *@param file: file path and name of the productlist  
         * 
         * imports products inpformation from a file  and save it to database
         */
        public void importProducts(string fileName = "spiegel-bestseller.txt")
        {
            //Console.WriteLine();
            string filePath= Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.FullName, @fileName);
            Console.WriteLine(filePath);
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
                                p.Author = new Author(names[0], line[1]);
                                Console.Out.WriteLine(p.Author.GivenName);
                                break;
                            case "TITLE":
                                p.Title = line[1];
                                break;
                            case "EAN":
                                p.EAN1 = line[1];
                                break;
                            case "PUBLISHER":
                                p.Publisher = new Publisher(line[1]);
                                break;
                            case "DATE":
                                //p.ReleaseDate = DateTime.ParseExact(line[1],"MMMM yyyy", null);
                                p.ReleaseDate = line[1];
                                break;
                            case "PRICE":
                               string newValue = line[1].Substring(0, 3).Replace(",", ".");
                                p.Price = float.Parse(newValue);
                                pp.Product = p;
                                pmd.add(pp);
                                break;
                        }
                        
                        }
                }
            }
           // Console.WriteLine("{0} {1} geladen", count - 1, count == 1 ? "Datensatz wurde" : "Datensätze wurden");
        }

        /**
         * create new products and save it to database
         */
        public void createProducts()
        {

        }


    }
}
