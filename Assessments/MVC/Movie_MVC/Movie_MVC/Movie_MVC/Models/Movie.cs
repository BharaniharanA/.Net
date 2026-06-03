using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace Movie_MVC.Models
{
    public class Movie
    {

        [Key]
        public int Mid { get; set; }

        [Required]
        public string MovieName { get; set; }

        [Required]
        public string DirectorName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfRelease { get; set; }

    }
}