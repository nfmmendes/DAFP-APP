using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solver.SolutionData;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1.Controller
{
    class HeuristicSolutionController
    {
        private CustomSqlContext Context { get; set; }
        public static readonly HeuristicSolutionController Instance = new HeuristicSolutionController();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void setContext(CustomSqlContext context)
        {
            Instance.Context = context;
        }

        public void SaveResults(DbInstance instance, GeneralSolution solution)
        {

            Instance.Context.PassagersOnFlight.RemoveRange(Instance.Context.PassagersOnFlight.Where(x=>x.Flight.Instance.Id == instance.Id));
            Instance.Context.SaveChanges();
            Instance.Context.FlightsReports.RemoveRange(Instance.Context.FlightsReports.Where(x => x.Instance.Id == instance.Id));
            Instance.Context.SaveChanges();

            foreach (var flight in solution.Flights)
            {
                var report = new DbFlightsReport(){
                    Origin = flight.Origin,
                    Destination = flight.Destination,
                    DepartureTime = flight.DepartureTime,
                    ArrivalTime = flight.ArrivalTime,
                    Airplanes = flight.Airplanes,
                    FuelOnArrival = flight.FuelOnLanding,
                    FuelOnDeparture = flight.FuelOnTakeOff,
                    Instance = instance
                };

                Instance.Context.FlightsReports.Add(report);

                foreach (var passenger in flight.Passengers){
                    var dbPassenger = new DbPassagensOnFlightReport()
                    {
                        Flight = report,
                        Passenger = passenger
                    };
                    Instance.Context.PassagersOnFlight.Add(dbPassenger);
                
                }
                Instance.Context.SaveChanges();
            }

            foreach (var refuel in solution.Refuels){
                var item = new DbRefuelsReport(){
                                Instance  = instance,
                                Airport =  refuel.Airport,
                                Airplanes = refuel.Airplanes,
                                Amount = refuel.Amount,
                                RefuelTime = refuel.RefuelTime
                          };

                Instance.Context.RefuelsReport.Add(item);

            }
            Instance.Context.SaveChanges();
        }
    }
}
