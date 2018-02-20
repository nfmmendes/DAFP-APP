using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solver.SolutionData;
using SolverClientComunication;

namespace Solver.Heuristics
{
    class MainHeuristic : AbstractHeuristic
    {
        public GeneralSolution Solution { get; set; }

        public override double EvaluateSolution()
        {
            throw new NotImplementedException();

        }

        public override void Execute()
        {
            throw new NotImplementedException();
        }

        public MainHeuristic(SolverInput input, bool isMinimization) : base(input, isMinimization)
        {
        }
    }
}
