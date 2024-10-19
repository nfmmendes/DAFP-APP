using SolverClientComunication.Models;

namespace SolverClientComunication
{

    using Microsoft.EntityFrameworkCore;

    public class CustomSqlContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<DbAirplane> Airplanes { get; set; }
        public DbSet<DbAirport> Airports { get; set; }
        public DbSet<DbRequest> Requests { get; set; }
        public DbSet<DbParameter> Parameters { get; set; }
        public DbSet<DbStretch> Stretches { get; set; }
        public DbSet<DbReportList> ReportList { get; set; }
        public DbSet<DbInstance> Instances { get; set; }
        public DbSet<DbGeneralParametersDefault> DefaultParameters { get; set; }
        public DbSet<DbImportError> ImportErrors { get; set; }
        public DbSet<DbSeat> Seats { get; set; }
        public DbSet<DbFuelPrice> FuelPrices { get; set; }
        public DbSet<DbExchangeRate> ExchangeRates { get; set; }
        public DbSet<DbRefuelsReport> RefuelsReport { get; set; }
        public DbSet<DbFlightsReport> FlightsReports { get; set; }
        public DbSet<DbPassengersOnFlightReport> PassengersOnFlight { get; set; }
        public DbSet<DbOptimizationAlert> OptimizationAlerts { get; set; }

        // Your context has been configured to use a 'CustomSqlContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SolverClientComunication.CustomSqlContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CustomSqlContext' 
        // connection string in the application configuration file.
        public CustomSqlContext()
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Prototipo1;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true", sqlServerOptions => sqlServerOptions.CommandTimeout(60));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TableNameConvention
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
               entity.SetTableName("Db" + entity.GetTableName());
            }
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