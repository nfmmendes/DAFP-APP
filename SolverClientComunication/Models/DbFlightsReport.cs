using System;
using System.ComponentModel.DataAnnotations;

namespace SolverClientComunication.Models
{
    public class DbFlightsReport
    {

        [Key]
        public long Id { get; set; }

        [Required]
        public virtual DbAirports Origin { get; set; }

        [Required]
        public virtual DbAirports Destination { get; set; }

        [Required]
        public double FuelOnDeparture { get; set; }

        [Required]
        public double FuelOnArrival { get; set; }


        [Required]
        public TimeSpan DepartureTime { get; set; }

        [Required]
        public TimeSpan ArrivalTime { get; set; }

        [Required]
        public virtual DbAirplanes Airplanes { get; set; }

        [Required]
        public DbInstance Instance { get; set; }

    }
}
