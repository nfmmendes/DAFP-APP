namespace Prototipo1.Components
{
    partial class CurrencyView
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
            this.buttonDeleteCurrency = new System.Windows.Forms.Button();
            this.buttonEditCurrency = new System.Windows.Forms.Button();
            this.buttonAddCurrency = new System.Windows.Forms.Button();
            this.dataGridViewCurrency = new System.Windows.Forms.DataGridView();
            this.CurrencyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrencyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrencySymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCurrency)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonDeleteCurrency
            // 
            this.buttonDeleteCurrency.Location = new System.Drawing.Point(1035, 105);
            this.buttonDeleteCurrency.Name = "buttonDeleteCurrency";
            this.buttonDeleteCurrency.Size = new System.Drawing.Size(91, 34);
            this.buttonDeleteCurrency.TabIndex = 17;
            this.buttonDeleteCurrency.Text = "Delete";
            this.buttonDeleteCurrency.UseVisualStyleBackColor = true;
            this.buttonDeleteCurrency.Click += new System.EventHandler(this.buttonDeleteCurrency_Click);
            // 
            // buttonEditCurrency
            // 
            this.buttonEditCurrency.Location = new System.Drawing.Point(1035, 55);
            this.buttonEditCurrency.Name = "buttonEditCurrency";
            this.buttonEditCurrency.Size = new System.Drawing.Size(91, 34);
            this.buttonEditCurrency.TabIndex = 16;
            this.buttonEditCurrency.Text = "Edit";
            this.buttonEditCurrency.UseVisualStyleBackColor = true;
            this.buttonEditCurrency.Click += new System.EventHandler(this.buttonEditCurrency_Click);
            // 
            // buttonAddCurrency
            // 
            this.buttonAddCurrency.Location = new System.Drawing.Point(1035, 5);
            this.buttonAddCurrency.Name = "buttonAddCurrency";
            this.buttonAddCurrency.Size = new System.Drawing.Size(91, 34);
            this.buttonAddCurrency.TabIndex = 15;
            this.buttonAddCurrency.Text = "Add";
            this.buttonAddCurrency.UseVisualStyleBackColor = true;
            this.buttonAddCurrency.Click += new System.EventHandler(this.buttonAddCurrency_Click);
            // 
            // dataGridViewCurrency
            // 
            this.dataGridViewCurrency.AllowUserToAddRows = false;
            this.dataGridViewCurrency.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCurrency.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCurrency.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CurrencyId,
            this.CurrencyName,
            this.CurrencySymbol,
            this.Value});
            this.dataGridViewCurrency.Location = new System.Drawing.Point(10, 5);
            this.dataGridViewCurrency.Name = "dataGridViewCurrency";
            this.dataGridViewCurrency.RowHeadersVisible = false;
            this.dataGridViewCurrency.RowTemplate.Height = 24;
            this.dataGridViewCurrency.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCurrency.Size = new System.Drawing.Size(1008, 450);
            this.dataGridViewCurrency.TabIndex = 14;
            // 
            // CurrencyId
            // 
            this.CurrencyId.HeaderText = "Id";
            this.CurrencyId.Name = "CurrencyId";
            this.CurrencyId.ReadOnly = true;
            this.CurrencyId.Visible = false;
            // 
            // CurrencyName
            // 
            this.CurrencyName.HeaderText = "Currency";
            this.CurrencyName.Name = "CurrencyName";
            this.CurrencyName.ReadOnly = true;
            // 
            // CurrencySymbol
            // 
            this.CurrencySymbol.HeaderText = "Symbol";
            this.CurrencySymbol.Name = "CurrencySymbol";
            this.CurrencySymbol.ReadOnly = true;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value (1 to US$)";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // CurrencyView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.buttonDeleteCurrency);
            this.Controls.Add(this.buttonEditCurrency);
            this.Controls.Add(this.buttonAddCurrency);
            this.Controls.Add(this.dataGridViewCurrency);
            this.Name = "CurrencyView";
            this.Size = new System.Drawing.Size(1180, 530);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCurrency)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDeleteCurrency;
        private System.Windows.Forms.Button buttonEditCurrency;
        private System.Windows.Forms.Button buttonAddCurrency;
        private System.Windows.Forms.DataGridView dataGridViewCurrency;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencyId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencySymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
    }
}
