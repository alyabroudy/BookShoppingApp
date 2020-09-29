using System;
using System.Collections.Generic;
using System.Text;

namespace BookShoppingApp.DataModel.Entity
{
    class Card
    {
        private LinkedList<Order> orders;
        private LinkedList<Order> completedOrders;
        private float sum;
        private int id;

        public Card()
        {
            orders = new LinkedList<Order>();
            completedOrders = new LinkedList<Order>();
            sum = 0;
        }

        public int Id { get => id; set => id = value; }


        /**
         * @ param order: the new order to be added to the card
         * @ return: the added order
         * 
         * chechs if order already in card so it increase its quantity by 1
         * if not in list then add it
         */
        public Order AddOrder (Order order){
            sum = sum + order.Sum;
            foreach(Order o in orders)
            {
                if(o == order)
                {
                    o.Quantity = o.Quantity + order.Quantity;
                    return o;
                }
            }
            orders.AddLast(order);
            return order;
        }


        public Order CompleteOrder(Order order)
        {
            sum = sum - order.Sum;
           
            orders.Remove(order);
            completedOrders.AddLast(order);
            return order;
        }

        /**
         * @ param order: the order to be removed from card
         * @ return: true if removed or quantity reduced
         * 
         * checks if order quantity greater than 1 so it decrease it with one
         * if not then remove the order from card
         */
        public bool RemoveOrder(Order order)
        {
            foreach (Order o in orders)
            {
                if (o == order)
                {
                    if (o.Quantity > 1)
                    {
                        o.Quantity = o.Quantity - 1;
                    }
                    else
                    {
                        orders.Remove(o);
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
