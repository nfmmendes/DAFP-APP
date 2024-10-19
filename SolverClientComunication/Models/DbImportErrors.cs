using System;
using System.ComponentModel.DataAnnotations;

namespace SolverClientComunication.Models
{
    public class DbImportErrors
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
