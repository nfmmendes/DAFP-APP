using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.SolverInterface
{
    public interface IVariableFactory { }

    public abstract class VariableFactory<ModelData,T>: IVariableFactory where T: VariableFactory<ModelData,T>,new()

    {
        private static T _instance;
        private static readonly object padlock = new object();

        public abstract bool CreateVariables(Model<ModelData> model);

        public VariableFactory()
        {

        }

        public static T Instance
        {
            get
            {
                if (_instance == null){
                    lock (padlock){
                        _instance = new T();
                    }
                }
                return _instance;
            }
        }

    }
}
