using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    public class DbClusterRequests : DbContext
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public DbSet<DbCommodities> DbCommodities { get; set; }

        [Required]
        public DateTime TimeOfRequisiton { get; set; }

        [Required]
        public DateTime TimeWindowBegin { get; set; }

        [Required]
        public DateTime TimeWindowEnd { get; set; }

        [Required]
        public DbStretches Stretch { get; set; }

        [Required]
        public DbInstance DbInstance { get; set; }
    }
}
