using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolutionData;

namespace Solver.SolutionData
{
    public class GeneralSolution
    {
        public List<Flight> Flights { get; set; }
        public List<Refuel> Refuels { get; set;  }

        public GeneralSolution(List<Flight> flights, List<Refuel> refuels){
            this.Flights = flights;
            this.Refuels = refuels; 
        }

        public GeneralSolution(){
            Flights = new List<Flight>();
            Refuels = new List<Refuel>();
        }

        public GeneralSolution Clone(){
            return new GeneralSolution(this.Flights, this.Refuels);
        }

    }
}
