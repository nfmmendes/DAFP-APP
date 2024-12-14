using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Common;
using SolutionData;
using Solver.SolutionData;
using SolverClientComunication.Enums;
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

            Stopwatch sw = new Stopwatch();
            sw.Start();
            var constructHeur1 = new ConstructiveHeuristic(Input, true, GreedyStrategy.MostRequestedOrigin);
            constructHeur1.Execute();
            BestSolution = constructHeur1.BestSolution;

            if (BestSolution.Flights.None())
                return;

            var timeLimitCode = ParametersEnum.TIME_LIMIT.DbCode;
            var maxTime = Input.Parameters.Any(x=>x.Code.Equals(timeLimitCode)) ? Convert.ToInt32(Input.Parameters.First(x => x.Code.Equals(timeLimitCode)).Value):5;
            maxTime *= 60;
            var grouped = BestSolution.Flights.GroupBy(x => x.Airplanes).ToDictionary(x => x.Key, x => x.ToList());
            
            while (sw.Elapsed.TotalSeconds < maxTime ){
                  BestSolution = NewFlightOnEndLocalSearch(BestSolution);
                  grouped = BestSolution.Flights.GroupBy(x => x.Airplanes).ToDictionary(x => x.Key, x => x.ToList());
                  BestSolution = TravelsWithStopLocalSearch(BestSolution);
                  grouped = BestSolution.Flights.GroupBy(x => x.Airplanes).ToDictionary(x => x.Key, x => x.ToList());
                  BestSolution = StartLateTripLocalSearch(BestSolution);
                  grouped = BestSolution.Flights.GroupBy(x => x.Airplanes).ToDictionary(x => x.Key, x => x.ToList());
                  BestSolution = LateComeBackLocalSearch(BestSolution);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        private GeneralSolution StartLateTripLocalSearch(GeneralSolution solution){

            var remainingRequests = new List<DbRequest>();
            var currentSolution = solution.Clone();

            var allPassengers = solution.Flights.SelectMany(x => x.Passengers).Distinct().ToList();

            remainingRequests = Input.Requests.Where(x => allPassengers.Count(y => y.Id == x.Id) == 0).ToList();

            foreach (var request in remainingRequests){
                //Late departure upper bound
                var maxLateness = TimeSpan.FromHours(2);
                var candidateFlights = currentSolution.Flights.Where(x=>x.Origin.Id == request.Origin.Id && 
                                                                        request.Destination.Id == x.Destination.Id && 
                                                                        x.DepartureTime > request.DepartureTimeWindowBegin && 
                                                                        request.DepartureTimeWindowEnd + maxLateness > x.DepartureTime );
                if (candidateFlights.None())
                    continue;

                
                var orderedFlights = candidateFlights.OrderBy(x=>x.DepartureTime);
                    
                var first = orderedFlights.FirstOrDefault(x => !x.IsFull && 
                                                                SolverUtils.GetRequestWeight(Input, x.Airplanes,new List<DbRequest>(){request}) < x.Airplanes.MaxWeight);

                if(first!= null)
                    currentSolution.Flights.First(x=>x.Equals(first)).Passengers.Add(request);
            }


            return currentSolution.Clone();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        private GeneralSolution LateComeBackLocalSearch(GeneralSolution solution)
        {
            var remainingRequests = new List<DbRequest>();
            var currentSolution = solution.Clone();

            var allPassengers = solution.Flights.SelectMany(x => x.Passengers).Distinct().ToList();

            remainingRequests = Input.Requests.Where(x => allPassengers.Count(y => y.Id == x.Id) == 0).ToList();

            var flightsByAirplane = currentSolution.Flights.GroupBy(x=>x.Airplanes).ToDictionary(x=>x.Key, x=>x.ToList());

            foreach (var item in flightsByAirplane) { 
                var lastFlight = item.Value.OrderBy(x=>x.ArrivalTime).Last();

                if (lastFlight.Passengers.Any())
                    continue;

                
                var requestCandidates = remainingRequests.Where(x => x.ArrivalTimeWindowEnd > lastFlight.DepartureTime && //Just to don't generate long delays
                                                                        x.Origin.Id == lastFlight.Origin.Id &&
                                                                        x.Destination.Id == lastFlight.Destination.Id);

                if(requestCandidates.None())
                    continue;

                var firstRequest = requestCandidates.OrderBy(x=>x.ArrivalTimeWindowBegin).FirstOrDefault();
                var finalRequests = requestCandidates.Where(x=>x.DepartureTimeWindowBegin < firstRequest.DepartureTimeWindowEnd).ToList();

                var oldDeparture = lastFlight.DepartureTime;
                var newDeparture = firstRequest.DepartureTimeWindowBegin;

                currentSolution.Flights.First(x => x.Id == lastFlight.Id).DepartureTime = newDeparture;
                currentSolution.Flights.First(x => x.Id == lastFlight.Id).ArrivalTime += (newDeparture - oldDeparture);

                if (finalRequests.Count() < lastFlight.Airplanes.Capacity) { 
                    currentSolution.Flights.First(x => x.Id == lastFlight.Id).Passengers.AddRange(finalRequests);
                            
                }else{
                    var inserted= new List<DbRequest>();
                    for(int i=0; i < lastFlight.Airplanes.Capacity;i++)
                        inserted.Add(finalRequests[i]);
                    currentSolution.Flights.First(x => x.Id == lastFlight.Id).Passengers.AddRange(inserted);
                }
;           }

            return currentSolution.Clone();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bestSolution"></param>
        /// <returns></returns>
        private GeneralSolution TravelsWithStopLocalSearch(GeneralSolution solution){
            var returnedSolution = new GeneralSolution();


            var remainingRequests = new List<DbRequest>();
            var currentSolution = solution.Clone();

            var allPassengers = solution.Flights.SelectMany(x => x.Passengers).Distinct().ToList();

            remainingRequests = Input.Requests.Where(x => allPassengers.Count(y => y.Id == x.Id) == 0).ToList();
            var insertedRequets = new List<DbRequest>();

            var maxLateness = TimeSpan.FromHours(1);
            foreach (var request in remainingRequests){

                if (insertedRequets.Contains(request))
                    continue;
                var flightCandidates = solution.Flights.Where(x => x.DepartureTime > request.DepartureTimeWindowBegin &&
                                                                   request.DepartureTimeWindowEnd + maxLateness > x.DepartureTime && 
                                                                   x.Origin.Id == request.Origin.Id);

                var flightsByAirplane = flightCandidates.GroupBy(x=>x.Airplanes).ToDictionary(x=>x.Key, x=>x.ToList());

                foreach (var airplane in flightsByAirplane.Keys){

                    if (insertedRequets.Contains(request))
                        continue;

                    var flights = flightsByAirplane[airplane].OrderBy(x=>x.DepartureTime);

                    if (!flights.Any(x => x.Destination.Id == request.Destination.Id && x.DepartureTime > request.DepartureTimeWindowBegin &&
                                                                                        request.DepartureTimeWindowEnd + maxLateness > x.DepartureTime))
                        continue;

                    var listOfFlights = new List<Flight>();
                    var currentFlight = flights.First(x => x.DepartureTime > request.DepartureTimeWindowBegin);
                    while (true){
                        listOfFlights.Add(currentFlight);

                        if (currentFlight.Destination.Id == request.Destination.Id)
                            break;

                        currentFlight = flights.FirstOrDefault(x => x.DepartureTime > currentFlight.ArrivalTime);
                        if (currentFlight == null)
                            break;

                        //Avoid cycles 
                        if (currentFlight.Destination.Id == request.Origin.Id)
                            break; 

                        var amountOfFuel = currentFlight.FuelOnTakeOff*SolverUtils.PoundsToKg;
                        var passengersWeight = SolverUtils.GetRequestWeight(Input, airplane, currentFlight.Passengers);

                        var weightOfNewPassenger = SolverUtils.GetRequestWeight(Input, airplane, new List<DbRequest>(){request});
                        var totalWeight = weightOfNewPassenger + passengersWeight + amountOfFuel + airplane.Weight;

                        if (totalWeight > SolverUtils.GetMaxWeight(currentFlight.Origin, airplane))
                            break;
                    }

                    if (currentFlight != null && currentFlight.Destination.Id == request.Destination.Id){
                        foreach (var flight in listOfFlights)
                            currentSolution.Flights.First(x => x.Equals(flight)).Passengers.Add(request);
                      //  currentSolution.Flights.First(x => x.Equals(currentFlight)).Passengers.Add(request);

                        insertedRequets.Add(request);
                    }
                }   

            }

            returnedSolution = currentSolution.Clone();
            return returnedSolution;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solution"></param>
        /// <returns></returns>
        public GeneralSolution NewFlightOnEndLocalSearch(GeneralSolution solution){
            var returnedSolution = new GeneralSolution();
            var currentSolution = solution.Clone();
                    
            var flightsByAirplane =currentSolution.Flights.GroupBy(x=>x.Airplanes).ToDictionary(x=>x.Key, x=>x.ToList());
            var requests = currentSolution.Flights.SelectMany(x => x.Passengers).Distinct().ToHashSet();

            var nonSatisfiedRequests = Input.Requests.Where(x => requests.Count(y => y.Id == x.Id) == 0).ToList();

            foreach (var airplane in flightsByAirplane.Keys)
            {
                var flights = flightsByAirplane[airplane];
                var orderedFlights = flights.OrderBy(x => x.DepartureTime);

                if (orderedFlights.Last().Destination.Id != airplane.BaseAirport.Id)
                {
                    continue;
                }
                var lastFlight = orderedFlights.Last();
                var lastOrigin = lastFlight.Origin;
                var lastDeparture = lastFlight.DepartureTime;
                var lastFuel = lastFlight.FuelOnTakeOff;

                //TODO: Insert logic of "USE_TIME_WINDOWS" parameter here 
                var possibleNewRequests = nonSatisfiedRequests.Where(x => x.DepartureTimeWindowBegin > GetArrivalTime(lastDeparture, lastOrigin, x.Origin, airplane));

                //PROCEED A CHANGE IN THE ROUTE. INSTEAD OF GOING TO THE DEPOT, THE AIRPLANE WILL DO ANOTHER TRAVEL TO PICK UP PEOPLE IN AN ORIGIN AND DELIVER 
                //THEM IN A DESTINATION AND JUST AFTER THAT GO TO DEPOT. IN THIS SENSE, ONE FLIGHT WILL BECOME THREE (OR MORE IF IT'S NEEDED TO PROCEED STOPS). 
                if (possibleNewRequests.None())
                {
                    continue;
                }
                var orderedRequests = possibleNewRequests.OrderBy(x => x.DepartureTimeWindowBegin);
                var earliest = orderedRequests.First();

                if (!SolverUtils.CanMakeItInOne(Input, lastDeparture, lastOrigin, earliest.Origin, earliest.Destination, airplane))
                {
                    continue;
                }

                currentSolution.Flights.Remove(lastFlight);

                if (nonSatisfiedRequests.Any(x => x.Id == earliest.Id))
                    nonSatisfiedRequests.Remove(nonSatisfiedRequests.First(x => x.Id == earliest.Id));

                //PROCEED THE FIRST FLIGHT, BASED ON THE CURRENT STATE OF AIRPLANE IN THE LAST ORIGIN
                CreateRegularRoute(lastOrigin, earliest.Origin, lastFuel, airplane, lastDeparture, currentSolution, new List<DbRequest>());


                //PROCEED THE SECOND FLIGHT, AFTER THE AIRPLANE ARRIVES IN THE ORIGIN OF THE REQUEST 
                var arrivalTime = GetArrivalTime(lastDeparture, lastOrigin, earliest.Origin, airplane);
                var fuelOnLanding = SolverUtils.GetFuelOnLanding(Input, lastFuel, lastOrigin, earliest.Origin, airplane);

                var minTakeOffTime = arrivalTime + earliest.Origin.GroundTime;
                var minDeparture = minTakeOffTime > earliest.DepartureTimeWindowBegin ? minTakeOffTime : earliest.DepartureTimeWindowBegin;

                var passengers = nonSatisfiedRequests.Where(x => x.PNR.Equals(earliest.PNR)).ToList();

                if (passengers.Count > airplane.Capacity)
                    passengers.RemoveRange((int)airplane.Capacity, passengers.Count - (int)airplane.Capacity);

                CreateRegularRoute(earliest.Origin, earliest.Destination, fuelOnLanding, airplane, minDeparture, currentSolution, passengers);

                foreach (var passenger in passengers)
                    nonSatisfiedRequests.Remove(passenger);


                //PROCEED THE LAST FLIGHT, GOING BACK TO DEPOT 
                arrivalTime = GetArrivalTime(minDeparture, earliest.Origin, earliest.Destination, airplane);
                fuelOnLanding = SolverUtils.GetFuelOnLanding(Input, fuelOnLanding, earliest.Origin, earliest.Destination, airplane);

                minTakeOffTime = arrivalTime + earliest.Destination.GroundTime;
                CreateRegularRoute(earliest.Destination, airplane.BaseAirport, fuelOnLanding, airplane, minTakeOffTime, currentSolution, new List<DbRequest>());

            }

            returnedSolution = currentSolution.Clone();
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
        private TimeSpan GetArrivalTime(TimeSpan departure, DbAirport origin, DbAirport destination, DbAirplane airplane){

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
        private bool CreateRegularRoute(DbAirport origin, DbAirport destination, double fuel, DbAirplane airplane, TimeSpan departure,
                                        GeneralSolution solution, List<DbRequest> passengers)
        {

            var fuelOnLanding = SolverUtils.GetFuelOnLanding(Input, fuel, origin, destination, airplane);

            //TODO: Include more checks  
            if (fuelOnLanding > 0){

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
        private bool GoRefuelAndGo(DbAirport origin, DbAirport destination, double fuelOnTakeOff, DbAirplane airplane,
            TimeSpan departureTime, GeneralSolution solution, List<DbRequest> requests)
        {
            var alternativeRoute = SolverUtils.FindStopToFuelAirport(Input, airplane, origin, destination);
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
                var fuelBuyed = airplane.MaxRefuelQuantity(Input, firstStep, origin, requests);
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
        private bool RefuelAndGo(DbAirplane airplanes, double fuelOnTank, DbAirport origin, DbAirport destination,
                              GeneralSolution solution, TimeSpan departureTime, List<DbRequest> requests)
        {

            var arrivalTime = SolverUtils.GetArrivalTime(Input, airplanes, departureTime, origin, destination);

            if (arrivalTime > TimeSpan.FromHours(18.25))
                return false;

            var maxRefuelQuantity = airplanes.MaxRefuelQuantity(Input, fuelOnTank, origin, requests);
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
