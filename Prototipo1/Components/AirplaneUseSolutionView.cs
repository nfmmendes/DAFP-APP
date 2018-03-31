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
    public partial class AirplaneUseSolutionView : UserControl
    {
        public CustomSqlContext Context { get; set; }
        public DbInstance Instance { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public AirplaneUseSolutionView(){
            InitializeComponent();
        }


        /// <summary>
        /// Function to deal with the event of changing the selected index of the airplane combo box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxAirplaneSolution_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            var prefix = "";

            //Get the airplane prefix selected on the combo box
            if (this.comboBoxAirplaneSolution.Items.Count > 0)
                prefix = this.comboBoxAirplaneSolution.SelectedItem.ToString();

            if (Instance != null)
            {
                var airplane = Context.Airplanes.FirstOrDefault(x => x.Instance.Id == Instance.Id && x.Prefix.Equals(prefix));
                if (airplane != null)
                {
                    // Get the information of all flights that were performed by the airplane selected
                    var trips = Context.FlightsReports.Where(x => x.Instance.Id == Instance.Id && x.Airplanes.Prefix.Equals(airplane.Prefix)).ToList();

                    //Replace the data of the previous airplane flights by the data about the new airplane flights
                    dataGridViewRoutePassagers.Rows.Clear();
                    dataGridViewRoute.Rows.Clear();
                    foreach (var item in trips){

                        var weightOnDeparture = item.Airplanes.Weight + GetWeightOfPassengers(item) + item.FuelOnDeparture * 0.453592;
                        var weightOnArrival = item.Airplanes.Weight + GetWeightOfPassengers(item) + item.FuelOnArrival * 0.453592;

                        dataGridViewRoute.Rows.Add(item.Id, "X", item.Origin.AirportName,
                                                                item.FuelOnDeparture, weightOnDeparture,
                                                                item.DepartureTime.ToString("hh\\:mm"),
                                                                item.Destination.AirportName,
                                                                item.FuelOnArrival, weightOnArrival,
                                                                item.ArrivalTime.ToString("hh\\:mm"));
                    }
                }
            }
        }



        /// <summary>
        /// Get the weight of the passengers based on the parameters set to the instance that the flight belongs
        /// In other words, the flight belongs to the solution of an instance, and this instance has specific values to men, women and children weghts.
        /// The total weight of the airplane passengers is calculated based on these values. 
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        private double GetWeightOfPassengers(DbFlightsReport flight){
            var itemList = Context.PassagersOnFlight.Where(x => x.Flight.Id == flight.Id);
            var seatList = Context.SeatList.Where(x => x.Airplanes.Id == flight.Airplanes.Id).ToList();


            var sum = 0.0;
            foreach (var item in itemList){

                var seatClass = seatList.FirstOrDefault(x => x.seatClass.Equals(item.Passenger.Class));
                if (seatClass != null)
                    sum += seatClass.luggageWeightLimit;


                //TODO: Correct to get the values from database. THIS IS WRONG!!!!
                /*
                if (item.Passenger.Sex.Equals("M"))
                    sum += item.Passenger.IsChildren ? Convert.ToDouble(numUD_ChildWeight.Value) : Convert.ToDouble(numUD_ManWeight.Value);
                else
                    sum += item.Passenger.IsChildren ? Convert.ToDouble(numUD_ChildWeight.Value) : Convert.ToDouble(numUD_WomanWeight.Value);
                    */
            }
            return sum;
        }

        /// <summary>
        /// Function that deals with the event of selecting a row in the data grid view that describes a flight/route
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewRoute_RowEnter(object sender, DataGridViewCellEventArgs e){
            if (dataGridViewRoute.SelectedRows.Count > 0)
            {
                var indexRow = dataGridViewRoute.SelectedRows[0].Index;
                var index = Convert.ToInt64(dataGridViewRoute.Rows[indexRow].Cells[0].Value.ToString());

                var reports = Context.PassagersOnFlight.Where(x => x.Flight.Id.Equals(index)).ToList();

                dataGridViewRoutePassagers.Rows.Clear();
                foreach (var item in reports)
                    dataGridViewRoutePassagers.Rows.Add(item.Passenger.Name, item.Passenger.PNR, item.Passenger.Sex, item.Passenger.Class);

            }

        }

        /// <summary>
        /// Set the instance that will have its data showed
        /// </summary>
        /// <param name="instance"></param>
        public void setInstance(DbInstance instance){
            Instance = instance;
            this.comboBoxAirplaneSolution.DataSource = null; 

            if(Context.FlightsReports.Any())
                this.comboBoxAirplaneSolution.DataSource = Context.FlightsReports.Where(x => x.Instance.Id == instance.Id)
                                                                  .Select(x => x.Airplanes.Prefix).Distinct().ToList();
            if (this.comboBoxAirplaneSolution.Items.Count > 0)
                this.comboBoxAirplaneSolution.SelectedIndex = 0;

        }
    }
}
