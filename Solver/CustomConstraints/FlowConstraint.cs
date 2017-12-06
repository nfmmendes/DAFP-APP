using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solver.CustomVariables;
using Solver.Enum.Commons;
using Solver.SolverInterface;

namespace Solver.CustomConstraints
{
    class FlowConstraint : Constraint
    {

        FlowConstraint() : base(RowSenseEnum.Greater, FlowConstraintBuilder.Instance)
        {
            
        }
    }

    class FlowConstraintBuilder : ConstraintBuilder<IProblemData, FlowConstraintBuilder>
    {
        public override void CreateOrUpdateConstraints(Variable v)
        {
            if (v.Type.Equals(YTVariableFactory.Instance))
            {
                
            }
            throw new NotImplementedException();
        }
    }
}
