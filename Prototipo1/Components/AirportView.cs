using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1.Components
{
    public partial class AirportView : UserControl
    {
        public CustomSqlContext Context { get; set; }
        public DbInstance Instance { get; set; }

        public AirportView(){
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void setInstance(DbInstance instance)
        {
            Instance = instance;
            FillAirportsTable();

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        private void FillAirportsTable()
        {
            this.dataGridViewAirport.Rows.Clear();
            var airports = Context.Airports.ToList().Where(x => x.Instance.Id == Instance.Id);
            foreach (var item in airports){
                dataGridViewAirport.Rows.Add(item.Id, item.AirportName, item.IATA, item.Latitude, item.Longitude, item.Elevation,
                    item.RunwayLength, item.Region, item.MTOW_APE3, item.MTOW_PC12, item.LandingCost, item.GroundTime);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteAirport_Click(object sender, EventArgs e)
        {

            if (dataGridViewAirport.SelectedRows.Count > 0)
            {
                var message = "All information related with these airports will be deleted. Do you want continue?";
                var result = MessageBox.Show(message, "", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridViewAirport.Rows.Count; i++){

                        //TODO: Put it in an controller 
                        if (!dataGridViewAirport.Rows[i].Selected) continue;

                        var index = Convert.ToInt64(dataGridViewAirport.Rows[i].Cells[0].Value);
                        var deleted = Context.Airports.FirstOrDefault(x => x.Id == index);
                        var stretchDelete = Context.Stretches.Where(x=> x.InstanceId == deleted.Instance.Id && (x.Origin.Equals(deleted.AirportName) || x.Destination.Equals(deleted.AirportName)));
                        var requestsDelete = Context.Requests.Where(x=>x.Origin.Id == deleted.Id || x.Destination.Id == deleted.Id);
                        var fuelDelete = Context.FuelPrices.Where(x => x.Airport.Id == deleted.Id);

                        if (fuelDelete.Any())
                            Context.FuelPrices.RemoveRange(fuelDelete.ToList());

                        if (requestsDelete.Any())
                            Context.Requests.RemoveRange(requestsDelete.ToList());

                        if(stretchDelete.Any())
                            Context.Stretches.RemoveRange(stretchDelete.ToList());

                        var airplanesDelete = Context.Airplanes.Where(x => x.BaseAirport.Id == deleted.Id);
                        if(airplanesDelete.Any())
                            Context.Airplanes.RemoveRange(airplanesDelete.ToList());
                        Context.SaveChanges();

                        if (deleted != null)
                            Context.Airports.Remove(deleted);
                    }

                    Context.SaveChanges();
                    FillAirportsTable();
                }
            }
            else
                MessageBox.Show("There are no selected airplanes");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditAirport_Click(object sender, EventArgs e)
        {

            if (Instance != null){

                if (dataGridViewAirport.SelectedRows.Count > 0){
                    var first = dataGridViewAirport.SelectedRows[0].Index;
                    var indexAirport = Convert.ToInt64(dataGridViewAirport.Rows[first].Cells[0].Value);
                    var addAirport = new AddEditAirport(Context);
                    addAirport.OpenToEdit(Instance, indexAirport); 
                    FillAirportsTable();
                }else
                    MessageBox.Show("Select one airport");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddAirport_Click(object sender, EventArgs e){
            if (Instance != null){
                var addAirport = new AddEditAirport(Context);
                addAirport.OpenToAdd(Instance);
                FillAirportsTable();
            }
        }

        private void AirportView_Load(object sender, EventArgs e){
            FillAirportsTable();
        }
    }
}
