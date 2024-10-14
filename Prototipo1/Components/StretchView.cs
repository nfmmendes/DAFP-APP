using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SolverClientComunication;
using SolverClientComunication.Models;
using System.Threading;
using System.Device.Location;

namespace Prototipo1.Components
{
    public partial class StretchView : UserControl
    {
        public CustomSqlContext Context { get; set; }
        public DbInstance Instance { get; set; }
        private int CountStretchesPage { get; set; }
        private int StretchePageSize { get; set; }
        private List<Tuple<long, string, string, int>> RowsCache { get; set; }

        public StretchView(){
            InitializeComponent();
            CountStretchesPage = 1;
            StretchePageSize = 200;
            RowsCache = new List<Tuple<long, string, string, int>>();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void setInstance(DbInstance instance){
            Instance = instance;

            var listOfStretches = Context.Stretches.ToList().Where(x => x.Origin != null && x.InstanceId == Instance.Id).ToList();
            RowsCache.Clear();
            foreach (var item in listOfStretches)
                RowsCache.Add( new Tuple<long, string, string, int>( item.Id, item.Origin, item.Destination, item.Distance));

            FillStretchTable();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonFirstPageStretch_Click(object sender, EventArgs e) {

            dataGridViewStretches.Rows.Clear();

            var totalSize = RowsCache.Count;

            var firstPageSize = Math.Min(StretchePageSize, totalSize);
            //var listOfStretches = Context.Stretches.Where(x => x.Origin != null && x.InstanceId == Instance.Id).ToList();

            for (int i = 0; i <= firstPageSize; i++)
                dataGridViewStretches.Rows.Add(RowsCache[i].Item1, RowsCache[i].Item2,RowsCache[i].Item3, RowsCache[i].Item4);

            CountStretchesPage = 1;
            labelPageStretch.Text = $"{CountStretchesPage} of {(int)(RowsCache.Count/ StretchePageSize + 1)}";

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonPrevPageStretch_Click(object sender, EventArgs e){

            var totalSize = RowsCache.Count;

            //var listOfStretches = Context.Stretches.Where(x => x.Origin != null && x.InstanceId == Instance.Id).ToList();

            if (CountStretchesPage > 1)
            {
                dataGridViewStretches.Rows.Clear();

                CountStretchesPage--;
                var firstIndex = StretchePageSize * (CountStretchesPage - 1);
                var lastIndex = Math.Min(firstIndex + StretchePageSize, totalSize);

                for (int i = firstIndex; i <= lastIndex; i++)
                    dataGridViewStretches.Rows.Add(RowsCache[i].Item1, RowsCache[i].Item2, RowsCache[i].Item3, RowsCache[i].Item4);

                labelPageStretch.Text = $"{CountStretchesPage} of {(int)(RowsCache.Count / StretchePageSize + 1)}";
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNextPageStretch_Click(object sender, EventArgs e)
        {
            if (CountStretchesPage <= (int)(RowsCache.Count() / StretchePageSize))
            {
                dataGridViewStretches.Rows.Clear();

                var firstIndex = StretchePageSize * CountStretchesPage;
                var lastIndex = Math.Min(firstIndex + StretchePageSize, RowsCache.Count);

                CountStretchesPage++;

                for (int i = firstIndex; i < lastIndex; i++)
                    dataGridViewStretches.Rows.Add(RowsCache[i].Item1, RowsCache[i].Item2, RowsCache[i].Item3, RowsCache[i].Item4);

                labelPageStretch.Text = $"{CountStretchesPage} of {(int)(RowsCache.Count / StretchePageSize + 1)}";
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
                            Distance = (int)distance/1000,
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StretchView_Load(object sender, EventArgs e){
            FillStretchTable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPageSize_SelectedIndexChanged(object sender, EventArgs e){
            StretchePageSize = Convert.ToInt32(comboBoxPageSize.SelectedItem.ToString());
            FillStretchTable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEdit_Click(object sender, EventArgs e){

            if (dataGridViewStretches.SelectedRows.Count > 0){
                var id = Convert.ToInt64(dataGridViewStretches.SelectedRows[0].Cells[0].Value);
                var editStretch = new AddEditStretch(Context);
                editStretch.OpenToEdit(Instance, id);
                FillStretchTable();
            }else
                MessageBox.Show("Select a segment on the table!!");
            
        }
    }
}
