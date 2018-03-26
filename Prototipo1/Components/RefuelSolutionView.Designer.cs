namespace Prototipo1.Components
{
    partial class RefuelSolutionView
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
            this.dataGridViewSolutionRefuel = new System.Windows.Forms.DataGridView();
            this.AirplanePrefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AirportRefuel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefuelHour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FuelType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Volume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonDeleteFuelPrice = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAddFuel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSolutionRefuel)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewSolutionRefuel
            // 
            this.dataGridViewSolutionRefuel.AllowUserToAddRows = false;
            this.dataGridViewSolutionRefuel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewSolutionRefuel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSolutionRefuel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AirplanePrefix,
            this.AirportRefuel,
            this.RefuelHour,
            this.FuelType,
            this.Volume,
            this.UnitPrice,
            this.Total});
            this.dataGridViewSolutionRefuel.Location = new System.Drawing.Point(10, 5);
            this.dataGridViewSolutionRefuel.Name = "dataGridViewSolutionRefuel";
            this.dataGridViewSolutionRefuel.RowHeadersVisible = false;
            this.dataGridViewSolutionRefuel.RowTemplate.Height = 24;
            this.dataGridViewSolutionRefuel.Size = new System.Drawing.Size(1000, 450);
            this.dataGridViewSolutionRefuel.TabIndex = 1;
            // 
            // AirplanePrefix
            // 
            this.AirplanePrefix.HeaderText = "Airplanes";
            this.AirplanePrefix.Name = "AirplanePrefix";
            // 
            // AirportRefuel
            // 
            this.AirportRefuel.HeaderText = "Airport";
            this.AirportRefuel.Name = "AirportRefuel";
            // 
            // RefuelHour
            // 
            this.RefuelHour.HeaderText = "Hour";
            this.RefuelHour.Name = "RefuelHour";
            // 
            // FuelType
            // 
            this.FuelType.HeaderText = "Fuel Type";
            this.FuelType.Name = "FuelType";
            // 
            // Volume
            // 
            this.Volume.HeaderText = "Volume";
            this.Volume.Name = "Volume";
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "Price";
            this.UnitPrice.Name = "UnitPrice";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // buttonDeleteFuelPrice
            // 
            this.buttonDeleteFuelPrice.Location = new System.Drawing.Point(1035, 105);
            this.buttonDeleteFuelPrice.Name = "buttonDeleteFuelPrice";
            this.buttonDeleteFuelPrice.Size = new System.Drawing.Size(91, 34);
            this.buttonDeleteFuelPrice.TabIndex = 14;
            this.buttonDeleteFuelPrice.Text = "Delete";
            this.buttonDeleteFuelPrice.UseVisualStyleBackColor = true;
            this.buttonDeleteFuelPrice.Click += new System.EventHandler(this.buttonDeleteFuelPrice_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(1035, 55);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(91, 34);
            this.buttonEdit.TabIndex = 13;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAddFuel
            // 
            this.buttonAddFuel.Location = new System.Drawing.Point(1035, 5);
            this.buttonAddFuel.Name = "buttonAddFuel";
            this.buttonAddFuel.Size = new System.Drawing.Size(91, 34);
            this.buttonAddFuel.TabIndex = 12;
            this.buttonAddFuel.Text = "Add";
            this.buttonAddFuel.UseVisualStyleBackColor = true;
            this.buttonAddFuel.Click += new System.EventHandler(this.buttonAddFuel_Click);
            // 
            // RefuelSolutionView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.buttonDeleteFuelPrice);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAddFuel);
            this.Controls.Add(this.dataGridViewSolutionRefuel);
            this.Name = "RefuelSolutionView";
            this.Size = new System.Drawing.Size(1180, 530);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSolutionRefuel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSolutionRefuel;
        private System.Windows.Forms.DataGridViewTextBoxColumn AirplanePrefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn AirportRefuel;
        private System.Windows.Forms.DataGridViewTextBoxColumn RefuelHour;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuelType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Volume;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.Button buttonDeleteFuelPrice;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAddFuel;
    }
}
