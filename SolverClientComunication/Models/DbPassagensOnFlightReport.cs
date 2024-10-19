using System.ComponentModel.DataAnnotations;

namespace SolverClientComunication.Models
{
    public class DbPassagensOnFlightReport
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public virtual DbFlightsReport Flight { get; set; }

        [Required]
        public virtual DbRequests Passenger { get; set; }

    }
}
