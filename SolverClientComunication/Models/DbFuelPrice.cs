using System.ComponentModel.DataAnnotations;

namespace SolverClientComunication.Models
{
    public class DbFuelPrice
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public virtual DbAirports Airport { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public DbInstance Instance { get; set; }

    }
}
