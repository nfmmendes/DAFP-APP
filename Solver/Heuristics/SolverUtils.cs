using System;
using System.Collections.Generic;
using System.Linq;
using Common;
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
            if (input.Stretches.ContainsKey(origin))
                if (input.Stretches[origin].ContainsKey(destination))
                    timeToGo = airplanes.GetTravelTime(input.Stretches[origin][destination]).TotalHours;

            double fuelSpent = 0;
            fuelSpent = Math.Max(0, timeToGo - 1) * airplanes.FuelConsumptionSecondHour + + Math.Min(1, timeToGo)*airplanes.FuelConsumptionFirstHour;
            
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
        public static TimeSpan GetArrivalTime(SolverInput input, DbAirplane airplane, TimeSpan departureTime, DbAirport origin, DbAirport destination){
            
            var returnedValue = TimeSpan.FromHours(1000000);
            //TODO: Maybe replace this calculus (time to go) with a input
            if (input.Stretches.ContainsKey(origin) && input.Stretches[origin].ContainsKey(destination))
                returnedValue = airplane.GetTravelTime(input.Stretches[origin][destination]);

            return departureTime + returnedValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static List<DbAirport> FindStopToFuelAirport(SolverInput input, DbAirplane airplane, DbAirport origin, DbAirport destination){
            // Filter refuel airports that are in the network.
            var refuelAirports = input.FuelPrice.Where(x => input.Stretches[origin].ContainsKey(x.Airport) && 
                                                            input.Stretches.ContainsKey(x.Airport)
                                                            && input.Stretches[x.Airport].ContainsKey(destination)
                                                       ).Select(x => x.Airport);

            if(refuelAirports.None())
                return new List<DbAirport>();

            if (!(input.Stretches.ContainsKey(origin) && input.Stretches[origin].ContainsKey(destination)))
                return new List<DbAirport>();
            
            return refuelAirports.Where(x=> input.Stretches[origin][x] < airplane.Range &&
                                            input.Stretches[x][destination] < airplane.Range).ToList();
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

            var passengersWeight = requests.Sum(x => x.PassengerWeight(input));

            var requestsByClass = requests.GroupBy(x => x.Class).ToDictionary(x => x.Key, x => x.ToList());
            var airplaneSeatList = input.SeatList.Where(x => x.Airplanes.Id == airplanes.Id).ToList();

            var classesWeight = requestsByClass.Sum(x => airplaneSeatList.FirstOrDefault(y => y.seatClass.Equals(x.Key))?.
                                                         luggageWeightLimit ?? 10000);

            return classesWeight + passengersWeight;
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
        public static double MaxRefuelQuantity(this DbAirplane airplanes, SolverInput input, double fuelOnTank, DbAirport origin, List<DbRequest> requests)
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
        public static bool CanMakeItInOneDay(SolverInput input, DbAirplane airplane, DbAirport origin, DbAirport destination)
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
        public static bool CanMakeItInOne(SolverInput input , TimeSpan lastDeparture, DbAirport lastOrigin,DbAirport requestOrigin,
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

        public static double PassengerWeight(this DbRequest request, SolverInput input)
        {
            var weight = request switch
            {
                DbRequest r when r.Sex.Equals("M") && !r.IsChildren => input.OptimizationParameter.AverageManWeight,
                DbRequest r when r.Sex.Equals("F") && !r.IsChildren => input.OptimizationParameter.AverageWomanWeight,
                DbRequest r when r.IsChildren => input.OptimizationParameter.AverageChildWeight,
                _ => -1
            };

            return weight;
        }

    }
}
