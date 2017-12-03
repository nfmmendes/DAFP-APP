namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbCommodities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Codigo = c.String(),
                        Weight = c.Double(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        DbCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbCategories", t => t.DbCategory_Id)
                .Index(t => t.DbCategory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbCommodities", "DbCategory_Id", "dbo.DbCategories");
            DropIndex("dbo.DbCommodities", new[] { "DbCategory_Id" });
            DropTable("dbo.DbCommodities");
            DropTable("dbo.DbCategories");
        }
    }
}
