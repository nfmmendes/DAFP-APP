using System;
using System.Windows.Forms;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabInstances = new System.Windows.Forms.TabPage();
            this.buttonDeleteScenario = new System.Windows.Forms.Button();
            this.buttonCreateInstance = new System.Windows.Forms.Button();
            this.buttonEditScenario = new System.Windows.Forms.Button();
            this.panelInstanceDetails = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabInput = new System.Windows.Forms.TabPage();
            this.tabControlInputTables = new System.Windows.Forms.TabControl();
            this.tabPageAirplanes = new System.Windows.Forms.TabPage();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.tabPageAirports = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPageRequests = new System.Windows.Forms.TabPage();
            this.tabPageFuel = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tabSolution = new System.Windows.Forms.TabPage();
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
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AirportName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ICAO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longintude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Elevation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RunwayLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Region = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MTOW_APE3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MTOW_PC12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.BookingNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Origin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinDeparture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxDeparture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinArrival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxArrival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.AirplaneModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Range = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxWeightTakeOff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Airplane = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fuel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PricePerLitre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Passenger = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl.SuspendLayout();
            this.tabInstances.SuspendLayout();
            this.panelInstanceDetails.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabInput.SuspendLayout();
            this.tabControlInputTables.SuspendLayout();
            this.tabPageAirplanes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabPageAirports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPageRequests.SuspendLayout();
            this.tabPageFuel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabParameters.SuspendLayout();
            this.panelParamSelectInstance.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
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
            this.tabControl.Size = new System.Drawing.Size(1300, 850);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabInstances
            // 
            this.tabInstances.Controls.Add(this.buttonDeleteScenario);
            this.tabInstances.Controls.Add(this.buttonCreateInstance);
            this.tabInstances.Controls.Add(this.buttonEditScenario);
            this.tabInstances.Controls.Add(this.panelInstanceDetails);
            this.tabInstances.Controls.Add(this.tabControl2);
            this.tabInstances.Controls.Add(this.label7);
            this.tabInstances.Controls.Add(this.comboBoxInstancesInstanceTab);
            this.tabInstances.Controls.Add(this.buttonOptimizeInstanceTab);
            this.tabInstances.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.tabInstances.Location = new System.Drawing.Point(4, 40);
            this.tabInstances.Name = "tabInstances";
            this.tabInstances.Padding = new System.Windows.Forms.Padding(3);
            this.tabInstances.Size = new System.Drawing.Size(1292, 806);
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
            // 
            // panelInstanceDetails
            // 
            this.panelInstanceDetails.BackColor = System.Drawing.Color.DarkRed;
            this.panelInstanceDetails.Controls.Add(this.label15);
            this.panelInstanceDetails.Controls.Add(this.label11);
            this.panelInstanceDetails.Controls.Add(this.label10);
            this.panelInstanceDetails.Controls.Add(this.label9);
            this.panelInstanceDetails.Controls.Add(this.label8);
            this.panelInstanceDetails.ForeColor = System.Drawing.Color.White;
            this.panelInstanceDetails.Location = new System.Drawing.Point(20, 75);
            this.panelInstanceDetails.Name = "panelInstanceDetails";
            this.panelInstanceDetails.Size = new System.Drawing.Size(1250, 43);
            this.panelInstanceDetails.TabIndex = 13;
            this.panelInstanceDetails.Visible = false;
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
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabInput);
            this.tabControl2.Controls.Add(this.tabSolution);
            this.tabControl2.Location = new System.Drawing.Point(6, 146);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1264, 641);
            this.tabControl2.TabIndex = 14;
            // 
            // tabInput
            // 
            this.tabInput.Controls.Add(this.tabControlInputTables);
            this.tabInput.Location = new System.Drawing.Point(4, 31);
            this.tabInput.Name = "tabInput";
            this.tabInput.Padding = new System.Windows.Forms.Padding(3);
            this.tabInput.Size = new System.Drawing.Size(1256, 606);
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
            this.tabControlInputTables.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlInputTables.ItemSize = new System.Drawing.Size(40, 100);
            this.tabControlInputTables.Location = new System.Drawing.Point(3, 24);
            this.tabControlInputTables.Multiline = true;
            this.tabControlInputTables.Name = "tabControlInputTables";
            this.tabControlInputTables.Padding = new System.Drawing.Point(200, 200);
            this.tabControlInputTables.SelectedIndex = 0;
            this.tabControlInputTables.Size = new System.Drawing.Size(1247, 561);
            this.tabControlInputTables.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlInputTables.TabIndex = 0;
            this.tabControlInputTables.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlInputTables_DrawItem);
            // 
            // tabPageAirplanes
            // 
            this.tabPageAirplanes.Controls.Add(this.dataGridView3);
            this.tabPageAirplanes.Location = new System.Drawing.Point(104, 4);
            this.tabPageAirplanes.Margin = new System.Windows.Forms.Padding(20);
            this.tabPageAirplanes.Name = "tabPageAirplanes";
            this.tabPageAirplanes.Padding = new System.Windows.Forms.Padding(20);
            this.tabPageAirplanes.Size = new System.Drawing.Size(1139, 553);
            this.tabPageAirplanes.TabIndex = 0;
            this.tabPageAirplanes.Text = "Airplanes";
            this.tabPageAirplanes.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AirplaneModel,
            this.Prefix,
            this.Range,
            this.Weight,
            this.MaxWeightTakeOff,
            this.Capacity});
            this.dataGridView3.Location = new System.Drawing.Point(12, 23);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(1055, 238);
            this.dataGridView3.TabIndex = 0;
            // 
            // tabPageAirports
            // 
            this.tabPageAirports.Controls.Add(this.dataGridView1);
            this.tabPageAirports.Location = new System.Drawing.Point(104, 4);
            this.tabPageAirports.Margin = new System.Windows.Forms.Padding(20);
            this.tabPageAirports.Name = "tabPageAirports";
            this.tabPageAirports.Padding = new System.Windows.Forms.Padding(20);
            this.tabPageAirports.Size = new System.Drawing.Size(1139, 553);
            this.tabPageAirports.TabIndex = 1;
            this.tabPageAirports.Text = "Airport";
            this.tabPageAirports.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AirportName,
            this.ICAO,
            this.Latitude,
            this.Longintude,
            this.Elevation,
            this.RunwayLength,
            this.Region,
            this.MTOW_APE3,
            this.MTOW_PC12});
            this.dataGridView1.Location = new System.Drawing.Point(11, 32);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1087, 419);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPageRequests
            // 
            this.tabPageRequests.Controls.Add(this.dataGridView5);
            this.tabPageRequests.Controls.Add(this.dataGridView4);
            this.tabPageRequests.Location = new System.Drawing.Point(104, 4);
            this.tabPageRequests.Margin = new System.Windows.Forms.Padding(20);
            this.tabPageRequests.Name = "tabPageRequests";
            this.tabPageRequests.Padding = new System.Windows.Forms.Padding(20);
            this.tabPageRequests.Size = new System.Drawing.Size(1139, 553);
            this.tabPageRequests.TabIndex = 2;
            this.tabPageRequests.Text = "Requests";
            this.tabPageRequests.UseVisualStyleBackColor = true;
            // 
            // tabPageFuel
            // 
            this.tabPageFuel.Controls.Add(this.dataGridView2);
            this.tabPageFuel.Location = new System.Drawing.Point(104, 4);
            this.tabPageFuel.Name = "tabPageFuel";
            this.tabPageFuel.Size = new System.Drawing.Size(1139, 553);
            this.tabPageFuel.TabIndex = 3;
            this.tabPageFuel.Text = "Fuel";
            this.tabPageFuel.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Airplane,
            this.Fuel,
            this.Currency,
            this.PricePerLitre});
            this.dataGridView2.Location = new System.Drawing.Point(21, 19);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(1039, 223);
            this.dataGridView2.TabIndex = 1;
            // 
            // tabSolution
            // 
            this.tabSolution.Location = new System.Drawing.Point(4, 31);
            this.tabSolution.Name = "tabSolution";
            this.tabSolution.Padding = new System.Windows.Forms.Padding(3);
            this.tabSolution.Size = new System.Drawing.Size(1256, 606);
            this.tabSolution.TabIndex = 1;
            this.tabSolution.Text = "Solution";
            this.tabSolution.UseVisualStyleBackColor = true;
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
            this.buttonOptimizeInstanceTab.Location = new System.Drawing.Point(1153, 31);
            this.buttonOptimizeInstanceTab.Name = "buttonOptimizeInstanceTab";
            this.buttonOptimizeInstanceTab.Size = new System.Drawing.Size(113, 38);
            this.buttonOptimizeInstanceTab.TabIndex = 0;
            this.buttonOptimizeInstanceTab.Text = "Optimize";
            this.buttonOptimizeInstanceTab.UseVisualStyleBackColor = true;
            this.buttonOptimizeInstanceTab.Click += new System.EventHandler(this.button1_Click);
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
            this.tabParameters.Size = new System.Drawing.Size(1292, 806);
            this.tabParameters.TabIndex = 0;
            this.tabParameters.Text = "Parameters";
            this.tabParameters.UseVisualStyleBackColor = true;
            // 
            // buttonOptimizeAll
            // 
            this.buttonOptimizeAll.Location = new System.Drawing.Point(417, 627);
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
            this.panel6.Size = new System.Drawing.Size(1153, 462);
            this.panel6.TabIndex = 12;
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
            this.buttonEditParams.Location = new System.Drawing.Point(500, 324);
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
            this.buttonOptimizeInstance.Location = new System.Drawing.Point(418, 397);
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
            this.panel9.Size = new System.Drawing.Size(1117, 40);
            this.panel9.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label14.Location = new System.Drawing.Point(3, 7);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(151, 24);
            this.label14.TabIndex = 2;
            this.label14.Text = "Start from depot?";
            // 
            // radioButtonStartDepotYes
            // 
            this.radioButtonStartDepotYes.AutoSize = true;
            this.radioButtonStartDepotYes.Checked = true;
            this.radioButtonStartDepotYes.Enabled = false;
            this.radioButtonStartDepotYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonStartDepotYes.Location = new System.Drawing.Point(307, 4);
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
            this.radioButtonStartDepotNo.Location = new System.Drawing.Point(751, 4);
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
            this.panel1.Size = new System.Drawing.Size(1117, 40);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Use Time Windows?";
            // 
            // radioButtonTimeWindowYes
            // 
            this.radioButtonTimeWindowYes.AutoSize = true;
            this.radioButtonTimeWindowYes.Checked = true;
            this.radioButtonTimeWindowYes.Enabled = false;
            this.radioButtonTimeWindowYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonTimeWindowYes.Location = new System.Drawing.Point(307, 4);
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
            this.radioButtonTimeWindowNo.Location = new System.Drawing.Point(751, 3);
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
            this.panel2.Size = new System.Drawing.Size(1117, 40);
            this.panel2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label3.Location = new System.Drawing.Point(3, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Pick all?";
            // 
            // radioButtonPickAllYes
            // 
            this.radioButtonPickAllYes.AutoSize = true;
            this.radioButtonPickAllYes.Checked = true;
            this.radioButtonPickAllYes.Enabled = false;
            this.radioButtonPickAllYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonPickAllYes.Location = new System.Drawing.Point(307, 4);
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
            this.radioButtonPickAllNo.Location = new System.Drawing.Point(751, 4);
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
            this.panel3.Size = new System.Drawing.Size(1117, 40);
            this.panel3.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 24);
            this.label2.TabIndex = 2;
            this.label2.Text = "Deliver all?";
            // 
            // radioButtonDeliverAllYes
            // 
            this.radioButtonDeliverAllYes.AutoSize = true;
            this.radioButtonDeliverAllYes.Checked = true;
            this.radioButtonDeliverAllYes.Enabled = false;
            this.radioButtonDeliverAllYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonDeliverAllYes.Location = new System.Drawing.Point(307, 4);
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
            this.radioButtonDeliverAllNo.Location = new System.Drawing.Point(751, 4);
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
            this.panel4.Size = new System.Drawing.Size(1118, 40);
            this.panel4.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label4.Location = new System.Drawing.Point(3, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "Come back to depot?";
            // 
            // radioButtonComeBackDepotYes
            // 
            this.radioButtonComeBackDepotYes.AutoSize = true;
            this.radioButtonComeBackDepotYes.Checked = true;
            this.radioButtonComeBackDepotYes.Enabled = false;
            this.radioButtonComeBackDepotYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonComeBackDepotYes.Location = new System.Drawing.Point(307, 4);
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
            this.radioButtonComeBackDepotNo.Location = new System.Drawing.Point(752, 7);
            this.radioButtonComeBackDepotNo.Name = "radioButtonComeBackDepotNo";
            this.radioButtonComeBackDepotNo.Size = new System.Drawing.Size(56, 28);
            this.radioButtonComeBackDepotNo.TabIndex = 1;
            this.radioButtonComeBackDepotNo.Text = "No";
            this.radioButtonComeBackDepotNo.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DarkRed;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1382, 28);
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
            this.instanceToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
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
            // AirportName
            // 
            this.AirportName.HeaderText = "Aiport";
            this.AirportName.Name = "AirportName";
            // 
            // ICAO
            // 
            this.ICAO.HeaderText = "ICAO";
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
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookingNumber,
            this.Origin,
            this.Destination,
            this.MinDeparture,
            this.MaxDeparture,
            this.MinArrival,
            this.MaxArrival});
            this.dataGridView4.Location = new System.Drawing.Point(11, 32);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowHeadersVisible = false;
            this.dataGridView4.RowTemplate.Height = 24;
            this.dataGridView4.Size = new System.Drawing.Size(1070, 213);
            this.dataGridView4.TabIndex = 0;
            // 
            // BookingNumber
            // 
            this.BookingNumber.HeaderText = "PNR";
            this.BookingNumber.Name = "BookingNumber";
            // 
            // Origin
            // 
            this.Origin.HeaderText = "Origin";
            this.Origin.Name = "Origin";
            // 
            // Destination
            // 
            this.Destination.HeaderText = "Destination";
            this.Destination.Name = "Destination";
            // 
            // MinDeparture
            // 
            this.MinDeparture.HeaderText = "Minimum Departure Time";
            this.MinDeparture.Name = "MinDeparture";
            this.MinDeparture.Width = 170;
            // 
            // MaxDeparture
            // 
            this.MaxDeparture.HeaderText = "Maximum Departure Time";
            this.MaxDeparture.Name = "MaxDeparture";
            this.MaxDeparture.Width = 170;
            // 
            // MinArrival
            // 
            this.MinArrival.HeaderText = "Minimum Arrival Time";
            this.MinArrival.Name = "MinArrival";
            this.MinArrival.Width = 150;
            // 
            // MaxArrival
            // 
            this.MaxArrival.HeaderText = "Maximum Arrival Time";
            this.MaxArrival.Name = "MaxArrival";
            this.MaxArrival.Width = 150;
            // 
            // dataGridView5
            // 
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Passenger,
            this.Sex,
            this.Class});
            this.dataGridView5.Location = new System.Drawing.Point(11, 327);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.RowHeadersVisible = false;
            this.dataGridView5.RowTemplate.Height = 24;
            this.dataGridView5.Size = new System.Drawing.Size(1070, 189);
            this.dataGridView5.TabIndex = 1;
            // 
            // AirplaneModel
            // 
            this.AirplaneModel.HeaderText = "Model";
            this.AirplaneModel.Name = "AirplaneModel";
            // 
            // Prefix
            // 
            this.Prefix.HeaderText = "Prefix";
            this.Prefix.Name = "Prefix";
            // 
            // Range
            // 
            this.Range.HeaderText = "Range (Km)";
            this.Range.Name = "Range";
            this.Range.Width = 140;
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Weight (Kg)";
            this.Weight.Name = "Weight";
            this.Weight.Width = 140;
            // 
            // MaxWeightTakeOff
            // 
            this.MaxWeightTakeOff.HeaderText = "Max Weight Take Off (Kg)";
            this.MaxWeightTakeOff.Name = "MaxWeightTakeOff";
            this.MaxWeightTakeOff.Width = 180;
            // 
            // Capacity
            // 
            this.Capacity.HeaderText = "Capacity";
            this.Capacity.Name = "Capacity";
            // 
            // Airplane
            // 
            this.Airplane.HeaderText = "Airplane";
            this.Airplane.Name = "Airplane";
            this.Airplane.Width = 240;
            // 
            // Fuel
            // 
            this.Fuel.HeaderText = "Fuel";
            this.Fuel.Name = "Fuel";
            this.Fuel.Width = 150;
            // 
            // Currency
            // 
            this.Currency.HeaderText = "Currency";
            this.Currency.Name = "Currency";
            this.Currency.Width = 180;
            // 
            // PricePerLitre
            // 
            this.PricePerLitre.HeaderText = "Price Per Litre";
            this.PricePerLitre.Name = "PricePerLitre";
            this.PricePerLitre.Width = 200;
            // 
            // Passenger
            // 
            this.Passenger.HeaderText = "Passenger";
            this.Passenger.Name = "Passenger";
            this.Passenger.Width = 270;
            // 
            // Sex
            // 
            this.Sex.HeaderText = "Sex";
            this.Sex.Name = "Sex";
            this.Sex.Width = 260;
            // 
            // Class
            // 
            this.Class.HeaderText = "Class";
            this.Class.Name = "Class";
            this.Class.Width = 260;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1382, 953);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1400, 1000);
            this.MinimumSize = new System.Drawing.Size(1400, 1000);
            this.Name = "MainForm";
            this.Text = "Unimore - Optimizer 1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl.ResumeLayout(false);
            this.tabInstances.ResumeLayout(false);
            this.tabInstances.PerformLayout();
            this.panelInstanceDetails.ResumeLayout(false);
            this.panelInstanceDetails.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabInput.ResumeLayout(false);
            this.tabControlInputTables.ResumeLayout(false);
            this.tabPageAirplanes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabPageAirports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPageRequests.ResumeLayout(false);
            this.tabPageFuel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabParameters.ResumeLayout(false);
            this.panelParamSelectInstance.ResumeLayout(false);
            this.panelParamSelectInstance.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel6.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private System.Windows.Forms.TabControl tabControl2;
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
        private System.Windows.Forms.TabControl tabControlInputTables;
        private System.Windows.Forms.TabPage tabPageAirplanes;
        private System.Windows.Forms.TabPage tabPageAirports;
        private TabPage tabPageRequests;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn AirplaneName;
        private TabPage tabPageFuel;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn AirportName;
        private DataGridViewTextBoxColumn ICAO;
        private DataGridViewTextBoxColumn Latitude;
        private DataGridViewTextBoxColumn Longintude;
        private DataGridViewTextBoxColumn Elevation;
        private DataGridViewTextBoxColumn RunwayLength;
        private DataGridViewTextBoxColumn Region;
        private DataGridViewTextBoxColumn MTOW_APE3;
        private DataGridViewTextBoxColumn MTOW_PC12;
        private DataGridView dataGridView4;
        private DataGridView dataGridView5;
        private DataGridViewTextBoxColumn BookingNumber;
        private DataGridViewTextBoxColumn Origin;
        private DataGridViewTextBoxColumn Destination;
        private DataGridViewTextBoxColumn MinDeparture;
        private DataGridViewTextBoxColumn MaxDeparture;
        private DataGridViewTextBoxColumn MinArrival;
        private DataGridViewTextBoxColumn MaxArrival;
        private DataGridViewTextBoxColumn AirplaneModel;
        private DataGridViewTextBoxColumn Prefix;
        private DataGridViewTextBoxColumn Range;
        private DataGridViewTextBoxColumn Weight;
        private DataGridViewTextBoxColumn MaxWeightTakeOff;
        private DataGridViewTextBoxColumn Capacity;
        private DataGridViewTextBoxColumn Airplane;
        private DataGridViewTextBoxColumn Fuel;
        private DataGridViewTextBoxColumn Currency;
        private DataGridViewTextBoxColumn PricePerLitre;
        private DataGridViewTextBoxColumn Passenger;
        private DataGridViewTextBoxColumn Sex;
        private DataGridViewTextBoxColumn Class;
    }
}

