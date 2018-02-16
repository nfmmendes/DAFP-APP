namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataTableImportErrors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbImportErrors",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        File = c.String(nullable: false),
                        Sheet = c.String(nullable: false),
                        Message = c.String(nullable: false),
                        RowLine = c.Int(nullable: false),
                        ImportationHour = c.DateTime(nullable: false),
                        Instance_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbInstances", t => t.Instance_Id, cascadeDelete: true)
                .Index(t => t.Instance_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbImportErrors", "Instance_Id", "dbo.DbInstances");
            DropIndex("dbo.DbImportErrors", new[] { "Instance_Id" });
            DropTable("dbo.DbImportErrors");
        }
    }
}
