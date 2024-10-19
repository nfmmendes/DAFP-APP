using System.ComponentModel.DataAnnotations;

namespace SolverClientComunication.Models
{
    public class DbStretch
    {
        [Key]
        public long Id { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public long InstanceId { get; set; }

        [Required]
        public int Distance { get; set; }


    }
}
