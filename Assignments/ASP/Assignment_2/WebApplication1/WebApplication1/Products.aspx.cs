using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Products : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindProducts();
            }
        }

        private void BindProducts()
        {
            var products = GetProduct();

            ddlProducts.DataSource = products;
            ddlProducts.DataTextField = "Name";     
            ddlProducts.DataValueField = "Location"; 

            ddlProducts.DataBind();

            ddlProducts.Items.Insert(0, new ListItem("-- Select Product --", ""));
        }
        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPrice.Text = "";
            ViewState["index"]=ddlProducts.SelectedIndex;
            if (ddlProducts.SelectedIndex > 0)
            {
                string imagePath = ddlProducts.SelectedValue;
                imgProducts.ImageUrl = imagePath;
            }
            else
            {
                imgProducts.ImageUrl = "";
                lblPrice.Text = "";
            }

        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {

            var products = GetProduct();

            if (ddlProducts.SelectedIndex > 0)
            {
                if (products[ddlProducts.SelectedIndex - 1] != null)
                {
                    lblPrice.Text = "Price: ₹ " + products[ddlProducts.SelectedIndex-1].Price;
                    lblPrice.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblPrice.Text = "Please select the product";
                    lblPrice.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblPrice.Text = "Please select the product";
                lblPrice.ForeColor = System.Drawing.Color.Red;
            }


        }

        public static List<ProductItems> GetProduct()
        {
            List<ProductItems> products = new List<ProductItems>()
            {
                new ProductItems {Name="Laptop",Price=57000.00f,Location="images/laptop.jpg"},
                new ProductItems {Name="SmartPhone",Price=21000.00f,Location="images/smartphone.jpg"},
                new ProductItems {Name="PlayStation 5",Price=69999.99f,Location="images/ps5.jpg"},
                new ProductItems {Name="XBox",Price=58000.00f,Location="images/xbox.jpg"},
                new ProductItems {Name="SmartWatch",Price=5000.00f,Location="images/smartwatch.jpg"},
            };

            return products;
        }
    }

    public class ProductItems
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public string Location { get; set; }
    }
}