using Common;
using Solver.SolutionData;
using System.Collections.Generic;
using System.Linq;
using SolverClientComunication.Models;
using SolutionData;


namespace Solver
{
    /// <summary>
    /// This class contains the logic needed to validate one solution based on the parameters and constraints defined 
    /// on the input. 
    /// </summary>
    public class SolutionValidator
    {

        /// <summary>
        /// List of the errors found in the solution. 
        /// </summary>
        public List<string> Errors { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        SolutionValidator()
        {
            Errors = new List<string>();
        }

        /// <summary>
        /// Validate the solution received as parameter based on the input data. 
        /// </summary>
        /// <param name="solution"> The solution to be validated. </param>
        /// <param name="input"> The problem input data. </param>
        /// <returns> True if the solution is valid. False otherwise. </returns>
        public bool Validate(GeneralSolution solution, SolverInput input)
        {
           Errors.Clear();
           return solution.Flights.Where(x => !ValidateArrivalAfterDeparture(x)).None();
        }

        /// <summary>
        /// Validate the a flight in the solution
        /// </summary>
        /// <param name="flight"> A flight in the solution. </param>
        /// <param name="input"> The problem input data. </param>
        /// <returns> True if the flight is valid. False otherwise. </returns>
        public bool ValidateFlight(Flight flight, SolverInput input) {
            return ValidateArrivalAfterDeparture(flight) && ValidateWeight(flight, input) &&
                            ValidateCapacity(flight);
        }

        /// <summary>
        /// Validate that a flight arrives after its departure. 
        /// </summary>
        /// <param name="flight"> The flight to be validated. </param>
        /// <returns> True if the flight is valid. False otherwise. </returns>
        private bool ValidateArrivalAfterDeparture(Flight flight) { 

            if (flight.DepartureTime > flight.ArrivalTime)
                return true;

            Errors.Add($"The flight with id {flight.Id}, from {flight.Origin} to {flight.Destination} arrives" +
                           $"before the departure time");

            return false;
        }

        /// <summary>
        /// Validate the airplane max weight in the flight. 
        /// </summary>
        /// <param name="flight"> The flight to be validated. </param>
        /// <param name="input"> The problem inpud data. </param>
        /// <returns> True if the weight is valid. False otherwise. </returns>
        private bool ValidateWeight(Flight flight, SolverInput input) {
            var passengersWeight = PassengersWeight(flight.Passengers, input.OptimizationParameter);
            if (flight.Airplanes.Weight + flight.FuelOnTakeOff + passengersWeight > flight.Airplanes.MaxWeight) 
                return true;

            Errors.Add($"In the flight with id {flight.Id}, from {flight.Origin} to {flight.Destination}, the" +
                           $"airplane departed over its max takeoff weight");

            return false;
        }

        /// <summary>
        /// Get the total weight of the passengers in a flight. 
        /// </summary>
        /// <param name="passengers"> The list of passengers. </param>
        /// <param name="parameters"> The optimization parameters containing the average weight by passenger type. </param>
        /// <returns> The total weight of the passengers in the flight. </returns>
        private double PassengersWeight(List<DbRequest> passengers, OptimizationParameters parameters) {
            return passengers.Where(y => y.Sex == "M").Count() * parameters.AverageManWeight + 
                   passengers.Where(x => x.Sex == "F").Count() * parameters.AverageWomanWeight + 
                   passengers.Where(x => x.Sex == "C").Count() * parameters.AverageChildWeight;
        }


        /// <summary>
        /// Validate the airplane capacity in number of passengers. 
        /// </summary>
        /// <param name="flight"> The flight to be validated. </param>
        /// <returns> True if the airplane capacity is respected. False otherwise. </returns>
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
