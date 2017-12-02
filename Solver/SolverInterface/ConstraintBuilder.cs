using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.SolverInterface
{
    abstract class ConstraintBuilder<IProblemData,T> where T : new()
    {
        public abstract void CreateOrUpdateConstraints();
    }
}
