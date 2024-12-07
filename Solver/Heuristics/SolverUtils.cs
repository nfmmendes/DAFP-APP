using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics;
using SolutionData;
using SolverClientComunication.Enums;
using SolverClientComunication.Models;

namespace Solver.Heuristics
{
    static class SolverUtils
    {
        public static readonly double KnotsToKmH = 1.852;
        public static readonly double PoundsToKg = 0.453592;

        /// <summary>
        /// Return the airplanes that can satisfy entirely a list of requests considering only the seats/class capacities
        /// </summary>
        /// <param name="input"></param>
        /// <param name="requests"></param>
        /// <returns></returns>
        public static List<DbAirplane> GetCompatibleAirplanes(SolverInput input, List<DbRequest> requests)
        {
            var returnedList = new List<DbAirplane>();

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
        public static List<DbAirplane> GetPartiallyCompatibleAirplanes(SolverInput input, List<DbRequest> requests)
        {
            var returnedList = new List<DbAirplane>();

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
        public static List<DbAirplane> AvailableAirplanes(SolverInput input, List<Flight> flights, List<DbRequest> requests)
        {
            var returnedList = new List<DbAirplane>();

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
        private static bool IsFreeAndClose(SolverInput input, DbAirplane airplanes, List<Flight> flights, DbRequest request)
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
        public static TimeSpan ArrivallFromDepot(SolverInput input,DbAirplane airplanes, DbAirport originRequest){
            var baseAirport = airplanes.BaseAirport;
            var returnedValue = TimeSpan.FromHours(1000000); 
            if(originRequest.Id == airplanes.BaseAirport.Id)
                return TimeSpan.FromHours(6.25);
            //TODO: Maybe replace this calculus (time to go) with a input
            if (input.Stretches.ContainsKey(baseAirport) && input.Stretches[baseAirport].ContainsKey(originRequest))
                returnedValue = TimeSpan.FromHours(6.25) + TimeSpan.FromHours(input.Stretches[baseAirport][originRequest] / (airplanes.CruiseSpeed * KnotsToKmH));

            return returnedValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="fuelOnTakeOff"></param>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <param name="airplanes"></param>
        /// <returns></returns>
        public static double GetFuelOnLanding(SolverInput input, double fuelOnTakeOff, DbAirport origin, DbAirport destination, DbAirplane airplanes){

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="airplanes"></param>
        /// <param name="departureTime"></param>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static TimeSpan GetArrivalTime(SolverInput input, DbAirplane airplanes, TimeSpan departureTime, DbAirport origin, DbAirport destination){
            
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
        public static List<DbAirport> findStopToFuelAirport(SolverInput input, DbAirplane airplane, DbAirport origin, DbAirport destination){
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
                return new List<DbAirport>();
        }

        /// <summary>
        /// Return the weight of a passengers group based on their sex and class. 
        /// WARNING: The class weight depends on airplane
        /// </summary>
        /// <param name="input"></param>
        /// <param name="airplanes"></param>
        /// <param name="requests"></param>
        /// <returns></returns>
        public static double GetRequestWeight(SolverInput input, DbAirplane airplanes, List<DbRequest> requests){

            var weightPerPassenger =  requests.Count(x => x.Sex.Equals("M") && !x.IsChildren) * input.OptimizationParameter.AverageManWeight
                                    + requests.Count(x => x.Sex.Equals("F") && !x.IsChildren) * input.OptimizationParameter.AverageWomanWeight
                                    + requests.Count(x => x.IsChildren) * input.OptimizationParameter.AverageChildWeight;

            var requestsByClass = requests.GroupBy(x => x.Class).ToDictionary(x => x.Key, x => x.ToList());

            double weightPerClass = 0;
            foreach (var classItem in requestsByClass){
                var seatClass = input.SeatList.FirstOrDefault(x => x.Airplanes.Id == airplanes.Id && x.seatClass.Equals(classItem.Key));
                if(seatClass != null)
                    weightPerClass += input.SeatList.First(x => x.Airplanes.Id == airplanes.Id && x.seatClass.Equals(classItem.Key)).luggageWeightLimit
                                      * classItem.Value.Count;
                else
                    weightPerClass += 100000; //TODO : The code should not arrive here 
            }

            return weightPerClass + weightPerPassenger;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="airplanes"></param>
        /// <param name="fuelOnTank"></param>
        /// <param name="origin"></param>
        /// <param name="requests"></param>
        /// <returns></returns>
        public static double MaxRefuelQuantity(SolverInput input, DbAirplane airplanes, double fuelOnTank, DbAirport origin, List<DbRequest> requests)
        {
            //IF there was not enough fuel on the airplanes to do the trip without a stop, 
            //it is searched an airport to refueling on the track (or refueled on origin airport)
            var requestWeight = SolverUtils.GetRequestWeight(input, airplanes, requests);

            var weight = airplanes.Weight + fuelOnTank + requestWeight;
            var MTOW = airplanes.Model.Contains("PC")
                ? origin.MTOW_PC12 * SolverUtils.PoundsToKg
                : origin.MTOW_APE3 * SolverUtils.PoundsToKg;

            double maxRefuelQuantity = Math.Min(MTOW - weight, airplanes.MaxFuel - fuelOnTank);
            return maxRefuelQuantity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="airport"></param>
        /// <returns></returns>
        public static List<DbAirplane> GetAirplanesByProximity(SolverInput input ,DbAirport airport){
            List<KeyValuePair<TimeSpan, DbAirplane>> airplanesDistances = new List<KeyValuePair<TimeSpan, DbAirplane>>();

            
            foreach (var airplane in input.Airplanes){
                var timeToGo = TimeSpan.FromHours(100000);
                if(airport.Id == airplane.BaseAirport.Id)
                    airplanesDistances.Add(new KeyValuePair<TimeSpan, DbAirplane>(TimeSpan.FromSeconds(0.1), airplane));

                if (input.Stretches.ContainsKey(airplane.BaseAirport))
                    if (input.Stretches[airplane.BaseAirport].ContainsKey(airport))
                        timeToGo = TimeSpan.FromHours(input.Stretches[airplane.BaseAirport][airport]/(airplane.CruiseSpeed*KnotsToKmH) );
                airplanesDistances.Add(new KeyValuePair<TimeSpan, DbAirplane>(timeToGo,airplane));
            }

            airplanesDistances.OrderBy(x=>x.Key );

            List<DbAirplane> returnedList = new List<DbAirplane>();

            foreach (var airplanes in airplanesDistances)
                returnedList.Add(airplanes.Value);

            return returnedList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="airplane"></param>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static bool CanDoInOneDay(SolverInput input, DbAirplane airplane, DbAirport origin, DbAirport destination)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="lastDeparture"></param>
        /// <param name="lastOrigin"></param>
        /// <param name="requestOrigin"></param>
        /// <param name="requestDestination"></param>
        /// <param name="airplane"></param>
        /// <returns></returns>
        public static bool CanDoInOne(SolverInput input , TimeSpan lastDeparture, DbAirport lastOrigin,DbAirport requestOrigin,
                                     DbAirport requestDestination, DbAirplane airplane){
            
            var arrival1 = GetArrivalTime(input, airplane,lastDeparture,lastOrigin,requestOrigin);
            var arrival2 = GetArrivalTime(input, airplane, arrival1+requestOrigin.GroundTime, requestOrigin, requestDestination);
            var arrival3 = GetArrivalTime(input, airplane, arrival2+requestDestination.GroundTime,requestDestination, airplane.BaseAirport);

            var timeInString = input.Parameters.FirstOrDefault(x => x.Code.Equals(ParametersEnum.SUNSET_TIME.DbCode)).Value;
            var hour = Convert.ToInt32(timeInString.Split(':')[0]);
            var minute = Convert.ToInt32(timeInString.Split(':')[1]);

            return arrival3 <= TimeSpan.FromHours(hour) + TimeSpan.FromMinutes(minute);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="airport"></param>
        /// <param name="airplane"></param>
        /// <returns></returns>
        public static double GetMaxWeight(DbAirport airport, DbAirplane airplane){
            //TODO: This is not the right way 
            if (airplane.Model.Contains("PC"))
                return Math.Min(airport.MTOW_PC12, airplane.MaxWeight);
            if (airplane.Model.Contains("Cessna"))
                return Math.Min(airport.MTOW_APE3, airplane.MaxWeight);
            else
                return 0;
        }

        public static TimeSpan GetTravelTime(this DbAirplane airplane, double distance) { 
            return TimeSpan.FromHours(airplane.CruiseSpeed > 0 ? distance/(airplane.CruiseSpeed * KnotsToKmH) : 1e5);
        }

    }
}
