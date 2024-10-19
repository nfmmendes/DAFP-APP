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
    class FuelController: AbstractController<DbFuelPrice, CustomSqlContext>{
        
        public static readonly FuelController Instance = new FuelController();

        /// <summary>
        /// Sets the object that access the database
        /// </summary>
        /// <param name="context">Object that will access the database </param>
        public override void setContext(CustomSqlContext context){
            Instance.Context = context;
        }

        /// <summary>
        /// Add element to the database 
        /// </summary>
        /// <param name="item"></param>
        public override void Add(DbFuelPrice item){
            if (IsValidItem(item)){
                Instance.Context.FuelPrices.Add(item);
                Instance.Context.SaveChanges();
            }
        }

        /// <summary>
        /// Edit a fuel price of the database (if this element is stored on database)
        /// </summary>
        /// <param name="item"></param>
        /// <param name="IdItem"></param>
        public override void Edit(DbFuelPrice item, long IdItem){
            var element = Instance.Context.FuelPrices.FirstOrDefault(x => x.Id == IdItem);

            if (element != null){
                element.Airport = item.Airport;
                element.Currency = item.Currency;
                element.Value = item.Value;

                Instance.Context.FuelPrices.Update(element);
                Instance.Context.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a fuel price of the database, if this item is stored there
        /// </summary>
        /// <param name="item">Item to the deleted</param>
        public override void Delete(DbFuelPrice item){
            if (Instance.Context.FuelPrices.Contains(item)) { 
                Instance.Context.FuelPrices.Remove(item);
                Instance.Context.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool IsValidItem(DbFuelPrice item){
            return !(item == null || item.Airport == null || string.IsNullOrEmpty(item.Currency) || string.IsNullOrEmpty(item.Value) || item.Instance ==null );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="original"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public DbFuelPrice Clone(DbFuelPrice original, DbInstance instance=null){
            DbFuelPrice newItem = new DbFuelPrice();

            newItem.Currency = original.Currency;
            newItem.Value = original.Value;

            if (instance != null)
            {

                var airport = Context.Airports.FirstOrDefault(x => x.IATA.Equals(original.Airport.IATA) && x.Instance.Id == instance.Id);

                if (airport != null)
                    newItem.Airport = airport;
                else
                {
                    var controller = new AirportController();
                    controller.setContext(Context);
                    airport = controller.Clone(original.Airport, instance);
                    newItem.Airport = airport;
                }
                newItem.Instance = instance;
            }
            else
                newItem.Airport = original.Airport;

            return newItem;
        }
    }
}
