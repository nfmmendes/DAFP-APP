using System;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using Prototipo1.Controller;
using SolverClientComunication;
using SolverClientComunication.Enums;
using SolverClientComunication.Models;


namespace Prototipo1
{
    public partial class MainForm : Form
    {
        public CustomSqlContext Context = new CustomSqlContext();

        /// <summary>
        /// Class constructor
        /// The funcion initialize component is created automatically by the Visual Studio
        /// The initialization of Controller's context is just for avoid code repetition
        /// The initialization of combo boxes should be maintened here
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            var instances = Context.Instances;
            comboBoxInstancesInstanceTab.DataSource = instances.ToList().Select(shortInstanceDescription).ToList();
            if(comboBoxInstancesInstanceTab.Items.Count>0)
                comboBoxInstancesInstanceTab.SelectedIndex = 0;
            comboBoxInstanceParamTab.DataSource = instances.ToList().Select(shortInstanceDescription).ToList();

            InstancesController.Instance.setContext(Context);
            ParametersController.Instance.setContext(Context);
            ImportDataController.Instance.setContext(Context);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private string shortInstanceDescription(DbInstance x){
            return $"{x.Name} ({x.CreatedOn.ToString("dd/MM/yy hh:mm")}) {(x.Optimized?"Opt":"NotOpt")}";
        }

        /// <summary>
        /// Event handler to catch the change of parameter edit/visualization option
        /// In this case, the general settings is being choosen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonGenSettingY_CheckedChanged(object sender, EventArgs e){
            this.panelParamSelectInstance.Visible = !this.radioButtonGenSettingY.Checked;
            this.buttonOptimizeAll.Enabled = this.radioButtonGenSettingY.Checked;
            this.buttonOptimizeInstance.Visible = this.radioButtonGenSettingN.Checked;
        }

