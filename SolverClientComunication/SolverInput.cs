using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SolverClientComunication.Models;

namespace SolverClientComunication
{
    public class SolverInput{
        public List<DbAirplane> Airplanes { get; set; }
        public List<DbAirports> Airports { get; set; }
        public List<DbRequests> Requests { get; set; }
        public List<DbParameters> Parameters { get; set; }
        public List<DbStretches> Stretches { get; set; }
        public List<DbReportList> ReportList { get; set; }
        public List<DbGeneralParametersDefault> DefaultParameters { get; set; }
        public List<DbImportErrors> ImportErrors { get; set; }
        public List<DbSeats> SeatList { get; set; }
        public List<DbFuelPrice> FuelPrice { get; set; }
        public List<DbExchangeRates> Exchange { get; set; }

        public DbInstance Instance { get; set; }

        private SolverInput() { }

        public static SolverInput BuildSolverInput(CustomSqlContext context,DbInstance instance){
            var Instance = instance;
            var input = new SolverInput();
            input.Airplanes = context.Airplanes.Where(x=>x.Instance.Id == Instance.Id).ToList();
            input.Airports = context.Airports.Where(x => x.Instance.Id == Instance.Id).ToList();
            input.Requests = context.Requests.Where(x => x.Instance.Id == Instance.Id).ToList();
            input.Stretches = context.Stretches.Where(x => x.Origin.Instance.Id == Instance.Id).ToList();
            input.Parameters = context.Parameters.Where(x => x.Instance.Id == Instance.Id).ToList();
            input.SeatList = context.SeatList.Where(x => x.Airplane.Instance.Id == Instance.Id).ToList();
            input.FuelPrice = context.FuelPrice.Where(x => x.Instance.Id == Instance.Id).ToList();
            input.Exchange = context.Exchange.Where(x => x.Instance.Id == Instance.Id).ToList();

            return input;
        }

    }
}
