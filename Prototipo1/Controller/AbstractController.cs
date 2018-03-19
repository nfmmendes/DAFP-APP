using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolverClientComunication;

namespace Prototipo1.Controller
{
    abstract class AbstractController{
        protected CustomSqlContext Context { get; set; }
        public abstract void setContext(CustomSqlContext context);
        public abstract void Add(DbContext item);
        public abstract void Edit(DbContext item, long IdItem);
        public abstract void Delete(DbContext item);
        public abstract bool isValidItem(DbContext item);
    }
}
