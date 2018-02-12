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
        
        /// <summary>
        /// 
        /// </summary>
        public InstanceLoader()
        {
            InitializeComponent();
            var instances = MainForm.Context.Instances;
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
            if (alreadyDoneCall){
                alreadyDoneCall = false;
                return;
            }

            alreadyDoneCall = true; 

            var tree = treeViewTablesLoaded;
            if (tree.Nodes["AirplaneNodes"].Checked ){
                this.buttonChooseAirplaneFile.Enabled = true;
                tree.Nodes["AirplaneNodes"].Nodes["AirplaneNode"].Checked = true;
                alreadyDoneCall = true; 
                tree.Nodes["AirplaneNodes"].Nodes["SeatListNode"].Checked = true;
                alreadyDoneCall = true;

            }else if (tree.Nodes["AirplaneNodes"].Nodes["AirplaneNode"].Checked || tree.Nodes["AirplaneNodes"].Nodes["SeatListNode"].Checked){
                tree.Nodes["AirplaneNodes"].Checked = true;
                alreadyDoneCall = true;
                this.buttonChooseAirplaneFile.Enabled = true;
            }else {
                this.buttonChooseAirplaneFile.Enabled = true;
                tree.Nodes["AirplaneNodes"].Nodes["AirplaneNode"].Checked = true;
                alreadyDoneCall = true;
                tree.Nodes["AirplaneNodes"].Nodes["SeatListNode"].Checked = true;
                alreadyDoneCall = true; 
            }

            if (tree.Nodes["RequestsNodes"].Checked){
                this.buttonChooseRequestFile.Enabled = true;
                tree.Nodes["RequestsNodes"].Nodes["FlightRequestNode"].Checked = true;
                

            }else if (tree.Nodes["RequestsNodes"].Nodes["FlightRequestNode"].Checked){
                tree.Nodes["RequestsNodes"].Checked = true;
                this.buttonChooseRequestFile.Enabled = true;
            }else
                this.buttonChooseRequestFile.Enabled = false;
        }
    }
}
