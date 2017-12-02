using System.Collections.Generic;
using Common;


namespace Solver.SolverInterface
{
    class MathTypeEnum : AbstractEnum
    {
        public static List<MathTypeEnum> EnumList = new List<MathTypeEnum>();

        public static MathTypeEnum Integer = new MathTypeEnum("Integer", "Integer");
        public static MathTypeEnum Continuous = new MathTypeEnum("Continuous", "Continuous");

        private MathTypeEnum(string Label,string DbCode ):base(Label,DbCode)
        {
            EnumList.Add(this);
        }


        
    }
}
