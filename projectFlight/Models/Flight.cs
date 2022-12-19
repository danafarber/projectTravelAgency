using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace projectFlight.Models
{
    public class Flight
    {
        [Key]
        [StringLength(50)]
        public string flightId { get; set; }

        [Required]
        [StringLength(50)]
        public string flightTo { get; set; }

        [Required]
        [StringLength(50)]
        public string flightFrom { get; set; }

        public int price { get; set; }

        public int numberOfSeats { get; set; }

        public int? soldCount { get; set; }

        [Required]
        [StringLength(10)]
        public string timeFlight { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateFlight { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateBackFlight { get; set; }
    }
}