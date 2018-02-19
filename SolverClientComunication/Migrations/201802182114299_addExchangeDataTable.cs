namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addExchangeDataTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbExchangeRates",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CurrencyName = c.String(nullable: false),
                        CurrencySymbol = c.String(),
                        ValueInDolar = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Instance_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbInstances", t => t.Instance_Id, cascadeDelete: true)
                .Index(t => t.Instance_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbExchangeRates", "Instance_Id", "dbo.DbInstances");
            DropIndex("dbo.DbExchangeRates", new[] { "Instance_Id" });
            DropTable("dbo.DbExchangeRates");
        }
    }
}
