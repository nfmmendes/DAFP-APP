using System;
using System.ComponentModel.DataAnnotations;

namespace SolverClientComunication.Models
{
    public class DbExchangeRates
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string CurrencyName { get; set; }

        public string CurrencySymbol { get; set; }

        [Required]
        public Double ValueInDolar { get; set; }

        [Required]
        public DbInstance Instance { get; set; }
    }
}
