namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestArc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "DestinationAirport", c => c.String(nullable: false));
            AddColumn("dbo.Requests", "OriginAirport_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.Requests", "OriginAirport_Id");
            AddForeignKey("dbo.Requests", "OriginAirport_Id", "dbo.Airports", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "OriginAirport_Id", "dbo.Airports");
            DropIndex("dbo.Requests", new[] { "OriginAirport_Id" });
            DropColumn("dbo.Requests", "OriginAirport_Id");
            DropColumn("dbo.Requests", "DestinationAirport");
        }
    }
}
