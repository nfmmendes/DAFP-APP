using System;
using GMap.NET.WindowsForms;

namespace Prototipo1.Components
{
    partial class MapRoutesView 
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.comboBoxAirplane = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonZoomIn = new System.Windows.Forms.Button();
            this.buttonZoomOut = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonAllPoints = new System.Windows.Forms.RadioButton();
            this.radioButtonSolution = new System.Windows.Forms.RadioButton();
            this.radioButtonAirplane = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // GMapControl
            // 
            this.GMapControl.Bearing = 0F;
            this.GMapControl.CanDragMap = true;
            this.GMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.GMapControl.GrayScaleMode = false;
            this.GMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.GMapControl.LevelsKeepInMemory = 5;
            this.GMapControl.Location = new System.Drawing.Point(29, 67);
            this.GMapControl.MarkersEnabled = true;
            this.GMapControl.MaxZoom = 15;
            this.GMapControl.MinZoom = 2;
            this.GMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.GMapControl.Name = "GMapControl";
            this.GMapControl.NegativeMode = false;
            this.GMapControl.PolygonsEnabled = true;
            this.GMapControl.RetryLoadTile = 0;
            this.GMapControl.RoutesEnabled = true;
            this.GMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.GMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.GMapControl.ShowTileGridLines = false;
            this.GMapControl.Size = new System.Drawing.Size(1130, 423);
            this.GMapControl.TabIndex = 0;
            this.GMapControl.Zoom = 2D;
            this.GMapControl.Scroll += new System.Windows.Forms.ScrollEventHandler(this.GMapControl_Scroll);
            this.GMapControl.DoubleClick += new System.EventHandler(this.GMapControl_DoubleClick);
            // 
            // comboBoxAirplane
            // 
            this.comboBoxAirplane.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.comboBoxAirplane.FormattingEnabled = true;
            this.comboBoxAirplane.Location = new System.Drawing.Point(121, 22);
            this.comboBoxAirplane.Name = "comboBoxAirplane";
            this.comboBoxAirplane.Size = new System.Drawing.Size(200, 30);
            this.comboBoxAirplane.TabIndex = 1;
            this.comboBoxAirplane.SelectedIndexChanged += new System.EventHandler(this.comboBoxAirplane_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label1.Location = new System.Drawing.Point(25, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Airplane :";
            // 
            // buttonZoomIn
            // 
            this.buttonZoomIn.Location = new System.Drawing.Point(445, 17);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(44, 35);
            this.buttonZoomIn.TabIndex = 3;
            this.buttonZoomIn.Text = "+";
            this.buttonZoomIn.UseVisualStyleBackColor = true;
            this.buttonZoomIn.Click += new System.EventHandler(this.buttonZoomIn_Click);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.Location = new System.Drawing.Point(495, 17);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(44, 35);
            this.buttonZoomOut.TabIndex = 4;
            this.buttonZoomOut.Text = "-";
            this.buttonZoomOut.UseVisualStyleBackColor = true;
            this.buttonZoomOut.Click += new System.EventHandler(this.buttonZoomOut_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label2.Location = new System.Drawing.Point(379, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Zoom";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.label3.Location = new System.Drawing.Point(604, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Show";
            // 
            // radioButtonAllPoints
            // 
            this.radioButtonAllPoints.AutoSize = true;
            this.radioButtonAllPoints.Location = new System.Drawing.Point(675, 27);
            this.radioButtonAllPoints.Name = "radioButtonAllPoints";
            this.radioButtonAllPoints.Size = new System.Drawing.Size(86, 21);
            this.radioButtonAllPoints.TabIndex = 7;
            this.radioButtonAllPoints.Text = "All points";
            this.radioButtonAllPoints.UseVisualStyleBackColor = true;
            this.radioButtonAllPoints.CheckedChanged += new System.EventHandler(this.radioButtonAllPoints_CheckedChanged);
            // 
            // radioButtonSolution
            // 
            this.radioButtonSolution.AutoSize = true;
            this.radioButtonSolution.Checked = true;
            this.radioButtonSolution.Location = new System.Drawing.Point(785, 27);
            this.radioButtonSolution.Name = "radioButtonSolution";
            this.radioButtonSolution.Size = new System.Drawing.Size(101, 21);
            this.radioButtonSolution.TabIndex = 8;
            this.radioButtonSolution.TabStop = true;
            this.radioButtonSolution.Text = "On solution";
            this.radioButtonSolution.UseVisualStyleBackColor = true;
            this.radioButtonSolution.CheckedChanged += new System.EventHandler(this.radioButtonSolution_CheckedChanged);
            // 
            // radioButtonAirplane
            // 
            this.radioButtonAirplane.AutoSize = true;
            this.radioButtonAirplane.Location = new System.Drawing.Point(916, 27);
            this.radioButtonAirplane.Name = "radioButtonAirplane";
            this.radioButtonAirplane.Size = new System.Drawing.Size(140, 21);
            this.radioButtonAirplane.TabIndex = 9;
            this.radioButtonAirplane.Text = "On airplane route";
            this.radioButtonAirplane.UseVisualStyleBackColor = true;
            this.radioButtonAirplane.CheckedChanged += new System.EventHandler(this.radioButtonAirplane_CheckedChanged);
            // 
            // MapRoutesView
            // 
            this.Controls.Add(this.radioButtonAirplane);
            this.Controls.Add(this.radioButtonSolution);
            this.Controls.Add(this.radioButtonAllPoints);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonZoomOut);
            this.Controls.Add(this.buttonZoomIn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAirplane);
            this.Controls.Add(this.GMapControl);
            this.Name = "MapRoutesView";
            this.Size = new System.Drawing.Size(1180, 530);
            this.Load += new System.EventHandler(this.MapRoutesView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private GMapControl GMapControl;


        #endregion

        private System.Windows.Forms.ComboBox comboBoxAirplane;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonZoomIn;
        private System.Windows.Forms.Button buttonZoomOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonAllPoints;
        private System.Windows.Forms.RadioButton radioButtonSolution;
        private System.Windows.Forms.RadioButton radioButtonAirplane;
    }
}
