using System.ComponentModel.DataAnnotations;

namespace SolverClientComunication.Models
{
    public class DbPassengersOnFlightReport
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public virtual DbFlightsReport Flight { get; set; }

        [Required]
        public virtual DbRequest Passenger { get; set; }

    }
}
