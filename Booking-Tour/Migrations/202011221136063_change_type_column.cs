namespace Booking_Tour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_type_column : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bills", "payments", c => c.Double(nullable: false));
            AlterColumn("dbo.Bills", "discount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bills", "discount", c => c.Int(nullable: false));
            AlterColumn("dbo.Bills", "payments", c => c.Int(nullable: false));
        }
    }
}
