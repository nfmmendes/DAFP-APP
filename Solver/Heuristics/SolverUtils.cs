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
                                                                               y.numberOfSeats >= countRequestsByClass[key])).ToList();
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
            foreach (var key in countRequestsByClass.Keys){
                returnedList = returnedList.Where(x => input.SeatList.Any(y => y.seatClass.Equals(key) && y.Airplane.Id == x.Id &&
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
            
            var earlyFlights = flights.Where(x =>x.ArrivalTime <= request.DepartureTimeWindowEnd - x.Destination.GroundTime - request.Origin.GroundTime);

            List<Flight> usefulFlights = new List<Flight>();

            foreach (var item in earlyFlights){
                //TODO: Create a dictionary to stretch 
                var exist = input.Stretches.ContainsKey(item.Destination);
                exist = exist | input.Stretches[item.Destination].ContainsKey(request.Origin);

           

                if (exist){
                    var flightTime = TimeSpan.FromHours(input.Stretches[item.Destination][request.Origin]/(item.Airplane.CruiseSpeed*KnotsToKmH));
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
        /// <param name="airplane"></param>
        /// <param name="originRequest"></param>
        /// <returns></returns>
        public static TimeSpan ArrivallFromDepot(SolverInput input,DbAirplane airplane, DbAirports originRequest){
            var baseAirport = airplane.BaseAirport;
            var returnedValue = TimeSpan.FromHours(1000000); 
            //TODO: Maybe replace this calculus (time to go) with a input
            if (input.Stretches.ContainsKey(baseAirport) && input.Stretches[baseAirport].ContainsKey(originRequest))
                returnedValue = TimeSpan.FromHours(input.Stretches[baseAirport][originRequest] / (airplane.CruiseSpeed * KnotsToKmH));

            return returnedValue;
        }


        public static double GetFuelOnLanding(SolverInput input, double fuelOnTakeOff, DbAirports origin, DbAirports destination, DbAirplane airplane){

            double timeToGo = 0;
            if(input.Stretches.ContainsKey(origin))
                if (input.Stretches[origin].ContainsKey(destination))
                    timeToGo = input.Stretches[origin][destination] / (airplane.CruiseSpeed);

            double fuelSpent = 0;
            if (timeToGo > 1)
                fuelSpent = (timeToGo - 1) * airplane.FuelConsumptionSecondHour + airplane.FuelConsumptionFirstHour ;


            return timeToGo != 0? fuelOnTakeOff - fuelSpent : -1;
        }

        public static TimeSpan GetArrivalTime(SolverInput input, DbAirplane airplane, TimeSpan departureTime, DbAirports origin, DbAirports destination){
            
            var returnedValue = TimeSpan.FromHours(1000000);
            //TODO: Maybe replace this calculus (time to go) with a input
            if (input.Stretches.ContainsKey(origin) && input.Stretches[origin].ContainsKey(destination))
                returnedValue = TimeSpan.FromHours(input.Stretches[origin][destination] / (airplane.CruiseSpeed * KnotsToKmH));

            return departureTime + returnedValue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public static List<DbAirports> findStopToFuelAirport(SolverInput input, DbAirports origin, DbAirports destination){
            const double absurdValue = 100000;
            double distanceOrigDest = absurdValue;
            if (input.Stretches.ContainsKey(origin) && input.Stretches[origin].ContainsKey(destination))
                distanceOrigDest = input.Stretches[origin][destination];
            var refuelAirports = input.FuelPrice.Select(x => x.Airport);

            //TODO: Evaluate a future improvement on this filter
            if (refuelAirports.Any() && distanceOrigDest != absurdValue){
                var closerAirports  = refuelAirports.Where(x=>   input.Stretches[origin].ContainsKey(x) && input.Stretches.ContainsKey(x)
                                                              && input.Stretches[origin][x] < distanceOrigDest).ToList();

                var finalResult = closerAirports.Where(x=>     input.Stretches[x].ContainsKey(destination)
                                                            && input.Stretches[x][destination] < distanceOrigDest).ToList();

                return finalResult; 

            }else
                return new List<DbAirports>();
        }
    }
}
