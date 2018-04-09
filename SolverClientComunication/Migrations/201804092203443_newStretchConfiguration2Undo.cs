namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newStretchConfiguration2Undo : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.DbStretches", new[] { "InstanceId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.DbStretches", "InstanceId");
        }
    }
}
