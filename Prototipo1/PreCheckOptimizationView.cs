using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    }
}
