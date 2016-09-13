using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GarageManager.Models;

namespace GarageManager.Pages.Management
{
    public partial class ManageProductTypes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ProductTypeTypeModel pModel = new Models.ProductTypeTypeModel();
            ProductType pt = CreateProductType();

            lbResult.Text = pModel.InsertProductType(pt);
        }

        private ProductType CreateProductType()
        {
            ProductType p = new ProductType();
            p.Name = txtName.Text;

            return p;
        }
    }
}