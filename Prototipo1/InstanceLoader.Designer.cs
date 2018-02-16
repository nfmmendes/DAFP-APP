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
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Seat List");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Airplanes", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Flight Request");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Requests", new System.Windows.Forms.TreeNode[] {
            treeNode7});
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.networkFileChoosenLabel = new System.Windows.Forms.Label();
            this.buttonChooseFileNetwork = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.choosenRequestFileLabel = new System.Windows.Forms.Label();
            this.buttonChooseRequestFile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.choosenAirplaneFileLabel = new System.Windows.Forms.Label();
            this.buttonChooseAirplaneFile = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxInstances = new System.Windows.Forms.ComboBox();
            this.buttonLoadFiles = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.treeViewTablesLoaded = new System.Windows.Forms.TreeView();
            this.label13 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxInstance = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButtonNew = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(359, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(634, 455);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.panel7);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(23, 59);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(589, 365);
            this.panel4.TabIndex = 18;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.networkFileChoosenLabel);
            this.panel7.Controls.Add(this.buttonChooseFileNetwork);
            this.panel7.Location = new System.Drawing.Point(114, 25);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(458, 43);
            this.panel7.TabIndex = 7;
            // 
            // networkFileChoosenLabel
            // 
            this.networkFileChoosenLabel.AutoSize = true;
            this.networkFileChoosenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.networkFileChoosenLabel.Location = new System.Drawing.Point(10, 9);
            this.networkFileChoosenLabel.Name = "networkFileChoosenLabel";
            this.networkFileChoosenLabel.Size = new System.Drawing.Size(0, 24);
            this.networkFileChoosenLabel.TabIndex = 2;
            // 
            // buttonChooseFileNetwork
            // 
            this.buttonChooseFileNetwork.Enabled = false;
            this.buttonChooseFileNetwork.Location = new System.Drawing.Point(309, 0);
            this.buttonChooseFileNetwork.Name = "buttonChooseFileNetwork";
            this.buttonChooseFileNetwork.Size = new System.Drawing.Size(148, 41);
            this.buttonChooseFileNetwork.TabIndex = 0;
            this.buttonChooseFileNetwork.Text = "Choose file";
            this.buttonChooseFileNetwork.UseVisualStyleBackColor = true;
            this.buttonChooseFileNetwork.Click += new System.EventHandler(this.buttonChooseFileNetwork_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label5.Location = new System.Drawing.Point(14, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "Network:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.choosenRequestFileLabel);
            this.panel6.Controls.Add(this.buttonChooseRequestFile);
            this.panel6.Location = new System.Drawing.Point(115, 179);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(458, 43);
            this.panel6.TabIndex = 5;
            // 
            // choosenRequestFileLabel
            // 
            this.choosenRequestFileLabel.AutoSize = true;
            this.choosenRequestFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.choosenRequestFileLabel.Location = new System.Drawing.Point(10, 9);
            this.choosenRequestFileLabel.Name = "choosenRequestFileLabel";
            this.choosenRequestFileLabel.Size = new System.Drawing.Size(0, 24);
            this.choosenRequestFileLabel.TabIndex = 2;
            // 
            // buttonChooseRequestFile
            // 
            this.buttonChooseRequestFile.Enabled = false;
            this.buttonChooseRequestFile.Location = new System.Drawing.Point(309, 0);
            this.buttonChooseRequestFile.Name = "buttonChooseRequestFile";
            this.buttonChooseRequestFile.Size = new System.Drawing.Size(148, 41);
            this.buttonChooseRequestFile.TabIndex = 0;
            this.buttonChooseRequestFile.Text = "Choose file";
            this.buttonChooseRequestFile.UseVisualStyleBackColor = true;
            this.buttonChooseRequestFile.Click += new System.EventHandler(this.buttonChooseFileRequests_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label6.Location = new System.Drawing.Point(15, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 24);
            this.label6.TabIndex = 4;
            this.label6.Text = "Requests:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.choosenAirplaneFileLabel);
            this.panel5.Controls.Add(this.buttonChooseAirplaneFile);
            this.panel5.Location = new System.Drawing.Point(115, 100);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(458, 43);
            this.panel5.TabIndex = 3;
            // 
            // choosenAirplaneFileLabel
            // 
            this.choosenAirplaneFileLabel.AutoSize = true;
            this.choosenAirplaneFileLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.choosenAirplaneFileLabel.Location = new System.Drawing.Point(10, 9);
            this.choosenAirplaneFileLabel.Name = "choosenAirplaneFileLabel";
            this.choosenAirplaneFileLabel.Size = new System.Drawing.Size(0, 24);
            this.choosenAirplaneFileLabel.TabIndex = 2;
            // 
            // buttonChooseAirplaneFile
            // 
            this.buttonChooseAirplaneFile.Enabled = false;
            this.buttonChooseAirplaneFile.Location = new System.Drawing.Point(309, 0);
            this.buttonChooseAirplaneFile.Name = "buttonChooseAirplaneFile";
            this.buttonChooseAirplaneFile.Size = new System.Drawing.Size(148, 41);
            this.buttonChooseAirplaneFile.TabIndex = 0;
            this.buttonChooseAirplaneFile.Text = "Choose file";
            this.buttonChooseAirplaneFile.UseVisualStyleBackColor = true;
            this.buttonChooseAirplaneFile.Click += new System.EventHandler(this.buttonChooseAirplaneFile_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label3.Location = new System.Drawing.Point(15, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Airplanes:";
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
            // comboBoxInstances
            // 
            this.comboBoxInstances.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.comboBoxInstances.FormattingEnabled = true;
            this.comboBoxInstances.Location = new System.Drawing.Point(20, 98);
            this.comboBoxInstances.Name = "comboBoxInstances";
            this.comboBoxInstances.Size = new System.Drawing.Size(277, 30);
            this.comboBoxInstances.TabIndex = 1;
            // 
            // buttonLoadFiles
            // 
            this.buttonLoadFiles.Enabled = false;
            this.buttonLoadFiles.ForeColor = System.Drawing.Color.DarkRed;
            this.buttonLoadFiles.Location = new System.Drawing.Point(625, 543);
            this.buttonLoadFiles.Name = "buttonLoadFiles";
            this.buttonLoadFiles.Size = new System.Drawing.Size(130, 38);
            this.buttonLoadFiles.TabIndex = 3;
            this.buttonLoadFiles.Text = "Load";
            this.buttonLoadFiles.UseVisualStyleBackColor = true;
            this.buttonLoadFiles.Click += new System.EventHandler(this.buttonLoadFiles_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkRed;
            this.panel2.Controls.Add(this.treeViewTablesLoaded);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Location = new System.Drawing.Point(13, 256);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 325);
            this.panel2.TabIndex = 4;
            // 
            // treeViewTablesLoaded
            // 
            this.treeViewTablesLoaded.CheckBoxes = true;
            this.treeViewTablesLoaded.Enabled = false;
            this.treeViewTablesLoaded.Location = new System.Drawing.Point(20, 52);
            this.treeViewTablesLoaded.Name = "treeViewTablesLoaded";
            treeNode1.Name = "AirportsNode";
            treeNode1.Text = "Airports";
            treeNode2.Name = "StretchNode";
            treeNode2.Text = "Stretches";
            treeNode3.Name = "NetworkNode";
            treeNode3.Text = "Network";
            treeNode4.Name = "AirplaneNode";
            treeNode4.Text = "Airplane";
            treeNode5.Name = "SeatListNode";
            treeNode5.Text = "Seat List";
            treeNode6.Name = "AirplaneNodes";
            treeNode6.Text = "Airplanes";
            treeNode7.Name = "FlightRequestNode";
            treeNode7.Text = "Flight Request";
            treeNode8.Name = "RequestsNodes";
            treeNode8.Text = "Requests";
            this.treeViewTablesLoaded.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6,
            treeNode8});
            this.treeViewTablesLoaded.Size = new System.Drawing.Size(269, 255);
            this.treeViewTablesLoaded.TabIndex = 17;
            this.treeViewTablesLoaded.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTablesLoaded_AfterCheck);
            this.treeViewTablesLoaded.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewTablesLoaded_AfterSelect);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial", 12.8F);
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(15, 12);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 25);
            this.label13.TabIndex = 16;
            this.label13.Text = "Tables loaded";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkRed;
            this.panel3.Controls.Add(this.textBoxInstance);
            this.panel3.Controls.Add(this.radioButton2);
            this.panel3.Controls.Add(this.radioButtonNew);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.comboBoxInstances);
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
            this.textBoxInstance.TextChanged += new System.EventHandler(this.textBoxInstance_TextChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.ForeColor = System.Drawing.Color.WhiteSmoke;
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
            this.radioButtonNew.ForeColor = System.Drawing.Color.WhiteSmoke;
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
            this.Controls.Add(this.buttonLoadFiles);
            this.Controls.Add(this.panel1);
            this.Name = "InstanceLoader";
            this.Text = "Load Instance";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox comboBoxInstances;
        private System.Windows.Forms.Button buttonLoadFiles;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView treeViewTablesLoaded;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxInstance;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButtonNew;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label choosenRequestFileLabel;
        private System.Windows.Forms.Button buttonChooseRequestFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label choosenAirplaneFileLabel;
        private System.Windows.Forms.Button buttonChooseAirplaneFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label networkFileChoosenLabel;
        private System.Windows.Forms.Button buttonChooseFileNetwork;
        private System.Windows.Forms.Label label5;
    }
}