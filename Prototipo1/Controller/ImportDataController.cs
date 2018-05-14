using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolverClientComunication;
using SolverClientComunication.Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Prototipo1.Controller
{
    class ImportDataController
    {
        private CustomSqlContext Context { get; set; }
        public static readonly ImportDataController Instance = new ImportDataController();

        /// <summary>
        /// Sets the object that access the database
        /// </summary>
        /// <param name="context">Object that will access the database </param>
        public void setContext(CustomSqlContext context){
            Instance.Context = context;
        }

        /// <summary>
        /// This function imports the data concerning to the network (Airports, routes and refuel points)
        /// </summary>
        /// <param name="now">Instant that starts the optizimation - It will be used to build the log</param>
        /// <param name="fileName">Name of file that contains the data</param>
        /// <param name="instance">Instance where the data will be inserted</param>
        /// <param name="loadAirports">It defines if the sheet "Airport" will be loaded </param>
        /// <param name="loadStretches">It defines if the sheet "Stretches" will be loaded</param>
        /// <param name="loadFuelInformation"> If the sheet "Fuel Prices" will be loaded </param>
        public void importNetworkData(DateTime now, string fileName, DbInstance instance,bool loadAirports, bool loadStretches, bool loadFuelInformation)
        {
            //Default procedure to open a excel file using the library NPOI
            var stream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
            stream.Position = 0;
            XSSFWorkbook hssfwb = new XSSFWorkbook(stream);

            Instance.Context.Configuration.AutoDetectChangesEnabled = false;

            //Try to get the sheet caled "Airport"
            var sheet = hssfwb.GetSheet("Airport");
            var iatas = new HashSet<string>();
            if (sheet != null && loadAirports){
                //The first line is reserved to headers
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                {
                    //Get the i-esim row
                    IRow row = sheet.GetRow(i);     
                    if (row == null) break;

                    //If all lines are blank the reading procedure stops
                    //TODO: Create a error log
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) break;

                    //Check if the first cell (airport name) is present. If it's not, it's impossible to identify the airport
                    if (iatas.Contains(row.GetCell(1).StringCellValue))
                        continue;
                    
                    //Create DbAirport object to add it on the database
                    var item = new DbAirports()
                    {
                        AirportName = row.GetCell(0).StringCellValue,
                        GroundTime =row.GetCell(9).CellType != CellType.String? 
                                                               row.GetCell(9).DateCellValue.TimeOfDay: (new DateTime(0)).TimeOfDay,
                        IATA = row.GetCell(1).StringCellValue,
                        Latitude = row.GetCell(2).StringCellValue,
                        Longitude = row.GetCell(3).StringCellValue, 
                        Region = row.GetCell(6).StringCellValue,
                        MTOW_APE3 = Convert.ToInt32(row.GetCell(7).NumericCellValue),
                        MTOW_PC12 = Convert.ToInt32( row.GetCell(8).NumericCellValue),
                        Instance = instance
                    };

                    //Solve some problems related with the data format and lack of information
                    if (row.GetCell(4) == null)
                        item.Elevation = -1; 
                    else if (row.GetCell(4).CellType == CellType.Numeric )
                        item.Elevation = Convert.ToInt32(row.GetCell(4).NumericCellValue);
                    if (row.GetCell(10).CellType == CellType.Numeric )
                        item.LandingCost = Convert.ToInt32(row.GetCell(10).NumericCellValue);
                    if (row.GetCell(5).CellType == CellType.Numeric )
                        item.RunwayLength = Convert.ToInt32(row.GetCell(5).NumericCellValue);

                    try{
                     Instance.Context.Airports.Add(item);
                     //    
                    }catch (DbEntityValidationException e){
                        ShowErros(e);
                    }
                    
                }
                Instance.Context.SaveChanges();
            }

            //Select the sheet called "Stretches"
            var sheet2 = hssfwb.GetSheet("Stretches");
            
            if (sheet2 != null && loadStretches){
                Context.Configuration.ValidateOnSaveEnabled = false;

                //Get the name of all airports already registered
                //If there is no airports registered that corrresponds to the values on fields "Origin" or "Destination" of the stretch this 
                //stretch will be not added to the instance
                var instanceAirports = Instance.Context.Airports.Where(x => x.Instance.Id == instance.Id).ToDictionary(x=>x.AirportName, x=>x);
                List<DbStretches> newItems = new List<DbStretches>();
                //The first row is reserved to the hearders
                for (int i = (sheet2.FirstRowNum + 1); i <= sheet2.LastRowNum; i++) {
                    IRow row = sheet2.GetRow(i);
                    if (row == null) break;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) break;

                    //If the field "Origin" or the field "Destination" is empty, there is nothing to add
                    if (string.IsNullOrEmpty(row.GetCell(0).StringCellValue)) continue; //TODO: Error
                    if (string.IsNullOrEmpty(row.GetCell(1).StringCellValue)) continue; //TODO: Error


                    var airportOriginName = row.GetCell(0).StringCellValue;
                    var airportDestinationName = row.GetCell(1).StringCellValue;
                    
                    //Get the airports based on their names
                    var airportOrigin = instanceAirports.ContainsKey(airportOriginName) ? instanceAirports[airportOriginName] : null;
                    var airportDestination = instanceAirports.ContainsKey(airportDestinationName) ? instanceAirports[airportDestinationName] : null;

                    if (airportOrigin != null && airportDestination != null){

                        //Try to make the insert procedure quicker 
                        if (i % 50 == 0){
                            Instance.Context.Stretches.AddRange(newItems);
                            Instance.Context.SaveChanges();
                            newItems.Clear();
                           
                        }

                        //Create a stretch object to be added to the database
                        var item = new DbStretches(){
                            Origin = airportOriginName,
                            Destination = airportDestinationName,
                            Distance = Convert.ToInt32(row.GetCell(2).NumericCellValue),
                            InstanceId = instance.Id
                        };

                        try{
                            newItems.Add(item);
                        }
                        catch (DbEntityValidationException e){
                            ShowErros(e);
                        }
                    }

                }
                Instance.Context.SaveChanges();
                Context.Configuration.ValidateOnSaveEnabled = false;
            }

            // Get the sheed called "Fuel Prices"
            var sheet3 = hssfwb.GetSheet("Fuel Prices");

            if (loadFuelInformation && sheet3 != null){
                //Get the name of all aiports
                var instanceAirports = Instance.Context.Airports.Where(x => x.Instance.Id == instance.Id);
                
                //The first row is reserved to the headers
                for (int i = (sheet3.FirstRowNum + 1); i <= sheet3.LastRowNum; i++)
                {
                    //Get the information of the row i
                    IRow row = sheet3.GetRow(i);
                    if (row == null) break;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) break;

                    //If the airport field is empty the row will be not added to the database
                    if (string.IsNullOrEmpty(row.GetCell(0).StringCellValue)) continue; //TODO: Error
                    var airportName = row.GetCell(0).StringCellValue;
                    
                    //Get the airport by its name
                    var airport = instanceAirports.FirstOrDefault(x => x.Instance.Id == instance.Id &&  x.AirportName.Equals(airportName));

                    //Generate the fuel price object to be added to the database 
                    if (airport != null){
                        var item = new DbFuelPrice(){
                            Instance = instance,
                            Airport = airport,
                            Currency = row.GetCell(1).StringCellValue,
                            Value = row.GetCell(2).NumericCellValue.ToString()
                        };
                        Instance.Context.FuelPrice.Add(item);
                    }
                }
                Instance.Context.SaveChanges();
            }
            Instance.Context.Configuration.AutoDetectChangesEnabled = true;
        }

        /// <summary>
        /// Function to show the errors in the database procedures. It's is used mainly to debug purposes 
        /// </summary>
        /// <param name="e"></param>
        private void ShowErros(DbEntityValidationException e)
        {
            foreach (var eve in e.EntityValidationErrors){
                Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                foreach (var ve in eve.ValidationErrors){
                    Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",ve.PropertyName, ve.ErrorMessage);
                }
            }
        }

        /// <summary>
        /// Import the data that describes the requests of the optimization period
        /// </summary>
        /// <param name="now">Instant the the procedure started</param>
        /// <param name="fileName">Name of file where the data is</param>
        /// <param name="instance">Name of the instance where the data will be stored</param>
        /// <param name="loadRequests">Indicate if the load request data will be read</param>
        public void importRequestData(DateTime now, string fileName, DbInstance instance,bool loadRequests = true)
        {
            //Default procedure to open a excel file using the library NPOI
            var stream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
            stream.Position = 0;

            var importHour = now;
            Instance.Context.Configuration.AutoDetectChangesEnabled = false;    //This is done to make the procedure quicker
                                                                                //It need to be set to true in the end of procedure
            XSSFWorkbook hssfwb = new XSSFWorkbook(stream);

            //Open the sheet called "Request"
            var sheet = hssfwb.GetSheet("Request");

            if (sheet != null){
                //Create a dictionary that links a aiport IATA code to the airport. Airports without a IATA code registered are not mapped
                var instanceAirports = Instance.Context.Airports.Where(x => x.Instance.Id == instance.Id && !string.IsNullOrEmpty(x.IATA)).ToDictionary(x => x.IATA, x => x);
                //The first line is reserved to the headers
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                {
                    //Get the data of the row i
                    IRow row = sheet.GetRow(i);
                    if (row == null) break;
                    //If all the fields of that row are empty, finish the procedure
                    //TODO: Create a error log to this case
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) break;

                    var originIATA = row.GetCell(5).StringCellValue;
                    var destinationIATA = row.GetCell(6).StringCellValue;
                    //Verify if the IATA codes fields have non null or empty values. If it is false, it's generated a log error
                    if (string.IsNullOrEmpty(originIATA) || string.IsNullOrEmpty(destinationIATA)){
                        CreateImportErrorLog(instance, "Requests", "Request", importHour, i, "Null origin or destination airport name");
                        continue;
                    }

                    //Get the airport given the IATA
                    var airportOrigin = instanceAirports.ContainsKey(originIATA) ? instanceAirports[originIATA] : null;
                    var airportDestination = instanceAirports.ContainsKey(destinationIATA) ? instanceAirports[destinationIATA] : null;

                    //If some of the airports are not found a error log is generated
                    if (airportOrigin == null || airportDestination == null){
                        CreateImportErrorLog(instance, "Requests", "Request", importHour, i, "Inexistent airport");
                        continue;
                    }

                    //TODO: Verify if this is right
                    if(row.Cells.Count < 10) { 
                        CreateImportErrorLog(instance, "Requests", "Request", importHour, i, "Some data is missing in your database row");
                        continue;
                    }

                    //Generated a DbRequest object to the added on the database 
                    var item = new DbRequests()
                    {
                        Name = row.GetCell(0).StringCellValue,
                        PNR = row.GetCell(1).CellType == CellType.String? row.GetCell(1).StringCellValue: row.GetCell(1).NumericCellValue.ToString(),
                        Sex = row.GetCell(2).StringCellValue,
                        Class = row.GetCell(3).StringCellValue,
                        IsChildren = row.GetCell(4).BooleanCellValue,
                        Origin = airportOrigin,
                        Destination = airportDestination,
                        DepartureTimeWindowBegin = row.GetCell(7).DateCellValue.TimeOfDay,
                        DepartureTimeWindowEnd = row.GetCell(8).DateCellValue.TimeOfDay,
                        ArrivalTimeWindowBegin = row.GetCell(9).DateCellValue.TimeOfDay,
                        ArrivalTimeWindowEnd = row.GetCell(10).DateCellValue.TimeOfDay,
                        Instance = instance
                    };

                    Instance.Context.Requests.Add(item);
                }

                try{
                    Instance.Context.SaveChanges();
                }catch (DbEntityValidationException e){
                    ShowErros(e);
                }
            }
            Instance.Context.Configuration.AutoDetectChangesEnabled = true;
        }

        /// <summary>
        /// Function to create and store the import data that describes the errors in import data
        /// </summary>
        /// <param name="instance">Instance in which the error happened</param>
        /// <param name="fileName">Name of the file that was being read</param>
        /// <param name="sheet">Name of the sheet that was being read</param>
        /// <param name="importHour">Import hour</param>
        /// <param name="i">Line that was being read</param>
        /// <param name="msg">Error message</param>
        private void CreateImportErrorLog(DbInstance instance,string fileName,string sheet,  DateTime importHour, int i,string msg)
        {
            Instance.Context.ImportErrors.Add(new DbImportErrors()
            {
                ImportationHour = importHour,
                File = fileName,
                Instance = instance,
                Sheet = sheet,
                RowLine = i,
                Message = msg
            });
        }

        /// <summary>
        /// Read all the data that describe the airports 
        /// </summary>
        /// <param name="fileName">Name of the file that contains the airplane data</param>
        /// <param name="instance">Instance that will be read</param>
        /// <param name="loadAirplanes">If the data about the airplanes will be read</param>
        /// <param name="loadSeats">If the data about load seats will be read</param>
        public void importAirplanesData(DateTime now, string fileName, DbInstance instance,bool loadAirplanes, bool loadSeats)
        {
            //Default procedure to open a excel file using the library NPOI
            var stream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
            stream.Position = 0;

            var importHour = now;

            Instance.Context.Configuration.AutoDetectChangesEnabled = false;    //This is done to make the procedure quicker. This field must be set to true in the end
            XSSFWorkbook hssfwb = new XSSFWorkbook(stream);

            //Get the sheet called "Airplanes" if it exist
            var sheet = hssfwb.GetSheet("Airplanes");
            if (sheet != null && loadAirplanes){
                //The first row is reserved to readers 
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                {
                    IRow row = sheet.GetRow(i);         //Get the row i
                    if (row == null) break;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) break;

                    //Get the data about the airport base and checks if this airport is registered on the database, otherwise will be generated
                    //a error log 
                    var airportName = row.GetCell(7).StringCellValue;
                    var baseAirport = Context.Airports.FirstOrDefault(x => x.Instance.Id == instance.Id && x.AirportName.Equals(airportName));

                    if (baseAirport != null){
                        //Generate the DbAirplane object to be added on the database
                        var item = new DbAirplanes()
                        {
                            Model = row.GetCell(0).StringCellValue,
                            Prefix = row.GetCell(1).StringCellValue,
                            Range = Convert.ToInt32(row.GetCell(2).NumericCellValue),
                            Weight = Convert.ToInt32(row.GetCell(3).NumericCellValue),
                            MaxWeight = Convert.ToInt32(row.GetCell(4).NumericCellValue),
                            CruiseSpeed = Convert.ToInt32(row.GetCell(5).NumericCellValue),
                            Capacity = Convert.ToInt32(row.GetCell(6).NumericCellValue),
                            BaseAirport = baseAirport,
                            FuelConsumptionFirstHour = Convert.ToInt32(row.GetCell(8).NumericCellValue),
                            FuelConsumptionSecondHour = Convert.ToInt32(row.GetCell(9).NumericCellValue),
                            MaxFuel = Convert.ToInt32(row.GetCell(10).NumericCellValue),
                            Instance = instance
                        };

                        Instance.Context.Airplanes.Add(item);
                    }
                    else
                    {
                        Instance.Context.ImportErrors.Add(new DbImportErrors(){
                            ImportationHour = importHour,
                            File = "Airplanes",
                            Instance = instance,
                            Sheet = "Airplanes",
                            RowLine = i,
                            Message = "Airport does not exist"
                        });
                    }
                }
                Instance.Context.SaveChanges();
                
            }

            //Get the sheet called "Seat List"
            sheet = hssfwb.GetSheet("Seat List");
            if (sheet != null && loadSeats){
                //The first row is reserved to the headers 
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                {
                    IRow row = sheet.GetRow(i); //Get the data of the row i
                    if (row == null) break;
                    //If all the fields of the row are empty, the import procedure stops
                    //TODO: Generate a error log
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) break;

                    //Data validation
                    if (string.IsNullOrEmpty(row.GetCell(0).StringCellValue)){
                        CreateImportErrorLog(instance, "Airplanes", "Seat List", importHour, i, "Airplanes information not available");
                        continue;
                    }

                    if (string.IsNullOrEmpty(row.GetCell(1).StringCellValue)){
                        CreateImportErrorLog(instance, "Airplanes", "Seat List", importHour, i, "Class information not available");
                        continue;
                    }

                    if (row.GetCell(2).CellType == CellType.String && string.IsNullOrEmpty(row.GetCell(2).StringCellValue)){
                        CreateImportErrorLog(instance, "Airplanes", "Seat List", importHour, i, "Number of seats not available");
                        continue;
                    }
                    
                    var prefix = row.GetCell(0).StringCellValue;
                    var airplane = Instance.Context.Airplanes.FirstOrDefault(x=>x.Instance.Id == instance.Id 
                                                                             && x.Prefix.Equals(prefix));

                    //Generate the airplane object that will be added to the database
                    if (airplane != null){

                        var item = new DbSeats(){
                            Airplanes = airplane,
                            seatClass = row.GetCell(1).StringCellValue,
                            luggageWeightLimit = row.GetCell(2).NumericCellValue
                        };

                        Instance.Context.SeatList.Add(item);
                        
                    }else{
                        CreateImportErrorLog(instance,"Airplanes", "Seat List",importHour, i, "Airplanes not found");
                    }
                }
                Instance.Context.SaveChanges();
            }
            Instance.Context.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
