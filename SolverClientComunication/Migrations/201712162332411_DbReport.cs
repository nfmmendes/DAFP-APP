namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbReport : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbReportLists",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TableName = c.String(nullable: false),
                        ReportLabel = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbReportLists");
        }
    }
}
