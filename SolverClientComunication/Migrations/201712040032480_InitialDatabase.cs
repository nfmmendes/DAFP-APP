namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbAirplanes",
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
                "dbo.DbAirports",
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
                "dbo.DbCategories",
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
                "dbo.DbCommodities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 64),
                        Weight = c.Double(nullable: false),
                        DbCategories_Id = c.Int(),
                        DbInstance_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbCategories", t => t.DbCategories_Id)
                .ForeignKey("dbo.DbInstances", t => t.DbInstance_Id)
                .Index(t => t.DbCategories_Id)
                .Index(t => t.DbInstance_Id);
            
            CreateTable(
                "dbo.DbRequests",
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
                .ForeignKey("dbo.DbCommodities", t => t.DbCommodities_Id, cascadeDelete: true)
                .ForeignKey("dbo.DbInstances", t => t.DbInstance_Id, cascadeDelete: true)
                .Index(t => t.DbCommodities_Id)
                .Index(t => t.DbInstance_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbRequests", "DbInstance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.DbRequests", "DbCommodities_Id", "dbo.DbCommodities");
            DropForeignKey("dbo.DbCommodities", "DbInstance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.DbCommodities", "DbCategories_Id", "dbo.DbCategories");
            DropForeignKey("dbo.DbCategories", "DbInstance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.DbAirports", "DbInstance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.DbAirplanes", "Model_Id", "dbo.DbAirplaneModels");
            DropForeignKey("dbo.DbAirplanes", "DbInstance_Id", "dbo.DbInstances");
            DropIndex("dbo.DbRequests", new[] { "DbInstance_Id" });
            DropIndex("dbo.DbRequests", new[] { "DbCommodities_Id" });
            DropIndex("dbo.DbCommodities", new[] { "DbInstance_Id" });
            DropIndex("dbo.DbCommodities", new[] { "DbCategories_Id" });
            DropIndex("dbo.DbCategories", new[] { "DbInstance_Id" });
            DropIndex("dbo.DbAirports", new[] { "DbInstance_Id" });
            DropIndex("dbo.DbAirplanes", new[] { "Model_Id" });
            DropIndex("dbo.DbAirplanes", new[] { "DbInstance_Id" });
            DropTable("dbo.DbRequests");
            DropTable("dbo.DbCommodities");
            DropTable("dbo.DbCategories");
            DropTable("dbo.DbAirports");
            DropTable("dbo.DbAirplaneModels");
            DropTable("dbo.DbInstances");
            DropTable("dbo.DbAirplanes");
        }
    }
}
