namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameFieldICAO : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbAirports", "IATA", c => c.String(maxLength: 6));
            DropColumn("dbo.DbAirports", "ICAO");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbAirports", "ICAO", c => c.String(maxLength: 6));
            DropColumn("dbo.DbAirports", "IATA");
        }
    }
}
