namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AirplaneAndAirportsDefinition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbInstances",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 15),
                        Description = c.String(maxLength: 40),
                        CreatedOn = c.DateTime(nullable: false),
                        LastOptimization = c.DateTime(nullable: false),
                        Optimized = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DbCategories", "DbInstance_Id", c => c.Long());
            AddColumn("dbo.DbCommodities", "DbInstance_Id", c => c.Long());
            AlterColumn("dbo.DbCategories", "Code", c => c.String(nullable: false));
            AlterColumn("dbo.DbCommodities", "Codigo", c => c.String(nullable: false, maxLength: 64));
            CreateIndex("dbo.DbCategories", "DbInstance_Id");
            CreateIndex("dbo.DbCommodities", "DbInstance_Id");
            AddForeignKey("dbo.DbCategories", "DbInstance_Id", "dbo.DbInstances", "Id");
            AddForeignKey("dbo.DbCommodities", "DbInstance_Id", "dbo.DbInstances", "Id");
            DropColumn("dbo.DbCommodities", "CategoryId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbCommodities", "CategoryId", c => c.Int(nullable: false));
            DropForeignKey("dbo.DbCommodities", "DbInstance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.DbCategories", "DbInstance_Id", "dbo.DbInstances");
            DropIndex("dbo.DbCommodities", new[] { "DbInstance_Id" });
            DropIndex("dbo.DbCategories", new[] { "DbInstance_Id" });
            AlterColumn("dbo.DbCommodities", "Codigo", c => c.String());
            AlterColumn("dbo.DbCategories", "Code", c => c.String());
            DropColumn("dbo.DbCommodities", "DbInstance_Id");
            DropColumn("dbo.DbCategories", "DbInstance_Id");
            DropTable("dbo.DbInstances");
        }
    }
}
