using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GarageManager.Pages.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            UserStore<IdentityUser> userStore = new UserStore<Microsoft.AspNet.Identity.EntityFramework.IdentityUser>();

            userStore.Context.Database.Connection.ConnectionString = System.Configuration
                .ConfigurationManager.ConnectionStrings["GarageConnectionString"].ConnectionString;

            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

            var user = manager.Find(txtUserName.Text, txtPassword.Text);

            if (user != null)
            {
                  //CAll OWIN funcionality:
                var authenticatioManagerm = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //Sing in user:
                authenticatioManagerm.SignIn(new Microsoft.Owin.Security.AuthenticationProperties
                {
                    IsPersistent =false,


                }, userIdentity);

                //Redirect user to homepage:
                Response.Redirect("~/Index.aspx");
            }
            else
            {
                LiteralStatus.Text = "Invalid UserName or Password.....";

            }

        }
    }
}