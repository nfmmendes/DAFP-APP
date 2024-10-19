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
    public partial class AddEditSeatType : Form
    {
        private bool IsAdd { get; set; }
        public DbSeats CurrentElement { get; set; }
        private DbAirplanes Airplane { get; set; }
        public CustomSqlContext Context { get; set; }
        public DbInstance Instance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public AddEditSeatType(CustomSqlContext context)
        {
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
        public void SetAirplane(DbAirplanes airplane){
            Airplane = airplane;
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

            CurrentElement = Context.SeatList.FirstOrDefault(x => x.Id == idSeat);

            if (CurrentElement != null){
                this.textBoxClass.Text = CurrentElement.seatClass;
                this.numUDLuggageWeight.Value = Convert.ToDecimal(CurrentElement.luggageWeightLimit);
            }

            this.ShowDialog();
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, EventArgs e){

            if (string.IsNullOrEmpty(this.textBoxClass.Text)) { 
                MessageBox.Show("You need enter the seat class!");
                return; 
            }

            if (IsAdd){
                if(Context.SeatList.Any(x =>x.seatClass.Equals(this.textBoxClass.Text) && x.Airplanes.Id == Airplane.Id))
                    return;

                var item = new DbSeats(){
                    seatClass = this.textBoxClass.Text,
                    Airplanes = this.Airplane,
                    luggageWeightLimit = Convert.ToDouble(this.numUDLuggageWeight.Value),
                };

                Context.SeatList.Add(item);
                Context.SaveChanges();

            }else
            {
                var idSeats = CurrentElement.Id;
                var seat = Context.SeatList.FirstOrDefault(x => x.Id == idSeats);

                seat.luggageWeightLimit = Convert.ToDouble(numUDLuggageWeight.Value);
                seat.seatClass = textBoxClass.Text;

                Context.SeatList.Update(seat);
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
