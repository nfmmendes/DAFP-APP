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
    public partial class AddEditSeatType : Form
    {
        private bool IsAdd { get; set; }
        public DbSeats CurrentElement { get; set; }
        public CustomSqlContext Context { get; set; }
        public DbInstance Instance { get; set; }

        public AddEditSeatType(CustomSqlContext context)
        {
            InitializeComponent();
            Context = context; 
        }

        public void OpenToAdd(DbInstance instance){
            Instance = instance;
            IsAdd = true;
            this.ShowDialog();
            
        }

        public void OpenToEdit(DbInstance instance, long idSeat)
        {
            Instance = instance;
            IsAdd = false;

            CurrentElement = Context.SeatList.FirstOrDefault(x => x.Id == idSeat);

            if (CurrentElement != null){
                this.textBoxClass.Text = CurrentElement.seatClass;
                this.numUDNumberSeats.Value = CurrentElement.numberOfSeats;
                this.numUDLuggageWeight.Value = Convert.ToDecimal(CurrentElement.luggageWeightLimit);
            }

            this.ShowDialog();
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
