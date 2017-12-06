using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.SolverInterface
{

    public abstract class VariableFactory<IProblemData,T> : IVariableFactory<IProblemData> where T: class
                          
    {
        private static object lockingObject; //TODO: Use this to deal with paralelism
        private static VariableFactory<IProblemData, T> singleTonObject;


        public abstract bool CreateVariables(Model model);

        protected VariableFactory()
        {

        }

        public static VariableFactory<SolverInterface.IProblemData, IVariableFactory<SolverInterface.IProblemData>> Instance { get; }
        
    }
}
