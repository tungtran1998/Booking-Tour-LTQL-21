namespace Booking_Tour.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_table_tours : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tours", "avatar", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tours", "avatar", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
