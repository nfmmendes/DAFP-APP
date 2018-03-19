namespace Prototipo1
{
    partial class AddEditStretch
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
            this.comboBoxOrigin = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDestination = new System.Windows.Forms.ComboBox();
            this.Destination = new System.Windows.Forms.Label();
            this.numUpDownDist = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownDist)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxOrigin
            // 
            this.comboBoxOrigin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.comboBoxOrigin.FormattingEnabled = true;
            this.comboBoxOrigin.Location = new System.Drawing.Point(142, 79);
            this.comboBoxOrigin.Name = "comboBoxOrigin";
            this.comboBoxOrigin.Size = new System.Drawing.Size(369, 30);
            this.comboBoxOrigin.TabIndex = 45007;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label1.Location = new System.Drawing.Point(24, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "Origin :";
            // 
            // comboBoxDestination
            // 
            this.comboBoxDestination.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.comboBoxDestination.FormattingEnabled = true;
            this.comboBoxDestination.Location = new System.Drawing.Point(142, 139);
            this.comboBoxDestination.Name = "comboBoxDestination";
            this.comboBoxDestination.Size = new System.Drawing.Size(369, 30);
            this.comboBoxDestination.TabIndex = 45009;
            // 
            // Destination
            // 
            this.Destination.AutoSize = true;
            this.Destination.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.Destination.Location = new System.Drawing.Point(24, 142);
            this.Destination.Name = "Destination";
            this.Destination.Size = new System.Drawing.Size(112, 24);
            this.Destination.TabIndex = 20;
            this.Destination.Text = "Destination :";
            // 
            // numUpDownDist
            // 
            this.numUpDownDist.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.numUpDownDist.Location = new System.Drawing.Point(142, 192);
            this.numUpDownDist.Name = "numUpDownDist";
            this.numUpDownDist.Size = new System.Drawing.Size(120, 28);
            this.numUpDownDist.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label4.Location = new System.Drawing.Point(24, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Distance :";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(297, 252);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(126, 43);
            this.buttonCancel.TabIndex = 45013;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(110, 252);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(126, 43);
            this.buttonSave.TabIndex = 45012;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // EditStretch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 307);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.numUpDownDist);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxDestination);
            this.Controls.Add(this.Destination);
            this.Controls.Add(this.comboBoxOrigin);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditStretch";
            this.ShowIcon = false;
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownDist)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxOrigin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDestination;
        private System.Windows.Forms.Label Destination;
        private System.Windows.Forms.NumericUpDown numUpDownDist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}