namespace Prototipo1.Components
{
    partial class RequestsView
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
            this.buttonDeletePassenger = new System.Windows.Forms.Button();
            this.buttonEditPassenger = new System.Windows.Forms.Button();
            this.buttonAddPassenger = new System.Windows.Forms.Button();
            this.buttonRemoveRequest = new System.Windows.Forms.Button();
            this.buttonEditRequest = new System.Windows.Forms.Button();
            this.buttonAddRequest = new System.Windows.Forms.Button();
            this.dataGridViewPassenger = new System.Windows.Forms.DataGridView();
            this.dataGridViewRequest = new System.Windows.Forms.DataGridView();
            this.RequestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookingNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Origin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Destination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinDeparture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxDeparture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MinArrival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxArrival = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPassenger = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Passenger = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsKid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPassenger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequest)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDeletePassenger
            // 
            this.buttonDeletePassenger.Location = new System.Drawing.Point(1035, 395);
            this.buttonDeletePassenger.Name = "buttonDeletePassenger";
            this.buttonDeletePassenger.Size = new System.Drawing.Size(91, 34);
            this.buttonDeletePassenger.TabIndex = 21;
            this.buttonDeletePassenger.Text = "Delete";
            this.buttonDeletePassenger.UseVisualStyleBackColor = true;
            this.buttonDeletePassenger.Click += new System.EventHandler(this.buttonDeletePassenger_Click);
            // 
            // buttonEditPassenger
            // 
            this.buttonEditPassenger.Location = new System.Drawing.Point(1035, 345);
            this.buttonEditPassenger.Name = "buttonEditPassenger";
            this.buttonEditPassenger.Size = new System.Drawing.Size(91, 34);
            this.buttonEditPassenger.TabIndex = 20;
            this.buttonEditPassenger.Text = "Edit";
            this.buttonEditPassenger.UseVisualStyleBackColor = true;
            this.buttonEditPassenger.Click += new System.EventHandler(this.buttonEditPassenger_Click);
            // 
            // buttonAddPassenger
            // 
            this.buttonAddPassenger.Location = new System.Drawing.Point(1035, 295);
            this.buttonAddPassenger.Name = "buttonAddPassenger";
            this.buttonAddPassenger.Size = new System.Drawing.Size(91, 34);
            this.buttonAddPassenger.TabIndex = 19;
            this.buttonAddPassenger.Text = "Add";
            this.buttonAddPassenger.UseVisualStyleBackColor = true;
            this.buttonAddPassenger.Click += new System.EventHandler(this.buttonAddPassenger_Click);
            // 
            // buttonRemoveRequest
            // 
            this.buttonRemoveRequest.Location = new System.Drawing.Point(1035, 105);
            this.buttonRemoveRequest.Name = "buttonRemoveRequest";
            this.buttonRemoveRequest.Size = new System.Drawing.Size(91, 34);
            this.buttonRemoveRequest.TabIndex = 18;
            this.buttonRemoveRequest.Text = "Delete";
            this.buttonRemoveRequest.UseVisualStyleBackColor = true;
            // 
            // buttonEditRequest
            // 
            this.buttonEditRequest.Location = new System.Drawing.Point(1035, 55);
            this.buttonEditRequest.Name = "buttonEditRequest";
            this.buttonEditRequest.Size = new System.Drawing.Size(91, 34);
            this.buttonEditRequest.TabIndex = 17;
            this.buttonEditRequest.Text = "Edit";
            this.buttonEditRequest.UseVisualStyleBackColor = true;
            this.buttonEditRequest.Click += new System.EventHandler(this.buttonEditRequest_Click);
            // 
            // buttonAddRequest
            // 
            this.buttonAddRequest.Location = new System.Drawing.Point(1035, 5);
            this.buttonAddRequest.Name = "buttonAddRequest";
            this.buttonAddRequest.Size = new System.Drawing.Size(91, 34);
            this.buttonAddRequest.TabIndex = 16;
            this.buttonAddRequest.Text = "Add";
            this.buttonAddRequest.UseVisualStyleBackColor = true;
            // 
            // dataGridViewPassenger
            // 
            this.dataGridViewPassenger.AllowUserToAddRows = false;
            this.dataGridViewPassenger.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPassenger.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPassenger.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdPassenger,
            this.Passenger,
            this.Sex,
            this.IsKid,
            this.Class});
            this.dataGridViewPassenger.Location = new System.Drawing.Point(10, 295);
            this.dataGridViewPassenger.Name = "dataGridViewPassenger";
            this.dataGridViewPassenger.RowHeadersVisible = false;
            this.dataGridViewPassenger.RowTemplate.Height = 24;
            this.dataGridViewPassenger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPassenger.Size = new System.Drawing.Size(1000, 215);
            this.dataGridViewPassenger.TabIndex = 15;
            // 
            // dataGridViewRequest
            // 
            this.dataGridViewRequest.AllowUserToAddRows = false;
            this.dataGridViewRequest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequest.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RequestId,
            this.BookingNumber,
            this.Origin,
            this.Destination,
            this.MinDeparture,
            this.MaxDeparture,
            this.MinArrival,
            this.MaxArrival});
            this.dataGridViewRequest.Location = new System.Drawing.Point(10, 5);
            this.dataGridViewRequest.Name = "dataGridViewRequest";
            this.dataGridViewRequest.RowHeadersVisible = false;
            this.dataGridViewRequest.RowTemplate.Height = 24;
            this.dataGridViewRequest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRequest.Size = new System.Drawing.Size(1000, 220);
            this.dataGridViewRequest.TabIndex = 14;
            this.dataGridViewRequest.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRequest_RowEnter);
            // 
            // RequestId
            // 
            this.RequestId.HeaderText = "Id";
            this.RequestId.Name = "RequestId";
            this.RequestId.ReadOnly = true;
            this.RequestId.Visible = false;
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
            // 
            // MaxDeparture
            // 
            this.MaxDeparture.HeaderText = "Maximum Departure Time";
            this.MaxDeparture.Name = "MaxDeparture";
            // 
            // MinArrival
            // 
            this.MinArrival.HeaderText = "Minimum Arrival Time";
            this.MinArrival.Name = "MinArrival";
            // 
            // MaxArrival
            // 
            this.MaxArrival.HeaderText = "Maximum Arrival Time";
            this.MaxArrival.Name = "MaxArrival";
            // 
            // IdPassenger
            // 
            this.IdPassenger.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IdPassenger.HeaderText = "Id";
            this.IdPassenger.Name = "IdPassenger";
            this.IdPassenger.ReadOnly = true;
            this.IdPassenger.Visible = false;
            // 
            // Passenger
            // 
            this.Passenger.HeaderText = "Passenger";
            this.Passenger.Name = "Passenger";
            // 
            // Sex
            // 
            this.Sex.HeaderText = "Sex";
            this.Sex.Name = "Sex";
            // 
            // IsKid
            // 
            this.IsKid.HeaderText = "Is Children";
            this.IsKid.Name = "IsKid";
            this.IsKid.ReadOnly = true;
            // 
            // Class
            // 
            this.Class.HeaderText = "Class";
            this.Class.Name = "Class";
            // 
            // RequestsView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.buttonDeletePassenger);
            this.Controls.Add(this.buttonEditPassenger);
            this.Controls.Add(this.buttonAddPassenger);
            this.Controls.Add(this.buttonRemoveRequest);
            this.Controls.Add(this.buttonEditRequest);
            this.Controls.Add(this.buttonAddRequest);
            this.Controls.Add(this.dataGridViewPassenger);
            this.Controls.Add(this.dataGridViewRequest);
            this.Name = "RequestsView";
            this.Size = new System.Drawing.Size(1180, 530);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPassenger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequest)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDeletePassenger;
        private System.Windows.Forms.Button buttonEditPassenger;
        private System.Windows.Forms.Button buttonAddPassenger;
        private System.Windows.Forms.Button buttonRemoveRequest;
        private System.Windows.Forms.Button buttonEditRequest;
        private System.Windows.Forms.Button buttonAddRequest;
        private System.Windows.Forms.DataGridView dataGridViewPassenger;
        private System.Windows.Forms.DataGridView dataGridViewRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestId;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookingNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Origin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Destination;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinDeparture;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxDeparture;
        private System.Windows.Forms.DataGridViewTextBoxColumn MinArrival;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxArrival;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPassenger;
        private System.Windows.Forms.DataGridViewTextBoxColumn Passenger;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsKid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class;
    }
}
