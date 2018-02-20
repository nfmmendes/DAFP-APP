using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolverClientComunication.Models;
using Aiport = SolverClientComunication.Models.DbAirports;
using Passenger = SolverClientComunication.Models.DbRequests;

namespace SolutionData
{
    public class Flight
    {
        public Aiport Origin { get; set; }
        public Aiport Destination { get; set; }
        public TimeSpan Departure { get; set; }
        public TimeSpan Arrival { get; set; }
        public double FuelOnTakeOff { get; set; }
        public double FuelOnLanding { get; set; }
        public List<Passenger> Passengers { get; set;  }
    }
}
