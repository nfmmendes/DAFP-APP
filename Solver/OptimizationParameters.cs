using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver
{
    public class OptimizationParameters
    {
        public  bool UseTimeWindows {  get;  set; }
        public  bool PickUpAll { get; set; }
        public  bool DeliverALl { get; set; }
        public  bool StartFromDepot { get; set; }
        public  bool ComeBackToDepot { get; private set; }
        public  DateTime StartDate { get; private set; }
        public  DateTime EndDate { get; private set; }
        public  int TimeLimit { get; set;  }

    }
}
