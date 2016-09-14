using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GarageManager.Pages.Management
{
    public partial class Management : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
             //Get selected row:
            GridViewRow row = GridViewProducts.Rows[e.NewEditIndex];

            //Get Id of selected product:
            int rowId = Convert.ToInt32(row.Cells[1].Text);

            //Redirect user ManageProducts along with the selected rowId:
            Response.Redirect("~/Pages/Management/manageProducts.aspx?id=" + rowId);
        }
    }
}