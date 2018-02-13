using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    public class DbRequests : DbContext
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public bool IsChildren { get; set; }
        
        [Required]
        public DateTime TimeOfRequisiton { get; set; }

        [Required]
        public DateTime DepartureTimeWindowBegin { get; set; }

        [Required]
        public DateTime DepartureTimeWindowEnd { get; set; }

        [Required]
        public DateTime ArrivalTimeWindowBegin { get; set; }

        [Required]
        public DateTime ArrivalTimeWindowEnd { get; set; }

        [Required]
        public DbStretches Stretch { get; set; }

        [Required]
        public DbInstance DbInstance { get; set; }
    }
}
