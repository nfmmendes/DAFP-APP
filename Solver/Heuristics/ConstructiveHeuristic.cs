using System;
using System.Collections.Generic;
using System.Linq;
using SolutionData;
using Solver.SolutionData;
using SolverClientComunication.Enums;
using SolverClientComunication.Models;

namespace Solver.Heuristics
{
    public class ConstructiveHeuristic : AbstractHeuristic
    {
        public enum GreedyStrategie { MostRequestedOrigin, MostRequestedDestination, EarlierRequests}

        public GreedyStrategie Strategie { get; set; }

        //============== "Global fields" to make the information interchange between the functions easier =============================
        private List<DbRequests> requestsBoardedInOrigin { get; set; }
        private List<DbRequests> requestsAlreadyFinished { get; set; }
        private List<DbRequests> requestsWithMandatoryStop { get; set; }
        private List<DbRequests> requestsWithMandatorySplit { get; set; }

        
        private TimeSpan CurrentAirplaneArrivalTime { get; set; }
        private DbAirports CurrentAirplaneLocation { get; set; }
        private double CurrentFuelAmount { get; set; }

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
            requestsBoardedInOrigin = new List<DbRequests>();
            requestsAlreadyFinished = new List<DbRequests>();

            var maxRange = Input.Airplanes.Max(x => x.Range);
            requestsWithMandatoryStop = Input.Requests.Where(x=> !Input.Stretches.ContainsKey(x.Origin) || !
                                                                  Input.Stretches[x.Origin].ContainsKey(x.Destination) 
                                                                  || Input.Stretches[x.Origin][x.Destination] > maxRange).ToList();


            var maxTotalCapacity = Input.Airplanes.Max(x => x.Capacity);
            var numRequestsByPNR = Input.Requests.GroupBy(x => x.PNR).ToDictionary(x => x.Key, x => x.ToList().Count);
            
            requestsWithMandatorySplit = Input.Requests.Where(x => numRequestsByPNR[x.PNR] > maxTotalCapacity).ToList();

            if (Strategie == GreedyStrategie.MostRequestedOrigin)
            {
                BestSolution = DoMostRequestedOriginStrategy();
            }
            else if (Strategie == GreedyStrategie.EarlierRequests)
            {
                BestSolution = DoEarlierRequests();
            }
            else if (Strategie == GreedyStrategie.MostRequestedDestination)
            {
                BestSolution = DoMostRequestedDestinatio();
            }  
        }

        /// <summary>
        /// Creates a solution based on cosntructive heuristic based on traveling to the more the more frequent destinations
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
            var numberOfPassengersByAirport = requestsByOrigin.ToDictionary(x => x.Key, x => x.Value.Count());
       

            HashSet<DbAirplanes> ExitedFromDepot = new HashSet<DbAirplanes>();

            foreach (var airport in numberOfPassengersByAirport.Keys){
                var sameStretchRequest = requestsByOrigin[airport].GroupBy(x=>x.Destination).ToDictionary(x=>x.Key, x=>x.ToList());
                var airplanesByClosests = SolverUtils.GetAirplanesByProximity(Input, airport); //Get the airplanes ordered by proximity
                    
                foreach (var destination in sameStretchRequest.Keys){
                    var requestsToDestination = sameStretchRequest[destination];
                    var requestsOrdered = requestsToDestination.OrderBy(x=>x.PNR).OrderBy(x=>x.DepartureTimeWindowEnd).ToList();
                    var firstDeparture = requestsToDestination.First(x=>!requestsBoardedInOrigin.Contains(x)).DepartureTimeWindowEnd;

                    var airplane = airplanesByClosests.FirstOrDefault( x => SolverUtils.ArrivallFromDepot(Input, x, airport) < firstDeparture &&
                                                        !ExitedFromDepot.Contains(x) && SolverUtils.CanDoInOneDay(Input, x,airport,destination));

                    while (airplane != null){
                        List<DbRequests> passengersList = new List<DbRequests>();
                        Dictionary<string, int> classBooking = new Dictionary<string, int>();

                        var nobodyInserted = true;
                        if (requestsOrdered.Any(x => !requestsBoardedInOrigin.Contains(x))){
                            var lastDeparture = requestsOrdered.First(x=>!requestsBoardedInOrigin.Contains(x)).DepartureTimeWindowEnd;

                            foreach (var request in requestsOrdered){

                                if (requestsBoardedInOrigin.Contains(request))
                                    continue;

                                if (lastDeparture < request.DepartureTimeWindowBegin)
                                    continue;

                                if (!Input.SeatList.Any(x => x.Airplanes.Id == airplane.Id && x.seatClass.Equals(request.Class)))
                                    continue;
                                if (!classBooking.ContainsKey(request.Class))
                                    classBooking[request.Class] = 0;

                                passengersList.Add(request);
                                if (passengersList.Count > airplane.Capacity)
                                    break;
                                nobodyInserted = false;

                            }

                        }

                        if (nobodyInserted)
                            break;
                        
                        ExitedFromDepot.Add(airplane);
                        if (airplane.BaseAirport.Id != airport.Id)
                            CreatedRouteFromDepot(solution, passengersList, airplane, airport,destination);
                        else{
                            var fuel = SolverUtils.MaxRefuelQuantity(Input, airplane, 0, airport, passengersList);
                            CreateRegularRoute(solution, airport, destination, passengersList.Max(x => x.ArrivalTimeWindowBegin), airplane, fuel,passengersList);
                        }
                                
                        airplane = airplanesByClosests.FirstOrDefault(x =>SolverUtils.ArrivallFromDepot(Input, x, airport) < firstDeparture &&
                                                                     !ExitedFromDepot.Contains(x) && SolverUtils.CanDoInOneDay(Input, x, airport, destination));
                    }
   
                }
            }

