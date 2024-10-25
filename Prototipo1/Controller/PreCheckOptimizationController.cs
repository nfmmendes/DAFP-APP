using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solver;
using SolverClientComunication;
using SolverClientComunication.Enums;
using SolverClientComunication.Models;

namespace Prototipo1.Controller
{
    class PreCheckOptimizationController : AbstractController<DbOptimizationAlert,CustomSqlContext>{

        private CustomSqlContext Context { get; set; }
        public static readonly PreCheckOptimizationController Instance = new PreCheckOptimizationController();

        /// <summary>
        /// Set the controller context.
        /// </summary>
        /// <param name="context"> The controler context. </param>
        public override void setContext(CustomSqlContext context){
            Instance.Context = context;
        }

        /// <summary>
        /// Add an optimization alert to the pre-optimization warning list.
        /// </summary>
        /// <param name="item">The new alert.</param>
        public override void Add(DbOptimizationAlert item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all the pre-optimization alerts. 
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public List<DbOptimizationAlert> GetWarnings(DbInstance instance){
            return Context.OptimizationAlerts.Where(x=>x.Instance.Id == instance.Id).ToList();
        }

        /// <summary>
        /// Edit an pre-optimization alert.
        /// </summary>
        /// <param name="item">The new item value</param>
        /// <param name="IdItem">The id of the item to be edited</param>
        public override void Edit(DbOptimizationAlert item, long IdItem)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete an optimization alert. 
        /// </summary>
        /// <param name="item">The item to be deleted. </param>
        public override void Delete(DbOptimizationAlert item)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool IsValidItem(DbOptimizationAlert item){
            throw new NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        public void ExecuteCheck(SolverInput input){

            if(Context.OptimizationAlerts.Any(x => x.Instance.Id == input.Instance.Id)) { 
                Context.OptimizationAlerts.RemoveRange(Context.OptimizationAlerts.Where(x=>x.Instance.Id == input.Instance.Id));
                Context.SaveChanges();
            }
            getTooLongFlights(input);
            getNoGroundTimeAirports(input);
            verifyStretchIntegrality(input);
        }

        private void verifyStretchIntegrality(SolverInput input)
        {
            var numAirports = input.Airports.Count;
            var airports = input.Airports;

            foreach (var item in airports){
                if (!input.Stretches.ContainsKey(item)){
                    var alert = new DbOptimizationAlert(){
                        Type = OptimizationAlertTypeEnum.ERROR.DbCode,
                        Table = "Stretches",
                        Message = $"There are no data of the distances from the airport with IATA code {item.IATA}",
                        Instance = input.Instance
                    };

                    Context.OptimizationAlerts.Add(alert);
                }else if (input.Stretches[item].Count < numAirports - 1){
                    var alert = new DbOptimizationAlert(){
                        Type = OptimizationAlertTypeEnum.ERROR.DbCode,
                        Table = "Stretches",
                        Message = $"In this instance is missing data of the distances from the airport with IATA code {item.IATA}",
                        Instance = input.Instance
                    };

                    Context.OptimizationAlerts.Add(alert);
                }

            }
            Context.SaveChanges();
        }

        private void getNoGroundTimeAirports(SolverInput input){
            var airports = input.Airports.Where(x=>x.GroundTime.TotalSeconds < 20);

            foreach (var item in airports){
                var alert = new DbOptimizationAlert(){
                    Type = OptimizationAlertTypeEnum.WARNING.DbCode,
                    Table = "Airplanes",
                    Message = $"The airport with IATA code {item.IATA} has a zero ground time",
                    Instance = input.Instance
                };

                Context.OptimizationAlerts.Add(alert);
            }
            Context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        private void getTooLongFlights(SolverInput input){
            var requests = input.Requests;
            var maxAirplaneSpeed = input.Airplanes.Max(x => x.CruiseSpeed);
            var stretches = input.Stretches;
            HashSet<string> alreadyVerifiedPNR = new HashSet<string>();

            foreach (var item in requests){
                var distance = 0.0;

                if(alreadyVerifiedPNR.Contains(item.PNR))
                    continue;

                alreadyVerifiedPNR.Add(item.PNR);

                if (!stretches.ContainsKey(item.Origin))
                    continue;

                if (!stretches[item.Origin].ContainsKey(item.Destination))
                    continue;

                distance = stretches[item.Origin][item.Destination];
                var time = item.ArrivalTimeWindowEnd - item.DepartureTimeWindowBegin;
                if (time.TotalHours < distance / (maxAirplaneSpeed*1.852)){

                    var alert = new DbOptimizationAlert(){
                        Type = OptimizationAlertTypeEnum.ERROR.DbCode,
                        Table = "Requests",
                        Message = $"The request with PNR {item.PNR} has origin and destination too far to the time windows defined",
                        Instance = input.Instance
                    };

                    Context.OptimizationAlerts.Add(alert);
                }                    
            }
            Context.SaveChanges();
        }
    }
}
