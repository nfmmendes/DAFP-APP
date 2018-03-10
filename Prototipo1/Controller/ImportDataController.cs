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
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Prototipo1.Controller
{
    class ImportDataController
    {
        private CustomSqlContext Context { get; set; }
        public static readonly ImportDataController Instance = new ImportDataController();

        public void setContext(CustomSqlContext context)
        {
            Instance.Context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="instance"></param>
        /// <param name="loadAirports"></param>
        /// <param name="loadStretches"></param>
        public void importNetworkData(string fileName, DbInstance instance,bool loadAirports, bool loadStretches, bool loadFuelInformation)
        {
            var stream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
            stream.Position = 0;

            XSSFWorkbook hssfwb = new XSSFWorkbook(stream);
            var sheet = hssfwb.GetSheet("Airport");
            if (sheet != null && loadAirports){
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) break;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) break;

                    var item = new DbAirports()
                    {
                        AiportName = row.GetCell(0).StringCellValue,
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

                    if (row.GetCell(4).CellType == CellType.Numeric )
                        item.Elevation = Convert.ToInt32(row.GetCell(4).NumericCellValue);
                    if (row.GetCell(10).CellType == CellType.Numeric )
                        item.LandingCost = Convert.ToInt32(row.GetCell(10).NumericCellValue);
                    if (row.GetCell(5).CellType == CellType.Numeric )
                        item.RunwayLength = Convert.ToInt32(row.GetCell(5).NumericCellValue);

                    try
                    {
                        Instance.Context.Airports.AddOrUpdate(item);
                        Instance.Context.SaveChanges();
                    }catch (DbEntityValidationException e){
                        ShowErros(e);
                    }
                    
                }
            }

            var sheet2 = hssfwb.GetSheet("Stretches");

            if (sheet2 != null && loadStretches){
                var instanceAirports = Instance.Context.Airports.Where(x => x.Instance.Id == instance.Id);
                List<DbStretches> newItems = new List<DbStretches>();
                for (int i = (sheet2.FirstRowNum + 1); i <= sheet2.LastRowNum; i++) {
                    IRow row = sheet2.GetRow(i);
                    if (row == null) break;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) break;

                    if (string.IsNullOrEmpty(row.GetCell(0).StringCellValue)) continue; //TODO: Error
                    if (string.IsNullOrEmpty(row.GetCell(1).StringCellValue)) continue; //TODO: Error

                    var airportOriginName = row.GetCell(0).StringCellValue;
                    var airportDestinationName = row.GetCell(1).StringCellValue;
                    var airportOrigin = instanceAirports.FirstOrDefault(x =>x.Instance.Id == instance.Id &&  x.AiportName.Equals(airportOriginName));
                    var airportDestination = instanceAirports.FirstOrDefault(x => x.Instance.Id == instance.Id &&  x.AiportName.Equals(airportDestinationName));

                    

                    if (airportOrigin != null && airportDestination != null){
                        var item = new DbStretches(){
                            Origin = airportOrigin,
                            Destination = airportDestination,
                            Distance = Convert.ToInt32(row.GetCell(2).NumericCellValue)
                        };

                        try{
                            newItems.Add(item);
                        }
                        catch (DbEntityValidationException e){
                            ShowErros(e);
                        }
                    }

                }
                Instance.Context.Stretches.AddRange(newItems);
                Instance.Context.SaveChanges();
            }

            var sheet3 = hssfwb.GetSheet("Fuel Prices");
            if (loadFuelInformation && sheet3 != null){
                var instanceAirports = Instance.Context.Airports.Where(x => x.Instance.Id == instance.Id);
                
                for (int i = (sheet3.FirstRowNum + 1); i <= sheet3.LastRowNum; i++)
                {
                    IRow row = sheet2.GetRow(i);
                    if (row == null) break;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) break;

                    if (string.IsNullOrEmpty(row.GetCell(0).StringCellValue)) continue; //TODO: Error
                    var airportName = row.GetCell(0).StringCellValue;
                    
                    var airport = instanceAirports.FirstOrDefault(x => x.Instance.Id == instance.Id &&  x.AiportName.Equals(airportName));

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

        }

        /// <summary>
        /// 
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
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="instance"></param>
        /// <param name="loadRequests"></param>
        public void importRequestData(string fileName, DbInstance instance,bool loadRequests)
        {
            var stream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
            stream.Position = 0;

            var importHour = DateTime.Now;

            XSSFWorkbook hssfwb = new XSSFWorkbook(stream);
            var sheet = hssfwb.GetSheet("Request");
            if (sheet != null)
            {
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) break;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) break;

                    var originIATA = row.GetCell(5).StringCellValue;
                    var destinationIATA = row.GetCell(6).StringCellValue;
                    if (string.IsNullOrEmpty(originIATA) || string.IsNullOrEmpty(destinationIATA)){
                        CreateImportErrorLog(instance, "Requests", "Request", importHour, i, "Null origin or destination airport name");
                        continue;
                    }

                    var airportOrigin = Instance.Context.Airports.FirstOrDefault(x=>x.Instance.Id == instance.Id 
                                                                                && x.IATA.Equals(originIATA));
                    var airportDestination = Instance.Context.Airports.FirstOrDefault(x => x.Instance.Id == instance.Id 
                                                                                   && x.IATA.Equals(destinationIATA));

                    if (airportOrigin == null || airportDestination == null){
                        CreateImportErrorLog(instance, "Requests", "Request", importHour, i, "Inexistent airport");
                        continue;
                    }

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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="fileName"></param>
        /// <param name="sheet"></param>
        /// <param name="importHour"></param>
        /// <param name="i"></param>
        /// <param name="msg"></param>
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
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="instance"></param>
        /// <param name="loadAirplanes"></param>
        /// <param name="loadSeats"></param>
        public void importAirplanesData(string fileName, DbInstance instance,bool loadAirplanes, bool loadSeats)
        {
            var stream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
            stream.Position = 0;

            var importHour = DateTime.Now;

            XSSFWorkbook hssfwb = new XSSFWorkbook(stream);
            var sheet = hssfwb.GetSheet("Airplanes");
            if (sheet != null && loadAirplanes){
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) break;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) break;

                    var airportName = row.GetCell(7).StringCellValue;
                    var baseAirport = Context.Airports.FirstOrDefault(x => x.Instance.Id == instance.Id && x.AiportName.Equals(airportName));

                    if (baseAirport != null){
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
                        Instance.Context.ImportErrors.Add(new DbImportErrors()
                        {
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

            sheet = hssfwb.GetSheet("Seat List");
            if (sheet != null && loadSeats){
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) break;
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

                    if (row.GetCell(3).CellType == CellType.String && string.IsNullOrEmpty(row.GetCell(3).StringCellValue)){
                        CreateImportErrorLog(instance, "Airplanes", "Seat List", importHour, i, "Luggage information not available");
                        continue;
                    }

                    var prefix = row.GetCell(0).StringCellValue;
                    var airplane = Instance.Context.Airplanes.FirstOrDefault(x=>x.Instance.Id == instance.Id 
                                                                             && x.Prefix.Equals(prefix));

                    if (airplane != null){

                        var item = new DbSeats(){
                            Airplanes = airplane,
                            seatClass = row.GetCell(1).StringCellValue,
                            numberOfSeats = Convert.ToInt32(row.GetCell(2).NumericCellValue),
                            luggageWeightLimit = row.GetCell(3).NumericCellValue
                        };

                        Instance.Context.SeatList.Add(item);
                        
                    }else{
                        CreateImportErrorLog(instance,"Airplanes", "Seat List",importHour, i, "Airplanes not found");
                    }
                }
                Instance.Context.SaveChanges();
            }
        }
    }
}
