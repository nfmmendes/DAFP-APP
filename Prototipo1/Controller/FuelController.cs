using System;
using System.Collections.Generic;
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
        /// 
        /// </summary>
        /// <param name="item"></param>
        public override void Add(DbFuelPrice item){
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="IdItem"></param>
        public override void Edit(DbFuelPrice item, long IdItem){
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public override void Delete(DbFuelPrice item){
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool IsValidItem(DbFuelPrice item){
            throw new NotImplementedException();
        }
    }
}
