using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageManager.Models
{
    public class ProductTypeTypeModel
    {
        private GarageEntities db = new GarageEntities();

        public string InsertProductType(ProductType productType)
        {

            try
            {
                db.ProductTypes.Add(productType);
                db.SaveChanges();




                return productType.Name + " Was successfully inserted.";
            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }


        }


        public string UpdateProductType(int? id, ProductType productType)
        {
            try
            {
                //Fetch object from db:
                var p = db.ProductTypes.Find(id);

                p.Name = productType.Name;



                db.SaveChanges();

                return productType.Name + " Was successfully updated.";

            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }

        }

        public string DeleteProductType(int? id)
        {
            try
            {
                var productType = db.ProductTypes.Find(id);

                db.ProductTypes.Attach(productType);
                db.ProductTypes.Remove(productType);
                db.SaveChanges();

                return productType.Name + " Was successfylly Deleted.";

            }
            catch (Exception ex)
            {

                return "Error: " + ex.Message;
            }
        }
    }
}