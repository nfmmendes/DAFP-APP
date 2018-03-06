using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solver;
using Solver.CustomVariables;
using SolverClientComunication.Models;
using Aiport = SolverClientComunication.Models.DbAirports;
using Passenger = SolverClientComunication.Models.DbRequests;

namespace SolutionData
{
    public class Flight
    {
        public DbAirplane Airplane { get; set; }
        public Aiport Origin { get; set; }
        public Aiport Destination { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public double FuelOnTakeOff { get; set; }
        public double FuelOnLanding { get; set; }
        public List<Passenger> Passengers { get; set;  }




    }

    
}
