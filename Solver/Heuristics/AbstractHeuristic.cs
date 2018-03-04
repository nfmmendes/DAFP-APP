using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Solver.SolutionData;
using SolverClientComunication;

namespace Solver.Heuristics
{
    public abstract class AbstractHeuristic
    {
        public GeneralSolution BestSolution { get; set; }
        public double BestSolutionValue { get; set;  }
        public double CurrentSolutionValue { get; set; }
        public bool IsMinimization{ get; set; }
        public SolverInput Input { get; set; }
        //public delegate bool StopCriteria(object[] ); 

        public AbstractHeuristic(SolverInput input, bool isMinimization){
            if (isMinimization){
                BestSolutionValue = Double.MaxValue;
                CurrentSolutionValue = Double.MaxValue;
            }
        }
        protected abstract double EvaluateSolution(GeneralSolution solution);
        public abstract void Execute();

    }
}
