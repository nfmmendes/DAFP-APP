using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    [Serializable]
    class DbAirplane : DbContext
    {

        public long Id { get;  set; }

        [Required, MaxLength(25)]
        public string Prefix { get;  set; }

        [Required]
        public DbAirplaneModel Model { get; set;  }

        [Required, Range(0,Double.PositiveInfinity)]
        public double Capacity { get; set; }

        public DbInstance DbInstance { get;  set; }
    }
}
