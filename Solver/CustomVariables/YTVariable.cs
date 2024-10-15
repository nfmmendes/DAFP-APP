using Solver.Enum.Commons;
using Solver.SolverInterface;

namespace Solver.CustomVariables
{
    public class YTVariable : Variable<IProblemData>
    {

        public YTVariable() : base(MathTypeEnum.Integer,YTVariableFactory.Instance)
        {

        }
    }

    public class YTVariableFactory : VariableFactory<IProblemData,YTVariableFactory>
    {

        //TODO: Verify if its called the right function in each class
        public override bool CreateVariables(Model<IProblemData> model)
        {
            int a = 6;
            int b = 7;

            

            return true;
        }

      
    }

}
