using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.SolverInterface
{
    abstract class VariableFactory<IProblemData>
    {
        public abstract bool CreateVariables(IProblemData model);
        public abstract string ConstraintType { get; set; }
    }
}
