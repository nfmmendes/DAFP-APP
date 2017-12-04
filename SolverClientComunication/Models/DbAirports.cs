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
    public class DbAirports : DbContext
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public char LatitudeHemisphere { get; set; }

        [Required]
        public char LongitudeHemisphere { get; set; }
        
        [Required, Range(0,90)]
        public double Latitude { get; set; }

        [Required, Range(0,180)]
        public double Longitude { get; set; }

        [Required,MaxLength(6)]
        public string Prefix { get; set; }

        [Required,MaxLength(25)]
        public string City { get; set; }

        [MaxLength(55)]
        public string Name { get; set; }
        public Time Openning { get; set; }
        public Time Closing { get; set;  }

        [Range(0,5000)]
        public int MaxFlightsPerHour { get; set; }
        public DbInstance DbInstance { get; private set; }
        

    }
}
