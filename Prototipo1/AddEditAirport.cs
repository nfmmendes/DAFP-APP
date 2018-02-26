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
    public partial class AddEditAirport : Form
    {
        private bool IsAdd { get; set; }
        public DbInstance Instance { get; set; }

        public AddEditAirport(){
            InitializeComponent();
        }

        public void OpenToAdd(DbInstance instance){
            this.ShowDialog();
            Instance = instance;
            IsAdd = true; 
        }

        public void OpenToEdit(DbInstance instance,long idAiport){
            this.ShowDialog();
            Instance = instance; 
            IsAdd = false; 
        }

        private void buttonSave_Click(object sender, EventArgs e){
            if (IsAdd){
                //TODO: 
            }else{
                
            }
           
        }

        private void buttonCancel_Click(object sender, EventArgs e){
            this.Close();
        }
    }
}
