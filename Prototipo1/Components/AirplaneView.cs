using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SolverClientComunication;
using SolverClientComunication.Models;
using Microsoft.EntityFrameworkCore;

namespace Prototipo1.Components
{
    public partial class AirplaneView : UserControl
    {
        public CustomSqlContext Context { get; set; }
        public DbInstance Instance { get; set; }

        /// <summary>
        /// Sets the object that access the database
        /// </summary>
        /// <param name="context">Object that will access the database </param>
        public AirplaneView(){
            InitializeComponent();
        }

        /// <summary>
        /// Set the instance that will have its data showed
        /// </summary>
        /// <param name="instance"></param>
        public void setInstance(DbInstance instance){
            Instance = instance;
            FillAirplaneTables();

        }

        /// <summary>
        /// Fill the seat class information based on the airplane id
        /// </summary>
        /// <param name="idAirplane">Id of the airplane</param>
        private void FillSeatTypeList(long idAirplane)
        {
            this.dataGridViewSeatTypes.Rows.Clear();

            var seatTypes = Context.Seats.Where(x => x.Airplanes.Id == idAirplane).ToList();

            //if(seatTypes.Any())
            foreach (var item in seatTypes)
                dataGridViewSeatTypes.Rows.Add(item.Id, item.seatClass, item.luggageWeightLimit);
        }

        /// <summary>
        /// This function deals with the event of selecting a row on the airplane table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewAirplane_RowEnter(object sender, DataGridViewCellEventArgs e){
            FillSeatTypeList(Convert.ToInt64(dataGridViewAirplane.Rows[e.RowIndex].Cells[0].Value));
        }

        /// <summary>
        /// Fill the instance airplane data 
        /// </summary>
        /// <param name="instance"></param>
        private void FillAirplaneTables(){

            this.dataGridViewAirplane.Rows.Clear();
            this.dataGridViewSeatTypes.Rows.Clear();
            if (Context.Airplanes.Any()){
                var airplanes = Context.Airplanes.Where(x => x.Instance.Id == Instance.Id).ToList();

                foreach (var item in airplanes)
                    dataGridViewAirplane.Rows.Add(item.Id, item.Model, item.Prefix, item.Range, item.Weight, item.MaxWeight, item.CruiseSpeed,
                        item.FuelConsumptionFirstHour, item.FuelConsumptionSecondHour, item.MaxFuel, item.Capacity,
                        item.BaseAirport?.AirportName);
            }
            

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditAirplane_Click(object sender, EventArgs e)
        {
            
            if (Instance != null && dataGridViewAirplane.SelectedRows.Count > 0)
            {
                var addAirplane = new AddEditAirplane(Context);

                var indexRow = dataGridViewAirplane.SelectedRows[0].Index;

                addAirplane.OpenToEdit(Instance, Convert.ToInt64(dataGridViewAirplane.Rows[indexRow].Cells[0].Value));
                FillAirplaneTables();

                dataGridViewAirplane.Rows.Clear();
                FillAirplaneTables();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditAirplaneSeatType_Click(object sender, EventArgs e){

            if (this.dataGridViewAirplane.SelectedRows.Count > 0){
                var idAirplane = Convert.ToInt64(this.dataGridViewAirplane.SelectedRows[0].Cells[0].Value);
                var airplane = Context.Airplanes.FirstOrDefault(x => x.Id == idAirplane);

                if (Instance != null && dataGridViewSeatTypes.SelectedRows.Count > 0 && airplane != null){
                    var editSeatType = new AddEditSeatType(Context);
                    var index = dataGridViewSeatTypes.SelectedRows[0].Index;
                    editSeatType.SetAirplane(airplane);
                    editSeatType.OpenToEdit(Instance, Convert.ToInt64(dataGridViewSeatTypes.Rows[index].Cells[0].Value));
                }
            }

        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteAirplaneSeatType_Click(object sender, EventArgs e)
        {
            if (dataGridViewSeatTypes.SelectedRows.Count > 0)
            {
                var message = "All information related with these seats will be deleted. Do you want continue?";
                var result = MessageBox.Show(message, "", MessageBoxButtons.YesNo);
                long idAirplane = 0;

                //TODO: Put it in the airplane controller 
                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridViewSeatTypes.Rows.Count; i++)
                    {
                        if (!dataGridViewSeatTypes.Rows[i].Selected) continue;

                        var index = Convert.ToInt64(dataGridViewSeatTypes.Rows[i].Cells[0].Value);
                        var deleted = Context.Seats.FirstOrDefault(x => x.Id == index);
                        idAirplane = deleted.Airplanes.Id;
                        if (deleted != null)
                            Context.Seats.Remove(deleted);
                    }

                    Context.SaveChanges();
                    FillSeatTypeList(idAirplane);
                }
            }
            else
                MessageBox.Show("There are no selected seat types");
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteAirplane_Click(object sender, EventArgs e)
        {
            if (dataGridViewAirplane.SelectedRows.Count > 0){
                var message = "All information related with these airplanes will be deleted. Do you want continue?";
                var result = MessageBox.Show(message, "", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridViewAirplane.Rows.Count; i++)
                    {
                        if (!dataGridViewAirplane.Rows[i].Selected) continue;

                        var index = Convert.ToInt64(dataGridViewAirplane.Rows[i].Cells[0].Value);
                        var deleted = Context.Airplanes.FirstOrDefault(x => x.Id == index);
                        if (deleted != null)
                            Context.Airplanes.Remove(deleted);
                    }

                    Context.SaveChanges();
                    
                    FillAirplaneTables();
                }
            }else
                MessageBox.Show("There are no selected airplanes");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getSelectedInstanceName(string selectedValue)
        {
            var selectedLabel = selectedValue;
            var instanceName = selectedLabel.Split('(')[0];
            return instanceName.Substring(0, instanceName.Length - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddAirplaneSeatType_Click(object sender, EventArgs e){

            if (this.dataGridViewAirplane.SelectedRows.Count > 0){
                var idAirplane = Convert.ToInt64(this.dataGridViewAirplane.SelectedRows[0].Cells[0].Value);
                var airplane = Context.Airplanes.FirstOrDefault(x=>x.Id == idAirplane);

                if (Instance != null && airplane != null){
                    var addSeat = new AddEditSeatType(Context);
                    addSeat.SetAirplane(airplane);
                    addSeat.OpenToAdd(Instance);
                }
                FillSeatTypeList(idAirplane);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddAirplane_Click(object sender, EventArgs e){
            if (Instance != null && dataGridViewAirplane.SelectedRows.Count > 0){
                var addAirplane = new AddEditAirplane(Context);
                addAirplane.OpenToAdd(Instance);
            }
        }

        private void AirplaneView_Load(object sender, EventArgs e){
            FillAirplaneTables();
        }
    }
}
