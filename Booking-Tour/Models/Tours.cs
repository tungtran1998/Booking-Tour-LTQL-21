using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class Tours
    {
        [Key]
        public int id { get; set; }

        [StringLength(30), Required]
        public string name { get; set; }
        public string day { get; set; }
        public string description { get; set; }
        [Required]
        public int price { get; set; }
        public bool status { get; set; }
        public string avatar { get; set; }
        public DateTime created_at { get; set; }
        public DateTime update_at { get; set; }

        public int provinces_id { get; set; }
        [ForeignKey("provinces_id")]
        public virtual Provinces Provinces { get; set; }
        public ICollection<Bills> Bills { get; set; }
        public ICollection<DescriptionTour> DescriptionTours { get; set; }
    }
}