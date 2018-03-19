using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.SqlServer.Server;
using Prototipo1.Controller;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1
{
    public partial class DuplicateInstance : Form
    {
        private CustomSqlContext Context { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public DuplicateInstance(CustomSqlContext context){
            InitializeComponent();
            Context = context;
            this.comboBoxInstance.DataSource = context.Instances.ToList().Select(shortInstanceDescription).ToList();
            this.comboBoxInstance.SelectedIndex = 0;
        }

        /// <summary>
        /// Create a label showing the main informations of a instance
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private string shortInstanceDescription(DbInstance x){
            return $"{x.Name} ({x.CreatedOn.ToString("dd/MM/yy hh:mm")}) {(x.Optimized ? "Opt" : "NotOpt")}";
        }
        
        /// <summary>
        /// Close the window after the button Cancel be pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e){
            this.Close();
        }

        /// <summary>
        /// Parser of the combo box label that return the instance name
        /// TODO: Ensure that the instance name is UNIQUE
        /// </summary>
        /// <returns></returns>
        public string getSelectedInstanceName(string selectedValue)
        {
            var selectedLabel = selectedValue;
            var instanceName = selectedLabel.Split('(')[0];
            return instanceName.Substring(0, instanceName.Length - 1);
        }

        /// <summary>
        /// Start the instance duplication procedure after the button Duplicate be pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDuplicate_Click(object sender, EventArgs e){

            var instanceName = getSelectedInstanceName(this.comboBoxInstance.SelectedItem.ToString());
            var instance = Context.Instances.FirstOrDefault(x => x.Name.Equals(instanceName));
            if (!string.IsNullOrEmpty(this.textBoxInstanceName.Text) && instance != null){
                InstancesController.Instance.Add(textBoxInstanceName.Text, textBoxScenarioDescription.Text);
                var newInstance = Context.Instances.FirstOrDefault(x => x.Name.Equals(textBoxInstanceName.Text));
                InstancesController.Instance.CopyInstance(instance, newInstance);
            }

        }

        private void textBoxInstanceName_TextChanged(object sender, EventArgs e)
        {
            this.buttonDuplicate.Enabled = !string.IsNullOrEmpty(this.textBoxInstanceName.Text);
        }
    }
}
