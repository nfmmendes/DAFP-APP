using System;
using System.Collections.Generic;
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

        public void importAirportData(string fileName, DbInstance instance)
        {
            var stream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite, FileShare.Read);
            stream.Position = 0;

            XSSFWorkbook hssfwb = new XSSFWorkbook(stream);
            var sheet = hssfwb.GetSheet("Airport");
            if (sheet != null){
                
            }
            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++) //Read Excel File
            {
                IRow row = sheet.GetRow(i);
                if (row == null) break;
                if (row.Cells.All(d => d.CellType == CellType.Blank)) break;
                Console.WriteLine(row.GetCell(0)+" "+row.GetCell(1)+" "+row.GetCell(2));    
            }
            
        }


        public void importRequestData(string text, DbInstance dbInstance)
        {
            throw new NotImplementedException();
        }
    }
}
