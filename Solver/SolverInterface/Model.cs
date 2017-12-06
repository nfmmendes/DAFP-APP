using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.SolverInterface
{
    public class Model
    {
        public IProblemData Data { get;  set; }
        private List<VariableFactory<IProblemData,Object>> VariableFactories { get; set; }
        private List<ConstraintBuilder<IProblemData,Constraint>> ConstraintBuilder { get; set;  }
        private HashSet<Variable> Variables { get; set; }
        private Dictionary<string, Constraint> Constraints { get; set; }
        public long InstanceId { get; set;  }

        public void AssociateConstraint(Constraint constraint, Variable variable, double coefficient){
            
        }

        public void AddVariable(Variable variable)
        {
            
        }
    }
}
