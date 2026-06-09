using Assessment_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace Assessment_1.Controllers
{
   [RoutePrefix("api/country")]
    public class CountryController : ApiController
    {
        CountryContext db = new CountryContext();

        // GET: api/Country
        [HttpGet]
        [Route("all")]
        public IHttpActionResult GetAll()
        {
            return Ok(db.Countries.ToList());
        }

        // GET: api/Country/1

        [HttpGet]
        [Route("ById")]
        public IHttpActionResult Get(int id)
        {
            var country = db.Countries.Find(id);
            if (country == null)
                return NotFound();

            return Ok(country);
        }

        // POST: api/Country
        [HttpPost]
        [Route("Post")]
        public IHttpActionResult Post([FromBody]Country country)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            db.Countries.Add(country);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }

        // PUT: api/Country/1
        [HttpPut]
        [Route("Put")]
        public IHttpActionResult Put(int id,[FromBody] Country country)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var data = db.Countries.Find(id);
            if (data == null)
                return NotFound();

            data.CountryName = country.CountryName;
            data.Capital = country.Capital;
            db.SaveChanges();

            return Ok();
        }

        // DELETE: api/Country/1
        [Route("Delete")]
        public IHttpActionResult Delete(int id)
        {
            var data = db.Countries.Find(id);
            if (data == null)
                return NotFound();

            db.Countries.Remove(data);
            db.SaveChanges();
            return Ok();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                db.Dispose();
            base.Dispose(disposing);
        }

    }
}
