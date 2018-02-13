namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestDefinition : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DbClusterRequests", "DbInstance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.DbClusterRequests", "Stretch_Id", "dbo.DbStretches");
            DropForeignKey("dbo.DbCommodities", "DbCategories_Id", "dbo.DbCategories");
            DropForeignKey("dbo.DbCommodities", "DbInstance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.DbRequests", "DbCommodities_Id", "dbo.DbCommodities");
            DropIndex("dbo.DbClusterRequests", new[] { "DbInstance_Id" });
            DropIndex("dbo.DbClusterRequests", new[] { "Stretch_Id" });
            DropIndex("dbo.DbCommodities", new[] { "DbCategories_Id" });
            DropIndex("dbo.DbCommodities", new[] { "DbInstance_Id" });
            DropIndex("dbo.DbRequests", new[] { "DbCommodities_Id" });
            AddColumn("dbo.DbRequests", "Class", c => c.String(nullable: false));
            AddColumn("dbo.DbRequests", "Sex", c => c.String(nullable: false));
            AddColumn("dbo.DbRequests", "IsChildren", c => c.Boolean(nullable: false));
            AddColumn("dbo.DbRequests", "DepartureTimeWindowBegin", c => c.DateTime(nullable: false));
            AddColumn("dbo.DbRequests", "DepartureTimeWindowEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.DbRequests", "ArrivalTimeWindowBegin", c => c.DateTime(nullable: false));
            AddColumn("dbo.DbRequests", "ArrivalTimeWindowEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DbInstances", "LastOptimization", c => c.DateTime());
            DropColumn("dbo.DbRequests", "TimeWindowBegin");
            DropColumn("dbo.DbRequests", "TimeWindowEnd");
            DropColumn("dbo.DbRequests", "DbCommodities_Id");
            DropTable("dbo.DbClusterRequests");
            DropTable("dbo.DbCommodities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DbCommodities",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Codigo = c.String(nullable: false, maxLength: 64),
                        Weight = c.Double(nullable: false),
                        DbCategories_Id = c.Int(),
                        DbInstance_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbClusterRequests",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TimeOfRequisiton = c.DateTime(nullable: false),
                        TimeWindowBegin = c.DateTime(nullable: false),
                        TimeWindowEnd = c.DateTime(nullable: false),
                        DbInstance_Id = c.Long(nullable: false),
                        Stretch_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DbRequests", "DbCommodities_Id", c => c.Long(nullable: false));
            AddColumn("dbo.DbRequests", "TimeWindowEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.DbRequests", "TimeWindowBegin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DbInstances", "LastOptimization", c => c.DateTime(nullable: false));
            DropColumn("dbo.DbRequests", "ArrivalTimeWindowEnd");
            DropColumn("dbo.DbRequests", "ArrivalTimeWindowBegin");
            DropColumn("dbo.DbRequests", "DepartureTimeWindowEnd");
            DropColumn("dbo.DbRequests", "DepartureTimeWindowBegin");
            DropColumn("dbo.DbRequests", "IsChildren");
            DropColumn("dbo.DbRequests", "Sex");
            DropColumn("dbo.DbRequests", "Class");
            CreateIndex("dbo.DbRequests", "DbCommodities_Id");
            CreateIndex("dbo.DbCommodities", "DbInstance_Id");
            CreateIndex("dbo.DbCommodities", "DbCategories_Id");
            CreateIndex("dbo.DbClusterRequests", "Stretch_Id");
            CreateIndex("dbo.DbClusterRequests", "DbInstance_Id");
            AddForeignKey("dbo.DbRequests", "DbCommodities_Id", "dbo.DbCommodities", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DbCommodities", "DbInstance_Id", "dbo.DbInstances", "Id");
            AddForeignKey("dbo.DbCommodities", "DbCategories_Id", "dbo.DbCategories", "Id");
            AddForeignKey("dbo.DbClusterRequests", "Stretch_Id", "dbo.DbStretches", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DbClusterRequests", "DbInstance_Id", "dbo.DbInstances", "Id", cascadeDelete: true);
        }
    }
}
