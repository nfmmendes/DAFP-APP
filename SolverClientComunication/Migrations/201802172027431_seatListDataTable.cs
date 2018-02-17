namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seatListDataTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbSeats",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        seatClass = c.String(nullable: false),
                        numberOfSeats = c.Int(nullable: false),
                        luggageWeightLimit = c.Double(nullable: false),
                        Airplane_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DbAirplanes", t => t.Airplane_Id, cascadeDelete: true)
                .Index(t => t.Airplane_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbSeats", "Airplane_Id", "dbo.DbAirplanes");
            DropIndex("dbo.DbSeats", new[] { "Airplane_Id" });
            DropTable("dbo.DbSeats");
        }
    }
}
