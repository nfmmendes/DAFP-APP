namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestArc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbRequests", "DestinationAirport", c => c.String(nullable: false));
            AddColumn("dbo.DbRequests", "OriginAirport_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.DbRequests", "OriginAirport_Id");
            AddForeignKey("dbo.DbRequests", "OriginAirport_Id", "dbo.DbAirports", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbRequests", "OriginAirport_Id", "dbo.DbAirports");
            DropIndex("dbo.DbRequests", new[] { "OriginAirport_Id" });
            DropColumn("dbo.DbRequests", "OriginAirport_Id");
            DropColumn("dbo.DbRequests", "DestinationAirport");
        }
    }
}
