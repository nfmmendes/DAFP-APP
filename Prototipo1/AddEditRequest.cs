using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1
{
    public partial class AddEditRequest : Form
    {

        private bool IsAdd { get; set; }
        public DbInstance Instance { get; set; }
        private string CurrentPNR { get; set; }
        private CustomSqlContext Context { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AddEditRequest(CustomSqlContext context){
            InitializeComponent();
            Context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void OpenToAdd(DbInstance instance){
            Instance = instance;
            IsAdd = true;

            this.comboBoxOrigin.DataSource = Context.Airports.ToList().Where(x => x.Instance.Id == instance.Id).Select(x => x.AirportName).ToList();
            this.comboBoxDestination.DataSource = Context.Airports.ToList().Where(x => x.Instance.Id == instance.Id).Select(x => x.AirportName).ToList();

            this.comboBoxOrigin.SelectedIndex = 0;
            this.comboBoxDestination.SelectedIndex = 0;

            this.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="PNRCode"></param>
        public void OpenToEdit(DbInstance instance, string PNRCode){
            Instance = instance;
            IsAdd = false;
            CurrentPNR = PNRCode;

            var currentElement = Context.Requests.FirstOrDefault(x => x.PNR.Equals(PNRCode));

            if (currentElement != null){
                this.textBoxPNR.Text = CurrentPNR;
                this.textBoxPNR.ReadOnly = true;

                this.comboBoxOrigin.DataSource = Context.Airports.ToList().Where(x=>x.Instance.Id == instance.Id).Select(x=>x.AirportName).ToList();
                this.comboBoxDestination.DataSource = Context.Airports.ToList().Where(x => x.Instance.Id == instance.Id).Select(x => x.AirportName).ToList();

                this.comboBoxOrigin.Text = currentElement.Origin.AirportName;
                this.comboBoxDestination.Text = currentElement.Destination.AirportName;

                numUD_Hr_MinDep.Value = currentElement.DepartureTimeWindowBegin.Hours;
                numUD_Min_MinDep.Value = currentElement.DepartureTimeWindowBegin.Minutes;

                numUD_Hr_MaxDep.Value = currentElement.DepartureTimeWindowEnd.Hours;
                numUD_Min_MaxDep.Value = currentElement.DepartureTimeWindowEnd.Minutes;

                numUD_Hr_MinArr.Value = currentElement.ArrivalTimeWindowBegin.Hours;
                numUD_Min_MinArr.Value = currentElement.ArrivalTimeWindowBegin.Minutes;

                numUD_Hr_MaxArr.Value = currentElement.ArrivalTimeWindowEnd.Hours;
                numUD_Min_MaxArr.Value = currentElement.ArrivalTimeWindowEnd.Minutes;
            }
            
            this.ShowDialog(); 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e){

            if (IsAdd){

                if (string.IsNullOrEmpty(this.textBoxPNR.Text)){
                    MessageBox.Show("The PNR field can not be empty");
                    return;
                }
                    

                var result = MessageBox.Show("You need add passengers in this request. Would you like to do it now?" +
                                             " If you say no, a fake passenger will be created", "", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes){
                    var passenger = new AddEditPassenger(Context,textBoxPNR.Text);

                    
                    var originName = this.comboBoxOrigin.SelectedItem.ToString();
                    var destinationName = this.comboBoxDestination.SelectedItem.ToString();
                    var origin = Context.Airports.FirstOrDefault(x=>x.Instance.Id == Instance.Id && x.AirportName.Equals(originName));

                    var pnr = this.textBoxPNR.Text;
                    var destination = Context.Airports.FirstOrDefault(x =>x.Instance.Id == Instance.Id && x.AirportName.Equals(destinationName));
                    var minDeparture = TimeSpan.FromHours(Convert.ToInt32(numUD_Hr_MinDep.Value)) + TimeSpan.FromMinutes(Convert.ToInt32(numUD_Min_MinDep.Value));
                    var maxDeparture = TimeSpan.FromHours(Convert.ToInt32(numUD_Hr_MaxDep.Value)) + TimeSpan.FromMinutes(Convert.ToInt32(numUD_Min_MaxDep.Value));
                    var minArrival = TimeSpan.FromHours(Convert.ToInt32(numUD_Hr_MinArr.Value)) + TimeSpan.FromMinutes(Convert.ToInt32(numUD_Min_MinArr.Value));
                    var maxArrival = TimeSpan.FromHours(Convert.ToInt32(numUD_Hr_MaxArr.Value)) + TimeSpan.FromMinutes(Convert.ToInt32(numUD_Min_MaxArr.Value));

                    

                    if(origin != null && destination != null)
                        passenger.OpenToAdd(Instance,pnr,origin, destination,minDeparture,maxDeparture,minArrival,maxArrival);
                    else
                        MessageBox.Show("Airports not found. Observe the values selected");
                }else{
                    
                }

            }else{

                var changed = Context.Requests.Where(x => x.PNR.Equals(this.textBoxPNR.Text)).ToList();

                foreach (var item in changed){

                    var airports = Context.Airports.ToList();
                    var origin = airports.FirstOrDefault(x => x.Instance.Id == Instance.Id && x.AirportName.Equals(comboBoxOrigin.Text));
                    var destination = Context.Airports.ToList().FirstOrDefault(x => x.Instance.Id == Instance.Id && x.AirportName.Equals(comboBoxDestination.Text));

                    if (origin != null && destination != null)
                    {
                        item.Origin = origin;
                        item.Destination = destination;
                        item.DepartureTimeWindowBegin = new TimeSpan(Convert.ToInt32(numUD_Hr_MinDep.Value), Convert.ToInt32(numUD_Min_MinDep.Value), 0);
                        item.DepartureTimeWindowEnd = new TimeSpan(Convert.ToInt32(numUD_Hr_MaxDep.Value), Convert.ToInt32(numUD_Min_MaxDep.Value), 0);
                        item.ArrivalTimeWindowBegin = new TimeSpan(Convert.ToInt32(numUD_Hr_MinArr.Value), Convert.ToInt32(numUD_Min_MinArr.Value), 0);
                        item.ArrivalTimeWindowEnd = new TimeSpan(Convert.ToInt32(numUD_Hr_MaxArr.Value), Convert.ToInt32(numUD_Min_MaxArr.Value), 0);

                        Context.Requests.Update(item);
                    }
                    else
                    {
                        MessageBox.Show("Invalid airports names");
                    }
                }
                Context.SaveChanges();
            }

            this.Close();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e){
            this.Close();
        }
    }
}
