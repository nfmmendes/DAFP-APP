using System.ComponentModel.DataAnnotations;

namespace SolverClientComunication.Models
{
    public class DbSeat
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public virtual DbAirplane Airplanes { get; set; }

        [Required]
        public string seatClass { get; set; }

        [Required]
        public double luggageWeightLimit { get; set; }
    }
}
