using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolutionData;
using Solver.SolutionData;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Solver.Heuristics
{
    public class ConstructiveHeuristic : AbstractHeuristic
    {
        public enum GreedyStrategie { MostRequestedOrigin, MostRequestedDestination, EarlierRequests}

        public GreedyStrategie Strategie { get; set; }
        private List<DbRequests> requestsAlreadyBoardedOnOrigin { get; set; }
        private List<DbRequests> requestsAlreadyFinished { get; set; }
        private List<DbRequests> requestsWithMandatoryStop { get; set; }
        private List<DbRequests> requestsWithMandatorySplit { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        protected override double EvaluateSolution(GeneralSolution solution){
            throw new NotImplementedException();
        }

        /// <summary>
        /// Function that controls all the heuristic execution, directly or indirectly
        /// </summary>
        public override void Execute()
        {
            requestsAlreadyBoardedOnOrigin = new List<DbRequests>();
            requestsAlreadyFinished = new List<DbRequests>();

            var maxRange = Input.Airplanes.Max(x => x.Range);
            requestsWithMandatoryStop = Input.Requests.Where(x=> !Input.Stretches.ContainsKey(x.Origin) || !
                                                                  Input.Stretches[x.Origin].ContainsKey(x.Destination) 
                                                                  || Input.Stretches[x.Origin][x.Destination] > maxRange).ToList();

            var maxCapacityByClass = Input.SeatList.GroupBy(x=>x.seatClass).ToDictionary(x=>x.Key, x=>x.Max(y=>y.numberOfSeats));
            var maxTotalCapacity = Input.Airplanes.Max(x => x.Capacity);
            var numRequestsByPNR = Input.Requests.GroupBy(x => x.PNR).ToDictionary(x => x.Key, x => x.ToList().Count);
            
            //TODO: Include the classes on this query
            requestsWithMandatorySplit = Input.Requests.Where(x => numRequestsByPNR[x.PNR] > maxTotalCapacity).ToList();

            if (Strategie == GreedyStrategie.MostRequestedOrigin){
                BestSolution = DoMostRequestedOriginStrategy();
            }else if (Strategie == GreedyStrategie.EarlierRequests){
                BestSolution = DoEarlierRequests();
            }else if (Strategie == GreedyStrategie.MostRequestedDestination){
                BestSolution = DoMostRequestedDestinatio();
            }
            
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private GeneralSolution DoMostRequestedDestinatio()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private GeneralSolution DoEarlierRequests()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="isMinimization"></param>
        /// <param name="strategie"></param>
        public ConstructiveHeuristic(SolverInput input, bool isMinimization, GreedyStrategie strategie) 
            : base(input, isMinimization){

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private GeneralSolution DoMostRequestedOriginStrategy(){

            var solution = new GeneralSolution();

            var requests = Input.Requests;
            var requestsByOrigin = requests.GroupBy(x => x.Origin).ToDictionary(x => x.Key, x => x.ToList());
            

            var numberOfPassengersByAirport = new Dictionary<DbAirports, int>(); 
            foreach (var key in requestsByOrigin.Keys){
                numberOfPassengersByAirport[key] = requestsByOrigin[key].Count;
            }

            var orderedNumberOfPassagensByAirport = numberOfPassengersByAirport.OrderBy(x => x.Key).Reverse();
            var firstTakeOff = TimeSpan.FromHours(6.25); //TODO: Put it as a parameter. Now it's considered as the sun rise hour

            bool someoneInserted = true;

            while (someoneInserted){
                someoneInserted = false;

                foreach (var element in numberOfPassengersByAirport){
                    var aiportRequestsByRPN = requestsByOrigin[element.Key].OrderBy(x=>x.DepartureTimeWindowEnd)
                                                                           .GroupBy(x=>x.PNR).ToDictionary(x=>x.Key, x=>x.ToList());

                    foreach (var requestItem in aiportRequestsByRPN){
                        var airplanes =  SolverUtils.GetCompatibleAirplanes(Input,requestItem.Value);
                        var origin = requestItem.Value.First().Origin; //Same RPN is equals to same origin.
                        var time = requestItem.Value.First().DepartureTimeWindowEnd;

                        var choosen = airplanes.FirstOrDefault(x => SolverUtils.ArrivallFromDepot(Input,x, origin) < time);

                        if (choosen != null){
                            
                            var fuelOnTakeOff = choosen.Model.Contains("PC") ? choosen.BaseAirport.MTOW_PC12 : choosen.BaseAirport.MTOW_APE3;
                            var newFlight = new Flight(){
                                Airplane = choosen,
                                DepartureTime = firstTakeOff,
                                ArrivalTime = SolverUtils.ArrivallFromDepot(Input, choosen, origin),
                                Origin = choosen.BaseAirport,
                                Destination = origin,
                                FuelOnLanding = fuelOnTakeOff,
                                FuelOnTakeOff = SolverUtils.GetFuelOnLanding(fuelOnTakeOff, choosen.BaseAirport, origin, choosen),
                                Passengers = requestItem.Value.ToList()
                            };

                            solution.Flights.Add(newFlight);


                        }
                        

                        //TODO: Insert flight
                    }
                }
            }

            return solution;
        }
    }
}
