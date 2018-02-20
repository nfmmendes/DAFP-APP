namespace Prototipo1
{
    partial class DuplicateInstance
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
            this.comboBoxInstance = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxScenarioDescription = new System.Windows.Forms.TextBox();
            this.textBoxInstanceName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonDuplicate = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxInstance
            // 
            this.comboBoxInstance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.comboBoxInstance.FormattingEnabled = true;
            this.comboBoxInstance.Location = new System.Drawing.Point(17, 78);
            this.comboBoxInstance.Name = "comboBoxInstance";
            this.comboBoxInstance.Size = new System.Drawing.Size(348, 30);
            this.comboBoxInstance.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Original Instance";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(12, 41);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.comboBoxInstance);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxScenarioDescription);
            this.splitContainer1.Panel2.Controls.Add(this.textBoxInstanceName);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Size = new System.Drawing.Size(1037, 207);
            this.splitContainer1.SplitterDistance = 407;
            this.splitContainer1.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label4.Location = new System.Drawing.Point(18, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 24);
            this.label4.TabIndex = 13;
            this.label4.Text = "New instance";
            // 
            // textBoxScenarioDescription
            // 
            this.textBoxScenarioDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.textBoxScenarioDescription.Location = new System.Drawing.Point(133, 131);
            this.textBoxScenarioDescription.MaxLength = 128;
            this.textBoxScenarioDescription.Name = "textBoxScenarioDescription";
            this.textBoxScenarioDescription.Size = new System.Drawing.Size(479, 28);
            this.textBoxScenarioDescription.TabIndex = 10;
            // 
            // textBoxInstanceName
            // 
            this.textBoxInstanceName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.textBoxInstanceName.Location = new System.Drawing.Point(133, 78);
            this.textBoxInstanceName.MaxLength = 32;
            this.textBoxInstanceName.Name = "textBoxInstanceName";
            this.textBoxInstanceName.Size = new System.Drawing.Size(288, 28);
            this.textBoxInstanceName.TabIndex = 9;
            this.textBoxInstanceName.TextChanged += new System.EventHandler(this.textBoxInstanceName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label2.Location = new System.Drawing.Point(18, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label3.Location = new System.Drawing.Point(18, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 24);
            this.label3.TabIndex = 11;
            this.label3.Text = "Name:";
            // 
            // buttonDuplicate
            // 
            this.buttonDuplicate.Enabled = false;
            this.buttonDuplicate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.buttonDuplicate.Location = new System.Drawing.Point(275, 268);
            this.buttonDuplicate.Name = "buttonDuplicate";
            this.buttonDuplicate.Size = new System.Drawing.Size(182, 47);
            this.buttonDuplicate.TabIndex = 3;
            this.buttonDuplicate.Text = "Duplicate";
            this.buttonDuplicate.UseVisualStyleBackColor = true;
            this.buttonDuplicate.Click += new System.EventHandler(this.buttonDuplicate_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.buttonCancel.Location = new System.Drawing.Point(609, 268);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(182, 47);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // DuplicateInstance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1061, 327);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDuplicate);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DuplicateInstance";
            this.Text = "Duplicate Instance";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxInstance;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox textBoxScenarioDescription;
        private System.Windows.Forms.TextBox textBoxInstanceName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonDuplicate;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label4;
    }
}