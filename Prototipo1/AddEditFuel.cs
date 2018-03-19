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
    public partial class AddEditFuel : Form
    {

        public bool IsAdd { get; set; }
        public DbInstance Instance { get; set; }
        public DbFuelPrice CurrentElement { get; set; }
        private CustomSqlContext Context { get; set; }
        private long IdItem { get; set; }

        public AddEditFuel(CustomSqlContext context){
            InitializeComponent();
            Context = context;
        }

        public void OpenToAdd(DbInstance instance){
            this.Instance =instance;

            comboBoxAirport.DataSource = Context.Airports.ToList().Where(x => x.Instance.Id == instance.Id)
                .Select(x => x.AiportName).ToList();
            comboBoxCurrency.DataSource = Context.Exchange.ToList().Where(x => x.Instance.Id == instance.Id)
                .Select(x => x.CurrencySymbol).ToList();
            
            


            IsAdd = true;
            this.ShowDialog();
        }

        public void OpenToEdit(DbFuelPrice fuel, long IdFuel){
            IsAdd = false;
            IdItem = IdFuel;
            CurrentElement = fuel;

            if (CurrentElement != null){
                comboBoxAirport.DataSource = Context.Airports.ToList().Where(x => x.Instance.Id == CurrentElement.Instance.Id)
                    .Select(x => x.AiportName).ToList();
                comboBoxAirport.Text = CurrentElement.Airport.AiportName;
                comboBoxFuel.Text = "F";
                comboBoxCurrency.DataSource = Context.Exchange.ToList().Where(x => x.Instance.Id == CurrentElement.Instance.Id)
                    .Select(x => x.CurrencySymbol).ToList();
                comboBoxCurrency.SelectedText = CurrentElement.Currency;
                textBoxPrice.Text = CurrentElement.Value;
            }


            this.ShowDialog();
            
        }


        private void buttonCancel_Click(object sender, EventArgs e){
            this.Close(); 
        }

        private void buttonSave_Click(object sender, EventArgs e){

            var airport = Context.Airports.FirstOrDefault(x=>x.AiportName.Equals(comboBoxAirport.SelectedItem.ToString()));
            if (airport != null)
            {
                var item = new DbFuelPrice(){
                    Airport = airport,
                    Currency = comboBoxCurrency.SelectedItem.ToString(),
                    Value = textBoxPrice.Text,
                    Instance = this.Instance
                };

                if (IsAdd){
                    FuelController.Instance.Add(item);
                }else{
                    FuelController.Instance.Edit(item,IdItem);
                }
            }
            this.Close();

        }
    }
}
