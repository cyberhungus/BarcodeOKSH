using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeOKSH
{
    public partial class ReservationForm : Form
    {
       Person activeuser;
        SQLGetter dataGetter; 
        List<LendingObject> lendingObjects;
        public ReservationForm(string userid)
        {
            InitializeComponent();
            dataGetter = new SQLGetter();
            activeuser = dataGetter.selectPersonByID(userid)[0];
            ReservationBox.Text = "Vormerken für " + activeuser.getFullName();
            ReserveFromTimePicker.Value = DateTime.Now.AddDays(7);
            ReturnDateTimePicker.Value = DateTime.Now.AddDays(14);
            lendingObjects = new List<LendingObject>();
        }

        private void AddObjectButton_Click(object sender, EventArgs e)
        {
            ObjectSearch rsform = new ObjectSearch(this);
            rsform.ShowDialog();
        }
        
        public void reserveHook(LendingObject obj)
        {
            Console.WriteLine("ReserveHook" + obj.ToString());
            string[] row1 = { Helpers.translateNumberStringToStatus(obj.status), obj.tags };
            LendListBox.Items.Add(obj.name).SubItems.AddRange(row1);
            lendingObjects.Add(obj);
        }

        private void ConfirmLendButton_Click(object sender, EventArgs e)
        {
            List<Reservation> relevantreserved = new List<Reservation>();
            foreach ( LendingObject item in lendingObjects)
            {
                List<Reservation> subrelevantreserved = dataGetter.selectReservationsByItem(item.code);
                foreach (Reservation subitem in subrelevantreserved)
                {
                    if (!relevantreserved.Contains(subitem))
                    {
                        relevantreserved.Add(subitem);
                    }
                }

            }

            Console.WriteLine("RelevantReservedcount   ", relevantreserved.Count.ToString());



            



            if (ReserveFromTimePicker.Value > DateTime.Now && 
                ReturnDateTimePicker.Value > DateTime.Now && 
                SignatureTextBox.Text != "" && lendingObjects.Count>0 &&
                ReserveFromTimePicker.Value<ReturnDateTimePicker.Value)
            {
                Reservation newres = new Reservation();
                newres.borrower = activeuser;

                foreach (LendingObject obj in lendingObjects)
                {

                    newres.addItem(obj);
                }
                newres.staffmember = SignatureTextBox.Text;
                newres.enddate = ReturnDateTimePicker.Value.Date;
                Console.WriteLine(newres.enddate.ToString());
                newres.startdate = ReserveFromTimePicker.Value.Date;

                List<Reservation> conflictingReservations = Helpers.checkIfItemIsFree(Helpers.datesBetweenDates(newres.startdate, newres.enddate), relevantreserved);

                if (conflictingReservations.Count == 0)
                {
                    dataGetter.insertReservation(newres);
                }
                else
                {
                    MessageBox.Show("Konflikt:" + conflictingReservations[0].ToString(),"ERROR");
                }
                    

                    

            }
            else
            {
                MessageBox.Show("Datum Von und Datum Bis müssen in der Zukunft liegen. Eine Signatur muss eingegeben werden. Objekte müssen vorhanden sein.", "ERROR");
            }



        }

        private void IDCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
