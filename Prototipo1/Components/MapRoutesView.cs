using System;
using System.Collections;
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
        public CustomSqlContext Context { get; set; }
        private static Regex Parser = new Regex("^(?<deg>[-+0-9]+)[^0-9]+(?<min>[0-9]+)[^0-9]+(?<sec>[0-9.,]+)[^0-9.,ENSW]+(?<pos>[ENSW]*)$");

        public MapRoutesView(){
            InitializeComponent();

        }

        public void setInstance(DbInstance instance){
            Instance = instance;
            GMapControl.Overlays.Clear();
            radioButtonAllPoints.Checked = true;
            comboBoxAirplane.DataSource = null; 
            if (instance == null)
                return; 

            if (Instance.Optimized){
                if(Context.FlightsReports.Any())
                    this.comboBoxAirplane.DataSource = Context.FlightsReports.Where(x => x.Instance.Id == instance.Id)
                                                                  .Select(x => x.Airplanes.Prefix).Distinct().ToList();
            }else{
                if(Context.Airplanes.Any())
                    this.comboBoxAirplane.DataSource = Context.Airplanes.Where(x => x.Instance.Id == Instance.Id).Select(x => x.Prefix).ToList();
            }
             

        }

        private void setOverlayMarker(List<DbAirports> airportsList){
            GMapOverlay markers = new GMapOverlay("markers");
            GMapControl.Overlays.Clear();

            if (Context.Instances.Any()){
                foreach (var item in airportsList){

                    Debug.Write(item.Latitude);
                    var _lat = TransformCoordinate(item.Latitude);
                    Debug.Write(item.Longitude);
                    var _long = TransformCoordinate(item.Longitude);

                    var newMarker = new GMarkerGoogle(new PointLatLng(_lat, _long), GMarkerGoogleType.red_small);
                    newMarker.ToolTip = new GMapToolTip(newMarker);
                    newMarker.ToolTip.Fill = new SolidBrush(Color.White);
                    newMarker.ToolTipText = item.AirportName;

                    markers.Markers.Add(newMarker);
                }
            }

            GMapControl.Overlays.Add(markers);

            if (radioButtonAirplane.Checked || radioButtonSolution.Checked){
                GMapOverlay polyOverlay = new GMapOverlay("polygons");


                var flights = new List<DbFlightsReport>();

                if (radioButtonSolution.Checked){
                    flights = Context.FlightsReports.Where(x => x.Instance.Id == Instance.Id).ToList();
                }else{
                    var airplane = Context.Airplanes.FirstOrDefault(x => x.Prefix.Equals(comboBoxAirplane.SelectedItem.ToString()) &&
                                                                         x.Instance.Id == Instance.Id);
                    if(airplane!= null)
                       flights = Context.FlightsReports.Where(x => x.Instance.Id == Instance.Id && x.Airplanes.Id == airplane.Id).ToList();

                }
                    

                foreach (var item in flights){
                    var points = new List<PointLatLng>();
                    points.Add(new PointLatLng(TransformCoordinate(item.Origin.Latitude), TransformCoordinate(item.Origin.Longitude)));
                    points.Add(new PointLatLng(TransformCoordinate(item.Destination.Latitude), TransformCoordinate(item.Destination.Longitude)));
                    points.Add(new PointLatLng(TransformCoordinate(item.Origin.Latitude), TransformCoordinate(item.Origin.Longitude)));
                    GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
                    polygon.Stroke = new Pen(Color.Red, 1);
                    polyOverlay.Polygons.Add(polygon);
                }

                /*
                points.Add(new PointLatLng(-25.969562, 32.585789));
                points.Add(new PointLatLng(-25.966205, 32.588171));
                points.Add(new PointLatLng(-25.968134, 32.591647));
                points.Add(new PointLatLng(-25.971684, 32.589759));
                GMapPolygon polygon = new GMapPolygon(points, "mypolygon");
                polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
                polygon.Stroke = new Pen(Color.Red, 1);
                polyOverlay.Polygons.Add(polygon);
                */
                GMapControl.Overlays.Add(polyOverlay);
            }
            

        }


        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MapRoutesView_Load(object sender, EventArgs e){
            //use google provider
            GMapControl.MapProvider = GoogleMapProvider.Instance;
            //get tiles from server only
            GMapControl.Manager.Mode = AccessMode.ServerOnly;
            
            
            //center map on moscow
            GMapControl.Position = new PointLatLng(-6.816330, 39.276638);
            
            //set zoom
            GMapControl.Zoom = 5;
            GMapControl.DragButton = MouseButtons.Left;

            radioButtonAllPoints.Checked = true;

            if (Instance == null)
                return;

            if (Instance.Optimized){
                if (Context.FlightsReports.Any())
                    this.comboBoxAirplane.DataSource = Context.FlightsReports.Where(x => x.Instance.Id == Instance.Id)
                        .Select(x => x.Airplanes.Prefix).Distinct().ToList();
            }else{
                if (Context.Airplanes.Any())
                    this.comboBoxAirplane.DataSource = Context.Airplanes.Where(x => x.Instance.Id == Instance.Id).Select(x => x.Prefix).ToList();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        public static double TransformCoordinate(string coordinate){

            if(!coordinate.Contains("''"))
                coordinate = coordinate.Replace("'","'00''");

            // If it starts and finishes with a quote, strip them off
            if (coordinate.StartsWith("\"") && coordinate.EndsWith("\"")){
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
            if(radioButtonAirplane.Checked)
                DrawAirportsOnAirplaneRoute();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GMapControl_DoubleClick(object sender, EventArgs e){
            GMapControl.Zoom += 0.25;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GMapControl_Scroll(object sender, ScrollEventArgs e){
            if(e.OldValue > e.NewValue)
                GMapControl.Zoom += 0.5;
            else 
                GMapControl.Zoom -= 0.5;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonAllPoints_CheckedChanged(object sender, EventArgs e){
            if (radioButtonAllPoints.Checked && Context.Airports.Any())
            {
                setOverlayMarker(Context.Airports.Where(x => x.Instance.Id == Instance.Id).ToList());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonSolution_CheckedChanged(object sender, EventArgs e){
            if (radioButtonSolution.Checked){
                var airports = Context.FlightsReports.Where(x => x.Instance.Id == Instance.Id).Select(x=>x.Origin).Distinct().ToList();
                airports = Context.FlightsReports.Where(x => x.Instance.Id == Instance.Id).Select(x => x.Destination).Distinct().ToList();

                airports = airports.Distinct().ToList();
                setOverlayMarker(airports);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonAirplane_CheckedChanged(object sender, EventArgs e){
            if (radioButtonAirplane.Checked)
                DrawAirportsOnAirplaneRoute();
            
        }

        /// <summary>
        /// 
        /// </summary>
        void DrawAirportsOnAirplaneRoute(){
            if (comboBoxAirplane.SelectedItem != null){

                var airplane = Context.Airplanes.FirstOrDefault(x => x.Prefix.Equals(comboBoxAirplane.SelectedItem.ToString()) &&
                                                                     x.Instance.Id == Instance.Id);

                if (airplane != null){
                    var airports = Context.FlightsReports.Where(x => x.Airplanes.Id == airplane.Id)
                        .Select(x => x.Origin).Distinct().ToList();
                    airports = Context.FlightsReports.Where(x => x.Airplanes.Id == airplane.Id).Select(x => x.Destination).Distinct().ToList();

                    airports = airports.Distinct().ToList();
                    setOverlayMarker(airports);
                }
            }
        }
    }
}
