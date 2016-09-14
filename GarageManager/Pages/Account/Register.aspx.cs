using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace GarageManager.Pages.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIn_Click(object sender, EventArgs e)
        {
            UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();

            userStore.Context.Database.Connection.ConnectionString = System.Configuration
                .ConfigurationManager.ConnectionStrings["GarageConnectionString"].ConnectionString;

            UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

            //Create new user try to store in DB:
            IdentityUser user = new IdentityUser();
            user.UserName = TxtUserName.Text;

            if (txtPassword.Text == txtConfirmPassword.Text)
            {

                try
                {
                    //Crreate user object:
                    //Database will be created / expandedd automatically:
                    IdentityResult result = manager.Create(user,txtPassword.Text);

                    if (result.Succeeded)
                    {
                        //Store user in db:
                        var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

                        //Set to log in new user by Cookie:
                        var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                        //Log in the new user and redirect to homepage:
                        authenticationManager.SignIn(new AuthenticationProperties(),
                            userIdentity);
                        Response.Redirect("~/Index.aspx");
                    }
                    else
                    {
                        LiteralStatus.Text = result.Errors.FirstOrDefault();
                    }

                }
                catch (Exception ex)
                {

                    LiteralStatus.Text = ex.ToString();
                }
            }
            else
            {

            }

        }
    }
}