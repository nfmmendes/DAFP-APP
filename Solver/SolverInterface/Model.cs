using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.SolverInterface
{
    public class Model<ModelData>
    {
        public ModelData Data { get;  set; }
        //
        private List<IVariableFactory> VariableFactories { get; set; }
        private List<IConstraintBuilder> ConstraintBuilder { get; set;  }
        private HashSet<Variable<ModelData>> Variables { get; set; }
        private Dictionary<string, Constraint> Constraints { get; set; }
        public long InstanceId { get; set;  }

        public void AssociateConstraint(Constraint constraint, Variable<ModelData> variable, double coefficient){
            
        }

        public void AddVariable(Variable<ModelData> variable)
        {
            
        }
    }
}
