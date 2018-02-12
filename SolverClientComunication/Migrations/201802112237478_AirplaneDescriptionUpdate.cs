namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AirplaneDescriptionUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbAirplanes", "Range", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirplanes", "Weight", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirplanes", "Knot", c => c.Double(nullable: false));
            AddColumn("dbo.DbAirplanes", "BaseAirport_Id", c => c.Long());
            CreateIndex("dbo.DbAirplanes", "BaseAirport_Id");
            AddForeignKey("dbo.DbAirplanes", "BaseAirport_Id", "dbo.DbAirports", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbAirplanes", "BaseAirport_Id", "dbo.DbAirports");
            DropIndex("dbo.DbAirplanes", new[] { "BaseAirport_Id" });
            DropColumn("dbo.DbAirplanes", "BaseAirport_Id");
            DropColumn("dbo.DbAirplanes", "Knot");
            DropColumn("dbo.DbAirplanes", "Weight");
            DropColumn("dbo.DbAirplanes", "Range");
        }
    }
}
