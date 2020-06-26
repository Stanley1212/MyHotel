namespace MyHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoomOptionsv2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BedRooms", "CreateDate", c => c.DateTime(nullable: true));
            AddColumn("dbo.BedRooms", "CreateUser", c => c.String());
            AddColumn("dbo.BedRooms", "UpdateDate", c => c.DateTime(nullable: true));
            AddColumn("dbo.BedRooms", "UpdateUser", c => c.String());
            AddColumn("dbo.BedRooms", "IsInactive", c => c.Boolean(nullable: true));
            AddColumn("dbo.LevelRooms", "CreateDate", c => c.DateTime(nullable: true));
            AddColumn("dbo.LevelRooms", "CreateUser", c => c.String());
            AddColumn("dbo.LevelRooms", "UpdateDate", c => c.DateTime(nullable: true));
            AddColumn("dbo.LevelRooms", "UpdateUser", c => c.String());
            AddColumn("dbo.LevelRooms", "IsInactive", c => c.Boolean(nullable: true));
            AddColumn("dbo.TypeRooms", "CreateDate", c => c.DateTime(nullable: true));
            AddColumn("dbo.TypeRooms", "CreateUser", c => c.String());
            AddColumn("dbo.TypeRooms", "UpdateDate", c => c.DateTime(nullable: true));
            AddColumn("dbo.TypeRooms", "UpdateUser", c => c.String());
            AddColumn("dbo.TypeRooms", "IsInactive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TypeRooms", "IsInactive");
            DropColumn("dbo.TypeRooms", "UpdateUser");
            DropColumn("dbo.TypeRooms", "UpdateDate");
            DropColumn("dbo.TypeRooms", "CreateUser");
            DropColumn("dbo.TypeRooms", "CreateDate");
            DropColumn("dbo.LevelRooms", "IsInactive");
            DropColumn("dbo.LevelRooms", "UpdateUser");
            DropColumn("dbo.LevelRooms", "UpdateDate");
            DropColumn("dbo.LevelRooms", "CreateUser");
            DropColumn("dbo.LevelRooms", "CreateDate");
            DropColumn("dbo.BedRooms", "IsInactive");
            DropColumn("dbo.BedRooms", "UpdateUser");
            DropColumn("dbo.BedRooms", "UpdateDate");
            DropColumn("dbo.BedRooms", "CreateUser");
            DropColumn("dbo.BedRooms", "CreateDate");
        }
    }
}
