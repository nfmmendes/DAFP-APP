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
    class AirportController :  AbstractController<DbAirports, CustomSqlContext> {
        private CustomSqlContext Context { get; set; }
        public static readonly AirportController Instance = new AirportController();

        /// <summary>
        /// Set the context that will be used by the controller to do all its operations
        /// It's mandatory use this function BEFORE any operation, otherwise you'll get a null pointer like exception 
        /// </summary>
        /// <param name="context"></param>
        public override void setContext(CustomSqlContext context){
            Instance.Context = context;
        }

        /// <summary>
        /// Add a new airplane in the database
        /// </summary>
        /// <param name="airport">Airplane that will be added</param>
        public override void Add(DbAirports airport){
            if (IsValidItem(airport)){
                Instance.Context.Airports.Update(airport);
                Instance.Context.SaveChanges();
            }
        }

        /// <summary>
        /// Function to edit the information of an airport based on others airport object
        /// </summary>
        /// <param name="airport">New data</param>
        /// <param name="IdAirport">Id of the airport that will be edited</param>
        public override void Edit(DbAirports airport, long IdAirport)
        {

            var item = Instance.Context.Airports.First(x => x.Id == IdAirport);
            
            item.AirportName = airport.AirportName;
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
            

            Instance.Context.Airports.Update(item);
            Instance.Context.SaveChanges();
            
        }

        /// <summary>
        /// Remove a airport on database
        /// </summary>
        /// <param name="item">airport to be deleted</param>
        public override void Delete(DbAirports item){
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="original"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public DbAirports Clone(DbAirports original, DbInstance instance){
            var newItem = new DbAirports();

            newItem.AirportName = original.AirportName;
            newItem.Latitude = original.Latitude;
            newItem.Longitude = original.Longitude;
            newItem.IATA = original.IATA;
            newItem.Region = original.Region;
            newItem.Elevation = original.Elevation;
            newItem.RunwayLength = original.RunwayLength;
            newItem.MTOW_APE3 = original.MTOW_APE3;
            newItem.MTOW_PC12 = original.MTOW_PC12;
            newItem.LandingCost = original.LandingCost;
            newItem.GroundTime = original.GroundTime;

            if(instance!= null)
                newItem.Instance = instance;
            return newItem;
        }

        //TODO: Improve this function
        /// <summary>
        /// Function that makes the validation of a airport before it be inserted on the database
        /// </summary>
        /// <param name="item">Object verified</param>
        /// <returns></returns>
        protected override bool IsValidItem(DbAirports item){

            if (item != null){
                return !string.IsNullOrEmpty(item.AirportName) && item.Latitude != null && item.Longitude != null;

            }
            else
                return false;
        }


        
        
    }
}
