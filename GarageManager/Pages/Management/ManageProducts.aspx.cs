using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GarageManager.Models;

namespace GarageManager.Pages.Management
{
    public partial class ManageProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetImages();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ProductModel productModel = new Models.ProductModel();

            Product product = this.CreateProduct();

            lblMessage.Text = productModel.InsertProduct(product);
        }


        private void GetImages()
        {
            try
            {
                  //Get all filepaths:
                string[] images = Directory.GetFiles(Server.MapPath("~/Images/Products/"));

                //Get all filename and add them to an arraylist:
                ArrayList imageList = new ArrayList();
                foreach (var image in images )
                {
                    var imageName = image.Substring(image.LastIndexOf(@"\", StringComparison.Ordinal) + 1);
                    imageList.Add(imageName);
                }

                //Set the arrayList as the droendownview's datasource and refresh:
                ddImage.DataSource = imageList;
                ddImage.AppendDataBoundItems = true;
                ddImage.DataBind();

            }
            catch (Exception ex)
            {

                lblMessage.Text = ex.ToString();
            }
        }

        private Product CreateProduct()
        {
            Product product = new Product();

            product.Name = txtName.Text;
            product.Price = Convert.ToInt32(txtPrice.Text);
            product.TypeId = Convert.ToInt32( ddType.SelectedValue);
            product.Description = txtDescription.Text;
            product.Image = ddImage.SelectedValue;

            return product;
        }
    }
}