namespace Prototipo1
{
    partial class AddEditRequest
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
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPNR = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numUD_Hr_MinDep = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numUD_Min_MinDep = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numUD_Min_MaxDep = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.numUD_Hr_MaxDep = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numUD_Min_MinArr = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.numUD_Hr_MinArr = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.numUD_Min_MaxArr = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.numUD_Hr_MaxArr = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBoxOrigin = new System.Windows.Forms.ComboBox();
            this.comboBoxDestination = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Hr_MinDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Min_MinDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Min_MaxDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Hr_MaxDep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Min_MinArr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Hr_MinArr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Min_MaxArr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Hr_MaxArr)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(417, 372);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(126, 43);
            this.buttonCancel.TabIndex = 13;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(230, 372);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(126, 43);
            this.buttonSave.TabIndex = 12;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label1.Location = new System.Drawing.Point(23, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "PNR :";
            // 
            // textBoxPNR
            // 
            this.textBoxPNR.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.textBoxPNR.Location = new System.Drawing.Point(100, 44);
            this.textBoxPNR.Name = "textBoxPNR";
            this.textBoxPNR.Size = new System.Drawing.Size(221, 28);
            this.textBoxPNR.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label2.Location = new System.Drawing.Point(23, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 24);
            this.label2.TabIndex = 20;
            this.label2.Text = "Origin :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label3.Location = new System.Drawing.Point(379, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 24);
            this.label3.TabIndex = 22;
            this.label3.Text = "Destination :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label4.Location = new System.Drawing.Point(23, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 24);
            this.label4.TabIndex = 24;
            this.label4.Text = "Minimum Departure Time";
            // 
            // numUD_Hr_MinDep
            // 
            this.numUD_Hr_MinDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.numUD_Hr_MinDep.Location = new System.Drawing.Point(37, 182);
            this.numUD_Hr_MinDep.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.numUD_Hr_MinDep.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numUD_Hr_MinDep.Name = "numUD_Hr_MinDep";
            this.numUD_Hr_MinDep.Size = new System.Drawing.Size(60, 28);
            this.numUD_Hr_MinDep.TabIndex = 4;
            this.numUD_Hr_MinDep.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label5.Location = new System.Drawing.Point(104, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 24);
            this.label5.TabIndex = 26;
            this.label5.Text = "Hrs";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label6.Location = new System.Drawing.Point(216, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 24);
            this.label6.TabIndex = 28;
            this.label6.Text = "Min";
            // 
            // numUD_Min_MinDep
            // 
            this.numUD_Min_MinDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.numUD_Min_MinDep.Location = new System.Drawing.Point(149, 184);
            this.numUD_Min_MinDep.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numUD_Min_MinDep.Name = "numUD_Min_MinDep";
            this.numUD_Min_MinDep.Size = new System.Drawing.Size(60, 28);
            this.numUD_Min_MinDep.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label7.Location = new System.Drawing.Point(676, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 24);
            this.label7.TabIndex = 33;
            this.label7.Text = "Min";
            // 
            // numUD_Min_MaxDep
            // 
            this.numUD_Min_MaxDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.numUD_Min_MaxDep.Location = new System.Drawing.Point(609, 184);
            this.numUD_Min_MaxDep.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numUD_Min_MaxDep.Name = "numUD_Min_MaxDep";
            this.numUD_Min_MaxDep.Size = new System.Drawing.Size(60, 28);
            this.numUD_Min_MaxDep.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label8.Location = new System.Drawing.Point(564, 186);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 24);
            this.label8.TabIndex = 31;
            this.label8.Text = "Hrs";
            // 
            // numUD_Hr_MaxDep
            // 
            this.numUD_Hr_MaxDep.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.numUD_Hr_MaxDep.Location = new System.Drawing.Point(497, 182);
            this.numUD_Hr_MaxDep.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.numUD_Hr_MaxDep.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numUD_Hr_MaxDep.Name = "numUD_Hr_MaxDep";
            this.numUD_Hr_MaxDep.Size = new System.Drawing.Size(60, 28);
            this.numUD_Hr_MaxDep.TabIndex = 6;
            this.numUD_Hr_MaxDep.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label9.Location = new System.Drawing.Point(478, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(229, 24);
            this.label9.TabIndex = 29;
            this.label9.Text = "Maximum Departure Time";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label10.Location = new System.Drawing.Point(216, 269);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 24);
            this.label10.TabIndex = 38;
            this.label10.Text = "Min";
            // 
            // numUD_Min_MinArr
            // 
            this.numUD_Min_MinArr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.numUD_Min_MinArr.Location = new System.Drawing.Point(149, 265);
            this.numUD_Min_MinArr.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numUD_Min_MinArr.Name = "numUD_Min_MinArr";
            this.numUD_Min_MinArr.Size = new System.Drawing.Size(60, 28);
            this.numUD_Min_MinArr.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label11.Location = new System.Drawing.Point(104, 267);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 24);
            this.label11.TabIndex = 36;
            this.label11.Text = "Hrs";
            // 
            // numUD_Hr_MinArr
            // 
            this.numUD_Hr_MinArr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.numUD_Hr_MinArr.Location = new System.Drawing.Point(37, 263);
            this.numUD_Hr_MinArr.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.numUD_Hr_MinArr.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numUD_Hr_MinArr.Name = "numUD_Hr_MinArr";
            this.numUD_Hr_MinArr.Size = new System.Drawing.Size(60, 28);
            this.numUD_Hr_MinArr.TabIndex = 8;
            this.numUD_Hr_MinArr.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label12.Location = new System.Drawing.Point(33, 234);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(193, 24);
            this.label12.TabIndex = 34;
            this.label12.Text = "Minimum Arrival Time";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label13.Location = new System.Drawing.Point(676, 273);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 24);
            this.label13.TabIndex = 43;
            this.label13.Text = "Min";
            // 
            // numUD_Min_MaxArr
            // 
            this.numUD_Min_MaxArr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.numUD_Min_MaxArr.Location = new System.Drawing.Point(609, 269);
            this.numUD_Min_MaxArr.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numUD_Min_MaxArr.Name = "numUD_Min_MaxArr";
            this.numUD_Min_MaxArr.Size = new System.Drawing.Size(60, 28);
            this.numUD_Min_MaxArr.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label14.Location = new System.Drawing.Point(564, 271);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 24);
            this.label14.TabIndex = 41;
            this.label14.Text = "Hrs";
            // 
            // numUD_Hr_MaxArr
            // 
            this.numUD_Hr_MaxArr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.numUD_Hr_MaxArr.Location = new System.Drawing.Point(497, 267);
            this.numUD_Hr_MaxArr.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.numUD_Hr_MaxArr.Minimum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numUD_Hr_MaxArr.Name = "numUD_Hr_MaxArr";
            this.numUD_Hr_MaxArr.Size = new System.Drawing.Size(60, 28);
            this.numUD_Hr_MaxArr.TabIndex = 10;
            this.numUD_Hr_MaxArr.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label15.Location = new System.Drawing.Point(498, 234);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(198, 24);
            this.label15.TabIndex = 39;
            this.label15.Text = "Maximum Arrival Time";
            // 
            // comboBoxOrigin
            // 
            this.comboBoxOrigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.comboBoxOrigin.FormattingEnabled = true;
            this.comboBoxOrigin.Location = new System.Drawing.Point(100, 89);
            this.comboBoxOrigin.Name = "comboBoxOrigin";
            this.comboBoxOrigin.Size = new System.Drawing.Size(220, 30);
            this.comboBoxOrigin.TabIndex = 2;
            // 
            // comboBoxDestination
            // 
            this.comboBoxDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.comboBoxDestination.FormattingEnabled = true;
            this.comboBoxDestination.Location = new System.Drawing.Point(497, 92);
            this.comboBoxDestination.Name = "comboBoxDestination";
            this.comboBoxDestination.Size = new System.Drawing.Size(220, 30);
            this.comboBoxDestination.TabIndex = 3;
            // 
            // AddEditRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 455);
            this.Controls.Add(this.comboBoxDestination);
            this.Controls.Add(this.comboBoxOrigin);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.numUD_Min_MaxArr);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.numUD_Hr_MaxArr);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numUD_Min_MinArr);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numUD_Hr_MinArr);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numUD_Min_MaxDep);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numUD_Hr_MaxDep);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numUD_Min_MinDep);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numUD_Hr_MinDep);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPNR);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditRequest";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Hr_MinDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Min_MinDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Min_MaxDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Hr_MaxDep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Min_MinArr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Hr_MinArr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Min_MaxArr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUD_Hr_MaxArr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPNR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numUD_Hr_MinDep;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numUD_Min_MinDep;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numUD_Min_MaxDep;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numUD_Hr_MaxDep;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numUD_Min_MinArr;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numUD_Hr_MinArr;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numUD_Min_MaxArr;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numUD_Hr_MaxArr;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBoxOrigin;
        private System.Windows.Forms.ComboBox comboBoxDestination;
    }
}