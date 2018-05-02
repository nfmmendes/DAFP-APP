using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolutionData;
using Solver.SolutionData;
using SolverClientComunication;
using SolverClientComunication.Models;
using GreedyStrategy = Solver.Heuristics.ConstructiveHeuristic.GreedyStrategie;

namespace Solver.Heuristics
{
    public class MainHeuristic : AbstractHeuristic
    {

        protected override double EvaluateSolution(GeneralSolution solution){
            return 0; 

        }

        public override void Execute()
        {
            GeneralSolution currentSolution = new GeneralSolution();


            /*      Uncoment it
            var constructHeur1 = new ConstructiveHeuristic(Input, true,GreedyStrategy.MostRequestedOrigin);
            constructHeur1.Execute();
            var firstSolution = constructHeur1.BestSolution;
            currentSolution = DeterministicLocalSearch(firstSolution);
            UpdateBestSolution(currentSolution);

            var constructHeur2 = new ConstructiveHeuristic(Input,true,GreedyStrategy.MostRequestedDestination);

            var secondSolution = constructHeur2.BestSolution;
            currentSolution = DeterministicLocalSearch(secondSolution);
            UpdateBestSolution(currentSolution);

            var constructHeur3 = new ConstructiveHeuristic(Input,true,GreedyStrategy.EarlierRequests);

            var thirdSolution = constructHeur3.BestSolution;
            currentSolution = DeterministicLocalSearch(thirdSolution);
            UpdateBestSolution(currentSolution);
            */
            var constructHeur1 = new ConstructiveHeuristic(Input, true, GreedyStrategy.MostRequestedOrigin);
            constructHeur1.Execute();
            BestSolution = constructHeur1.BestSolution;
          //  BestSolution = DeterministicLocalSearch(BestSolution);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        public GeneralSolution DeterministicLocalSearch(GeneralSolution solution){
            var returnedSolution = new GeneralSolution();

            var timeLimit = Input.OptimizationParameter.TimeLimit;

            Stopwatch sw = new Stopwatch();
            sw.Start();

            var requests = new HashSet<DbRequests>();

            while (sw.Elapsed.TotalSeconds < 240){

                var currentSolution = solution.Clone();
                var flightsByAirplane =currentSolution.Flights.GroupBy(x=>x.Airplanes).ToDictionary(x=>x.Key, x=>x.ToList());
                

                foreach (var flight in currentSolution.Flights)
                    foreach (var passenger in flight.Passengers)
                        requests.Add(passenger);

                var nonSatisfiedRequests = Input.Requests.Where(x => !requests.Contains(x));

                foreach (var airplane in flightsByAirplane.Keys){
                    var flights = flightsByAirplane[airplane];
                    var orderedFlights = flights.OrderBy(x=>x.DepartureTime);

                    if (orderedFlights.Last().Destination.Id == airplane.BaseAirport.Id){
                        var lastFlight = orderedFlights.Last();
                        var lastOrigin = lastFlight.Origin;
                        var lastDeparture = lastFlight.DepartureTime;
                        var lastFuel = lastFlight.FuelOnTakeOff;                         

                        //TODO: Insert logic of "USE_TIME_WINDOWS" parameter here 
                        var possibleNewRequests = nonSatisfiedRequests.Where(x => x.DepartureTimeWindowBegin >GetArrivalTime(lastDeparture,lastOrigin,x.Origin, airplane) );

                        if (possibleNewRequests.Any()){
                            var orderedRequests = possibleNewRequests.OrderBy(x => x.DepartureTimeWindowBegin);
                            var earliest = orderedRequests.First();

                            if (SolverUtils.CanDoInOne(lastDeparture, lastOrigin, earliest.Destination, airplane)){
                                CreateRegularRoute(lastOrigin, earliest.Origin, lastFuel, airplane, lastDeparture, currentSolution, new List<DbRequests>());
                                var arrivalTime = GetArrivalTime(lastDeparture, lastOrigin, earliest.Origin, airplane);

                                var passengers = new List<DbRequests>();
                                CreateRegularRoute(earliest.Origin, earliest.Destination, lastFuel, airplane, lastDeparture, currentSolution, passengers);

                                foreach (var passenger in passengers)
                                    requests.Add(passenger);
                            }
                            

                        }
                    }
                        
                }

            }


            return returnedSolution; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departure"></param>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <param name="airplane"></param>
        /// <returns></returns>
        private TimeSpan GetArrivalTime(TimeSpan departure, DbAirports origin, DbAirports destination, DbAirplanes airplane){

            if(Input.Stretches.ContainsKey(origin))
                if (Input.Stretches[origin].ContainsKey(destination))
                    return departure + TimeSpan.FromHours(Input.Stretches[origin][destination] / (airplane.CruiseSpeed * SolverUtils.KnotsToKmH));

            
            return departure + TimeSpan.FromHours(1000);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solution"></param>
        public void UpdateBestSolution(GeneralSolution solution){
            var currentSolutionValue = EvaluateSolution(solution);

            if (IsMinimization)
                if (currentSolutionValue < BestSolutionValue){
                    BestSolutionValue = currentSolutionValue;
                    BestSolution = solution; 
                }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <param name="fuel">Amount of fuel in Kg</param>
        /// <param name="airplane"></param>
        /// <param name="departure"></param>
        /// <param name="solution"></param>
        /// <param name="passengers"></param>
        /// <returns></returns>
        private bool CreateRegularRoute(DbAirports origin, DbAirports destination, double fuel, DbAirplanes airplane, TimeSpan departure,
                                        GeneralSolution solution, List<DbRequests> passengers)
        {

            var fuelOnLanding = SolverUtils.GetFuelOnLanding(Input, fuel, origin, destination, airplane);

            //TODO: Include more checks  
            if (fuelOnLanding > 0)
            {

                var arrivalTime = SolverUtils.GetArrivalTime(Input, airplane, departure, origin, destination);
                if (arrivalTime < TimeSpan.FromHours(18.25))
                {

                    var newFlight = new Flight()
                    {
                        Airplanes = airplane,
                        DepartureTime = departure,
                        ArrivalTime = arrivalTime,
                        Origin = origin,
                        Destination = destination,
                        FuelOnLanding = fuelOnLanding,
                        FuelOnTakeOff = fuel,
                        Passengers = passengers
                    };
                   
                    var someoneInserted = true;
                    solution.Flights.Add(newFlight);

                    return someoneInserted;
                }
            }
            else
            {

                //If the current airport allows refueling 
                var someoneInserted = false;
                if (Input.FuelPrice.Any(x => x.Airport.Id == origin.Id))
                    someoneInserted = RefuelAndGo(airplane, fuel, origin, destination, solution, departure, passengers);
                else
                    someoneInserted = GoRefuelAndGo(origin, destination, fuel, airplane, departure, solution, passengers);


                return someoneInserted;
            }
            return false;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <param name="fuelOnTakeOff"></param>
        /// <param name="airplane"></param>
        /// <param name="departureTime"></param>
        /// <param name="solution"></param>
        /// <param name="requests"></param>
        /// <returns></returns>
        private bool GoRefuelAndGo(DbAirports origin, DbAirports destination, double fuelOnTakeOff, DbAirplanes airplane,
            TimeSpan departureTime, GeneralSolution solution, List<DbRequests> requests)
        {
            var alternativeRoute = SolverUtils.findStopToFuelAirport(Input, airplane, origin, destination);
            foreach (var airport in alternativeRoute)
            {
                //Fuel after arriving on the intermediary airport
                var firstStep = SolverUtils.GetFuelOnLanding(Input, fuelOnTakeOff, origin, airport, airplane);
                var firstStepArrival = SolverUtils.GetArrivalTime(Input, airplane, departureTime, origin, airport);

                if (firstStepArrival > TimeSpan.FromHours(18.25))
                    return false;

                if (firstStep < 0)
                    continue;

                //Fuel after arriving on the second airport
                var fuelBuyed = SolverUtils.MaxRefuelQuantity(Input, airplane, firstStep, origin, requests);
                var secondStep = SolverUtils.GetFuelOnLanding(Input, firstStep + fuelBuyed, airport, destination, airplane);
                var secondStepArrival = SolverUtils.GetArrivalTime(Input, airplane, firstStepArrival + airport.GroundTime, airport, destination);

                if (secondStepArrival > TimeSpan.FromHours(18.25))
                    return false;

                if (secondStep > 0)
                {
                    var flight1 = new Flight()
                    {
                        Airplanes = airplane,
                        DepartureTime = departureTime,
                        ArrivalTime = firstStepArrival,
                        Origin = origin,
                        Destination = airport,
                        FuelOnLanding = firstStep,
                        FuelOnTakeOff = fuelOnTakeOff,
                        Passengers = requests
                    };

                    var refuel = new Refuel(airport, airplane, firstStepArrival + airport.GroundTime, fuelBuyed, 6);

                    var flight2 = new Flight()
                    {
                        Airplanes = airplane,
                        DepartureTime = firstStepArrival + airport.GroundTime,
                        ArrivalTime = secondStepArrival,
                        Origin = airport,
                        Destination = destination,
                        FuelOnLanding = secondStep,
                        FuelOnTakeOff = firstStep + fuelBuyed,
                        Passengers = requests
                    };

                    solution.Flights.Add(flight1);
                    solution.Flights.Add(flight2);
                    solution.Refuels.Add(refuel);
                }
                else{
                    return RefuelAndGo(airplane, firstStep, airport, destination, solution, firstStepArrival + airport.GroundTime, requests);
                }
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="airplanes"></param>
        /// <param name="fuelOnTank"></param>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <param name="solution"></param>
        /// <param name="departureTime"></param>
        /// <param name="requests"></param>
        /// <returns></returns>
        private bool RefuelAndGo(DbAirplanes airplanes, double fuelOnTank, DbAirports origin, DbAirports destination,
                              GeneralSolution solution, TimeSpan departureTime, List<DbRequests> requests)
        {

            var arrivalTime = SolverUtils.GetArrivalTime(Input, airplanes, departureTime, origin, destination);

            if (arrivalTime > TimeSpan.FromHours(18.25))
                return false;

            var maxRefuelQuantity = SolverUtils.MaxRefuelQuantity(Input, airplanes, fuelOnTank, origin, requests);
            var finalFuel = SolverUtils.GetFuelOnLanding(Input, fuelOnTank + maxRefuelQuantity, origin, destination, airplanes);

            if (finalFuel > 0)
            {

                //TODO: Replace by the real price
                var refuel = new Refuel(origin, airplanes, departureTime, maxRefuelQuantity, 6);

                solution.Refuels.Add(refuel);

                var newFlight = new Flight()
                {
                    Airplanes = airplanes,
                    DepartureTime = departureTime,
                    ArrivalTime = arrivalTime,
                    Origin = origin,
                    Destination = destination,
                    FuelOnTakeOff = fuelOnTank + maxRefuelQuantity,
                    FuelOnLanding = finalFuel,
                    Passengers = requests
                };

                solution.Flights.Add(newFlight);
                return true;
            }else{
                GoRefuelAndGo(origin, destination, fuelOnTank + maxRefuelQuantity, airplanes, departureTime, solution, requests);
            }
            return false;
        }


        public MainHeuristic(SolverInput input, bool isMinimization) : base(input, isMinimization){
        }
    }
}
