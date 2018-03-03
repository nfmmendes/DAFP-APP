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
    public partial class AddEditFuel : Form
    {

        public bool IsAdd { get; set; }
        public DbInstance Instance { get; set; }
        public DbFuelPrice CurrentElement { get; set; }
        private CustomSqlContext Context { get; set; }

        public AddEditFuel(CustomSqlContext context){
            InitializeComponent();
            Context = context;
        }

        public void OpenToAdd(DbInstance instance){
            this.Instance = instance;
            IsAdd = true;
            this.ShowDialog();
        }

        public void OpenToEdit(DbInstance instance, long IdFuel){
            IsAdd = false;
            CurrentElement = Context.FuelPrice.FirstOrDefault(x => x.Id == IdFuel);

            if (CurrentElement != null){
                comboBoxAirport.DataSource = Context.Airports.ToList().Where(x => x.Instance.Id == CurrentElement.Instance.Id)
                    .Select(x => x.AiportName).ToList();
                comboBoxAirport.SelectedText = CurrentElement.Airport.AiportName;
                comboBoxFuel.SelectedText = "F";
                comboBoxCurrency.DataSource = Context.Airports.ToList().Where(x => x.Instance.Id == CurrentElement.Instance.Id)
                    .Select(x => x.AiportName).ToList();
                comboBoxCurrency.SelectedText = CurrentElement.Currency;
                textBoxPrice.Text = CurrentElement.Value;
            }


            this.ShowDialog();
            
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
