namespace Prototipo1
{
    partial class AddEditPassenger
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
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataGridViewPassenger = new System.Windows.Forms.DataGridView();
            this.IdPassenger = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Passenger = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsKid = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxPassenger = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxClass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonIsChildren = new System.Windows.Forms.RadioButton();
            this.radioButtonIsNotChildren = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioButtonMale = new System.Windows.Forms.RadioButton();
            this.radioButtonFemale = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPassenger)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(369, 356);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(126, 43);
            this.buttonEdit.TabIndex = 19;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(182, 356);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(126, 43);
            this.buttonAdd.TabIndex = 18;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
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
            this.dataGridViewPassenger.Location = new System.Drawing.Point(12, 50);
            this.dataGridViewPassenger.Name = "dataGridViewPassenger";
            this.dataGridViewPassenger.RowHeadersVisible = false;
            this.dataGridViewPassenger.RowTemplate.Height = 24;
            this.dataGridViewPassenger.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPassenger.Size = new System.Drawing.Size(831, 171);
            this.dataGridViewPassenger.TabIndex = 20;
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
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(559, 356);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(126, 43);
            this.buttonClose.TabIndex = 22;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxPassenger
            // 
            this.textBoxPassenger.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.textBoxPassenger.Location = new System.Drawing.Point(125, 242);
            this.textBoxPassenger.Name = "textBoxPassenger";
            this.textBoxPassenger.Size = new System.Drawing.Size(221, 28);
            this.textBoxPassenger.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label1.Location = new System.Drawing.Point(10, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 23;
            this.label1.Text = "Passenger :";
            // 
            // textBoxClass
            // 
            this.textBoxClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.textBoxClass.Location = new System.Drawing.Point(502, 243);
            this.textBoxClass.Name = "textBoxClass";
            this.textBoxClass.Size = new System.Drawing.Size(221, 28);
            this.textBoxClass.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label2.Location = new System.Drawing.Point(430, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 25;
            this.label2.Text = "Class :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label3.Location = new System.Drawing.Point(12, 294);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 24);
            this.label3.TabIndex = 27;
            this.label3.Text = "Is Children :";
            // 
            // radioButtonIsChildren
            // 
            this.radioButtonIsChildren.AutoSize = true;
            this.radioButtonIsChildren.Location = new System.Drawing.Point(3, 7);
            this.radioButtonIsChildren.Name = "radioButtonIsChildren";
            this.radioButtonIsChildren.Size = new System.Drawing.Size(53, 21);
            this.radioButtonIsChildren.TabIndex = 28;
            this.radioButtonIsChildren.TabStop = true;
            this.radioButtonIsChildren.Text = "Yes";
            this.radioButtonIsChildren.UseVisualStyleBackColor = true;
            // 
            // radioButtonIsNotChildren
            // 
            this.radioButtonIsNotChildren.AutoSize = true;
            this.radioButtonIsNotChildren.Location = new System.Drawing.Point(103, 7);
            this.radioButtonIsNotChildren.Name = "radioButtonIsNotChildren";
            this.radioButtonIsNotChildren.Size = new System.Drawing.Size(47, 21);
            this.radioButtonIsNotChildren.TabIndex = 29;
            this.radioButtonIsNotChildren.TabStop = true;
            this.radioButtonIsNotChildren.Text = "No";
            this.radioButtonIsNotChildren.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonIsChildren);
            this.panel1.Controls.Add(this.radioButtonIsNotChildren);
            this.panel1.Location = new System.Drawing.Point(127, 285);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(174, 33);
            this.panel1.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label4.Location = new System.Drawing.Point(430, 289);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 24);
            this.label4.TabIndex = 31;
            this.label4.Text = "Sex :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioButtonMale);
            this.panel2.Controls.Add(this.radioButtonFemale);
            this.panel2.Location = new System.Drawing.Point(502, 285);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(196, 33);
            this.panel2.TabIndex = 32;
            // 
            // radioButtonMale
            // 
            this.radioButtonMale.AutoSize = true;
            this.radioButtonMale.Location = new System.Drawing.Point(3, 7);
            this.radioButtonMale.Name = "radioButtonMale";
            this.radioButtonMale.Size = new System.Drawing.Size(59, 21);
            this.radioButtonMale.TabIndex = 28;
            this.radioButtonMale.TabStop = true;
            this.radioButtonMale.Text = "Male";
            this.radioButtonMale.UseVisualStyleBackColor = true;
            // 
            // radioButtonFemale
            // 
            this.radioButtonFemale.AutoSize = true;
            this.radioButtonFemale.Location = new System.Drawing.Point(103, 7);
            this.radioButtonFemale.Name = "radioButtonFemale";
            this.radioButtonFemale.Size = new System.Drawing.Size(75, 21);
            this.radioButtonFemale.TabIndex = 29;
            this.radioButtonFemale.TabStop = true;
            this.radioButtonFemale.Text = "Female";
            this.radioButtonFemale.UseVisualStyleBackColor = true;
            // 
            // AddEditPassenger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 411);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxClass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPassenger);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.dataGridViewPassenger);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.MaximizeBox = false;
            this.Name = "AddEditPassenger";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPassenger)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridView dataGridViewPassenger;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPassenger;
        private System.Windows.Forms.DataGridViewTextBoxColumn Passenger;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sex;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsKid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxPassenger;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonIsChildren;
        private System.Windows.Forms.RadioButton radioButtonIsNotChildren;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton radioButtonMale;
        private System.Windows.Forms.RadioButton radioButtonFemale;
    }
}