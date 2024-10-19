using System;
using System.ComponentModel.DataAnnotations;

namespace SolverClientComunication.Models
{
    public class DbRefuelsReport
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public DbInstance Instance { get; set; }

        [Required]
        public DbAirports Airport { get; set; }

        [Required]
        public DbAirplanes Airplanes { get; set; }

        [Required]
        public TimeSpan RefuelTime { get; set; }

        [Required]
        public double Amount { get; set; }
    }
}
