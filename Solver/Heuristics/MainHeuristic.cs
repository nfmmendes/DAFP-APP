using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solver.SolutionData;
using SolverClientComunication;
using GreedyStrategy = Solver.Heuristics.ConstructiveHeuristic.GreedyStrategie;

namespace Solver.Heuristics
{
    public class MainHeuristic : AbstractHeuristic
    {

        protected override double EvaluateSolution(GeneralSolution solution){
            throw new NotImplementedException();

        }

        public override void Execute()
        {
            var constructHeur1 = new ConstructiveHeuristic(Input, true,GreedyStrategy.MostRequestedOrigin);
            GeneralSolution currentSolution = new GeneralSolution();

            constructHeur1.Execute();
            var firstSolution = constructHeur1.BestSolution;
            currentSolution = DeterministicLocalSearch(firstSolution);
            UpdateBestSolution(currentSolution);

            var constructHeur2 = new ConstructiveHeuristic(Input,true,GreedyStrategy.MostRequestedDestination);
            var secondSolution = constructHeur2.BestSolution;
            currentSolution = DeterministicLocalSearch(secondSolution);
            UpdateBestSolution(currentSolution);

            var constructHeur3 = new ConstructiveHeuristic(Input,true,GreedyStrategy.EarlierRequests);
            var thirdSolution = constructHeur3.BestSolution;
            currentSolution = DeterministicLocalSearch(thirdSolution);
            UpdateBestSolution(currentSolution);

            
        }

        public GeneralSolution DeterministicLocalSearch(GeneralSolution solution){
            var returnedSolution = new GeneralSolution();

            var timeLimit = Input.OptimizationParameter.TimeLimit;

            Stopwatch sw = new Stopwatch();
            sw.Start();


            while (sw.Elapsed.TotalSeconds < timeLimit/4){
                
            }


            return returnedSolution; 
        }

        public void UpdateBestSolution(GeneralSolution solution){
            var currentSolutionValue = EvaluateSolution(solution);

            if (IsMinimization)
                if (currentSolutionValue < BestSolutionValue){
                    BestSolutionValue = currentSolutionValue;
                    BestSolution = solution; 
                }
        }

        public MainHeuristic(SolverInput input, bool isMinimization) : base(input, isMinimization){
        }
    }
}
