namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StretchAndClusteredRequests : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DbRequests", "OriginAirport_Id", "dbo.DbAirports");
            DropIndex("dbo.DbRequests", new[] { "OriginAirport_Id" });
            RenameColumn(table: "dbo.DbAirplanes", name: "DbInstance_Id", newName: "Instance_Id");
            RenameColumn(table: "dbo.DbAirports", name: "DbInstance_Id", newName: "Instance_Id");
            RenameColumn(table: "dbo.DbCategories", name: "DbInstance_Id", newName: "Instance_Id");
            RenameIndex(table: "dbo.DbAirplanes", name: "IX_DbInstance_Id", newName: "IX_Instance_Id");
            RenameIndex(table: "dbo.DbAirports", name: "IX_DbInstance_Id", newName: "IX_Instance_Id");
            RenameIndex(table: "dbo.DbCategories", name: "IX_DbInstance_Id", newName: "IX_Instance_Id");
            CreateTable(
                "dbo.DbClusterRequests",
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
                .ForeignKey("dbo.DbStretches", t => t.Stretch_Id, cascadeDelete: true)
                .Index(t => t.DbInstance_Id)
                .Index(t => t.Stretch_Id);
            
            CreateTable(
                "dbo.DbStretches",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Departure_Id = c.Long(),
                        Instance_Id = c.Long(),
                        Origin_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbAirports", t => t.Departure_Id)
                .ForeignKey("dbo.DbInstances", t => t.Instance_Id)
                .ForeignKey("dbo.DbAirports", t => t.Origin_Id)
                .Index(t => t.Departure_Id)
                .Index(t => t.Instance_Id)
                .Index(t => t.Origin_Id);
            
            AddColumn("dbo.DbRequests", "Stretch_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.DbAirports", "Prefix", unique: true, name: "UniqueAirportPerInstance");
            CreateIndex("dbo.DbRequests", "Stretch_Id");
            AddForeignKey("dbo.DbRequests", "Stretch_Id", "dbo.DbStretches", "Id", cascadeDelete: true);
            DropColumn("dbo.DbRequests", "DestinationAirport");
            DropColumn("dbo.DbRequests", "OriginAirport_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbRequests", "OriginAirport_Id", c => c.Long(nullable: false));
            AddColumn("dbo.DbRequests", "DestinationAirport", c => c.String(nullable: false));
            DropForeignKey("dbo.DbRequests", "Stretch_Id", "dbo.DbStretches");
            DropForeignKey("dbo.DbClusterRequests", "Stretch_Id", "dbo.DbStretches");
            DropForeignKey("dbo.DbStretches", "Origin_Id", "dbo.DbAirports");
            DropForeignKey("dbo.DbStretches", "Instance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.DbStretches", "Departure_Id", "dbo.DbAirports");
            DropForeignKey("dbo.DbClusterRequests", "DbInstance_Id", "dbo.DbInstances");
            DropIndex("dbo.DbRequests", new[] { "Stretch_Id" });
            DropIndex("dbo.DbStretches", new[] { "Origin_Id" });
            DropIndex("dbo.DbStretches", new[] { "Instance_Id" });
            DropIndex("dbo.DbStretches", new[] { "Departure_Id" });
            DropIndex("dbo.DbClusterRequests", new[] { "Stretch_Id" });
            DropIndex("dbo.DbClusterRequests", new[] { "DbInstance_Id" });
            DropIndex("dbo.DbAirports", "UniqueAirportPerInstance");
            DropColumn("dbo.DbRequests", "Stretch_Id");
            DropTable("dbo.DbStretches");
            DropTable("dbo.DbClusterRequests");
            RenameIndex(table: "dbo.DbCategories", name: "IX_Instance_Id", newName: "IX_DbInstance_Id");
            RenameIndex(table: "dbo.DbAirports", name: "IX_Instance_Id", newName: "IX_DbInstance_Id");
            RenameIndex(table: "dbo.DbAirplanes", name: "IX_Instance_Id", newName: "IX_DbInstance_Id");
            RenameColumn(table: "dbo.DbCategories", name: "Instance_Id", newName: "DbInstance_Id");
            RenameColumn(table: "dbo.DbAirports", name: "Instance_Id", newName: "DbInstance_Id");
            RenameColumn(table: "dbo.DbAirplanes", name: "Instance_Id", newName: "DbInstance_Id");
            CreateIndex("dbo.DbRequests", "OriginAirport_Id");
            AddForeignKey("dbo.DbRequests", "OriginAirport_Id", "dbo.DbAirports", "Id", cascadeDelete: true);
        }
    }
}
