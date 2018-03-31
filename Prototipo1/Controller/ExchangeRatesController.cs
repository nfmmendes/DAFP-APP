﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1.Controller
{
    class ExchangeRatesController : AbstractController<DbExchangeRates, CustomSqlContext> {

        public static readonly ExchangeRatesController Instance = new ExchangeRatesController();

        /// <summary>
        /// Sets the object that access the database
        /// </summary>
        /// <param name="context">Object that will access the database </param>
        public override void setContext(CustomSqlContext context){
            Instance.Context = context;

        }

        /// <summary>
        ///  Add an exchange rate on database
        /// </summary>
        /// <param name="airplane">Exchange rate that will be added</param>
        public override void Add(DbExchangeRates item){
            if (IsValidItem(item)){
                Instance.Context.Exchange.Add(item);
                Instance.Context.SaveChanges();
            }

        }

        /// <summary>
        /// Edit an exchange rate on database
        /// </summary>
        /// <param name="airplane">Item with new values</param>
        /// <param name="Id">Exchange rate Id</param>
        public override void Edit(DbExchangeRates item, long IdItem){
            var element = Instance.Context.Exchange.FirstOrDefault(x=>x.Id == IdItem);

            if (element != null){
                element.CurrencyName = item.CurrencyName;
                element.CurrencySymbol = item.CurrencySymbol;
                element.ValueInDolar = item.ValueInDolar;

                Instance.Context.Exchange.AddOrUpdate(element);
                Instance.Context.SaveChanges();
            }
            
        }

        /// <summary>
        /// Remove an exchange rate on database
        /// </summary>
        /// <param name="item">Exchange rate to be deleted</param>
        public override void Delete(DbExchangeRates item){
            if (Context.Exchange.Contains(item))
                Context.Exchange.Remove(item);
        }

        /// <summary>
        /// Function that verify if the exchange rate object has coditions to be inserted on the database
        /// </summary>
        /// <param name="item"></param>
        /// <returns>Returns true if the item is valid and false otherwise</returns>
        protected override bool IsValidItem(DbExchangeRates item){
            return ! (item == null || string.IsNullOrEmpty(item.CurrencyName) || string.IsNullOrEmpty(item.CurrencySymbol) );
        }
    }
}
