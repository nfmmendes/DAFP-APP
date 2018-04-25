using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.XSSF.UserModel;
using Prototipo1.Controller;
using Solver;
using SolverClientComunication.Enums;
using SolverClientComunication.Models;

namespace Prototipo1
{
    public partial class PreCheckOptimizationView : Form
    {
        public bool ContinueOptimization { get; private set; }
        private DbInstance Instance { get; set; }
        private int ViewChoosen { get; set; } /* 1: All - 2: Error - 3: Warnings */

        public PreCheckOptimizationView(DbInstance instance){
            InitializeComponent();
            ContinueOptimization = false;
            Instance = instance;
            FillTable();

        }

        /// <summary>
        /// 
        /// </summary>
        private void FillTable(){
            var warnings = PreCheckOptimizationController.Instance.GetWarnings(Instance);
            this.dataGridViewAlerts.Rows.Clear();

            foreach (var row in warnings)
                dataGridViewAlerts.Rows.Add(OptimizationAlertTypeEnum.GetLabel(row.Type), row.Message, row.Table);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        private void FillTable(OptimizationAlertTypeEnum e){
            var warnings = PreCheckOptimizationController.Instance.GetWarnings(Instance).Where(x=>x.Type.Equals(e.DbCode));
            this.dataGridViewAlerts.Rows.Clear();

            foreach (var row in warnings)
                dataGridViewAlerts.Rows.Add(OptimizationAlertTypeEnum.GetLabel(row.Type), row.Message, row.Table);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonContinue_Click(object sender, EventArgs e){
            ContinueOptimization = true;
            this.Close();
        }

        private void radioButtonErrors_CheckedChanged(object sender, EventArgs e){
            if (radioButtonErrors.Checked)
                FillTable(OptimizationAlertTypeEnum.ERROR);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonWarnings_CheckedChanged(object sender, EventArgs e){
            if (radioButtonWarnings.Checked)
                FillTable(OptimizationAlertTypeEnum.WARNING);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonAll_CheckedChanged(object sender, EventArgs e){
            if (radioButtonAll.Checked)
                FillTable();
        }

        private void buttonExport_Click(object sender, EventArgs e){
            var saveFile = new SaveFileDialog();
            saveFile.Filter = "Excel File | *.xlsx";
            saveFile.ShowDialog();

            
                

            XSSFWorkbook wb;
            XSSFSheet sh;
            // create xls if not exists
            if (!File.Exists(saveFile.FileName)){
                wb = new XSSFWorkbook();

                // create sheet
                sh = (XSSFSheet) wb.CreateSheet("Optimization alerts");

                sh.CreateRow(0);
                sh.GetRow(0).CreateCell(0);
                sh.GetRow(0).CreateCell(1);
                sh.GetRow(0).CreateCell(2);
                sh.GetRow(0).GetCell(0).SetCellValue("Type");
                sh.GetRow(0).GetCell(1).SetCellValue("Message");
                sh.GetRow(0).GetCell(2).SetCellValue("Table");

                for (int i = 0; i < dataGridViewAlerts.RowCount - 1; i++){
                    if (sh.GetRow(i+1) == null)
                        sh.CreateRow(i+1);

                    for (int j = 0; j < dataGridViewAlerts.ColumnCount; j++){
                        if (sh.GetRow(i+1).GetCell(j) == null)
                            sh.GetRow(i+1).CreateCell(j);

                        if (dataGridViewAlerts[j, i].Value != null){
                            sh.GetRow(i+1).GetCell(j).SetCellValue(dataGridViewAlerts[j, i].Value.ToString());
                        }
                    }

                    using (var fs = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write))
                        wb.Write(fs);
                }
                MessageBox.Show("Export finished");
            }
            
        }
    }
}
