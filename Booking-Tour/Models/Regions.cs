using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class Regions
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public ICollection <Provinces> Provinces { get; set; }
    }
}