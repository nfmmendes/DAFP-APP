using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1.Controller
{
    class AirportController {
        private CustomSqlContext Context { get; set; }
        public static readonly AirportController Instance = new AirportController();

        /// <summary>
        /// Set the context that will be used by the controller to do all its operations
        /// It's mandatory use this function BEFORE any operation, otherwise you'll get a null pointer like exception 
        /// </summary>
        /// <param name="context"></param>
        public  void setContext(CustomSqlContext context){
            Instance.Context = context;
        }

        /// <summary>
        /// Add a new airplane in the database
        /// </summary>
        /// <param name="airport">Airplane that will be added</param>
        public  void Add(DbAirports airport){
            if (IsValidAirport(airport)){
                Instance.Context.Airports.AddOrUpdate(airport);
                Instance.Context.SaveChanges();
            }
        }

        /// <summary>
        /// Function to edit the information of an airport based on others airport object
        /// </summary>
        /// <param name="airport">New data</param>
        /// <param name="IdAirport">Id of the airport that will be edited</param>
        public  void Edit(DbAirports airport, long IdAirport)
        {

            var item = Instance.Context.Airports.First(x => x.Id == IdAirport);
            
            item.AiportName = airport.AiportName;
            item.IATA = airport.IATA;
            item.Region = airport.Region;
            item.Elevation = airport.Elevation;
            item.Instance = airport.Instance;
            item.GroundTime = airport.GroundTime;
            item.MTOW_APE3 = airport.MTOW_APE3;
            item.MTOW_PC12 = airport.MTOW_PC12;
            item.LandingCost = airport.LandingCost;
            item.RunwayLength = airport.RunwayLength;
            item.Latitude = airport.Latitude;
            item.Longitude = airport.Longitude;
            item.Id = IdAirport;
            

            Instance.Context.Airports.AddOrUpdate(item);
            Instance.Context.SaveChanges();
            
        }



        //TODO: Improve this function
        /// <summary>
        /// Function that makes the validation of a airport before it be inserted on the database
        /// </summary>
        /// <param name="airport">Object verified</param>
        /// <returns></returns>
        private bool IsValidAirport(DbAirports airport){
            if (airport != null) { 
                return !string.IsNullOrEmpty(airport.AiportName) && airport.Latitude != null && airport.Longitude != null;
                
            }else 
                return false;
        }
    }
}
