namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterLatLongFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DbAirports", "Latitude", c => c.String(nullable: false));
            AlterColumn("dbo.DbAirports", "Longitude", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DbAirports", "Longitude", c => c.Double(nullable: false));
            AlterColumn("dbo.DbAirports", "Latitude", c => c.Double(nullable: false));
        }
    }
}
