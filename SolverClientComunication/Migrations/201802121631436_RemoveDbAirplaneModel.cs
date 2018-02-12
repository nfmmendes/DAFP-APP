namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDbAirplaneModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DbAirplanes", "Model_Id", "dbo.DbAirplaneModels");
            DropIndex("dbo.DbAirplanes", new[] { "Model_Id" });
            AddColumn("dbo.DbAirplanes", "Model", c => c.String());
            DropColumn("dbo.DbAirplanes", "Model_Id");
            DropTable("dbo.DbAirplaneModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DbAirplaneModels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Code = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DbAirplanes", "Model_Id", c => c.Long(nullable: false));
            DropColumn("dbo.DbAirplanes", "Model");
            CreateIndex("dbo.DbAirplanes", "Model_Id");
            AddForeignKey("dbo.DbAirplanes", "Model_Id", "dbo.DbAirplaneModels", "Id", cascadeDelete: true);
        }
    }
}
