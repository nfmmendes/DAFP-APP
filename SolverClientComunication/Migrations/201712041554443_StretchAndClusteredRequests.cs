namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StretchAndClusteredRequests : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Requests", "OriginAirport_Id", "dbo.Airports");
            DropIndex("dbo.Requests", new[] { "OriginAirport_Id" });
            RenameColumn(table: "dbo.Airplanes", name: "DbInstance_Id", newName: "Instance_Id");
            RenameColumn(table: "dbo.Airports", name: "DbInstance_Id", newName: "Instance_Id");
            RenameColumn(table: "dbo.Categories", name: "DbInstance_Id", newName: "Instance_Id");
            RenameIndex(table: "dbo.Airplanes", name: "IX_DbInstance_Id", newName: "IX_Instance_Id");
            RenameIndex(table: "dbo.Airports", name: "IX_DbInstance_Id", newName: "IX_Instance_Id");
            RenameIndex(table: "dbo.Categories", name: "IX_DbInstance_Id", newName: "IX_Instance_Id");
            CreateTable(
                "dbo.ClusterRequests",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TimeOfRequisiton = c.DateTime(nullable: false),
                        TimeWindowBegin = c.DateTime(nullable: false),
                        TimeWindowEnd = c.DateTime(nullable: false),
                        DbInstance_Id = c.Long(nullable: false),
                        Stretch_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbInstances", t => t.DbInstance_Id, cascadeDelete: true)
                .ForeignKey("dbo.Stretches", t => t.Stretch_Id, cascadeDelete: true)
                .Index(t => t.DbInstance_Id)
                .Index(t => t.Stretch_Id);
            
            CreateTable(
                "dbo.Stretches",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Departure_Id = c.Long(),
                        Instance_Id = c.Long(),
                        Origin_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Airports", t => t.Departure_Id)
                .ForeignKey("dbo.DbInstances", t => t.Instance_Id)
                .ForeignKey("dbo.Airports", t => t.Origin_Id)
                .Index(t => t.Departure_Id)
                .Index(t => t.Instance_Id)
                .Index(t => t.Origin_Id);
            
            AddColumn("dbo.Requests", "Stretch_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.Airports", "Prefix", unique: true, name: "UniqueAirportPerInstance");
            CreateIndex("dbo.Requests", "Stretch_Id");
            AddForeignKey("dbo.Requests", "Stretch_Id", "dbo.Stretches", "Id", cascadeDelete: true);
            DropColumn("dbo.Requests", "DestinationAirport");
            DropColumn("dbo.Requests", "OriginAirport_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Requests", "OriginAirport_Id", c => c.Long(nullable: false));
            AddColumn("dbo.Requests", "DestinationAirport", c => c.String(nullable: false));
            DropForeignKey("dbo.Requests", "Stretch_Id", "dbo.Stretches");
            DropForeignKey("dbo.ClusterRequests", "Stretch_Id", "dbo.Stretches");
            DropForeignKey("dbo.Stretches", "Origin_Id", "dbo.Airports");
            DropForeignKey("dbo.Stretches", "Instance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.Stretches", "Departure_Id", "dbo.Airports");
            DropForeignKey("dbo.ClusterRequests", "DbInstance_Id", "dbo.DbInstances");
            DropIndex("dbo.Requests", new[] { "Stretch_Id" });
            DropIndex("dbo.Stretches", new[] { "Origin_Id" });
            DropIndex("dbo.Stretches", new[] { "Instance_Id" });
            DropIndex("dbo.Stretches", new[] { "Departure_Id" });
            DropIndex("dbo.ClusterRequests", new[] { "Stretch_Id" });
            DropIndex("dbo.ClusterRequests", new[] { "DbInstance_Id" });
            DropIndex("dbo.Airports", "UniqueAirportPerInstance");
            DropColumn("dbo.Requests", "Stretch_Id");
            DropTable("dbo.Stretches");
            DropTable("dbo.ClusterRequests");
            RenameIndex(table: "dbo.Categories", name: "IX_Instance_Id", newName: "IX_DbInstance_Id");
            RenameIndex(table: "dbo.Airports", name: "IX_Instance_Id", newName: "IX_DbInstance_Id");
            RenameIndex(table: "dbo.Airplanes", name: "IX_Instance_Id", newName: "IX_DbInstance_Id");
            RenameColumn(table: "dbo.Categories", name: "Instance_Id", newName: "DbInstance_Id");
            RenameColumn(table: "dbo.Airports", name: "Instance_Id", newName: "DbInstance_Id");
            RenameColumn(table: "dbo.Airplanes", name: "Instance_Id", newName: "DbInstance_Id");
            CreateIndex("dbo.Requests", "OriginAirport_Id");
            AddForeignKey("dbo.Requests", "OriginAirport_Id", "dbo.Airports", "Id", cascadeDelete: true);
        }
    }
}
