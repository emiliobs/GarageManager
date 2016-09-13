using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageManager.Models
{
    public class ProductModel
    {
        private GarageEntities db = new GarageEntities();

        public string InsertProduct(Product product)
        {

            try
            {
                db.Products.Add(product);
                db.SaveChanges();




                return product.Name + "Was successfully inserted.";
            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }


        }


        public string UpdateProduct(int? id, Product product)
        {
            try
            {
                //Fetch object from db:
                var p = db.Products.Find(id);

                p.Name = product.Name;
                p.Price = product.Price;
                p.TypeId = product.TypeId;
                p.Description = product.Description;
                p.Image = product.Image;

                db.SaveChanges();

                return product.Name + "Was successfully updated.";

            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }

        }

        public string DeleteProduct(int? id)
        {
            try
            {
                var product = db.Products.Find(id);

                db.Products.Attach(product);
                db.Products.Remove(product);
                db.SaveChanges();

                return product.Name + "Was successfylly Deleted.";

            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }
        }




    }
}