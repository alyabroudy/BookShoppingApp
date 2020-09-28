using BookShopping;
using BookShopping.DataModel.Entity;
using BookShoppingApp.DataModel;
using BookShoppingApp.DataModel.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShoppingApp.Controller
{
    class ProductController
    {
        EntityContext db;
        private ModelManager<Person> cmd;

        public ProductController()
        {
            db = new EntityContext();
        }

        /*
         * @param customer: the cutomer who wants the product to be added to his card
         * @param purchaseProduct: the purchaseProduct to be added to a cutomer card
         * 
         * addes purchaseProduct to a customer card and decrease purchaseProducts quantity in shop
         */
        public PurchaseProduct addPurchaseProductToUserCard(PurchaseProduct purchaseProduct, Customer customer)
        {
            //add purchaseProduct to customer card
            customer.Card.AddProduct(purchaseProduct.Product);

            //decrease the purchaseProduct quantity in the store
            purchaseProduct.Quantity = purchaseProduct.Quantity - 1;
            db.SaveChanges();

            return purchaseProduct;
        }

        /*
         * @param customer: the cutomer who wants to remove the product from his card
         * @param purchaseProduct: the purchaseProduct to be removed from a cutomer card
         * 
         * removes purchaseProduct from customer card and increase purchaseProducts quantity in shop
         */
        public PurchaseProduct removePurchaseProductFromUserCard(PurchaseProduct purchaseProduct, Customer customer)
        {
            //add purchaseProduct to customer card
            customer.Card.RemoveProduct(purchaseProduct.Product);

            //decrease the purchaseProduct quantity in the store
            purchaseProduct.Quantity = purchaseProduct.Quantity + 1;
            db.SaveChanges();
            return purchaseProduct;
        }


        public PurchaseProduct createPurchaseProduct(PurchaseProduct product)
        {
            db.PurchaseProduct.Add(product);
            return product;
        }

        public Object deletePurchaseProduct(PurchaseProduct product)
        {
            return db.PurchaseProduct.Remove(product);
        }

        public Object updatePurchaseProduct(PurchaseProduct product)
        {
            return db.PurchaseProduct.Update(product);
        }
    }
}
