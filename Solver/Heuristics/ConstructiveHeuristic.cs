using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solver.SolutionData;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Solver.Heuristics
{
    public class ConstructiveHeuristic : AbstractHeuristic
    {
        public enum GreedyStrategie { MostRequestedOrigin, MostRequestedDestination, EarlierRequests}

        public GreedyStrategie Strategie { get; set; }

        protected override double EvaluateSolution(GeneralSolution solution){
            throw new NotImplementedException();
        }

        public override void Execute()
        {
            if (Strategie == GreedyStrategie.MostRequestedOrigin){
                DoMostRequestedOriginStrategy();
            }else if (Strategie == GreedyStrategie.EarlierRequests){
                
            }else if (Strategie == GreedyStrategie.MostRequestedOrigin){
                
            }
            
            
        }


        public ConstructiveHeuristic(SolverInput input, bool isMinimization, GreedyStrategie strategie) 
            : base(input, isMinimization){

        }

        private void DoMostRequestedOriginStrategy(){
            var requests = Input.Requests;
            var requestsByOrigin = requests.GroupBy(x => x.Origin).ToDictionary(x => x.Key, x => x.ToList());
            

            var numberOfPassengersByAirport = new Dictionary<DbAirports, int>(); 
            foreach (var key in requestsByOrigin.Keys){
                numberOfPassengersByAirport[key] = requestsByOrigin[key].Count;
            }

            var orderedNumberOfPassagensByAirport = numberOfPassengersByAirport.OrderBy(x => x.Key).Reverse();

            bool someoneInserted = true;

            while (someoneInserted){
                someoneInserted = false;

                foreach (var element in numberOfPassengersByAirport){
                    
                }
            }


        }
    }
}
