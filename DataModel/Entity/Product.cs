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
        private Person author;
        private Person publisher;
        private float price;
        private string EAN;
        private string releaseDate;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string Category { get => category; set => category = value; }
        public string Format { get => format; set => format = value; }
        public float Price { get => price; set => price = value; }
        public string ReleaseDate { get => releaseDate; set => releaseDate = value; }
        public string EAN1 { get => EAN; set => EAN = value; }
        internal Person Author { get => author; set => author = value; }
        internal Person Publisher { get => publisher; set => publisher = value; }
    }
}
