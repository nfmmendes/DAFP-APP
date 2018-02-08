namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbParemeters : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parameters",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Value = c.String(nullable: false),
                        Instance_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbInstances", t => t.Instance_Id)
                .Index(t => t.Instance_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parameters", "Instance_Id", "dbo.DbInstances");
            DropIndex("dbo.Parameters", new[] { "Instance_Id" });
            DropTable("dbo.Parameters");
        }
    }
}
