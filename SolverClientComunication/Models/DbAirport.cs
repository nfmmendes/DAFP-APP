using System;
using System.ComponentModel.DataAnnotations;

namespace SolverClientComunication.Models
{
    [Serializable]
    public class DbAirport
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string AirportName { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }

        [MaxLength(6)]
        public string IATA { get; set; }

        [MaxLength(25)]
        public string Region { get; set; }

        [Range(-1, 20000)]
        public int Elevation { get; set; }

        public int RunwayLength { get; set; }

        public int MTOW_APE3 { get; set; }

        public int MTOW_PC12 { get; set; }

        public int LandingCost { get; set; }

        public TimeSpan GroundTime { get; set; }

        [Required]
        public DbInstance Instance { get; set; }


    }
}
