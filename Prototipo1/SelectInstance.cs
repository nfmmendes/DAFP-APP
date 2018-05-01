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
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1
{
    public partial class SelectInstance : Form
    {
        public enum SelectToEnum{
            EXPORT_INSTANCE,
            EXPORT_INSTANCE_SOLUTION,
            OPTIMIZATION_ALERTS,
            IMPORT_LOG
        }

        private SelectToEnum Mode { get; set;  }
        private CustomSqlContext Context { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SelectInstance(SelectToEnum selectTo, CustomSqlContext context){
            InitializeComponent();
            Mode = selectTo;
            Context = context;
            comboBoxInstances.DataSource = Context.Instances.ToList().Where(x=>x.Optimized).Select(shortInstanceDescription).ToList();
        }

        /// <summary>
        /// Parser of the instance metadata to a string 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private string shortInstanceDescription(DbInstance x){
            return $"{x.Name} ({x.CreatedOn.ToString("dd/MM/yy hh:mm")}) {(x.Optimized ? "Opt" : "NotOpt")}";
        }


        /// <summary>
        /// Return the name of a instance given the value selected in the main combo box
        /// </summary>
        /// <returns></returns>
        private string getSelectedInstanceName(string selectedValue){
            var selectedLabel = selectedValue;
            var instanceName = selectedLabel.Split('(')[0];
            return instanceName.Substring(0, instanceName.Length - 1);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOk_Click(object sender, EventArgs e){
            var instanceName = getSelectedInstanceName(this.comboBoxInstances.SelectedValue.ToString());
            var instance = this.Context.Instances.First(x => x.Name.Equals(instanceName));

            if (Mode == SelectToEnum.EXPORT_INSTANCE){
                var saveFileDialog = new SaveFileDialog();
                var saveFile = new SaveFileDialog();
                saveFile.Filter = "Excel File | *.xlsx";
                saveFileDialog.ShowDialog();

                InstancesController.Instance.setContext(Context);
                InstancesController.Instance.ExportInstance(saveFileDialog.FileName);
                this.Close();
            }else if (Mode == SelectToEnum.EXPORT_INSTANCE_SOLUTION){
                var saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel File | *.xlsx";
                saveFileDialog.ShowDialog();

                InstancesController.Instance.setContext(Context);
                InstancesController.Instance.ExportInstanceSolution(saveFileDialog.FileName, instance);
                this.Close();
            }else if (Mode == SelectToEnum.OPTIMIZATION_ALERTS){
                var preCheckView = new PreCheckOptimizationView(instance,false);
               
                preCheckView.ShowDialog();
            }

            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e){
            this.Close();
        }
    }
}
