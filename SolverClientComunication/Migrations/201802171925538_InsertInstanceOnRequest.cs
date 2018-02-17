namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertInstanceOnRequest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbRequests", "Instance_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.DbRequests", "Instance_Id");
            AddForeignKey("dbo.DbRequests", "Instance_Id", "dbo.DbInstances", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbRequests", "Instance_Id", "dbo.DbInstances");
            DropIndex("dbo.DbRequests", new[] { "Instance_Id" });
            DropColumn("dbo.DbRequests", "Instance_Id");
        }
    }
}
