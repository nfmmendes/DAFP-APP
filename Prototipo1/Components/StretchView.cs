using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolverClientComunication;
using SolverClientComunication.Models;
using System.Device.Location;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;

namespace Prototipo1.Components
{
    public partial class StretchView : UserControl
    {
        public CustomSqlContext Context { get; set; }
        public DbInstance Instance { get; set; }
        private int CountStretchesPage { get; set; }
        private int StretchePageSize { get; set; }

        public StretchView(){
            InitializeComponent();
            CountStretchesPage = 1;
            StretchePageSize = 5000;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void setInstance(DbInstance instance){
            Instance = instance;
            FillStretchTable();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFirstPageStretch_Click(object sender, EventArgs e)
        {

            dataGridViewStretches.Rows.Clear();

            var totalSize = Context.Stretches.Count(x => x.Origin != null && x.InstanceId == Instance.Id);

            var firstPageSize = Math.Min(StretchePageSize, totalSize);
            var listOfStretches = Context.Stretches.Where(x => x.Origin != null && x.InstanceId == Instance.Id).ToList();

            for (int i = 0; i <= firstPageSize; i++)
                dataGridViewStretches.Rows.Add(listOfStretches[i].Id, listOfStretches[i].Origin,listOfStretches[i].Destination, listOfStretches[i].Distance);

            CountStretchesPage = 1;
            labelPageStretch.Text = $"{CountStretchesPage} of {(int)(listOfStretches.Count() / StretchePageSize + 1)}";

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrevPageStretch_Click(object sender, EventArgs e)
        {


            var totalSize = Context.Stretches.Count(x => x.Origin != null && x.InstanceId == Instance.Id);

            var listOfStretches = Context.Stretches.Where(x => x.Origin != null && x.InstanceId == Instance.Id).ToList();

            if (CountStretchesPage > 1)
            {
                dataGridViewStretches.Rows.Clear();

                CountStretchesPage--;
                var firstIndex = StretchePageSize * (CountStretchesPage - 1);
                var lastIndex = Math.Min(firstIndex + StretchePageSize, totalSize);

                for (int i = firstIndex; i <= lastIndex; i++)
                    dataGridViewStretches.Rows.Add(listOfStretches[i].Id, listOfStretches[i].Origin,listOfStretches[i].Destination, listOfStretches[i].Distance);

                labelPageStretch.Text = $"{CountStretchesPage} of {(int)(listOfStretches.Count() / StretchePageSize + 1)}";
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNextPageStretch_Click(object sender, EventArgs e)
        {
            

            var totalSize = Context.Stretches.Count(x => x.Origin != null && x.InstanceId == Instance.Id);

            var listOfStretches = Context.Stretches.Where(x => x.Origin != null && x.InstanceId == Instance.Id).ToList();

            if (CountStretchesPage <= (int)(listOfStretches.Count() / StretchePageSize))
            {
                dataGridViewStretches.Rows.Clear();

                var firstIndex = StretchePageSize * CountStretchesPage;
                var lastIndex = Math.Min(firstIndex + StretchePageSize, totalSize);

                CountStretchesPage++;

                for (int i = firstIndex; i < lastIndex; i++)
                    dataGridViewStretches.Rows.Add(listOfStretches[i].Id, listOfStretches[i].Origin,listOfStretches[i].Destination, listOfStretches[i].Distance);

                labelPageStretch.Text = $"{CountStretchesPage} of {(int)(listOfStretches.Count() / StretchePageSize + 1)}";
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonLastPageStretch_Click(object sender, EventArgs e)
        {

            var totalSize = Context.Stretches.Count(x => x.Origin != null && x.InstanceId == Instance.Id);
            var firstLastPageIndex = totalSize - (totalSize % StretchePageSize);
            var listOfStretches = Context.Stretches.Where(x => x.Origin != null && x.InstanceId == Instance.Id).ToList();

            dataGridViewStretches.Rows.Clear();



            for (int i = firstLastPageIndex; i < totalSize; i++)
                try
                {
                    dataGridViewStretches.Rows.Add(listOfStretches[i].Id, listOfStretches[i].Origin,listOfStretches[i].Destination, listOfStretches[i].Distance);
                }
                catch (Exception ex) { }

            CountStretchesPage = listOfStretches.Count() / StretchePageSize + 1;
            labelPageStretch.Text = $"{CountStretchesPage} of {(int)(listOfStretches.Count() / StretchePageSize + 1)}";

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        private void FillStretchTable()
        {
            this.dataGridViewStretches.Rows.Clear();
            var stretches = Context.Stretches.ToList().Where(x => x.InstanceId == Instance.Id);
            int cont = 0;
            CountStretchesPage = 1;
            labelPageStretch.Text = $"{CountStretchesPage} of {(int)(stretches.Count() / StretchePageSize + 1)}";
            foreach (var item in stretches)
            {
                dataGridViewStretches.Rows.Add(item.Id, item.Origin, item.Destination, item.Distance);
                cont++;
                if (cont == StretchePageSize)
                    break;
            }

        }

        private void buttonDistances_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("This function will clear all the distance current data and replace it " +
                                         "by straight line distances. Do you want continue?", "",MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes){
                dataGridViewStretches.Rows.Clear();
                dataGridViewStretches.Refresh();
                Context.Stretches.RemoveRange(Context.Stretches.Where(x => x.InstanceId == Instance.Id));
                Context.SaveChanges();

                Thread.Sleep(5000);

                var airports = Context.Airports.Where(x => x.Instance.Id == Instance.Id);

                var coordinatesByName = airports.ToDictionary(x => x.AirportName, x => new KeyValuePair<string, string>(x.Latitude,x.Longitude));

                var doubleCoordinatesByName = new Dictionary<string, KeyValuePair<double,double>>();

                foreach (var item in coordinatesByName){
                    var latitude = MapRoutesView.TransformCoordinate(item.Value.Key);
                    var longitude = MapRoutesView.TransformCoordinate(item.Value.Value);

                    doubleCoordinatesByName[item.Key] = new KeyValuePair<double, double>(latitude, longitude);
                }
                Context.Configuration.AutoDetectChangesEnabled = false;    //This is done to make the procedure quicker
                //It need to be set to true in the end of procedure
                foreach (var origin in doubleCoordinatesByName.Keys){
                    foreach (var destination in doubleCoordinatesByName.Keys){

                        if(origin.Equals(destination))
                            continue;
                        var distance = calculateDistance(doubleCoordinatesByName[origin], doubleCoordinatesByName[destination]);

                        var item = new DbStretches(){
                            Distance = (int)distance,
                            Origin = origin,
                            Destination = destination,
                            InstanceId = Instance.Id
                        };

                        Context.Stretches.Add(item);
                    }
                    Context.SaveChanges();
                }
                Context.Configuration.AutoDetectChangesEnabled = true;    //This is done to make the procedure quicker
                                                                          //It need to be set to true in the end of procedure
                FillStretchTable();
            }

        }


        private double calculateDistance(KeyValuePair<double, double> origin, KeyValuePair<double, double> destination)
        {
            var latOrigin = origin.Key;
            var longOrigin = origin.Value;
            var latDestination = destination.Key;
            var longDestination = destination.Value;

            var sCoord = new GeoCoordinate(latOrigin, longOrigin);
            var eCoord = new GeoCoordinate(latDestination, longDestination);

            return sCoord.GetDistanceTo(eCoord);


        }
    }
}
