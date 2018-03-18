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

namespace Prototipo1.Components
{
    public partial class RequestsView : UserControl
    {
        public CustomSqlContext Context { get; set; }
        public DbInstance Instance { get; set; }

        public RequestsView(){
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void setInstance(DbInstance instance)
        {
            Instance = instance;
            FillRequestTables();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        private void FillRequestTables()
        {
            this.dataGridViewRequest.Rows.Clear();
            var requests = Context.Requests.ToList().Where(x => x.Instance.Id == Instance.Id)
                .GroupBy(x => x.PNR).ToDictionary(x => x.Key, x => x.ToList());

            foreach (var key in requests.Keys)
            {
                var value = requests[key].First();
                dataGridViewRequest.Rows.Add(key, key, value.Origin.AiportName, value.Destination?.AiportName, value.DepartureTimeWindowBegin,
                    value.DepartureTimeWindowEnd, value.ArrivalTimeWindowBegin, value.ArrivalTimeWindowEnd);
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewRequest_RowEnter(object sender, DataGridViewCellEventArgs e){
            FillPassengerList(dataGridViewRequest.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        /// <summary>
        /// Fill the data grid view that shows the list of passengers. 
        /// This function will be called after a row of the request data grid view be selected
        /// </summary>
        /// <param name="PNR"></param>
        private void FillPassengerList(string PNR){
            this.dataGridViewPassenger.Rows.Clear();
            var passengers = Context.Requests.Where(x =>Instance.Id == x.Instance.Id &&  x.PNR.Equals(PNR));

            foreach (var item in passengers){
                this.dataGridViewPassenger.Rows.Add(item.Id, item.Name, item.Sex, item.IsChildren, item.Class);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditRequest_Click(object sender, EventArgs e){
            
            if (Instance != null && dataGridViewRequest.SelectedRows.Count > 0){
                var editRequest = new AddEditRequest();
                var rowIndex = dataGridViewRequest.SelectedRows[0].Index;

                editRequest.OpenToEdit(Instance, dataGridViewRequest.Rows[rowIndex].Cells[0].Value.ToString());
            }
        }
    }
}