            //================================= RETURN TO THE BASE =================================
            foreach (var airplane in solution.Flights.Select(x=>x.Airplanes).Distinct().ToList()){
                var airplaneFlights = solution.Flights.Where(x => x.Airplanes.Id == airplane.Id);

                var lastFlight = airplaneFlights.OrderBy(x => x.ArrivalTime).Last();
                var departureTime = lastFlight.ArrivalTime + lastFlight.Destination.GroundTime;
                CreateRegularRoute(solution, lastFlight.Destination, airplane.BaseAirport, departureTime, airplane, lastFlight.FuelOnLanding,
                     new List<DbRequests>());
            }



            return solution;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solution"></param>
        /// <param name="passengers"></param>
        /// <param name="airplane"></param>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        private bool CreatedRouteFromDepot(GeneralSolution solution, List<DbRequests> passengers, DbAirplanes airplane, DbAirports origin, DbAirports destination){

            //Fills with the data about the flight from depot to the first origin
            double fuelOnTakeOff = airplane.Model.Contains("PC") ? airplane.BaseAirport.MTOW_PC12 : airplane.BaseAirport.MTOW_APE3;
            double fuelOnLanding = SolverUtils.GetFuelOnLanding(Input, fuelOnTakeOff, airplane.BaseAirport, origin, airplane);
            TimeSpan arrivalTime = SolverUtils.ArrivallFromDepot(Input, airplane, origin);

            fuelOnTakeOff *= SolverUtils.PoundsToKg;
            fuelOnLanding *= SolverUtils.PoundsToKg;


            var splitedSunrise = Input.Parameters.First(x => x.Code.Equals(ParametersEnum.SUNRISE_TIME.DbCode)).Value;
            var hour = Convert.ToInt32(splitedSunrise.Split(':')[0]);
            var minute = Convert.ToInt32(splitedSunrise.Split(':')[1]);
            var sunriseTime = TimeSpan.FromHours(hour) + TimeSpan.FromMinutes(minute);

            var firstTakeOff = splitedSunrise.Length > 1 ? TimeSpan.FromHours(Convert.ToInt32(hour) + Convert.ToDouble(minute) / 100) : TimeSpan.MinValue;

            var splitedSunset = Input.Parameters.FirstOrDefault(x => x.Code.Equals(ParametersEnum.SUNSET_TIME.DbCode)).Value;
            hour = Convert.ToInt32(splitedSunset.Split(':')[0]);
            minute = Convert.ToInt32(splitedSunset.Split(':')[1]);
            var sunsetTime = TimeSpan.FromHours(hour) + TimeSpan.FromMinutes(minute);

            

