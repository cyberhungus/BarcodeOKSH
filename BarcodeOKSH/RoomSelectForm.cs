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
    public partial class RoomSelectForm : Form
    {

        List<string> selection = new List<string>();
        string userid;
        SQLGetter dataBaseConnector;

        public RoomSelectForm(string userid)
        {
            InitializeComponent();
            this.userid = userid;
            dataBaseConnector = new SQLGetter();
            RoomBookingHeaderLabel.Text = "Raumbuchung für " + dataBaseConnector.selectPersonByID(userid)[0].getFullName();
        }

        private void TvStudButton_Click(object sender, EventArgs e)
        {
            if (!selection.Contains("TVSTUD"))
            {
                selection.Add("TVSTUD");
                TvStudButton.Text = "Ausgewählt";
            }
            else
            {
                selection.Remove("TVSTUD");
                TvStudButton.Text = "TV Studio";
            }
        }

        private void CutBButton_Click(object sender, EventArgs e)
        {
            if (!selection.Contains("CUTB"))
            {
                selection.Add("CUTB");
                CutBButton.Text = "Ausgewählt";
            }
            else
            {
                selection.Remove("CUTB");
                CutBButton.Text = "Schnittraum B";
            }
        }

        private void CutAButton_Click(object sender, EventArgs e)
        {
            if (!selection.Contains("CUTA"))
            {
                selection.Add("CUTA");
                CutAButton.Text = "Ausgewählt";
            }
            else
            {
                selection.Remove("CUTA");
                CutAButton.Text = "Schnittraum A";
            }
        }

        private void RecRoomButton_Click(object sender, EventArgs e)
        {
            if (!selection.Contains("RECROOM"))
            {
                selection.Add("RECROOM");
                RecRoomButton.Text = "Ausgewählt";
            }
            else
            {
                selection.Remove("RECROOM");
                RecRoomButton.Text = "Sozialraum ";
            }
        }

        private void MultiFuncButton_Click(object sender, EventArgs e)
        {
            if (!selection.Contains("MUFU"))
            {

                selection.Add("MUFU");
                MultiFuncButton.Text = "Ausgewählt";
            }
            else
            {
                selection.Remove("MUFU");
                MultiFuncButton.Text = "Multifunktionsraum";
            }
        }

        private void RadioStudioButton_Click(object sender, EventArgs e)
        {
            if (!selection.Contains("RADSTUD"))
            {

                selection.Add("RADSTUD");
                RadioStudioButton.Text = "Ausgewählt";
            }
            else
            {
                selection.Remove("RADSTUF");
                RadioStudioButton.Text = "Radiostudio";
            }
        }

        private void AudioCuttingButton_Click(object sender, EventArgs e)
        {
            if (!selection.Contains("AUDIOCUT"))
            {
                selection.Add("AUDIOCUT");
                AudioCuttingButton.Text = "Ausgewählt";
            }
            else
            {
                selection.Remove("AUDIOCUT");
                AudioCuttingButton.Text = "Schnittraum Audio";
            }
        }

        private void ConferenceRoomButton_Click(object sender, EventArgs e)
        {
            if (!selection.Contains("CONFROOM"))
            {
                selection.Add("CONFROOM");
                ConferenceRoomButton.Text = "Ausgewählt";
            }
            else
            {
                selection.Remove("CONFROOM");
                ConferenceRoomButton.Text = "Seminarraum";
            }
        }

    }
}
