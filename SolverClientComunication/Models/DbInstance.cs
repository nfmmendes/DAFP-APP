using System;
using System.ComponentModel.DataAnnotations;

namespace SolverClientComunication.Models
{
    public class DbInstance
    {
        public long Id { get; set; }

        [MaxLength(15)]
        public string Name { get; set; }

        [MaxLength(40)]
        public string Description { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }
        public DateTime? LastOptimization { get; set; }

        [Required]
        public bool Optimized { get; set; }
    }
}
