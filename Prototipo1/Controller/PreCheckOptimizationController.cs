using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1.Controller
{
    class PreCheckOptimizationController : AbstractController<DbOptimizationAlerts,CustomSqlContext>{
        public override void setContext(CustomSqlContext context)
        {
            throw new NotImplementedException();
        }

        public override void Add(DbOptimizationAlerts item)
        {
            throw new NotImplementedException();
        }

        public override void Edit(DbOptimizationAlerts item, long IdItem)
        {
            throw new NotImplementedException();
        }

        public override void Delete(DbOptimizationAlerts item)
        {
            throw new NotImplementedException();
        }

        protected override bool IsValidItem(DbOptimizationAlerts item)
        {
            throw new NotImplementedException();
        }
    }
}
