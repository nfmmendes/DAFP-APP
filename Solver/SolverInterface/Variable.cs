using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.SolverInterface
{
    abstract class Variable
    {
        public double Lb { get; set; }
        public double Ub { get; set; }
        public double ObjValue { get; set; }
        public double ConsName { get; set; }
        public virtual MathTypeEnum MathType { get; set; }
    }
}
