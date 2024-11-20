using SolverClientComunication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolverClientComunication.Enums.Excel
{
    /// <summary>
    /// Enum to hold the column indexes of the Airport sheet. 
    /// </summary>
    public enum AirportColumnsEnum
    {
        AiportName,
        IataCode,
        Latitude,
        Longitude,
        Elevation,
        RunwayLength,
        Region,
        Mtow_Ape3,
        Mtow_pc12,
        GroundTime,
        LandingCost
    }
}
