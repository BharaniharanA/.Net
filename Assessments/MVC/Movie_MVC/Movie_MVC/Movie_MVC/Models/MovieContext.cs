using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Movie_MVC.Models
{
    public class MovieContext: DbContext
    {
        public MovieContext() : base("MovieContext")
        {
        }

        public DbSet<Movie> Movies { get; set; }

    }
}