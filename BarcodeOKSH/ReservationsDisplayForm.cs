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
    public partial class ReservationsDisplayForm : Form
    {
        List<Reservation> reservations;
        public ReservationsDisplayForm(string texttodisplay, List<Reservation> reservationstodisplay)
        {
            InitializeComponent();
            this.reservations = reservationstodisplay;
            ReservationInfoLabel.Text = texttodisplay;
            foreach (Reservation res in this.reservations)
            {

                string[] row1 = { res.enddate.ToString(), res.borrower.getFullName(), Helpers.makeStringFromReservationItems(res.objects), res.staffmember };
                ReservationDisplayListview.Items.Add(res.startdate.ToString()).SubItems.AddRange(row1);

            }
        }

        private void Acknowledge_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            
        }

        private void OverwriteButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}
