using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    [Serializable]
    public class DbAirports : DbContext
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string AirportName { get; set; }
        
        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }

        [MaxLength(6) ]
        public string IATA { get; set; }

        [MaxLength(25)]
        public string Region { get; set; }

        [Range(-1,20000)]
        public int Elevation { get; set; }

        public int RunwayLength { get; set; }

        public int MTOW_APE3 { get; set; }

        public int MTOW_PC12 { get; set; }

        public int LandingCost { get; set; }

        public TimeSpan GroundTime { get;set;}

        [Required]
        public DbInstance Instance { get;  set; }
        

    }
}
