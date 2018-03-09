namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPassengersOnFlight : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbPassagensOnFlightReports",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Flight_Id = c.Long(nullable: false),
                        Passenger_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbFlightsReports", t => t.Flight_Id, cascadeDelete: false)
                .ForeignKey("dbo.DbRequests", t => t.Passenger_Id, cascadeDelete: false)
                .Index(t => t.Flight_Id)
                .Index(t => t.Passenger_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbPassagensOnFlightReports", "Passenger_Id", "dbo.DbRequests");
            DropForeignKey("dbo.DbPassagensOnFlightReports", "Flight_Id", "dbo.DbFlightsReports");
            DropIndex("dbo.DbPassagensOnFlightReports", new[] { "Passenger_Id" });
            DropIndex("dbo.DbPassagensOnFlightReports", new[] { "Flight_Id" });
            DropTable("dbo.DbPassagensOnFlightReports");
        }
    }
}
