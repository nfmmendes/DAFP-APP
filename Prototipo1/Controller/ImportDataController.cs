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

        public void importNetworkData(string fileName, DbInstance instance,bool loadAirports, bool loadStretches)
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
                        GroundTime =row.GetCell(9).CellType != CellType.String?  row.GetCell(9).DateCellValue.TimeOfDay: (new DateTime(0)).TimeOfDay,
                        ICAO = row.GetCell(1).StringCellValue,
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
                    var airportOrigin = instanceAirports.FirstOrDefault(x => x.AiportName.Equals(airportOriginName));
                    var airportDestination = instanceAirports.FirstOrDefault(x => x.AiportName.Equals(airportDestinationName));

                    

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


        public void importRequestData(string text, DbInstance dbInstance)
        {
            throw new NotImplementedException();
        }

        public void importAirplanesData(string fileName, DbInstance instance,bool loadAirplanes, bool loadSeats)
        {
            var stream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
            stream.Position = 0;

            XSSFWorkbook hssfwb = new XSSFWorkbook(stream);
            var sheet = hssfwb.GetSheet("Airplanes");
            if (sheet != null && loadAirplanes){
                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) break;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) break;

                    var airportName = row.GetCell(7).StringCellValue;
                    var baseAirport = Context.Airports.FirstOrDefault(x => x.AiportName.Equals(airportName));

                    if (baseAirport != null){

                        var item = new DbAirplane(){
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
                }
                Instance.Context.SaveChanges();
                
            }
       }
    }
}
