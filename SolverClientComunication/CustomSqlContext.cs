using SolverClientComunication.Models;

namespace SolverClientComunication
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CustomSqlContext : DbContext
    {


        public DbSet<DbCategories> Categories { get; set; }
        public DbSet<DbAirplane> Airplanes { get; set; }
        public DbSet<DbAirports> Airports { get; set; }
        public DbSet<DbRequests> Requests { get; set; }
        public DbSet<DbParameters> Parameters { get; set; }
        public DbSet<DbStretches> Stretches { get; set; }
        public DbSet<DbReportList> ReportList { get; set; }
        public DbSet<DbInstance> Instances { get; set;  }
        public DbSet<DbGeneralParametersDefault> DefaultParameters { get; set; }
        public DbSet<DbImportErrors> ImportErrors { get; set; }
            
        // Your context has been configured to use a 'CustomSqlContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SolverClientComunication.CustomSqlContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CustomSqlContext' 
        // connection string in the application configuration file.
        public CustomSqlContext()
            : base("name=CustomSqlContext")
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