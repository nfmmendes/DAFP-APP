using System;
using System.ComponentModel.DataAnnotations;

namespace SolverClientComunication.Models
{
    public class DbRequests
    {
        [Key]
        public long Id { get; set; }

        public string Name { get; set; }

        [Required]
        public string PNR { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public bool IsChildren { get; set; }

        [Required]
        public TimeSpan DepartureTimeWindowBegin { get; set; }

        [Required]
        public TimeSpan DepartureTimeWindowEnd { get; set; }

        [Required]
        public TimeSpan ArrivalTimeWindowBegin { get; set; }

        [Required]
        public TimeSpan ArrivalTimeWindowEnd { get; set; }

        [Required]
        public virtual DbAirports Origin { get; set; }

        [Required]
        public virtual DbAirports Destination { get; set; }

        [Required]
        public DbInstance Instance { get; set; }
    }
}
