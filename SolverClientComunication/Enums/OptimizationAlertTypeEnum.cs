using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Enums
{
    public class OptimizationAlertTypeEnum: AbstractEnum {
        public static List<OptimizationAlertTypeEnum> EnumList = new List<OptimizationAlertTypeEnum>();

        public static readonly OptimizationAlertTypeEnum ERROR = new OptimizationAlertTypeEnum("Error", "ERROR");
        public static readonly OptimizationAlertTypeEnum WARNING = new OptimizationAlertTypeEnum("Warning", "WARNING");

        private OptimizationAlertTypeEnum(string label, string dbCode) : base(label, dbCode){
            EnumList.Add(this);
        }
    }
}
