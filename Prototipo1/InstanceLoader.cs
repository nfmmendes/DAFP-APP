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

namespace Prototipo1
{
    public partial class InstanceLoader : Form
    {

        private bool alreadyDoneCall;
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
                    chooseAirplaneFileLabel.Text = fileDialogue.FileName;
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
                    chooseAirplaneFileLabel.Text = fileDialogue.FileName;
                    buttonLoadFiles.Enabled = true;
                }
            }
        }

        private void treeViewTablesLoaded_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (alreadyDoneCall)
                return;
            

            alreadyDoneCall = true;

            var tree = treeViewTablesLoaded;
            bool airplaneStatus = tree.Nodes["AirplaneNodes"].Checked;
            bool airplaneAirplaneStatus = tree.Nodes["AirplaneNodes"].Nodes["AirplaneNode"].Checked;
            bool airplaneSeatStatus = tree.Nodes["AirplaneNodes"].Nodes["SeatListNode"].Checked;

            
            if (airplaneStatus && !airplaneAirplaneStatus && !airplaneSeatStatus ){
                this.buttonChooseAirplaneFile.Enabled = true;
                tree.Nodes["AirplaneNodes"].Nodes["AirplaneNode"].Checked = true;
                tree.Nodes["AirplaneNodes"].Nodes["SeatListNode"].Checked = true;

            }else if((airplaneAirplaneStatus || airplaneSeatStatus) && !airplaneStatus){
                tree.Nodes["AirplaneNodes"].Checked = true;
                this.buttonChooseAirplaneFile.Enabled = true;
            }else if(!airplaneStatus) {
                this.buttonChooseAirplaneFile.Enabled = false;
                tree.Nodes["AirplaneNodes"].Nodes["AirplaneNode"].Checked = false;
                tree.Nodes["AirplaneNodes"].Nodes["SeatListNode"].Checked = false;
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
                    chooseAirplaneFileLabel.Text = fileDialogue.FileName;
                    buttonLoadFiles.Enabled = true;
                }
            }
        }
    }
}
