using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prototipo1.Controller;
using SolverClientComunication.Models;

namespace Prototipo1
{
    public partial class AddEditCurrency : Form
    {
        private bool isAdd;
        private long IdItem { get; set; }
        public DbInstance Instance { get; set;  }

        /// <summary>
        /// 
        /// </summary>
        public AddEditCurrency(){
            InitializeComponent();
            isAdd = true; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e){

            var item = new DbExchangeRates(){
                CurrencyName = textBoxCurrencyName.Text,
                CurrencySymbol = textBoxSymbol.Text,
                ValueInDolar = Convert.ToDouble(textBoxValue.Text),
                Instance = this.Instance
            };

            if(isAdd)
                ExchangeRatesController.Instance.Add(item);
            else
                ExchangeRatesController.Instance.Edit(item, IdItem);

            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, EventArgs e){
            this.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="itemId"></param>
        public void OpenToEdit(DbExchangeRates item, long itemId){

            isAdd = false;
            IdItem = itemId;
            textBoxCurrencyName.Text = item.CurrencyName;
            textBoxSymbol.Text = item.CurrencySymbol;
            textBoxValue.Text = item.ValueInDolar.ToString();

            this.ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        public void OpenToAdd(DbInstance instance){
            Instance = instance; 
            this.ShowDialog();

        }
    }
}
