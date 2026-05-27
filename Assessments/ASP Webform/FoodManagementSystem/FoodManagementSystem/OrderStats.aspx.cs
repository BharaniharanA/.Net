using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodManagementSystem
{
    public partial class OrderStats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
                Response.Redirect("Login.aspx");

            lblStats.Text = "Visitors: " + Application["Visitors"] +
                            "<br/>Active Users: " + Application["ActiveUsers"];

            if (Cache["FoodCategoryStats"] == null)
            {
                Cache.Insert("FoodCategoryStats", "Category Data",
                    null, DateTime.Now.AddMinutes(5),
                    System.Web.Caching.Cache.NoSlidingExpiration);
            }
        }
    }
}