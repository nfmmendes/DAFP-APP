using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    public class DbRequests : DbContext
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public DbCommodities DbCommodities { get; set; }
        
        [Required]
        public DateTime TimeOfRequisiton { get; set; }

        [Required]
        public DateTime TimeWindowBegin { get; set; }

        [Required]
        public DateTime TimeWindowEnd { get; set; }

        [Required]
        public DbAirports OriginAirport { get; set; }

        [Required]
        public string DestinationAirport { get; set;  }

        [Required]
        public DbInstance DbInstance { get; set; }
    }
}
