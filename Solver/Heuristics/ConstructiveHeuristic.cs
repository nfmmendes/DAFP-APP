using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolverClientComunication;

namespace Solver.Heuristics
{
    public class ConstructiveHeuristic : AbstractHeuristic
    {
        public override double EvaluateSolution()
        {
            throw new NotImplementedException();
        }

        public override void Execute()
        {
            var a = 1;
            a = 2; 
        }

        public ConstructiveHeuristic(SolverInput input, bool isMinimization) : base(input, isMinimization)
        {
        }
    }
}
