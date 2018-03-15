namespace Prototipo1.Components
{
    partial class AirportView
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
            this.dataGridViewAirport = new System.Windows.Forms.DataGridView();
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
            this.buttonDeleteAirport = new System.Windows.Forms.Button();
            this.buttonEditAirport = new System.Windows.Forms.Button();
            this.buttonAddAirport = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAirport)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAirport
            // 
            this.dataGridViewAirport.AllowUserToAddRows = false;
            this.dataGridViewAirport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAirport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AiportAid,
            this.AirportName,
            this.ICAO,
            this.Latitude,
            this.Longintude,
            this.Elevation,
            this.RunwayLength,
            this.Region,
            this.MTOW_APE3,
            this.MTOW_PC12,
            this.LandingCost,
            this.GroundTime});
            this.dataGridViewAirport.Location = new System.Drawing.Point(11, 32);
            this.dataGridViewAirport.Name = "dataGridViewAirport";
            this.dataGridViewAirport.RowHeadersVisible = false;
            this.dataGridViewAirport.RowTemplate.Height = 24;
            this.dataGridViewAirport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAirport.Size = new System.Drawing.Size(1013, 419);
            this.dataGridViewAirport.TabIndex = 0;
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
            // buttonDeleteAirport
            // 
            this.buttonDeleteAirport.Location = new System.Drawing.Point(712, 478);
            this.buttonDeleteAirport.Name = "buttonDeleteAirport";
            this.buttonDeleteAirport.Size = new System.Drawing.Size(91, 34);
            this.buttonDeleteAirport.TabIndex = 7;
            this.buttonDeleteAirport.Text = "Delete";
            this.buttonDeleteAirport.UseVisualStyleBackColor = true;
            this.buttonDeleteAirport.Click += new System.EventHandler(this.buttonDeleteAirport_Click);
            // 
            // buttonEditAirport
            // 
            this.buttonEditAirport.Location = new System.Drawing.Point(479, 478);
            this.buttonEditAirport.Name = "buttonEditAirport";
            this.buttonEditAirport.Size = new System.Drawing.Size(91, 34);
            this.buttonEditAirport.TabIndex = 6;
            this.buttonEditAirport.Text = "Edit";
            this.buttonEditAirport.UseVisualStyleBackColor = true;
            this.buttonEditAirport.Click += new System.EventHandler(this.buttonEditAirport_Click);
            // 
            // buttonAddAirport
            // 
            this.buttonAddAirport.Location = new System.Drawing.Point(225, 478);
            this.buttonAddAirport.Name = "buttonAddAirport";
            this.buttonAddAirport.Size = new System.Drawing.Size(91, 34);
            this.buttonAddAirport.TabIndex = 5;
            this.buttonAddAirport.Text = "Add";
            this.buttonAddAirport.UseVisualStyleBackColor = true;
            this.buttonAddAirport.Click += new System.EventHandler(this.buttonAddAirport_Click);
            // 
            // AirportView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.buttonDeleteAirport);
            this.Controls.Add(this.buttonEditAirport);
            this.Controls.Add(this.buttonAddAirport);
            this.Controls.Add(this.dataGridViewAirport);
            this.Name = "AirportView";
            this.Size = new System.Drawing.Size(1119, 526);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAirport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAirport;
        private System.Windows.Forms.DataGridViewTextBoxColumn AiportAid;
        private System.Windows.Forms.DataGridViewTextBoxColumn AirportName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ICAO;
        private System.Windows.Forms.DataGridViewTextBoxColumn Latitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longintude;
        private System.Windows.Forms.DataGridViewTextBoxColumn Elevation;
        private System.Windows.Forms.DataGridViewTextBoxColumn RunwayLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn Region;
        private System.Windows.Forms.DataGridViewTextBoxColumn MTOW_APE3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MTOW_PC12;
        private System.Windows.Forms.DataGridViewTextBoxColumn LandingCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroundTime;
        private System.Windows.Forms.Button buttonDeleteAirport;
        private System.Windows.Forms.Button buttonEditAirport;
        private System.Windows.Forms.Button buttonAddAirport;
    }
}
