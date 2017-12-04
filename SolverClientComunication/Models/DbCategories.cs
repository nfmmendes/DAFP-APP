using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    public class DbCategories : DbContext
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Code { get;  set; }

        public DbInstance Instance { get;  set; }
    }
}
