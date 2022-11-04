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
    public partial class ReservationConfirmForm : Form
    {
        Reservation thisRes;
        public ReservationConfirmForm(Reservation res)
        {
            InitializeComponent();
            thisRes = res;
            this.ResDisplayElement.setReservation(res);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SQLGetter().insertReservation(thisRes);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
