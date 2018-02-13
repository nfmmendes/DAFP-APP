using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    public class DbInstance : DbContext
    {
        public long Id { get;  set; }

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
