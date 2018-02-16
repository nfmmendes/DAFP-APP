namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class airplanesRedefinition2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbAirplanes", "MaxFuel", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbAirplanes", "MaxFuel");
        }
    }
}
