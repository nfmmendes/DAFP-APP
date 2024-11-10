using Common;
using Solver.SolutionData;
using System.Collections.Generic;
using System.Linq;
using SolverClientComunication.Models;
using SolutionData;


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
           return solution.Flights.Where(x => !ValidateArrivalAfterDeparture(x)).None();
        }

        public bool ValidateFlight(Flight flight, SolverInput input) {
            return ValidateArrivalAfterDeparture(flight) && ValidateWeight(flight, input) &&
                            ValidateCapacity(flight);
        }

        private bool ValidateArrivalAfterDeparture(Flight flight) { 

            if (flight.DepartureTime > flight.ArrivalTime)
                return true;

            Errors.Add($"The flight with id {flight.Id}, from {flight.Origin} to {flight.Destination} arrives" +
                           $"before the departure time");

            return false;
        }

        private bool ValidateWeight(Flight flight, SolverInput input) {
            var passengersWeight = PassengersWeight(flight.Passengers, input.OptimizationParameter);
            if (flight.Airplanes.Weight + flight.FuelOnTakeOff + passengersWeight > flight.Airplanes.MaxWeight) 
                return true;

            Errors.Add($"In the flight with id {flight.Id}, from {flight.Origin} to {flight.Destination}, the" +
                           $"airplane departed over its max takeoff weight");

            return false;
        }

        private double PassengersWeight(List<DbRequest> passengers, OptimizationParameters parameters) {
            return passengers.Where(y => y.Sex == "M").Count() * parameters.AverageManWeight + 
                   passengers.Where(x => x.Sex == "F").Count() * parameters.AverageWomanWeight + 
                   passengers.Where(x => x.Sex == "C").Count() * parameters.AverageChildWeight;
        }

        private bool ValidateCapacity(Flight flight)
        {
            if (flight.Airplanes.Capacity < flight.Passengers.Count()) 
                return true;

            Errors.Add($"In the flight with id {flight.Id}, from {flight.Origin} to {flight.Destination}, the" +
                           $"airplane departed over its capacity");

            return false;
        }
    }
}
