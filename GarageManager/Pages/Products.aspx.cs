using GarageManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace GarageManager.Pages
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FillPage();
        }

        private void FillPage()
        {
            //Get selected products's data:
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);


                ProductModel pm = new Models.ProductModel();
                Product product = pm.GetProduct(id);


                //Fill page with data:
                lblPrice.Text = "Proce per unit: <br/>€ " + product.Price;
                lblTitle.Text = product.Name;
                lblDescription.Text = product.Description;
                lblItemNumber.Text = id.ToString();
                imageProduct.ImageUrl = "~/Images/Products/" + product.Image;


                //Fill amount dropdownlist with number 1 - 20:
                int[] amount = Enumerable.Range(1, 20).ToArray();
                ddlAmount.DataSource = amount;
                ddlAmount.AppendDataBoundItems = true;
                ddlAmount.DataBind();

            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {


                //string clientId = Context.User.Identity.GetUserId();

                //if (clientId != null)
                //{
                //    //ingresar todo lo de Baja
                //}
                //else
                //{
                //    lblResult.Text = "Please Log In to order items.";
                //}

                //Esto lo pongo en el if

                string clientId = "-1";
                int id = Convert.ToInt32(Request.QueryString["id"]);
                int amount = Convert.ToInt32(ddlAmount.SelectedValue);

                Cart cart = new Cart
                {

                    Amount=amount,
                    ClienteId = clientId,
                    DatePurchased = DateTime.Now,
                    IsInCart =true,
                    ProductId = id



                };

                CartModel cm = new CartModel();
                lblResult.Text = cm.InsertCart(cart);

            }
        }
    }
}