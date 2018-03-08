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
        public DbAirplanes Airplanes { get; set; }
        public TimeSpan RefuelTime { get; set;  }
        public double Amount { get; set; }
        public string FuelCode { get; set; }
        public double PriceInUSD { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="airport"></param>
        /// /// <param name="airplanes"></param>
        /// <param name="amount"></param>
        /// <param name="price"></param>
        public Refuel(DbAirports airport, DbAirplanes airplanes, TimeSpan refuelTime, double amount, double price){
            this.Airport = airport;
            this.Airplanes = airplanes;
            this.RefuelTime = refuelTime; 
            this.Amount = amount;
            this.PriceInUSD = price;
        }
    }
}
