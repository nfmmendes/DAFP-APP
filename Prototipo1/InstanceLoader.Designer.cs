namespace Prototipo1
{
    partial class InstanceLoader
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Airports");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Stretches");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Network", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Airplane");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Airplanes", new System.Windows.Forms.TreeNode[] {
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Passenger");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Flight Request");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Flight Cluster Request");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Requests", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8});
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.buttonSelectFiles = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label13 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxInstance = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButtonNew = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(359, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 455);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12.8F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(18, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "File List";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(20, 98);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(277, 30);
            this.comboBox1.TabIndex = 1;
            // 
            // buttonSelectFiles
            // 
            this.buttonSelectFiles.Enabled = false;
            this.buttonSelectFiles.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonSelectFiles.Location = new System.Drawing.Point(493, 543);
            this.buttonSelectFiles.Name = "buttonSelectFiles";
            this.buttonSelectFiles.Size = new System.Drawing.Size(130, 38);
            this.buttonSelectFiles.TabIndex = 2;
            this.buttonSelectFiles.Text = "Select files";
            this.buttonSelectFiles.UseVisualStyleBackColor = true;
            this.buttonSelectFiles.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.ForeColor = System.Drawing.Color.DarkRed;
            this.button1.Location = new System.Drawing.Point(699, 543);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "Load";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkRed;
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(13, 256);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 325);
            this.panel2.TabIndex = 4;
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Location = new System.Drawing.Point(20, 52);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "AirportsNode";
            treeNode1.Text = "Airports";
            treeNode2.Name = "StretchNode";
            treeNode2.Text = "Stretches";
            treeNode3.Name = "NetworkNode";
            treeNode3.Text = "Network";
            treeNode4.Name = "AirplaneNode";
            treeNode4.Text = "Airplane";
            treeNode5.Name = "AirplaneNodes";
            treeNode5.Text = "Airplanes";
            treeNode6.Name = "PassengerNode";
            treeNode6.Text = "Passenger";
            treeNode7.Name = "FlightRequestNode";
            treeNode7.Text = "Flight Request";
            treeNode8.Name = "Flight Cluster Request Node";
            treeNode8.Text = "Flight Cluster Request";
            treeNode9.Name = "RequestsNodes";
            treeNode9.Text = "Requests";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode5,
            treeNode9});
            this.treeView1.Size = new System.Drawing.Size(269, 255);
            this.treeView1.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12.8F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(15, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 25);
            this.label13.TabIndex = 16;
            this.label13.Text = "File List";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkRed;
            this.panel3.Controls.Add(this.textBoxInstance);
            this.panel3.Controls.Add(this.radioButton2);
            this.panel3.Controls.Add(this.radioButtonNew);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.comboBox1);
            this.panel3.Location = new System.Drawing.Point(13, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(315, 182);
            this.panel3.TabIndex = 5;
            // 
            // textBoxInstance
            // 
            this.textBoxInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.textBoxInstance.Location = new System.Drawing.Point(20, 99);
            this.textBoxInstance.Name = "textBoxInstance";
            this.textBoxInstance.Size = new System.Drawing.Size(276, 28);
            this.textBoxInstance.TabIndex = 19;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(169, 59);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(128, 21);
            this.radioButton2.TabIndex = 18;
            this.radioButton2.Text = "Stored Instance";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButtonNew
            // 
            this.radioButtonNew.AutoSize = true;
            this.radioButtonNew.Checked = true;
            this.radioButtonNew.Location = new System.Drawing.Point(20, 59);
            this.radioButtonNew.Name = "radioButtonNew";
            this.radioButtonNew.Size = new System.Drawing.Size(113, 21);
            this.radioButtonNew.TabIndex = 17;
            this.radioButtonNew.TabStop = true;
            this.radioButtonNew.Text = "New Instance";
            this.radioButtonNew.UseVisualStyleBackColor = true;
            this.radioButtonNew.CheckedChanged += new System.EventHandler(this.radioButtonNew_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12.8F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "Instance";
            // 
            // InstanceLoader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 606);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSelectFiles);
            this.Controls.Add(this.panel1);
            this.Name = "InstanceLoader";
            this.Text = "Load Instance";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button buttonSelectFiles;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxInstance;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButtonNew;
        private System.Windows.Forms.Label label2;
    }
}