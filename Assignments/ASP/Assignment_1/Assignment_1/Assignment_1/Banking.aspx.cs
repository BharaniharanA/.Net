using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoApp1
{
    public partial class Banking : System.Web.UI.Page
    {
        string conStr = ConfigurationManager.ConnectionStrings["EmployeeDBConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAccounts();
            }
        }

        protected void cvDob_ServerValidate(object source, ServerValidateEventArgs args)
        {
            DateTime dt= Convert.ToDateTime(txtDob.Text);
            DateTime ct = DateTime.Today.AddYears(-18);
            if (ct>=dt)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void cvAgree_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid=chkAgree.Checked;
        }

        protected void cvFuaadhar_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!FuAadhar.HasFile)
            {
                args.IsValid = false;
                return;
            }
            else
            {
                
                string extension = Path.GetExtension(FuAadhar.FileName).ToLower();
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".pdf" };
                args.IsValid = allowedExtensions.Contains(extension);
            }
        }

        protected void cvFuPan_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!FuPan.HasFile)
            {
                args.IsValid = false;
                return;
            }
            else
            {
                string extension = Path.GetExtension(FuPan.FileName).ToLower();
                string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".pdf" };
                args.IsValid = allowedExtensions.Contains(extension);
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!Page.IsValid)
            {
                return;
            }

            
            Random rnd = new Random();
            int id=rnd.Next(1,99999999);
            string accNo = "BNK"+ id.ToString("D10");


            string uploadFilePathAadhar = "";
            string uploadFilePathPan = "";
            if (FuAadhar.HasFile)
            {
                string folderPath = Server.MapPath("~/AadharFilesUploads/");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string fileName = DateTime.Now.Ticks + "_" + Path.GetFileName(FuAadhar.FileName);
                string fullPath = Path.Combine(folderPath, fileName);

                FuAadhar.SaveAs(fullPath);
                uploadFilePathAadhar = "~/AadharFilesUploads/" + fileName;
            }

            if (FuPan.HasFile)
            {
                string folderPath = Server.MapPath("~/PanFilesUploads/");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                string fileName = DateTime.Now.Ticks + "_" + Path.GetFileName(FuPan.FileName);
                string fullPath = Path.Combine(folderPath, fileName);

                FuPan.SaveAs(fullPath);
                uploadFilePathPan = "~/PanFilesUploads/" + fileName;
            }

            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = @"INSERT INTO Accounts
            (AccountNo,Name, Email, Phone, Address, DOB, AccountType, Aadhar, Pan, AadharFile, PanFile)
            VALUES (@Accno,@Name, @Email, @Phone, @Address, @DOB, @AccountType, @Aadhar, @Pan, @AadharFile, @PanFile)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@AccNo", accNo);
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@DOB", txtDob.Text);
                    cmd.Parameters.AddWithValue("@AccountType", ddlAccType.SelectedValue);
                    cmd.Parameters.AddWithValue("@Aadhar", txtAadhar.Text);
                    cmd.Parameters.AddWithValue("@Pan", txtPan.Text.ToUpper());
                    cmd.Parameters.AddWithValue("@AadharFile", uploadFilePathAadhar);
                    cmd.Parameters.AddWithValue("@PanFile", uploadFilePathPan);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            lblMessage.Text = "Account registered successfully!";
            lblAccno.Text = "Account Number: " + accNo;
            lblMessage.CssClass = "success";
            lblAccno.CssClass = "success";
           
            ClearForm();
            LoadAccounts();
            //Response.Redirect(Request.RawUrl);
        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtDob.Text = "";
            ddlAccType.SelectedIndex = 0;
            txtAadhar.Text = "";
            txtPan.Text = "";
            chkAgree.Checked = false;

        }

        private void LoadAccounts()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string query = "Select * from Accounts";

                using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gvAccounts.DataSource = dt;
                    gvAccounts.DataBind();
                }
            }
        }

        protected void cvAcctype_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(ddlAccType.SelectedIndex > 0)
            {
                args.IsValid= true;

            }
            else
            {
                args.IsValid= false;
            }
        }

        
    }
}