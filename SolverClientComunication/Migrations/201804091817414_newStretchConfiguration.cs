namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newStretchConfiguration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DbStretches", "Destination_Id", "dbo.DbAirports");
            DropForeignKey("dbo.DbStretches", "Origin_Id", "dbo.DbAirports");
            DropIndex("dbo.DbStretches", new[] { "Destination_Id" });
            DropIndex("dbo.DbStretches", new[] { "Origin_Id" });
            AddColumn("dbo.DbStretches", "Origin", c => c.String());
            AddColumn("dbo.DbStretches", "Destination", c => c.String());
            AddColumn("dbo.DbStretches", "InstanceId", c => c.Long(nullable: false));
            DropColumn("dbo.DbStretches", "Destination_Id");
            DropColumn("dbo.DbStretches", "Origin_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbStretches", "Origin_Id", c => c.Long());
            AddColumn("dbo.DbStretches", "Destination_Id", c => c.Long());
            DropColumn("dbo.DbStretches", "InstanceId");
            DropColumn("dbo.DbStretches", "Destination");
            DropColumn("dbo.DbStretches", "Origin");
            CreateIndex("dbo.DbStretches", "Origin_Id");
            CreateIndex("dbo.DbStretches", "Destination_Id");
            AddForeignKey("dbo.DbStretches", "Origin_Id", "dbo.DbAirports", "Id");
            AddForeignKey("dbo.DbStretches", "Destination_Id", "dbo.DbAirports", "Id");
        }
    }
}
