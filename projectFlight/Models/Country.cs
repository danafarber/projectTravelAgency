using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace projectFlight.Models
{
    public class Country
    {
        [Key]
        [StringLength(50)]
        public string country { get; set; }

        [StringLength(50)]
        public string imageUrl { get; set; }
    }
}