using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    [Serializable]
    class DbAirplaneModel
    {
        [Key]
        public long Id { get; private set; }

        [Required]
        public string Code { get; private set; }
    }
}
