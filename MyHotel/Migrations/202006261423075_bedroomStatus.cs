namespace MyHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bedroomStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BedRooms", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BedRooms", "Status");
        }
    }
}
