using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolverClientComunication.Models;

namespace Prototipo1
{
    public partial class AddEditFuel : Form
    {

        public bool IsAdd { get; set; }
        public DbInstance Instance { get; set; }

        public AddEditFuel()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e){
            this.Close(); 
        }

        private void buttonSave_Click(object sender, EventArgs e){
            if (IsAdd){
                //TODO:
            }else{
                //TODO: 
            }
        }
    }
}
