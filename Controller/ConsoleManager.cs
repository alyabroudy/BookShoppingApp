using BookShoppingApp.DataModel;
using BookShoppingApp.DataModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShoppingApp.Controller
{
    class ConsoleManager
    {
        private bool isAlive;
        EntityContext entityContext;
        LoginController loginController;
        ProductController productController;



        public ConsoleManager(EntityContext entityContext, LoginController loginController, ProductController productController)
        {
            this.entityContext = entityContext;
            this.loginController = loginController;
            this.productController = productController;
            isAlive = true;
        }

        public bool IsAlive { get => isAlive; set => isAlive = value; }
        public void start()
        {
            while (isAlive)
            {    
                RunCommand(MainMenu());
            }
        }


        public char MainMenu()
        {
            string ersteller = "Alyabroudy, Aldera";
            double version = 1.0;

            Console.WriteLine("-------------------------------");
            Console.WriteLine("Ersteller: {0:s}", ersteller);
            Console.WriteLine("Version: {0:f}", version);
            Console.WriteLine("------------Hilfe Menue-------------");
            if(null != Session.user) { 
                Console.WriteLine(String.Format("{0,-3} | {1,-5}", "Welcome: ", Session.user.GivenName));
            }
            else
            {
                Console.WriteLine(String.Format("{0,-3} | {1,-5}", "1", ": Login"));
            }

            
            Console.WriteLine(String.Format("{0,-3} | {1,-5}", "2", ": Angebote anschauen"));
            Console.WriteLine(String.Format("{0,-3} | {1,-5}", "3", ": Warenkorp anschauen"));
            Console.WriteLine(String.Format("{0,-3} | {1,-5}", "4", ": Gekaufte Waren anschauen"));
            Console.WriteLine(String.Format("{0,-3} | {1,-5}", "5", ": Logout und ausschalten"));
            Console.WriteLine("-------------------------------");

            string command = Console.ReadLine();
            return command[0];
        }

        /**
        * recieves a string input if the intended command and call its method
        */
        private void RunCommand(char command)
        {
                switch (command)
                {
                    case '1':
                        Console.WriteLine("*** Login ***");
                        Login();
                        break;

                    case '2':
                        Console.WriteLine("*** Angebote ***");
                        ShowProducts();
                        break;

                    case '3':
                        Console.WriteLine("*** Warenkorp ***");
                        ShowUserCard();
                        break;

                    case '4':
                        Console.WriteLine("*** Gekaufte Waren ***");
                        ShowPurchaseHistory();
                        break;

                    case '5':
                        Console.WriteLine("*** Logout und ausschalten ***");
                        logout();
                        break;
                }
        }

        private void ShowUserCard()
        {
            if (Session.user == null) { Console.WriteLine("Bitte zuerst Einloggen"); return; }

            var orders = Session.user.Card.Orders;
            
            foreach (Order o in orders)
            {
                Console.WriteLine("Product '{0}' '{1}' Kostet: '{2}'  und Quantity: '{3}'", o.Product.Id, o.Product.Title, o.Product.Price, o.Quantity);
          
            }
           
        }

        private void logout()
        {
            isAlive = false;
        }

        private void ShowPurchaseHistory()
        {
            if(null != Session.user)
            {
                var completedOrders = productController.GetUserCompletedOrders(Session.user);

                Console.WriteLine("Purchase History:" + completedOrders.Count);
                foreach (Order o in completedOrders)
                {
                    Console.Write(o.ToString());
                }
            }
            else
            {
                Console.WriteLine("Please Login first....");
            }
            
        }

        private void ShowProducts()
        {
            var purchaseProducts = productController.GetPurchaseProducts();
            bool exit = false;
            Console.WriteLine("Angebote:" + purchaseProducts.Count);
            foreach (PurchaseProduct p in purchaseProducts)
            {
               Console.Write( p.ToString());
            }
            while (!exit)
            {
                Console.WriteLine("Um ein Product zu Ihrem Warenkorp hinzufügen geben Sie bitt die Product ID!!");
                Console.WriteLine("Oder: x   für exit");
                Console.Write("ProductID: ");
                string productID = Console.ReadLine();
                int number;
                if(productID == "x") { break; }
                if(Session.user == null) { Console.WriteLine("Bitte zuerst Einloggen");  break; }

                bool success = Int32.TryParse(productID, out number);
                if (success)
                {
                    Console.WriteLine("Product '{0}' würde hingefügt!", productID);
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Ungültige Product ID");
                }
            }

        }

        private void Login()
        {
                Console.WriteLine("------------User Login-------------");
                Console.WriteLine("Email:");
                string email = Console.ReadLine();

                Console.WriteLine("Password:");
                string password = Console.ReadLine();

                if (this.loginController.loginUser(email, password))
            {
                Console.WriteLine("------------Login Success-------------");

            }
            else
            {
                Console.WriteLine("------------Login Failed-------------");
            }
            start();
        }

    }
}
