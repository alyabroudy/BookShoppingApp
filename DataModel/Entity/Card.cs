using System;
using System.Collections.Generic;
using System.Text;

namespace BookShoppingApp.DataModel.Entity
{
    class Card
    {
        private LinkedList<OrderProduct> orderProducts;
        private int id;

        public Card()
        {
            OrderProducts = new LinkedList<OrderProduct>();
        }

        public int Id { get => id; set => id = value; }
        internal LinkedList<OrderProduct> OrderProducts { get => orderProducts; set => orderProducts = value; }
       
        /**
         * @ param product: the new product to be added to the card
         * @ return: if product is found in card it returns it else return the given product after adding it to card
         * 
         * chechs if product already in card so it increase the quantity by 1
         * if not in list it creates a new OrderProduct with new quantity
         */
        public Product AddProduct (Product product){
            foreach(OrderProduct op in OrderProducts)
            {
                if(op.Product == product)
                {
                    op.Quantity = op.Quantity + 1;
                    return product;
                }
            }

            OrderProduct newOP = new OrderProduct();
            newOP.Product = product;
            newOP.Quantity = 1;
            orderProducts.AddLast(newOP);
            return newOP.Product;
        }

        /**
         * @ param product: the new product to be removed from card
         * @ return: true if removed or quantity reduced
         * 
         * chechs if orderProducts quantity greater than 1 so it decrease it with one
         * if not then remove the OrderProduct from card
         */
        public bool RemoveProduct(Product product)
        {
            foreach (OrderProduct op in OrderProducts)
            {
                if (op.Product == product)
                {
                    if(op.Quantity > 1)
                    {
                        op.Quantity = op.Quantity - 1;
                    }
                    else
                    {
                        OrderProducts.Remove(op);
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
