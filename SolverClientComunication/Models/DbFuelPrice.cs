using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    public class DbFuelPrice : DbContext
    {
        [Key]
        public long Id { get; set; }
    
        [Required]
        public virtual DbAirports Airport { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public DbInstance Instance { get; set; }

    }
}
