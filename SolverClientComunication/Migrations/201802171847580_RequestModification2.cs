namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestModification2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DbRequests", "DbInstance_Id", "dbo.DbInstances");
            DropIndex("dbo.DbRequests", new[] { "DbInstance_Id" });
            AddColumn("dbo.DbRequests", "Name", c => c.String());
            AddColumn("dbo.DbRequests", "PNR", c => c.String(nullable: false));
            AddColumn("dbo.DbRequests", "Destination_Id", c => c.Long(nullable: false));
            AddColumn("dbo.DbRequests", "Origin_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.DbRequests", "Destination_Id");
            CreateIndex("dbo.DbRequests", "Origin_Id");
            AddForeignKey("dbo.DbRequests", "Destination_Id", "dbo.DbAirports", "Id", cascadeDelete: false);
            AddForeignKey("dbo.DbRequests", "Origin_Id", "dbo.DbAirports", "Id", cascadeDelete: false);
            DropColumn("dbo.DbRequests", "DbInstance_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbRequests", "DbInstance_Id", c => c.Long(nullable: false));
            DropForeignKey("dbo.DbRequests", "Origin_Id", "dbo.DbAirports");
            DropForeignKey("dbo.DbRequests", "Destination_Id", "dbo.DbAirports");
            DropIndex("dbo.DbRequests", new[] { "Origin_Id" });
            DropIndex("dbo.DbRequests", new[] { "Destination_Id" });
            DropColumn("dbo.DbRequests", "Origin_Id");
            DropColumn("dbo.DbRequests", "Destination_Id");
            DropColumn("dbo.DbRequests", "PNR");
            DropColumn("dbo.DbRequests", "Name");
            CreateIndex("dbo.DbRequests", "DbInstance_Id");
            AddForeignKey("dbo.DbRequests", "DbInstance_Id", "dbo.DbInstances", "Id", cascadeDelete: true);
        }
    }
}
