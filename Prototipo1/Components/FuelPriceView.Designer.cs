namespace Prototipo1.Components
{
    partial class FuelPriceView
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
            this.buttonDeleteFuelPrice = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAddFuel = new System.Windows.Forms.Button();
            this.dataGridViewFuel = new System.Windows.Forms.DataGridView();
            this.IdFuel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Airport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fuel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PricePerLitre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFuel)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDeleteFuelPrice
            // 
            this.buttonDeleteFuelPrice.Location = new System.Drawing.Point(704, 291);
            this.buttonDeleteFuelPrice.Name = "buttonDeleteFuelPrice";
            this.buttonDeleteFuelPrice.Size = new System.Drawing.Size(91, 34);
            this.buttonDeleteFuelPrice.TabIndex = 11;
            this.buttonDeleteFuelPrice.Text = "Delete";
            this.buttonDeleteFuelPrice.UseVisualStyleBackColor = true;
            this.buttonDeleteFuelPrice.Click += new System.EventHandler(this.buttonDeleteFuelPrice_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(473, 291);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(91, 34);
            this.buttonEdit.TabIndex = 10;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEditFuel_Click);
            // 
            // buttonAddFuel
            // 
            this.buttonAddFuel.Location = new System.Drawing.Point(217, 291);
            this.buttonAddFuel.Name = "buttonAddFuel";
            this.buttonAddFuel.Size = new System.Drawing.Size(91, 34);
            this.buttonAddFuel.TabIndex = 9;
            this.buttonAddFuel.Text = "Add";
            this.buttonAddFuel.UseVisualStyleBackColor = true;
            // 
            // dataGridViewFuel
            // 
            this.dataGridViewFuel.AllowUserToAddRows = false;
            this.dataGridViewFuel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFuel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdFuel,
            this.Airport,
            this.Fuel,
            this.Currency,
            this.PricePerLitre});
            this.dataGridViewFuel.Location = new System.Drawing.Point(14, 32);
            this.dataGridViewFuel.Name = "dataGridViewFuel";
            this.dataGridViewFuel.RowHeadersVisible = false;
            this.dataGridViewFuel.RowTemplate.Height = 24;
            this.dataGridViewFuel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFuel.Size = new System.Drawing.Size(1008, 223);
            this.dataGridViewFuel.TabIndex = 8;
            // 
            // IdFuel
            // 
            this.IdFuel.HeaderText = "Id";
            this.IdFuel.Name = "IdFuel";
            this.IdFuel.ReadOnly = true;
            this.IdFuel.Visible = false;
            // 
            // Airport
            // 
            this.Airport.HeaderText = "Airport";
            this.Airport.Name = "Airport";
            this.Airport.Width = 270;
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
            // FuelPriceView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.buttonDeleteFuelPrice);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAddFuel);
            this.Controls.Add(this.dataGridViewFuel);
            this.Name = "FuelPriceView";
            this.Size = new System.Drawing.Size(1048, 509);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFuel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDeleteFuelPrice;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAddFuel;
        private System.Windows.Forms.DataGridView dataGridViewFuel;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFuel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Airport;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fuel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn PricePerLitre;
    }
}
