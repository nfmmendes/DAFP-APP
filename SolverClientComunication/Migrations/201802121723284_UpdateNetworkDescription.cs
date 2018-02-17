namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNetworkDescription : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DbAirports", "UniqueAirportPerInstance");
            AddColumn("dbo.DbAirports", "AiportName", c => c.String(nullable: false));
            AddColumn("dbo.DbAirports", "IATA", c => c.String(maxLength: 6));
            AddColumn("dbo.DbAirports", "Region", c => c.String(maxLength: 25));
            AddColumn("dbo.DbAirports", "Elevation", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirports", "RunwayLength", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirports", "MTOW_APE3", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirports", "MTOW_PC12", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirports", "LandingCost", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirports", "GroundTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.DbStretches", "Distance", c => c.Int(nullable: false));
            DropColumn("dbo.DbAirports", "Prefix");
            DropColumn("dbo.DbAirports", "City");
            DropColumn("dbo.DbAirports", "Name");
            DropColumn("dbo.DbAirports", "Openning_Hour");
            DropColumn("dbo.DbAirports", "Openning_Minute");
            DropColumn("dbo.DbAirports", "Openning_Second");
            DropColumn("dbo.DbAirports", "Openning_Millisecond");
            DropColumn("dbo.DbAirports", "Closing_Hour");
            DropColumn("dbo.DbAirports", "Closing_Minute");
            DropColumn("dbo.DbAirports", "Closing_Second");
            DropColumn("dbo.DbAirports", "Closing_Millisecond");
            DropColumn("dbo.DbAirports", "MaxFlightsPerHour");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbAirports", "MaxFlightsPerHour", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirports", "Closing_Millisecond", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirports", "Closing_Second", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirports", "Closing_Minute", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirports", "Closing_Hour", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirports", "Openning_Millisecond", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirports", "Openning_Second", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirports", "Openning_Minute", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirports", "Openning_Hour", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirports", "Name", c => c.String(maxLength: 55));
            AddColumn("dbo.DbAirports", "City", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.DbAirports", "Prefix", c => c.String(nullable: false, maxLength: 6));
            DropColumn("dbo.DbStretches", "Distance");
            DropColumn("dbo.DbAirports", "GroundTime");
            DropColumn("dbo.DbAirports", "LandingCost");
            DropColumn("dbo.DbAirports", "MTOW_PC12");
            DropColumn("dbo.DbAirports", "MTOW_APE3");
            DropColumn("dbo.DbAirports", "RunwayLength");
            DropColumn("dbo.DbAirports", "Elevation");
            DropColumn("dbo.DbAirports", "Region");
            DropColumn("dbo.DbAirports", "IATA");
            DropColumn("dbo.DbAirports", "AiportName");
            CreateIndex("dbo.DbAirports", "Prefix", unique: true, name: "UniqueAirportPerInstance");
        }
    }
}
