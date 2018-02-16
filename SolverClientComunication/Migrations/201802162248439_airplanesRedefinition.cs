namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class airplanesRedefinition : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbAirplanes", "MaxWeight", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirplanes", "FuelConsumptionFirstHour", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirplanes", "FuelConsumptionSecondHour", c => c.Int(nullable: false));
            AddColumn("dbo.DbAirplanes", "CruiseSpeed", c => c.Double(nullable: false));
            DropColumn("dbo.DbAirplanes", "Knot");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbAirplanes", "Knot", c => c.Double(nullable: false));
            DropColumn("dbo.DbAirplanes", "CruiseSpeed");
            DropColumn("dbo.DbAirplanes", "FuelConsumptionSecondHour");
            DropColumn("dbo.DbAirplanes", "FuelConsumptionFirstHour");
            DropColumn("dbo.DbAirplanes", "MaxWeight");
        }
    }
}
