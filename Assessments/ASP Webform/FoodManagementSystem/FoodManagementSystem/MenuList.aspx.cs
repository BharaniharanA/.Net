using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodManagementSystem
{
    public partial class MenuList : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["Username"] == null)
                Response.Redirect("Login.aspx");

            if (!IsPostBack) LoadData();
        }

        void LoadData()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlDataAdapter da = new SqlDataAdapter("select * from MenuItems", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvMenu.DataSource = dt;
                    gvMenu.DataBind();
                }
            }
        }

        protected void gvMenu_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvMenu.DataKeys[e.RowIndex].Value);

            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand("delete from MenuItems where MenuId=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            LoadData();
        }
    }
}