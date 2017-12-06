using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace Solver.Enum.Commons
{
    public class RowSenseEnum : AbstractEnum
    {
        public static List<RowSenseEnum> EnumList = new List<RowSenseEnum>();

        public static RowSenseEnum Greater = new RowSenseEnum("Greater", "Greater");
        public static RowSenseEnum Less = new RowSenseEnum("Less", "Less");
        public static RowSenseEnum Equal = new RowSenseEnum("Equal", "Equal");
       

        private RowSenseEnum(string Label, string DbCode):base(Label,DbCode)
        {
            EnumList.Add(this);
        }
    }
}
