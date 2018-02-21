namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeUselessTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DbCategories", "Instance_Id", "dbo.DbInstances");
            DropIndex("dbo.DbCategories", new[] { "Instance_Id" });
            DropTable("dbo.DbCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DbCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Instance_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.DbCategories", "Instance_Id");
            AddForeignKey("dbo.DbCategories", "Instance_Id", "dbo.DbInstances", "Id");
        }
    }
}