            if (fuelOnLanding > 0){

                if (arrivalTime < sunsetTime){

                    var newFlight = new Flight()
                    {
                        Airplanes = airplane,
                        DepartureTime = firstTakeOff, 
                        ArrivalTime = arrivalTime,
                        Origin = airplane.BaseAirport,
                        Destination = origin,
                        FuelOnLanding = fuelOnLanding,
                        FuelOnTakeOff = fuelOnTakeOff,
                        Passengers = new List<DbRequests>()
                    };
                    solution.Flights.Add(newFlight);

                    var minTakeOffTime = arrivalTime + origin.GroundTime;
                    var minDeparture = minTakeOffTime > passengers.Max(x => x.DepartureTimeWindowBegin)? minTakeOffTime: passengers.Max(x => x.DepartureTimeWindowBegin);
                    CreateRegularRoute(solution, origin, destination, minDeparture, airplane, fuelOnLanding, passengers);
                }
                return true;
                
            }else{
                var sucess= GoRefuelAndGo(airplane.BaseAirport, origin, fuelOnTakeOff, airplane, TimeSpan.FromHours(6.25), solution, new List<DbRequests>());

                if (!sucess)
                    return false;

                var minTakeOffTime = CurrentAirplaneArrivalTime + CurrentAirplaneLocation.GroundTime;
                var minDeparture = minTakeOffTime > passengers.Max(x => x.DepartureTimeWindowBegin) ? minTakeOffTime : passengers.Max(x => x.DepartureTimeWindowBegin);
                sucess = CreateRegularRoute(solution, origin, destination, minDeparture, airplane, CurrentFuelAmount,passengers);
            }
            return false;
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
        private bool CreateRegularRoute(GeneralSolution solution, DbAirports origin, DbAirports destination, TimeSpan departure, DbAirplanes airplane,
                                        double fuel, List<DbRequests> passengers)
        {
            
            var fuelOnLanding = SolverUtils.GetFuelOnLanding(Input, fuel, origin, destination, airplane);

           // fuelOnLanding *= SolverUtils.PoundsToKg;


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
                    requestsBoardedInOrigin.AddRange(passengers);
                    requestsBoardedInOrigin.AddRange(passengers);
                    var someoneInserted = true;
                    solution.Flights.Add(newFlight);

                    return someoneInserted;
                }
            }
            else{

                //If the current airport allows refueling 
                var someoneInserted = false;
                if (Input.FuelPrice.Any(x => x.Airport.Id == origin.Id))
                    someoneInserted = RefuelAndGo(airplane, fuel, origin, destination, solution,departure, passengers);
                else
                    someoneInserted = GoRefuelAndGo(origin, destination, fuel, airplane, departure,solution, passengers);


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
            TimeSpan departureTime, GeneralSolution solution, List<DbRequests> requests){
            var alternativeRoute = SolverUtils.findStopToFuelAirport(Input,airplane, origin, destination);
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
                var secondStep = SolverUtils.GetFuelOnLanding(Input, firstStep+fuelBuyed, airport, destination, airplane);
                var secondStepArrival = SolverUtils.GetArrivalTime(Input, airplane,firstStepArrival + airport.GroundTime, airport, destination);

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
                        FuelOnTakeOff = firstStep+fuelBuyed,
                        Passengers = requests
                    };

                    solution.Flights.Add(flight1);
                    solution.Flights.Add(flight2);
                    solution.Refuels.Add(refuel);
                    requestsBoardedInOrigin.AddRange(requests);
                }
                else{
                    return RefuelAndGo(airplane, firstStep, airport, destination, solution,firstStepArrival + airport.GroundTime, requests);
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
        private bool RefuelAndGo(DbAirplanes airplanes, double fuelOnTank, DbAirports origin, DbAirports destination, GeneralSolution solution,
                                 TimeSpan departureTime,List<DbRequests> requests){

            var arrivalTime = SolverUtils.GetArrivalTime(Input, airplanes, departureTime, origin, destination);

            //TODO: Change by parameters 
            if (arrivalTime > TimeSpan.FromHours(18.25))
                return false;

            var maxRefuelQuantity = SolverUtils.MaxRefuelQuantity(Input,airplanes, fuelOnTank, origin, requests);
            var finalFuel = SolverUtils.GetFuelOnLanding(Input, fuelOnTank + maxRefuelQuantity, origin, destination, airplanes);
            
            if (finalFuel > 0){

                //TODO: Replace by the real price
                var refuel = new Refuel(origin, airplanes,departureTime, maxRefuelQuantity, 6);

                solution.Refuels.Add(refuel);

                var newFlight = new Flight()
                {
                    Airplanes = airplanes,
                    DepartureTime = departureTime,
                    ArrivalTime = arrivalTime,
                    Origin = origin,
                    Destination = destination,
                    FuelOnTakeOff = fuelOnTank+maxRefuelQuantity,
                    FuelOnLanding = finalFuel,
                    Passengers = requests
                };

                solution.Flights.Add(newFlight);
                requestsBoardedInOrigin.AddRange(requests);
                return true;

            }else{
                GoRefuelAndGo(origin,destination,fuelOnTank+maxRefuelQuantity,airplanes, departureTime,solution,requests);
            }
            return false; 
        }
    }
}
