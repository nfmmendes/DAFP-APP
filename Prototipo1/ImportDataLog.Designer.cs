namespace Prototipo1
{
    partial class ImportDataLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxInstances = new System.Windows.Forms.ComboBox();
            this.dataGridViewDatetime = new System.Windows.Forms.DataGridView();
            this.ImportTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewDetail = new System.Windows.Forms.DataGridView();
            this.File = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sheet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatetime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label7.Location = new System.Drawing.Point(26, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "Instance";
            // 
            // comboBoxInstances
            // 
            this.comboBoxInstances.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.comboBoxInstances.FormattingEnabled = true;
            this.comboBoxInstances.Location = new System.Drawing.Point(26, 46);
            this.comboBoxInstances.Name = "comboBoxInstances";
            this.comboBoxInstances.Size = new System.Drawing.Size(373, 30);
            this.comboBoxInstances.TabIndex = 13;
            this.comboBoxInstances.SelectedIndexChanged += new System.EventHandler(this.comboBoxInstances_SelectedIndexChanged);
            // 
            // dataGridViewDatetime
            // 
            this.dataGridViewDatetime.AllowUserToAddRows = false;
            this.dataGridViewDatetime.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDatetime.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewDatetime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDatetime.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImportTime});
            this.dataGridViewDatetime.Location = new System.Drawing.Point(26, 95);
            this.dataGridViewDatetime.Name = "dataGridViewDatetime";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDatetime.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewDatetime.RowHeadersVisible = false;
            this.dataGridViewDatetime.RowTemplate.Height = 24;
            this.dataGridViewDatetime.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDatetime.Size = new System.Drawing.Size(1016, 168);
            this.dataGridViewDatetime.TabIndex = 15;
            this.dataGridViewDatetime.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDatetime_CellClick);
            // 
            // ImportTime
            // 
            this.ImportTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ImportTime.HeaderText = "Datetime";
            this.ImportTime.Name = "ImportTime";
            this.ImportTime.ReadOnly = true;
            // 
            // dataGridViewDetail
            // 
            this.dataGridViewDetail.AllowUserToAddRows = false;
            this.dataGridViewDetail.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.File,
            this.Sheet,
            this.RowLine,
            this.Message});
            this.dataGridViewDetail.Location = new System.Drawing.Point(26, 327);
            this.dataGridViewDetail.Name = "dataGridViewDetail";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDetail.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewDetail.RowHeadersVisible = false;
            this.dataGridViewDetail.RowTemplate.Height = 24;
            this.dataGridViewDetail.Size = new System.Drawing.Size(1016, 181);
            this.dataGridViewDetail.TabIndex = 16;
            // 
            // File
            // 
            this.File.HeaderText = "File";
            this.File.Name = "File";
            this.File.ReadOnly = true;
            this.File.Width = 253;
            // 
            // Sheet
            // 
            this.Sheet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Sheet.HeaderText = "Sheet";
            this.Sheet.Name = "Sheet";
            this.Sheet.ReadOnly = true;
            // 
            // RowLine
            // 
            this.RowLine.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RowLine.HeaderText = "Row Line";
            this.RowLine.Name = "RowLine";
            this.RowLine.ReadOnly = true;
            // 
            // Message
            // 
            this.Message.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Message.HeaderText = "Message";
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            // 
            // ImportDataLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 553);
            this.Controls.Add(this.dataGridViewDetail);
            this.Controls.Add(this.dataGridViewDatetime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxInstances);
            this.Name = "ImportDataLog";
            this.Text = "Import Data Log";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDatetime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxInstances;
        private System.Windows.Forms.DataGridView dataGridViewDatetime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportTime;
        private System.Windows.Forms.DataGridView dataGridViewDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn File;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sheet;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
    }
}