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
    public partial class ReservationDisplayElement : UserControl
    {
        public ReservationDisplayElement()
        {
            InitializeComponent();
        }

        public void setReservation(Reservation res)
        {
            ObjectList.Items.Clear();
            string info = "Reservierung für ";
            info += res.borrower.getFullName();

            InfoLabel.Text = info;

            StartTimeLabel.Text = "Beginnt: " + res.startdate.Date.ToShortDateString();
            EndTimeLabel.Text = "Endet: " + res.enddate.Date.ToShortDateString();

            foreach (LendingObject obj in res.objects)
            {
                if (obj.borrower != "" && obj.borrower != null)
                {
                    string[] row1 = { Helpers.translateNumberStringToStatus(obj.status), new SQLGetter().selectPersonByID(obj.borrower)[0].LastName + "," + new SQLGetter().selectPersonByID(obj.borrower)[0].FirstName + "," + new SQLGetter().selectPersonByID(obj.borrower)[0].PersonalID, Helpers.makeStringFromDate(obj.borrowedUntil), obj.staffmember };
                    ObjectList.Items.Add(obj.name).SubItems.AddRange(row1);
                }
                else
                {
                    string[] row1 = { Helpers.translateNumberStringToStatus(obj.status), "Verfügbar", "Nicht ausgeliehen", "Nicht ausgeliehen" };
                    ObjectList.Items.Add(obj.name).SubItems.AddRange(row1);
                }
            }
        }

        private void EndTimeLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
