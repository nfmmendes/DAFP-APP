﻿using System;
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
    public partial class FuelPriceView : UserControl
    {
        public CustomSqlContext Context { get; set; }
        public DbInstance Instance { get; set; }


        public FuelPriceView(CustomSqlContext context){
            InitializeComponent();
            Context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void setInstance(DbInstance instance){
            Instance = instance;
            FillFuelTable();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteFuelPrice_Click(object sender, EventArgs e)
        {
            if (dataGridViewFuel.SelectedRows.Count > 0)
            {
                var message = "All information related with these prices will be deleted. Do you want continue?";
                var result = MessageBox.Show(message, "", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < dataGridViewFuel.Rows.Count; i++)
                    {

                        if (!dataGridViewFuel.Rows[i].Selected) continue;

                        var index = Convert.ToInt64(dataGridViewFuel.Rows[i].Cells[0].Value);
                        var deleted = Context.FuelPrice.FirstOrDefault(x => x.Id == index);

                        if (deleted != null)
                            Context.FuelPrice.Remove(deleted);
                    }

                    Context.SaveChanges();
                    
                }
            }
            else
                MessageBox.Show("There are no selected airplanes");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditFuel_Click(object sender, EventArgs e)
        {
  
            if (Instance != null && dataGridViewFuel.SelectedRows.Count > 0)
            {
                var addFuel = new AddEditFuel(Context);
                var index = dataGridViewFuel.SelectedRows[0].Index;

                addFuel.OpenToEdit(Instance, Convert.ToInt64(dataGridViewFuel.Rows[index].Cells[0].Value)); //TODO: Get real id

                FillFuelTable();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        private void FillFuelTable(){
           // this.dataGridViewFuel.Rows.Clear();
            var fuels = Context.FuelPrice.ToList().Where(x => x.Instance.Id == Instance.Id);

            foreach (var item in fuels)
                dataGridViewFuel.Rows.Add(item.Id, item.Airport.AiportName, "F", item.Currency, item.Value); //TODO: Change This F
        }

    }
}
