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
            this.SuspendLayout();
            // 
            // GMapControl
            // 
            this.GMapControl.Bearing = 0F;
            this.GMapControl.CanDragMap = true;
            this.GMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.GMapControl.GrayScaleMode = false;
            this.GMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.GMapControl.LevelsKeepInMemmory = 5;
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
            this.GMapControl.Size = new System.Drawing.Size(960, 423);
            this.GMapControl.TabIndex = 0;
            this.GMapControl.Zoom = 2D;
            // 
            // comboBoxAirplane
            // 
            this.comboBoxAirplane.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F);
            this.comboBoxAirplane.FormattingEnabled = true;
            this.comboBoxAirplane.Location = new System.Drawing.Point(121, 22);
            this.comboBoxAirplane.Name = "comboBoxAirplane";
            this.comboBoxAirplane.Size = new System.Drawing.Size(310, 30);
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
            this.buttonZoomIn.Location = new System.Drawing.Point(525, 21);
            this.buttonZoomIn.Name = "buttonZoomIn";
            this.buttonZoomIn.Size = new System.Drawing.Size(44, 35);
            this.buttonZoomIn.TabIndex = 3;
            this.buttonZoomIn.Text = "+";
            this.buttonZoomIn.UseVisualStyleBackColor = true;
            this.buttonZoomIn.Click += new System.EventHandler(this.buttonZoomIn_Click);
            // 
            // buttonZoomOut
            // 
            this.buttonZoomOut.Location = new System.Drawing.Point(575, 21);
            this.buttonZoomOut.Name = "buttonZoomOut";
            this.buttonZoomOut.Size = new System.Drawing.Size(44, 35);
            this.buttonZoomOut.TabIndex = 4;
            this.buttonZoomOut.Text = "-";
            this.buttonZoomOut.UseVisualStyleBackColor = true;
            this.buttonZoomOut.Click += new System.EventHandler(this.buttonZoomOut_Click);
            // 
            // MapRoutesView
            // 
            this.Controls.Add(this.buttonZoomOut);
            this.Controls.Add(this.buttonZoomIn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxAirplane);
            this.Controls.Add(this.GMapControl);
            this.Name = "MapRoutesView";
            this.Size = new System.Drawing.Size(1022, 509);
            this.Load += new System.EventHandler(this.MapRoutesView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MapRoutesView_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private GMapControl GMapControl;


        #endregion

        private System.Windows.Forms.ComboBox comboBoxAirplane;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonZoomIn;
        private System.Windows.Forms.Button buttonZoomOut;
    }
}
