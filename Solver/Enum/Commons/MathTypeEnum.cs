using System.Collections.Generic;
using Common;


namespace Solver.Enum.Commons
{
    public class MathTypeEnum : AbstractEnum
    {
        public static List<MathTypeEnum> EnumList = new List<MathTypeEnum>();

        public static MathTypeEnum Integer = new MathTypeEnum("Integer", "Integer");
        public static MathTypeEnum Continuous = new MathTypeEnum("Continuous", "Continuous");
        public static MathTypeEnum Binary = new MathTypeEnum("Binary", "Binary");
        public static MathTypeEnum SemiContinuous = new MathTypeEnum("Semicontinuous", "Semicontinuous");

        private MathTypeEnum(string Label,string DbCode ):base(Label,DbCode)
        {
            EnumList.Add(this);
        }


        
    }
}
