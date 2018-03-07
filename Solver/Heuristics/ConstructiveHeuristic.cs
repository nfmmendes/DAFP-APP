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
        /// Builds a initial solution based on priotizing the airports with bigger 
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

            var orderedNumberOfPassagersByAirport = numberOfPassengersByAirport.OrderBy(x => x.Key).Reverse();
            var firstTakeOff = TimeSpan.FromHours(6.25); //TODO: Put it as a parameter. Now it's considered as the sun rise hour

            bool someoneInserted = true;

            while (someoneInserted){
                someoneInserted = false;

                foreach (var element in numberOfPassengersByAirport){
                    var airportRequestsByRPN = requestsByOrigin[element.Key].OrderBy(x=>x.DepartureTimeWindowEnd)
                                                                           .GroupBy(x=>x.PNR).ToDictionary(x=>x.Key, x=>x.ToList());

                    foreach (var requestItem in airportRequestsByRPN){
                        var airplanes =  SolverUtils.GetCompatibleAirplanes(Input,requestItem.Value);
                        var origin = requestItem.Value.First().Origin; //Same RPN is equals to same origin.
                        var destination = requestItem.Value.First().Destination; //Same RPN is equals to same origin.
                        var time = requestItem.Value.First().DepartureTimeWindowEnd;

                        var choosenAirplane = airplanes.FirstOrDefault(x => SolverUtils.ArrivallFromDepot(Input,x, origin) < time);

                        if (choosenAirplane != null){
                            
                            //Fills with the data about the flight from depot to the first origin
                            double fuelOnTakeOff = choosenAirplane.Model.Contains("PC") ? choosenAirplane.BaseAirport.MTOW_PC12 : choosenAirplane.BaseAirport.MTOW_APE3;
                            double fuelOnLanding = SolverUtils.GetFuelOnLanding(Input, fuelOnTakeOff, choosenAirplane.BaseAirport, origin, choosenAirplane);
                            TimeSpan arrivalTime = SolverUtils.ArrivallFromDepot(Input, choosenAirplane, origin);

                            //TODO: Eventually the plane will do some stops. Decide if it will allowed in this point
                            if (fuelOnLanding > 0){
                                var newFlight = new Flight(){
                                    Airplane = choosenAirplane,
                                    DepartureTime = firstTakeOff,
                                    ArrivalTime = arrivalTime,
                                    Origin = choosenAirplane.BaseAirport,
                                    Destination = origin,
                                    FuelOnLanding = fuelOnTakeOff,
                                    FuelOnTakeOff = fuelOnLanding,
                                    Passengers = new List<DbRequests>()
                                };

                                solution.Flights.Add(newFlight);
                            }

                            fuelOnTakeOff = fuelOnLanding; 
                            fuelOnLanding = SolverUtils.GetFuelOnLanding(Input, fuelOnTakeOff, origin,destination , choosenAirplane);
                            var departureTime = arrivalTime + origin.GroundTime < requestItem.Value.First().DepartureTimeWindowEnd
                                ? requestItem.Value.First().DepartureTimeWindowEnd : arrivalTime + origin.GroundTime;

                            //TODO: Include more checks  
                            if (fuelOnLanding > 0)
                            {
                                
                                arrivalTime = SolverUtils.GetArrivalTime(Input, choosenAirplane, departureTime, origin,destination);

                                var newFlight = new Flight(){
                                    Airplane = choosenAirplane,
                                    DepartureTime = departureTime,
                                    ArrivalTime = arrivalTime,
                                    Origin = choosenAirplane.BaseAirport,
                                    Destination = origin,
                                    FuelOnLanding = fuelOnTakeOff,
                                    FuelOnTakeOff = fuelOnLanding,
                                    Passengers = new List<DbRequests>()
                                };

                                someoneInserted = true;
                                solution.Flights.Add(newFlight);
                                
                            }else{

                                //IF there was not enough fuel on the airplane to do the trip without a stop, 
                                //it is searched an airport to refueling on the track (or refueled on origin airport)

                                //If the current airport allows refueling 
                                if (Input.FuelPrice.Any(x => x.Airport.Id == origin.Id)){
                                    var weight = choosenAirplane.Weight + fuelOnTakeOff*SolverUtils.PoundsToKg;
                                    var refuel = new Refuel(origin,Math.Min()){
                                        
                                    };

                                    var newFlight = new Flight()
                                    {
                                        Airplane = choosenAirplane,
                                        DepartureTime = departureTime,
                                        ArrivalTime = arrivalTime,
                                        Origin = choosenAirplane.BaseAirport,
                                        Destination = origin,
                                        FuelOnLanding = fuelOnTakeOff,
                                        FuelOnTakeOff = fuelOnLanding,
                                        Passengers = new List<DbRequests>()
                                    };
                                }


                                var alternativeRoute = SolverUtils.findStopToFuelAirport(Input, origin, destination);
                                foreach (var airport in alternativeRoute){
                                    //Fuel after arriving on the intermediary airport
                                    var firstStep = SolverUtils.GetFuelOnLanding(Input, fuelOnTakeOff, origin, airport, choosenAirplane);

                                    if (firstStep < 0)
                                        continue;

                                    //Fuel after arriving on the second airport
                                    var secondStep = SolverUtils.GetFuelOnLanding(Input, firstStep, airport, destination, choosenAirplane);
                                    if (secondStep > 0){
                                        
                                    }

                                }
                            }

                        }
                        

                        //TODO: Insert flight
                    }
                }
            }

            return solution;
        }
    }
}
