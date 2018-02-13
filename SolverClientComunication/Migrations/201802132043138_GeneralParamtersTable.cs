namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GeneralParamtersTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbGeneralParametersDefaults",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                        Value = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbGeneralParametersDefaults");
        }
    }
}
