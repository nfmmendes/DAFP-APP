using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolverClientComunication;
using SolverClientComunication.Models;
using SolverClientComunication.Enums;

namespace Prototipo1.Controller
{
    class ParametersController
    {
        private CustomSqlContext Context { get; set; }
        public static readonly ParametersController Instance = new ParametersController();

        private Dictionary<ParametersEnum, string> DefaultParameters { get; set;  }


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
        }

        public void setContext(CustomSqlContext context){
            Instance.Context = context;
        }

        public void setDefaultParameters(DbInstance solverInstance)
        {
            var newParameters = new List<DbParameters>();
            long id = Instance.Context.Parameters.Any() ? Instance.Context.Parameters.Max(x => x.Id) + 1 : 0;
            foreach (var key in DefaultParameters.Keys)
                newParameters.Add(new DbParameters(){Id=id++, Code = key.DbCode, Instance = solverInstance, Value = DefaultParameters[key]});

            Instance.Context.Parameters.AddRange(newParameters);

            try{
                Instance.Context.SaveChanges();
            }catch (DbEntityValidationException e){
                ShowErros(e);
                throw;
            }
        }

        public void UpdateInstanceParameters(DbInstance instance, bool useTimeWindows, bool pickAll = true, bool deliverAll = true,
                                       bool startFromDepot = true, bool comebackToDepot = true, int averageWeightMan = 75,
                                       int averageWeightWoman = 65, int averageChildWeight = 30, int timeLimit = 45)
        {
            var insId = instance.Id;
            var Parameters = Instance.Context.Parameters;
            var parameters = Parameters.Where(x =>insId == x.Instance.Id && x.Code == ParametersEnum.USE_TIME_WINDOWS.DbCode).ToList();
            foreach (var param in parameters) { param.Value = useTimeWindows ? "true" : "false"; UpdateAndSave(param); }

            parameters = Parameters.Where(x => insId == x.Instance.Id && x.Code == ParametersEnum.PICK_ALL.DbCode).ToList();
            foreach (var param in parameters) { param.Value = pickAll ? "true" : "false"; UpdateAndSave(param); }

            parameters = Parameters.Where(x => insId == x.Instance.Id && x.Code == ParametersEnum.DELIVER_ALL.DbCode).ToList();
            foreach (var param in parameters) { param.Value = deliverAll ? "true" : "false"; UpdateAndSave(param); }

            parameters = Parameters.Where(x => insId == x.Instance.Id && x.Code == ParametersEnum.START_FROM_DEPOT.DbCode).ToList();
            foreach (var param in parameters) { param.Value = startFromDepot ? "true" : "false"; UpdateAndSave(param); }

            parameters = Parameters.Where(x => insId == x.Instance.Id && x.Code == ParametersEnum.COME_BACK_TO_DEPOT.DbCode).ToList();
            foreach (var param in parameters) { param.Value = comebackToDepot ? "true" : "false"; UpdateAndSave(param); }

            parameters = Parameters.Where(x => insId == x.Instance.Id && x.Code == ParametersEnum.AVERAGE_MEN_WEIGHT.DbCode).ToList();
            foreach (var param in parameters) { param.Value = averageWeightMan.ToString(); UpdateAndSave(param); }

            parameters = Parameters.Where(x => insId == x.Instance.Id && x.Code == ParametersEnum.AVERAGE_WOMEN_WEIGHT.DbCode).ToList();
            foreach (var param in parameters) { param.Value = averageWeightWoman.ToString(); UpdateAndSave(param); }

            parameters = Parameters.Where(x => insId == x.Instance.Id && x.Code == ParametersEnum.TIME_LIMIT.DbCode).ToList();
            foreach (var param in parameters) { param.Value = timeLimit.ToString(); UpdateAndSave(param); }
        }

        public void UpdateAllInstances(bool useTimeWindows, bool pickAll = true, bool deliverAll = true,
                                       bool startFromDepot = true,bool comebackToDepot = true, int averageWeightMan = 75, 
                                       int averageWeightWoman = 65,int averageChildWeight = 30,int timeLimit = 45){

            var parameters = Instance.Context.Parameters.Where(x => x.Code == ParametersEnum.USE_TIME_WINDOWS.DbCode).ToList();
            foreach (var param in parameters){ param.Value= useTimeWindows?"true":"false";   UpdateAndSave(param);}

            parameters = Instance.Context.Parameters.Where(x => x.Code == ParametersEnum.PICK_ALL.DbCode).ToList();
            foreach (var param in parameters) { param.Value = pickAll ? "true" : "false"; UpdateAndSave(param); }

            parameters = Instance.Context.Parameters.Where(x => x.Code == ParametersEnum.DELIVER_ALL.DbCode).ToList();
            foreach (var param in parameters) { param.Value = deliverAll ? "true" : "false"; UpdateAndSave(param); }

            parameters = Instance.Context.Parameters.Where(x => x.Code == ParametersEnum.START_FROM_DEPOT.DbCode).ToList();
            foreach (var param in parameters) { param.Value = startFromDepot ? "true" : "false"; UpdateAndSave(param); }

            parameters = Instance.Context.Parameters.Where(x => x.Code == ParametersEnum.COME_BACK_TO_DEPOT.DbCode).ToList();
            foreach (var param in parameters) { param.Value = comebackToDepot ? "true" : "false"; UpdateAndSave(param); }

            parameters = Instance.Context.Parameters.Where(x => x.Code == ParametersEnum.AVERAGE_MEN_WEIGHT.DbCode).ToList();
            foreach (var param in parameters) { param.Value = averageWeightMan.ToString(); UpdateAndSave(param); }

            parameters = Instance.Context.Parameters.Where(x => x.Code == ParametersEnum.AVERAGE_WOMEN_WEIGHT.DbCode).ToList();
            foreach (var param in parameters) { param.Value = averageWeightWoman.ToString(); UpdateAndSave(param); }

            parameters = Instance.Context.Parameters.Where(x => x.Code == ParametersEnum.TIME_LIMIT.DbCode).ToList();
            foreach (var param in parameters) { param.Value = timeLimit.ToString(); UpdateAndSave(param); }
            
        }

        private void UpdateAndSave(DbParameters param){
            Instance.Context.Parameters.AddOrUpdate(param);
            Instance.Context.SaveChanges();
        }

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
    }
}
