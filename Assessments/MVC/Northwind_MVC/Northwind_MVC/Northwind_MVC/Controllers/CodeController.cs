using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Northwind_MVC.Models;

namespace Northwind_MVC.Controllers
{
    public class CodeController : Controller
    {
        northwindEntities db = new northwindEntities();
        // GET: Code

        [HttpGet]

        public ActionResult Index()
        {
            var customers = db.Customers.ToList();
            return View(customers);
        }

        [HttpGet]
        public ActionResult GetCountry()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetCustomersByCountry(string country)
        {

            var customers = db.Customers.Where(c => c.Country == country).ToList();

            return View(customers);
        }

        [HttpGet]
        public ActionResult GetOrderId()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustomerByOrder(int orderId)
        {
            var customer = (from o in db.Orders
                            join c in db.Customers
                            on o.CustomerID equals c.CustomerID
                            where o.OrderID == orderId
                            select c).FirstOrDefault();

            return View(customer);
        }


    }
}