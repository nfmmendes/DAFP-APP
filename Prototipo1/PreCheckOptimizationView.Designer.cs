namespace Prototipo1
{
    partial class PreCheckOptimizationView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewAlerts = new System.Windows.Forms.DataGridView();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Table = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonExport = new System.Windows.Forms.Button();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.radioButtonErrors = new System.Windows.Forms.RadioButton();
            this.radioButtonWarnings = new System.Windows.Forms.RadioButton();
            this.buttonContinue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlerts)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAlerts
            // 
            this.dataGridViewAlerts.AllowUserToAddRows = false;
            this.dataGridViewAlerts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAlerts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewAlerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAlerts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Type,
            this.Message,
            this.Table});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAlerts.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewAlerts.Location = new System.Drawing.Point(12, 72);
            this.dataGridViewAlerts.Name = "dataGridViewAlerts";
            this.dataGridViewAlerts.RowHeadersVisible = false;
            this.dataGridViewAlerts.RowTemplate.Height = 24;
            this.dataGridViewAlerts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAlerts.Size = new System.Drawing.Size(977, 309);
            this.dataGridViewAlerts.TabIndex = 0;
            // 
            // Type
            // 
            this.Type.FillWeight = 15.99303F;
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Message
            // 
            this.Message.FillWeight = 70.02032F;
            this.Message.HeaderText = "Message";
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            // 
            // Table
            // 
            this.Table.FillWeight = 15.98666F;
            this.Table.HeaderText = "Table";
            this.Table.Name = "Table";
            this.Table.ReadOnly = true;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(819, 399);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(170, 46);
            this.buttonExport.TabIndex = 1;
            this.buttonExport.Text = "Export Report";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Checked = true;
            this.radioButtonAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonAll.Location = new System.Drawing.Point(658, 25);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(52, 28);
            this.radioButtonAll.TabIndex = 2;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "All";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            this.radioButtonAll.CheckedChanged += new System.EventHandler(this.radioButtonAll_CheckedChanged);
            // 
            // radioButtonErrors
            // 
            this.radioButtonErrors.AutoSize = true;
            this.radioButtonErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonErrors.Location = new System.Drawing.Point(767, 25);
            this.radioButtonErrors.Name = "radioButtonErrors";
            this.radioButtonErrors.Size = new System.Drawing.Size(82, 28);
            this.radioButtonErrors.TabIndex = 3;
            this.radioButtonErrors.Text = "Errors";
            this.radioButtonErrors.UseVisualStyleBackColor = true;
            this.radioButtonErrors.CheckedChanged += new System.EventHandler(this.radioButtonErrors_CheckedChanged);
            // 
            // radioButtonWarnings
            // 
            this.radioButtonWarnings.AutoSize = true;
            this.radioButtonWarnings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.radioButtonWarnings.Location = new System.Drawing.Point(878, 25);
            this.radioButtonWarnings.Name = "radioButtonWarnings";
            this.radioButtonWarnings.Size = new System.Drawing.Size(111, 28);
            this.radioButtonWarnings.TabIndex = 4;
            this.radioButtonWarnings.Text = "Warnings";
            this.radioButtonWarnings.UseVisualStyleBackColor = true;
            this.radioButtonWarnings.CheckedChanged += new System.EventHandler(this.radioButtonWarnings_CheckedChanged);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Location = new System.Drawing.Point(12, 399);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(170, 46);
            this.buttonContinue.TabIndex = 5;
            this.buttonContinue.Text = "Continue Optimization";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // PreCheckOptimizationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 457);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.radioButtonWarnings);
            this.Controls.Add(this.radioButtonErrors);
            this.Controls.Add(this.radioButtonAll);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.dataGridViewAlerts);
            this.Name = "PreCheckOptimizationView";
            this.Text = "Optimization alerts";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlerts)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAlerts;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn Table;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.RadioButton radioButtonErrors;
        private System.Windows.Forms.RadioButton radioButtonWarnings;
        private System.Windows.Forms.Button buttonContinue;
    }
}