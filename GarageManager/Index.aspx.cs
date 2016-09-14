using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GarageManager.Models;

namespace GarageManager
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }

        private void FillPage()
        {
            //Get a list of all products in Db:
            ProductModel pm = new ProductModel();

            List<Product> products = pm.GetAllProduct();

            //Make sure products exist in the dabase:
            if (products != null)
            {
                //Create a new Panel with an ImageButton and 2 label for each Product:
                foreach (var product in products)
                {
                    Panel productPanel = new Panel();
                    ImageButton imagenButton = new ImageButton();
                    Label lblName = new Label();
                    Label lblPrice = new Label();

                    //Set xhildrenControl`s properties:
                    imagenButton.ImageUrl = "~/Images/Products/" + product.Image;
                    imagenButton.CssClass = "productImage";
                    imagenButton.PostBackUrl = "~/Pages/Products.aspx?id=" + product.Id;

                    lblName.Text = product.Name;
                    lblName.CssClass = "productName";

                    lblPrice.Text = "€ " + product.Price;
                    lblPrice.CssClass = "productPrice";

                    //Add child controls to Panel:
                    productPanel.Controls.Add(imagenButton);
                    productPanel.Controls.Add(new Literal {Text="<br/>"});
                    productPanel.Controls.Add(lblName);
                    productPanel.Controls.Add(new Literal {Text="<br/>"});
                    productPanel.Controls.Add(lblPrice);

                    //add dynamic Panels to static Parent Panel:
                    PanelProdcuts.Controls.Add(productPanel);
                }
            }
            else
            {
               //Not products found:
                PanelProdcuts.Controls.Add(new Literal {Text ="No Products Found.!"});
            }
        }


    }
}