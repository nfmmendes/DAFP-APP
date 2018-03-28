namespace Prototipo1.Components
{
    partial class AirplaneUseSolutionView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.comboBoxAirplaneSolution = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoutePassagers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoute)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRoutePassagers
            // 
            this.dataGridViewRoutePassagers.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRoutePassagers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewRoutePassagers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRoutePassagers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StretchPassenger,
            this.StretchPNR,
            this.StretchSex,
            this.StretchClass});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewRoutePassagers.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewRoutePassagers.Location = new System.Drawing.Point(10, 355);
            this.dataGridViewRoutePassagers.Name = "dataGridViewRoutePassagers";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRoutePassagers.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewRoutePassagers.RowHeadersVisible = false;
            this.dataGridViewRoutePassagers.RowTemplate.Height = 24;
            this.dataGridViewRoutePassagers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRoutePassagers.Size = new System.Drawing.Size(1017, 162);
            this.dataGridViewRoutePassagers.TabIndex = 9;
            
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
            this.dataGridViewRoute.Location = new System.Drawing.Point(10, 101);
            this.dataGridViewRoute.Name = "dataGridViewRoute";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRoute.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewRoute.RowHeadersVisible = false;
            this.dataGridViewRoute.RowTemplate.Height = 24;
            this.dataGridViewRoute.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRoute.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRoute_RowEnter);
            this.dataGridViewRoute.Size = new System.Drawing.Size(1017, 190);
            this.dataGridViewRoute.TabIndex = 8;
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
            // comboBoxAirplaneSolution
            // 
            this.comboBoxAirplaneSolution.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.comboBoxAirplaneSolution.FormattingEnabled = true;
            this.comboBoxAirplaneSolution.Location = new System.Drawing.Point(10, 44);
            this.comboBoxAirplaneSolution.Name = "comboBoxAirplaneSolution";
            this.comboBoxAirplaneSolution.Size = new System.Drawing.Size(220, 30);
            this.comboBoxAirplaneSolution.TabIndex = 7;
            this.comboBoxAirplaneSolution.SelectedIndexChanged += new System.EventHandler(this.comboBoxAirplaneSolution_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label18.Location = new System.Drawing.Point(10, 15);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(89, 24);
            this.label18.TabIndex = 10;
            this.label18.Text = "Airplanes";
            // 
            // AirplaneUseSolutionView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.label18);
            this.Controls.Add(this.dataGridViewRoutePassagers);
            this.Controls.Add(this.dataGridViewRoute);
            this.Controls.Add(this.comboBoxAirplaneSolution);
            this.Name = "AirplaneUseSolutionView";
            this.Size = new System.Drawing.Size(1180, 530);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoutePassagers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRoute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRoutePassagers;
        private System.Windows.Forms.DataGridViewTextBoxColumn StretchPassenger;
        private System.Windows.Forms.DataGridViewTextBoxColumn StretchPNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn StretchSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn StretchClass;
        private System.Windows.Forms.DataGridView dataGridViewRoute;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdAirplaneResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn RouteId;
        private System.Windows.Forms.DataGridViewTextBoxColumn StretchOrigin;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuelOnDeparture;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightOnDeparture;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlightDepartureTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StretchDestination;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuelOnArrival;
        private System.Windows.Forms.DataGridViewTextBoxColumn WeightOnArrival;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlightArrivalTime;
        private System.Windows.Forms.ComboBox comboBoxAirplaneSolution;
        private System.Windows.Forms.Label label18;
    }
}
