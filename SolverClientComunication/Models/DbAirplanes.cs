using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    [Serializable]
    public class DbAirplanes : DbContext
    {
        [Key]
        public long Id { get;  set; }

        [Required, MaxLength(25)]
        public string Prefix { get;  set; }

        [Required]
        public int Range { get; set; }

        [Required]
        public int Weight { get; set; }

        [Required]
        public int MaxWeight { get; set; }

        [Required]
        public int FuelConsumptionFirstHour { get; set; }

        [Required]
        public int FuelConsumptionSecondHour { get; set; }

        [Required]
        public double CruiseSpeed { get; set; }

        [Required]
        public double MaxFuel { get; set;  }

        public string Model { get; set;  }

        [Required, Range(0,Double.PositiveInfinity)]
        public double Capacity { get; set; }

        public DbAirports BaseAirport { get; set; }

        [Required]
        public DbInstance Instance { get;  set; }
    }
}
