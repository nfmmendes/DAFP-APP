using Common;
using Solver.SolutionData;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SolverClientComunication.Models;
using Org.BouncyCastle.Tls;

namespace Solver
{
    internal class SolutionValidator
    {
        public List<string> Errors { get; private set; }

        SolutionValidator()
        {
            Errors = new List<string>();
        }

        public bool Validate(GeneralSolution solution, SolverInput input)
        {
            return ValidateArrivalAfterDeparture(solution) && ValidateWeight(solution, input) &&
                   ValidateCapacity(solution);
        }

        private bool ValidateArrivalAfterDeparture(GeneralSolution solution) { 
            var invalidFlights = solution.Flights.Where(x => x.DepartureTime > x.ArrivalTime).ToList();

            if (invalidFlights.None())
                return true;

            Errors.AddRange(invalidFlights.Select(x => 
                new string($"The flight with id {x.Id}, from {x.Origin} to {x.Destination} arrives" +
                           $"before the departure time")).ToList());

            return false;
        }

        private bool ValidateWeight(GeneralSolution solution, SolverInput input) {
            var invalidFlights = solution.Flights
                                         .Where(x => x.Airplanes.Weight + 
                                                     x.FuelOnTakeOff + 
                                                     PassengersWeight(x.Passengers, input.OptimizationParameter) > x.Airplanes.MaxWeight);

            if(invalidFlights.None()) 
                return true;

            Errors.AddRange(invalidFlights.Select(x => 
                new string($"In the flight with id {x.Id}, from {x.Origin} to {x.Destination}, the" +
                           $"airplane departed over its max takeoff weight")).ToList());

            return false;
        }

        private double PassengersWeight(List<DbRequest> passengers, OptimizationParameters parameters) {
            return passengers.Where(y => y.Sex == "M").Count() * parameters.AverageManWeight + 
                   passengers.Where(x => x.Sex == "F").Count() * parameters.AverageWomanWeight + 
                   passengers.Where(x => x.Sex == "C").Count() * parameters.AverageChildWeight;
        }

        private bool ValidateCapacity(GeneralSolution solution)
        {
            var invalidFlights = solution.Flights.Where(x => x.Airplanes.Capacity < x.Passengers.Count());

            if(invalidFlights.None()) 
                return true;

            Errors.AddRange(invalidFlights.Select(x =>
                new string($"In the flight with id {x.Id}, from {x.Origin} to {x.Destination}, the" +
                           $"airplane departed over its capacity")).ToList());

            return false;
        }
    }
}
