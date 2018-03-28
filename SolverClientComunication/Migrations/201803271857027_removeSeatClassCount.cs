namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeSeatClassCount : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.DbSeats", "numberOfSeats");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbSeats", "numberOfSeats", c => c.Int(nullable: false));
        }
    }
}
