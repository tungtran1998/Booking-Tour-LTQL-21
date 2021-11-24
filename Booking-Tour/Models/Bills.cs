using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class Bills
    {
        [Key]
        public int id { get; set; }
        [Required, Range(0, 10000000)]
        public double payments { get; set; }
        public double discount { get; set; }
        public double discount_percent { get; set; }
        public int total_price { get; set; }
        public int person { get; set; }
        public bool status { get; set; }
        public DateTime created_at { get; set; }
        public int user_id { get; set; }
        [ForeignKey("user_id")]
        public virtual Users Users { get; set; }
        public int tour_id { get; set; }
        [ForeignKey("tour_id")]
        public virtual Tours Tours { get; set; }
    }
}