using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SolverClientComunication.Models
{
    public class DbSeats : DbContext
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public virtual DbAirplanes Airplanes { get; set; }

        [Required]
        public string seatClass { get; set; }

        [Required]
        public double luggageWeightLimit { get; set; }
    }
}
