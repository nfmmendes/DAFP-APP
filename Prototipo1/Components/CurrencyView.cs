using System;
using System.Data;
using System.Linq;
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
        /// Fill the currency table with the data of a specific instance
        /// </summary>
        /// <param name="instance"></param>
        private void FillCurrencyTable(){

            this.dataGridViewCurrency.Rows.Clear();
            if (Context.Exchange.Any()){
                var exchanges = Context.Exchange.Where(x => x.Instance.Id == Instance.Id);

                foreach (var item in exchanges)
                    this.dataGridViewCurrency.Rows.Add(item.Id, item.CurrencyName, item.CurrencySymbol, item.ValueInDolar);
            }
            
        }

        /// <summary>
        /// Add a currency to the instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddCurrency_Click(object sender, EventArgs e){
            var add = new AddEditCurrency();
            add.OpenToAdd(Instance);
            FillCurrencyTable();
        }

        /// <summary>
        /// Edit a currency on the instance
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditCurrency_Click(object sender, EventArgs e){
            if (dataGridViewCurrency.SelectedRows.Count > 0){
                var first = dataGridViewCurrency.SelectedRows[0].Index;
                var index = Convert.ToInt64(dataGridViewCurrency.Rows[first].Cells[0].Value);
                
                var element = Context.Exchange.FirstOrDefault(x => x.Id == index);
                if (element != null){
                    var edit = new AddEditCurrency();
                    edit.OpenToEdit(element,index);
                }
                FillCurrencyTable();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteCurrency_Click(object sender, EventArgs e){
            if (dataGridViewCurrency.SelectedRows.Count > 0){
                var first = dataGridViewCurrency.SelectedRows[0].Index;
                var index = Convert.ToInt64(dataGridViewCurrency.Rows[first].Cells[0].Value);

                Context.Exchange.Remove(Context.Exchange.First(x => x.Id == index));
                Context.SaveChanges();
            }
            FillCurrencyTable();
        }

        private void CurrencyView_Load(object sender, EventArgs e){
            FillCurrencyTable();
        }
    }
}
