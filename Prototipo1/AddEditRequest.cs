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

        public AddEditRequest(CustomSqlContext context){
            InitializeComponent();
            Context = context;
        }

        public void OpenToAdd(DbInstance instance){
            Instance = instance;
            IsAdd = true;
            this.ShowDialog();
        }

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

        private void buttonSave_Click(object sender, EventArgs e){

            if (IsAdd){
                var result = MessageBox.Show("You need add passengers in this request. Would you like to do it now?" +
                                             " If you say no, a fake passenger will be created", "", MessageBoxButtons.YesNo);

            }
            else{

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

                        Context.Requests.AddOrUpdate(item);
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
        

        private void buttonCancel_Click(object sender, EventArgs e){
            this.Close();
        }
    }
}
