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
    class InstancesController :AbstractController<DbInstance, CustomSqlContext>
    {
        
        public static readonly InstancesController Instance = new InstancesController();

        /// <summary>
        /// Sets the object that access the database
        /// </summary>
        /// <param name="context">Object that will access the database </param>
        public override void setContext(CustomSqlContext context){
            Instance.Context = context; 
        }

        /// <summary>
        /// Add a new instance on the database
        /// </summary>
        /// <param name="item">Instance object that will be inserted</param>
        public override void Add(DbInstance item){
            Instance.Add(item.Name,item.Description);
        }

        /// <summary>
        /// Edit an instance 
        /// </summary>
        /// <param name="item">Instance that will be edited, already with the new values</param>
        /// <param name="IdItem">Id of the instance</param>
        public override void Edit(DbInstance item, long IdItem){
            Instance.Edit(IdItem, item.Name, item.Description);
        }

        /// <summary>
        /// Delete an instance
        /// </summary>
        /// <param name="item"></param>
        public override void Delete(DbInstance item)
        {
            //TODO: Pass the delete procedure to this function
            throw new NotImplementedException();
        }

        /// <summary>
        /// Verify if an instance object is valid to be in the database 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        protected override bool IsValidItem(DbInstance item){
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create and add an instance on database based on a name and a description
        /// </summary>
        /// <param name="name">Name of the instance</param>
        /// <param name="description">Description of the instance (Optional)</param>
        public void Add(string name, string description = ""){
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
        /// Edit an instance given a its Id
        /// </summary>
        /// <param name="instanceId">Id of the instance that will be edited</param>
        /// <param name="name">New name of the instance</param>
        /// <param name="description">New description of the instance </param>
        public void Edit(long instanceId, string name, string description){
            var entity = Instance.Context.Instances.FirstOrDefault(x => x.Id == instanceId);
            if (entity != null){
                entity.Name = name;
                entity.Description = description;
            }
            Instance.Context.Instances.AddOrUpdate(entity);
            Instance.Context.SaveChanges();
        }

        /// <summary>
        /// This function, given a instance name, finds and deletes it 
        /// </summary>
        /// <param name="name"></param>
        public void FindAndDeleteByName(string name)
        {
            var deleted = Instance.Context.Instances.FirstOrDefault(x => x.Name.Equals(name));
            if (deleted != null){

                Instance.Context.Configuration.AutoDetectChangesEnabled = false;
                Instance.Context.Stretches.RemoveRange(Instance.Context.Stretches.ToList().Where(x => x.InstanceId == deleted.Id));
                Instance.Context.SaveChanges();
                Instance.Context.Configuration.AutoDetectChangesEnabled = true;

                //TODO: Remove it. It's wrong 
                Instance.Context.PassagersOnFlight.RemoveRange(
                    Instance.Context.PassagersOnFlight.Where(x => x.Flight.Instance.Id == deleted.Id).ToList());
                Instance.Context.FlightsReports.RemoveRange(Instance.Context.FlightsReports.Where(x=>x.Instance.Id == deleted.Id).ToList());
                

                Instance.Context.SaveChanges();

                Instance.Context.Instances.Remove(deleted);
                
            } 
            Instance.Context.SaveChanges();
        }

        /// <summary>
        /// Copy all the information of a instance to another, except the metadata
        /// </summary>
        /// <param name="instance">Source instance</param>
        /// <param name="newInstance">Destination instance</param>
        public void CopyInstance(DbInstance previousInstance, DbInstance newInstance){
            //TODO: Implement
        }
    }
}
