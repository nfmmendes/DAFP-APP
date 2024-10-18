using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1.Components
{
    public partial class RequestsView : UserControl
    {
        public CustomSqlContext Context { get; set; }
        public DbInstance Instance { get; set; }

        public RequestsView(){
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void setInstance(DbInstance instance)
        {
            Instance = instance;
            FillRequestTables();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        private void FillRequestTables()
        {
            this.dataGridViewRequest.Rows.Clear();
            var requests = Context.Requests.ToList().Where(x => x.Instance.Id == Instance.Id).GroupBy(x => x.PNR).ToDictionary(x => x.Key, x => x.ToList());

            foreach (var key in requests.Keys){
                var value = requests[key].First();
                dataGridViewRequest.Rows.Add(key, key, value.Origin.AirportName, value.Destination?.AirportName, value.DepartureTimeWindowBegin,
                    value.DepartureTimeWindowEnd, value.ArrivalTimeWindowBegin, value.ArrivalTimeWindowEnd);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewRequest_RowEnter(object sender, DataGridViewCellEventArgs e){
            FillPassengerList(dataGridViewRequest.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        /// <summary>
        /// Fill the data grid view that shows the list of passengers. 
        /// This function will be called after a row of the request data grid view be selected
        /// </summary>
        /// <param name="PNR"></param>
        private void FillPassengerList(string PNR){
            this.dataGridViewPassenger.Rows.Clear();
            var passengers = Context.Requests.Where(x =>Instance.Id == x.Instance.Id &&  x.PNR.Equals(PNR));

            foreach (var item in passengers){
                this.dataGridViewPassenger.Rows.Add(item.Id, item.Name, item.Sex, item.IsChildren, item.Class);
            }
        }

        private TimeSpan TransformToTimespan(string time){
            var split = time.Split(':');
            if (split.Length == 3)
                return    TimeSpan.FromHours(Convert.ToInt32(split[0])) 
                        + TimeSpan.FromMinutes(Convert.ToInt32(split[1])) 
                        + TimeSpan.FromSeconds(Convert.ToInt32(split[2]));
            else if (split.Length == 2)
                return TimeSpan.FromHours(Convert.ToInt32(split[0]))
                       + TimeSpan.FromMinutes(Convert.ToInt32(split[1]));
            else{
                MessageBox.Show("Time data in wrong format");
                return TimeSpan.MinValue;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditRequest_Click(object sender, EventArgs e){
            
            if (Instance != null && dataGridViewRequest.SelectedRows.Count > 0){
                var editRequest = new AddEditRequest(Context);
                var rowIndex = dataGridViewRequest.SelectedRows[0].Index;

                editRequest.OpenToEdit(Instance, dataGridViewRequest.Rows[rowIndex].Cells[0].Value.ToString());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeletePassenger_Click(object sender, EventArgs e){
            if (this.dataGridViewPassenger.SelectedRows.Count>0){
                var index = Convert.ToInt64(this.dataGridViewPassenger.Rows[this.dataGridViewPassenger.SelectedRows[0].Index].Cells[0].Value);

                var deleted = Context.Requests.First(x => x.Id == index);
                if (deleted != null){
                    var PNR = deleted.PNR;
                    Context.Requests.Remove(deleted);
                    Context.SaveChanges();
                    FillRequestTables();
                    FillPassengerList(PNR);
                }
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditPassenger_Click(object sender, EventArgs e){

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddPassenger_Click(object sender, EventArgs e){
            if (dataGridViewPassenger.SelectedRows.Count > 0){
                var rowIndex = dataGridViewRequest.SelectedRows[0].Index;

                var pnr = dataGridViewRequest.Rows[rowIndex].Cells[1].Value.ToString();
                var originName = dataGridViewRequest.Rows[rowIndex].Cells[2].Value.ToString();
                var destinationName = dataGridViewRequest.Rows[rowIndex].Cells[3].Value.ToString();
                var minDeparture = TransformToTimespan(dataGridViewRequest.Rows[rowIndex].Cells[4].Value.ToString());
                var maxDeparture = TransformToTimespan(dataGridViewRequest.Rows[rowIndex].Cells[5].Value.ToString());
                var minArrival = TransformToTimespan(dataGridViewRequest.Rows[rowIndex].Cells[6].Value.ToString());
                var maxArrival = TransformToTimespan(dataGridViewRequest.Rows[rowIndex].Cells[7].Value.ToString());

                var origin = Context.Airports.FirstOrDefault(x => x.Instance.Id == Instance.Id && x.AirportName.Equals(originName));
                var destination = Context.Airports.FirstOrDefault(x => x.Instance.Id == Instance.Id && x.AirportName.Equals(destinationName));

                if (origin != null && destination != null && !string.IsNullOrEmpty(pnr)){
                    var addPassenger = new AddEditPassenger(Context, pnr);
                    addPassenger.OpenToAdd(Instance,pnr,origin,destination,minDeparture,maxDeparture,minArrival,maxArrival);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddRequest_Click(object sender, EventArgs e){
            var add = new AddEditRequest(Context);
            add.OpenToAdd(Instance);
            FillRequestTables();
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRemoveRequest_Click(object sender, EventArgs e){
            if (dataGridViewRequest.SelectedRows.Count > 0){

                for (int i = 0; i < dataGridViewRequest.SelectedRows.Count; i++){
                    var index = dataGridViewRequest.SelectedRows[i].Index;

                    var PNR = dataGridViewRequest.Rows[index].Cells[0].Value.ToString();
                    Context.Requests.Remove(Context.Requests.First(x => x.PNR.Equals(PNR) && x.Instance.Id == Instance.Id));
                }
                
                Context.SaveChanges();
                FillRequestTables();
                FillPassengerList("");
            }
            else
                MessageBox.Show("Select on request in the table");
        }

        private void RequestsView_Load(object sender, EventArgs e){
            FillRequestTables();
        }
    }
}
