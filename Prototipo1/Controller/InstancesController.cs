using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1.Controller
{
    class InstancesController
    {
        private CustomSqlContext Context { get; set; }
        public static readonly InstancesController Instance = new InstancesController();

        public void setContext(CustomSqlContext context){
            Instance.Context = context; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public void AddInstance(string name, string description = ""){
            var solverInstance = new DbInstance()
            {
                CreatedOn = DateTime.Now,
                Description = !string.IsNullOrEmpty(description)? description: "",
                Name = name,
                LastOptimization = DateTime.Now, //TODO : Change to nullable  
                Optimized = false
            };
            Instance.Context.Instances.Add(solverInstance);
            Instance.Context.SaveChanges();

            ParametersController.Instance.setContext(Context);
            ParametersController.Instance.setDefaultParameters(solverInstance);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instanceId"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public void EditInstance(long instanceId, string name, string description){
            var entity = Instance.Context.Instances.FirstOrDefault(x => x.Id == instanceId);
            if (entity != null){
                entity.Name = name;
                entity.Description = description;
            }
            Instance.Context.Instances.AddOrUpdate(entity);
            Instance.Context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void FindAndDeleteByName(string name)
        {
            var deleted = Instance.Context.Instances.FirstOrDefault(x => x.Name.Equals(name));
            if (deleted != null){
                Instance.Context.Instances.Remove(deleted);
                Instance.Context.Parameters.RemoveRange(Instance.Context.Parameters.Where(x => x.Instance.Id.Equals(deleted.Id)));
            } 
            Instance.Context.SaveChanges();
        }
    }
}
