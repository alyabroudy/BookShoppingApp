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

            System.Console.WriteLine("-------------------------------");
            System.Console.WriteLine("Ersteller: {0:s}", ersteller);
            System.Console.WriteLine("Version: {0:f}", version);
            System.Console.WriteLine("------------Hilfe Menue-------------");
            if(null != Session.user) {
                System.Console.WriteLine(String.Format("{0,-3} | {1,-5}", "Welcome: ", Session.user.GivenName));
            }
            else
            {
                System.Console.WriteLine(String.Format("{0,-3} | {1,-5}", "1", ": Login"));
            }


            System.Console.WriteLine(String.Format("{0,-3} | {1,-5}", "2", ": Angebote anschauen"));
            System.Console.WriteLine(String.Format("{0,-3} | {1,-5}", "3", ": Warenkorp anschauen"));
            System.Console.WriteLine(String.Format("{0,-3} | {1,-5}", "4", ": Gekaufte Waren anschauen"));
            System.Console.WriteLine(String.Format("{0,-3} | {1,-5}", "5", ": Logout und ausschalten"));
            System.Console.WriteLine("-------------------------------");

            string command = System.Console.ReadLine();
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
                    System.Console.WriteLine("*** Login ***");
                        Login();
                        break;

                    case '2':
                    System.Console.WriteLine("*** Angebote ***");
                        ShowProducts();
                        break;

                    case '3':
                    System.Console.WriteLine("*** Warenkorp ***");
                        ShowUserCard();
                        break;

                    case '4':
                    System.Console.WriteLine("*** Gekaufte Waren ***");
                        ShowPurchaseHistory();
                        break;

                    case '5':
                       System. Console.WriteLine("*** Logout und ausschalten ***");
                        logout();
                        break;
                }
        }

        private void ShowUserCard()
        {
                                                //Warernkorb items auflisten 
            Card c = new Card();
            if (c.Sum>0) 
            {

           
            foreach (var item in c.Orders)
            {
                System.Console.WriteLine(item.ToString());
            }
            }
            else
                {
                    System.Console.WriteLine("WarenKorb ist Leer !!");
                }

            
            throw new NotImplementedException();
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

                System.Console.WriteLine("Purchase History:" + completedOrders.Count);
                foreach (Order o in completedOrders)
                {
                    System.Console.Write(o.ToString());
                }
            }
            else
            {
                System.Console.WriteLine("Please Login first....");
            }
            
        }

        private void ShowProducts() //?
        {
            var purchaseProducts = productController.GetPurchaseProducts();
            bool exit = false;
            System.Console.WriteLine("Angebote:" + purchaseProducts.Count);
            foreach (PurchaseProduct p in purchaseProducts)
            {
                System.Console.Write( p.ToString());
            }
            while (!exit)
            {
                System.Console.WriteLine("Um ein Product zu Ihrem Warenkorp hinzufügen geben Sie bitt die Product ID!!");
                System.Console.Write("ProductID: ");
                string productID = System.Console.ReadLine();
                int number;
                if(productID == "x") { }
                bool success = Int32.TryParse(productID, out number);
                if (success)
                {
                    System.Console.WriteLine("Product '{0}' würde hingefügt!", productID);
                    exit = true;
                }
                else
                {
                    System.Console.WriteLine("Ungültige Product ID");
                }
            }

        }

        private void Login()
        {
            System.Console.WriteLine("------------User Login-------------");
            System.Console.WriteLine("Email:");
            string email = System.Console.ReadLine();

            System.Console.WriteLine("Password:");
                string password = System.Console.ReadLine();

                if (this.loginController.loginUser(email, password))
            {
                System.Console.WriteLine("------------Login Success-------------");

            }
            else
            {
                System.Console.WriteLine("------------Login Failed-------------");
            }
            start();
        }

    }
}
