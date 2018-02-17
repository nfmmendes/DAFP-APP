namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeStretch : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DbRequests", "Stretch_Id", "dbo.DbStretches");
            DropIndex("dbo.DbRequests", new[] { "Stretch_Id" });
            DropColumn("dbo.DbRequests", "Stretch_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbRequests", "Stretch_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.DbRequests", "Stretch_Id");
            AddForeignKey("dbo.DbRequests", "Stretch_Id", "dbo.DbStretches", "Id", cascadeDelete: true);
        }
    }
}
