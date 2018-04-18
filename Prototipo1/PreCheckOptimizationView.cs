using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Solver;

namespace Prototipo1
{
    public partial class PreCheckOptimizationView : Form
    {
        public bool ContinueOptimization { get; private set; }

        public PreCheckOptimizationView(){
            InitializeComponent();
            ContinueOptimization = false; 
        }

        public void ExecutePreCheck(SolverInput input){
            
        }

        private void buttonContinue_Click(object sender, EventArgs e){
            ContinueOptimization = true;
            this.Close();
        }
    }
}
