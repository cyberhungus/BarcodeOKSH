using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Drawing.Printing;

namespace BarcodeOKSH
{
    public partial class LendReturnCheckForm : Form
    {

        List<LendingObject> displayItems;
        string type;
        Main parent;
        Person activePers;
        DateTime date; 


        public LendReturnCheckForm(Person activePerson, DateTime date,  List<LendingObject> itemsToDisplay, string type, Main parent)
        {
            InitializeComponent();

            displayItems = itemsToDisplay;
            this.type = type;

            foreach (LendingObject item in displayItems)
            {
                ItemCheckListBox.Items.Add(item.name);
                Console.WriteLine(item.name);
            }

            this.parent = parent;
            this.activePers = activePerson;
            this.date = date; 

            if (this.type == "RETURN")
            {
                ItemCheckTextLabel.Text = "Rückgabe folgender Objekte um "+date.ToString();

            }
            else if (this.type == "LEND")
            {
                ItemCheckTextLabel.Text = "Ausleihen folgender Objekte von " + activePerson.ToString() + " bis " + date.ToString();

            }
            else
            {
                throw new Exception("ERROR");
            }

        }

        private void ConfirmItemCheckButton_Click(object sender, EventArgs e)
        {
            if (this.type == "RETURN")
            {
                if (StaffmemberEntryTextbox.Text != "")
                {

                    parent.ReturnProcess(this.displayItems,StaffmemberEntryTextbox.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bitte Kürzel oder Namen eingeben", "ERROR");
                    StaffmemberEntryTextbox.Focus();
                }
            }
            else if (this.type == "LEND")
            {


            
                    if (StaffmemberEntryTextbox.Text != "")
                    {
                        parent.LendingProcess(this.activePers, this.displayItems, this.date, StaffmemberEntryTextbox.Text);
                        var result = MessageBox.Show("Quittung drucken?", "DRUCK",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            this.Close();
                        }
                        else
                        {
                            string output = "";
                            if (type == "LEND")
                            {


                                string header = "Verleihschein von " + DateTime.Now;
                                header += "folgende Objekte wurden an ";
                                header += activePers.getFullName();
                                header += " mit der ID ";
                                header += activePers.PersonalID;
                                header += " ausgegeben.";
                                header += "\r\n";
                                output += header;
                                foreach (LendingObject obj in displayItems)
                                {

                                    string objectline = obj.name;
                                    objectline += " - Zurückzugeben am: ";
                                    objectline += obj.borrowedUntil.ToString();
                                    objectline += "\r\n";
                                    output += objectline;

                                }

                                string footer = "Vielen Dank - Die Ausgabe erfolgte durch ";
                                footer += StaffmemberEntryTextbox.Text;
                                footer += "Offener Kanal - Hamburger Chaussee 36, Kiel";
                                output += footer;
                            }


                            printDialog1.Document.PrintPage += new PrintPageEventHandler(pd_PrintPage);

                            var resultPrintDialog = printDialog1.ShowDialog();

                            if (resultPrintDialog == DialogResult.Yes)
                            {
                                printDialog1.Document.Print();
                                this.Close();
                            }
                            else
                            {
                                this.Close();
                            }



                        }


                    }
                    else
                    {
                        MessageBox.Show("Bitte Kürzel oder Namen eingeben", "ERROR");
                        StaffmemberEntryTextbox.Focus();
                    }
                }
               
            else
            {
                throw new Exception("ERROR");
            }
        }
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            ev.Graphics.DrawString("Hello",new Font("ARIAL",20), Brushes.Black, ev.MarginBounds.Left, 0, new StringFormat());
        }
        private void ItemCheckCancelButton_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
