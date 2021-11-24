namespace Booking_Tour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arlet_table_bills : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bills", "discount", c => c.Int(nullable: false));
            AddColumn("dbo.Bills", "total_price", c => c.Int(nullable: false));
            AddColumn("dbo.Bills", "person", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bills", "person");
            DropColumn("dbo.Bills", "total_price");
            DropColumn("dbo.Bills", "discount");
        }
    }
}
