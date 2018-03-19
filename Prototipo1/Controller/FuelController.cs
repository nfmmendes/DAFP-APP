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
        private CustomSqlContext Context { get; set; }
        public static readonly FuelController Instance = new FuelController();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void setContext(CustomSqlContext context){
            Instance.Context = context;
        }

        /// <summary>
        /// Add element to the database 
        /// </summary>
        /// <param name="item"></param>
        public override void Add(DbFuelPrice item){
            if (IsValidItem(item)){
                Instance.Context.FuelPrice.Add(item);
                Instance.Context.SaveChanges();
            }
        }

        /// <summary>
        /// Edit a element of the database (if this element is stored on database)
        /// </summary>
        /// <param name="item"></param>
        /// <param name="IdItem"></param>
        public override void Edit(DbFuelPrice item, long IdItem){
            var element = Instance.Context.FuelPrice.FirstOrDefault(x => x.Id == IdItem);

            if (element != null){
                element.Airport = item.Airport;
                element.Currency = item.Currency;
                element.Value = item.Value;

                Instance.Context.FuelPrice.AddOrUpdate(element);
                Instance.Context.SaveChanges();
            }
        }

        /// <summary>
        /// Delete a item of the database, if this item is stored there
        /// </summary>
        /// <param name="item">Item to the deleted</param>
        public override void Delete(DbFuelPrice item){
            if (Instance.Context.FuelPrice.Contains(item)) { 
                Instance.Context.FuelPrice.Remove(item);
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
    }
}
