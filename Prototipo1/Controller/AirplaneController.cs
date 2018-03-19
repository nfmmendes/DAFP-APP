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
    public class AirplaneController{

        private CustomSqlContext Context { get; set; }
        public static readonly AirplaneController Instance = new AirplaneController();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void setContext(CustomSqlContext context){
            Instance.Context = context;
        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="airplane"></param>
        /// <param name="Id"></param>
        public void Edit(DbAirplanes airplane, long Id){
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

        public void Add(DbAirplanes airplane){
            if(IsValidItem(airplane))
            Instance.Context.Airplanes.AddOrUpdate(airplane);
            Instance.Context.SaveChanges();
        }

        private bool IsValidItem(DbAirplanes airplane){
            if (airplane != null)
                return true;
            else
                return false; 
        }
    }
}
