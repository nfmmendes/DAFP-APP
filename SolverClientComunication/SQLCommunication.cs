using SolverClientComunication.Models;

namespace SolverClientComunication
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SQLCommunication : DbContext
    {


        public DbSet<DbCategories> DbCategories { get; set; }
        public DbSet<DbCommodities> DbCommodities { get; set; }
        public DbSet<DbAirplane> DbAirplanes { get; set; }
        public DbSet<DbAirports> DbAirports { get; set; }
        public DbSet<DbRequests> DbRequests { get; set; }
        public DbSet<DbParameters> DbParameters { get; set; }
        public DbSet<DbClusterRequests> DbClusterRequests { get; set;  }
        public DbSet<DbStretches> DbStretches { get; set; }
        public DbSet<DbReportList> DbReportList { get; set; }
            
        // Your context has been configured to use a 'SQLCommunication' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SolverClientComunication.SQLCommunication' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SQLCommunication' 
        // connection string in the application configuration file.
        public SQLCommunication()
            : base("name=SQLCommunication")
        {
            
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}