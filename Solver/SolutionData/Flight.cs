using System;
using System.Collections.Generic;
using SolverClientComunication.Models;
using Aiport = SolverClientComunication.Models.DbAirports;
using Passenger = SolverClientComunication.Models.DbRequests;

namespace SolutionData
{
    public class Flight{

        public long Id { get; private set; }
        private static long LastId = 0;
        public DbAirplanes Airplanes { get; set; }
        public Aiport Origin { get; set; }
        public Aiport Destination { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public double FuelOnTakeOff { get; set; }
        public double FuelOnLanding { get; set; }
        public List<Passenger> Passengers { get; set;  }
        public bool IsFull => Passengers.Count >= Airplanes.Capacity;

        public bool IsEmpty => Passengers.Count == 0;

        public Flight(){
            Id = LastId;
            LastId++; 
        }
    }
}
