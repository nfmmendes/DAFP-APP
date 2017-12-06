using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.SolverInterface
{
    public interface IConstraintBuilder { }
    public abstract class ConstraintBuilder<ModelData, T>  where T : class,new()

    { 
        public abstract void CreateOrUpdateConstraints(Variable<ModelData> v);

        private static object lockingObject; //TODO: Use this to deal with paralelism
        private static ConstraintBuilder<IProblemData, T> singleTonObject;

        protected ConstraintBuilder()
        {

        }

        public static T Instance { get; }
    }
}
