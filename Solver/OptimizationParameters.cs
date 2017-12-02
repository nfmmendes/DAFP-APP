using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    static class OptimizationParameters
    {
        public static bool UseTimeWindows {  get;  set; }
        public static bool PickUpAll { get; set; }
        public static bool DeliverALl { get; set; }
        public static bool StartFromDepot { get; set; }
        public static bool ComeBackToDepot { get; private set; }
        public static DateTime StartDate { get; private set; }
        public static DateTime EndDate { get; private set; }

    }
}
