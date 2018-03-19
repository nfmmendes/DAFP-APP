using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolverClientComunication;

namespace Prototipo1.Controller
{
    public abstract class AbstractController<IDbContext, ISQLContex>{
        protected ISQLContex Context { get; set; }
        public abstract void setContext(ISQLContex context);
        public abstract void Add(IDbContext item);
        public abstract void Edit(IDbContext item, long IdItem);
        public abstract void Delete(IDbContext item);
        protected abstract bool IsValidItem(IDbContext item);
    }
}
