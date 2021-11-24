using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class DescriptionTour
    {
        [Key]
        public int id { get; set; }
        public string avatar { get; set; }
        public int day_tour { get; set; }
        public string description { get; set; }
        public int tour_id { get; set; }
        [ForeignKey("tour_id")]
        public virtual Tours Tours { get; set; }
    }
}