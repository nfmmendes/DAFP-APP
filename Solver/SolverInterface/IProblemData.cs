﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solver.SolverInterface
{
    public interface IProblemData
    {
         Model<IProblemData> Model { get; set; }
    }
}
