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
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Get Id of current logged in user an ddisplay item in caar:
            //string userId = User.Identity.GetUserId();
            //GetpurchasesInCart(userId);

            //string userId = User.Identity.GetUserId();
            GetpurchasesInCart("1");


        }

        private void GetpurchasesInCart(string userId)
        {
            CartModel model = new Models.CartModel();

            double subTotal = 0;

            //Generate HTML for each elemnt in purchaseList
            var purchaseList = model.GetOrdersInCArt(userId);
            CreateShopTable(purchaseList, out subTotal);

            //Add totals to webpage
            double vat = subTotal * 0.21;
            double totalAmount = subTotal + vat + 15;

            //Display values on page:
            litTotal.Text = "€ " + subTotal;
            LiteralVat.Text = "€ " + vat;
            LiteralTotalAmount.Text = "€ " + totalAmount;
        }

        private void CreateShopTable(List<Cart> purchaseList, out double subTotal)
        {
            subTotal = new double();
            ProductModel model = new ProductModel();

            foreach (Cart cart in purchaseList)
            {
                //Product product = model.GetProduct(cart.ProductId);
                Product product = model.GetProduct(5);

                //Create the imagen button:
                ImageButton btnImage = new ImageButton
                {
                    ImageUrl = $"~/Images/Products/{product.Image}",
                    PostBackUrl = $"~/Pages/Products.aspx?Id={product.Id}"

                };


                //Create the delete link:
                LinkButton lnkDelete = new LinkButton
                {

                    //PostBackUrl = $"~/Pages/ShoppingCart.aspx?productId={cart.Id}",
                    PostBackUrl = $"~/Pages/ShoppingCart.aspx?productId={1}",
                    Text = "Delete Item",
                    ID = "Del " + cart.Id
                };


                //Add an Onck¡lick Event:
                lnkDelete.Click += LnkDelete_Click;


                //Create the Quantity DropDownList
                //Generate list with numbers from 1 to 20:
                int[] amount = Enumerable.Range(1, 20).ToArray();
                DropDownList ddlAmount = new DropDownList
                {

                    DataSource = amount,
                    AppendDataBoundItems = true,
                    AutoPostBack = true,
                    ID = cart.Id.ToString()
                };

                ddlAmount.DataBind();
                ddlAmount.SelectedValue = cart.Amount.ToString();
                ddlAmount.SelectedIndexChanged += DdlAmount_SelectedIndexChanged;


                 //create HTML with 2 rows
                Table table = new Table {CssClass="cartTable"};
                TableRow a = new TableRow();
                TableRow b = new TableRow();

                //Create 6 cells for row a:
                TableCell a1 = new TableCell {RowSpan =2, Width=50};
                TableCell a2 = new TableCell
                {
                    Text =$"<h4>{product.Name}</h4><br/> Item No:{product.Id}<br/> In Stock",
                    HorizontalAlign = HorizontalAlign.Left,
                    Width= 350
                };
                TableCell a3 = new TableCell {Text="Unit Price<hr/>"};
                TableCell a4 = new TableCell { Text = "Quantity<hr/>" };
                TableCell a5 = new TableCell { Text = "Item Total<hr/>" };
                TableCell a6 = new TableCell {};

                //Create 6 cell for row B
                TableCell b1 = new TableCell {};
                TableCell b2 = new TableCell {Text = "€ " + product.Price};
                TableCell b3 = new TableCell {};
                TableCell b4 = new TableCell {Text = "€ " + Math.Round((Convert.ToDouble(cart.Amount * product.Price)), 2)};
                TableCell b5 = new TableCell {};
                TableCell b6 = new TableCell {};

                //Set 'Special' controls:
                a1.Controls.Add(btnImage);
                a6.Controls.Add(lnkDelete);
                b3.Controls.Add(ddlAmount);

                //Add cells to rows;
                a.Cells.Add(a1);
                a.Cells.Add(a2);
                a.Cells.Add(a3);
                a.Cells.Add(a4);
                a.Cells.Add(a5);
                a.Cells.Add(a6);

                b.Cells.Add(b1);
                b.Cells.Add(b2);
                b.Cells.Add(b3);
                b.Cells.Add(b4);
                b.Cells.Add(b5);
                b.Cells.Add(b6);

                //Add rows to table:
                table.Rows.Add(a);
                table.Rows.Add(b);

                //Add table to pnlShoppingCart:
                pnlShoopingCart.Controls.Add(table);

                //Add total amount of item in cart to subtotal:
                subTotal += Convert.ToDouble(cart.Amount * product.Price);
            }

              //Add current user's shopping cart to user specific session value:
            Session[User.Identity.GetUserId()] = purchaseList;

        }

        private void LnkDelete_Click(object sender, EventArgs e)
        {
          LinkButton selectedLink = (LinkButton)sender;
            string link = selectedLink.ID.Replace("Del", " ");
            int cartId = Convert.ToInt32(link);
            CartModel model = new CartModel();
            model.DeleteCart(cartId);

            Response.Redirect("~/Pages/ShoppingCart.aspx");

        }

        private void DdlAmount_SelectedIndexChanged(object sender, EventArgs e)
        {
             DropDownList selectedList = (DropDownList)sender;

            var quantity = Convert.ToInt32(selectedList.SelectedValue);
            var cartId = Convert.ToInt32(selectedList.ID);

            CartModel model = new CartModel();
            model.UpdateQuantity(cartId,quantity);

            Response.Redirect("~/Pages/ShoppingCart.aspx");
        }
    }


}