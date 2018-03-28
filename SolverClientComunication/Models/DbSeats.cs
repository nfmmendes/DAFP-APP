using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    public class DbSeats : DbContext
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public DbAirplanes Airplanes { get; set; }

        [Required]
        public string seatClass { get; set; }

        [Required]
        public double luggageWeightLimit { get; set; }
    }
}
