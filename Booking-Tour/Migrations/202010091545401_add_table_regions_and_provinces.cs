namespace Booking_Tour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table_regions_and_provinces : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        region_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Regions", t => t.region_id, cascadeDelete: true)
                .Index(t => t.region_id);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Provinces", "region_id", "dbo.Regions");
            DropIndex("dbo.Provinces", new[] { "region_id" });
            DropTable("dbo.Regions");
            DropTable("dbo.Provinces");
        }
    }
}
