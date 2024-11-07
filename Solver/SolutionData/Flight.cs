using System;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib;
using SolverClientComunication.Models;
using Aiport = SolverClientComunication.Models.DbAirport;
using Passenger = SolverClientComunication.Models.DbRequest;

namespace SolutionData
{
    public class Flight{

        private double fuelOnTakeOff;
        private double fuelOnLanding;

        public long Id { get; private set; }
        private static long LastId = 0;
        public DbAirplane Airplanes { get; set; }
        public Aiport Origin { get; set; }
        public Aiport Destination { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public double FuelOnTakeOff
        {
            get
            {
                return fuelOnTakeOff;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentException("It is not allowed to set a negative value to this property");
                fuelOnTakeOff = value;
            }
        }

        public double FuelOnLanding {
            get {
                return fuelOnLanding;
            }

            set
            {
                if (value < 0)
                    throw new ArgumentException("It is not allowed to set a negative value to this property");

                value = fuelOnLanding;
            }
        }
        public List<Passenger> Passengers { get; set;  }
        public bool IsFull => Passengers.Count >= Airplanes.Capacity;

        public bool IsEmpty => Passengers.Count == 0;

        public Flight(){
            Id = LastId;
            LastId++; 
        }
    }
}
