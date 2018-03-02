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
    public partial class AddEditRequest : Form
    {

        private bool IsAdd { get; set; }
        public DbInstance Instance { get; set; }

        public AddEditRequest(){
            InitializeComponent();
        }

        public void OpenToAdd(DbInstance instance){
            Instance = instance;
            IsAdd = true;
            this.ShowDialog();
        }

        public void OpenToEdit(DbInstance instance, string PNRCode){
            Instance = instance;
            IsAdd = false;
            this.ShowDialog(); 
        }

        private void buttonSave_Click(object sender, EventArgs e){

        }

        private void buttonCancel_Click(object sender, EventArgs e){
            this.Close();
        }
    }
}
