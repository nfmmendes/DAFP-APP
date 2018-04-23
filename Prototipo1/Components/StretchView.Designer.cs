namespace Prototipo1.Components
{
    partial class StretchView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonNextPageStretch = new System.Windows.Forms.Button();
            this.buttonLastPageStretch = new System.Windows.Forms.Button();
            this.labelPageStretch = new System.Windows.Forms.Label();
            this.buttonFirstPageStretch = new System.Windows.Forms.Button();
            this.buttonPrevPageStretch = new System.Windows.Forms.Button();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.dataGridViewStretches = new System.Windows.Forms.DataGridView();
            this.StretcheId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OriginStretche = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestinationStretche = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DistanceStretche = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonDistances = new System.Windows.Forms.Button();
            this.comboBoxPageSize = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStretches)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonNextPageStretch
            // 
            this.buttonNextPageStretch.Location = new System.Drawing.Point(558, 419);
            this.buttonNextPageStretch.Name = "buttonNextPageStretch";
            this.buttonNextPageStretch.Size = new System.Drawing.Size(42, 34);
            this.buttonNextPageStretch.TabIndex = 22;
            this.buttonNextPageStretch.Text = ">";
            this.buttonNextPageStretch.UseVisualStyleBackColor = true;
            this.buttonNextPageStretch.Click += new System.EventHandler(this.buttonNextPageStretch_Click);
            // 
            // buttonLastPageStretch
            // 
            this.buttonLastPageStretch.Location = new System.Drawing.Point(612, 419);
            this.buttonLastPageStretch.Name = "buttonLastPageStretch";
            this.buttonLastPageStretch.Size = new System.Drawing.Size(42, 34);
            this.buttonLastPageStretch.TabIndex = 21;
            this.buttonLastPageStretch.Text = ">>";
            this.buttonLastPageStretch.UseVisualStyleBackColor = true;
            this.buttonLastPageStretch.Click += new System.EventHandler(this.buttonLastPageStretch_Click);
            // 
            // labelPageStretch
            // 
            this.labelPageStretch.AutoSize = true;
            this.labelPageStretch.Location = new System.Drawing.Point(464, 425);
            this.labelPageStretch.Name = "labelPageStretch";
            this.labelPageStretch.Size = new System.Drawing.Size(32, 17);
            this.labelPageStretch.TabIndex = 20;
            this.labelPageStretch.Text = "1 of";
            // 
            // buttonFirstPageStretch
            // 
            this.buttonFirstPageStretch.Location = new System.Drawing.Point(338, 419);
            this.buttonFirstPageStretch.Name = "buttonFirstPageStretch";
            this.buttonFirstPageStretch.Size = new System.Drawing.Size(42, 34);
            this.buttonFirstPageStretch.TabIndex = 19;
            this.buttonFirstPageStretch.Text = "<<";
            this.buttonFirstPageStretch.UseVisualStyleBackColor = true;
            this.buttonFirstPageStretch.Click += new System.EventHandler(this.buttonFirstPageStretch_Click);
            // 
            // buttonPrevPageStretch
            // 
            this.buttonPrevPageStretch.Location = new System.Drawing.Point(392, 419);
            this.buttonPrevPageStretch.Name = "buttonPrevPageStretch";
            this.buttonPrevPageStretch.Size = new System.Drawing.Size(42, 34);
            this.buttonPrevPageStretch.TabIndex = 18;
            this.buttonPrevPageStretch.Text = "<";
            this.buttonPrevPageStretch.UseVisualStyleBackColor = true;
            this.buttonPrevPageStretch.Click += new System.EventHandler(this.buttonPrevPageStretch_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.buttonEdit.Location = new System.Drawing.Point(1035, 5);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(91, 34);
            this.buttonEdit.TabIndex = 17;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            // 
            // dataGridViewStretches
            // 
            this.dataGridViewStretches.AllowUserToAddRows = false;
            this.dataGridViewStretches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStretches.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewStretches.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStretches.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StretcheId,
            this.OriginStretche,
            this.DestinationStretche,
            this.DistanceStretche});
            this.dataGridViewStretches.Location = new System.Drawing.Point(14, 5);
            this.dataGridViewStretches.Name = "dataGridViewStretches";
            this.dataGridViewStretches.RowHeadersVisible = false;
            this.dataGridViewStretches.RowTemplate.Height = 24;
            this.dataGridViewStretches.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStretches.Size = new System.Drawing.Size(1000, 400);
            this.dataGridViewStretches.TabIndex = 16;
            // 
            // StretcheId
            // 
            this.StretcheId.HeaderText = "Id";
            this.StretcheId.Name = "StretcheId";
            this.StretcheId.Visible = false;
            // 
            // OriginStretche
            // 
            this.OriginStretche.HeaderText = "Origin";
            this.OriginStretche.Name = "OriginStretche";
            this.OriginStretche.ReadOnly = true;
            // 
            // DestinationStretche
            // 
            this.DestinationStretche.HeaderText = "Destination";
            this.DestinationStretche.Name = "DestinationStretche";
            this.DestinationStretche.ReadOnly = true;
            // 
            // DistanceStretche
            // 
            this.DistanceStretche.HeaderText = "Distance (Km)";
            this.DistanceStretche.Name = "DistanceStretche";
            this.DistanceStretche.ReadOnly = true;
            // 
            // buttonDistances
            // 
            this.buttonDistances.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.buttonDistances.Location = new System.Drawing.Point(14, 419);
            this.buttonDistances.Name = "buttonDistances";
            this.buttonDistances.Size = new System.Drawing.Size(187, 34);
            this.buttonDistances.TabIndex = 23;
            this.buttonDistances.Text = "Calculate Distances";
            this.buttonDistances.UseVisualStyleBackColor = true;
            this.buttonDistances.Click += new System.EventHandler(this.buttonDistances_Click);
            // 
            // comboBoxPageSize
            // 
            this.comboBoxPageSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.comboBoxPageSize.FormattingEnabled = true;
            this.comboBoxPageSize.Items.AddRange(new object[] {
            "20",
            "50",
            "100",
            "200",
            "500",
            "1000"});
            this.comboBoxPageSize.Location = new System.Drawing.Point(917, 419);
            this.comboBoxPageSize.Name = "comboBoxPageSize";
            this.comboBoxPageSize.Size = new System.Drawing.Size(97, 30);
            this.comboBoxPageSize.TabIndex = 24;
            this.comboBoxPageSize.SelectedIndexChanged += new System.EventHandler(this.comboBoxPageSize_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label1.Location = new System.Drawing.Point(816, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 24);
            this.label1.TabIndex = 25;
            this.label1.Text = "Page size:";
            // 
            // StretchView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxPageSize);
            this.Controls.Add(this.buttonDistances);
            this.Controls.Add(this.buttonNextPageStretch);
            this.Controls.Add(this.buttonLastPageStretch);
            this.Controls.Add(this.labelPageStretch);
            this.Controls.Add(this.buttonFirstPageStretch);
            this.Controls.Add(this.buttonPrevPageStretch);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.dataGridViewStretches);
            this.Name = "StretchView";
            this.Size = new System.Drawing.Size(1180, 530);
            this.Load += new System.EventHandler(this.StretchView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStretches)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNextPageStretch;
        private System.Windows.Forms.Button buttonLastPageStretch;
        private System.Windows.Forms.Label labelPageStretch;
        private System.Windows.Forms.Button buttonFirstPageStretch;
        private System.Windows.Forms.Button buttonPrevPageStretch;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.DataGridView dataGridViewStretches;
        private System.Windows.Forms.Button buttonDistances;
        private System.Windows.Forms.DataGridViewTextBoxColumn StretcheId;
        private System.Windows.Forms.DataGridViewTextBoxColumn OriginStretche;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestinationStretche;
        private System.Windows.Forms.DataGridViewTextBoxColumn DistanceStretche;
        private System.Windows.Forms.ComboBox comboBoxPageSize;
        private System.Windows.Forms.Label label1;
    }
}
