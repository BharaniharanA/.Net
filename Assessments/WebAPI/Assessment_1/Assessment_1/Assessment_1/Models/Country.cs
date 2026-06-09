using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assessment_1.Models
{
    public class Country
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int ID { get; set; }

        [Required]
        public string CountryName { get; set; }

        [Required]
        public string Capital { get; set; }
    }

}