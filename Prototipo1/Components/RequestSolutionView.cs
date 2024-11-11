using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SolverClientComunication;
using SolverClientComunication.Models;
using System.Runtime.Versioning;

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
        [SupportedOSPlatform("windows7.0")]
        public void setInstance(DbInstance instance)
        {
            Instance = instance;
             FillRequestSolutionTable();

        }

        /// <summary>
        /// 
        /// </summary>
        [SupportedOSPlatform("windows7.0")]
        private void FillRequestSolutionTable()
        {

            dataGridViewRequestsResult.Rows.Clear();
            if (Context.Requests.Any()){
                var requests = Context.Requests.Where(x => x.Instance.Id == Instance.Id).GroupBy(x => x.PNR).ToDictionary(x => x.Key, x => x.ToList());

                //var flightList = Context.FlightsReports.Where(x => x.Instance.Id == Instance.Id);
                var toShortData = (TimeSpan t) => t.ToString(@"hh\:mm");
                foreach (var key in requests.Keys){
                    var value = requests[key].First();
                    _ = dataGridViewRequestsResult.Rows.Add(key,
                                                            key,
                                                            value.Origin.AirportName,
                                                            value.Destination.AirportName,
                                                            toShortData(value.DepartureTimeWindowBegin),
                                                            toShortData(value.DepartureTimeWindowEnd),
                                                            toShortData(value.ArrivalTimeWindowBegin),
                                                            toShortData(value.ArrivalTimeWindowEnd));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [SupportedOSPlatform("windows7.0")]
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

        [SupportedOSPlatform("windows7.0")]
        private void RequestSolutionView_Load(object sender, EventArgs e){
            FillRequestSolutionTable();
        }
    }
}
