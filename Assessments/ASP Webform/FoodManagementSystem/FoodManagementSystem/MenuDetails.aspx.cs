using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodManagementSystem
{
    public partial class MenuDetails : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["MenuId"]);

            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd = new SqlCommand("select * from MenuItems where MenuId=@id", con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                lblDetails.Text = "Name: " + dr["ItemName"] +
                                  "<br/>Category: " + dr["Category"] +
                                  "<br/>Type: " + dr["FoodType"] +
                                  "<br/>Price: " + dr["Price"];
            }

            con.Close();
        }
    }
}