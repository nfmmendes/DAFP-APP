using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    class DbExchangeRates
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string CurrencyName { get; set; }

        public string CurrencySymbol { get; set; }

        [Required]
        public Decimal ValueInDolar { get; set; }

        public DbInstance Scenario { get; set; }
    }
}
