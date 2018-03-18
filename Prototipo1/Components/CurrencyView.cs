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
    public partial class CurrencyView : UserControl
    {
        public CustomSqlContext Context { get; set; }
        public DbInstance Instance { get; set; }


        public CurrencyView(){
            InitializeComponent();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void setInstance(DbInstance instance){
            Instance = instance;
            FillCurrencyTable();

        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        private void FillCurrencyTable(){

            this.dataGridViewCurrency.Rows.Clear();
            var exchanges = Context.Exchange.Where(x => x.Instance.Id == Instance.Id);

            foreach (var item in exchanges)
            {
                this.dataGridViewCurrency.Rows.Add(item.Id, item.CurrencyName, item.CurrencySymbol, item.ValueInDolar);
            }
        }
    }
}
