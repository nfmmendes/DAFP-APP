using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Solver;
using SolverClientComunication;
using SolverClientComunication.Enums;
using SolverClientComunication.Models;

namespace Solver
{
    public class SolverInput{
        public List<DbAirplanes> Airplanes { get; set; }
        public List<DbAirports> Airports { get; set; }
        public List<DbRequests> Requests { get; set; }
        public List<DbParameters> Parameters { get; set; }
        public Dictionary<DbAirports,Dictionary<DbAirports,double>>  Stretches { get; set; } //< Origin, destination, distance
        //public List<DbReportList> ReportList { get; set; }
        public List<DbGeneralParametersDefault> DefaultParameters { get; set; }
        public OptimizationParameters OptimizationParameter { get; set;  }
        //public List<DbImportErrors> ImportErrors { get; set; }
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
            input.Parameters = context.Parameters.Where(x => x.Instance.Id == Instance.Id).ToList();
            input.SeatList = context.SeatList.Where(x => x.Airplanes.Instance.Id == Instance.Id).ToList();
            input.FuelPrice = context.FuelPrice.Where(x => x.Instance.Id == Instance.Id).ToList();
            input.Exchange = context.Exchange.Where(x => x.Instance.Id == Instance.Id).ToList();
            input.DefaultParameters = context.DefaultParameters.ToList();
           
           
            //Setting the optimization parameters 
            var instanceOptimizationParameters = context.Parameters.Where(x=>x.Instance.Id == Instance.Id).ToList();
            var comeBackToDepot = instanceOptimizationParameters.FirstOrDefault(x=>x.Code.Equals(ParametersEnum.COME_BACK_TO_DEPOT.DbCode));
            var deliveryAll = instanceOptimizationParameters.FirstOrDefault(x => x.Code.Equals(ParametersEnum.DELIVER_ALL.DbCode));
            var pickAll = instanceOptimizationParameters.FirstOrDefault(x => x.Code.Equals(ParametersEnum.PICK_ALL.DbCode));
            var startFromDepot = instanceOptimizationParameters.FirstOrDefault(x => x.Code.Equals(ParametersEnum.START_FROM_DEPOT.DbCode));
            var useTimeWindows = instanceOptimizationParameters.FirstOrDefault(x => x.Code.Equals(ParametersEnum.USE_TIME_WINDOWS.DbCode));
            var timeLimit = instanceOptimizationParameters.FirstOrDefault(x => x.Code.Equals(ParametersEnum.TIME_LIMIT.DbCode));
            var menAverageWeight = instanceOptimizationParameters.FirstOrDefault(x => x.Code.Equals(ParametersEnum.AVERAGE_MEN_WEIGHT.DbCode));
            var womenAverageWeight = instanceOptimizationParameters.FirstOrDefault(x=> x.Code.Equals(ParametersEnum.AVERAGE_WOMEN_WEIGHT.DbCode));
            var kidsAverageWeight = instanceOptimizationParameters.FirstOrDefault(x =>x.Code.Equals(ParametersEnum.AVERAGE_CHILDREN_WEIGHT.DbCode));

            input.OptimizationParameter = new OptimizationParameters();
            input.OptimizationParameter.ComeBackToDepot = comeBackToDepot == null || (comeBackToDepot.Value == "true"? true : false); 
               
            input.OptimizationParameter.DeliverAll = deliveryAll == null || (deliveryAll.Value == "true"? true: false);
            input.OptimizationParameter.PickUpAll = pickAll == null || (pickAll.Value == "true" ? true : false);
            input.OptimizationParameter.StartFromDepot = startFromDepot == null || (startFromDepot.Value == "true" ? true : false);
            input.OptimizationParameter.UseTimeWindows = useTimeWindows == null || (useTimeWindows.Value == "true" ? true : false);
            input.OptimizationParameter.TimeLimit = timeLimit != null ? Convert.ToInt32(timeLimit.Value): 500; 
            input.OptimizationParameter.AverageChildWeight = kidsAverageWeight != null ? Convert.ToInt32(kidsAverageWeight.Value) : 30;
            input.OptimizationParameter.AverageManWeight = menAverageWeight != null ? Convert.ToInt32(menAverageWeight.Value) : 75;
            input.OptimizationParameter.AverageWomanWeight = womenAverageWeight != null ? Convert.ToInt32(womenAverageWeight.Value) : 30;

            input.Stretches = new Dictionary<DbAirports, Dictionary<DbAirports, double>>();
            var stretchesOfInstance = context.Stretches.Where(x => x.Origin.Instance.Id == Instance.Id);
            foreach (var stretch in stretchesOfInstance){
               // if (stretch.Origin != null && stretch.Destination != null){
                    if (!input.Stretches.ContainsKey(stretch.Origin))
                        input.Stretches[stretch.Origin] = new Dictionary<DbAirports, double>();

                    input.Stretches[stretch.Origin][stretch.Destination] = stretch.Distance;
               // }
            }

            return input;
        }
    }
}
