﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using SolverClientComunication;
using SolverClientComunication.Models;
using SolverClientComunication.Enums;

namespace Prototipo1.Controller
{
    //TODO: Evaluate if it possible to put this class as a derived from the AbstractController class 
    /// <summary>
    /// Control the optimization parameters of the instances
    /// </summary>
    class ParametersController
    {
        private CustomSqlContext Context { get; set; }
        public static readonly ParametersController Instance = new ParametersController();

        private Dictionary<ParametersEnum, string> DefaultParameters { get; set;  }

        /// <summary>
        /// Set the default values of the optimization parameters
        /// </summary>
        private ParametersController()
        {
            DefaultParameters = new Dictionary<ParametersEnum, string>();
            DefaultParameters[ParametersEnum.USE_TIME_WINDOWS] = "true";
            DefaultParameters[ParametersEnum.PICK_ALL] = "true";
            DefaultParameters[ParametersEnum.DELIVER_ALL] = "true";
            DefaultParameters[ParametersEnum.START_FROM_DEPOT] = "true";
            DefaultParameters[ParametersEnum.COME_BACK_TO_DEPOT] = "true";
            DefaultParameters[ParametersEnum.AVERAGE_MEN_WEIGHT] = "75";
            DefaultParameters[ParametersEnum.AVERAGE_WOMEN_WEIGHT] = "65";
            DefaultParameters[ParametersEnum.AVERAGE_CHILDREN_WEIGHT] = "30";
            DefaultParameters[ParametersEnum.TIME_LIMIT] = "45";
            DefaultParameters[ParametersEnum.SUNRISE_TIME] = "6:15";
            DefaultParameters[ParametersEnum.SUNSET_TIME] = "18:15";
        }

        /// <summary>
        /// Sets the object that access the database
        /// </summary>
        /// <param name="context">Object that will access the database </param>
        public void setContext(CustomSqlContext context){
            Instance.Context = context;
        }

        /// <summary>
        /// Set the default parameters values of an instance
        /// </summary>
        /// <param name="solverInstance"></param>
        public void setDefaultParameters(DbInstance solverInstance)
        {
            var newParameters = new List<DbParameter>();
            long id = Instance.Context.Parameters.Any() ? Instance.Context.Parameters.Max(x => x.Id) + 1 : 0;
            foreach (var key in DefaultParameters.Keys)
                newParameters.Add(new DbParameter(){ Code = key.DbCode, Instance = solverInstance, Value = DefaultParameters[key]});

            Instance.Context.Parameters.AddRange(newParameters);

            try{
                Instance.Context.SaveChanges();
            }catch (DbEntityValidationException e){
                ShowErros(e);
                throw;
            }
        }

        /// <summary>
        /// Change the parameters values of an instancce 
        /// </summary>
        /// <param name="instance">Instance that will be its parameters changed</param>
        /// <param name="useTimeWindows">If the time windows (to departure and arrival) will be used</param>
        /// <param name="pickAll"> If all the passengers MUST be picked on origin</param>
        /// <param name="deliverAll">If all the passengers MUST be delivered on the destination</param>
        /// <param name="startFromDepot">Make the airplanes starts the route from the airplane base </param>
        /// <param name="comebackToDepot">If the airplane need to come back to the airplane base in the end of the day</param>
        /// <param name="averageWeightMan">The average weight of men</param>
        /// <param name="averageWeightWoman">The average weight of women</param>
        /// <param name="averageChildWeight">The average weight of Child</param>
        /// <param name="timeLimit">Maximum time to the algorithm rum</param>
        public void UpdateInstanceParameters(DbInstance instance, bool useTimeWindows, bool pickAll = true, bool deliverAll = true,
                                       bool startFromDepot = true, bool comebackToDepot = true, int averageWeightMan = 75,
                                       int averageWeightWoman = 65, int averageChildWeight = 30, int timeLimit = 45, string sunrise = "6:15", string sunset = "18:15")
        {
            var insId = instance.Id;
            var Parameters = Instance.Context.Parameters;
            var boolToString = (bool value) => value ? "true" : "false";
            
            var parameters = Parameters.Where(x => insId == x.Instance.Id).ToList();

            var newValueByType = new Dictionary<string, string>()
            {
                { ParametersEnum.USE_TIME_WINDOWS.DbCode, boolToString(useTimeWindows)},
                { ParametersEnum.PICK_ALL.DbCode, boolToString(pickAll)},
                { ParametersEnum.DELIVER_ALL.DbCode, boolToString(deliverAll) },
                { ParametersEnum.START_FROM_DEPOT.DbCode, boolToString(startFromDepot) },
                { ParametersEnum.COME_BACK_TO_DEPOT.DbCode, boolToString(comebackToDepot) },
                { ParametersEnum.AVERAGE_MEN_WEIGHT.DbCode, averageWeightMan.ToString() },
                { ParametersEnum.AVERAGE_WOMEN_WEIGHT.DbCode, averageWeightWoman.ToString() },
                { ParametersEnum.TIME_LIMIT.DbCode, timeLimit.ToString() },
                { ParametersEnum.SUNRISE_TIME.DbCode, sunrise },
                { ParametersEnum.SUNSET_TIME.DbCode, sunset },
            };

            foreach (var param in parameters)
            {
                UpdateAndSave(param, newValueByType[param.Code]);
            }

        }

