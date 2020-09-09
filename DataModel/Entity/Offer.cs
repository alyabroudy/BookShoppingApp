using System;
using System.Collections.Generic;
using System.Text;

namespace BookShopping.DataModel.Entity
{
    class Offer
    {
        private LinkedList<Media> medias;

        internal LinkedList<Media> Medias { get => medias; set => medias = value; }

        public Media AddMedia(Media media)
        {
            if (!Medias.Contains(media))
            {
                Medias.AddLast(media);
                return media;
            }
            return null;
        }

        public void RemoveMedia(Media media)
        {
            if (Medias.Contains(media))
            {
                Medias.Remove(media);
            }
        }
    }
}
