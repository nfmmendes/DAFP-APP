using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolverClientComunication;

namespace Prototipo1.Controller
{
    /// <summary>
    /// Class that defines a general structure of a control in this project
    /// </summary>
    /// <typeparam name="IDbContext">The class that is used to access the database</typeparam>
    /// <typeparam name="ISQLContex">The class represents the data model of that control</typeparam>
    public abstract class AbstractController<IDbContext, ISQLContex>{
        
        protected ISQLContex Context { get; set; }                  //< Object to access the database
        public abstract void setContext(ISQLContex context);        //< Sets the object that access the database
        public abstract void Add(IDbContext item);                  //< Add a item on database
        public abstract void Edit(IDbContext item, long IdItem);    //< Edit a item on database
        public abstract void Delete(IDbContext item);               //< Remove a item on database
        protected abstract bool IsValidItem(IDbContext item);       //< Verify if a item is valid regarding the validation criteria of the model
    }
}
