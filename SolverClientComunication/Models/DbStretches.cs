using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    public class DbStretches: DbContext
     {
        [Key]
        public long Id { get;  set; }

        [Key]
        public DbAirports Origin { get; set; }

        [Key]
        public DbAirports Destination { get; set; }

        [Required]
        public int Distance { get; set; }

      
    }
}
