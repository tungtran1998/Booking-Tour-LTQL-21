namespace Booking_Tour.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Booking_Tour.Models;

    public partial class ConnectDB_BookingTour : DbContext
    {
        //public virtual DbSet<bills> bills { get; set; }
        public virtual DbSet<Regions> Regions { get; set; }
        public virtual DbSet<Provinces> Provinces { get; set; }
        public virtual DbSet<Tours> Tours { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<DescriptionTour> DescriptionTours { get; set; }
        public ConnectDB_BookingTour()
            : base("name=ConnectDB_BookingTour")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
