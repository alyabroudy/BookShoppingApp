using System;
using System.Collections.Generic;
using System.Text;

namespace BookShopping.DataModel.Entity
{
    class Media
    {
        private Category category;
        private Format format;
        private int id;
        private Person author;
        private String title;
        private String EAN;
        private Person publisher;
        private DateTime data;
        private float price;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public string EAN1 { get => EAN; set => EAN = value; }
        public DateTime Data { get => data; set => data = value; }
        public float Price { get => price; set => price = value; }
        internal Category Category { get => category; set => category = value; }
        internal Format Format { get => format; set => format = value; }
        internal Person Author { get => author; set => author = value; }
        internal Person Publisher { get => publisher; set => publisher = value; }
    }
}
