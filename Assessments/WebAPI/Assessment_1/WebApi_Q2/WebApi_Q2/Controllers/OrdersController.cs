using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApi_Q2.Models;

namespace WebApi_Q2.Controllers
{

    public class OrdersController : Controller
    {
        NorthwindEntities db = new NorthwindEntities();

        // GET: api/orders/buchanan
        [HttpGet]

        public ActionResult GetOrders()
        {
            var orders = db.Orders.Where(o => o.EmployeeID == 5)
                .Select(o=>o).ToList();

            return View(orders);
        }
    }

}