using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prototipo1.Controller;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1
{
    public partial class InstanceLoader : Form
    {

        private bool alreadyDoneCall;
        private bool previousStateAirplanes;
        private bool previousStateNetwork;
        private bool previousStateFlightRequest; 

        private CustomSqlContext Context { get; set;  }
        
        /// <summary>
        /// 
        /// </summary>
        public InstanceLoader(CustomSqlContext context)
        {
            InitializeComponent();
            Context = context;
            var instances = Context.Instances;
            comboBoxInstances.DataSource = instances.ToList().Select(x=>x.Name).ToList();

            previousStateAirplanes = previousStateNetwork  = previousStateFlightRequest = false;
         }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonNew_CheckedChanged(object sender, EventArgs e)
        {
            textBoxInstance.Visible = radioButtonNew.Checked;
            if (!radioButtonNew.Checked == true || !string.IsNullOrEmpty(textBoxInstance.Text))
                treeViewTablesLoaded.Enabled = true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChooseAirplaneFile_Click(object sender, EventArgs e)
        {
            var fileDialogue = new OpenFileDialog();
            fileDialogue.Filter = "Microsoft Excel files (*.xlsx)|*.xlsx";
            fileDialogue.ShowDialog();

            if (!string.IsNullOrEmpty(fileDialogue.FileName)){
                var splitedFileName = fileDialogue.FileName.Split('\\');
                if (splitedFileName.Last() != "Airplanes.xlsx")
                    MessageBox.Show("Your input file must be called Airplanes.xlsx");
                else{
                    choosenAirplaneFileLabel.Text = fileDialogue.FileName;
                    buttonLoadFiles.Enabled = true; 
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxInstance_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textBoxInstance.Text))
                treeViewTablesLoaded.Enabled = true; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLoadFiles_Click(object sender, EventArgs e)
        {
            DbInstance instance=null;

            var loadAirplane = treeViewTablesLoaded.Nodes["AirplaneNodes"].Nodes["AirplaneNode"].Checked;
            var loadSeat = treeViewTablesLoaded.Nodes["AirplaneNodes"].Nodes["SeatListNode"].Checked;
            var loadAirports = treeViewTablesLoaded.Nodes["NetworkNode"].Nodes["AirportsNode"].Checked;
            var loadStretches = treeViewTablesLoaded.Nodes["NetworkNode"].Nodes["StretchNode"].Checked;

            if (this.radioButtonNew.Checked == true)
            {
                if (!string.IsNullOrEmpty(this.textBoxInstance.Text)){
                    InstancesController.Instance.AddInstance(this.textBoxInstance.Text);
                }else
                    MessageBox.Show("You should type the instance name");

                 instance = Context.Instances.FirstOrDefault(x => x.Name.Equals(this.textBoxInstance.Text));
               
            }else{
                 instance = Context.Instances.FirstOrDefault(x => x.Name.Equals(this.comboBoxInstances.SelectedValue.ToString()));
            }

            this.Enabled = false; 
            if (instance != null){
                if (!string.IsNullOrEmpty(this.networkFileChoosenLabel.Text))
                    ImportDataController.Instance.importNetworkData(this.networkFileChoosenLabel.Text, instance,loadAirports, loadStretches);
                if (!string.IsNullOrEmpty(choosenAirplaneFileLabel.Text))
                    ImportDataController.Instance.importAirplanesData(this.choosenAirplaneFileLabel.Text, instance,loadAirplane, loadSeat);
                if (!string.IsNullOrEmpty(choosenRequestFileLabel.Text))
                    ImportDataController.Instance.importRequestData(this.choosenRequestFileLabel.Text, instance);
            }
            this.Enabled = true; 
            // ImportDataController.Instance.importRequestData(this.choosenRequestFileLabel.Text, new DbInstance());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewTablesLoaded_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChooseFileRequests_Click(object sender, EventArgs e)
        {
            var fileDialogue = new OpenFileDialog();
            fileDialogue.Filter = "Microsoft Excel files (*.xlsx)|*.xlsx";
            fileDialogue.ShowDialog();

            if (fileDialogue.FileName != null)
            {
                var splitedFileName = fileDialogue.FileName.Split('\\');
                if (splitedFileName.Last() != "Requests.xlsx")
                    MessageBox.Show("Your input file must be called Requests.xlsx");
                else
                {
                    choosenRequestFileLabel.Text = fileDialogue.FileName;
                    buttonLoadFiles.Enabled = true;
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeViewTablesLoaded_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (alreadyDoneCall)
                return;
            

            alreadyDoneCall = true;

            var tree = treeViewTablesLoaded;
            bool airplaneStatus = tree.Nodes["AirplaneNodes"].Checked;
            bool networkStatus = tree.Nodes["NetworkNode"].Checked;

            if (!previousStateAirplanes && airplaneStatus){
                this.buttonChooseAirplaneFile.Enabled = true;
                previousStateAirplanes = true; 
                tree.Nodes["AirplaneNodes"].Nodes["AirplaneNode"].Checked = true;
                tree.Nodes["AirplaneNodes"].Nodes["SeatListNode"].Checked = true;
            }else if (previousStateAirplanes && !airplaneStatus){
                this.buttonChooseAirplaneFile.Enabled = false;
                previousStateAirplanes = false;
                tree.Nodes["AirplaneNodes"].Nodes["AirplaneNode"].Checked = false;
                tree.Nodes["AirplaneNodes"].Nodes["SeatListNode"].Checked = false;
            }else if(tree.Nodes["AirplaneNodes"].Nodes["SeatListNode"].Checked ==tree.Nodes["AirplaneNodes"].Nodes["AirplaneNode"].Checked){
                if (tree.Nodes["AirplaneNodes"].Nodes["AirplaneNode"].Checked == false){
                    this.buttonChooseAirplaneFile.Enabled = false;
                    previousStateAirplanes = false;
                    tree.Nodes["AirplaneNodes"].Checked = false;
                    tree.Nodes["AirplaneNodes"].Nodes["AirplaneNode"].Checked = false;
                    tree.Nodes["AirplaneNodes"].Nodes["SeatListNode"].Checked = false;
                }              
            }else if (tree.Nodes["AirplaneNodes"].Nodes["SeatListNode"].Checked !=tree.Nodes["AirplaneNodes"].Nodes["AirplaneNode"].Checked){
                this.buttonChooseAirplaneFile.Enabled = true;
                previousStateAirplanes = true;
                tree.Nodes["AirplaneNodes"].Checked = true;
            }

            if (!previousStateNetwork && networkStatus){
                this.buttonChooseFileNetwork.Enabled = true;
                previousStateNetwork = true;
                tree.Nodes["NetworkNode"].Nodes["AirportsNode"].Checked = true;
                tree.Nodes["NetworkNode"].Nodes["StretchNode"].Checked = true;
            }else if (previousStateNetwork && !networkStatus){
                this.buttonChooseFileNetwork.Enabled = false;
                previousStateNetwork = false;
                tree.Nodes["NetworkNode"].Nodes["AirportsNode"].Checked = false;
                tree.Nodes["NetworkNode"].Nodes["StretchNode"].Checked = false;
            }else if (tree.Nodes["NetworkNode"].Nodes["AirportsNode"].Checked == tree.Nodes["NetworkNode"].Nodes["StretchNode"].Checked){
                if (tree.Nodes["NetworkNode"].Nodes["AirportsNode"].Checked == false){
                    tree.Nodes["NetworkNode"].Checked = false;
                    this.buttonChooseFileNetwork.Enabled = false;
                    previousStateNetwork = false;
                    tree.Nodes["NetworkNode"].Nodes["AirportsNode"].Checked = false;
                    tree.Nodes["NetworkNode"].Nodes["StretchNode"].Checked = false;
                }
            }else if (tree.Nodes["NetworkNode"].Nodes["AirportsNode"].Checked !=tree.Nodes["NetworkNode"].Nodes["StretchNode"].Checked){
                this.buttonChooseFileNetwork.Enabled = true;
                previousStateNetwork = true;
                tree.Nodes["NetworkNode"].Checked = true; 
            }


            if (tree.Nodes["RequestsNodes"].Checked){
                this.buttonChooseRequestFile.Enabled = true;
                tree.Nodes["RequestsNodes"].Nodes["FlightRequestNode"].Checked = true;
            }else if (tree.Nodes["RequestsNodes"].Nodes["FlightRequestNode"].Checked){
                tree.Nodes["RequestsNodes"].Checked = true;
                this.buttonChooseRequestFile.Enabled = true;
            }else
                this.buttonChooseRequestFile.Enabled = false;

            alreadyDoneCall = false; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonChooseFileNetwork_Click(object sender, EventArgs e)
        {
            var fileDialogue = new OpenFileDialog();
            fileDialogue.Filter = "Microsoft Excel files (*.xlsx)|*.xlsx";
            fileDialogue.ShowDialog();

            if (fileDialogue.FileName != null)
            {
                var splitedFileName = fileDialogue.FileName.Split('\\');
                if (splitedFileName.Last() != "Network.xlsx")
                    MessageBox.Show("Your input file must be called Network.xlsx");
                else
                {
                    networkFileChoosenLabel.Text = fileDialogue.FileName;
                    buttonLoadFiles.Enabled = true;
                }
            }
        }
    }
}
