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

        //============== "Global fields" to make the information interchange between the functions easier =============================
        private List<DbRequests> requestsAlreadyBoardedOnOrigin { get; set; }
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
            

            var numberOfPassengersByAirport = new Dictionary<DbAirports, int>(); 
            foreach (var key in requestsByOrigin.Keys){
                numberOfPassengersByAirport[key] = requestsByOrigin[key].Count;
            }

            var orderedNumberOfPassagersByAirport = numberOfPassengersByAirport.OrderBy(x => x.Key).Reverse();
            var firstTakeOff = TimeSpan.FromHours(6.25); //TODO: Put it as a parameter. Now it's considered as the sun rise hour

            HashSet<DbAirplanes> ExitedFromDepot = new HashSet<DbAirplanes>();

            foreach (var airportCountPair in numberOfPassengersByAirport){

                var sameStretchRequest = requestsByOrigin[airportCountPair.Key].GroupBy(x=>x.Destination).ToDictionary(x=>x.Key, x=>x.ToList());
                var airplanesByClosests = SolverUtils.GetAirplanesByProximity(Input, airportCountPair.Key); //Get the airplanes ordered by proximity
                    
                foreach (var destination in sameStretchRequest.Keys){
                    var requestsOrdered = sameStretchRequest[destination].OrderBy(x=>x.PNR).OrderBy(x=>x.DepartureTimeWindowEnd);
                    var firstDeparture = sameStretchRequest[destination].First(x=>!requestsAlreadyBoardedOnOrigin.Contains(x))
                                                                        .DepartureTimeWindowEnd;

                    var airplane = airplanesByClosests.FirstOrDefault( x => 
                                                        SolverUtils.ArrivallFromDepot(Input, x, airportCountPair.Key) < firstDeparture &&
                                                        !ExitedFromDepot.Contains(x) && 
                                                        SolverUtils.CanDoInOneDay(Input, x,airportCountPair.Key,destination));

                    while (airplane != null){
                        List<DbRequests> passagersList = new List<DbRequests>();
                        Dictionary<string, int> classCapaciy = SolverUtils.CapacityByClass(Input, airplane);
                        Dictionary<string, int> classBooking = new Dictionary<string, int>();

                        var someoneInserted = false;
                        foreach (var request in requestsOrdered){
                            
                            if(requestsAlreadyBoardedOnOrigin.Contains(request))
                                continue;

                            if (!classCapaciy.ContainsKey(request.Class))
                                continue;
                            if (!classBooking.ContainsKey(request.Class))
                                classBooking[request.Class] = 0;

                            if (classBooking[request.Class] >= classCapaciy[request.Class])
                                continue;

                            classBooking[request.Class]++;
                            passagersList.Add(request);
                            someoneInserted = true; 

                        }

                        if (someoneInserted){
                            ExitedFromDepot.Add(airplane);
                            CreatedRouteFromDepot(solution, passagersList, airplane, airportCountPair.Key, destination);
                        }else
                            break;


                        airplane = airplanesByClosests.FirstOrDefault(x =>
                            SolverUtils.ArrivallFromDepot(Input, x, airportCountPair.Key) < firstDeparture &&
                            !ExitedFromDepot.Contains(x) &&
                            SolverUtils.CanDoInOneDay(Input, x, airportCountPair.Key, destination));
                    }

                        
                        
                }
            }

            return solution;
        }

        private bool CreatedRouteFromDepot(GeneralSolution solution, List<DbRequests> passengers, 
                                           DbAirplanes airplane, DbAirports origin, DbAirports destination){

            //Fills with the data about the flight from depot to the first origin
            double fuelOnTakeOff = airplane.Model.Contains("PC") ? airplane.BaseAirport.MTOW_PC12 : airplane.BaseAirport.MTOW_APE3;
            double fuelOnLanding = SolverUtils.GetFuelOnLanding(Input, fuelOnTakeOff, airplane.BaseAirport, origin, airplane);
            TimeSpan arrivalTime = SolverUtils.ArrivallFromDepot(Input, airplane, origin);

            fuelOnTakeOff *= SolverUtils.PoundsToKg;

            
            if (fuelOnLanding > 0){

                if (arrivalTime < TimeSpan.FromHours(18.25)){

                    var newFlight = new Flight()
                    {
                        Airplanes = airplane,
                        DepartureTime = TimeSpan.FromHours(6.25), //TODO: Change for something more rational 
                        ArrivalTime = arrivalTime,
                        Origin = airplane.BaseAirport,
                        Destination = origin,
                        FuelOnLanding = fuelOnLanding,
                        FuelOnTakeOff = fuelOnTakeOff,
                        Passengers = new List<DbRequests>()
                    };
                    solution.Flights.Add(newFlight);

                    CreateRegularRoute(origin, destination, fuelOnLanding, airplane,arrivalTime + origin.GroundTime, solution, passengers);
                }
                return true;
                
            }else{
                var sucess= GoRefuelAndGo(airplane.BaseAirport, origin, fuelOnTakeOff,
                    airplane, TimeSpan.FromHours(6.25), solution, new List<DbRequests>());

                if (!sucess)
                    return false; 

                sucess = CreateRegularRoute(origin,destination, CurrentFuelAmount,airplane,
                                            CurrentAirplaneArrivalTime+CurrentAirplaneLocation.GroundTime,solution,passengers);
            }
            return false;
        }

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
                    requestsAlreadyBoardedOnOrigin.AddRange(passengers);
                    requestsAlreadyBoardedOnOrigin.AddRange(passengers);
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
                    requestsAlreadyBoardedOnOrigin.AddRange(requests);
                }
                else{
                    return RefuelAndGo(airplane, firstStep, airport, destination, solution,firstStepArrival + airport.GroundTime, requests);
                }
            }
            return false;
        }

        private bool RefuelAndGo(DbAirplanes airplanes, double fuelOnTank, DbAirports origin, DbAirports destination, 
                              GeneralSolution solution, TimeSpan departureTime,List<DbRequests> requests){

            var arrivalTime = SolverUtils.GetArrivalTime(Input, airplanes, departureTime, origin, destination);

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
                requestsAlreadyBoardedOnOrigin.AddRange(requests);
                return true;

            }else{
                GoRefuelAndGo(origin,destination,fuelOnTank+maxRefuelQuantity,airplanes, departureTime,solution,requests);
            }
            return false; 
        }


    }
}
