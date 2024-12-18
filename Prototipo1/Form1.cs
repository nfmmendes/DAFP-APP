﻿using System;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Prototipo1.Controller;
using Solver;
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

            var instances = Context.Instances.ToList();
            //Initialize the context of all controllers 
            //WARNING: Everytime that a new controller is created it's necessary to initialize their context here to allow
            // its rigth use
            InstancesController.Instance.setContext(Context);
            ParametersController.Instance.setContext(Context);
            ImportDataController.Instance.setContext(Context);
            HeuristicSolutionController.Instance.setContext(Context);
            AirplaneController.Instance.setContext(Context);
            AirportController.Instance.setContext(Context);
            ExchangeRatesController.Instance.setContext(Context);
            FuelController.Instance.setContext(Context);
            PreCheckOptimizationController.Instance.setContext(Context);

            //Fill the list of instances on the main combo box
            comboBoxInstancesInstanceTab.DataSource = instances.ToList().Select(shortInstanceDescription).ToList();
            if(comboBoxInstancesInstanceTab.Items.Count>0)
                comboBoxInstancesInstanceTab.SelectedIndex = 0;
            comboBoxInstanceParamTab.DataSource = instances.ToList().Select(shortInstanceDescription).ToList();


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
        /// Changes the MILP solver to COIN-OR
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
            //Set all checks to false...
            this.cplexToolStripMenuItem.Checked = false;
            this.gurobiToolStripMenuItem.Checked = false;
            this.coinORToolStripMenuItem.Checked = false;
            this.xpressToolStripMenuItem.Checked = false;

            ///..Because just one option must be true
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

                PreCheckOptimizationController.Instance.setContext(Context);
                PreCheckOptimizationController.Instance.ExecuteCheck(input);

                if (Context.OptimizationAlerts.Any(x => x.Instance.Id == instance.Id)){
                    MessageBox.Show("There are problems related with your instance.");

                    var optimizationWarnings = new PreCheckOptimizationView(instance);
                    optimizationWarnings.ShowDialog();
                    if (!optimizationWarnings.ContinueOptimization)
                        return; 
                }
                

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
                labelIsOptimized.Text = "Yes";
                labelLastOptimization.Text = instance.LastOptimization.Value.ToString("G");

                //Save the modifications on the database
                Context.Instances.Update(instance);
                Context.SaveChanges();
                BuildSolutionPanel(instance); 

            }else{
                MessageBox.Show("A instance should be selected");
            }
        }

        /// <summary>
        /// Starts the process of showing the optimization results on the interface
        /// </summary>
        private void BuildSolutionPanel(DbInstance instance){
           // this.comboBoxAirplaneSolution.DataSource = Context.FlightsReports.Select(x => x.Airplanes.Prefix).Distinct().ToList();
            this.tabControlInputSolution.SelectedIndex = 1;
            this.AirplaneUseSolutionView.setInstance(instance);
            this.RefuelSolutionView.setInstance(instance);
            this.SolutionSummaryView.setInstance(instance);
            this.RequestSolutionView.setInstance(instance);
        }


        /// <summary>
        /// Function to catch the event of clicking in the CreateInstance button
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
        /// Function to catch de event of clicking in the EditParam button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditParams_Click(object sender, EventArgs e)
        {
            ///It changes the state of objects on the view to enable using the elements that allow to edit the data
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
        /// Function that will deal with the procedure of saving the parameters of the model after a edition
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveParams_Click(object sender, EventArgs e)
        {

            DisableParametersEdition();
            //Change/Save the parameters of all instances

            var sunrise = numUD_SunriseH.Value + ":" + numUD_SunriseM.Value;
            var sunset = numUD_Sunset_H.Value + ":" + numUD_Sunset_M.Value;

            if (this.radioButtonGenSettingY.Checked){
                ParametersController.Instance.UpdateAllInstances(radioButtonTimeWindowYes.Checked,
                                                                radioButtonPickAllYes.Checked,radioButtonDeliverAllYes.Checked, 
                                                                radioButtonStartDepotYes.Checked,radioButtonComeBackDepotYes.Checked, 
                                                                Convert.ToInt32(numUD_ManWeight.Value),Convert.ToInt32(numUD_WomanWeight.Value), 
                                                                Convert.ToInt32(numUD_ChildWeight.Value),Convert.ToInt32(numUD_TimeLimit.Value),sunrise,sunset);
            }
            //Change/Save the parameters of just one instance 
            else{
                var instanceName = getSelectedInstanceName(this.comboBoxInstanceParamTab.SelectedValue.ToString());
                var instance = Context.Instances.First(x => x.Name.Equals(instanceName));
                ParametersController.Instance.UpdateInstanceParameters(instance, radioButtonTimeWindowYes.Checked,
                                                                radioButtonPickAllYes.Checked, radioButtonDeliverAllYes.Checked,
                                                                radioButtonStartDepotYes.Checked, radioButtonComeBackDepotYes.Checked,
                                                                Convert.ToInt32(numUD_ManWeight.Value), Convert.ToInt32(numUD_WomanWeight.Value),
                                                                Convert.ToInt32(numUD_ChildWeight.Value), Convert.ToInt32(numUD_TimeLimit.Value),sunrise,sunset);
            }

        }

        /// <summary>
        /// Disable/Hide all the controls that allow the parameters edition
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
        /// Alter the instance currently selected and refresh the data grid views 
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
                labelIsOptimized.Text = instance.Optimized ? "Yes" : "No";
                labelLastOptimization.Text = instance.Optimized ? instance.LastOptimization.Value.ToString("G"): "";
                
                FillTables(instance);
            //  XX
                
            }
        }

        /// <summary>
        /// Reload all the data tables to show the data of the instance 
        /// </summary>
        /// <param name="instance">The instance that will be showed on the view</param>
        private void FillTables(DbInstance instance){
            AirportView.setInstance(instance);
            StretchView.setInstance(instance);
            AirplaneView.setInstance(instance);
            RequestView.setInstance(instance);
            FuelPriceView.setInstance(instance);
            CurrencyView.setInstance(instance);
            RequestSolutionView.setInstance(instance);
            MapRoutView.setInstance(instance);
            AirplaneUseSolutionView.setInstance(instance);
            SolutionSummaryView.setInstance(instance);
        }


        
        
        /// <summary>
        /// Return the name of a instance given the value selected in the main combo box
        /// </summary>
        /// <returns></returns>
        private string getSelectedInstanceName(string selectedValue){
            var selectedLabel = selectedValue; 
            var instanceName = selectedLabel.Split('(')[0];
            return instanceName.Substring(0, instanceName.Length - 1);
        }

        /// <summary>
        /// Catch and deal the event of clicking in the button delete scenario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteScenario_Click(object sender, EventArgs e)
        {

            var instanceName = getSelectedInstanceName(this.comboBoxInstancesInstanceTab.SelectedValue.ToString());
            var result = MessageBox.Show($"Do you really want delete the instance {instanceName}?","Warning", MessageBoxButtons.YesNo);

            this.comboBoxInstancesInstanceTab.Text = "";
            if (result == DialogResult.Yes)
                InstancesController.Instance.FindAndDeleteByName(instanceName);
            
            //Update the list of scenarios after delete the scenario
            this.comboBoxInstancesInstanceTab.DataSource = Context.Instances.ToList().Select(shortInstanceDescription).ToList();
            this.comboBoxInstanceParamTab.DataSource = Context.Instances.ToList().Select(shortInstanceDescription).ToList();

            var first = Context.Instances.FirstOrDefault();

            
            FillTables(first);
        }

        /// <summary>
        /// Catch and deal the event of editing a scenario
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
        /// Catch and deal the event of duplicating a instance 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void duplicateInstanceToolStripMenuItem_Click(object sender, EventArgs e){
            var duplicateWindow = new DuplicateInstance(Context);
            duplicateWindow.ShowDialog();
            var instances = Context.Instances;
            //Fill the list of instances on the main combo box
            comboBoxInstancesInstanceTab.DataSource = instances.ToList().Select(shortInstanceDescription).ToList();
            if (comboBoxInstancesInstanceTab.Items.Count > 0)
                comboBoxInstancesInstanceTab.SelectedIndex = 0;
            comboBoxInstanceParamTab.DataSource = instances.ToList().Select(shortInstanceDescription).ToList();
        }
        
        
        /// <summary>
        /// Shows the import data log 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void importDataLogToolStripMenuItem_Click(object sender, EventArgs e){
            if (Context.Instances.Any()){
                var importDataLog = new ImportDataLog(Context, null);
                importDataLog.ShowDialog();
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxInstanceParamTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            var instanceName = getSelectedInstanceName(this.comboBoxInstanceParamTab.SelectedValue.ToString());
            var instance = Context.Instances.FirstOrDefault(x => x.Name.Equals(instanceName));

            if (instance != null){
                var parameters = ParametersController.Instance.getParameters(instance);

                var pickupAll = parameters.FirstOrDefault(x => x.Code.Equals(ParametersEnum.PICK_ALL.DbCode));
                var deliverAll = parameters.FirstOrDefault(x => x.Code.Equals(ParametersEnum.DELIVER_ALL.DbCode));
                var useTimeWindows = parameters.FirstOrDefault(x => x.Code.Equals(ParametersEnum.USE_TIME_WINDOWS.DbCode));
                var startFromDepot = parameters.FirstOrDefault(x=>x.Code.Equals(ParametersEnum.START_FROM_DEPOT.DbCode));
                var comeBackToDepot = parameters.FirstOrDefault(x=>x.Code.Equals(ParametersEnum.COME_BACK_TO_DEPOT.DbCode));
                var menWeight = parameters.FirstOrDefault(x => x.Code.Equals(ParametersEnum.AVERAGE_MEN_WEIGHT.DbCode));
                var womenWeight = parameters.FirstOrDefault(x => x.Code.Equals(ParametersEnum.AVERAGE_WOMEN_WEIGHT.DbCode));
                var childrenWeight = parameters.FirstOrDefault(x => x.Code.Equals(ParametersEnum.AVERAGE_CHILDREN_WEIGHT.DbCode));
                var timeLimit = parameters.FirstOrDefault(x => x.Code.Equals(ParametersEnum.TIME_LIMIT.DbCode));
                var sunrise = parameters.FirstOrDefault(x => x.Code.Equals(ParametersEnum.SUNRISE_TIME.DbCode));
                var sunset = parameters.FirstOrDefault(x => x.Code.Equals(ParametersEnum.SUNSET_TIME.DbCode));

                //TODO: Pegar valores default do controller

                //USE TIME WINDOWS
                if (useTimeWindows == null)
                    this.radioButtonTimeWindowYes.Checked = true;
                else{
                    if (useTimeWindows.Value.Equals("true"))
                        this.radioButtonTimeWindowYes.Checked = true;
                    else
                        this.radioButtonTimeWindowNo.Checked = true;
                }

                //PICK UP ALL
                if (pickupAll == null)
                    this.radioButtonPickAllYes.Checked = true;
                else{
                    if (pickupAll.Value.Equals("true"))
                        this.radioButtonPickAllYes.Checked = true;
                    else
                        this.radioButtonPickAllNo.Checked = true;
                }

                //DELIVER ALL
                if (deliverAll == null)
                    this.radioButtonDeliverAllYes.Checked = true;
                else{
                    if (deliverAll.Value.Equals("true"))
                        this.radioButtonDeliverAllYes.Checked = true;
                    else
                        this.radioButtonDeliverAllNo.Checked = true;
                }

                //START FROM DEPOT 
                if (startFromDepot == null)
                    this.radioButtonStartDepotYes.Checked = true;
                else{
                    if (startFromDepot.Value.Equals("true"))
                        this.radioButtonStartDepotYes.Checked = true;
                    else
                        this.radioButtonStartDepotNo.Checked = true;
                }

                //COME BACK TO DEPOT
                if (comeBackToDepot == null)
                    this.radioButtonComeBackDepotYes.Checked = true;
                else{
                    if (comeBackToDepot.Value.Equals("true"))
                        this.radioButtonComeBackDepotYes.Checked = true;
                    else
                        this.radioButtonComeBackDepotNo.Checked = true;
                }

                //MEN WEIGHT 
                this.numUD_ManWeight.Value = menWeight == null ? 70 : Convert.ToInt32(menWeight.Value);

                //WOMEN WEIGHT 
                this.numUD_WomanWeight.Value = womenWeight == null ? 70 : Convert.ToInt32(womenWeight.Value);

                //CHILD WEIGHT
                this.numUD_ChildWeight.Value = childrenWeight == null ? 70 : Convert.ToInt32(childrenWeight.Value);

                //TIME LIMIT
                this.numUD_TimeLimit.Value = timeLimit == null ? 45 : Convert.ToInt32(timeLimit.Value);

                //SUNRISE
                if (sunrise != null){
                    var splited = sunrise.Value.Split(':');
                    this.numUD_SunriseH.Value = Convert.ToInt32(splited[0]);
                    this.numUD_SunriseM.Value = Convert.ToInt32(splited[1]);
                }else{
                    this.numUD_SunriseH.Value = 6;
                    this.numUD_SunriseM.Value = 15;
                }

                //SUNSET 
                if (sunset != null){
                    var splited = sunset.Value.Split(':');
                    this.numUD_Sunset_H.Value = Convert.ToInt32(splited[0]);
                    this.numUD_Sunset_M.Value = Convert.ToInt32(splited[1]);
                }else{
                    this.numUD_Sunset_H.Value = 18;
                    this.numUD_Sunset_M.Value = 15;
                }

            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void solutionToolStripMenuItem_Click(object sender, EventArgs e){
            var selectInstance = new SelectInstance(SelectInstance.SelectToEnum.EXPORT_INSTANCE_SOLUTION,Context);
            selectInstance.Show();
        }

        private void preOptimizationWarningsToolStripMenuItem_Click(object sender, EventArgs e){
            var selectInstance = new SelectInstance(SelectInstance.SelectToEnum.OPTIMIZATION_ALERTS, Context);
            
            selectInstance.ShowDialog();
        }
    }
}
