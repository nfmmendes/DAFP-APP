namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fuelPriceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbFuelPrices",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Currency = c.String(nullable: false),
                        Value = c.String(nullable: false),
                        Airport_Id = c.Long(nullable: false),
                        Instance_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbAirports", t => t.Airport_Id, cascadeDelete: false)
                .ForeignKey("dbo.DbInstances", t => t.Instance_Id, cascadeDelete: true)
                .Index(t => t.Airport_Id)
                .Index(t => t.Instance_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbFuelPrices", "Instance_Id", "dbo.DbInstances");
            DropForeignKey("dbo.DbFuelPrices", "Airport_Id", "dbo.DbAirports");
            DropIndex("dbo.DbFuelPrices", new[] { "Instance_Id" });
            DropIndex("dbo.DbFuelPrices", new[] { "Airport_Id" });
            DropTable("dbo.DbFuelPrices");
        }
    }
}
