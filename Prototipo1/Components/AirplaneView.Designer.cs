namespace Prototipo1.Components
{
    partial class AirplaneView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonDeleteAirplane = new System.Windows.Forms.Button();
            this.buttonEditAirplane = new System.Windows.Forms.Button();
            this.buttonAddAirplane = new System.Windows.Forms.Button();
            this.buttonDeleteAirplaneSeatType = new System.Windows.Forms.Button();
            this.buttonEditAirplaneSeatType = new System.Windows.Forms.Button();
            this.buttonAddAirplaneSeatType = new System.Windows.Forms.Button();
            this.dataGridViewSeatTypes = new System.Windows.Forms.DataGridView();
            this.dataGridViewAirplane = new System.Windows.Forms.DataGridView();
            this.AirplaneId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AirplaneModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Range = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Weight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxWeightTakeOff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CruiseSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstHourConsumption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondHourFuelConsumption = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxFuel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Capacity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BaseAirport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.SeatTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeatClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxLuggageWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeatTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAirplane)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDeleteAirplane
            // 
            this.buttonDeleteAirplane.Location = new System.Drawing.Point(1035, 105);
            this.buttonDeleteAirplane.Name = "buttonDeleteAirplane";
            this.buttonDeleteAirplane.Size = new System.Drawing.Size(91, 34);
            this.buttonDeleteAirplane.TabIndex = 15;
            this.buttonDeleteAirplane.Text = "Delete";
            this.buttonDeleteAirplane.UseVisualStyleBackColor = true;
            this.buttonDeleteAirplane.Click += new System.EventHandler(this.buttonDeleteAirplane_Click);
            // 
            // buttonEditAirplane
            // 
            this.buttonEditAirplane.Location = new System.Drawing.Point(1035, 55);
            this.buttonEditAirplane.Name = "buttonEditAirplane";
            this.buttonEditAirplane.Size = new System.Drawing.Size(91, 34);
            this.buttonEditAirplane.TabIndex = 14;
            this.buttonEditAirplane.Text = "Edit";
            this.buttonEditAirplane.UseVisualStyleBackColor = true;
            this.buttonEditAirplane.Click += new System.EventHandler(this.buttonEditAirplane_Click);
            // 
            // buttonAddAirplane
            // 
            this.buttonAddAirplane.Location = new System.Drawing.Point(1035, 5);
            this.buttonAddAirplane.Name = "buttonAddAirplane";
            this.buttonAddAirplane.Size = new System.Drawing.Size(91, 34);
            this.buttonAddAirplane.TabIndex = 13;
            this.buttonAddAirplane.Text = "Add";
            this.buttonAddAirplane.UseVisualStyleBackColor = true;
            this.buttonAddAirplane.Click += new System.EventHandler(this.buttonAddAirplane_Click);
            // 
            // buttonDeleteAirplaneSeatType
            // 
            this.buttonDeleteAirplaneSeatType.Location = new System.Drawing.Point(1035, 395);
            this.buttonDeleteAirplaneSeatType.Name = "buttonDeleteAirplaneSeatType";
            this.buttonDeleteAirplaneSeatType.Size = new System.Drawing.Size(91, 34);
            this.buttonDeleteAirplaneSeatType.TabIndex = 12;
            this.buttonDeleteAirplaneSeatType.Text = "Delete";
            this.buttonDeleteAirplaneSeatType.UseVisualStyleBackColor = true;
            this.buttonDeleteAirplaneSeatType.Click += new System.EventHandler(this.buttonDeleteAirplaneSeatType_Click);
            // 
            // buttonEditAirplaneSeatType
            // 
            this.buttonEditAirplaneSeatType.Location = new System.Drawing.Point(1035, 345);
            this.buttonEditAirplaneSeatType.Name = "buttonEditAirplaneSeatType";
            this.buttonEditAirplaneSeatType.Size = new System.Drawing.Size(91, 34);
            this.buttonEditAirplaneSeatType.TabIndex = 11;
            this.buttonEditAirplaneSeatType.Text = "Edit";
            this.buttonEditAirplaneSeatType.UseVisualStyleBackColor = true;
            this.buttonEditAirplaneSeatType.Click += new System.EventHandler(this.buttonEditAirplaneSeatType_Click);
            // 
            // buttonAddAirplaneSeatType
            // 
            this.buttonAddAirplaneSeatType.Location = new System.Drawing.Point(1035, 295);
            this.buttonAddAirplaneSeatType.Name = "buttonAddAirplaneSeatType";
            this.buttonAddAirplaneSeatType.Size = new System.Drawing.Size(91, 34);
            this.buttonAddAirplaneSeatType.TabIndex = 10;
            this.buttonAddAirplaneSeatType.Text = "Add";
            this.buttonAddAirplaneSeatType.UseVisualStyleBackColor = true;
            this.buttonAddAirplaneSeatType.Click += new System.EventHandler(this.buttonAddAirplaneSeatType_Click);
            // 
            // dataGridViewSeatTypes
            // 
            this.dataGridViewSeatTypes.AllowUserToAddRows = false;
            this.dataGridViewSeatTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSeatTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSeatTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SeatTypeId,
            this.SeatClass,
            this.MaxLuggageWeight});
            this.dataGridViewSeatTypes.Location = new System.Drawing.Point(10, 295);
            this.dataGridViewSeatTypes.Name = "dataGridViewSeatTypes";
            this.dataGridViewSeatTypes.RowHeadersVisible = false;
            this.dataGridViewSeatTypes.RowTemplate.Height = 24;
            this.dataGridViewSeatTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSeatTypes.Size = new System.Drawing.Size(1000, 215);
            this.dataGridViewSeatTypes.TabIndex = 9;
            // 
            // dataGridViewAirplane
            // 
            this.dataGridViewAirplane.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAirplane.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAirplane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAirplane.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AirplaneId,
            this.AirplaneModel,
            this.Prefix,
            this.Range,
            this.Weight,
            this.MaxWeightTakeOff,
            this.CruiseSpeed,
            this.FirstHourConsumption,
            this.SecondHourFuelConsumption,
            this.MaxFuel,
            this.Capacity,
            this.BaseAirport});
            this.dataGridViewAirplane.Location = new System.Drawing.Point(10, 5);
            this.dataGridViewAirplane.Name = "dataGridViewAirplane";
            this.dataGridViewAirplane.RowHeadersVisible = false;
            this.dataGridViewAirplane.RowTemplate.Height = 24;
            this.dataGridViewAirplane.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAirplane.Size = new System.Drawing.Size(1000, 215);
            this.dataGridViewAirplane.TabIndex = 8;
            this.dataGridViewAirplane.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAirplane_RowEnter);
            // 
            // AirplaneId
            // 
            this.AirplaneId.HeaderText = "Id";
            this.AirplaneId.Name = "AirplaneId";
            this.AirplaneId.ReadOnly = true;
            this.AirplaneId.Visible = false;
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
            this.Range.Width = 120;
            // 
            // Weight
            // 
            this.Weight.HeaderText = "Weight (Kg)";
            this.Weight.Name = "Weight";
            this.Weight.Width = 120;
            // 
            // MaxWeightTakeOff
            // 
            this.MaxWeightTakeOff.HeaderText = "Max Weight Take Off (Kg)";
            this.MaxWeightTakeOff.Name = "MaxWeightTakeOff";
            this.MaxWeightTakeOff.Width = 180;
            // 
            // CruiseSpeed
            // 
            this.CruiseSpeed.HeaderText = "Cruise Speed (Knot)";
            this.CruiseSpeed.Name = "CruiseSpeed";
            this.CruiseSpeed.Width = 150;
            // 
            // FirstHourConsumption
            // 
            this.FirstHourConsumption.HeaderText = "1º Hour Fuel Consumption";
            this.FirstHourConsumption.Name = "FirstHourConsumption";
            this.FirstHourConsumption.Width = 150;
            // 
            // SecondHourFuelConsumption
            // 
            this.SecondHourFuelConsumption.HeaderText = "2º Hour Fuel Consumption";
            this.SecondHourFuelConsumption.Name = "SecondHourFuelConsumption";
            this.SecondHourFuelConsumption.Width = 150;
            // 
            // MaxFuel
            // 
            this.MaxFuel.HeaderText = "Max Fuel";
            this.MaxFuel.Name = "MaxFuel";
            // 
            // Capacity
            // 
            this.Capacity.HeaderText = "Capacity";
            this.Capacity.Name = "Capacity";
            this.Capacity.Width = 90;
            // 
            // BaseAirport
            // 
            this.BaseAirport.HeaderText = "Base Airport";
            this.BaseAirport.Name = "BaseAirport";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label1.Location = new System.Drawing.Point(20, 268);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 24);
            this.label1.TabIndex = 16;
            this.label1.Text = "Available Classes";
            // 
            // SeatTypeId
            // 
            this.SeatTypeId.HeaderText = "Id";
            this.SeatTypeId.Name = "SeatTypeId";
            this.SeatTypeId.ReadOnly = true;
            this.SeatTypeId.Visible = false;
            // 
            // SeatClass
            // 
            this.SeatClass.HeaderText = "Class";
            this.SeatClass.Name = "SeatClass";
            // 
            // MaxLuggageWeight
            // 
            this.MaxLuggageWeight.HeaderText = "Max Luggage Weight (Kg)";
            this.MaxLuggageWeight.Name = "MaxLuggageWeight";
            // 
            // AirplaneView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDeleteAirplane);
            this.Controls.Add(this.buttonEditAirplane);
            this.Controls.Add(this.buttonAddAirplane);
            this.Controls.Add(this.buttonDeleteAirplaneSeatType);
            this.Controls.Add(this.buttonEditAirplaneSeatType);
            this.Controls.Add(this.buttonAddAirplaneSeatType);
            this.Controls.Add(this.dataGridViewSeatTypes);
            this.Controls.Add(this.dataGridViewAirplane);
            this.Name = "AirplaneView";
            this.Size = new System.Drawing.Size(1180, 530);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSeatTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAirplane)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDeleteAirplane;
        private System.Windows.Forms.Button buttonEditAirplane;
        private System.Windows.Forms.Button buttonAddAirplane;
        private System.Windows.Forms.Button buttonDeleteAirplaneSeatType;
        private System.Windows.Forms.Button buttonEditAirplaneSeatType;
        private System.Windows.Forms.Button buttonAddAirplaneSeatType;
        private System.Windows.Forms.DataGridView dataGridViewSeatTypes;
        private System.Windows.Forms.DataGridView dataGridViewAirplane;
        private System.Windows.Forms.DataGridViewTextBoxColumn AirplaneId;
        private System.Windows.Forms.DataGridViewTextBoxColumn AirplaneModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn Range;
        private System.Windows.Forms.DataGridViewTextBoxColumn Weight;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxWeightTakeOff;
        private System.Windows.Forms.DataGridViewTextBoxColumn CruiseSpeed;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstHourConsumption;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondHourFuelConsumption;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxFuel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Capacity;
        private System.Windows.Forms.DataGridViewTextBoxColumn BaseAirport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeatTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeatClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxLuggageWeight;
    }
}
