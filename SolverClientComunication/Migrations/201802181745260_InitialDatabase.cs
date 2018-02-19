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
                        Range = c.Int(nullable: false),
                        Weight = c.Int(nullable: false),
                        MaxWeight = c.Int(nullable: false),
                        FuelConsumptionFirstHour = c.Int(nullable: false),
                        FuelConsumptionSecondHour = c.Int(nullable: false),
                        CruiseSpeed = c.Double(nullable: false),
                        MaxFuel = c.Double(nullable: false),
                        Model = c.String(),
                        Capacity = c.Double(nullable: false),
                        BaseAirport_Id = c.Long(),
                        Instance_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbAirports", t => t.BaseAirport_Id)
                .ForeignKey("dbo.DbInstances", t => t.Instance_Id, cascadeDelete: true)
                .Index(t => t.BaseAirport_Id)
                .Index(t => t.Instance_Id);
            
            CreateTable(
                "dbo.DbAirports",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AiportName = c.String(nullable: false),
                        Latitude = c.String(nullable: false),
                        Longitude = c.String(nullable: false),
                        IATA = c.String(maxLength: 6),
                        Region = c.String(maxLength: 25),
                        Elevation = c.Int(nullable: false),
                        RunwayLength = c.Int(nullable: false),
                        MTOW_APE3 = c.Int(nullable: false),
                        MTOW_PC12 = c.Int(nullable: false),
                        LandingCost = c.Int(nullable: false),
                        GroundTime = c.Time(nullable: false, precision: 7),
                        Instance_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbInstances", t => t.Instance_Id, cascadeDelete: true)
                .Index(t => t.Instance_Id);
            
            CreateTable(
                "dbo.DbInstances",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 15),
                        Description = c.String(maxLength: 40),
                        CreatedOn = c.DateTime(nullable: false),
                        LastOptimization = c.DateTime(),
                        Optimized = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Instance_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbInstances", t => t.Instance_Id)
                .Index(t => t.Instance_Id);
            
            CreateTable(
                "dbo.DbGeneralParametersDefaults",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbFuelPrices",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Currency = c.String(nullable: false),
                        Value = c.String(nullable: false),
                        Airport_Id = c.Long(nullable: false),
                        Instance_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbAirports", t => t.Airport_Id, cascadeDelete: false)
                .ForeignKey("dbo.DbInstances", t => t.Instance_Id, cascadeDelete: true)
                .Index(t => t.Airport_Id)
                .Index(t => t.Instance_Id);
            
            CreateTable(
                "dbo.DbImportErrors",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        File = c.String(nullable: false),
                        Sheet = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        RowLine = c.Int(nullable: false),
                        ImportationHour = c.DateTime(nullable: false),
                        Instance_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbInstances", t => t.Instance_Id, cascadeDelete: true)
                .Index(t => t.Instance_Id);
            
            CreateTable(
                "dbo.DbParameters",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Value = c.String(nullable: false),
                        Instance_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbInstances", t => t.Instance_Id, cascadeDelete: true)
                .Index(t => t.Instance_Id);
            
            CreateTable(
                "dbo.DbReportLists",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TableName = c.String(nullable: false),
                        ReportLabel = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbRequests",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        PNR = c.String(nullable: false),
                        Class = c.String(nullable: false),
                        Sex = c.String(nullable: false),
                        IsChildren = c.Boolean(nullable: false),
                        DepartureTimeWindowBegin = c.Time(nullable: false, precision: 7),
                        DepartureTimeWindowEnd = c.Time(nullable: false, precision: 7),
                        ArrivalTimeWindowBegin = c.Time(nullable: false, precision: 7),
                        ArrivalTimeWindowEnd = c.Time(nullable: false, precision: 7),
                        Destination_Id = c.Long(nullable: false),
                        Instance_Id = c.Long(nullable: false),
                        Origin_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbAirports", t => t.Destination_Id, cascadeDelete: false)
                .ForeignKey("dbo.DbInstances", t => t.Instance_Id, cascadeDelete: true)
                .ForeignKey("dbo.DbAirports", t => t.Origin_Id, cascadeDelete: false)
                .Index(t => t.Destination_Id)
                .Index(t => t.Instance_Id)
                .Index(t => t.Origin_Id);
            
            CreateTable(
                "dbo.DbSeats",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        seatClass = c.String(nullable: false),
                        numberOfSeats = c.Int(nullable: false),
                        luggageWeightLimit = c.Double(nullable: false),
                        Airplane_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbAirplanes", t => t.Airplane_Id, cascadeDelete: true)
                .Index(t => t.Airplane_Id);
            
            CreateTable(
                "dbo.DbStretches",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Distance = c.Int(nullable: false),
                        Destination_Id = c.Long(),
                        Origin_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbAirports", t => t.Destination_Id)
                .ForeignKey("dbo.DbAirports", t => t.Origin_Id)
                .Index(t => t.Destination_Id)
                .Index(t => t.Origin_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbStretches", "Origin_Id", "dbo.DbAirports");
            DropForeignKey("dbo.DbStretches", "Destination_Id", "dbo.DbAirports");
            DropForeignKey("dbo.DbSeats", "Airplane_Id", "dbo.DbAirplanes");
            DropForeignKey("dbo.DbRequests", "Origin_Id", "dbo.DbAirports");
            DropForeignKey("dbo.DbRequests", "Instance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.DbRequests", "Destination_Id", "dbo.DbAirports");
            DropForeignKey("dbo.DbParameters", "Instance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.DbImportErrors", "Instance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.DbFuelPrices", "Instance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.DbFuelPrices", "Airport_Id", "dbo.DbAirports");
            DropForeignKey("dbo.DbCategories", "Instance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.DbAirplanes", "Instance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.DbAirplanes", "BaseAirport_Id", "dbo.DbAirports");
            DropForeignKey("dbo.DbAirports", "Instance_Id", "dbo.DbInstances");
            DropIndex("dbo.DbStretches", new[] { "Origin_Id" });
            DropIndex("dbo.DbStretches", new[] { "Destination_Id" });
            DropIndex("dbo.DbSeats", new[] { "Airplane_Id" });
            DropIndex("dbo.DbRequests", new[] { "Origin_Id" });
            DropIndex("dbo.DbRequests", new[] { "Instance_Id" });
            DropIndex("dbo.DbRequests", new[] { "Destination_Id" });
            DropIndex("dbo.DbParameters", new[] { "Instance_Id" });
            DropIndex("dbo.DbImportErrors", new[] { "Instance_Id" });
            DropIndex("dbo.DbFuelPrices", new[] { "Instance_Id" });
            DropIndex("dbo.DbFuelPrices", new[] { "Airport_Id" });
            DropIndex("dbo.DbCategories", new[] { "Instance_Id" });
            DropIndex("dbo.DbAirports", new[] { "Instance_Id" });
            DropIndex("dbo.DbAirplanes", new[] { "Instance_Id" });
            DropIndex("dbo.DbAirplanes", new[] { "BaseAirport_Id" });
            DropTable("dbo.DbStretches");
            DropTable("dbo.DbSeats");
            DropTable("dbo.DbRequests");
            DropTable("dbo.DbReportLists");
            DropTable("dbo.DbParameters");
            DropTable("dbo.DbImportErrors");
            DropTable("dbo.DbFuelPrices");
            DropTable("dbo.DbGeneralParametersDefaults");
            DropTable("dbo.DbCategories");
            DropTable("dbo.DbInstances");
            DropTable("dbo.DbAirports");
            DropTable("dbo.DbAirplanes");
        }
    }
}
