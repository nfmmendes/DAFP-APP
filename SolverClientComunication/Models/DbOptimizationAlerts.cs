using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
