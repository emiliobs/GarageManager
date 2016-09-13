using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageManager.Models
{
    public class CartModel
    {
         private GarageEntities db = new GarageEntities();

        public string InsertCart(Cart cart)
        {

            try
            {
                db.Carts.Add(cart);
                db.SaveChanges();




                return cart.DatePurchased + "Was successfully inserted.";
            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }


        }


        public string UpdateCart(int? id, Cart cart)
        {
            try
            {
                //Fetch object from db:
                var p = db.Carts.Find(id);

                p.DatePurchased = cart.DatePurchased;
                p.ClienteId = cart.ClienteId;
                p.Amount = cart.Amount;
                p.IsInCart = cart.IsInCart;
                p.ProductId = cart.ProductId;


                db.SaveChanges();

                return cart.DatePurchased + "Was successfully updated.";

            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }

        }

        public string DeleteCart(int? id)
        {
            try
            {
                var cart = db.Carts.Find(id);

                db.Carts.Attach(cart);
                db.Carts.Remove(cart);
                db.SaveChanges();

                return cart.DatePurchased + "Was successfylly Deleted.";

            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }
        }
    }
}