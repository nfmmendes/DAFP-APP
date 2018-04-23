namespace Prototipo1.Components
{
    partial class RequestSolutionView
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
            this.dataGridViewRequestSolutionDetails = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassengerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlightAirplane = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewRequestsResult = new System.Windows.Forms.DataGridView();
            this.SolutionRequestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.solutionRequestPNR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SolutionRequestOrigin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SolutionReportDestination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SolutionRequestMinDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SolutionRequestMaxDep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SolutionRequestMinArr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SolutionRequestMaxArr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequestSolutionDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequestsResult)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewRequestSolutionDetails
            // 
            this.dataGridViewRequestSolutionDetails.AllowUserToAddRows = false;
            this.dataGridViewRequestSolutionDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequestSolutionDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.PassengerName,
            this.FlightAirplane,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dataGridViewRequestSolutionDetails.Location = new System.Drawing.Point(10, 295);
            this.dataGridViewRequestSolutionDetails.Name = "dataGridViewRequestSolutionDetails";
            this.dataGridViewRequestSolutionDetails.RowHeadersVisible = false;
            this.dataGridViewRequestSolutionDetails.RowTemplate.Height = 24;
            this.dataGridViewRequestSolutionDetails.Size = new System.Drawing.Size(1000, 215);
            this.dataGridViewRequestSolutionDetails.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Route ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // PassengerName
            // 
            this.PassengerName.HeaderText = "Passenger";
            this.PassengerName.Name = "PassengerName";
            this.PassengerName.ReadOnly = true;
            this.PassengerName.Width = 150;
            // 
            // FlightAirplane
            // 
            this.FlightAirplane.HeaderText = "Airplanes";
            this.FlightAirplane.Name = "FlightAirplane";
            this.FlightAirplane.ReadOnly = true;
            this.FlightAirplane.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Origin";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Departure";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Destination";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Arrival";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 140;
            // 
            // dataGridViewRequestsResult
            // 
            this.dataGridViewRequestsResult.AllowUserToAddRows = false;
            this.dataGridViewRequestsResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRequestsResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequestsResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SolutionRequestId,
            this.solutionRequestPNR,
            this.SolutionRequestOrigin,
            this.SolutionReportDestination,
            this.SolutionRequestMinDep,
            this.SolutionRequestMaxDep,
            this.SolutionRequestMinArr,
            this.SolutionRequestMaxArr});
            this.dataGridViewRequestsResult.Location = new System.Drawing.Point(10, 5);
            this.dataGridViewRequestsResult.Name = "dataGridViewRequestsResult";
            this.dataGridViewRequestsResult.RowHeadersVisible = false;
            this.dataGridViewRequestsResult.RowTemplate.Height = 24;
            this.dataGridViewRequestsResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRequestsResult.Size = new System.Drawing.Size(1000, 220);
            this.dataGridViewRequestsResult.TabIndex = 7;
            this.dataGridViewRequestsResult.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRequestsResult_RowEnter);
            // 
            // SolutionRequestId
            // 
            this.SolutionRequestId.HeaderText = "Id";
            this.SolutionRequestId.Name = "SolutionRequestId";
            this.SolutionRequestId.ReadOnly = true;
            this.SolutionRequestId.Visible = false;
            // 
            // solutionRequestPNR
            // 
            this.solutionRequestPNR.HeaderText = "PNR";
            this.solutionRequestPNR.Name = "solutionRequestPNR";
            this.solutionRequestPNR.ReadOnly = true;
            // 
            // SolutionRequestOrigin
            // 
            this.SolutionRequestOrigin.HeaderText = "Origin";
            this.SolutionRequestOrigin.Name = "SolutionRequestOrigin";
            this.SolutionRequestOrigin.ReadOnly = true;
            // 
            // SolutionReportDestination
            // 
            this.SolutionReportDestination.HeaderText = "Destination";
            this.SolutionReportDestination.Name = "SolutionReportDestination";
            this.SolutionReportDestination.ReadOnly = true;
            // 
            // SolutionRequestMinDep
            // 
            this.SolutionRequestMinDep.HeaderText = "Minimum Departure Time";
            this.SolutionRequestMinDep.Name = "SolutionRequestMinDep";
            this.SolutionRequestMinDep.ReadOnly = true;
            // 
            // SolutionRequestMaxDep
            // 
            this.SolutionRequestMaxDep.HeaderText = "Maximum Departure Time";
            this.SolutionRequestMaxDep.Name = "SolutionRequestMaxDep";
            this.SolutionRequestMaxDep.ReadOnly = true;
            // 
            // SolutionRequestMinArr
            // 
            this.SolutionRequestMinArr.HeaderText = "Minimum Arrival Time";
            this.SolutionRequestMinArr.Name = "SolutionRequestMinArr";
            this.SolutionRequestMinArr.ReadOnly = true;
            // 
            // SolutionRequestMaxArr
            // 
            this.SolutionRequestMaxArr.HeaderText = "Maximum Arrival Time";
            this.SolutionRequestMaxArr.Name = "SolutionRequestMaxArr";
            this.SolutionRequestMaxArr.ReadOnly = true;
            // 
            // RequestSolutionView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.dataGridViewRequestSolutionDetails);
            this.Controls.Add(this.dataGridViewRequestsResult);
            this.Name = "RequestSolutionView";
            this.Size = new System.Drawing.Size(1180, 530);
            this.Load += new System.EventHandler(this.RequestSolutionView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequestSolutionDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequestsResult)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewRequestSolutionDetails;
        private System.Windows.Forms.DataGridView dataGridViewRequestsResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassengerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FlightAirplane;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn SolutionRequestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn solutionRequestPNR;
        private System.Windows.Forms.DataGridViewTextBoxColumn SolutionRequestOrigin;
        private System.Windows.Forms.DataGridViewTextBoxColumn SolutionReportDestination;
        private System.Windows.Forms.DataGridViewTextBoxColumn SolutionRequestMinDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn SolutionRequestMaxDep;
        private System.Windows.Forms.DataGridViewTextBoxColumn SolutionRequestMinArr;
        private System.Windows.Forms.DataGridViewTextBoxColumn SolutionRequestMaxArr;
    }
}
