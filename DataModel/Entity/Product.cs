using BookShopping;
using System;
using System.Collections.Generic;
using System.Text;



namespace BookShoppingApp.DataModel.Entity
{
    class Product
    {
        private int id;
        private string title;
        private string description;
        private string category;
        private string format;
        private string author;
        private string publisher;
        private double price;
        private string ean;
        private DateTime releaseDate;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string Category { get => category; set => category = value; }
        public string Format { get => format; set => format = value; }
        public double Price { get => price; set => price = value; }
        public DateTime ReleaseDate { get => releaseDate; set => releaseDate = value; }
        public string Ean { get => ean; set => ean = value; }
        public string Author { get => author; set => author = value; }
        public string Publisher { get => publisher; set => publisher = value; }

        public override string ToString()   
        {
            return "---Product #" + this.Id + "---\n" +
                String.Format("{0,-15} | {1,-5}", "Category: ", Category + "\n") +
                String.Format("{0,-15} | {1,-5}", "Format: ", Format + "\n") +
                String.Format("{0,-15} | {1,1}", "Author: ", Author + "\n") +
                String.Format("{0,-15} | {1,1}", "Title: ", title + "\n") +
                String.Format("{0,-15} | {1,-5}", "Ean: ", Ean + "\n") +
                String.Format("{0,-15} | {1,1}", "Publisher: ", Publisher + "\n") +
                String.Format("{0,-15} | {1,1}", "Date: ", releaseDate.ToString("MMMM yyyy") + "\n") +
                String.Format("{0,-15} | {1,1}", "Price: ", Price + "\n") +
                String.Format("{0,-15} | {1,1}", "Description: ", Description + "\n")+
                "---\n";
                
        }

    }
}
