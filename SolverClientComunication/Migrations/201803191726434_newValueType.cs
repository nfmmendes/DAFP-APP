namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newValueType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DbExchangeRates", "ValueInDolar", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DbExchangeRates", "ValueInDolar", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
