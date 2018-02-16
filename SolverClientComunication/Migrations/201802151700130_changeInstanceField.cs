namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeInstanceField : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DbAirports", "Instance_Id", "dbo.DbInstances");
            DropIndex("dbo.DbAirports", new[] { "Instance_Id" });
            AlterColumn("dbo.DbAirports", "Instance_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.DbAirports", "Instance_Id");
            AddForeignKey("dbo.DbAirports", "Instance_Id", "dbo.DbInstances", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbAirports", "Instance_Id", "dbo.DbInstances");
            DropIndex("dbo.DbAirports", new[] { "Instance_Id" });
            AlterColumn("dbo.DbAirports", "Instance_Id", c => c.Long());
            CreateIndex("dbo.DbAirports", "Instance_Id");
            AddForeignKey("dbo.DbAirports", "Instance_Id", "dbo.DbInstances", "Id");
        }
    }
}
