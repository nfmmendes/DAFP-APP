namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePassengersOnFlight : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DbPassagensOnFlightReports", "Flight_Id", "dbo.DbFlightsReports");
            DropForeignKey("dbo.DbRequests", "DbPassagensOnFlightReport_Id", "dbo.DbPassagensOnFlightReports");
            DropIndex("dbo.DbPassagensOnFlightReports", new[] { "Flight_Id" });
            DropIndex("dbo.DbRequests", new[] { "DbPassagensOnFlightReport_Id" });
            DropColumn("dbo.DbRequests", "DbPassagensOnFlightReport_Id");
            DropTable("dbo.DbPassagensOnFlightReports");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DbPassagensOnFlightReports",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Flight_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DbRequests", "DbPassagensOnFlightReport_Id", c => c.Long());
            CreateIndex("dbo.DbRequests", "DbPassagensOnFlightReport_Id");
            CreateIndex("dbo.DbPassagensOnFlightReports", "Flight_Id");
            AddForeignKey("dbo.DbRequests", "DbPassagensOnFlightReport_Id", "dbo.DbPassagensOnFlightReports", "Id");
            AddForeignKey("dbo.DbPassagensOnFlightReports", "Flight_Id", "dbo.DbFlightsReports", "Id", cascadeDelete: true);
        }
    }
}
