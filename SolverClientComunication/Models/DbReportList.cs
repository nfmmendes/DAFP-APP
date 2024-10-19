using System.ComponentModel.DataAnnotations;

namespace SolverClientComunication.Models
{
    public class DbReportList
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string TableName { get; set; }

        [Required]
        public string ReportLabel { get; private set; }


    }
}
