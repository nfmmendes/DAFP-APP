using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SolverClientComunication.Models;

namespace SolverClientComunication
{
    class SolverInput{
        public DbSet<DbCategories> Categories { get; set; }
        public DbSet<DbAirplane> Airplanes { get; set; }
        public DbSet<DbAirports> Airports { get; set; }
        public DbSet<DbRequests> Requests { get; set; }
        public DbSet<DbParameters> Parameters { get; set; }
        public DbSet<DbStretches> Stretches { get; set; }
        public DbSet<DbReportList> ReportList { get; set; }
        public DbSet<DbGeneralParametersDefault> DefaultParameters { get; set; }
        public DbSet<DbImportErrors> ImportErrors { get; set; }
        public DbSet<DbSeats> SeatList { get; set; }
        public DbSet<DbFuelPrice> FuelPrice { get; set; }
        public DbSet<DbExchangeRates> Exchange { get; set; }

        public DbInstance Instances { get; set; }

        public static SolverInput BuildSolverInput(DbInstance instance) {
            return new SolverInput();
        }

    }
}
