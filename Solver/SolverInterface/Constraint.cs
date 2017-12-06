using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solver.Enum.Commons;

namespace Solver.SolverInterface
{
    public class Constraint
    {
        public double RHS { get;  set; }
        public RowSenseEnum RowSense { get; private set; }
        private IConstraintBuilder<IProblemData> Builder { get;  set; }

        public Constraint(RowSenseEnum rowsSense)
        {
            
        }

    }
}
