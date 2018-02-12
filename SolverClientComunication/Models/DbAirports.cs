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
        public string AiportName { get; set; }

        [Required]
        public char LatitudeHemisphere { get; set; }

        [Required]
        public char LongitudeHemisphere { get; set; }
        
        [Required, Range(0,90)]
        public double Latitude { get; set; }

        [Required, Range(0,180)]
        public double Longitude { get; set; }

        [MaxLength(6) ]
        public string ICAO { get; set; }

        [MaxLength(25)]
        public string Region { get; set; }

        [Range(0,20000)]
        public int Elevation { get; set; }

        public int RunwayLength { get; set; }

        public int MTOW_APE3 { get; set; }

        public int MTOW_PC12 { get; set; }

        public int LandingCost { get; set; }

        public DateTime GroundTime { get;set;}

        public DbInstance Instance { get;  set; }
        

    }
}
