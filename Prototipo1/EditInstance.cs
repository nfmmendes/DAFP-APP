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

namespace Prototipo1
{
    public partial class EditInstance : Form
    {
        private CustomSqlContext Context { get; set; }
        private long InstanceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="instanceId"></param>
        public EditInstance(CustomSqlContext context, long instanceId)
        {
            Context = context;
            InstanceId = instanceId;
            InitializeComponent();
            InitializeTextBoxes();
            
        }

        /// <summary>
        /// 
        /// </summary>
        private void InitializeTextBoxes(){
            var instance = Context.Instances.FirstOrDefault(x => x.Id == InstanceId);
            if (instance != null){
                this.textBoxScenarioDescription.Text = instance.Description;
                this.textBoxScenarioName.Text = instance.Name;
            }else{
                MessageBox.Show("Instance not found");
                this.Close();
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditScenario_Click(object sender, EventArgs e){
            
            InstancesController.Instance.Edit(InstanceId,textBoxScenarioName.Text,textBoxScenarioDescription.Text);
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
