using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1
{
    public partial class ImportDataLog : Form
    {

        public CustomSqlContext Context { get; set;  }

        public ImportDataLog(CustomSqlContext context, DbInstance instance = null){
            Context = context;
            InitializeComponent();
        }

        /// <summary>
        /// Parser of the instance metadata to a string 
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private string shortInstanceDescription(DbInstance x){
            return $"{x.Name} ({x.CreatedOn.ToString("dd/MM/yy hh:mm")}) {(x.Optimized ? "Opt" : "NotOpt")}";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e){

        }
    }
}
