using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace SolverClientComunication.Models
{
    public class DbReportList : DbContext
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        public string TableName { get; set; }

        [Required]
        public string ReportLabel { get; private set; }


    }
}
