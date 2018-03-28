using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1.Controller
{
    /// <summary>
    /// Class to control the manipulation of the data about the airports
    /// </summary>
    public class AirplaneController : AbstractController<DbAirplanes, CustomSqlContext>
    {

        public static readonly AirplaneController Instance = new AirplaneController();

        /// <summary>
        /// Sets the object that access the database
        /// </summary>
        /// <param name="context">Object that will access the database </param>
        public override void setContext(CustomSqlContext context){
            Instance.Context = context;
        }

        /// <summary>
        /// Edit a airport on database
        /// </summary>
        /// <param name="airplane">Airplane with new values</param>
        /// <param name="Id">Airplane Id</param>
        public override void Edit(DbAirplanes airplane, long Id){
            var item = Instance.Context.Airplanes.FirstOrDefault(x=>x.Id == Id);

            if (item != null){
                item.Instance = airplane.Instance;
                item.BaseAirport = airplane.BaseAirport;
                item.Model = airplane.Model;
                item.Prefix = airplane.Prefix;
                item.CruiseSpeed = airplane.CruiseSpeed;
                item.FuelConsumptionFirstHour = airplane.FuelConsumptionFirstHour;
                item.FuelConsumptionSecondHour = airplane.FuelConsumptionSecondHour;
                item.MaxFuel = airplane.MaxFuel;
                item.Range = airplane.Range;
                item.Capacity = airplane.Capacity;
                item.Weight = airplane.Weight;
                item.MaxWeight = airplane.MaxWeight;
            }
                
            
            Instance.Context.Airplanes.AddOrUpdate(item);
            Instance.Context.SaveChanges();
        }

        /// <summary>
        /// Remove a airplane on database
        /// </summary>
        /// <param name="item">Airplane to be deleted</param>
        public override void Delete(DbAirplanes item){
            throw new NotImplementedException();
        }

        /// <summary>
        ///  Add a airplane on database
        /// </summary>
        /// <param name="airplane">Item that will be added</param>
        public override void Add(DbAirplanes airplane){
            if(IsValidItem(airplane))
            Instance.Context.Airplanes.AddOrUpdate(airplane);
            Instance.Context.SaveChanges();
        }

        /// <summary>
        /// Validade a airplane object object
        /// </summary>
        /// <param name="item">Airplane object to be verified</param>
        /// <returns></returns>
        protected override bool IsValidItem(DbAirplanes item){
            if (item != null)
                return true;
            else
                return false;
        }
    }
}
