﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Models
{
    public class DbParameters
    {
        [Key]
        public long Id { get; set; }
        
        [Required]
        public string Code { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        public DbInstance Instance { get; set; }
    }
}
