using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using System.Web.Http;
using WebApi_Q2.Models;

namespace WebApi_Q2.Controllers
{

    public class CustomersController : ApiController
    {
        NorthwindEntities db = new NorthwindEntities();

        // GET api/customers/bycountry/USA
        [HttpGet]
        [Route("api/customers/bycountry")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var customers = db.GetCustomersByCountry(country).ToList();
            return Ok(customers);
        }
    }
}