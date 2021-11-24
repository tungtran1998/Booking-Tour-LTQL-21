namespace Booking_Tour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_table_tours : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tours",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 30),
                        day = c.String(),
                        description = c.String(),
                        price = c.Int(nullable: false),
                        status = c.Boolean(nullable: false),
                        avatar = c.String(nullable: false, maxLength: 255),
                        created_at = c.DateTime(nullable: false),
                        update_at = c.DateTime(nullable: false),
                        provinces_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Provinces", t => t.provinces_id, cascadeDelete: true)
                .Index(t => t.provinces_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tours", "provinces_id", "dbo.Provinces");
            DropIndex("dbo.Tours", new[] { "provinces_id" });
            DropTable("dbo.Tours");
        }
    }
}
