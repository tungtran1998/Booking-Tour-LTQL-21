using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Booking_Tour.Models
{
    public class Provinces
    {
        public int id { get; set; }
        public string name { get; set; }
        public int region_id { get; set; }
        [ForeignKey("region_id")]
        public virtual Regions Regions { get; set; }
        public ICollection<Tours> Tours { get; set; }

    }
}