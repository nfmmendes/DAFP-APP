using System.ComponentModel.DataAnnotations;

namespace SolverClientComunication.Models
{
    public class DbParameter
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public DbInstance Instance { get; set; }
    }
}
