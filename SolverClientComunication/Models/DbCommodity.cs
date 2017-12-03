using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    public class DbCommodity : DbContext
    {
        [Key]
        public long Id { get; set; }

        [Required,MaxLength(64)]
        public string Codigo { get;  set; }

        [Required, Range(0,Double.MaxValue)]
        public double Weight { get;  set; }

        public DbCategory DbCategory { get; set; }
        public DbInstance DbInstance { get; set; }
    }
}
