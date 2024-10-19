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
    public partial class RequestSolutionView : UserControl{

        public CustomSqlContext Context { get; set; }
        public DbInstance Instance { get; set; }

        public RequestSolutionView(){
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void setInstance(DbInstance instance)
        {
            Instance = instance;
             FillRequestSolutionTable();

        }

        /// <summary>
        /// 
        /// </summary>
        private void FillRequestSolutionTable()
        {

            this.dataGridViewRequestsResult.Rows.Clear();
            if (Context.Requests.Any()){
                var requests = Context.Requests.Where(x => x.Instance.Id == Instance.Id).GroupBy(x => x.PNR).ToDictionary(x => x.Key, x => x.ToList());

                //var flightList = Context.FlightsReports.Where(x => x.Instance.Id == Instance.Id);

                foreach (var key in requests.Keys){
                    var value = requests[key].First();
                    dataGridViewRequestsResult.Rows.Add(key, key, value.Origin.AirportName,
                        value.Destination.AirportName, value.DepartureTimeWindowBegin.ToString(@"hh\:mm"),value.DepartureTimeWindowEnd.ToString(@"hh\:mm"),
                        value.ArrivalTimeWindowBegin.ToString(@"hh\:mm"), value.ArrivalTimeWindowEnd.ToString(@"hh\:mm"));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewRequestsResult_RowEnter(object sender, DataGridViewCellEventArgs e){

            if (dataGridViewRequestsResult.SelectedRows.Count > 0)
            {
                var index = dataGridViewRequestsResult.SelectedRows[0].Index;
                var PNR = dataGridViewRequestsResult.Rows[index].Cells[0].Value.ToString();

                var passengerList = Context.PassengersOnFlight.ToList().Where(x => x.Passenger.PNR.Equals(PNR)  && x.Flight.Instance.Id == Instance.Id);

                dataGridViewRequestSolutionDetails.Rows.Clear();

                foreach (var passenger in passengerList){
                    dataGridViewRequestSolutionDetails.Rows.Add("x", passenger.Passenger.Name,
                        passenger.Flight.Airplanes.Prefix,
                        passenger.Flight.Origin.AirportName,
                        passenger.Flight.DepartureTime.ToString(@"hh\:mm"),
                        passenger.Flight.Destination.AirportName,
                        passenger.Flight.ArrivalTime.ToString(@"hh\:mm"));
                }


            }
        }

        private void RequestSolutionView_Load(object sender, EventArgs e){
            FillRequestSolutionTable();
        }
    }
}
