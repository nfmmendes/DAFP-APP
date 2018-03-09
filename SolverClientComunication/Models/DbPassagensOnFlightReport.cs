using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    public class DbPassagensOnFlightReport : DbContext
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public DbFlightsReport Flight { get; set; }

        [Required]
        public DbRequests Passenger { get; set; }

    }
}
