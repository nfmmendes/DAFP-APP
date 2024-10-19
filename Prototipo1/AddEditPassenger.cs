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
    public partial class AddEditPassenger : Form
    {
        private CustomSqlContext Context { get; set; }
        private string PNR { get; set; }
        private DbInstance Instance { get; set; }
        private bool IsAdd { get; set; }

        private DbAirport Origin { get; set; }
        private DbAirport Destination { get; set; }
        private TimeSpan MinDepartureTime { get; set; }
        private TimeSpan MaxDepartureTime { get; set; }
        private TimeSpan MinArrivalTime { get; set; }
        private TimeSpan MaxArrivalTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="PNR"></param>
        public AddEditPassenger(CustomSqlContext context, string PNR){
            InitializeComponent();
            Context = context;
            this.PNR = PNR;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e){
            this.Close();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="pnr"></param>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <param name="minDeparture"></param>
        /// <param name="maxDeparture"></param>
        /// <param name="minArrival"></param>
        /// <param name="maxArrival"></param>
        public void OpenToAdd(DbInstance instance, string pnr, DbAirport origin, DbAirport destination, TimeSpan minDeparture, TimeSpan maxDeparture, 
                              TimeSpan minArrival, TimeSpan maxArrival){
            Instance = instance;
            IsAdd = true;
            FillTable();

            PNR = pnr;
            Origin = origin;
            Destination = destination;
            MinDepartureTime = minDeparture;
            MaxDepartureTime = maxDeparture;
            MinArrivalTime = minArrival;
            MaxDepartureTime = MaxArrivalTime;

            this.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        private void FillTable(){
            dataGridViewPassenger.Rows.Clear();
            if (!string.IsNullOrEmpty(PNR) && Instance != null){
                var requests = Context.Requests.Where(x=>x.Instance.Id == Instance.Id && x.PNR.Equals(PNR));

                foreach (var item in requests){
                    dataGridViewPassenger.Rows.Add(item.Id, item.Name, item.Sex, item.IsChildren, item.Class);                    
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="PNRCode"></param>
        /// <param name="Id"></param>
        public void OpenToEdit(DbInstance instance, string PNRCode, int Id = -1){
            Instance = instance;
            PNR = PNRCode;
            this.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit_Click(object sender, EventArgs e){
            this.buttonAdd.Text = "Save";
            if (this.dataGridViewPassenger.SelectedRows.Count > 0){
                var index = dataGridViewPassenger.SelectedRows[0].Index;
                var id = dataGridViewPassenger.Rows[index].Cells[0];

            }else{
                MessageBox.Show("Please, select a passenger!!");
                this.buttonAdd.Text = "Add";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {


            var passenger = this.textBoxPassenger.Text;
            var seatClass = this.textBoxClass.Text;
            var isChildren = this.radioButtonIsChildren.Checked;
            var sex = this.radioButtonFemale.Checked ? "F" : "M";

            if (Origin != null && Destination != null && !string.IsNullOrEmpty(PNR) && !string.IsNullOrEmpty(passenger) && !string.IsNullOrEmpty(seatClass)){
                var item = new DbRequest()
                {
                    PNR = PNR,
                    Origin = Origin,
                    Destination = Destination,
                    DepartureTimeWindowBegin = MinDepartureTime,
                    DepartureTimeWindowEnd = MaxDepartureTime,
                    ArrivalTimeWindowBegin = MinArrivalTime,
                    ArrivalTimeWindowEnd = MaxArrivalTime,
                    Name = passenger,
                    Sex = sex,
                    IsChildren = isChildren,
                    Class = seatClass,
                    Instance  = Instance,
                };

                Context.Requests.Add(item);
                Context.SaveChanges();
            }
            FillTable();

        }
    }
}
