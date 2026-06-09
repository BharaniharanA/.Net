using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assessment_1.Models
{
    public class CountryContext : DbContext
    {
        public CountryContext() : base("DBConnection") { }

        public DbSet<Country> Countries { get; set; }
    }
}