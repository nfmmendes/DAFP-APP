using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    class DbFlightsReport : DbContext{
        
        [Key]
        public long Id { get; set; }

        [Required]
        public DbAirports Origin { get; set; }

        [Required]
        public DbAirports Destination { get; set; }

        [Required]
        public TimeSpan DepartureTime { get; set; }

        [Required]
        public  TimeSpan ArrivalTime { get; set; }

        [Required]
        public DbAirplane Airplane { get; set;}

    }
}
