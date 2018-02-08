namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Airplanes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Prefix = c.String(nullable: false, maxLength: 25),
                        Capacity = c.Double(nullable: false),
                        DbInstance_Id = c.Long(),
                        Model_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbInstances", t => t.DbInstance_Id)
                .ForeignKey("dbo.DbAirplaneModels", t => t.Model_Id, cascadeDelete: true)
                .Index(t => t.DbInstance_Id)
                .Index(t => t.Model_Id);
            
            CreateTable(
                "dbo.DbInstances",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 15),
                        Description = c.String(maxLength: 40),
                        CreatedOn = c.DateTime(nullable: false),
                        LastOptimization = c.DateTime(nullable: false),
                        Optimized = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbAirplaneModels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Airports",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        Prefix = c.String(nullable: false, maxLength: 6),
                        City = c.String(nullable: false, maxLength: 25),
                        Name = c.String(maxLength: 55),
                        Openning_Hour = c.Int(nullable: false),
                        Openning_Minute = c.Int(nullable: false),
                        Openning_Second = c.Int(nullable: false),
                        Openning_Millisecond = c.Int(nullable: false),
                        Closing_Hour = c.Int(nullable: false),
                        Closing_Minute = c.Int(nullable: false),
                        Closing_Second = c.Int(nullable: false),
                        Closing_Millisecond = c.Int(nullable: false),
                        MaxFlightsPerHour = c.Int(nullable: false),
                        DbInstance_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbInstances", t => t.DbInstance_Id)
                .Index(t => t.DbInstance_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        DbInstance_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbInstances", t => t.DbInstance_Id)
                .Index(t => t.DbInstance_Id);
            
            CreateTable(
                "dbo.Commodities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 64),
                        Weight = c.Double(nullable: false),
                        DbCategories_Id = c.Int(),
                        DbInstance_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.DbCategories_Id)
                .ForeignKey("dbo.DbInstances", t => t.DbInstance_Id)
                .Index(t => t.DbCategories_Id)
                .Index(t => t.DbInstance_Id);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TimeOfRequisiton = c.DateTime(nullable: false),
                        TimeWindowBegin = c.DateTime(nullable: false),
                        TimeWindowEnd = c.DateTime(nullable: false),
                        DbCommodities_Id = c.Long(nullable: false),
                        DbInstance_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Commodities", t => t.DbCommodities_Id, cascadeDelete: true)
                .ForeignKey("dbo.DbInstances", t => t.DbInstance_Id, cascadeDelete: true)
                .Index(t => t.DbCommodities_Id)
                .Index(t => t.DbInstance_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "DbInstance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.Requests", "DbCommodities_Id", "dbo.Commodities");
            DropForeignKey("dbo.Commodities", "DbInstance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.Commodities", "DbCategories_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "DbInstance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.Airports", "DbInstance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.Airplanes", "Model_Id", "dbo.DbAirplaneModels");
            DropForeignKey("dbo.Airplanes", "DbInstance_Id", "dbo.DbInstances");
            DropIndex("dbo.Requests", new[] { "DbInstance_Id" });
            DropIndex("dbo.Requests", new[] { "DbCommodities_Id" });
            DropIndex("dbo.Commodities", new[] { "DbInstance_Id" });
            DropIndex("dbo.Commodities", new[] { "DbCategories_Id" });
            DropIndex("dbo.Categories", new[] { "DbInstance_Id" });
            DropIndex("dbo.Airports", new[] { "DbInstance_Id" });
            DropIndex("dbo.Airplanes", new[] { "Model_Id" });
            DropIndex("dbo.Airplanes", new[] { "DbInstance_Id" });
            DropTable("dbo.Requests");
            DropTable("dbo.Commodities");
            DropTable("dbo.Categories");
            DropTable("dbo.Airports");
            DropTable("dbo.DbAirplaneModels");
            DropTable("dbo.DbInstances");
            DropTable("dbo.Airplanes");
        }
    }
}
