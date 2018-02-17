namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class airplanesRedefinition3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DbAirplanes", "Instance_Id", "dbo.DbInstances");
            DropIndex("dbo.DbAirplanes", new[] { "Instance_Id" });
            AlterColumn("dbo.DbAirplanes", "Instance_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.DbAirplanes", "Instance_Id");
            AddForeignKey("dbo.DbAirplanes", "Instance_Id", "dbo.DbInstances", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbAirplanes", "Instance_Id", "dbo.DbInstances");
            DropIndex("dbo.DbAirplanes", new[] { "Instance_Id" });
            AlterColumn("dbo.DbAirplanes", "Instance_Id", c => c.Long());
            CreateIndex("dbo.DbAirplanes", "Instance_Id");
            AddForeignKey("dbo.DbAirplanes", "Instance_Id", "dbo.DbInstances", "Id");
        }
    }
}
