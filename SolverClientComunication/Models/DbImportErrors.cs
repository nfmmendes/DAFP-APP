using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    public class DbImportErrors : DbContext
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string File { get; set; }

        [Required]
        public string Sheet { get; set; }

        [Required]
        public string Message { get; set; }

        public int RowLine { get; set; }
        
        [Required]
        public DateTime ImportationHour { get; set; } 

        [Required]
        public DbInstance Instance { get; set; }
    }
}
