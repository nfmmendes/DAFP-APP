using System;
using System.Linq;
using System.Windows.Forms;
using Prototipo1.Controller;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1
{
    public partial class AddEditAirport : Form
    {
        private bool IsAdd { get; set; }
        public DbInstance Instance { get; set; }
        private long IdItem { get; set; }
        private CustomSqlContext Context { get; set; }
        private DbAirports CurrentElement { get; set; }

        public AddEditAirport(CustomSqlContext context){
            InitializeComponent();
            Context = context;
        }

        public void OpenToAdd(DbInstance instance){
            Instance = instance;
            IsAdd = true;
            this.ShowDialog();
        }

        public void OpenToEdit(DbInstance instance, long idAiport){
            Instance = instance;
            IsAdd = false;
            
           
            IdItem = idAiport;

            CurrentElement = Context.Airports.FirstOrDefault(x => x.Id == idAiport);
            if (CurrentElement != null){
                textBoxName.Text = CurrentElement.AirportName;
                textBoxIATA.Text = CurrentElement.IATA;
                textBoxRegion.Text = CurrentElement.Region;
                numUD_Elevation.Value = CurrentElement.Elevation;
                numUD_LandCost.Value = CurrentElement.LandingCost;
                numUD_MTOW_AP3.Value = CurrentElement.MTOW_APE3;
                numUD_MTOW_PC12.Value = CurrentElement.MTOW_PC12;
                numUD_RunwayLen.Value = CurrentElement.RunwayLength;
                numUD_GroundTime.Value = CurrentElement.GroundTime.Minutes;

                var splitLat = CurrentElement.Latitude.Split('°');

                //Parse the latitude from string to DMS and fill the numeric up downs
                if (splitLat.Length > 1){
                    numUD_LatDeg.Value = Convert.ToInt32(splitLat[0]);

                    var minutes = splitLat[1].Split('\'');
                    if (minutes.Length > 1){
                        numUD_LatMin.Value = Convert.ToInt32(minutes[0]);
                        
                        var seconds = minutes[1].Split('\"');
                        if (seconds.Length == 1 && minutes.Length > 2)
                            numUD_LatSec.Value = Convert.ToInt32(seconds[0]);
                    }
                    comboBoxLatHem.Text = minutes.Last();
                }

                var splitLong = CurrentElement.Longitude.Split('°');
                //Parse the long from string to DMS and fill the numeric up downs
                if (splitLong.Length > 1){
                    numUD_LongDeg.Value = Convert.ToInt32(splitLong[0]);

                    var minutes = splitLong[1].Split('\'');
                    if (minutes.Length > 1){
                        numUD_LongMin.Value = Convert.ToInt32(minutes[0]);

                        var seconds = minutes[1].Split('\"');
                        if (seconds.Length == 1 && minutes.Length > 2)
                            numUD_LongSec.Value = Convert.ToInt32(seconds[0]);

                    }
                    comboBoxLongHem.Text = minutes.Last();
                }
            }else
                MessageBox.Show("Internal error on edit");

            this.ShowDialog();

        }

        private void buttonSave_Click(object sender, EventArgs e){
            var airport = new DbAirports(){
                AirportName = textBoxName.Text,
                IATA = textBoxIATA.Text,
                Region = textBoxRegion.Text,
                Elevation = Convert.ToInt32(numUD_Elevation.Value),
                Instance = Instance,
                GroundTime = TimeSpan.FromMinutes(Convert.ToInt32(numUD_GroundTime.Value)),
                MTOW_APE3 = Convert.ToInt32(numUD_MTOW_AP3.Value),
                MTOW_PC12 = Convert.ToInt32(numUD_MTOW_PC12.Value),
                LandingCost = Convert.ToInt32(numUD_LandCost.Value),
                RunwayLength = Convert.ToInt32(numUD_RunwayLen.Value),
                Latitude = numUD_LatDeg.Value+ "°"+numUD_LatMin.Value +"'"+numUD_LatSec.Value+"'' "+comboBoxLatHem.Text,
                Longitude = numUD_LongDeg.Value+ "°" +numUD_LongMin.Value+"'"+numUD_LongSec.Value+"'' "+comboBoxLongHem.Text,

            };


            if (IsAdd){
                AirportController.Instance.Add(airport);
            }else{
                AirportController.Instance.Edit(airport,IdItem);
            }
           
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e){
            this.Close();
        }
    }
}
