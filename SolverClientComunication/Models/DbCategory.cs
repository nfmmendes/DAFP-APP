using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    public class DbCategory : DbContext
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; private set; }

    }
}
