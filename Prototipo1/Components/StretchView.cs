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
    public partial class StretchView : UserControl
    {
        public CustomSqlContext Context { get; set; }
        public DbInstance Instance { get; set; }
        private int CountStretchesPage { get; set; }
        private int StretchePageSize { get; set; }

        public StretchView(CustomSqlContext context){
            InitializeComponent();
            Context = context;
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

            var totalSize = Context.Stretches.Count(x => x.Origin != null && x.Origin.Instance.Id == Instance.Id);

            var firstPageSize = Math.Min(StretchePageSize, totalSize);
            var listOfStretches = Context.Stretches.Where(x => x.Origin != null && x.Origin.Instance.Id == Instance.Id).ToList();

            for (int i = 0; i <= firstPageSize; i++)
                dataGridViewStretches.Rows.Add(listOfStretches[i].Id, listOfStretches[i].Origin.AiportName,
                                               listOfStretches[i].Destination.AiportName, listOfStretches[i].Distance);

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


            var totalSize = Context.Stretches.Count(x => x.Origin != null && x.Origin.Instance.Id == Instance.Id);

            var listOfStretches = Context.Stretches.Where(x => x.Origin != null && x.Origin.Instance.Id == Instance.Id).ToList();

            if (CountStretchesPage > 1)
            {
                dataGridViewStretches.Rows.Clear();

                CountStretchesPage--;
                var firstIndex = StretchePageSize * (CountStretchesPage - 1);
                var lastIndex = Math.Min(firstIndex + StretchePageSize, totalSize);

                for (int i = firstIndex; i <= lastIndex; i++)
                    dataGridViewStretches.Rows.Add(listOfStretches[i].Id, listOfStretches[i].Origin.AiportName,
                        listOfStretches[i].Destination.AiportName, listOfStretches[i].Distance);

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
            

            var totalSize = Context.Stretches.Count(x => x.Origin != null && x.Origin.Instance.Id == Instance.Id);

            var listOfStretches = Context.Stretches.Where(x => x.Origin != null && x.Origin.Instance.Id == Instance.Id).ToList();

            if (CountStretchesPage <= (int)(listOfStretches.Count() / StretchePageSize))
            {
                dataGridViewStretches.Rows.Clear();

                var firstIndex = StretchePageSize * CountStretchesPage;
                var lastIndex = Math.Min(firstIndex + StretchePageSize, totalSize);

                CountStretchesPage++;

                for (int i = firstIndex; i < lastIndex; i++)
                    dataGridViewStretches.Rows.Add(listOfStretches[i].Id, listOfStretches[i].Origin.AiportName,
                        listOfStretches[i].Destination.AiportName, listOfStretches[i].Distance);

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

            var totalSize = Context.Stretches.Count(x => x.Origin != null && x.Origin.Instance.Id == Instance.Id);
            var firstLastPageIndex = totalSize - (totalSize % StretchePageSize);
            var listOfStretches = Context.Stretches.Where(x => x.Origin != null && x.Origin.Instance.Id == Instance.Id).ToList();

            dataGridViewStretches.Rows.Clear();



            for (int i = firstLastPageIndex; i < totalSize; i++)
                try
                {
                    dataGridViewStretches.Rows.Add(listOfStretches[i].Id, listOfStretches[i].Origin.AiportName,
                        listOfStretches[i].Destination.AiportName, listOfStretches[i].Distance);
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
            var stretches = Context.Stretches.ToList().Where(x => x.Origin.Instance.Id == Instance.Id);
            int cont = 0;
            CountStretchesPage = 1;
            labelPageStretch.Text = $"{CountStretchesPage} of {(int)(stretches.Count() / StretchePageSize + 1)}";
            foreach (var item in stretches)
            {
                dataGridViewStretches.Rows.Add(item.Id, item.Origin.AiportName, item.Destination.AiportName, item.Distance);
                cont++;
                if (cont == StretchePageSize)
                    break;
            }

        }



    }
}
