using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Prototipo1.Components;
using Prototipo1.Controller;
using Solver;
using SolverClientComunication;
using SolverClientComunication.Enums;
using SolverClientComunication.Models;


namespace Prototipo1
{
    public partial class MainForm : Form
    {
        
        private int CountStretchePage;
        private readonly int StretchePageSize=5000; 

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

            //Initialize the context of all controllers 
            //WARNING: Everytime that a new controller is created it's necessary to initialize their context here to allow
            // its rigth use
            InstancesController.Instance.setContext(Context);
            ParametersController.Instance.setContext(Context);
            ImportDataController.Instance.setContext(Context);
            HeuristicSolutionController.Instance.setContext(Context);
            AirplaneController.Instance.setContext(Context);
            

        }

        /// <summary>
        /// Parser of the instance metadata to a string 
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
        /// Open a window where is possible to load the instance data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void instanceToolStripMenuItem_Click(object sender, EventArgs e) {
            var instanceLoader = new InstanceLoader(Context);
            instanceLoader.ShowDialog();
            var instances = Context.Instances;

            //After the load window be closed we need to update the instance list 
            comboBoxInstancesInstanceTab.DataSource = instances.ToList().Select(shortInstanceDescription).ToList();
            comboBoxInstanceParamTab.DataSource = instances.ToList().Select(shortInstanceDescription).ToList();
            if (comboBoxInstancesInstanceTab.Items.Count > 0)
                comboBoxInstancesInstanceTab.SelectedIndex = 0;
            

        }

        /// <summary>
        /// Changes the MILP solver to CPLEX
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cplexToolStripMenuItem_Click(object sender, EventArgs e){
            changeSelectedSolver(SolverEnum.CPLEX);
        }

        /// <summary>
        /// Changes the MILP solver to GUROBI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gurobiToolStripMenuItem_Click(object sender, EventArgs e){
            changeSelectedSolver(SolverEnum.GUROBI);
        }

        /// <summary>
        /// Changes the MILP solver to XPress
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
        /// Controls how the menu will display the current MILP solver in the menu strip
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
        /// Function that calls the solver to solve the optimization problem
        /// TODO: Improve it to call the right heuristic/solver
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonOptimizeInstance_Click(object sender, EventArgs e)
        {
            var instanceName = getSelectedInstanceName(this.comboBoxInstancesInstanceTab.SelectedItem.ToString());
            var instance = Context.Instances.FirstOrDefault(x => x.Name.Equals(instanceName));
            if (instance != null){
                //Create the input to the solver
                var input =  SolverInput.BuildSolverInput(Context,instance);

                //Instantiates and call the heuristic
                var heuristic = new Solver.Heuristics.MainHeuristic(input, true);
                heuristic.Execute();
                //Saving the solution
                HeuristicSolutionController.Instance.SaveResults(instance, heuristic.BestSolution);

                //Warning the end of the optimization
                MessageBox.Show("Optimization finished");

                //Set the metadata of the instance
                instance.Optimized = true;
                instance.LastOptimization = DateTime.Now;

                //Save the modifications on the database
                Context.Instances.AddOrUpdate(instance);
                Context.SaveChanges();
                BuildSolutionPanel(); 

            }else{
                MessageBox.Show("A instance should be selected");
            }
        }
        
        /// <summary>
        /// Starts the process of showing the optimization results on the interface
        /// </summary>
        private void BuildSolutionPanel(){
            this.comboBoxAirplaneSolution.DataSource = Context.FlightsReports.Select(x=>x.Airplanes.Prefix).Distinct().ToList();
            this.tabControlInputSolution.SelectedIndex = 1; 
            

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
                this.comboBoxAirplaneSolution.DataSource = Context.FlightsReports.Where(x => x.Instance.Id == instance.Id)
                    .Select(x => x.Airplanes.Prefix).Distinct().ToList();
                if(this.comboBoxAirplaneSolution.Items.Count > 0 )
                    this.comboBoxAirplaneSolution.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        private void FillTables(DbInstance instance)
        {
            AirportView.setInstance(instance);
            StretchView.setInstance(instance);
            AirplaneView.setInstance(instance);
            RequestView.setInstance(instance);
            FuelPriceView.setInstance(instance);
            CurrencyView.setInstance(instance);
            RequestSolutionView.setInstance(instance);
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
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void duplicateInstanceToolStripMenuItem_Click(object sender, EventArgs e){
            var duplicateWindow = new DuplicateInstance(Context);
            duplicateWindow.ShowDialog();
        }
        






        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddFuel_Click(object sender, EventArgs e){
            var instanceName = getSelectedInstanceName(this.comboBoxInstancesInstanceTab.SelectedItem.ToString());
            var instance = Context.Instances.FirstOrDefault(x => x.Name.Equals(instanceName));

            if (instance != null){
                var addFuel = new AddEditFuel(Context);
                addFuel.OpenToAdd(instance);
               // FillFuelTable(instance);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddRequest_Click(object sender, EventArgs e){
            var instanceName = getSelectedInstanceName(this.comboBoxInstancesInstanceTab.SelectedItem.ToString());
            var instance = Context.Instances.FirstOrDefault(x => x.Name.Equals(instanceName));

            if (instance != null){
                var addRequest = new AddEditRequest();
                addRequest.OpenToAdd(instance);
            }
        }


        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit_Click(object sender, EventArgs e){

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxAirplaneSolution_SelectedIndexChanged(object sender, EventArgs e){
            var instanceName = getSelectedInstanceName(this.comboBoxInstancesInstanceTab.SelectedItem.ToString());
            var instance = Context.Instances.FirstOrDefault(x => x.Name.Equals(instanceName));
            var prefix = "";

            if(this.comboBoxAirplaneSolution.Items.Count > 0)
                prefix = this.comboBoxAirplaneSolution.SelectedItem.ToString();



            if (instance != null){
                var airplane = Context.Airplanes.FirstOrDefault(x => x.Instance.Id == instance.Id && x.Prefix.Equals(prefix));
                if (airplane != null){
                    var test = Context.FlightsReports.ToList();
                    var trips = Context.FlightsReports.Where(x=>x.Instance.Id == instance.Id && x.Airplanes.Prefix.Equals(airplane.Prefix)).ToList();

                    dataGridViewRoutePassagers.Rows.Clear();
                    dataGridViewRoute.Rows.Clear();
                    foreach (var item in trips){

                        var weightOnDeparture = item.Airplanes.Weight + GetWeightOfPassengers(item) + item.FuelOnDeparture* 0.453592;
                        var weightOnArrival = item.Airplanes.Weight + GetWeightOfPassengers(item) + item.FuelOnArrival * 0.453592;

                        dataGridViewRoute.Rows.Add(item.Id, "X", item.Origin.AiportName,
                                                                item.FuelOnDeparture,weightOnDeparture ,  
                                                                item.DepartureTime, 
                                                                item.Destination.AiportName, 
                                                                item.FuelOnArrival, weightOnArrival, 
                                                                item.ArrivalTime);    
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        private double GetWeightOfPassengers(DbFlightsReport flight){
            var itemList = Context.PassagersOnFlight.Where(x => x.Flight.Id == flight.Id);
            var seatList = Context.SeatList.Where(x => x.Airplanes.Id == flight.Airplanes.Id).ToList();


            var sum = 0.0;
            foreach (var item in itemList){
                var seatClass = seatList.FirstOrDefault(x=>x.seatClass.Equals(item.Passenger.Class));
                if (seatClass != null)
                    sum += seatClass.luggageWeightLimit;

                //TODO: Correct to get the values from database. THIS IS WRONG!!!!
                if (item.Passenger.Sex.Equals("M"))
                    sum += item.Passenger.IsChildren? Convert.ToDouble(numUD_ChildWeight.Value) : Convert.ToDouble(numUD_ManWeight.Value);
                else
                    sum += item.Passenger.IsChildren ? Convert.ToDouble(numUD_ChildWeight.Value) : Convert.ToDouble(numUD_WomanWeight.Value);
            }
            return sum;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewRoute_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewRoute.SelectedRows.Count > 0){
                var indexRow = dataGridViewRoute.SelectedRows[0].Index;
                var index = Convert.ToInt64(dataGridViewRoute.Rows[indexRow].Cells[0].Value.ToString());

                var reports = Context.PassagersOnFlight.Where(x => x.Flight.Id.Equals(index)).ToList();

                dataGridViewRoutePassagers.Rows.Clear();
                foreach (var item in reports)
                    dataGridViewRoutePassagers.Rows.Add(item.Passenger.Name, item.Passenger.PNR, item.Passenger.Sex, item.Passenger.Class);
                
            }

        }


        #region Stretch table pagination
        #endregion


    }
}
