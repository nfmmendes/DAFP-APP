using Solver.SolutionData;
using System.Collections.Generic;

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
            return true;
        }
    }
}
