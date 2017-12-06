using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.SolverInterface
{
    public abstract class ConstraintBuilder<IProblemData, T> : IConstraintBuilder<IProblemData> where T : class

    { 
        public abstract void CreateOrUpdateConstraints(Variable v);

        private static object lockingObject; //TODO: Use this to deal with paralelism
        private static VariableFactory<IProblemData, T> singleTonObject;

        protected ConstraintBuilder()
        {

        }

        public static ConstraintBuilder<SolverInterface.IProblemData, IVariableFactory<SolverInterface.IProblemData>> Instance { get; }
    }
}
