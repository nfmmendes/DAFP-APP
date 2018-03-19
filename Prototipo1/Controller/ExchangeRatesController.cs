using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1.Controller
{
    class ExchangeRatesController : AbstractController<DbExchangeRates, CustomSqlContext> {

        public override void setContext(CustomSqlContext context)
        {
            throw new NotImplementedException();
        }

        public override void Add(DbExchangeRates item)
        {
            throw new NotImplementedException();
        }

        public override void Edit(DbExchangeRates item, long IdItem)
        {
            throw new NotImplementedException();
        }

        public override void Delete(DbExchangeRates item)
        {
            throw new NotImplementedException();
        }

        protected override bool IsValidItem(DbExchangeRates item)
        {
            throw new NotImplementedException();
        }
    }
}
