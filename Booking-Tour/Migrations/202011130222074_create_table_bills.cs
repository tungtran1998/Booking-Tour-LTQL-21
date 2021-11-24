namespace Booking_Tour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_bills : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        payments = c.Int(nullable: false),
                        status = c.Boolean(nullable: false),
                        user_id = c.Int(nullable: false),
                        tour_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Tours", t => t.tour_id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id)
                .Index(t => t.tour_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bills", "user_id", "dbo.Users");
            DropForeignKey("dbo.Bills", "tour_id", "dbo.Tours");
            DropIndex("dbo.Bills", new[] { "tour_id" });
            DropIndex("dbo.Bills", new[] { "user_id" });
            DropTable("dbo.Bills");
        }
    }
}
