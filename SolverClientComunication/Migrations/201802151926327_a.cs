namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DbParameters", "Instance_Id", "dbo.DbInstances");
            DropIndex("dbo.DbParameters", new[] { "Instance_Id" });
            RenameColumn(table: "dbo.DbStretches", name: "Departure_Id", newName: "Destination_Id");
            RenameIndex(table: "dbo.DbStretches", name: "IX_Departure_Id", newName: "IX_Destination_Id");
            AlterColumn("dbo.DbParameters", "Instance_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.DbParameters", "Instance_Id");
            AddForeignKey("dbo.DbParameters", "Instance_Id", "dbo.DbInstances", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbParameters", "Instance_Id", "dbo.DbInstances");
            DropIndex("dbo.DbParameters", new[] { "Instance_Id" });
            AlterColumn("dbo.DbParameters", "Instance_Id", c => c.Long());
            RenameIndex(table: "dbo.DbStretches", name: "IX_Destination_Id", newName: "IX_Departure_Id");
            RenameColumn(table: "dbo.DbStretches", name: "Destination_Id", newName: "Departure_Id");
            CreateIndex("dbo.DbParameters", "Instance_Id");
            AddForeignKey("dbo.DbParameters", "Instance_Id", "dbo.DbInstances", "Id");
        }
    }
}
