namespace SolverClientComunication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequestModifications : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DbRequests", "DepartureTimeWindowBegin", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.DbRequests", "DepartureTimeWindowEnd", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.DbRequests", "ArrivalTimeWindowBegin", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.DbRequests", "ArrivalTimeWindowEnd", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.DbRequests", "TimeOfRequisiton");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbRequests", "TimeOfRequisiton", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DbRequests", "ArrivalTimeWindowEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DbRequests", "ArrivalTimeWindowBegin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DbRequests", "DepartureTimeWindowEnd", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DbRequests", "DepartureTimeWindowBegin", c => c.DateTime(nullable: false));
        }
    }
}
