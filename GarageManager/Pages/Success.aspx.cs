using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using GarageManager.Models;

namespace GarageManager.Pages
{
    public partial class Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Cart> carts = (List<Cart>) Session[User.Identity.GetUserId()];

            CartModel model = new Models.CartModel ();

            model.MarkOrdersAsPaid(carts);

            Session[User.Identity.GetUserId()] = null;
        }
    }
}