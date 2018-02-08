using System;
using System.Linq;
using System.Windows.Forms;
using SolverClientComunication;


namespace Prototipo1
{
    public partial class MainForm : Form
    {
        SQLCommunication context = new SQLCommunication();

        public MainForm()
        {
            InitializeComponent();
            comboBoxInstances.DataSource = context.Instances.Select(x => x.Name).ToList();
            comboBoxMInstance.DataSource = context.Instances.Select(x => x.Name).ToList();

        }

        private void radioButtonGenSettingY_CheckedChanged(object sender, EventArgs e){
            this.panelParamSelectInstance.Visible = !this.radioButtonGenSettingY.Checked;
            this.buttonOptimizeAll.Enabled = this.radioButtonGenSettingY.Checked;
            this.buttonOptimizeInstance.Visible = this.radioButtonGenSettingN.Checked;
        }

        private void advancedOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dialog = new FormAdvancedOptions();
            dialog.ShowDialog();
        }

        private void instanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var instanceLoader = new InstanceLoader();
            instanceLoader.ShowDialog();
            
        }

        private void cplexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeSelectedSolver(SolverEnum.CPLEX);
          
        }

        private void gurobiToolStripMenuItem_Click(object sender, EventArgs e){
            changeSelectedSolver(SolverEnum.GUROBI);
        }

        private void xpressToolStripMenuItem_Click(object sender, EventArgs e){
            changeSelectedSolver(SolverEnum.XPRESS);
        }

        private void coinORToolStripMenuItem_Click(object sender, EventArgs e){
            changeSelectedSolver(SolverEnum.COIN);
        }

        private void changeSelectedSolver(SolverEnum solverEnum)
        {
            this.cplexToolStripMenuItem.Checked = false;
            this.gurobiToolStripMenuItem.Checked = false;
            this.coinORToolStripMenuItem.Checked = false;
            this.xpressToolStripMenuItem.Checked = false;

            if (solverEnum.Equals(SolverEnum.CPLEX))
                cplexToolStripMenuItem.Checked = true;
            else if (solverEnum.Equals(SolverEnum.GUROBI))
                gurobiToolStripMenuItem.Checked = true;
            else if (solverEnum.Equals(SolverEnum.XPRESS))
                xpressToolStripMenuItem.Checked = true;
            else if (solverEnum.Equals(SolverEnum.COIN))
                coinORToolStripMenuItem.Checked = true; 

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCreateInstance_Click(object sender, EventArgs e)
        {
            var createNewInstance = new CreateInstance(context);
            createNewInstance.ShowDialog();
            comboBoxInstances.Refresh();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabControl.TabPages["tabInstances"]){
                //comboBoxInstances.DataSource = context.Instances.Select(x => new{x.Id, Label =  $"{x.Name} ({x.CreatedOn})"}).ToList();
                
            }
        }

        private void buttonEditParams_Click(object sender, EventArgs e)
        {
            buttonEditParams.Visible = false;
            buttonSaveParams.Visible = true;
            buttonCancelSaveParams.Visible = true;
            radioButtonDeliverAllNo.Enabled = radioButtonDeliverAllYes.Enabled = true;
            radioButtonComeBackDepotNo.Enabled = radioButtonComeBackDepotYes.Enabled = true;
            radioButtonPickAllNo.Enabled = radioButtonPickAllYes.Enabled = true;
            radioButtonTimeWindowNo.Enabled = radioButtonTimeWindowYes.Enabled = true;
            radioButtonStartDepotNo.Enabled = radioButtonStartDepotYes.Enabled = true;
        }

        private void buttonCancelSaveParams_Click(object sender, EventArgs e)
        {
            buttonCancelSaveParams.Visible = false;
            buttonSaveParams.Visible = false;
            buttonEditParams.Visible = true;
            radioButtonDeliverAllNo.Enabled = radioButtonDeliverAllYes.Enabled = false;
            radioButtonComeBackDepotNo.Enabled = radioButtonComeBackDepotYes.Enabled = false;
            radioButtonPickAllNo.Enabled = radioButtonPickAllYes.Enabled = false;
            radioButtonTimeWindowNo.Enabled = radioButtonTimeWindowYes.Enabled = false;
            radioButtonStartDepotNo.Enabled = radioButtonStartDepotYes.Enabled = false;
        }

        private void buttonSaveParams_Click(object sender, EventArgs e)
        {

            radioButtonDeliverAllNo.Enabled = radioButtonDeliverAllYes.Enabled = false;
            radioButtonComeBackDepotNo.Enabled = radioButtonComeBackDepotYes.Enabled = false;
            radioButtonPickAllNo.Enabled = radioButtonPickAllYes.Enabled = false;
            radioButtonTimeWindowNo.Enabled = radioButtonTimeWindowYes.Enabled = false;
            radioButtonStartDepotNo.Enabled = radioButtonStartDepotYes.Enabled = false;

            buttonCancelSaveParams.Visible = false;
            buttonSaveParams.Visible = false;
            buttonEditParams.Visible = true;

        }
    }
}
