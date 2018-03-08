using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
