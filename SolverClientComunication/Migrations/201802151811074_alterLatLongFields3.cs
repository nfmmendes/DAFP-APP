namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class alterLatLongFields3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DbAirports", "GroundTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DbAirports", "GroundTime", c => c.DateTime(nullable: false));
        }
    }
}
