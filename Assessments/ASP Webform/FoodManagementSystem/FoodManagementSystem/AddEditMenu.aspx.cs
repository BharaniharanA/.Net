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
    public partial class AddEditMenu : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
                Response.Redirect("Login.aspx");

            if (!IsPostBack && Request.QueryString["MenuId"] != null)
            {
                int id = Convert.ToInt32(Request.QueryString["MenuId"]);

                SqlConnection con = new SqlConnection(conStr);
                SqlCommand cmd = new SqlCommand("select * from MenuItems where MenuId=@id", con);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtName.Text = dr["ItemName"].ToString();
                    txtCategory.Text = dr["Category"].ToString();
                    ddlType.SelectedValue = dr["FoodType"].ToString();
                    txtPrice.Text = dr["Price"].ToString();
                    txtQty.Text = dr["AvailableQuantity"].ToString();
                    chkAvailable.Checked = Convert.ToBoolean(dr["IsAvailable"]);
                }
                con.Close();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand cmd;

            if (Request.QueryString["MenuId"] != null)
            {
                cmd = new SqlCommand("update MenuItems set ItemName=@name, Category=@cat, FoodType=@type,Price=@price, AvailableQuantity=@qty, IsAvailable=@avail where MenuId=@id", con);

                cmd.Parameters.AddWithValue("@id", Request.QueryString["MenuId"]);
            }
            else
            {
                cmd = new SqlCommand("insert into MenuItems (ItemName,Category,FoodType,Price,AvailableQuantity,IsAvailable) values (@name,@cat,@type,@price,@qty,@avail)", con);
            }

            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@cat", txtCategory.Text);
            cmd.Parameters.AddWithValue("@type", ddlType.SelectedValue);
            cmd.Parameters.AddWithValue("@price", Convert.ToDecimal(txtPrice.Text));
            cmd.Parameters.AddWithValue("@qty", Convert.ToInt32(txtQty.Text));
            cmd.Parameters.AddWithValue("@avail", chkAvailable.Checked);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Redirect("MenuList.aspx");
        }
    }
}