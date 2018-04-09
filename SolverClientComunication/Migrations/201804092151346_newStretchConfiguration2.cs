namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newStretchConfiguration2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.DbStretches", "InstanceId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.DbStretches", new[] { "InstanceId" });
        }
    }
}
