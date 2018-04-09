using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;

namespace SolverClientComunication.Enums
{
    public class ParametersEnum : AbstractEnum
    {
        public static List<ParametersEnum> EnumList = new List<ParametersEnum>();

        public static readonly ParametersEnum USE_TIME_WINDOWS = new ParametersEnum("Use Time Windows", "USE_TIME_WINDOWS");
        public static readonly ParametersEnum PICK_ALL = new ParametersEnum("Pick all", "PICK_ALL");
        public static readonly ParametersEnum DELIVER_ALL = new ParametersEnum("Deliver all", "DELIVER_ALL");
        public static readonly ParametersEnum START_FROM_DEPOT = new ParametersEnum("Start from depot", "START_FROM_DEPOT");
        public static readonly ParametersEnum COME_BACK_TO_DEPOT = new ParametersEnum("Come back to depot", "COME_BACK_TO_DEPOT");
        public static readonly ParametersEnum AVERAGE_MEN_WEIGHT = new ParametersEnum("Average men weight", "AVERAGE_MEN_WEIGHT");
        public static readonly ParametersEnum AVERAGE_WOMEN_WEIGHT  = new ParametersEnum("Average women weight", "AVERAGE_WOMEN_WEIGHT");
        public static readonly ParametersEnum AVERAGE_CHILDREN_WEIGHT = new ParametersEnum("Average childrem weight", "AVERAGE_CHILDREN_WEIGHT");
        public static readonly ParametersEnum TIME_LIMIT = new ParametersEnum("Time limit", "TIME_LIMIT");
        public static readonly ParametersEnum SUNSET_TIME = new ParametersEnum("Sunset Time", "SUNSET_TIME");
        public static readonly ParametersEnum SUNRISE_TIME = new ParametersEnum("Sunrise Time", "SUNRISE_TIME");

        private ParametersEnum(string label, string dbCode) : base(label, dbCode)
        {
            EnumList.Add(this);
        }
    }
}
