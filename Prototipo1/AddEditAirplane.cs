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
    public partial class AddEditAirplane : Form
    {

        private bool IsAdd { get; set; }
        private long IdItem { get; set; }
        public DbInstance Instance { get; set; }
        public DbAirplane CurrentElement { get; set;  }
        public CustomSqlContext Context { get; set; }

        public AddEditAirplane(CustomSqlContext context){
            InitializeComponent();
            Context = context;

        }

        public void OpenToAdd(DbInstance instance){
            Instance = instance;
            IsAdd = true;
            comboBoxAirport.DataSource = Context.Airports.Where(x => x.Instance.Id == Instance.Id).Select(x => x.AirportName).Distinct().ToList();
            this.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="idAIrplane"></param>
        public void OpenToEdit(DbInstance instance, long idAIrplane){
            Instance = instance;
            IsAdd = false;
            IdItem = idAIrplane; 

            CurrentElement = Context.Airplanes.FirstOrDefault(x => x.Id == idAIrplane);
            comboBoxAirport.DataSource = Context.Airports.Where(x=>x.Instance.Id == Instance.Id).Select(x => x.AirportName).Distinct().ToList();


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

      
                comboBoxAirport.SelectedText = CurrentElement.BaseAirport.AirportName;

                this.ShowDialog();
            }else
                MessageBox.Show("Internal error on edit");

        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            var airport = Context.Airports.FirstOrDefault(x=>x.AirportName.Equals(comboBoxAirport.SelectedItem.ToString()));

            var airplane = new DbAirplane()
            {
                Model = comboBoxModel.SelectedItem.ToString(),
                Prefix = textBoxPrefix.Text,
                BaseAirport = airport,
                Capacity = Convert.ToInt32(numUDCapacity.Value),
                CruiseSpeed = Convert.ToDouble(numUDCruiseSpeed.Value),
                FuelConsumptionFirstHour = Convert.ToInt32(numUDFuelStHour.Value),
                FuelConsumptionSecondHour = Convert.ToInt32(numUDFuelNdHour.Value),
                Range = Convert.ToInt32(numUDRange.Value),
                Weight = Convert.ToInt32(numUDWeight.Value),
                MaxWeight = Convert.ToInt32(numUDMTOW.Value),
                MaxFuel = Convert.ToInt32(numUDMaxFuel.Value),
                Instance = Instance,
            };

            if(IsAdd)
                AirplaneController.Instance.Add(airplane);
            else
                AirplaneController.Instance.Edit(airplane,IdItem);
                
            this.Close();

        }

        private void buttonCancel_Click(object sender, EventArgs e){
            this.Close();
        }
    }
}
