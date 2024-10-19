using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolverClientComunication;
using SolverClientComunication.Models;

namespace Prototipo1
{
    public partial class AddEditStretch : Form
    {
        private bool IsAdd { get; set; }
        public DbStretch CurrentElement { get; set; }
        public CustomSqlContext Context { get; set; }
        public DbInstance Instance { get; set; }

        public AddEditStretch(CustomSqlContext context){
            InitializeComponent();
            Context = context; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public void OpenToAdd(DbInstance instance){
            Instance = instance;
            IsAdd = true;
            this.ShowDialog();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="airplane"></param>
        public void SetStretch(DbStretch airplane)
        {
            CurrentElement = airplane;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="idSeat"></param>
        public void OpenToEdit(DbInstance instance, long idSeat)
        {
            Instance = instance;
            IsAdd = false;

            CurrentElement = Context.Stretches.FirstOrDefault(x => x.Id == idSeat);

            if (CurrentElement != null)
            {
                this.comboBoxOrigin.Text = CurrentElement.Origin;
                this.comboBoxOrigin.Enabled = false; 
                this.comboBoxDestination.Text = CurrentElement.Destination;
                this.comboBoxDestination.Enabled = false;
                this.numUpDownDist.Value = CurrentElement.Distance;
            }

            this.ShowDialog();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e){

            if (IsAdd){

            }else{
                if (CurrentElement != null){
                    CurrentElement.Distance = Convert.ToInt32(numUpDownDist.Value); 
                    Context.Stretches.Update(CurrentElement);
                }
                Context.SaveChanges();
            }



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
    }
}
