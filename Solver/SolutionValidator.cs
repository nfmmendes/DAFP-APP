using Common;
using Solver.SolutionData;
using System.Collections.Generic;
using System.Linq;

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
            return ValidateArrivalAfterDeparture(solution);
        }

        private bool ValidateArrivalAfterDeparture(GeneralSolution solution) { 
            var invalidFlights = solution.Flights.Where(x => x.DepartureTime > x.ArrivalTime).ToList();

            if (invalidFlights.None())
                return true;

            Errors.AddRange(invalidFlights.Select(x => new string($"The flight with id {x.Id}, from {x.Origin} to {x.Destination} arrives" +
                $"before the departure time")).ToList());

            return false;
        }
    }
}
