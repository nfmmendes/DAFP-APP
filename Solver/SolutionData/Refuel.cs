using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolverClientComunication.Models;

namespace SolutionData
{
    public class Refuel{
        public DbAirports Airport { get; set; }
        public double Amount { get; set; }
        public double PriceInUSD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="airport"></param>
        /// <param name="amount"></param>
        /// <param name="price"></param>
        public Refuel(DbAirports airport, double amount, double price){
             
        }
    }
}
