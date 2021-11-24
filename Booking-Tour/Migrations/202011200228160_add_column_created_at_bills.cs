namespace Booking_Tour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_created_at_bills : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "created_at", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "created_at");
        }
    }
}
