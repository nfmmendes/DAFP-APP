using Common;
using System.Collections.Generic;
using System.Linq;

namespace SolverClientComunication.Enums
{
    public class OptimizationAlertTypeEnum : AbstractEnum
    {
        public static List<OptimizationAlertTypeEnum> EnumList = new List<OptimizationAlertTypeEnum>();

        public static readonly OptimizationAlertTypeEnum ERROR = new OptimizationAlertTypeEnum("Error", "ERROR");
        public static readonly OptimizationAlertTypeEnum WARNING = new OptimizationAlertTypeEnum("Warning", "WARNING");

        private OptimizationAlertTypeEnum(string label, string dbCode) : base(label, dbCode)
        {
            EnumList.Add(this);
        }

        public static string GetLabel(string dbCode)
        {
            return EnumList.Any(x => x.DbCode.Equals(dbCode)) ? EnumList.First(x => x.DbCode.Equals(dbCode)).Label : "##LABEL_NOT_FOUND";
        }
    }
}
