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
        public string Codigo { get;  set; }
        public double Weight { get;  set; }
        public int CategoryId { get;  set; }
        public DbCategory DbCategory { get; set; }
    }
}
