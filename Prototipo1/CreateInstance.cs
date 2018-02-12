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
    public partial class CreateInstance : Form
    {
        private CoopserviceContext context; 
        public CreateInstance(CoopserviceContext context)
        {
            InitializeComponent();
            this.context = context; 
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

            var instance = new DbInstance()
            {
                CreatedOn = DateTime.Now,
                Description = this.textBoxScenarioDescription.Text,
                Name = this.textBoxScenarioName.Text,
                LastOptimization = DateTime.Now, //TODO : Change to nullable  
                Optimized = false
            };
            context.Instances.Add(instance);
            context.SaveChanges();
            this.Close();
        }
    }
}
