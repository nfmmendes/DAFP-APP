using System;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using SolverClientComunication;
using SolverClientComunication.Enums;
using SolverClientComunication.Models;


namespace Prototipo1
{
    public partial class MainForm : Form
    {
        public static CoopserviceContext Context = new CoopserviceContext();

        public MainForm()
        {
            InitializeComponent();
            var instances = Context.Instances;
            comboBoxInstancesInstanceTab.DataSource = instances.ToList().Select(shortInstanceDescription).ToList();
            comboBoxInstancesInstanceTab.SelectedIndex = 0;
            comboBoxInstanceParamTab.DataSource = instances.ToList().Select(shortInstanceDescription).ToList();

        }

        
        private string shortInstanceDescription(DbInstance x){
            return $"{x.Name} ({x.CreatedOn.ToString("dd/MM/yy hh:mm")}) {(x.Optimized?"Opt":"NotOpt")}";
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
            var createNewInstance = new CreateInstance(Context);
            createNewInstance.ShowDialog();
            comboBoxInstancesInstanceTab.DataSource = Context.Instances.ToList().Select(shortInstanceDescription).ToList();
            comboBoxInstancesInstanceTab.SelectedIndex = 0;
            comboBoxInstanceParamTab.DataSource = Context.Instances.ToList().Select(shortInstanceDescription).ToList();

        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == tabControl.TabPages["tabInstances"]){
                
                
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
            numUD_ChildWeight.Enabled = true;
            numUD_WomanWeight.Enabled = true;
            numUD_ManWeight.Enabled = true;
            numUD_TimeLimit.Enabled = true;
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
            numUD_ChildWeight.Enabled = false;
            numUD_ManWeight.Enabled = false;
            numUD_WomanWeight.Enabled = false;
            numUD_TimeLimit.Enabled = false;

        }

#region Drawing Instance's Tabs 
        private void tabControlOtherTables_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControlInstanceSolution.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControlInstanceSolution.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Microsoft Sans Serif", (float)10.8, FontStyle.Regular, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }


        private void tabControlInputTables_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControlInputTables.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControlInputTables.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.Black);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Microsoft Sans Serif", (float)10.8, FontStyle.Regular, GraphicsUnit.Pixel);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }
#endregion

        private void buttonSaveParams_Click(object sender, EventArgs e)
        {

            radioButtonDeliverAllNo.Enabled = radioButtonDeliverAllYes.Enabled = false;
            radioButtonComeBackDepotNo.Enabled = radioButtonComeBackDepotYes.Enabled = false;
            radioButtonPickAllNo.Enabled = radioButtonPickAllYes.Enabled = false;
            radioButtonTimeWindowNo.Enabled = radioButtonTimeWindowYes.Enabled = false;
            radioButtonStartDepotNo.Enabled = radioButtonStartDepotYes.Enabled = false;
            numUD_ChildWeight.Enabled = false;
            numUD_WomanWeight.Enabled = false;
            numUD_ManWeight.Enabled = false;
            numUD_TimeLimit.Enabled = false;

            buttonCancelSaveParams.Visible = false;
            buttonSaveParams.Visible = false;
            buttonEditParams.Visible = true;

        }

        private void comboBoxInstances_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxInstancesInstanceTab.SelectedIndex >= 0){
                buttonEditScenario.Visible = true;
                buttonDeleteScenario.Visible = true;
                buttonOptimizeInstanceTab.Enabled = true;
                panelInstanceDetails.Visible = true;
            }
        }
    }
}
