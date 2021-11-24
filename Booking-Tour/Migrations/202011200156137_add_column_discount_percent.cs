namespace Booking_Tour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_discount_percent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "discount_percent", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "discount_percent");
        }
    }
}
