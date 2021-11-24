namespace Booking_Tour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_type_column_aaaa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bills", "discount_percent", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bills", "discount_percent", c => c.Int(nullable: false));
        }
    }
}
