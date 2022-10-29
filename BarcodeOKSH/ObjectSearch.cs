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
    public partial class ObjectSearch : Form
    {
        ReservationForm parent;
        SQLGetter dataBaseConnector;

        public ObjectSearch(ReservationForm parent)
        {
            InitializeComponent();
            this.parent = parent;
        dataBaseConnector=  new SQLGetter();
            InventorySearchDropdown.SelectedIndex= 0; 
        }

        private void ClearForm()
        {




        }

        private void InventoryListIndexChange(object sender, EventArgs e)
        {
            string result = "";
           foreach ( ListViewItem lvi in InventorySearchResultListView.SelectedItems)
            {
               result += lvi.Text;
                result += "; ";
            }
            SearchSelectionLabel.Text = result;
        }

        private void DateSearchCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SearchBorrowedByPersonButton_Click(object sender, EventArgs e)
        {

        }

        private void InventorySearchTermBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void InventorySearchTermBox_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void InventorySearchButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("inv search button");
                ItemSearchRegular();

        }

        private void ItemSearchRegular()
        {

            int selectedSearchMode = InventorySearchDropdown.SelectedIndex;
            if (selectedSearchMode < 0 || selectedSearchMode > 3)
            {
                MessageBox.Show("Falscher Suchmodus", "ERROR");
            }
            else
            {
                Console.WriteLine(InventorySearchTermBox.Text);
                //NAME
                if (selectedSearchMode == 0)
                {
                    InventorySearchResultListView.Items.Clear();
                    foreach (LendingObject obj in dataBaseConnector.searchObjectByName(InventorySearchTermBox.Text))
                    {
                        if (obj.borrower != "" && obj.borrower != null)
                        {
                            string[] row1 = { Helpers.translateNumberStringToStatus(obj.status), dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].FirstName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].PersonalID, Helpers.makeStringFromDate(obj.borrowedUntil), obj.staffmember };
                            InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                        }
                        else
                        {
                            string[] row1 = { Helpers.translateNumberStringToStatus(obj.status), "Verfügbar", "Nicht ausgeliehen", "Nicht ausgeliehen" };
                            InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                        }
                    }
                }
                //BARCODE
                else if (selectedSearchMode == 1)
                {

                    InventorySearchResultListView.Items.Clear();
                    if (InventorySearchTermBox.Text != "")
                    {
                        foreach (LendingObject obj in dataBaseConnector.selectObjectByBarcode(InventorySearchTermBox.Text))
                        {

                            if (obj.borrower != "" && obj.borrower != null)
                            {
                                string[] row1 = { Helpers.translateNumberStringToStatus(obj.status), dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].FirstName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].PersonalID, Helpers.makeStringFromDate(obj.borrowedUntil), obj.staffmember };
                                InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                            }
                            else
                            {
                                string[] row1 = { Helpers.translateNumberStringToStatus(obj.status), "Verfügbar", "Nicht ausgeliehen", "Nicht ausgeliehen" };
                                InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kein Suchbegriff eingegeben", "ERROR");
                    }
                }
                //STATUS
                else if (selectedSearchMode == 2)
                {
                    InventorySearchResultListView.Items.Clear();
                    if (InventorySearchTermBox.Text != "" && Helpers.IsDigitsOnly(InventorySearchTermBox.Text))
                    {
                        foreach (LendingObject obj in dataBaseConnector.selectObjectByStatus(InventorySearchTermBox.Text))
                        {

                            if (obj.borrower != "" && obj.borrower != null)
                            {
                                string[] row1 = { Helpers.translateNumberStringToStatus(obj.status), dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].FirstName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].PersonalID, Helpers.makeStringFromDate(obj.borrowedUntil), obj.staffmember };
                                InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                            }
                            else
                            {
                                string[] row1 = { Helpers.translateNumberStringToStatus(obj.status), "Verfügbar", "Nicht ausgeliehen", "Nicht ausgeliehen" };
                                InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kein Suchbegriff eingegeben", "ERROR");
                    }
                }
                //TAGS
                else if (selectedSearchMode == 3)
                {

                    InventorySearchResultListView.Items.Clear();
                    if (InventorySearchTermBox.Text != "")
                    {
                        foreach (LendingObject obj in dataBaseConnector.searchObjectByTags(InventorySearchTermBox.Text))
                        {

                            if (obj.borrower != "" && obj.borrower != null)
                            {
                                string[] row1 = { Helpers.translateNumberStringToStatus(obj.status), dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].FirstName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].PersonalID, Helpers.makeStringFromDate(obj.borrowedUntil), obj.staffmember };
                                InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                            }
                            else
                            {
                                string[] row1 = { Helpers.translateNumberStringToStatus(obj.status), "Verfügbar", "Nicht ausgeliehen", "Nicht ausgeliehen" };
                                InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kein Suchbegriff eingegeben", "ERROR");
                    }
                }
            }



        }
        

        private void ConfirmSearchSelection_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in InventorySearchResultListView.SelectedItems)
            {
                parent.reserveHook(dataBaseConnector.searchObjectByName(lvi.Text)[0]);
            }
        }
    }
}
