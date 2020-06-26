namespace MyHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimeFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BedRooms", "CreateDate", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.BedRooms", "UpdateDate", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.LevelRooms", "CreateDate", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.LevelRooms", "UpdateDate", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.TypeRooms", "CreateDate", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.TypeRooms", "UpdateDate", c => c.DateTime(nullable: true, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AlterColumn("dbo.TypeRooms", "UpdateDate", c => c.DateTime(nullable: true));
            AlterColumn("dbo.TypeRooms", "CreateDate", c => c.DateTime(nullable: true));
            AlterColumn("dbo.LevelRooms", "UpdateDate", c => c.DateTime(nullable: true));
            AlterColumn("dbo.LevelRooms", "CreateDate", c => c.DateTime(nullable: true));
            AlterColumn("dbo.BedRooms", "UpdateDate", c => c.DateTime(nullable: true));
            AlterColumn("dbo.BedRooms", "CreateDate", c => c.DateTime(nullable: true));
        }
    }
}
