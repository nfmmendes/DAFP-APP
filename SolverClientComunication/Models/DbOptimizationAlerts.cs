using System.ComponentModel.DataAnnotations;

namespace SolverClientComunication.Models
{
    public class DbOptimizationAlerts
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Type { get; set; }

        public string Table { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public virtual DbInstance Instance { get; set; }

    }
}
