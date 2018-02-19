using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    class DbPassagensOnFlightReport : DbContext
    {
        [Key]
        public DbFlightsReport Flight { get; set; }

        [Key]
        public string Passenger { get; set; }

    }
}
