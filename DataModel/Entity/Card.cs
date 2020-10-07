using System;
using System.Collections.Generic;
using System.Text;

namespace BookShoppingApp.DataModel.Entity
{
    class Card
    {
        private LinkedList<Order> orders;
        private LinkedList<Order> completedOrders;
        private double sum;
        private int id;

        public Card()
        {
            Orders = new LinkedList<Order>();
            CompletedOrders = new LinkedList<Order>();
            Sum = 0;
        }

        public int Id { get => Id1; set => Id1 = value; }
        public double Sum { get => sum; set => sum = value; }
        public int Id1 { get => id; set => id = value; }
        internal LinkedList<Order> Orders { get => orders; set => orders = value; }
        internal LinkedList<Order> CompletedOrders { get => completedOrders; set => completedOrders = value; }


        /**
         * @ param order: the new order to be added to the card
         * @ return: the added order
         * 
         * chechs if order already in card so it increase its quantity by 1
         * if not in list then add it
         */
        public Order AddOrder (Order order){
            Sum = Sum + order.Sum;
            foreach(Order o in Orders)
            {
                if(o == order)
                {
                    o.Quantity = o.Quantity + order.Quantity;
                    return o;
                }
            }
            Orders.AddLast(order);
            return order;
        }


        public Order CompleteOrder(Order order)
        {
            Sum = Sum - order.Sum;
           
            Orders.Remove(order);
            CompletedOrders.AddLast(order);
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
            foreach (Order o in Orders)
            {
                if (o == order)
                {
                    if (o.Quantity > 1)
                    {
                        o.Quantity = o.Quantity - 1;
                    }
                    else
                    {
                        Orders.Remove(o);
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
