using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SolutionData;
using SolverClientComunication.Models;

namespace Solver.Heuristics
{
    class SolverUtils
    {
        public readonly double KnotsToKmH = 1.852;
        /// <summary>
        /// Return the airplanes that can satisfy entirely a list of requests 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="requests"></param>
        /// <returns></returns>
        public static List<DbAirplane> GetCompatibleAirplanes(SolverInput input, List<DbRequests> requests)
        {
            var returnedList = new List<DbAirplane>();

            var countRequestsByClass = requests.GroupBy(x => x.Class).ToDictionary(x => x.Key, x => x.ToList().Count);
            returnedList = input.Airplanes.ToList();

            //TODO: Improve it
            foreach (var key in countRequestsByClass.Keys)
            {
                returnedList = returnedList.Where(x => input.SeatList.Any(y => y.seatClass.Equals(key) &&
                                                                               y.Airplane.Id == x.Id &&
                                                                               y.numberOfSeats >= countRequestsByClass[key]))
                    .ToList();
            }

            return returnedList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="requests"></param>
        /// <returns></returns>
        public List<DbAirplane> GetPartiallyCompatibleAirplanes(SolverInput input, List<DbRequests> requests)
        {
            var returnedList = new List<DbAirplane>();

            var countRequestsByClass = requests.GroupBy(x => x.Class).ToDictionary(x => x.Key, x => x.ToList().Count);
            returnedList = input.Airplanes.ToList();

            //TODO: Improve it
            //TODO: The number of seats here is greater than zero, but it should be checked on the input
            foreach (var key in countRequestsByClass.Keys)
            {
                returnedList = returnedList.Where(x => input.SeatList.Any(y => y.seatClass.Equals(key) &&
                                                                               y.Airplane.Id == x.Id &&
                                                                               y.numberOfSeats >= 0)).ToList();
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
        public List<DbAirplane> AvailableAirplanes(SolverInput input, List<Flight> flights, List<DbRequests> requests)
        {
            var returnedList = new List<DbAirplane>();

            var countRequestsByClass = requests.GroupBy(x => x.Class).ToDictionary(x => x.Key, x => x.ToList().Count);
            var airplanesUsed = flights.Select(x => x.Airplane).Distinct();
            var airplanesNotUsed = input.Airplanes.Where(x => !airplanesUsed.Contains(x)).ToList();

            returnedList = airplanesNotUsed;

            var orderedRequests = requests.OrderBy(x => x.ArrivalTimeWindowEnd);

            foreach (var request in orderedRequests){
                var flightsUseful = flights.Where(x=>(x.ArrivalTime <= request.DepartureTimeWindowEnd - x.Destination.GroundTime
                                                         && x.Destination.Id == request.Origin.Id) ||
                                                         (IsFreeAndClose(input,x.Airplane,flights,request) ));
            }

            return returnedList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="airplane"></param>
        /// <param name="flights"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        private bool IsFreeAndClose(SolverInput input, DbAirplane airplane, List<Flight> flights, DbRequests request)
        {
            
            var earlyFinishedFlights = flights.Where(x =>x.ArrivalTime <= request.DepartureTimeWindowEnd - x.Destination.GroundTime - request.Origin.GroundTime);

            List<Flight> usefulFlights = new List<Flight>();

            foreach (var item in earlyFinishedFlights){
                //TODO: Create a dictionary to stretch 
                var exist = input.Stretches.ContainsKey(item.Destination);
                exist = exist | input.Stretches[item.Destination].ContainsKey(request.Origin);
                if (exist){
                    var flightTime = TimeSpan.FromHours(input.Stretches[item.Destination][request.Origin]/(item.Airplane.CruiseSpeed*KnotsToKmH));
                    var arrivalOnOriginOfRequest = item.ArrivalTime + item.Destination.GroundTime + flightTime + request.Origin.GroundTime;
                    if (arrivalOnOriginOfRequest < request.DepartureTimeWindowEnd)
                        return true; 
                }
                
            }

            return false; 
        }
    }
}
