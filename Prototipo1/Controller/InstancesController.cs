using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;
using NPOI.XSSF.UserModel;
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
            
            var airplanes = Context.Airplanes.ToList().Where(x=>x.Instance.Id == previousInstance.Id);
            var airports = Context.Airports.ToList().Where(x => x.Instance.Id == previousInstance.Id);
            var exchange = Context.Exchange.ToList().Where(x => x.Instance.Id == previousInstance.Id);
            var fuelPrice = Context.FuelPrice.ToList().Where(x => x.Instance.Id == previousInstance.Id);
            var parameters = Context.Parameters.ToList().Where(x => x.Instance.Id == previousInstance.Id);
            var requests = Context.Requests.ToList().Where(x => x.Instance.Id == previousInstance.Id);
            var seats = Context.SeatList.ToList().Where(x => x.Airplanes.Instance.Id == previousInstance.Id);
            var stretches = Context.Stretches.ToList().Where(x => x.InstanceId == previousInstance.Id);

            //Clone and save the airport data
            foreach (var item in airports)
                Context.Airports.Add(AirportController.Instance.Clone(item, newInstance));
            Context.SaveChanges();

            //Clone and save the airplane data
            foreach (var item in airplanes)
                Context.Airplanes.Add(AirplaneController.Instance.Clone(item, newInstance));
            Context.SaveChanges();


            //Clone and save the exchange rate data
            foreach (var item in exchange){
                Context.Exchange.Add(ExchangeRatesController.Instance.Clone(item, newInstance));
            }
            Context.SaveChanges();

            //Clone and save the fuel price data
            foreach (var item in fuelPrice){
                Context.FuelPrice.Add(FuelController.Instance.Clone(item, newInstance));
            }
            Context.SaveChanges();

            //Clone and save the parameters data                
            ParametersController.Instance.setContext(Context);
            foreach (var item in parameters){
                Context.Parameters.Add(ParametersController.Instance.Clone(item, newInstance));
            }
            Context.SaveChanges();

            //Clone and sabe the requests data 
            //TODO: Create a controller and put this code on it
            foreach (var item in requests){
                var origin = Context.Airports.ToList().FirstOrDefault(x=>x.IATA.Equals(item.Origin.IATA) && x.Instance.Id == newInstance.Id);
                var destination = Context.Airports.ToList().FirstOrDefault(x => x.IATA.Equals(item.Destination.IATA) && x.Instance.Id == newInstance.Id);

                if (origin != null && destination != null){
                    var newItem = new DbRequests();
                    newItem.Origin = origin;
                    newItem.Destination = destination;
                    newItem.Name = item.Name;
                    newItem.PNR = item.PNR;
                    newItem.IsChildren = item.IsChildren;
                    newItem.Sex = item.Sex;
                    newItem.Class = item.Class; 
                    newItem.DepartureTimeWindowBegin = item.DepartureTimeWindowBegin;
                    newItem.DepartureTimeWindowEnd = item.DepartureTimeWindowEnd;
                    newItem.ArrivalTimeWindowBegin = item.ArrivalTimeWindowBegin;
                    newItem.ArrivalTimeWindowEnd = item.ArrivalTimeWindowEnd;
                    newItem.Instance = newInstance;

                    Context.Requests.Add(newItem);
                    
                }
              
            }
            Context.SaveChanges();

            //Clone and save the seat list data
            foreach (var item in seats){
                var airplane = Context.Airplanes.FirstOrDefault(x=>x.Prefix == item.Airplanes.Prefix && x.Instance.Id == newInstance.Id);

                if (airplane != null)
                    
                    Context.SeatList.Add(new DbSeats(){
                        Airplanes = airplane,
                        luggageWeightLimit = item.luggageWeightLimit,
                        seatClass = item.seatClass
                    });
            }
            Context.SaveChanges();


            //Clone and save the stretches list
            Context.Configuration.AutoDetectChangesEnabled = false;
            foreach (var item in stretches)
            {
                Context.Stretches.Add(new DbStretches()
                {
                    Origin = item.Origin,
                    Destination = item.Destination,
                    InstanceId = newInstance.Id,
                    Distance = item.Distance
                });
            }
            Context.Configuration.AutoDetectChangesEnabled = true;
            Context.SaveChanges();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public void ExportInstance(string fileName){
            XSSFWorkbook wb;
            XSSFSheet sheetAirplanes;
            XSSFSheet sheetAirports;
            XSSFSheet sheetRequests;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        public void ExportInstanceSolution(string fileName,DbInstance instance) { 
        
            
            XSSFWorkbook wb;
            XSSFSheet sheetFlight;
            XSSFSheet sheetRefuel;
            XSSFSheet sheetPassengers; 

            // create xls if not exists
            if (!File.Exists(fileName))
                File.Delete(fileName);
          //  {
                wb = new XSSFWorkbook();

                // create sheet
                sheetFlight = (XSSFSheet)wb.CreateSheet("Flights");

                sheetFlight.CreateRow(0);
                sheetFlight.GetRow(0).CreateCell(0);
                sheetFlight.GetRow(0).CreateCell(1);
                sheetFlight.GetRow(0).CreateCell(2);
                sheetFlight.GetRow(0).CreateCell(3);
                sheetFlight.GetRow(0).CreateCell(4);
                sheetFlight.GetRow(0).CreateCell(5);
                sheetFlight.GetRow(0).CreateCell(6);
                sheetFlight.GetRow(0).GetCell(0).SetCellValue("Id");
                sheetFlight.GetRow(0).GetCell(1).SetCellValue("Origin");
                sheetFlight.GetRow(0).GetCell(2).SetCellValue("Destination");
                sheetFlight.GetRow(0).GetCell(3).SetCellValue("Fuel On Departure");
                sheetFlight.GetRow(0).GetCell(4).SetCellValue("Fuel On Arrival");
                sheetFlight.GetRow(0).GetCell(5).SetCellValue("Arrial Time");
                sheetFlight.GetRow(0).GetCell(6).SetCellValue("Airplanes");

                //===========================================================================================
                //                                          FLIGHTS 
                //===========================================================================================
                var flights = Context.FlightsReports.ToList().Where(x=>x.Instance.Id == instance.Id).ToList();

                for (int i = 0; i < flights.Count; i++)
                {
                    if (sheetFlight.GetRow(i + 1) == null)
                        sheetFlight.CreateRow(i + 1);

                    int j = 0;
                    sheetFlight.GetRow(i + 1).CreateCell(j);
                    sheetFlight.GetRow(i + 1).GetCell(j++).SetCellValue(flights[i].Id);
                    sheetFlight.GetRow(i + 1).CreateCell(j);
                    sheetFlight.GetRow(i + 1).GetCell(j++).SetCellValue(flights[i].Origin.AirportName);
                    sheetFlight.GetRow(i + 1).CreateCell(j);
                    sheetFlight.GetRow(i + 1).GetCell(j++).SetCellValue(flights[i].Destination.AirportName);
                    sheetFlight.GetRow(i + 1).CreateCell(j);
                    sheetFlight.GetRow(i + 1).GetCell(j++).SetCellValue(flights[i].FuelOnDeparture.ToString());
                    sheetFlight.GetRow(i + 1).CreateCell(j);
                    sheetFlight.GetRow(i + 1).GetCell(j++).SetCellValue(flights[i].ArrivalTime.ToString(@"hh\:mm"));
                    sheetFlight.GetRow(i + 1).CreateCell(j);
                    sheetFlight.GetRow(i + 1).GetCell(j++).SetCellValue(flights[i].ArrivalTime.ToString(@"hh\:mm"));
                    sheetFlight.GetRow(i + 1).CreateCell(j);
                    sheetFlight.GetRow(i + 1).GetCell(j++).SetCellValue(flights[i].Airplanes.Prefix);
                }


                //===========================================================================================
                //                                          FLIGHTS 
                //===========================================================================================
                sheetRefuel = (XSSFSheet)wb.CreateSheet("Refuel");


                var refuels = Context.RefuelsReport.ToList().Where(x => x.Instance.Id == instance.Id).ToList();

                sheetRefuel.CreateRow(0);
                sheetRefuel.GetRow(0).CreateCell(0);
                sheetRefuel.GetRow(0).CreateCell(1);
                sheetRefuel.GetRow(0).CreateCell(2);
                sheetRefuel.GetRow(0).CreateCell(3);
                sheetRefuel.GetRow(0).CreateCell(4);
                sheetRefuel.GetRow(0).GetCell(0).SetCellValue("Id");
                sheetRefuel.GetRow(0).GetCell(0).SetCellValue("Airport");
                sheetRefuel.GetRow(0).GetCell(1).SetCellValue("Airplane");
                sheetRefuel.GetRow(0).GetCell(2).SetCellValue("Time");
                sheetRefuel.GetRow(0).GetCell(3).SetCellValue("Amount");

                for (int i =0;i<refuels.Count;i++){
                    if (sheetFlight.GetRow(i + 1) == null)
                        sheetFlight.CreateRow(i + 1);

                    int j = 0;
                    sheetRefuel.GetRow(i + 1).CreateCell(j);
                    sheetRefuel.GetRow(i + 1).GetCell(j++).SetCellValue(i);
                    sheetRefuel.GetRow(i + 1).CreateCell(j);
                    sheetRefuel.GetRow(i + 1).GetCell(j++).SetCellValue(refuels[i].Airport.AirportName);
                    sheetRefuel.GetRow(i + 1).CreateCell(j);
                    sheetRefuel.GetRow(i + 1).GetCell(j++).SetCellValue(refuels[i].Airplanes.Prefix);
                    sheetRefuel.GetRow(i + 1).CreateCell(j);
                    sheetRefuel.GetRow(i + 1).GetCell(j++).SetCellValue(refuels[i].RefuelTime.ToString(@"hh\:mm"));
                    sheetRefuel.GetRow(i + 1).CreateCell(j);
                    sheetRefuel.GetRow(i + 1).GetCell(j++).SetCellValue(refuels[i].Amount.ToString());
                }

                //===========================================================================================
                //                                          PASSENGERS 
                //===========================================================================================

                sheetPassengers = (XSSFSheet)wb.CreateSheet("Passengers");


                var passengers = Context.PassagersOnFlight.ToList().Where(x => x.Flight.Instance.Id == instance.Id).ToList();
                sheetPassengers.CreateRow(0);
                sheetPassengers.GetRow(0).CreateCell(0);
                sheetPassengers.GetRow(0).CreateCell(1);
                sheetPassengers.GetRow(0).CreateCell(2);
                sheetPassengers.GetRow(0).CreateCell(3);
                sheetPassengers.GetRow(0).CreateCell(4);
                sheetPassengers.GetRow(0).CreateCell(5);
                sheetPassengers.GetRow(0).CreateCell(6);
                sheetPassengers.GetRow(0).CreateCell(7);
                sheetPassengers.GetRow(0).CreateCell(8);
                sheetPassengers.GetRow(0).CreateCell(9);
                sheetPassengers.GetRow(0).CreateCell(10);
                sheetPassengers.GetRow(0).CreateCell(11);
                sheetPassengers.GetRow(0).GetCell(0).SetCellValue("Flight Id");
                sheetPassengers.GetRow(0).GetCell(1).SetCellValue("Name");
                sheetPassengers.GetRow(0).GetCell(2).SetCellValue("PNR");
                sheetPassengers.GetRow(0).GetCell(3).SetCellValue("Class");
                sheetPassengers.GetRow(0).GetCell(4).SetCellValue("Sex");
                sheetPassengers.GetRow(0).GetCell(5).SetCellValue("Is children");
                sheetPassengers.GetRow(0).GetCell(6).SetCellValue("Departure Time Windows Begin");
                sheetPassengers.GetRow(0).GetCell(7).SetCellValue("Departure Time Windows End");
                sheetPassengers.GetRow(0).GetCell(8).SetCellValue("Arrival Time Windows Begin");
                sheetPassengers.GetRow(0).GetCell(9).SetCellValue("Arrival Time Windows End");
                sheetPassengers.GetRow(0).GetCell(10).SetCellValue("Origin");
                sheetPassengers.GetRow(0).GetCell(11).SetCellValue("Destination");

                for (int i = 0; i < passengers.Count; i++)
                {
                    if (sheetPassengers.GetRow(i + 1) == null)
                        sheetPassengers.CreateRow(i + 1);

                    int j = 0;
                    sheetPassengers.GetRow(i + 1).CreateCell(j);
                    sheetPassengers.GetRow(i + 1).GetCell(j++).SetCellValue(passengers[i].Flight.Id);
                    sheetPassengers.GetRow(i + 1).CreateCell(j);
                    sheetPassengers.GetRow(i + 1).GetCell(j++).SetCellValue(passengers[i].Passenger.Name);
                    sheetPassengers.GetRow(i + 1).CreateCell(j);
                    sheetPassengers.GetRow(i + 1).GetCell(j++).SetCellValue(passengers[i].Passenger.PNR);
                    sheetPassengers.GetRow(i + 1).CreateCell(j);
                    sheetPassengers.GetRow(i + 1).GetCell(j++).SetCellValue(passengers[i].Passenger.Class);
                    sheetPassengers.GetRow(i + 1).CreateCell(j);
                    sheetPassengers.GetRow(i + 1).GetCell(j++).SetCellValue(passengers[i].Passenger.Sex);
                    sheetPassengers.GetRow(i + 1).CreateCell(j);
                    sheetPassengers.GetRow(i + 1).GetCell(j++).SetCellValue(passengers[i].Passenger.IsChildren);
                    sheetPassengers.GetRow(i + 1).CreateCell(j);
                    sheetPassengers.GetRow(i + 1).GetCell(j++).SetCellValue(passengers[i].Passenger.DepartureTimeWindowBegin.ToString(@"hh\:mm"));
                    sheetPassengers.GetRow(i + 1).CreateCell(j);
                    sheetPassengers.GetRow(i + 1).GetCell(j++).SetCellValue(passengers[i].Passenger.DepartureTimeWindowEnd.ToString(@"hh\:mm"));
                    sheetPassengers.GetRow(i + 1).CreateCell(j);
                    sheetPassengers.GetRow(i + 1).GetCell(j++).SetCellValue(passengers[i].Passenger.ArrivalTimeWindowBegin.ToString(@"hh\:mm"));
                    sheetPassengers.GetRow(i + 1).CreateCell(j);
                    sheetPassengers.GetRow(i + 1).GetCell(j++).SetCellValue(passengers[i].Passenger.ArrivalTimeWindowEnd.ToString(@"hh\:mm"));
                    sheetPassengers.GetRow(i + 1).CreateCell(j);
                    sheetPassengers.GetRow(i + 1).GetCell(j++).SetCellValue(passengers[i].Passenger.Origin.AirportName);
                    sheetPassengers.GetRow(i + 1).CreateCell(j);
                    sheetPassengers.GetRow(i + 1).GetCell(j++).SetCellValue(passengers[i].Passenger.Destination.AirportName);

                }

                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write)) { wb.Write(fs);  }
                        
                
                MessageBox.Show("Export finished");
          //  }
        }

    }
}
