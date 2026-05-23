using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Validator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                return;
            }
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                lblMessage.Text = "Successful";
                lblMessage.ForeColor = System.Drawing.Color.Green;
            }
        }

        
    }
}