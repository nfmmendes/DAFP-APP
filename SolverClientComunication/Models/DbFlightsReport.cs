﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    public class DbFlightsReport : DbContext{
        
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
        public  TimeSpan ArrivalTime { get; set; }

        [Required]
        public virtual DbAirplanes Airplanes { get; set;}

        [Required]
        public DbInstance Instance { get; set; }

    }
}
