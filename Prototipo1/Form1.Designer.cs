using System;
using System.Windows.Forms;
using Prototipo1.Components;
using SolverClientComunication;

namespace Prototipo1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code


        private void InitializeViews(){
            this.Context = new CustomSqlContext();
            this.AirportView = new AirportView();
            this.AirplaneView = new AirplaneView();
            this.RequestView = new RequestsView();
            this.CurrencyView = new CurrencyView();
            this.FuelPriceView = new FuelPriceView();
            this.StretchView = new StretchView();
            this.RefuelSolutionView =new  RefuelSolutionView();
            this.RequestSolutionView = new RequestSolutionView();
            this.tabPageAirplanes.Controls.Add(AirplaneView);
            this.tabPageAirports.Controls.Add(AirportView);
            this.tabPageFuel.Controls.Add(FuelPriceView);
            this.tabExchangeRate.Controls.Add(CurrencyView);
            this.tabStretches.Controls.Add(StretchView);
            this.tabPageRefuels.Controls.Add(RefuelSolutionView);
            this.tabPageSolutionRequests.Controls.Add(RequestSolutionView);
        }
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Context = new SolverClientComunication.CustomSqlContext();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabInstances = new System.Windows.Forms.TabPage();
            this.buttonDeleteScenario = new System.Windows.Forms.Button();
            this.buttonCreateInstance = new System.Windows.Forms.Button();
            this.buttonEditScenario = new System.Windows.Forms.Button();
            this.panelInstanceDetails = new System.Windows.Forms.Panel();
            this.labelDescriptionInstance = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControlInputSolution = new System.Windows.Forms.TabControl();
            this.tabInput = new System.Windows.Forms.TabPage();
            this.tabControlInputTables = new System.Windows.Forms.TabControl();
            this.tabPageAirplanes = new System.Windows.Forms.TabPage();
            this.AirplaneView = new Prototipo1.Components.AirplaneView();
            this.tabPageAirports = new System.Windows.Forms.TabPage();
            this.AirportView = new Prototipo1.Components.AirportView();
            this.tabPageRequests = new System.Windows.Forms.TabPage();
            this.RequestView = new Prototipo1.Components.RequestsView();
            this.tabPageFuel = new System.Windows.Forms.TabPage();
            this.FuelPriceView = new Prototipo1.Components.FuelPriceView();
            this.tabExchangeRate = new System.Windows.Forms.TabPage();
            this.CurrencyView = new Prototipo1.Components.CurrencyView();
            this.tabStretches = new System.Windows.Forms.TabPage();
            this.StretchView = new Prototipo1.Components.StretchView();
            this.tabSolution = new System.Windows.Forms.TabPage();
            this.tabControlInstanceSolution = new System.Windows.Forms.TabControl();
            this.tabPageRouteVisualization = new System.Windows.Forms.TabPage();
            this.MapRoutView = new Prototipo1.Components.MapRoutesView();
            this.tabPageAirplaneUsage = new System.Windows.Forms.TabPage();
            this.dataGridViewRoutePassagers = new System.Windows.Forms.DataGridView();
            this.StretchPassenger = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StretchPNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StretchSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StretchClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewRoute = new System.Windows.Forms.DataGridView();
            this.IdAirplaneResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RouteId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StretchOrigin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuelOnDeparture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightOnDeparture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlightDepartureTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StretchDestination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuelOnArrival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WeightOnArrival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlightArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label18 = new System.Windows.Forms.Label();
            this.comboBoxAirplaneSolution = new System.Windows.Forms.ComboBox();
            this.tabPageRefuels = new System.Windows.Forms.TabPage();
            this.RefuelSolutionView = new Prototipo1.Components.RefuelSolutionView();
            this.tabPageSolutionRequests = new System.Windows.Forms.TabPage();
            this.RequestSolutionView = new Prototipo1.Components.RequestSolutionView();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxInstancesInstanceTab = new System.Windows.Forms.ComboBox();
            this.buttonOptimizeInstanceTab = new System.Windows.Forms.Button();
            this.tabParameters = new System.Windows.Forms.TabPage();
            this.buttonOptimizeAll = new System.Windows.Forms.Button();
            this.panelParamSelectInstance = new System.Windows.Forms.Panel();
            this.comboBoxInstanceParamTab = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.radioButtonGenSettingY = new System.Windows.Forms.RadioButton();
            this.radioButtonGenSettingN = new System.Windows.Forms.RadioButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.radioButtonHeuristic = new System.Windows.Forms.RadioButton();
            this.radioButtonExact = new System.Windows.Forms.RadioButton();
            this.label19 = new System.Windows.Forms.Label();
            this.numUD_TimeLimit = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.numUD_ChildWeight = new System.Windows.Forms.NumericUpDown();
            this.numUD_WomanWeight = new System.Windows.Forms.NumericUpDown();
            this.numUD_ManWeight = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCancelSaveParams = new System.Windows.Forms.Button();
            this.buttonSaveParams = new System.Windows.Forms.Button();
            this.buttonEditParams = new System.Windows.Forms.Button();
            this.buttonOptimizeInstance = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.radioButtonStartDepotYes = new System.Windows.Forms.RadioButton();
            this.radioButtonStartDepotNo = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonTimeWindowYes = new System.Windows.Forms.RadioButton();
            this.radioButtonTimeWindowNo = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonPickAllYes = new System.Windows.Forms.RadioButton();
            this.radioButtonPickAllNo = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonDeliverAllYes = new System.Windows.Forms.RadioButton();
            this.radioButtonDeliverAllNo = new System.Windows.Forms.RadioButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonComeBackDepotYes = new System.Windows.Forms.RadioButton();
            this.radioButtonComeBackDepotNo = new System.Windows.Forms.RadioButton();
            this.AiportAid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AirportName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ICAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longintude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Elevation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RunwayLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Region = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MTOW_APE3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MTOW_PC12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LandingCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroundTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instanceToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.solutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cplexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gurobiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xpressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.coinORToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.heuristicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabuSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simulatedAnnealingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gRASPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duplicateInstanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl.SuspendLayout();
            this.tabInstances.SuspendLayout();
            this.panelInstanceDetails.SuspendLayout();
            this.tabControlInputSolution.SuspendLayout();
            this.tabInput.SuspendLayout();
            this.tabControlInputTables.SuspendLayout();
            this.tabPageAirplanes.SuspendLayout();
            this.tabPageAirports.SuspendLayout();
            this.tabPageRequests.SuspendLayout();
            this.tabPageFuel.SuspendLayout();
            this.tabExchangeRate.SuspendLayout();
            this.tabStretches.SuspendLayout();
            this.tabSolution.SuspendLayout();
            this.tabControlInstanceSolution.SuspendLayout();
            this.tabPageRouteVisualization.SuspendLayout();
            this.tabPageAirplaneUsage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoutePassagers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoute)).BeginInit();
            this.tabPageRefuels.SuspendLayout();
            this.tabPageSolutionRequests.SuspendLayout();
            this.tabParameters.SuspendLayout();
            this.panelParamSelectInstance.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_TimeLimit)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_ChildWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_WomanWeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_ManWeight)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabInstances);
            this.tabControl.Controls.Add(this.tabParameters);
            this.tabControl.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(27, 61);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1223, 852);
            this.tabControl.TabIndex = 0;
            // 
            // tabInstances
            // 
            this.tabInstances.Controls.Add(this.buttonDeleteScenario);
            this.tabInstances.Controls.Add(this.buttonCreateInstance);
            this.tabInstances.Controls.Add(this.buttonEditScenario);
            this.tabInstances.Controls.Add(this.panelInstanceDetails);
            this.tabInstances.Controls.Add(this.tabControlInputSolution);
            this.tabInstances.Controls.Add(this.label7);
            this.tabInstances.Controls.Add(this.comboBoxInstancesInstanceTab);
            this.tabInstances.Controls.Add(this.buttonOptimizeInstanceTab);
            this.tabInstances.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.tabInstances.Location = new System.Drawing.Point(4, 40);
            this.tabInstances.Name = "tabInstances";
            this.tabInstances.Padding = new System.Windows.Forms.Padding(3);
            this.tabInstances.Size = new System.Drawing.Size(1215, 808);
            this.tabInstances.TabIndex = 1;
            this.tabInstances.Text = "Instances";
            this.tabInstances.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteScenario
            // 
            this.buttonDeleteScenario.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonDeleteScenario.Location = new System.Drawing.Point(872, 31);
            this.buttonDeleteScenario.Name = "buttonDeleteScenario";
            this.buttonDeleteScenario.Size = new System.Drawing.Size(113, 38);
            this.buttonDeleteScenario.TabIndex = 7;
            this.buttonDeleteScenario.Text = "Delete";
            this.buttonDeleteScenario.UseVisualStyleBackColor = true;
            this.buttonDeleteScenario.Visible = false;
            this.buttonDeleteScenario.Click += new System.EventHandler(this.buttonDeleteScenario_Click);
            // 
            // buttonCreateInstance
            // 
            this.buttonCreateInstance.Location = new System.Drawing.Point(434, 31);
            this.buttonCreateInstance.Name = "buttonCreateInstance";
            this.buttonCreateInstance.Size = new System.Drawing.Size(182, 38);
            this.buttonCreateInstance.TabIndex = 15;
            this.buttonCreateInstance.Text = "Create new";
            this.buttonCreateInstance.UseVisualStyleBackColor = true;
            this.buttonCreateInstance.Click += new System.EventHandler(this.buttonCreateInstance_Click);
            // 
            // buttonEditScenario
            // 
            this.buttonEditScenario.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonEditScenario.Location = new System.Drawing.Point(753, 31);
            this.buttonEditScenario.Name = "buttonEditScenario";
            this.buttonEditScenario.Size = new System.Drawing.Size(113, 38);
            this.buttonEditScenario.TabIndex = 6;
            this.buttonEditScenario.Text = "Edit";
            this.buttonEditScenario.UseVisualStyleBackColor = true;
            this.buttonEditScenario.Visible = false;
            this.buttonEditScenario.Click += new System.EventHandler(this.buttonEditScenario_Click);
            // 
            // panelInstanceDetails
            // 
            this.panelInstanceDetails.BackColor = System.Drawing.Color.DarkRed;
            this.panelInstanceDetails.Controls.Add(this.labelDescriptionInstance);
            this.panelInstanceDetails.Controls.Add(this.label15);
            this.panelInstanceDetails.Controls.Add(this.label11);
            this.panelInstanceDetails.Controls.Add(this.label10);
            this.panelInstanceDetails.Controls.Add(this.label9);
            this.panelInstanceDetails.Controls.Add(this.label8);
            this.panelInstanceDetails.ForeColor = System.Drawing.Color.White;
            this.panelInstanceDetails.Location = new System.Drawing.Point(20, 75);
            this.panelInstanceDetails.Name = "panelInstanceDetails";
            this.panelInstanceDetails.Size = new System.Drawing.Size(1164, 43);
            this.panelInstanceDetails.TabIndex = 13;
            this.panelInstanceDetails.Visible = false;
            // 
            // labelDescriptionInstance
            // 
            this.labelDescriptionInstance.AutoSize = true;
            this.labelDescriptionInstance.Location = new System.Drawing.Point(128, 11);
            this.labelDescriptionInstance.Name = "labelDescriptionInstance";
            this.labelDescriptionInstance.Size = new System.Drawing.Size(0, 24);
            this.labelDescriptionInstance.TabIndex = 6;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 11);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(109, 24);
            this.label15.TabIndex = 5;
            this.label15.Text = "Description:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1086, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 24);
            this.label11.TabIndex = 4;
            this.label11.Text = "No";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(928, 11);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 24);
            this.label10.TabIndex = 3;
            this.label10.Text = "Last optimization:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(838, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 24);
            this.label9.TabIndex = 2;
            this.label9.Text = "No";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(732, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 24);
            this.label8.TabIndex = 1;
            this.label8.Text = "Optimized:";
            // 
            // tabControlInputSolution
            // 
            this.tabControlInputSolution.Controls.Add(this.tabInput);
            this.tabControlInputSolution.Controls.Add(this.tabSolution);
            this.tabControlInputSolution.Location = new System.Drawing.Point(6, 146);
            this.tabControlInputSolution.Name = "tabControlInputSolution";
            this.tabControlInputSolution.SelectedIndex = 0;
            this.tabControlInputSolution.Size = new System.Drawing.Size(1203, 639);
            this.tabControlInputSolution.TabIndex = 14;
            // 
            // tabInput
            // 
            this.tabInput.Controls.Add(this.tabControlInputTables);
            this.tabInput.Location = new System.Drawing.Point(4, 31);
            this.tabInput.Name = "tabInput";
            this.tabInput.Padding = new System.Windows.Forms.Padding(3);
            this.tabInput.Size = new System.Drawing.Size(1195, 604);
            this.tabInput.TabIndex = 0;
            this.tabInput.Text = "Input";
            this.tabInput.UseVisualStyleBackColor = true;
            // 
            // tabControlInputTables
            // 
            this.tabControlInputTables.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlInputTables.Controls.Add(this.tabPageAirplanes);
            this.tabControlInputTables.Controls.Add(this.tabPageAirports);
            this.tabControlInputTables.Controls.Add(this.tabPageRequests);
            this.tabControlInputTables.Controls.Add(this.tabPageFuel);
            this.tabControlInputTables.Controls.Add(this.tabExchangeRate);
            this.tabControlInputTables.Controls.Add(this.tabStretches);
            this.tabControlInputTables.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlInputTables.ItemSize = new System.Drawing.Size(40, 100);
            this.tabControlInputTables.Location = new System.Drawing.Point(3, 24);
            this.tabControlInputTables.Multiline = true;
            this.tabControlInputTables.Name = "tabControlInputTables";
            this.tabControlInputTables.Padding = new System.Drawing.Point(200, 200);
            this.tabControlInputTables.SelectedIndex = 0;
            this.tabControlInputTables.Size = new System.Drawing.Size(1186, 554);
            this.tabControlInputTables.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlInputTables.TabIndex = 0;
            this.tabControlInputTables.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlInputTables_DrawItem);
            // 
            // tabPageAirplanes
            // 
            this.tabPageAirplanes.Controls.Add(this.AirplaneView);
            this.tabPageAirplanes.Location = new System.Drawing.Point(104, 4);
            this.tabPageAirplanes.Margin = new System.Windows.Forms.Padding(20);
            this.tabPageAirplanes.Name = "tabPageAirplanes";
            this.tabPageAirplanes.Padding = new System.Windows.Forms.Padding(20);
            this.tabPageAirplanes.Size = new System.Drawing.Size(1078, 546);
            this.tabPageAirplanes.TabIndex = 0;
            this.tabPageAirplanes.Text = "Airplanes";
            this.tabPageAirplanes.UseVisualStyleBackColor = true;
            // 
            // AirplaneView
            // 
            this.AirplaneView.AutoSize = true;
            this.AirplaneView.Context = Context;
            this.AirplaneView.Instance = null;
            this.AirplaneView.Location = new System.Drawing.Point(20, 20);
            this.AirplaneView.Name = "AirplaneView";
            this.AirplaneView.Size = new System.Drawing.Size(1026, 524);
            this.AirplaneView.TabIndex = 0;
            // 
            // tabPageAirports
            // 
            this.tabPageAirports.Controls.Add(this.AirportView);
            this.tabPageAirports.Location = new System.Drawing.Point(104, 4);
            this.tabPageAirports.Margin = new System.Windows.Forms.Padding(20);
            this.tabPageAirports.Name = "tabPageAirports";
            this.tabPageAirports.Padding = new System.Windows.Forms.Padding(20);
            this.tabPageAirports.Size = new System.Drawing.Size(1078, 546);
            this.tabPageAirports.TabIndex = 1;
            this.tabPageAirports.Text = "Airport";
            this.tabPageAirports.UseVisualStyleBackColor = true;
            // 
            // AirportView
            // 
            this.AirportView.Context = Context;
            this.AirportView.Instance = null;
            this.AirportView.Location = new System.Drawing.Point(0, 0);
            this.AirportView.Name = "AirportView";
            this.AirportView.Size = new System.Drawing.Size(1119, 526);
            this.AirportView.TabIndex = 0;
            // 
            // tabPageRequests
            // 
            this.tabPageRequests.Controls.Add(this.RequestView);
            this.tabPageRequests.Location = new System.Drawing.Point(104, 4);
            this.tabPageRequests.Margin = new System.Windows.Forms.Padding(20);
            this.tabPageRequests.Name = "tabPageRequests";
            this.tabPageRequests.Padding = new System.Windows.Forms.Padding(20);
            this.tabPageRequests.Size = new System.Drawing.Size(1078, 546);
            this.tabPageRequests.TabIndex = 2;
            this.tabPageRequests.Text = "Requests";
            this.tabPageRequests.UseVisualStyleBackColor = true;
            // 
            // RequestView
            // 
            this.RequestView.Context = Context;
            this.RequestView.Instance = null;
            this.RequestView.Location = new System.Drawing.Point(0, 0);
            this.RequestView.Name = "RequestView";
            this.RequestView.Size = new System.Drawing.Size(1081, 544);
            this.RequestView.TabIndex = 0;
            // 
            // tabPageFuel
            // 
            this.tabPageFuel.Controls.Add(this.FuelPriceView);
            this.tabPageFuel.Location = new System.Drawing.Point(104, 4);
            this.tabPageFuel.Name = "tabPageFuel";
            this.tabPageFuel.Size = new System.Drawing.Size(1078, 546);
            this.tabPageFuel.TabIndex = 3;
            this.tabPageFuel.Text = "Fuel";
            this.tabPageFuel.UseVisualStyleBackColor = true;
            // 
            // FuelPriceView
            // 
            this.FuelPriceView.Context = Context;
            this.FuelPriceView.Instance = null;
            this.FuelPriceView.Location = new System.Drawing.Point(0, 0);
            this.FuelPriceView.Name = "FuelPriceView";
            this.FuelPriceView.Size = new System.Drawing.Size(1048, 509);
            this.FuelPriceView.TabIndex = 0;
            // 
            // tabExchangeRate
            // 
            this.tabExchangeRate.Controls.Add(this.CurrencyView);
            this.tabExchangeRate.Location = new System.Drawing.Point(104, 4);
            this.tabExchangeRate.Name = "tabExchangeRate";
            this.tabExchangeRate.Padding = new System.Windows.Forms.Padding(3);
            this.tabExchangeRate.Size = new System.Drawing.Size(1078, 546);
            this.tabExchangeRate.TabIndex = 4;
            this.tabExchangeRate.Text = "Exchange Rates";
            this.tabExchangeRate.UseVisualStyleBackColor = true;
            // 
            // CurrencyView
            // 
            this.CurrencyView.Context = Context;
            this.CurrencyView.Instance = null;
            this.CurrencyView.Location = new System.Drawing.Point(0, 0);
            this.CurrencyView.Name = "CurrencyView";
            this.CurrencyView.Size = new System.Drawing.Size(1045, 438);
            this.CurrencyView.TabIndex = 0;
            // 
            // tabStretches
            // 
            this.tabStretches.Controls.Add(this.StretchView);
            this.tabStretches.Location = new System.Drawing.Point(104, 4);
            this.tabStretches.Name = "tabStretches";
            this.tabStretches.Padding = new System.Windows.Forms.Padding(3);
            this.tabStretches.Size = new System.Drawing.Size(1078, 546);
            this.tabStretches.TabIndex = 5;
            this.tabStretches.Text = "Stretches";
            this.tabStretches.UseVisualStyleBackColor = true;
            // 
            // StretchView
            // 
            this.StretchView.Context = Context;
            this.StretchView.Instance = null;
            this.StretchView.Location = new System.Drawing.Point(0, 0);
            this.StretchView.Name = "StretchView";
            this.StretchView.Size = new System.Drawing.Size(1040, 550);
            this.StretchView.TabIndex = 0;
            // 
            // tabSolution
            // 
            this.tabSolution.Controls.Add(this.tabControlInstanceSolution);
            this.tabSolution.Location = new System.Drawing.Point(4, 31);
            this.tabSolution.Name = "tabSolution";
            this.tabSolution.Padding = new System.Windows.Forms.Padding(3);
            this.tabSolution.Size = new System.Drawing.Size(1195, 604);
            this.tabSolution.TabIndex = 1;
            this.tabSolution.Text = "Solution";
            this.tabSolution.UseVisualStyleBackColor = true;
            // 
            // tabControlInstanceSolution
            // 
            this.tabControlInstanceSolution.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlInstanceSolution.Controls.Add(this.tabPageRouteVisualization);
            this.tabControlInstanceSolution.Controls.Add(this.tabPageAirplaneUsage);
            this.tabControlInstanceSolution.Controls.Add(this.tabPageRefuels);
            this.tabControlInstanceSolution.Controls.Add(this.tabPageSolutionRequests);
            this.tabControlInstanceSolution.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlInstanceSolution.ItemSize = new System.Drawing.Size(40, 100);
            this.tabControlInstanceSolution.Location = new System.Drawing.Point(4, 25);
            this.tabControlInstanceSolution.Multiline = true;
            this.tabControlInstanceSolution.Name = "tabControlInstanceSolution";
            this.tabControlInstanceSolution.Padding = new System.Drawing.Point(200, 200);
            this.tabControlInstanceSolution.SelectedIndex = 0;
            this.tabControlInstanceSolution.Size = new System.Drawing.Size(1186, 554);
            this.tabControlInstanceSolution.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlInstanceSolution.TabIndex = 1;
            this.tabControlInstanceSolution.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlOtherTables_DrawItem);
            // 
            // tabPageRouteVisualization
            // 
            this.tabPageRouteVisualization.Controls.Add(this.MapRoutView);
            this.tabPageRouteVisualization.Location = new System.Drawing.Point(104, 4);
            this.tabPageRouteVisualization.Margin = new System.Windows.Forms.Padding(20);
            this.tabPageRouteVisualization.Name = "tabPageRouteVisualization";
            this.tabPageRouteVisualization.Padding = new System.Windows.Forms.Padding(20);
            this.tabPageRouteVisualization.Size = new System.Drawing.Size(1078, 546);
            this.tabPageRouteVisualization.TabIndex = 0;
            this.tabPageRouteVisualization.Text = "Route Vizualization";
            this.tabPageRouteVisualization.UseVisualStyleBackColor = true;
            // 
            // MapRoutView
            // 
            this.MapRoutView.Location = new System.Drawing.Point(34, 23);
            this.MapRoutView.Name = "MapRoutView";
            this.MapRoutView.Size = new System.Drawing.Size(1021, 500);
            this.MapRoutView.TabIndex = 0;
            // 
            // tabPageAirplaneUsage
            // 
            this.tabPageAirplaneUsage.Controls.Add(this.dataGridViewRoutePassagers);
            this.tabPageAirplaneUsage.Controls.Add(this.dataGridViewRoute);
            this.tabPageAirplaneUsage.Controls.Add(this.label18);
            this.tabPageAirplaneUsage.Controls.Add(this.comboBoxAirplaneSolution);
            this.tabPageAirplaneUsage.Location = new System.Drawing.Point(104, 4);
            this.tabPageAirplaneUsage.Margin = new System.Windows.Forms.Padding(20);
            this.tabPageAirplaneUsage.Name = "tabPageAirplaneUsage";
            this.tabPageAirplaneUsage.Padding = new System.Windows.Forms.Padding(20);
            this.tabPageAirplaneUsage.Size = new System.Drawing.Size(1078, 546);
            this.tabPageAirplaneUsage.TabIndex = 1;
            this.tabPageAirplaneUsage.Text = "Airplanes Usage";
            this.tabPageAirplaneUsage.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRoutePassagers
            // 
            this.dataGridViewRoutePassagers.AllowUserToAddRows = false;
            this.dataGridViewRoutePassagers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRoutePassagers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StretchPassenger,
            this.StretchPNR,
            this.StretchSex,
            this.StretchClass});
            this.dataGridViewRoutePassagers.Location = new System.Drawing.Point(16, 350);
            this.dataGridViewRoutePassagers.Name = "dataGridViewRoutePassagers";
            this.dataGridViewRoutePassagers.RowHeadersVisible = false;
            this.dataGridViewRoutePassagers.RowTemplate.Height = 24;
            this.dataGridViewRoutePassagers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRoutePassagers.Size = new System.Drawing.Size(1017, 162);
            this.dataGridViewRoutePassagers.TabIndex = 6;
            // 
            // StretchPassenger
            // 
            this.StretchPassenger.HeaderText = "Passenger";
            this.StretchPassenger.Name = "StretchPassenger";
            this.StretchPassenger.Width = 360;
            // 
            // StretchPNR
            // 
            this.StretchPNR.HeaderText = "PNR";
            this.StretchPNR.Name = "StretchPNR";
            this.StretchPNR.Width = 150;
            // 
            // StretchSex
            // 
            this.StretchSex.HeaderText = "Sex";
            this.StretchSex.Name = "StretchSex";
            this.StretchSex.Width = 150;
            // 
            // StretchClass
            // 
            this.StretchClass.HeaderText = "Class";
            this.StretchClass.Name = "StretchClass";
            this.StretchClass.Width = 150;
            // 
            // dataGridViewRoute
            // 
            this.dataGridViewRoute.AllowUserToAddRows = false;
            this.dataGridViewRoute.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRoute.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdAirplaneResult,
            this.RouteId,
            this.StretchOrigin,
            this.FuelOnDeparture,
            this.WeightOnDeparture,
            this.FlightDepartureTime,
            this.StretchDestination,
            this.FuelOnArrival,
            this.WeightOnArrival,
            this.FlightArrivalTime});
            this.dataGridViewRoute.Location = new System.Drawing.Point(16, 96);
            this.dataGridViewRoute.Name = "dataGridViewRoute";
            this.dataGridViewRoute.RowHeadersVisible = false;
            this.dataGridViewRoute.RowTemplate.Height = 24;
            this.dataGridViewRoute.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRoute.Size = new System.Drawing.Size(1017, 190);
            this.dataGridViewRoute.TabIndex = 5;
            this.dataGridViewRoute.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRoute_RowEnter);
            // 
            // IdAirplaneResult
            // 
            this.IdAirplaneResult.HeaderText = "Id";
            this.IdAirplaneResult.Name = "IdAirplaneResult";
            this.IdAirplaneResult.ReadOnly = true;
            this.IdAirplaneResult.Visible = false;
            // 
            // RouteId
            // 
            this.RouteId.HeaderText = "Route ID";
            this.RouteId.Name = "RouteId";
            this.RouteId.Visible = false;
            this.RouteId.Width = 120;
            // 
            // StretchOrigin
            // 
            this.StretchOrigin.HeaderText = "Origin";
            this.StretchOrigin.Name = "StretchOrigin";
            this.StretchOrigin.Width = 200;
            // 
            // FuelOnDeparture
            // 
            this.FuelOnDeparture.HeaderText = "Fuel On Departure";
            this.FuelOnDeparture.Name = "FuelOnDeparture";
            // 
            // WeightOnDeparture
            // 
            this.WeightOnDeparture.HeaderText = "Weight On Departure";
            this.WeightOnDeparture.Name = "WeightOnDeparture";
            this.WeightOnDeparture.Width = 150;
            // 
            // FlightDepartureTime
            // 
            this.FlightDepartureTime.HeaderText = "Departure Time";
            this.FlightDepartureTime.Name = "FlightDepartureTime";
            // 
            // StretchDestination
            // 
            this.StretchDestination.HeaderText = "Destination";
            this.StretchDestination.Name = "StretchDestination";
            this.StretchDestination.Width = 200;
            // 
            // FuelOnArrival
            // 
            this.FuelOnArrival.HeaderText = "Fuel On Arrival";
            this.FuelOnArrival.Name = "FuelOnArrival";
            this.FuelOnArrival.Width = 120;
            // 
            // WeightOnArrival
            // 
            this.WeightOnArrival.HeaderText = "Weight On Arrival";
            this.WeightOnArrival.Name = "WeightOnArrival";
            this.WeightOnArrival.Width = 150;
            // 
            // FlightArrivalTime
            // 
            this.FlightArrivalTime.HeaderText = "Arrival Time";
            this.FlightArrivalTime.Name = "FlightArrivalTime";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 12);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 24);
            this.label18.TabIndex = 4;
            this.label18.Text = "Airplanes";
            // 
            // comboBoxAirplaneSolution
            // 
            this.comboBoxAirplaneSolution.FormattingEnabled = true;
            this.comboBoxAirplaneSolution.Location = new System.Drawing.Point(12, 39);
            this.comboBoxAirplaneSolution.Name = "comboBoxAirplaneSolution";
            this.comboBoxAirplaneSolution.Size = new System.Drawing.Size(220, 30);
            this.comboBoxAirplaneSolution.TabIndex = 3;
            this.comboBoxAirplaneSolution.SelectedIndexChanged += new System.EventHandler(this.comboBoxAirplaneSolution_SelectedIndexChanged);
            // 
            // tabPageRefuels
            // 
            this.tabPageRefuels.Controls.Add(this.RefuelSolutionView);
            this.tabPageRefuels.Location = new System.Drawing.Point(104, 4);
            this.tabPageRefuels.Name = "tabPageRefuels";
            this.tabPageRefuels.Size = new System.Drawing.Size(1078, 546);
            this.tabPageRefuels.TabIndex = 2;
            this.tabPageRefuels.Text = "Refuels";
            this.tabPageRefuels.UseVisualStyleBackColor = true;
            // 
            // RefuelSolutionView
            // 
            this.RefuelSolutionView.Context = Context;
            this.RefuelSolutionView.Instance = null;
            this.RefuelSolutionView.Location = new System.Drawing.Point(0, 0);
            this.RefuelSolutionView.Name = "RefuelSolutionView";
            this.RefuelSolutionView.Size = new System.Drawing.Size(1069, 454);
            this.RefuelSolutionView.TabIndex = 0;
            // 
            // tabPageSolutionRequests
            // 
            this.tabPageSolutionRequests.Controls.Add(this.RequestSolutionView);
            this.tabPageSolutionRequests.Location = new System.Drawing.Point(104, 4);
            this.tabPageSolutionRequests.Name = "tabPageSolutionRequests";
            this.tabPageSolutionRequests.Size = new System.Drawing.Size(1078, 546);
            this.tabPageSolutionRequests.TabIndex = 3;
            this.tabPageSolutionRequests.Text = "Requests";
            this.tabPageSolutionRequests.UseVisualStyleBackColor = true;
            // 
            // RequestSolutionView
            // 
            this.RequestSolutionView.Context = Context;
            this.RequestSolutionView.Instance = null;
            this.RequestSolutionView.Location = new System.Drawing.Point(0, 0);
            this.RequestSolutionView.Name = "RequestSolutionView";
            this.RequestSolutionView.Size = new System.Drawing.Size(1077, 500);
            this.RequestSolutionView.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label7.Location = new System.Drawing.Point(20, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 24);
            this.label7.TabIndex = 12;
            this.label7.Text = "Instance";
            // 
            // comboBoxInstancesInstanceTab
            // 
            this.comboBoxInstancesInstanceTab.FormattingEnabled = true;
            this.comboBoxInstancesInstanceTab.Location = new System.Drawing.Point(20, 39);
            this.comboBoxInstancesInstanceTab.Name = "comboBoxInstancesInstanceTab";
            this.comboBoxInstancesInstanceTab.Size = new System.Drawing.Size(373, 30);
            this.comboBoxInstancesInstanceTab.TabIndex = 0;
            this.comboBoxInstancesInstanceTab.SelectedIndexChanged += new System.EventHandler(this.comboBoxInstances_SelectedIndexChanged);
            // 
            // buttonOptimizeInstanceTab
            // 
            this.buttonOptimizeInstanceTab.Enabled = false;
            this.buttonOptimizeInstanceTab.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonOptimizeInstanceTab.Location = new System.Drawing.Point(1071, 34);
            this.buttonOptimizeInstanceTab.Name = "buttonOptimizeInstanceTab";
            this.buttonOptimizeInstanceTab.Size = new System.Drawing.Size(113, 38);
            this.buttonOptimizeInstanceTab.TabIndex = 0;
            this.buttonOptimizeInstanceTab.Text = "Optimize";
            this.buttonOptimizeInstanceTab.UseVisualStyleBackColor = true;
            this.buttonOptimizeInstanceTab.Click += new System.EventHandler(this.buttonOptimizeInstance_Click);
            // 
            // tabParameters
            // 
            this.tabParameters.Controls.Add(this.buttonOptimizeAll);
            this.tabParameters.Controls.Add(this.panelParamSelectInstance);
            this.tabParameters.Controls.Add(this.panel8);
            this.tabParameters.Controls.Add(this.panel6);
            this.tabParameters.Location = new System.Drawing.Point(4, 40);
            this.tabParameters.Name = "tabParameters";
            this.tabParameters.Padding = new System.Windows.Forms.Padding(3);
            this.tabParameters.Size = new System.Drawing.Size(1215, 808);
            this.tabParameters.TabIndex = 0;
            this.tabParameters.Text = "Parameters";
            this.tabParameters.UseVisualStyleBackColor = true;
            // 
            // buttonOptimizeAll
            // 
            this.buttonOptimizeAll.Location = new System.Drawing.Point(417, 668);
            this.buttonOptimizeAll.Name = "buttonOptimizeAll";
            this.buttonOptimizeAll.Size = new System.Drawing.Size(345, 48);
            this.buttonOptimizeAll.TabIndex = 17;
            this.buttonOptimizeAll.Text = "Optimize all instances";
            this.buttonOptimizeAll.UseVisualStyleBackColor = true;
            // 
            // panelParamSelectInstance
            // 
            this.panelParamSelectInstance.BackColor = System.Drawing.Color.DarkRed;
            this.panelParamSelectInstance.Controls.Add(this.comboBoxInstanceParamTab);
            this.panelParamSelectInstance.Controls.Add(this.label13);
            this.panelParamSelectInstance.ForeColor = System.Drawing.Color.White;
            this.panelParamSelectInstance.Location = new System.Drawing.Point(375, 15);
            this.panelParamSelectInstance.Name = "panelParamSelectInstance";
            this.panelParamSelectInstance.Size = new System.Drawing.Size(789, 90);
            this.panelParamSelectInstance.TabIndex = 16;
            this.panelParamSelectInstance.Visible = false;
            // 
            // comboBoxInstanceParamTab
            // 
            this.comboBoxInstanceParamTab.Font = new System.Drawing.Font("Arial Narrow", 12.2F);
            this.comboBoxInstanceParamTab.FormattingEnabled = true;
            this.comboBoxInstanceParamTab.Location = new System.Drawing.Point(12, 51);
            this.comboBoxInstanceParamTab.Name = "comboBoxInstanceParamTab";
            this.comboBoxInstanceParamTab.Size = new System.Drawing.Size(762, 32);
            this.comboBoxInstanceParamTab.TabIndex = 16;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 11);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 33);
            this.label13.TabIndex = 15;
            this.label13.Text = "Instance";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.DarkRed;
            this.panel8.Controls.Add(this.label12);
            this.panel8.Controls.Add(this.radioButtonGenSettingY);
            this.panel8.Controls.Add(this.radioButtonGenSettingN);
            this.panel8.ForeColor = System.Drawing.Color.White;
            this.panel8.Location = new System.Drawing.Point(11, 15);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(345, 90);
            this.panel8.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(178, 33);
            this.label12.TabIndex = 15;
            this.label12.Text = "General settings";
            // 
            // radioButtonGenSettingY
            // 
            this.radioButtonGenSettingY.AutoSize = true;
            this.radioButtonGenSettingY.Checked = true;
            this.radioButtonGenSettingY.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonGenSettingY.Location = new System.Drawing.Point(12, 54);
            this.radioButtonGenSettingY.Name = "radioButtonGenSettingY";
            this.radioButtonGenSettingY.Size = new System.Drawing.Size(55, 26);
            this.radioButtonGenSettingY.TabIndex = 13;
            this.radioButtonGenSettingY.TabStop = true;
            this.radioButtonGenSettingY.Text = "Yes";
            this.radioButtonGenSettingY.UseVisualStyleBackColor = true;
            this.radioButtonGenSettingY.CheckedChanged += new System.EventHandler(this.radioButtonGenSettingY_CheckedChanged);
            // 
            // radioButtonGenSettingN
            // 
            this.radioButtonGenSettingN.AutoSize = true;
            this.radioButtonGenSettingN.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonGenSettingN.Location = new System.Drawing.Point(164, 54);
            this.radioButtonGenSettingN.Name = "radioButtonGenSettingN";
            this.radioButtonGenSettingN.Size = new System.Drawing.Size(49, 26);
            this.radioButtonGenSettingN.TabIndex = 14;
            this.radioButtonGenSettingN.Text = "No";
            this.radioButtonGenSettingN.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.DarkRed;
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Controls.Add(this.buttonCancelSaveParams);
            this.panel6.Controls.Add(this.buttonSaveParams);
            this.panel6.Controls.Add(this.buttonEditParams);
            this.panel6.Controls.Add(this.buttonOptimizeInstance);
            this.panel6.Controls.Add(this.button4);
            this.panel6.Controls.Add(this.panel9);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Controls.Add(this.panel3);
            this.panel6.Controls.Add(this.panel4);
            this.panel6.Location = new System.Drawing.Point(11, 140);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1153, 501);
            this.panel6.TabIndex = 12;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.radioButtonHeuristic);
            this.panel7.Controls.Add(this.radioButtonExact);
            this.panel7.Controls.Add(this.label19);
            this.panel7.Controls.Add(this.numUD_TimeLimit);
            this.panel7.Controls.Add(this.label21);
            this.panel7.Controls.Add(this.label22);
            this.panel7.Location = new System.Drawing.Point(861, 15);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(279, 151);
            this.panel7.TabIndex = 23;
            // 
            // radioButtonHeuristic
            // 
            this.radioButtonHeuristic.AutoSize = true;
            this.radioButtonHeuristic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonHeuristic.Location = new System.Drawing.Point(141, 111);
            this.radioButtonHeuristic.Name = "radioButtonHeuristic";
            this.radioButtonHeuristic.Size = new System.Drawing.Size(104, 28);
            this.radioButtonHeuristic.TabIndex = 7;
            this.radioButtonHeuristic.TabStop = true;
            this.radioButtonHeuristic.Text = "Heuristic";
            this.radioButtonHeuristic.UseVisualStyleBackColor = true;
            // 
            // radioButtonExact
            // 
            this.radioButtonExact.AutoSize = true;
            this.radioButtonExact.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonExact.Location = new System.Drawing.Point(141, 77);
            this.radioButtonExact.Name = "radioButtonExact";
            this.radioButtonExact.Size = new System.Drawing.Size(78, 28);
            this.radioButtonExact.TabIndex = 6;
            this.radioButtonExact.TabStop = true;
            this.radioButtonExact.Text = "Exact";
            this.radioButtonExact.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label19.Location = new System.Drawing.Point(4, 81);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(79, 24);
            this.label19.TabIndex = 5;
            this.label19.Text = "Method:";
            // 
            // numUD_TimeLimit
            // 
            this.numUD_TimeLimit.Enabled = false;
            this.numUD_TimeLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.numUD_TimeLimit.Location = new System.Drawing.Point(141, 39);
            this.numUD_TimeLimit.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUD_TimeLimit.Name = "numUD_TimeLimit";
            this.numUD_TimeLimit.Size = new System.Drawing.Size(50, 28);
            this.numUD_TimeLimit.TabIndex = 4;
            this.numUD_TimeLimit.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label21.Location = new System.Drawing.Point(4, 43);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(134, 24);
            this.label21.TabIndex = 1;
            this.label21.Text = "Time Limit (m):";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(3, 6);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(144, 24);
            this.label22.TabIndex = 0;
            this.label22.Text = "Solver Params";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Controls.Add(this.numUD_ChildWeight);
            this.panel5.Controls.Add(this.numUD_WomanWeight);
            this.panel5.Controls.Add(this.numUD_ManWeight);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.label16);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(554, 15);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(291, 151);
            this.panel5.TabIndex = 22;
            // 
            // numUD_ChildWeight
            // 
            this.numUD_ChildWeight.Enabled = false;
            this.numUD_ChildWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.numUD_ChildWeight.Location = new System.Drawing.Point(99, 115);
            this.numUD_ChildWeight.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numUD_ChildWeight.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numUD_ChildWeight.Name = "numUD_ChildWeight";
            this.numUD_ChildWeight.Size = new System.Drawing.Size(50, 28);
            this.numUD_ChildWeight.TabIndex = 6;
            this.numUD_ChildWeight.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numUD_WomanWeight
            // 
            this.numUD_WomanWeight.Enabled = false;
            this.numUD_WomanWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.numUD_WomanWeight.Location = new System.Drawing.Point(99, 77);
            this.numUD_WomanWeight.Maximum = new decimal(new int[] {
            110,
            0,
            0,
            0});
            this.numUD_WomanWeight.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.numUD_WomanWeight.Name = "numUD_WomanWeight";
            this.numUD_WomanWeight.Size = new System.Drawing.Size(50, 28);
            this.numUD_WomanWeight.TabIndex = 5;
            this.numUD_WomanWeight.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // numUD_ManWeight
            // 
            this.numUD_ManWeight.Enabled = false;
            this.numUD_ManWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.numUD_ManWeight.Location = new System.Drawing.Point(99, 39);
            this.numUD_ManWeight.Maximum = new decimal(new int[] {
            110,
            0,
            0,
            0});
            this.numUD_ManWeight.Minimum = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.numUD_ManWeight.Name = "numUD_ManWeight";
            this.numUD_ManWeight.Size = new System.Drawing.Size(50, 28);
            this.numUD_ManWeight.TabIndex = 4;
            this.numUD_ManWeight.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label17.Location = new System.Drawing.Point(3, 121);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(86, 24);
            this.label17.TabIndex = 3;
            this.label17.Text = "Children:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label16.Location = new System.Drawing.Point(3, 81);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(81, 24);
            this.label16.TabIndex = 2;
            this.label16.Text = "Woman:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label6.Location = new System.Drawing.Point(4, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 24);
            this.label6.TabIndex = 1;
            this.label6.Text = "Man:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Average Weight (Kg)";
            // 
            // buttonCancelSaveParams
            // 
            this.buttonCancelSaveParams.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonCancelSaveParams.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonCancelSaveParams.Location = new System.Drawing.Point(679, 324);
            this.buttonCancelSaveParams.Name = "buttonCancelSaveParams";
            this.buttonCancelSaveParams.Size = new System.Drawing.Size(150, 48);
            this.buttonCancelSaveParams.TabIndex = 21;
            this.buttonCancelSaveParams.Text = "Cancel";
            this.buttonCancelSaveParams.UseVisualStyleBackColor = false;
            this.buttonCancelSaveParams.Visible = false;
            this.buttonCancelSaveParams.Click += new System.EventHandler(this.buttonCancelSaveParams_Click);
            // 
            // buttonSaveParams
            // 
            this.buttonSaveParams.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonSaveParams.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonSaveParams.Location = new System.Drawing.Point(320, 324);
            this.buttonSaveParams.Name = "buttonSaveParams";
            this.buttonSaveParams.Size = new System.Drawing.Size(150, 48);
            this.buttonSaveParams.TabIndex = 20;
            this.buttonSaveParams.Text = "Save";
            this.buttonSaveParams.UseVisualStyleBackColor = false;
            this.buttonSaveParams.Visible = false;
            this.buttonSaveParams.Click += new System.EventHandler(this.buttonSaveParams_Click);
            // 
            // buttonEditParams
            // 
            this.buttonEditParams.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonEditParams.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonEditParams.Location = new System.Drawing.Point(782, 236);
            this.buttonEditParams.Name = "buttonEditParams";
            this.buttonEditParams.Size = new System.Drawing.Size(150, 48);
            this.buttonEditParams.TabIndex = 19;
            this.buttonEditParams.Text = "Edit";
            this.buttonEditParams.UseVisualStyleBackColor = false;
            this.buttonEditParams.Click += new System.EventHandler(this.buttonEditParams_Click);
            // 
            // buttonOptimizeInstance
            // 
            this.buttonOptimizeInstance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.buttonOptimizeInstance.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonOptimizeInstance.Location = new System.Drawing.Point(418, 436);
            this.buttonOptimizeInstance.Name = "buttonOptimizeInstance";
            this.buttonOptimizeInstance.Size = new System.Drawing.Size(316, 48);
            this.buttonOptimizeInstance.TabIndex = 18;
            this.buttonOptimizeInstance.Text = "Optimize instance";
            this.buttonOptimizeInstance.UseVisualStyleBackColor = false;
            this.buttonOptimizeInstance.Visible = false;
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.Color.DarkRed;
            this.button4.Location = new System.Drawing.Point(363, 751);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(175, 54);
            this.button4.TabIndex = 14;
            this.button4.Text = "Save";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.label14);
            this.panel9.Controls.Add(this.radioButtonStartDepotYes);
            this.panel9.Controls.Add(this.radioButtonStartDepotNo);
            this.panel9.Location = new System.Drawing.Point(21, 181);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(508, 40);
            this.panel9.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(168, 24);
            this.label14.TabIndex = 2;
            this.label14.Text = "Start from depot?";
            // 
            // radioButtonStartDepotYes
            // 
            this.radioButtonStartDepotYes.AutoSize = true;
            this.radioButtonStartDepotYes.Checked = true;
            this.radioButtonStartDepotYes.Enabled = false;
            this.radioButtonStartDepotYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonStartDepotYes.Location = new System.Drawing.Point(262, 4);
            this.radioButtonStartDepotYes.Name = "radioButtonStartDepotYes";
            this.radioButtonStartDepotYes.Size = new System.Drawing.Size(63, 28);
            this.radioButtonStartDepotYes.TabIndex = 0;
            this.radioButtonStartDepotYes.TabStop = true;
            this.radioButtonStartDepotYes.Text = "Yes";
            this.radioButtonStartDepotYes.UseVisualStyleBackColor = true;
            // 
            // radioButtonStartDepotNo
            // 
            this.radioButtonStartDepotNo.AutoSize = true;
            this.radioButtonStartDepotNo.Enabled = false;
            this.radioButtonStartDepotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonStartDepotNo.Location = new System.Drawing.Point(369, 4);
            this.radioButtonStartDepotNo.Name = "radioButtonStartDepotNo";
            this.radioButtonStartDepotNo.Size = new System.Drawing.Size(56, 28);
            this.radioButtonStartDepotNo.TabIndex = 1;
            this.radioButtonStartDepotNo.Text = "No";
            this.radioButtonStartDepotNo.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.radioButtonTimeWindowYes);
            this.panel1.Controls.Add(this.radioButtonTimeWindowNo);
            this.panel1.Location = new System.Drawing.Point(21, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 40);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Use Time Windows?";
            // 
            // radioButtonTimeWindowYes
            // 
            this.radioButtonTimeWindowYes.AutoSize = true;
            this.radioButtonTimeWindowYes.Checked = true;
            this.radioButtonTimeWindowYes.Enabled = false;
            this.radioButtonTimeWindowYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonTimeWindowYes.Location = new System.Drawing.Point(262, 4);
            this.radioButtonTimeWindowYes.Name = "radioButtonTimeWindowYes";
            this.radioButtonTimeWindowYes.Size = new System.Drawing.Size(63, 28);
            this.radioButtonTimeWindowYes.TabIndex = 0;
            this.radioButtonTimeWindowYes.TabStop = true;
            this.radioButtonTimeWindowYes.Text = "Yes";
            this.radioButtonTimeWindowYes.UseVisualStyleBackColor = true;
            // 
            // radioButtonTimeWindowNo
            // 
            this.radioButtonTimeWindowNo.AutoSize = true;
            this.radioButtonTimeWindowNo.Enabled = false;
            this.radioButtonTimeWindowNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonTimeWindowNo.Location = new System.Drawing.Point(369, 3);
            this.radioButtonTimeWindowNo.Name = "radioButtonTimeWindowNo";
            this.radioButtonTimeWindowNo.Size = new System.Drawing.Size(56, 28);
            this.radioButtonTimeWindowNo.TabIndex = 1;
            this.radioButtonTimeWindowNo.Text = "No";
            this.radioButtonTimeWindowNo.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.radioButtonPickAllYes);
            this.panel2.Controls.Add(this.radioButtonPickAllNo);
            this.panel2.Location = new System.Drawing.Point(21, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(508, 40);
            this.panel2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pick all?";
            // 
            // radioButtonPickAllYes
            // 
            this.radioButtonPickAllYes.AutoSize = true;
            this.radioButtonPickAllYes.Checked = true;
            this.radioButtonPickAllYes.Enabled = false;
            this.radioButtonPickAllYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonPickAllYes.Location = new System.Drawing.Point(262, 4);
            this.radioButtonPickAllYes.Name = "radioButtonPickAllYes";
            this.radioButtonPickAllYes.Size = new System.Drawing.Size(63, 28);
            this.radioButtonPickAllYes.TabIndex = 0;
            this.radioButtonPickAllYes.TabStop = true;
            this.radioButtonPickAllYes.Text = "Yes";
            this.radioButtonPickAllYes.UseVisualStyleBackColor = true;
            // 
            // radioButtonPickAllNo
            // 
            this.radioButtonPickAllNo.AutoSize = true;
            this.radioButtonPickAllNo.Enabled = false;
            this.radioButtonPickAllNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonPickAllNo.Location = new System.Drawing.Point(369, 4);
            this.radioButtonPickAllNo.Name = "radioButtonPickAllNo";
            this.radioButtonPickAllNo.Size = new System.Drawing.Size(56, 28);
            this.radioButtonPickAllNo.TabIndex = 1;
            this.radioButtonPickAllNo.Text = "No";
            this.radioButtonPickAllNo.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.radioButtonDeliverAllYes);
            this.panel3.Controls.Add(this.radioButtonDeliverAllNo);
            this.panel3.Location = new System.Drawing.Point(21, 126);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(508, 40);
            this.panel3.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Deliver all?";
            // 
            // radioButtonDeliverAllYes
            // 
            this.radioButtonDeliverAllYes.AutoSize = true;
            this.radioButtonDeliverAllYes.Checked = true;
            this.radioButtonDeliverAllYes.Enabled = false;
            this.radioButtonDeliverAllYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonDeliverAllYes.Location = new System.Drawing.Point(262, 4);
            this.radioButtonDeliverAllYes.Name = "radioButtonDeliverAllYes";
            this.radioButtonDeliverAllYes.Size = new System.Drawing.Size(63, 28);
            this.radioButtonDeliverAllYes.TabIndex = 0;
            this.radioButtonDeliverAllYes.TabStop = true;
            this.radioButtonDeliverAllYes.Text = "Yes";
            this.radioButtonDeliverAllYes.UseVisualStyleBackColor = true;
            // 
            // radioButtonDeliverAllNo
            // 
            this.radioButtonDeliverAllNo.AutoSize = true;
            this.radioButtonDeliverAllNo.Enabled = false;
            this.radioButtonDeliverAllNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonDeliverAllNo.Location = new System.Drawing.Point(369, 4);
            this.radioButtonDeliverAllNo.Name = "radioButtonDeliverAllNo";
            this.radioButtonDeliverAllNo.Size = new System.Drawing.Size(56, 28);
            this.radioButtonDeliverAllNo.TabIndex = 1;
            this.radioButtonDeliverAllNo.Text = "No";
            this.radioButtonDeliverAllNo.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.radioButtonComeBackDepotYes);
            this.panel4.Controls.Add(this.radioButtonComeBackDepotNo);
            this.panel4.Location = new System.Drawing.Point(20, 236);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(509, 40);
            this.panel4.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Come back to depot?";
            // 
            // radioButtonComeBackDepotYes
            // 
            this.radioButtonComeBackDepotYes.AutoSize = true;
            this.radioButtonComeBackDepotYes.Checked = true;
            this.radioButtonComeBackDepotYes.Enabled = false;
            this.radioButtonComeBackDepotYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonComeBackDepotYes.Location = new System.Drawing.Point(262, 4);
            this.radioButtonComeBackDepotYes.Name = "radioButtonComeBackDepotYes";
            this.radioButtonComeBackDepotYes.Size = new System.Drawing.Size(63, 28);
            this.radioButtonComeBackDepotYes.TabIndex = 0;
            this.radioButtonComeBackDepotYes.TabStop = true;
            this.radioButtonComeBackDepotYes.Text = "Yes";
            this.radioButtonComeBackDepotYes.UseVisualStyleBackColor = true;
            // 
            // radioButtonComeBackDepotNo
            // 
            this.radioButtonComeBackDepotNo.AutoSize = true;
            this.radioButtonComeBackDepotNo.Enabled = false;
            this.radioButtonComeBackDepotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonComeBackDepotNo.Location = new System.Drawing.Point(370, 7);
            this.radioButtonComeBackDepotNo.Name = "radioButtonComeBackDepotNo";
            this.radioButtonComeBackDepotNo.Size = new System.Drawing.Size(56, 28);
            this.radioButtonComeBackDepotNo.TabIndex = 1;
            this.radioButtonComeBackDepotNo.Text = "No";
            this.radioButtonComeBackDepotNo.UseVisualStyleBackColor = true;
            // 
            // AiportAid
            // 
            this.AiportAid.HeaderText = "Id";
            this.AiportAid.Name = "AiportAid";
            this.AiportAid.ReadOnly = true;
            this.AiportAid.Visible = false;
            // 
            // AirportName
            // 
            this.AirportName.HeaderText = "Airport";
            this.AirportName.Name = "AirportName";
            // 
            // ICAO
            // 
            this.ICAO.HeaderText = "IATA";
            this.ICAO.Name = "ICAO";
            this.ICAO.Width = 70;
            // 
            // Latitude
            // 
            this.Latitude.HeaderText = "Latitude";
            this.Latitude.Name = "Latitude";
            this.Latitude.Width = 80;
            // 
            // Longintude
            // 
            this.Longintude.HeaderText = "Longitude";
            this.Longintude.Name = "Longintude";
            this.Longintude.Width = 80;
            // 
            // Elevation
            // 
            this.Elevation.HeaderText = "Elevation  (m)";
            this.Elevation.Name = "Elevation";
            // 
            // RunwayLength
            // 
            this.RunwayLength.HeaderText = "Runway Length (m)";
            this.RunwayLength.Name = "RunwayLength";
            // 
            // Region
            // 
            this.Region.HeaderText = "Region";
            this.Region.Name = "Region";
            // 
            // MTOW_APE3
            // 
            this.MTOW_APE3.HeaderText = "MTOW-APE3";
            this.MTOW_APE3.Name = "MTOW_APE3";
            this.MTOW_APE3.Width = 120;
            // 
            // MTOW_PC12
            // 
            this.MTOW_PC12.HeaderText = "MTOW-PC12";
            this.MTOW_PC12.Name = "MTOW_PC12";
            this.MTOW_PC12.Width = 120;
            // 
            // LandingCost
            // 
            this.LandingCost.HeaderText = "LandingCost (US$)";
            this.LandingCost.Name = "LandingCost";
            this.LandingCost.Width = 150;
            // 
            // GroundTime
            // 
            this.GroundTime.HeaderText = "Ground Time";
            this.GroundTime.Name = "GroundTime";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkRed;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1262, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instanceToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(127, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // instanceToolStripMenuItem
            // 
            this.instanceToolStripMenuItem.Name = "instanceToolStripMenuItem";
            this.instanceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.instanceToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.instanceToolStripMenuItem.Text = "Instance";
            this.instanceToolStripMenuItem.Click += new System.EventHandler(this.instanceToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.instanceToolStripMenuItem2,
            this.solutionToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(127, 26);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // instanceToolStripMenuItem2
            // 
            this.instanceToolStripMenuItem2.Name = "instanceToolStripMenuItem2";
            this.instanceToolStripMenuItem2.Size = new System.Drawing.Size(139, 26);
            this.instanceToolStripMenuItem2.Text = "Instance";
            // 
            // solutionToolStripMenuItem
            // 
            this.solutionToolStripMenuItem.Name = "solutionToolStripMenuItem";
            this.solutionToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.solutionToolStripMenuItem.Text = "Solution";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(127, 26);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solverToolStripMenuItem,
            this.advancedOptionsToolStripMenuItem});
            this.configurationToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(112, 24);
            this.configurationToolStripMenuItem.Text = "Configuration";
            // 
            // solverToolStripMenuItem
            // 
            this.solverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cplexToolStripMenuItem,
            this.gurobiToolStripMenuItem,
            this.xpressToolStripMenuItem,
            this.coinORToolStripMenuItem,
            this.toolStripSeparator1,
            this.heuristicToolStripMenuItem});
            this.solverToolStripMenuItem.Name = "solverToolStripMenuItem";
            this.solverToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.solverToolStripMenuItem.Text = "Solver";
            // 
            // cplexToolStripMenuItem
            // 
            this.cplexToolStripMenuItem.Checked = true;
            this.cplexToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cplexToolStripMenuItem.Name = "cplexToolStripMenuItem";
            this.cplexToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.cplexToolStripMenuItem.Text = "Cplex";
            this.cplexToolStripMenuItem.Click += new System.EventHandler(this.cplexToolStripMenuItem_Click);
            // 
            // gurobiToolStripMenuItem
            // 
            this.gurobiToolStripMenuItem.Name = "gurobiToolStripMenuItem";
            this.gurobiToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.gurobiToolStripMenuItem.Text = "Gurobi";
            this.gurobiToolStripMenuItem.Click += new System.EventHandler(this.gurobiToolStripMenuItem_Click);
            // 
            // xpressToolStripMenuItem
            // 
            this.xpressToolStripMenuItem.Name = "xpressToolStripMenuItem";
            this.xpressToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.xpressToolStripMenuItem.Text = "Xpress";
            this.xpressToolStripMenuItem.Click += new System.EventHandler(this.xpressToolStripMenuItem_Click);
            // 
            // coinORToolStripMenuItem
            // 
            this.coinORToolStripMenuItem.Name = "coinORToolStripMenuItem";
            this.coinORToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.coinORToolStripMenuItem.Text = "Coin-OR";
            this.coinORToolStripMenuItem.Click += new System.EventHandler(this.coinORToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(139, 6);
            // 
            // heuristicToolStripMenuItem
            // 
            this.heuristicToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabuSearchToolStripMenuItem,
            this.simulatedAnnealingToolStripMenuItem,
            this.gRASPToolStripMenuItem});
            this.heuristicToolStripMenuItem.Name = "heuristicToolStripMenuItem";
            this.heuristicToolStripMenuItem.Size = new System.Drawing.Size(142, 26);
            this.heuristicToolStripMenuItem.Text = "Heuristic";
            // 
            // tabuSearchToolStripMenuItem
            // 
            this.tabuSearchToolStripMenuItem.Name = "tabuSearchToolStripMenuItem";
            this.tabuSearchToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.tabuSearchToolStripMenuItem.Text = "Tabu Search";
            // 
            // simulatedAnnealingToolStripMenuItem
            // 
            this.simulatedAnnealingToolStripMenuItem.Name = "simulatedAnnealingToolStripMenuItem";
            this.simulatedAnnealingToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.simulatedAnnealingToolStripMenuItem.Text = "Simulated Annealing";
            // 
            // gRASPToolStripMenuItem
            // 
            this.gRASPToolStripMenuItem.Name = "gRASPToolStripMenuItem";
            this.gRASPToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.gRASPToolStripMenuItem.Text = "GRASP";
            // 
            // advancedOptionsToolStripMenuItem
            // 
            this.advancedOptionsToolStripMenuItem.Name = "advancedOptionsToolStripMenuItem";
            this.advancedOptionsToolStripMenuItem.Size = new System.Drawing.Size(204, 26);
            this.advancedOptionsToolStripMenuItem.Text = "Advanced options";
            this.advancedOptionsToolStripMenuItem.Click += new System.EventHandler(this.advancedOptionsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.duplicateInstanceToolStripMenuItem});
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // duplicateInstanceToolStripMenuItem
            // 
            this.duplicateInstanceToolStripMenuItem.Name = "duplicateInstanceToolStripMenuItem";
            this.duplicateInstanceToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.duplicateInstanceToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.duplicateInstanceToolStripMenuItem.Text = "Duplicate Instance";
            this.duplicateInstanceToolStripMenuItem.Click += new System.EventHandler(this.duplicateInstanceToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tutorialToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.DarkGray;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // tutorialToolStripMenuItem
            // 
            this.tutorialToolStripMenuItem.Name = "tutorialToolStripMenuItem";
            this.tutorialToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.tutorialToolStripMenuItem.Text = "Tutorial";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 26);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1262, 977);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 1024);
            this.MinimumSize = new System.Drawing.Size(1280, 1024);
            this.Name = "MainForm";
            this.Text = "Unimore - Optimizer 1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl.ResumeLayout(false);
            this.tabInstances.ResumeLayout(false);
            this.tabInstances.PerformLayout();
            this.panelInstanceDetails.ResumeLayout(false);
            this.panelInstanceDetails.PerformLayout();
            this.tabControlInputSolution.ResumeLayout(false);
            this.tabInput.ResumeLayout(false);
            this.tabControlInputTables.ResumeLayout(false);
            this.tabPageAirplanes.ResumeLayout(false);
            this.tabPageAirplanes.PerformLayout();
            this.tabPageAirports.ResumeLayout(false);
            this.tabPageRequests.ResumeLayout(false);
            this.tabPageFuel.ResumeLayout(false);
            this.tabExchangeRate.ResumeLayout(false);
            this.tabStretches.ResumeLayout(false);
            this.tabSolution.ResumeLayout(false);
            this.tabControlInstanceSolution.ResumeLayout(false);
            this.tabPageRouteVisualization.ResumeLayout(false);
            this.tabPageAirplaneUsage.ResumeLayout(false);
            this.tabPageAirplaneUsage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoutePassagers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoute)).EndInit();
            this.tabPageRefuels.ResumeLayout(false);
            this.tabPageSolutionRequests.ResumeLayout(false);
            this.tabParameters.ResumeLayout(false);
            this.panelParamSelectInstance.ResumeLayout(false);
            this.panelParamSelectInstance.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_TimeLimit)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_ChildWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_WomanWeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_ManWeight)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomSqlContext Context;    
        private AirportView AirportView; 
        private AirplaneView AirplaneView;
        private RequestsView RequestView;
        private CurrencyView CurrencyView;
        private FuelPriceView FuelPriceView;
        private StretchView StretchView;
        private RefuelSolutionView RefuelSolutionView;
        private RequestSolutionView RequestSolutionView;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabParameters;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonTimeWindowYes;
        private System.Windows.Forms.RadioButton radioButtonTimeWindowNo;
        private System.Windows.Forms.TabPage tabInstances;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonPickAllYes;
        private System.Windows.Forms.RadioButton radioButtonPickAllNo;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonDeliverAllYes;
        private System.Windows.Forms.RadioButton radioButtonDeliverAllNo;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButtonComeBackDepotYes;
        private System.Windows.Forms.RadioButton radioButtonComeBackDepotNo;
        private System.Windows.Forms.TabControl tabControlInputSolution;
        private System.Windows.Forms.TabPage tabInput;
        private System.Windows.Forms.TabPage tabSolution;
        private System.Windows.Forms.Panel panelInstanceDetails;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonOptimizeInstanceTab;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxInstancesInstanceTab;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instanceToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem advancedOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tutorialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cplexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gurobiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xpressToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem coinORToolStripMenuItem;
        private System.Windows.Forms.Panel panelParamSelectInstance;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton radioButtonGenSettingY;
        private System.Windows.Forms.RadioButton radioButtonGenSettingN;
        private System.Windows.Forms.Button buttonOptimizeAll;
        private System.Windows.Forms.ComboBox comboBoxInstanceParamTab;
        private System.Windows.Forms.Button buttonOptimizeInstance;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem heuristicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tabuSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simulatedAnnealingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gRASPToolStripMenuItem;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton radioButtonStartDepotYes;
        private System.Windows.Forms.RadioButton radioButtonStartDepotNo;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button buttonCreateInstance;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button buttonDeleteScenario;
        private System.Windows.Forms.Button buttonEditScenario;
        private System.Windows.Forms.Button buttonCancelSaveParams;
        private System.Windows.Forms.Button buttonSaveParams;
        private System.Windows.Forms.Button buttonEditParams;
        private DataGridViewTextBoxColumn AirplaneName;
        private Panel panel5;
        private NumericUpDown numUD_ChildWeight;
        private NumericUpDown numUD_WomanWeight;
        private NumericUpDown numUD_ManWeight;
        private Label label17;
        private Label label16;
        private Label label6;
        private Label label5;
        private TabControl tabControlInstanceSolution;
        private TabPage tabPageRouteVisualization;
        private TabPage tabPageAirplaneUsage;
        private DataGridView dataGridViewRoute;
        private Label label18;
        private ComboBox comboBoxAirplaneSolution;
        private DataGridView dataGridViewRoutePassagers;
        private DataGridViewTextBoxColumn StretchPassenger;
        private DataGridViewTextBoxColumn StretchPNR;
        private DataGridViewTextBoxColumn StretchSex;
        private DataGridViewTextBoxColumn StretchClass;
        private Panel panel7;
        private RadioButton radioButtonHeuristic;
        private RadioButton radioButtonExact;
        private Label label19;
        private NumericUpDown numUD_TimeLimit;
        private Label label21;
        private Label label22;
        private Label labelDescriptionInstance;
        private DataGridViewTextBoxColumn AiportAid;
        private DataGridViewTextBoxColumn AirportName;
        private DataGridViewTextBoxColumn ICAO;
        private DataGridViewTextBoxColumn Latitude;
        private DataGridViewTextBoxColumn Longintude;
        private DataGridViewTextBoxColumn Elevation;
        private DataGridViewTextBoxColumn RunwayLength;
        private DataGridViewTextBoxColumn Region;
        private DataGridViewTextBoxColumn MTOW_APE3;
        private DataGridViewTextBoxColumn MTOW_PC12;
        private DataGridViewTextBoxColumn LandingCost;
        private DataGridViewTextBoxColumn GroundTime;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem duplicateInstanceToolStripMenuItem;
        private TabPage tabPageRefuels;
        private TabPage tabPageSolutionRequests;
        private DataGridViewTextBoxColumn IdAirplaneResult;
        private DataGridViewTextBoxColumn RouteId;
        private DataGridViewTextBoxColumn StretchOrigin;
        private DataGridViewTextBoxColumn FuelOnDeparture;
        private DataGridViewTextBoxColumn WeightOnDeparture;
        private DataGridViewTextBoxColumn FlightDepartureTime;
        private DataGridViewTextBoxColumn StretchDestination;
        private DataGridViewTextBoxColumn FuelOnArrival;
        private DataGridViewTextBoxColumn WeightOnArrival;
        private DataGridViewTextBoxColumn FlightArrivalTime;
        private TabControl tabControlInputTables;
        private TabPage tabPageAirplanes;
        private TabPage tabPageAirports;
        private TabPage tabPageRequests;
        private TabPage tabPageFuel;
        private TabPage tabExchangeRate;
        private TabPage tabStretches;
        private MapRoutesView MapRoutView;
    }
}



