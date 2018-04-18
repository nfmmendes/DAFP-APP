namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OptimmizationWarningTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbOptimizationAlerts",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Type = c.String(nullable: false),
                        Table = c.String(),
                        Message = c.String(nullable: false),
                        Instance_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbInstances", t => t.Instance_Id, cascadeDelete: true)
                .Index(t => t.Instance_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbOptimizationAlerts", "Instance_Id", "dbo.DbInstances");
            DropIndex("dbo.DbOptimizationAlerts", new[] { "Instance_Id" });
            DropTable("dbo.DbOptimizationAlerts");
        }
    }
}
