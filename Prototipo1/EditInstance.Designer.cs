namespace Prototipo1
{
    partial class EditInstance
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
            this.textBoxScenarioDescription = new System.Windows.Forms.TextBox();
            this.textBoxScenarioName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonEditScenario = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxScenarioDescription
            // 
            this.textBoxScenarioDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.textBoxScenarioDescription.Location = new System.Drawing.Point(128, 86);
            this.textBoxScenarioDescription.MaxLength = 128;
            this.textBoxScenarioDescription.Name = "textBoxScenarioDescription";
            this.textBoxScenarioDescription.Size = new System.Drawing.Size(479, 28);
            this.textBoxScenarioDescription.TabIndex = 5;
            // 
            // textBoxInstanceName
            // 
            this.textBoxScenarioName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.textBoxScenarioName.Location = new System.Drawing.Point(128, 33);
            this.textBoxScenarioName.MaxLength = 32;
            this.textBoxScenarioName.Name = "textBoxInstanceName";
            this.textBoxScenarioName.Size = new System.Drawing.Size(288, 28);
            this.textBoxScenarioName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label2.Location = new System.Drawing.Point(18, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label1.Location = new System.Drawing.Point(18, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Name:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(474, 199);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(133, 38);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonEditScenario
            // 
            this.buttonEditScenario.Location = new System.Drawing.Point(240, 199);
            this.buttonEditScenario.Name = "buttonEditScenario";
            this.buttonEditScenario.Size = new System.Drawing.Size(133, 38);
            this.buttonEditScenario.TabIndex = 7;
            this.buttonEditScenario.Text = "Edit";
            this.buttonEditScenario.UseVisualStyleBackColor = true;
            this.buttonEditScenario.Click += new System.EventHandler(this.buttonEditScenario_Click);
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 249);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxScenarioDescription);
            this.Controls.Add(this.textBoxScenarioName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonEditScenario);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditInstance";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Edit Instance";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxScenarioDescription;
        private System.Windows.Forms.TextBox textBoxScenarioName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonEditScenario;
    }
}