namespace MyHotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReceptionsAndConstrains : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Receptions",
                c => new
                    {
                        ReceptionsID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        BedRoomID = c.Int(nullable: false),
                        Day = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AmountPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                        CreateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CreateUser = c.String(),
                        UpdateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        UpdateUser = c.String(),
                        IsInactive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ReceptionsID)
                .ForeignKey("dbo.BedRooms", t => t.BedRoomID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.BedRoomID);
            
            AlterColumn("dbo.BedRooms", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.LevelRooms", "Name", c => c.String(maxLength: 25));
            AlterColumn("dbo.TypeRooms", "Name", c => c.String(maxLength: 25));
            AlterColumn("dbo.Customers", "DocumentNumber", c => c.String(maxLength: 20));
            CreateIndex("dbo.BedRooms", "Name", unique: true);
            CreateIndex("dbo.LevelRooms", "Name", unique: true);
            CreateIndex("dbo.TypeRooms", "Name", unique: true);
            CreateIndex("dbo.Customers", "DocumentNumber", unique: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receptions", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Receptions", "BedRoomID", "dbo.BedRooms");
            DropIndex("dbo.Receptions", new[] { "BedRoomID" });
            DropIndex("dbo.Receptions", new[] { "CustomerID" });
            DropIndex("dbo.Customers", new[] { "DocumentNumber" });
            DropIndex("dbo.TypeRooms", new[] { "Name" });
            DropIndex("dbo.LevelRooms", new[] { "Name" });
            DropIndex("dbo.BedRooms", new[] { "Name" });
            AlterColumn("dbo.Customers", "DocumentNumber", c => c.String());
            AlterColumn("dbo.TypeRooms", "Name", c => c.String());
            AlterColumn("dbo.LevelRooms", "Name", c => c.String());
            AlterColumn("dbo.BedRooms", "Name", c => c.String());
            DropTable("dbo.Receptions");
        }
    }
}
