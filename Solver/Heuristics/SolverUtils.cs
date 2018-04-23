using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolutionData;
using SolverClientComunication.Models;

namespace Solver.Heuristics
{
    class SolverUtils
    {
        public static readonly double KnotsToKmH = 1.852;
        public static readonly double PoundsToKg = 0.453592;

        /// <summary>
        /// Return the airplanes that can satisfy entirely a list of requests considering only the seats/class capacities
        /// </summary>
        /// <param name="input"></param>
        /// <param name="requests"></param>
        /// <returns></returns>
        public static List<DbAirplanes> GetCompatibleAirplanes(SolverInput input, List<DbRequests> requests)
        {
            var returnedList = new List<DbAirplanes>();

            var countRequestsByClass = requests.GroupBy(x => x.Class).ToDictionary(x => x.Key, x => x.ToList().Count);
            returnedList = input.Airplanes.ToList();

            //TODO: Improve it
            foreach (var key in countRequestsByClass.Keys)
            {
                returnedList = returnedList.Where(x => input.SeatList.Any(y => y.seatClass.Equals(key) &&
                                                                               y.Airplanes.Id == x.Id &&
                                                                               y.Airplanes.Capacity >= countRequestsByClass[key])).ToList();
            }

            return returnedList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="requests"></param>
        /// <returns></returns>
        public List<DbAirplanes> GetPartiallyCompatibleAirplanes(SolverInput input, List<DbRequests> requests)
        {
            var returnedList = new List<DbAirplanes>();

            var countRequestsByClass = requests.GroupBy(x => x.Class).ToDictionary(x => x.Key, x => x.ToList().Count);
            returnedList = input.Airplanes.ToList();

            //TODO: Improve it
            //TODO: The number of seats here is greater than zero, but it should be checked on the input
            foreach (var key in countRequestsByClass.Keys){
                returnedList = returnedList.Where(x => input.SeatList.Any(y => y.seatClass.Equals(key) && y.Airplanes.Id == x.Id)).ToList();
            }

            return returnedList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="flights"></param>
        /// <param name="requests"></param>
        /// <returns></returns>
        public List<DbAirplanes> AvailableAirplanes(SolverInput input, List<Flight> flights, List<DbRequests> requests)
        {
            var returnedList = new List<DbAirplanes>();

            var countRequestsByClass = requests.GroupBy(x => x.Class).ToDictionary(x => x.Key, x => x.ToList().Count);
            var airplanesUsed = flights.Select(x => x.Airplanes).Distinct();
            var airplanesNotUsed = input.Airplanes.Where(x => !airplanesUsed.Contains(x)).ToList();

            returnedList = airplanesNotUsed;

            var orderedRequests = requests.OrderBy(x => x.ArrivalTimeWindowEnd);

            foreach (var request in orderedRequests){
                var flightsUseful = flights.Where(x=>(x.ArrivalTime <= request.DepartureTimeWindowEnd - x.Destination.GroundTime
                                                         && x.Destination.Id == request.Origin.Id) ||
                                                         (IsFreeAndClose(input,x.Airplanes,flights,request) ));
            }

            return returnedList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="airplanes"></param>
        /// <param name="flights"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        private bool IsFreeAndClose(SolverInput input, DbAirplanes airplanes, List<Flight> flights, DbRequests request)
        {
            
            var earlyFlights = flights.Where(x =>x.ArrivalTime <= request.DepartureTimeWindowEnd - x.Destination.GroundTime - request.Origin.GroundTime);

            List<Flight> usefulFlights = new List<Flight>();

            foreach (var item in earlyFlights){
                var exist = input.Stretches.ContainsKey(item.Destination);
                exist = exist | input.Stretches[item.Destination].ContainsKey(request.Origin);

           

                if (exist){
                    var flightTime = TimeSpan.FromHours(input.Stretches[item.Destination][request.Origin]/(item.Airplanes.CruiseSpeed*KnotsToKmH));
                    var arrivalOnOriginOfRequest = item.ArrivalTime + item.Destination.GroundTime + flightTime + request.Origin.GroundTime;
                    if (arrivalOnOriginOfRequest < request.DepartureTimeWindowEnd )
                        return true; 
                }
                
            }

            return false; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="airplanes"></param>
        /// <param name="originRequest"></param>
        /// <returns></returns>
        public static TimeSpan ArrivallFromDepot(SolverInput input,DbAirplanes airplanes, DbAirports originRequest){
            var baseAirport = airplanes.BaseAirport;
            var returnedValue = TimeSpan.FromHours(1000000); 
            if(originRequest.Id == airplanes.BaseAirport.Id)
                return TimeSpan.FromHours(6.25);
            //TODO: Maybe replace this calculus (time to go) with a input
            if (input.Stretches.ContainsKey(baseAirport) && input.Stretches[baseAirport].ContainsKey(originRequest))
                returnedValue = TimeSpan.FromHours(6.25) + TimeSpan.FromHours(input.Stretches[baseAirport][originRequest] / (airplanes.CruiseSpeed * KnotsToKmH));

            return returnedValue;
        }


        public static double GetFuelOnLanding(SolverInput input, double fuelOnTakeOff, DbAirports origin, DbAirports destination, DbAirplanes airplanes){

            double timeToGo = 0;
            if(input.Stretches.ContainsKey(origin))
                if (input.Stretches[origin].ContainsKey(destination))
                    timeToGo = input.Stretches[origin][destination] / (airplanes.CruiseSpeed*KnotsToKmH);

            double fuelSpent = 0;
            if (timeToGo > 1)
                fuelSpent = (timeToGo - 1) * airplanes.FuelConsumptionSecondHour + airplanes.FuelConsumptionFirstHour;
            else
                fuelSpent = airplanes.FuelConsumptionFirstHour * timeToGo;


            return Math.Abs(timeToGo) > 0.00001? fuelOnTakeOff - fuelSpent : -1;
        }

        public static TimeSpan GetArrivalTime(SolverInput input, DbAirplanes airplanes, TimeSpan departureTime, DbAirports origin, DbAirports destination){
            
            var returnedValue = TimeSpan.FromHours(1000000);
            //TODO: Maybe replace this calculus (time to go) with a input
            if (input.Stretches.ContainsKey(origin) && input.Stretches[origin].ContainsKey(destination))
                returnedValue = TimeSpan.FromHours(input.Stretches[origin][destination] / (airplanes.CruiseSpeed * KnotsToKmH));

            return departureTime + returnedValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static List<DbAirports> findStopToFuelAirport(SolverInput input, DbAirplanes airplane, DbAirports origin, DbAirports destination){
            const double absurdValue = 100000;
            double distanceOrigDest = absurdValue;
            if (input.Stretches.ContainsKey(origin) && input.Stretches[origin].ContainsKey(destination))
                distanceOrigDest = input.Stretches[origin][destination];
            var refuelAirports = input.FuelPrice.Select(x => x.Airport);

            //TODO: Evaluate a future improvement on this filter
            if (refuelAirports.Any() && distanceOrigDest != absurdValue){
                var closerAirports  = refuelAirports.Where(x=>   input.Stretches[origin].ContainsKey(x) && input.Stretches.ContainsKey(x)
                                                              && input.Stretches[origin][x] < airplane.Range).ToList();

                var finalResult = closerAirports.Where(x=>     input.Stretches[x].ContainsKey(destination)
                                                            && input.Stretches[x][destination] < airplane.Range).ToList();

                return finalResult; 

            }else
                return new List<DbAirports>();
        }

        public static double GetRequestWeight(SolverInput input, DbAirplanes airplanes, List<DbRequests> requests){

            var weightPerPassenger =  requests.Count(x => x.Sex.Equals("M") && !x.IsChildren) * input.OptimizationParameter.AverageManWeight
                                    + requests.Count(x => x.Sex.Equals("F") && !x.IsChildren) * input.OptimizationParameter.AverageWomanWeight
                                    + requests.Count(x => x.IsChildren) * input.OptimizationParameter.AverageChildWeight;

            var requestsByClass = requests.GroupBy(x => x.Class).ToDictionary(x => x.Key, x => x.ToList());

            double weightPerClass = 0;
            foreach (var classItem in requestsByClass)
               weightPerClass +=  input.SeatList.First(x=>x.Airplanes.Id == airplanes.Id && x.seatClass.Equals(classItem.Key)).luggageWeightLimit
                                 * classItem.Value.Count;

            return weightPerClass + weightPerPassenger;
        }

        public static double MaxRefuelQuantity(SolverInput input, DbAirplanes airplanes, double fuelOnTank, DbAirports origin, List<DbRequests> requests)
        {
            //IF there was not enough fuel on the airplanes to do the trip without a stop, 
            //it is searched an airport to refueling on the track (or refueled on origin airport)
            var requestWeight = SolverUtils.GetRequestWeight(input, airplanes, requests);

            var weight = airplanes.Weight + fuelOnTank + requestWeight;
            var MTOW = airplanes.Model.Contains("PC")
                ? origin.MTOW_PC12 * SolverUtils.PoundsToKg
                : origin.MTOW_APE3 * SolverUtils.PoundsToKg;

            double maxRefuelQuantity = Math.Min(MTOW - weight, airplanes.Capacity - fuelOnTank);
            return maxRefuelQuantity;
        }

        public static List<DbAirplanes> GetAirplanesByProximity(SolverInput input ,DbAirports airport){
            List<KeyValuePair<TimeSpan, DbAirplanes>> airplanesDistances = new List<KeyValuePair<TimeSpan, DbAirplanes>>();

            foreach (var airplane in input.Airplanes){
                var timeToGo = TimeSpan.FromHours(100000);
                if(input.Stretches.ContainsKey(airplane.BaseAirport))
                    if (input.Stretches[airplane.BaseAirport].ContainsKey(airport))
                        timeToGo = TimeSpan.FromHours(input.Stretches[airplane.BaseAirport][airport]/(airplane.CruiseSpeed*KnotsToKmH) );
                airplanesDistances.Add(new KeyValuePair<TimeSpan, DbAirplanes>(timeToGo,airplane));
            }

            airplanesDistances.OrderBy(x=>x.Key );

            List<DbAirplanes> returnedList = new List<DbAirplanes>();

            foreach (var airplanes in airplanesDistances)
                returnedList.Add(airplanes.Value);

            return returnedList;
        }

        public static bool CanDoInOneDay(SolverInput input, DbAirplanes airplane, DbAirports origin, DbAirports destination)
        {
            double distStretch1 = 100000000;
            double distStretch2 = 100000000;


            if (airplane.BaseAirport.Id == origin.Id)
                distStretch1 = 0;
            else if (input.Stretches.ContainsKey(airplane.BaseAirport) && input.Stretches[airplane.BaseAirport].ContainsKey(origin))
                distStretch1 = input.Stretches[airplane.BaseAirport][origin]/(airplane.CruiseSpeed*KnotsToKmH);

            if (input.Stretches.ContainsKey(origin) && input.Stretches[origin].ContainsKey(destination))
                distStretch2 = input.Stretches[origin][destination] / (airplane.CruiseSpeed * KnotsToKmH);

            return TimeSpan.FromHours(distStretch1) + origin.GroundTime + TimeSpan.FromHours(distStretch2) <= TimeSpan.FromHours(12.0);

        }

    }
}
