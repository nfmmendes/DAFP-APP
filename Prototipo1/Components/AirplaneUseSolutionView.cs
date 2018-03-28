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

        public AirplaneUseSolutionView(){
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxAirplaneSolution_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            var prefix = "";

            if (this.comboBoxAirplaneSolution.Items.Count > 0)
                prefix = this.comboBoxAirplaneSolution.SelectedItem.ToString();



            if (Instance != null)
            {
                var airplane = Context.Airplanes.FirstOrDefault(x => x.Instance.Id == Instance.Id && x.Prefix.Equals(prefix));
                if (airplane != null)
                {
                    var test = Context.FlightsReports.ToList();
                    var trips = Context.FlightsReports.Where(x => x.Instance.Id == Instance.Id && x.Airplanes.Prefix.Equals(airplane.Prefix)).ToList();

                    dataGridViewRoutePassagers.Rows.Clear();
                    dataGridViewRoute.Rows.Clear();
                    foreach (var item in trips)
                    {

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
        /// 
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        private double GetWeightOfPassengers(DbFlightsReport flight){
            var itemList = Context.PassagersOnFlight.Where(x => x.Flight.Id == flight.Id);
            var seatList = Context.SeatList.Where(x => x.Airplanes.Id == flight.Airplanes.Id).ToList();


            var sum = 0.0;
            foreach (var item in itemList)
            {
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
        /// 
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
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void setInstance(DbInstance instance){
            Instance = instance;

            this.comboBoxAirplaneSolution.DataSource = Context.FlightsReports.Where(x => x.Instance.Id == instance.Id)
                .Select(x => x.Airplanes.Prefix).Distinct().ToList();
            if (this.comboBoxAirplaneSolution.Items.Count > 0)
                this.comboBoxAirplaneSolution.SelectedIndex = 0;

        }
    }
}
