namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbAirports", "AirportName", c => c.String(nullable: false));
            DropColumn("dbo.DbAirports", "AiportName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbAirports", "AiportName", c => c.String(nullable: false));
            DropColumn("dbo.DbAirports", "AirportName");
        }
    }
}
