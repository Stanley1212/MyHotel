namespace MyHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoomOptions : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BedRooms",
                c => new
                    {
                        BedRoomID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LevelID = c.Int(nullable: false),
                        TypeRoomID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BedRoomID)
                .ForeignKey("dbo.LevelRooms", t => t.LevelID, cascadeDelete: true)
                .ForeignKey("dbo.TypeRooms", t => t.TypeRoomID, cascadeDelete: true)
                .Index(t => t.LevelID)
                .Index(t => t.TypeRoomID);
            
            CreateTable(
                "dbo.LevelRooms",
                c => new
                    {
                        LevelID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.LevelID);
            
            CreateTable(
                "dbo.TypeRooms",
                c => new
                    {
                        TypeRoomID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.TypeRoomID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BedRooms", "TypeRoomID", "dbo.TypeRooms");
            DropForeignKey("dbo.BedRooms", "LevelID", "dbo.LevelRooms");
            DropIndex("dbo.BedRooms", new[] { "TypeRoomID" });
            DropIndex("dbo.BedRooms", new[] { "LevelID" });
            DropTable("dbo.TypeRooms");
            DropTable("dbo.LevelRooms");
            DropTable("dbo.BedRooms");
        }
    }
}