        /// <summary>
        /// Event handler to open advanced options window. 
        /// This window probably will be used just to internal tests. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void advancedOptionsToolStripMenuItem_Click(object sender, EventArgs e){
            var dialog = new FormAdvancedOptions();
            dialog.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void instanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var instanceLoader = new InstanceLoader(Context);
            instanceLoader.ShowDialog();
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cplexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeSelectedSolver(SolverEnum.CPLEX);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gurobiToolStripMenuItem_Click(object sender, EventArgs e){
            changeSelectedSolver(SolverEnum.GUROBI);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xpressToolStripMenuItem_Click(object sender, EventArgs e){
            changeSelectedSolver(SolverEnum.XPRESS);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coinORToolStripMenuItem_Click(object sender, EventArgs e){
            changeSelectedSolver(SolverEnum.COIN);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="solverEnum"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOptimizeInstance_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCreateInstance_Click(object sender, EventArgs e)
        {
            var createNewInstance = new CreateInstance(Context);
            createNewInstance.ShowDialog();
            comboBoxInstancesInstanceTab.DataSource = Context.Instances.ToList().Select(shortInstanceDescription).ToList();
            comboBoxInstancesInstanceTab.SelectedIndex = 0;
            comboBoxInstanceParamTab.DataSource = Context.Instances.ToList().Select(shortInstanceDescription).ToList();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancelSaveParams_Click(object sender, EventArgs e)
        {
            DisableParametersEdition();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveParams_Click(object sender, EventArgs e)
        {

            DisableParametersEdition();
            if (this.radioButtonGenSettingY.Checked){
                ParametersController.Instance.UpdateAllInstances(radioButtonTimeWindowYes.Checked,
                                                                radioButtonPickAllYes.Checked,radioButtonDeliverAllYes.Checked, 
                                                                radioButtonStartDepotYes.Checked,radioButtonComeBackDepotYes.Checked, 
                                                                Convert.ToInt32(numUD_ManWeight.Value),Convert.ToInt32(numUD_WomanWeight.Value), 
                                                                Convert.ToInt32(numUD_ChildWeight.Value),Convert.ToInt32(numUD_TimeLimit.Value));
            }
            else{
                var instanceName = getSelectedInstanceName(this.comboBoxInstanceParamTab.SelectedValue.ToString());
                var instance = Context.Instances.First(x => x.Name.Equals(instanceName));
                ParametersController.Instance.UpdateInstanceParameters(instance, radioButtonTimeWindowYes.Checked,
                                                                radioButtonPickAllYes.Checked, radioButtonDeliverAllYes.Checked,
                                                                radioButtonStartDepotYes.Checked, radioButtonComeBackDepotYes.Checked,
                                                                Convert.ToInt32(numUD_ManWeight.Value), Convert.ToInt32(numUD_WomanWeight.Value),
                                                                Convert.ToInt32(numUD_ChildWeight.Value), Convert.ToInt32(numUD_TimeLimit.Value));
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private void DisableParametersEdition(){
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxInstances_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxInstancesInstanceTab.SelectedIndex >= 0){
                buttonEditScenario.Visible = true;
                buttonDeleteScenario.Visible = true;
                buttonOptimizeInstanceTab.Enabled = true;
                panelInstanceDetails.Visible = true;
                var instanceName = getSelectedInstanceName(this.comboBoxInstancesInstanceTab.SelectedItem.ToString());
                var instance = Context.Instances.First(x => x.Name.Equals(instanceName));
                labelDescriptionInstance.Text = instance.Description;
                FillTables(instance);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        private void FillTables(DbInstance instance)
        {
            FillAiportsTable(instance);
            FillStretchTable(instance);
            FillAirplaneTables(instance);
            FillRequestTables(instance);
            FillCurrencyTable(instance);
            FillFuelTable(instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        private void FillFuelTable(DbInstance instance){
            this.dataGridViewFuel.Rows.Clear();
            var fuels = Context.FuelPrice.Where(x => x.Instance.Id == instance.Id);

            foreach (var item in fuels)
            {
                dataGridViewFuel.Rows.Add(item.Id, item.Airport.AiportName, item.Currency, item.Value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        private void FillCurrencyTable(DbInstance instance)
        {
            this.dataGridViewCurrency.Rows.Clear();
            var exchanges = Context.Exchange.Where(x => x.Instance.Id == instance.Id);

            foreach (var item in exchanges){
                this.dataGridViewCurrency.Rows.Add(item.Id, item.CurrencyName, item.CurrencySymbol, item.ValueInDolar);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        private void FillRequestTables(DbInstance instance)
        {
            this.dataGridViewRequest.Rows.Clear();
            var requests = Context.Requests.Where(x => x.Instance.Id == instance.Id).GroupBy(x=>x.PNR).ToDictionary(x=>x.Key, x=>x.ToList());

            foreach (var key in requests.Keys){
                var value = requests[key].First();
                dataGridViewRequest.Rows.Add(key, key, value.Origin.AiportName, value.Destination.AiportName, value.DepartureTimeWindowBegin,
                                                value.DepartureTimeWindowEnd, value.ArrivalTimeWindowBegin, value.ArrivalTimeWindowEnd);
           }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        private void FillAirplaneTables(DbInstance instance)
        {
            this.dataGridViewAirplane.Rows.Clear();
            var airplanes = Context.Airplanes.Where(x => x.Instance.Id == instance.Id);

            foreach (var item in airplanes)
                dataGridViewAirplane.Rows.Add(item.Id, item.Model,item.Prefix, item.Range, item.Weight, item.MaxWeight, item.CruiseSpeed, item.FuelConsumptionFirstHour,
                                              item.FuelConsumptionSecondHour, item.MaxFuel, item.Capacity, item.BaseAirport.AiportName);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        private void FillStretchTable(DbInstance instance)
        {
            this.dataGridViewStretches.Rows.Clear();
            var stretches = Context.Stretches.Where(x => x.Origin.Instance.Id == instance.Id);
            int cont = 0;
            foreach (var item in stretches){
                dataGridViewStretches.Rows.Add(item.Id, item.Origin.AiportName, item.Destination.AiportName, item.Distance);
                cont++;
                if (cont == 10001)
                    break; 
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        private void FillAiportsTable(DbInstance instance)
        {
            this.dataGridViewAirport.Rows.Clear();
            var airports = Context.Airports.Where(x => x.Instance.Id == instance.Id);
            foreach (var item in airports){
                dataGridViewAirport.Rows.Add(item.Id, item.AiportName, item.IATA, item.Latitude, item.Longitude, item.Elevation,
                                             item.RunwayLength, item.Region, item.MTOW_APE3, item.MTOW_PC12, item.LandingCost, item.GroundTime);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string getSelectedInstanceName(string selectedValue){
            var selectedLabel = selectedValue; 
            var instanceName = selectedLabel.Split('(')[0];
            return instanceName.Substring(0, instanceName.Length - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteScenario_Click(object sender, EventArgs e)
        {
            var instanceName = getSelectedInstanceName(this.comboBoxInstancesInstanceTab.SelectedValue.ToString());

            var result = MessageBox.Show($"Do you really want delete the instance {instanceName}?","Warning", MessageBoxButtons.YesNo);


            if (result == DialogResult.Yes)
                InstancesController.Instance.FindAndDeleteByName(instanceName);
            

            this.comboBoxInstancesInstanceTab.DataSource = Context.Instances.ToList().Select(shortInstanceDescription).ToList();
            this.comboBoxInstanceParamTab.DataSource = Context.Instances.ToList().Select(shortInstanceDescription).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditScenario_Click(object sender, EventArgs e){
            var instanceName = getSelectedInstanceName(this.comboBoxInstancesInstanceTab.SelectedValue.ToString());
            var scenarioId = this.Context.Instances.First(x => x.Name.Equals(instanceName)).Id;
            
            var editController = new EditInstance(Context,scenarioId);
            editController.ShowDialog();
            this.comboBoxInstancesInstanceTab.DataSource = Context.Instances.ToList().Select(shortInstanceDescription).ToList();
            this.comboBoxInstanceParamTab.DataSource = Context.Instances.ToList().Select(shortInstanceDescription).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idAirplane"></param>
        private void FillSeatTypeList(long idAirplane){ 
            this.dataGridViewSeatTypes.Rows.Clear();

            var seatTypes = Context.SeatList.Where(x => x.Airplane.Id == idAirplane);
            foreach (var item in seatTypes){
                dataGridViewSeatTypes.Rows.Add(item.Id, item.seatClass, item.numberOfSeats, item.luggageWeightLimit);
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewAirplane_RowEnter(object sender, DataGridViewCellEventArgs e){
            FillSeatTypeList(Convert.ToInt64(dataGridViewAirport.Rows[e.RowIndex].Cells[0].Value));
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
            var passengers = Context.Requests.Where(x => x.PNR.Equals(PNR));

            foreach (var item in passengers){
                this.dataGridViewPassenger.Rows.Add(item.Id, item.Name, item.Sex, item.IsChildren, item.Class);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void duplicateInstanceToolStripMenuItem_Click(object sender, EventArgs e){
            var duplicateWindow = new DuplicateInstance(Context);
            duplicateWindow.ShowDialog();
        }
    }
}
