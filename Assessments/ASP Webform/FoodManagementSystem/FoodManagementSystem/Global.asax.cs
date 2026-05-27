using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace FoodManagementSystem
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            Application["Visitors"] = 0;
            Application["ActiveUsers"] = 0;
        }

        void Session_Start(object sender, EventArgs e)
        {
            Application["Visitors"] = (int)Application["Visitors"] + 1;
            Application["ActiveUsers"] = (int)Application["ActiveUsers"] + 1;
        }

        void Session_End(object sender, EventArgs e)
        {
            Application["ActiveUsers"] = (int)Application["ActiveUsers"] - 1;
        }
    }
}