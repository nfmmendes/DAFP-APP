using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1.Components
{
    public partial class MapRoutesView : UserControl
    {

        private DbInstance Instance { get; set; }
        public CustomSqlContext Context;
        private static Regex Parser = new Regex("^(?<deg>[-+0-9]+)[^0-9]+(?<min>[0-9]+)[^0-9]+(?<sec>[0-9.,]+)[^0-9.,ENSW]+(?<pos>[ENSW]*)$");

        public MapRoutesView(){
            InitializeComponent();

        }

        public void setInstance(DbInstance instance){
            Instance = instance;
            GMapControl.Overlays.Clear();
            setOverlayMarker();
            this.comboBoxAirplane.DataSource = Context.Airplanes.Where(x => x.Instance.Id == Instance.Id).Select(x=>x.Prefix).ToList();

        }

        private void setOverlayMarker(){
            GMapOverlay markers = new GMapOverlay("markers");


            if (Context.Instances.Any())
            {
                var airportsList = Context.Airports.Where(x => x.Instance.Id == Instance.Id);
                foreach (var item in airportsList)
                {
                    Debug.Write(item.Latitude);
                    var _lat = TransformCoordinate(item.Latitude);
                    Debug.Write(item.Longitude);
                    var _long = TransformCoordinate(item.Longitude);


                    var newMarker = new GMarkerGoogle(new PointLatLng(_lat, _long), GMarkerGoogleType.red_small);
                    newMarker.ToolTip = new GMapToolTip(newMarker);
                    newMarker.ToolTip.Fill = new SolidBrush(Color.White);
                    newMarker.ToolTipText = item.AiportName;

                    markers.Markers.Add(newMarker);
                }
            }

            GMapControl.Overlays.Add(markers);
        }


        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapRoutesView_Load(object sender, EventArgs e)
        {
            //use google provider
            GMapControl.MapProvider = GoogleMapProvider.Instance;
            //get tiles from server only
            GMapControl.Manager.Mode = AccessMode.ServerOnly;
            
            
            //center map on moscow
            GMapControl.Position = new PointLatLng(-6.816330, 39.276638);
            
            //set zoom
            GMapControl.Zoom = 5;
            GMapControl.DragButton = MouseButtons.Left;

            setOverlayMarker();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        private double TransformCoordinate(string coordinate){

            if(!coordinate.Contains("''"))
                coordinate = coordinate.Replace("'","'00''");

            // If it starts and finishes with a quote, strip them off
            if (coordinate.StartsWith("\"") && coordinate.EndsWith("\""))
            {
                coordinate = coordinate.Substring(1, coordinate.Length - 2).Replace("\"\"", "\"");
            }

            // Now parse using the regex parser
            Match match = Parser.Match(coordinate);
            if (!match.Success)
            {

               // throw new ArgumentException(string.Format(CultureInfo.CurrentUICulture,
               //     "Lat/long value of '{0}' is not recognised", coordinate));
               Debug.Write("\t0\n");
                return 0;
            }else{

                // Convert - adjust the sign if necessary
                double deg = double.Parse(match.Groups["deg"].Value);
                double min = double.Parse(match.Groups["min"].Value);
                double sec = double.Parse(match.Groups["sec"].Value);
                double result = deg + (min / 60) + (sec / 3600);
                if (match.Groups["pos"].Success)
                {
                    if (match.Groups["pos"].Value != ""){
                        char ch = match.Groups["pos"].Value[0];
                        result = ((ch == 'S') || (ch == 'W')) ? -result : result;
                    }
                }
                Debug.Write($"\t{result}\n");
                return result;
            }

           
            
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxAirplane_SelectedIndexChanged(object sender, EventArgs e){
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapRoutesView_KeyDown(object sender, KeyEventArgs e){
            var _lat = GMapControl.Position.Lat;
            var _long = GMapControl.Position.Lng;

            if (e.KeyCode.Equals(Keys.Up))
                GMapControl.Position = new PointLatLng(_lat + 0.05, _long);
            else if (e.KeyCode.Equals(Keys.Down))
                GMapControl.Position = new PointLatLng(_lat - 0.05, _long);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonZoomIn_Click(object sender, EventArgs e){
            GMapControl.Zoom += 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonZoomOut_Click(object sender, EventArgs e){
            GMapControl.Zoom -= 1;
        }

        private void GMapControl_DoubleClick(object sender, EventArgs e){
            GMapControl.Zoom += 0.25;
        }

        private void GMapControl_Scroll(object sender, ScrollEventArgs e){
            if(e.OldValue > e.NewValue)
                GMapControl.Zoom += 0.5;
            else 
                GMapControl.Zoom -= 0.5;
        }
    }
}
