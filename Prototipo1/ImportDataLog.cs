using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1
{
    public partial class ImportDataLog : Form
    {

        public CustomSqlContext Context { get; set;  }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="instance"></param>
        public ImportDataLog(CustomSqlContext context, DbInstance instance = null){
            Context = context;
            InitializeComponent();

            this.comboBoxInstances.DataSource = Context.Instances.Select( shortInstanceDescription).ToList();
            if (instance != null)
                this.comboBoxInstances.SelectedText = shortInstanceDescription(instance);
            else
                this.comboBoxInstances.SelectedIndex = 0;
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxInstances_SelectedIndexChanged(object sender, EventArgs e){
            this.dataGridViewDatetime.Rows.Clear();

            if (!string.IsNullOrEmpty(this.comboBoxInstances.SelectedItem.ToString())){
                var instanceName = getSelectedInstanceName( this.comboBoxInstances.SelectedItem.ToString());
                var instance = Context.Instances.FirstOrDefault(x => x.Name.Equals(instanceName));

                if (instance != null){
                    var warningsTimes = Context.ImportErrors.Where(x => x.Instance.Id == instance.Id).Select(x=>x.ImportationHour).Distinct();

                    foreach (var time in warningsTimes)
                        dataGridViewDatetime.Rows.Add(time.ToString("G"));
                }  
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getSelectedInstanceName(string selectedValue)
        {
            var selectedLabel = selectedValue;
            var instanceName = selectedLabel.Split('(')[0];
            return instanceName.Substring(0, instanceName.Length - 1);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewDatetime_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridViewDetail.Rows.Clear();
            if (!string.IsNullOrEmpty(this.comboBoxInstances.SelectedItem.ToString())){
                var instanceName = getSelectedInstanceName(this.comboBoxInstances.SelectedItem.ToString());
                var instance = Context.Instances.FirstOrDefault(x => x.Name.Equals(instanceName));

                if (instance != null){
                    var selectedTime = dataGridViewDatetime.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    var warnings = Context.ImportErrors.ToList().Where(x => x.Instance.Id == instance.Id && x.ImportationHour.ToString("G").Equals(selectedTime));

                    foreach (var item in warnings)
                        dataGridViewDetail.Rows.Add(item.File, item.Sheet, item.RowLine, item.Message);
                }
            }
        }
    }
}
