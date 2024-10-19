using System;
using SolverClientComunication.Models;

namespace SolutionData
{
    public class Refuel{
        public DbAirport Airport { get; set; }
        public DbAirplane Airplanes { get; set; }
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
        public Refuel(DbAirport airport, DbAirplane airplanes, TimeSpan refuelTime, double amount, double price){
            this.Airport = airport;
            this.Airplanes = airplanes;
            this.RefuelTime = refuelTime; 
            this.Amount = amount;
            this.PriceInUSD = price;
        }
    }
}
