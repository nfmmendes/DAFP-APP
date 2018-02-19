namespace Prototipo1
{
    partial class CreateInstance
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
            this.buttonCreateScenario = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxScenarioName = new System.Windows.Forms.TextBox();
            this.textBoxScenarioDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonCreateScenario
            // 
            this.buttonCreateScenario.Location = new System.Drawing.Point(248, 155);
            this.buttonCreateScenario.Name = "buttonCreateScenario";
            this.buttonCreateScenario.Size = new System.Drawing.Size(133, 38);
            this.buttonCreateScenario.TabIndex = 2;
            this.buttonCreateScenario.Text = "Create";
            this.buttonCreateScenario.UseVisualStyleBackColor = true;
            this.buttonCreateScenario.Click += new System.EventHandler(this.buttonCreateScenario_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(482, 155);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(133, 38);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label1.Location = new System.Drawing.Point(26, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label2.Location = new System.Drawing.Point(26, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description:";
            // 
            // textBoxScenarioName
            // 
            this.textBoxScenarioName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.textBoxScenarioName.Location = new System.Drawing.Point(136, 41);
            this.textBoxScenarioName.MaxLength = 32;
            this.textBoxScenarioName.Name = "textBoxScenarioName";
            this.textBoxScenarioName.Size = new System.Drawing.Size(288, 28);
            this.textBoxScenarioName.TabIndex = 0;
            // 
            // textBoxScenarioDescription
            // 
            this.textBoxScenarioDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.textBoxScenarioDescription.Location = new System.Drawing.Point(136, 94);
            this.textBoxScenarioDescription.MaxLength = 40;
            this.textBoxScenarioDescription.Name = "textBoxScenarioDescription";
            this.textBoxScenarioDescription.Size = new System.Drawing.Size(479, 28);
            this.textBoxScenarioDescription.TabIndex = 1;
            // 
            // CreateInstance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 210);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxScenarioDescription);
            this.Controls.Add(this.textBoxScenarioName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonCreateScenario);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(838, 257);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(838, 257);
            this.Name = "CreateInstance";
            this.Text = "New Instance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateScenario;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxScenarioName;
        private System.Windows.Forms.TextBox textBoxScenarioDescription;
    }
}