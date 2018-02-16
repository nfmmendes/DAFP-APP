namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbStretchAlter : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DbStretches", "Instance_Id", "dbo.DbInstances");
            DropIndex("dbo.DbStretches", new[] { "Instance_Id" });
            DropColumn("dbo.DbStretches", "Instance_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbStretches", "Instance_Id", c => c.Long());
            CreateIndex("dbo.DbStretches", "Instance_Id");
            AddForeignKey("dbo.DbStretches", "Instance_Id", "dbo.DbInstances", "Id");
        }
    }
}
