namespace Prototipo1
{
    partial class AddEditSeatType
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
            this.textBoxClass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numUDNumberSeats = new System.Windows.Forms.NumericUpDown();
            this.numUDLuggageWeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUDNumberSeats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDLuggageWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(270, 248);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(126, 43);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(83, 248);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(126, 43);
            this.buttonSave.TabIndex = 14;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label1.Location = new System.Drawing.Point(17, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 24);
            this.label1.TabIndex = 16;
            this.label1.Text = "Class :";
            // 
            // textBoxClass
            // 
            this.textBoxClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.textBoxClass.Location = new System.Drawing.Point(97, 68);
            this.textBoxClass.Name = "textBoxClass";
            this.textBoxClass.Size = new System.Drawing.Size(361, 28);
            this.textBoxClass.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label2.Location = new System.Drawing.Point(17, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 24);
            this.label2.TabIndex = 18;
            this.label2.Text = "Number Of Seats :";
            // 
            // numUDNumberSeats
            // 
            this.numUDNumberSeats.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.numUDNumberSeats.Location = new System.Drawing.Point(231, 132);
            this.numUDNumberSeats.Name = "numUDNumberSeats";
            this.numUDNumberSeats.Size = new System.Drawing.Size(120, 28);
            this.numUDNumberSeats.TabIndex = 2;
            // 
            // numUDLuggageWeight
            // 
            this.numUDLuggageWeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.numUDLuggageWeight.Location = new System.Drawing.Point(231, 194);
            this.numUDLuggageWeight.Name = "numUDLuggageWeight";
            this.numUDLuggageWeight.Size = new System.Drawing.Size(120, 28);
            this.numUDLuggageWeight.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label3.Location = new System.Drawing.Point(17, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 24);
            this.label3.TabIndex = 20;
            this.label3.Text = "Max Luggage Weight:";
            // 
            // AddEditSeatType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 322);
            this.Controls.Add(this.numUDLuggageWeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numUDNumberSeats);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxClass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditSeatType";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            ((System.ComponentModel.ISupportInitialize)(this.numUDNumberSeats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUDLuggageWeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxClass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numUDNumberSeats;
        private System.Windows.Forms.NumericUpDown numUDLuggageWeight;
        private System.Windows.Forms.Label label3;
    }
}