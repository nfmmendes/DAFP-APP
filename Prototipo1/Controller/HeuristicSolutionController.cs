using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solver.SolutionData;
using SolverClientComunication;

namespace Prototipo1.Controller
{
    class HeuristicSolutionController
    {
        private CustomSqlContext Context { get; set; }
        public static readonly HeuristicSolutionController Instance = new HeuristicSolutionController();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void setContext(CustomSqlContext context)
        {
            Instance.Context = context;
        }

        public void SaveResults(GeneralSolution solution){
            foreach (var flight in solution.Flights){
              //  var item = new Db
            }
        }
    }
}
