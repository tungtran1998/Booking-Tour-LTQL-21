namespace Booking_Tour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescreptionTour : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DescriptionTours",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        avatar = c.String(),
                        day_tour = c.Int(nullable: false),
                        description = c.String(),
                        tour_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Tours", t => t.tour_id, cascadeDelete: true)
                .Index(t => t.tour_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DescriptionTours", "tour_id", "dbo.Tours");
            DropIndex("dbo.DescriptionTours", new[] { "tour_id" });
            DropTable("dbo.DescriptionTours");
        }
    }
}
