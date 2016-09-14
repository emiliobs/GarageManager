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

                //Check if the URl contains an id parameter:
                if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);

                    FillPage(id);
                }

            }
        }

        public void FillPage(int id)
        {
                 //Get selected products fron DB
            ProductModel pm = new ProductModel();

            Product product = pm.GetProduct(id);

            //Fill Texboxes:
            txtDescription.Text = product.Description;
            txtName.Text = product.Name;
            txtPrice.Text = product.Price.ToString();

            //Set dropdownlist values:
            ddImage.SelectedValue = product.Image;
            ddType.SelectedValue = product.TypeId.ToString();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ProductModel productModel = new Models.ProductModel();

            Product product = this.CreateProduct();

            //Check if the url contains an id parameter:
            if (!string.IsNullOrWhiteSpace(Request.QueryString["id"]))
            {
                //Is exists -> Update exists now
                int id = Convert.ToInt32(Request.QueryString["id"]);
                lblMessage.Text = productModel.UpdateProduct(id, product);
            }
            else
            {
              //ID does not exists -> Create a new row:
                lblMessage.Text = productModel.InsertProduct(product);
            }


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