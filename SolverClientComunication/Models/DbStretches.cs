using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    public class DbStretches: DbContext
     {
        [Key]
        public long Id { get;  set; }

        public string Origin { get; set; }

        public string Destination { get; set; }
        
        public long InstanceId { get; set;  }

        [Required]
        public int Distance { get; set; }

      
    }
}
