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
    public partial class CreateInstance : Form
    {
        private CustomSqlContext Context; 
        public CreateInstance(CustomSqlContext context)
        {
            InitializeComponent();
            this.Context = context; 
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCreateScenario_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBoxScenarioName.Text)){
                MessageBox.Show("Fill the field \"Name\"");
                return; 
            }

            InstancesController.Instance.Add(this.textBoxScenarioName.Text, this.textBoxScenarioDescription.Text);
            this.Close();
        }
    }
}
