using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolverClientComunication;

namespace Prototipo1.Controller
{
    class FuelController{
        private CustomSqlContext Context { get; set; }
        public static readonly FuelController Instance = new FuelController();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void setContext(CustomSqlContext context){
            Instance.Context = context;
        }
    }
}