        /// <summary>
        /// Update all the parameters of all instances 
        /// </summary>
        /// <param name="useTimeWindows">If the time windows (to departure and arrival) will be used</param>
        /// <param name="pickAll"> If all the passengers MUST be picked on origin</param>
        /// <param name="deliverAll">If all the passengers MUST be delivered on the destination</param>
        /// <param name="startFromDepot">Make the airplanes starts the route from the airplane base </param>
        /// <param name="comebackToDepot">If the airplane need to come back to the airplane base in the end of the day</param>
        /// <param name="averageWeightMan">The average weight of men</param>
        /// <param name="averageWeightWoman">The average weight of women</param>
        /// <param name="averageChildWeight">The average weight of Child</param>
        /// <param name="timeLimit">Maximum time to the algorithm rum</param>
        public void UpdateAllInstances(bool useTimeWindows, bool pickAll = true, bool deliverAll = true, bool startFromDepot = true,
                                       bool comebackToDepot = true, int averageWeightMan = 75, int averageWeightWoman = 65,
                                       int averageChildWeight = 30, int timeLimit = 45, string sunrise = "6:15", string sunset = "18:15")
        {

            var parameters = Context.Parameters.ToList();
            var boolToString = (bool value) => value ? "true" : "false";
            

            var newValueByType = new Dictionary<string, string>()
            {
                { ParametersEnum.USE_TIME_WINDOWS.DbCode, boolToString(useTimeWindows)},
                { ParametersEnum.PICK_ALL.DbCode, boolToString(pickAll)},
                { ParametersEnum.DELIVER_ALL.DbCode, boolToString(deliverAll) },
                { ParametersEnum.START_FROM_DEPOT.DbCode, boolToString(startFromDepot) },
                { ParametersEnum.COME_BACK_TO_DEPOT.DbCode, boolToString(comebackToDepot) },
                { ParametersEnum.AVERAGE_MEN_WEIGHT.DbCode, averageWeightMan.ToString() },
                { ParametersEnum.AVERAGE_WOMEN_WEIGHT.DbCode, averageWeightWoman.ToString() },
                { ParametersEnum.TIME_LIMIT.DbCode, timeLimit.ToString() },
                { ParametersEnum.SUNRISE_TIME.DbCode, sunrise },
                { ParametersEnum.SUNSET_TIME.DbCode, sunset },
            };

            foreach (var param in parameters)
            {
                UpdateAndSave(param, newValueByType[param.Code]);
            }
        }

        /// <summary>
        /// Update the value of a parameter and save it on the database 
        /// </summary>
        /// <param name="param">Parameter item</param>
        private int UpdateAndSave(DbParameter param, string value){

            param.Value = value;
            using (var context = new CustomSqlContext())
            {
                context.Parameters.Update(param);
                return context.SaveChanges();
            }
        }

        /// <summary>
        /// Show errors related with operations on the data base. It's used for debugging purposes only
        /// </summary>
        /// <param name="e"></param>
        private void ShowErros(DbEntityValidationException e)
        {
            foreach (var eve in e.EntityValidationErrors)
            {
                Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                foreach (var ve in eve.ValidationErrors)
                {
                    Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                        ve.PropertyName, ve.ErrorMessage);
                }
            }
        }

        /// <summary>
        /// Clone a parameter of a instance
        /// </summary>
        /// <param name="original"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        public DbParameter Clone(DbParameter original, DbInstance instance=null){
            DbParameter newItem = new DbParameter();
            newItem.Code = original.Code;
            newItem.Value = original.Value;
            newItem.Instance = original.Instance;

            return newItem;
        }

        /// <summary>
        /// Get all the parameters of a given instance
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public ICollection<DbParameter> getParameters(DbInstance instance){
            return Instance.Context.Parameters.Where(x => x.Instance.Id == instance.Id).ToList();
        }
    }
}
