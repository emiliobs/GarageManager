﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GarageManager.Models;
using Microsoft.AspNet.Identity;

namespace GarageManager
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = Context.User.Identity;

            if (user.IsAuthenticated)
            {
                //litStatus.Text = Context.User.Identity.Name;

                lnkLogin.Visible = false;
                lnkRegister.Visible = false;

                lnkLogOut.Visible = true;
                litStatus.Visible = true;

                CartModel model = new Models.CartModel();

                string userId = HttpContext.Current.User.Identity.GetUserId();

                litStatus.Text = $"{Context.User.Identity.Name} {model.GetAmountOfOrders(userId)}";

            }
            else
            {
                lnkLogin.Visible = true;
                lnkRegister.Visible = true;

                lnkLogOut.Visible = false;
                litStatus.Visible = false;
            }
        }

        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            authenticationManager.SignOut();

            Response.Redirect("~/Index.aspx");


        }

    }
}