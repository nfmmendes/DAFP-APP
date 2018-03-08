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
    public partial class AddEditAirplane : Form
    {

        private bool IsAdd { get; set; }
        public DbInstance Instance { get; set; }
        public DbAirplanes CurrentElement { get; set;  }
        public CustomSqlContext Context { get; set; }

        public AddEditAirplane(CustomSqlContext context){
            InitializeComponent();
            Context = context;

        }

        public void OpenToAdd(DbInstance instance){
            Instance = instance;
            IsAdd = true;
            this.ShowDialog();
        }

        public void OpenToEdit(DbInstance instance, long idAIrplane){
            Instance = instance;
            IsAdd = false;

            CurrentElement = Context.Airplanes.FirstOrDefault(x => x.Id == idAIrplane);

            if (CurrentElement != null){

                comboBoxModel.DataSource = Context.Airplanes.ToList().Where(x => x.Instance.Id == CurrentElement.Instance.Id)
                                                                    .Select(x => x.Model).Distinct().ToList();
                textBoxPrefix.Text = CurrentElement.Prefix;
                numUDRange.Value = CurrentElement.Range;
                numUDWeight.Value = CurrentElement.Weight;
                numUDMTOW.Value = CurrentElement.MaxWeight;
                numUDCruiseSpeed.Value = Convert.ToDecimal(CurrentElement.CruiseSpeed);
                numUDFuelStHour.Value = CurrentElement.FuelConsumptionFirstHour;
                numUDFuelNdHour.Value = CurrentElement.FuelConsumptionSecondHour;
                numUDMaxFuel.Value = Convert.ToDecimal(CurrentElement.MaxFuel);
                numUDCapacity.Value = Convert.ToDecimal(CurrentElement.Capacity);

                comboBoxAirport.DataSource= Context.Airplanes.ToList().Where(x=>x.Instance.Id == CurrentElement.Instance.Id)
                                                                     .Select(x=>x.BaseAirport.AiportName).Distinct().ToList();
                comboBoxAirport.SelectedText = CurrentElement.BaseAirport.AiportName;

                this.ShowDialog();
            }else
                MessageBox.Show("Internal error on edit");



            
        }


        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e){
            this.Close();
        }
    }
}
