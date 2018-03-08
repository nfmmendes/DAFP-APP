namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReportsDefinition : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.DbSeats", name: "Airplane_Id", newName: "Airplanes_Id");
            RenameIndex(table: "dbo.DbSeats", name: "IX_Airplane_Id", newName: "IX_Airplanes_Id");
            CreateTable(
                "dbo.DbFlightsReports",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FuelOnDeparture = c.Double(nullable: false),
                        FuelOnArrival = c.Double(nullable: false),
                        DepartureTime = c.Time(nullable: false, precision: 7),
                        ArrivalTime = c.Time(nullable: false, precision: 7),
                        Airplanes_Id = c.Long(nullable: false),
                        Destination_Id = c.Long(nullable: false),
                        Instance_Id = c.Long(nullable: false),
                        Origin_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbAirplanes", t => t.Airplanes_Id, cascadeDelete: false)
                .ForeignKey("dbo.DbAirports", t => t.Destination_Id, cascadeDelete: false)
                .ForeignKey("dbo.DbInstances", t => t.Instance_Id, cascadeDelete: true)
                .ForeignKey("dbo.DbAirports", t => t.Origin_Id, cascadeDelete: false)
                .Index(t => t.Airplanes_Id)
                .Index(t => t.Destination_Id)
                .Index(t => t.Instance_Id)
                .Index(t => t.Origin_Id);
            
            CreateTable(
                "dbo.DbPassagensOnFlightReports",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Flight_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbFlightsReports", t => t.Flight_Id, cascadeDelete: false)
                .Index(t => t.Flight_Id);
            
            CreateTable(
                "dbo.DbRefuelsReports",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RefuelTime = c.Time(nullable: false, precision: 7),
                        Amount = c.Double(nullable: false),
                        Airplanes_Id = c.Long(nullable: false),
                        Airport_Id = c.Long(nullable: false),
                        Instance_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbAirplanes", t => t.Airplanes_Id, cascadeDelete: false)
                .ForeignKey("dbo.DbAirports", t => t.Airport_Id, cascadeDelete: false)
                .ForeignKey("dbo.DbInstances", t => t.Instance_Id, cascadeDelete: true)
                .Index(t => t.Airplanes_Id)
                .Index(t => t.Airport_Id)
                .Index(t => t.Instance_Id);
            
            AddColumn("dbo.DbRequests", "DbPassagensOnFlightReport_Id", c => c.Long());
            CreateIndex("dbo.DbRequests", "DbPassagensOnFlightReport_Id");
            AddForeignKey("dbo.DbRequests", "DbPassagensOnFlightReport_Id", "dbo.DbPassagensOnFlightReports", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbRefuelsReports", "Instance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.DbRefuelsReports", "Airport_Id", "dbo.DbAirports");
            DropForeignKey("dbo.DbRefuelsReports", "Airplanes_Id", "dbo.DbAirplanes");
            DropForeignKey("dbo.DbRequests", "DbPassagensOnFlightReport_Id", "dbo.DbPassagensOnFlightReports");
            DropForeignKey("dbo.DbPassagensOnFlightReports", "Flight_Id", "dbo.DbFlightsReports");
            DropForeignKey("dbo.DbFlightsReports", "Origin_Id", "dbo.DbAirports");
            DropForeignKey("dbo.DbFlightsReports", "Instance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.DbFlightsReports", "Destination_Id", "dbo.DbAirports");
            DropForeignKey("dbo.DbFlightsReports", "Airplanes_Id", "dbo.DbAirplanes");
            DropIndex("dbo.DbRefuelsReports", new[] { "Instance_Id" });
            DropIndex("dbo.DbRefuelsReports", new[] { "Airport_Id" });
            DropIndex("dbo.DbRefuelsReports", new[] { "Airplanes_Id" });
            DropIndex("dbo.DbRequests", new[] { "DbPassagensOnFlightReport_Id" });
            DropIndex("dbo.DbPassagensOnFlightReports", new[] { "Flight_Id" });
            DropIndex("dbo.DbFlightsReports", new[] { "Origin_Id" });
            DropIndex("dbo.DbFlightsReports", new[] { "Instance_Id" });
            DropIndex("dbo.DbFlightsReports", new[] { "Destination_Id" });
            DropIndex("dbo.DbFlightsReports", new[] { "Airplanes_Id" });
            DropColumn("dbo.DbRequests", "DbPassagensOnFlightReport_Id");
            DropTable("dbo.DbRefuelsReports");
            DropTable("dbo.DbPassagensOnFlightReports");
            DropTable("dbo.DbFlightsReports");
            RenameIndex(table: "dbo.DbSeats", name: "IX_Airplanes_Id", newName: "IX_Airplane_Id");
            RenameColumn(table: "dbo.DbSeats", name: "Airplanes_Id", newName: "Airplane_Id");
        }
    }
}
