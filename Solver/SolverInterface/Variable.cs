using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solver.Enum;
using Solver.Enum.Commons;

namespace Solver.SolverInterface
{
    public abstract class Variable
    {
        public double Lb { get; set; }
        public double Ub { get; set; }
        public double ObjValue { get; set; }
        public double ConsName { get; set; }
        public MathTypeEnum MathType { get; set; }
        public double Value { get; private set;  }
        public VariableFactory<IProblemData, IVariableFactory<IProblemData>> Type { get; private set; }

        public Variable(MathTypeEnum mathType, VariableFactory<IProblemData,IVariableFactory<IProblemData>> instance)
        {
            MathType = mathType;
            Type = instance;
        }

    }
}
