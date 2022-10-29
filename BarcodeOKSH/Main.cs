using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarcodeOKSH
{
    public partial class Main : Form
    {

        private List<LendingObject> itemsToBorrow = new List<LendingObject>();
        Person activePerson;

        private List<LendingObject> itemsToReturn = new List<LendingObject>();


        private List<Person> users = new List<Person>();
        private List<LendingObject> inventory = new List<LendingObject>();
        SQLGetter dataBaseConnector;
        


        public Main()
        {
            InitializeComponent();
            LendBox.Visible = false;
            IDCancelButton.Visible = false;
            dataBaseConnector = new SQLGetter();
        }





        private void IDConfirmButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Click on lend");
            this.checkIDBox();
           // Obj_Entry_Box.Focus();

        }

        private void checkIDBox()
        {
            if (IsDigitsOnly(ID_Entry.Text)&&ID_Entry.Text!="")
            {
                Boolean retBool = this.checkIfUserExists(ID_Entry.Text);
                if (retBool == true)
                {
                    Console.WriteLine("Number was okay, unlock panel ");
                    LendBox.Visible = true;
                    LendBox.Text = "Verleihen an " + activePerson.FirstName + " " + activePerson.LastName;
                    LendBox.Focus();
                    IDCancelButton.Visible = true;
                    ID_Box.Visible = false;
                    ReturnDateTimePicker.Value = DateTime.Now.AddDays(7);
                    Obj_Entry_Box.Focus();
                }
            }
            else
            {
                MessageBox.Show("Falscher Input", "ERROR");
                ID_Entry.Text = "";
            }
        }



        private void IDEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.checkIDBox();
              
            }
        }

        public void setActivePersonViaID(string id)
        {
            if (id != "Result" && id != "" && id != null)
            {
                string idclean = id.Split(':')[1];
                try
                {
                    this.activePerson = dataBaseConnector.selectPersonByID(idclean)[0];
                    LendBox.Text = "Verleihen an " + activePerson.FirstName + " " + activePerson.LastName;
                    LendBox.Visible = true;
                    IDCancelButton.Visible = true;
                    itemsToBorrow.Clear();
                    ID_Box.Visible = false;
                    ID_Entry.Text = "";
                    LendListBox.Items.Clear();
                    Obj_Entry_Box.Text = "";
                    Obj_Entry_Box.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler beim Finden der Person", "ERROR");
                }

            }
        }

        private void IDCancelButton_Click(object sender, EventArgs e)
        {
            clearLendingUI();
        }

        private void clearLendingUI()
        {
            LendBox.Visible = false;
            IDCancelButton.Visible = false;
            itemsToBorrow.Clear();
            activePerson = null;
            ID_Box.Visible = true;
            ID_Entry.Text = "";
            LendListBox.Items.Clear();
            Obj_Entry_Box.Text = "";
        }

        private void Obj_ID_Entry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                markItemForBorrowByBarcode();
            }
        }



        private void DeleteBorrowItemButton_Click(object sender, EventArgs e)
        {
            if (LendListBox.SelectedItems.Count > 0)
            {
                List<LendingObject> itemstoremove =  new List<LendingObject>(); 
                foreach (ListViewItem x in LendListBox.SelectedItems)
                {
                    
                    foreach (LendingObject obj in itemsToBorrow)
                    {
                        if (obj.name.Equals(x.Text))
                        {
                            itemstoremove.Add(obj);


                        }
                    }
                }
                foreach (LendingObject obj in itemstoremove)
                {

                    itemsToBorrow.Remove(obj);
                    Console.WriteLine("removing obj" + obj.ToString());


                }
                LendListBox.Items.Clear();
                foreach (LendingObject obj in itemsToBorrow)
                {

                        
                        string[] row1 = { translateNumberStringToStatus(obj.status), obj.tags };
                        LendListBox.Items.Add(obj.name).SubItems.AddRange(row1);

                    
                }

            }
        }



        private void ConfirmLendButton_Click(object sender, EventArgs e)
        {
            if (itemsToBorrow.Count != 0)
            {

                List<Reservation> conflicts = new List<Reservation>();

                foreach (LendingObject obj in this.itemsToBorrow)
                {
                    try
                    {
                        Reservation potentialconfl = Helpers.checkIfItemIsFree(Helpers.datesBetweenDates(DateTime.Now, ReturnDateTimePicker.Value), new SQLGetter().selectReservationsByItem(obj.code))[0];
                        if (!conflicts.Contains(potentialconfl)) { conflicts.Add(potentialconfl); }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Confirmlendbutton" + ex.Message);
                    }


                }
                if (conflicts.Count == 0)
                {
                   // Console.WriteLine("AT FORM ONE LED BUTTON , ITEMSTOBORROW HAS " + itemsToBorrow.Count);
                    LendReturnCheckForm LRCF = new LendReturnCheckForm(activePerson, ReturnDateTimePicker.Value, itemsToBorrow, "LEND", this);
                    LRCF.ShowDialog();
                    clearLendingUI();
                }
                else
                {
                    ReservationsDisplayForm rdf = new ReservationsDisplayForm("Folgende Konflikte wurden gefunden:", conflicts);
                    DialogResult result = rdf.ShowDialog();
                    if (result == DialogResult.Yes)
                    {
                        //Console.WriteLine("AT FORM ONE LED BUTTON , ITEMSTOBORROW HAS " + itemsToBorrow.Count);
                        LendReturnCheckForm LRCF = new LendReturnCheckForm(activePerson, ReturnDateTimePicker.Value, itemsToBorrow, "LEND", this);
                        LRCF.ShowDialog();
                        clearLendingUI();
                    }
                    else if (result == DialogResult.Cancel)
                    {
                        MessageBox.Show("Lösen Sie die Konflikte");
                    }


                }
            }
            else
            {
                MessageBox.Show("Keine Objekte ausgewählt.", "Error");
            }
        }

        public void LendingProcess(Person person, List<LendingObject> items, DateTime date, string staffmember)
        {
            foreach (LendingObject obj in items)
            {
                dataBaseConnector.lendObjectToPerson(person.PersonalID, obj.code, makeDateTimeSQLString(date),staffmember);
            }
        }

        private void ObjectReturnTextKeyListener(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                markItemForReturnByBarcode();
            }
        }


        private void PersonAddButton_Click(object sender, EventArgs e)
        {
            string fn = FirstNameTextBox.Text;
            string ln = LastNameTextBox.Text;
            DateTime dob = DOBPicker.Value;
            string id = PersonIDTextBox.Text;
            string cont = AddPersonContactTextbox.Text;
            string govid = AddPersonGovIDTextbox.Text;
            string addr = AddPersonAddressTextbox.Text;


            Person newUser = new Person(fn, ln, id, dob);

            if (fn != "" && ln != "" && id != "" &&cont != "" && govid != "" && addr != "")
            {

                if (!dataBaseConnector.getAllUserIDs().Contains(Int32.Parse(id)))
                {
                    users.Add(newUser);

                    dataBaseConnector.insertPerson(fn, ln, id,cont,govid,addr,makeStringFromDate(dob));

                    MessageBox.Show(fn + " " + ln + " mit ID " + id + " wurde zur Datenbank hinzugefügt");
                    FirstNameTextBox.Text = "";
                    LastNameTextBox.Text = "";
                    PersonIDTextBox.Text = "";
                    AddPersonAddressTextbox.Text = "";
                    AddPersonContactTextbox.Text = "";
                    AddPersonGovIDTextbox.Text = "";
                }
                else
                {
                    MessageBox.Show("UserID bereits vergeben", "ERROR");
                }

                
            }
            else
            {
                Console.WriteLine("Writing Person Error - not all data");

            }


        }

        private void ObjAddButton_Click(object sender, EventArgs e)
        {
            string name = ObjNameBox.Text;
            string barcode = ObjCodeBox.Text;
            string tags = ObjAddTagsTextbox.Text;
            LendingObject newObj = new LendingObject(name, barcode, "0","");
            if (name!="" && barcode != "" && !name.Contains("\""))
            {
                inventory.Add(newObj);
                Boolean result = dataBaseConnector.insertObject(name, barcode,tags);
                if (result)
                {
                    MessageBox.Show("Erfolgreich hinzugefügt: " + name + " mit Barcode " + barcode + " und Tags: "+ tags, "ERFOLG");
                    ObjNameBox.Text = "";
                    ObjCodeBox.Text = "";
                    ObjAddTagsTextbox.Text = "";
                }
                else
                {
                    MessageBox.Show("Fehler bei Objektsuche - Barcode Duplikat?", "ERROR");
                }
            }
            else if (name.Contains("\""))
            {
                MessageBox.Show("Fehler - Name darf keine Anführungszeichen enthalten", "ERROR");
            }
            else
            {
                MessageBox.Show("Fehler - Alle Felder ausgefüllt?","ERROR");

            }



        }



        private void Obj_Entry_Button_Click(object sender, EventArgs e)
        {

            markItemForBorrowByBarcode();

        }


        private void markItemForBorrowByBarcode()
        {
            string barcode = Obj_Entry_Box.Text;
            if (IsDigitsOnly(barcode))
            {
                List<LendingObject> result = dataBaseConnector.selectObjectByBarcode(barcode);
                if (result.Count == 1)
                {
                    if (result[0].status == "0" || result[0].status == "" && !itemsToBorrow.Contains(result[0]))
                    {
                        LendingObject obj = result[0];
                        itemsToBorrow.Add(obj);
                        string[] row1 = {translateNumberStringToStatus( obj.status) ,obj.tags};
                        LendListBox.Items.Add(obj.name).SubItems.AddRange(row1);
                        Obj_Entry_Box.Text = "";
                    }

                    else if (result[0].status == "1")
                    {
                        LendingObject obj = result[0];
                        MessageBox.Show("Objekt " + obj.name + " bis " + makeStringFromDate(obj.borrowedUntil)+ " an "+ dataBaseConnector.selectPersonByID(obj.borrower.ToString())[0].LastName + " ," + dataBaseConnector.selectPersonByID(obj.borrower.ToString())[0].FirstName+" verliehen", "ERROR");

                    }
                    else if (result[0].status == "2")
                    {
                        LendingObject obj = result[0];
                        MessageBox.Show("Objekt " + obj.name + " ist in Reparatur", "ERROR");

                    }
                }
                else if (result.Count == 0)
                {
                    MessageBox.Show("Objekt " + barcode + " nicht in Datenbank", "ERROR");
                    Obj_Entry_Box.Text = "";
                }
                else if (result.Count > 1)
                {
                    MessageBox.Show("Objekt mit Barcode " + barcode + " doppelt vorhanden?", "ERROR");
                    Obj_Entry_Box.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Bei Barcode nur Nummern eingeben", "ERROR");
            }


        }

        private void markItemForReturnByBarcode()
        {
            string barcode = ReturnObjCodeEntryBox.Text;
         
            List<LendingObject> result = dataBaseConnector.selectObjectByBarcode(barcode);
            if (result.Count == 1)
            {
                if (result[0].status == "1" || result[0].status == "")
                {
                    LendingObject obj = result[0];
                    //itemsToBorrow.Add(obj);
                    string[] row1 = { translateNumberStringToStatus( obj.status), dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName, makeStringFromDate(obj.borrowedUntil), obj.staffmember  };
                    ReturnItemListView.Items.Add(obj.name).SubItems.AddRange(row1);
                    itemsToReturn.Add(obj);

                    ReturnObjCodeEntryBox.Text = "";
                }

                else
                {
                    MessageBox.Show("Objekt nicht verliehen", "ERROR");
                }
            }
            else if (result.Count == 0)
            {
                MessageBox.Show("Objekt "+ barcode+" nicht in Datenbank", "ERROR");
            }
            else if (result.Count > 1)
            {
                MessageBox.Show("Objekt mit Barcode " + barcode + "doppelt vorhanden?", "ERROR");
            }

        }

        private void ReturnIDEnterButton_Click(object sender, EventArgs e)
        {
            markItemForReturnByBarcode();
        }

        private void ReturnListConfirmButton_Click(object sender, EventArgs e)
        {
            if (itemsToReturn.Count > 0)
            {
                LendReturnCheckForm LRCF = new LendReturnCheckForm(null, DateTime.Now, itemsToReturn, "RETURN", this);
                LRCF.ShowDialog();
                clearReturnList();
            }
            else
            {
                MessageBox.Show("Keine Objekte zur Rückgabe", "ERROR");
            }
        }

        public void ReturnProcess(List<LendingObject> itemsToReturn, string staffmember)
        {
            foreach (LendingObject obj in itemsToReturn)
            {
                dataBaseConnector.returnObject(obj.code, "0" , staffmember);
            }
        }


        private void clearReturnList()
        {
            itemsToReturn.Clear();
            ReturnItemListView.Items.Clear();
        }

        private void ReturnRepairButton_Click(object sender, EventArgs e)
        {
            foreach (LendingObject obj in itemsToReturn)
            {
                dataBaseConnector.returnObject(obj.code, "2", "XX");
            }
            clearReturnList();
        }


        private void InventorySearchTermBox_KeyDown(object sender, KeyEventArgs e)
        {
            InventorySearchButton_Click(null, null);
        }
        private void InventorySearchButton_Click(object sender, EventArgs e)
        {
            if (DateSearchCheckBox.Checked == false)
            {
                ItemSearchRegular();
            }
            else
            {
                ItemSearchByDate();
            }

        }


        private void ItemSearchByDate()
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
                    foreach (LendingObject obj in dataBaseConnector.searchObjectByNameOnDate(InventorySearchTermBox.Text,makeDateTimeSQLString( SearchTimePicker.Value)))
                    {
                        if (obj.borrower != "" && obj.borrower != null)
                        {
                            string[] row1 = { translateNumberStringToStatus(obj.status), dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].FirstName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].PersonalID, makeStringFromDate(obj.borrowedUntil), obj.staffmember };
                            InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                        }
                        else
                        {
                            string[] row1 = { translateNumberStringToStatus(obj.status), "Verfügbar", "Nicht ausgeliehen", "Nicht ausgeliehen" };
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
                        foreach (LendingObject obj in dataBaseConnector.selectObjectByBarcodeOnDate(InventorySearchTermBox.Text,makeDateTimeSQLString(SearchTimePicker.Value)))
                        {

                            if (obj.borrower != "" && obj.borrower != null)
                            {
                                string[] row1 = { translateNumberStringToStatus(obj.status), dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].FirstName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].PersonalID, makeStringFromDate(obj.borrowedUntil), obj.staffmember };
                                InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                            }
                            else
                            {
                                string[] row1 = { translateNumberStringToStatus(obj.status), "Verfügbar", "Nicht ausgeliehen", "Nicht ausgeliehen" };
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
                    if (InventorySearchTermBox.Text != "" && IsDigitsOnly(InventorySearchTermBox.Text))
                    {
                        foreach (LendingObject obj in dataBaseConnector.selectObjectByStatusOnDate(InventorySearchTermBox.Text,makeDateTimeSQLString( SearchTimePicker.Value)))
                        {

                            if (obj.borrower != "" && obj.borrower != null)
                            {
                                string[] row1 = { translateNumberStringToStatus(obj.status), dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].FirstName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].PersonalID, makeStringFromDate(obj.borrowedUntil), obj.staffmember };
                                InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                            }
                            else
                            {
                                string[] row1 = { translateNumberStringToStatus(obj.status), "Verfügbar", "Nicht ausgeliehen", "Nicht ausgeliehen" };
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
                        foreach (LendingObject obj in dataBaseConnector.searchObjectByTagsOnDate(InventorySearchTermBox.Text, makeDateTimeSQLString( SearchTimePicker.Value)))
                        {
                            if (obj.borrower != "" && obj.borrower != null)
                            {
                                string[] row1 = { translateNumberStringToStatus(obj.status), dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].FirstName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].PersonalID, makeStringFromDate(obj.borrowedUntil), obj.staffmember };
                                InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                            }
                            else
                            {
                                string[] row1 = { translateNumberStringToStatus(obj.status), "Verfügbar", "Nicht ausgeliehen", "Nicht ausgeliehen" };
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
                            string[] row1 = { translateNumberStringToStatus(obj.status), dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].FirstName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].PersonalID, makeStringFromDate(obj.borrowedUntil), obj.staffmember };
                            InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                        }
                        else
                        {
                            string[] row1 = { translateNumberStringToStatus(obj.status), "Verfügbar", "Nicht ausgeliehen" , "Nicht ausgeliehen"};
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
                                string[] row1 = { translateNumberStringToStatus(obj.status), dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].FirstName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].PersonalID, makeStringFromDate(obj.borrowedUntil), obj.staffmember };
                                InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                            }
                            else
                            {
                                string[] row1 = { translateNumberStringToStatus(obj.status), "Verfügbar", "Nicht ausgeliehen", "Nicht ausgeliehen" };
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
                    if (InventorySearchTermBox.Text != "" && IsDigitsOnly(InventorySearchTermBox.Text))
                    {
                        foreach (LendingObject obj in dataBaseConnector.selectObjectByStatus(InventorySearchTermBox.Text))
                        {

                            if (obj.borrower != "" && obj.borrower != null)
                            {
                                string[] row1 = { translateNumberStringToStatus(obj.status), dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].FirstName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].PersonalID, makeStringFromDate(obj.borrowedUntil), obj.staffmember };
                                InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                            }
                            else
                            {
                                string[] row1 = { translateNumberStringToStatus(obj.status), "Verfügbar", "Nicht ausgeliehen", "Nicht ausgeliehen" };
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
                                string[] row1 = { translateNumberStringToStatus(obj.status), dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].FirstName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].PersonalID, makeStringFromDate(obj.borrowedUntil), obj.staffmember };
                                InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                            }
                            else
                            {
                                string[] row1 = { translateNumberStringToStatus(obj.status), "Verfügbar", "Nicht ausgeliehen", "Nicht ausgeliehen" };
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

        private void ShowNextMonthReturnButton_Click(object sender, EventArgs e)
        {
            EventExplanationLabel.Text = "ZEIGT RÜCKGABEN IN DEN NÄCHSTEN 30 TAGEN AN";
            EventListView.Items.Clear();
            foreach (LendingObject obj in dataBaseConnector.selectObjectByReturnDate(makeDateTimeSQLString(DateTime.Now.AddDays(30))))
            {
                if (obj.status != "0")
                {
                    string[] row1 = { translateNumberStringToStatus(obj.status), dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].FirstName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].PersonalID, makeStringFromDate(obj.borrowedUntil) };
                    EventListView.Items.Add(obj.name).SubItems.AddRange(row1);
                }
            }
        }


        private void ShowOverdueButton_Click(object sender, EventArgs e)
        {
            EventExplanationLabel.Text = "ZEIGE ÜBERFÄLLIGE RÜCKGABEN AN";
            EventListView.Items.Clear();
            foreach (LendingObject obj in dataBaseConnector.selectLateObjects())
            {
                if (obj.status != "0")
                {
                    string[] row1 = { translateNumberStringToStatus(obj.status), dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].FirstName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].PersonalID, makeStringFromDate(obj.borrowedUntil) };
                    EventListView.Items.Add(obj.name).SubItems.AddRange(row1);
                }
            }
        }
        public void SearchBorrowedByPersonButton_Click(object sender, EventArgs e)
        {
            PersonSearch personSearchForm = new PersonSearch(2);
            personSearchForm.setParentForm(this);
            personSearchForm.ShowDialog();
        }

        private void Root_Selecting(object sender, TabControlCancelEventArgs e)
        {
            int index = e.TabPageIndex;
            //SEARCH
            if (index == 4)
            {
                DateSearchCheckBox.Checked = false;
                SearchTimePicker.Visible = false;
                EventExplanationLabel.Text = "ZEIGT RÜCKGABEN IN DEN NÄCHSTEN 30 TAGEN AN";
                InventorySearchDropdown.SelectedIndex = 0;
                InventorySearchResultListView.Items.Clear();
                InventorySearchResultListView.Items.Clear();
                foreach (LendingObject obj in dataBaseConnector.searchObjectByNameOnDate(InventorySearchTermBox.Text, makeDateTimeSQLString(SearchTimePicker.Value)))
                {
                    if (obj.borrower != "" && obj.borrower != null)
                    {
                        string[] row1 = { translateNumberStringToStatus(obj.status), dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].FirstName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].PersonalID, makeStringFromDate(obj.borrowedUntil), obj.staffmember };
                        InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                    }
                    else
                    {
                        string[] row1 = { translateNumberStringToStatus(obj.status), "Verfügbar", "Nicht ausgeliehen", "Nicht ausgeliehen" };
                        InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                    }

                }
            }
            //EVENTS
            else if (index == 3)
            {
                EventListShower.Items.Clear();
                ShowOverdueButton.Text = "Zeige verspätete (" + dataBaseConnector.selectLateObjects().Count + ")";
                EventListView.Items.Clear();
                List<DateTime> relevantDates = new List<DateTime>();
                foreach (LendingObject obj in dataBaseConnector.selectObjectByReturnDate(makeDateTimeSQLString(DateTime.Now.AddDays(30))))
                {
                    if (obj.status != "0")
                    {
                        string[] row1 = { translateNumberStringToStatus(obj.status), dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].FirstName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].PersonalID, makeStringFromDate(obj.borrowedUntil) };
                        EventListView.Items.Add(obj.name).SubItems.AddRange(row1);
                        relevantDates.Add(obj.borrowedUntil);

                        
                    }
                }
                EventCalendar.BoldedDates = relevantDates.ToArray();
                Console.WriteLine("bold append" + EventCalendar.BoldedDates.Length.ToString());
                DateTime lastDay = DateTime.Now.Date;
                foreach (ReturnReserveEvent ev in sortEventsByDate(dataBaseConnector.generateEventsUntilDate(DateTime.Now.AddDays(30))))
                {
                    foreach ( DateTime dt in ev.relevantDates) {
                        
                       
                          if (dt.Date > lastDay)
                            {
                            EventListShower.Groups.Add(new ListViewGroup(dt.Date.ToString(),HorizontalAlignment.Left));
                            lastDay = dt;
                            EventListShower.Items.Add(dt.Date.ToString() + ev.eventstring);
                            // Adds the first item to the first group
                            EventListShower.Items[0].Group = EventListShower.Groups[0];
                            Console.WriteLine(EventListShower.Groups[0].Header);
                        }
                            else
                            {

                            }

                        }
                        // EventListShower.Items.Add(ev.eventstring);
                        //                        Console.WriteLine("EventListShower" + ev.eventstring);
 


                    
                    
                }
            }
            //Admin
            else if (index == 6)
            {
                DOBPicker.Value = DateTime.Now.AddYears(-12);
            }

            else if (index == 1)
            {
                activePerson = null;
                clearLendingUI();
            }

            else if (index == 2)
            {
                //ShowOverdueButton.Text = "Zeige verspätete (" + dataBaseConnector.selectLateObjects().Count + ")";
                ReservationDisplayListview.Clear();
                ReservationDisplayTimePicker.Value = DateTime.Now.Date;
                foreach (Reservation res in dataBaseConnector.selectReservationsActiveOnDate(ReservationDisplayTimePicker.Value))
                {
                    
                        string[] row1 = {res.enddate.ToString(), res.borrower.getFullName(), res.objects.ToString(), res.staffmember };
                        ReservationDisplayListview.Items.Add(res.startdate.ToString()).SubItems.AddRange(row1);
                    
                }
                

                
                {

                }
            }
        }

        private List<ReturnReserveEvent> sortEventsByDate(List<ReturnReserveEvent> inp)
        {
            List<ReturnReserveEvent> ret = new List<ReturnReserveEvent>();
            List<(DateTime date, ReturnReserveEvent ev)> SortList = new List<(DateTime date, ReturnReserveEvent ev)>();
            foreach (ReturnReserveEvent e in inp)
            {
               foreach (DateTime date in e.relevantDates)
                {
                    SortList.Add((date, e));
                }
            }
            SortList.Sort((u1, u2) => u1.date.CompareTo(u2.date));


            foreach (var v in SortList) {

                ret.Add(v.ev);
                Console.WriteLine("Sorted list " + v.ev.eventstring);
            }

            return ret;
        }



        private void DateSearchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DateSearchCheckBox.Checked == true)
            {
                SearchTimePicker.Visible = true;
            }
            else
            {
                SearchTimePicker.Visible = false;
            }
        }
        private string makeDateTimeSQLString(DateTime date)
        {
            string toReturn = date.Year.ToString() + "-" + date.Month.ToString() +"-"+ date.Day.ToString();
            Console.WriteLine(toReturn);
            return toReturn;
        }


        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void InventorySearchTermBox_TextChanged(object sender, EventArgs e)
        {
            if (InventorySearchTermBox.Text != "")
            {
                InventorySearchButton_Click(null, null);
            }
        }

        private void SearchPersonButton_Click(object sender, EventArgs e)
        {
            PersonSearch personSearchForm = new PersonSearch(1);
            personSearchForm.setParentForm(this);
            personSearchForm.ShowDialog();
        }


        public void searchObjectsByPersonIDandDisplay(string personID)
        {
            InventorySearchResultListView.Items.Clear();
            foreach (LendingObject obj in dataBaseConnector.selectObjectByBorrowerID(personID))
            {

                if (obj.borrower != null)
                {
                    string[] row1 = { translateNumberStringToStatus(obj.status), dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].FirstName + "," + dataBaseConnector.selectPersonByID(obj.borrower)[0].PersonalID, makeStringFromDate(obj.borrowedUntil) };
                    InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                }
                else
                {
                    string[] row1 = { translateNumberStringToStatus(obj.status), "Verfügbar", makeStringFromDate(obj.borrowedUntil) };
                    InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                }

            }
        }

        private string makeStringFromDate(DateTime input)
        {
            if (input.Date == new DateTime(0001, 1, 1).Date)
            {
                return "Nicht ausgeliehen";
            }
            else
            {
                return input.Day.ToString() + "-" + input.Month.ToString() + "-" + input.Year.ToString();
            }
        }

        private string translateNumberStringToStatus(string input)
        {
            if (input == "0")
            {
                return "Verfügbar";
            }
            else if (input == "1")
            {
                return "Ausgeliehen";
            }
            else if (input == "2")
            {
                return "In Reparatur";
            }
            else
            {
                return "Nicht bekannt/Fehler";
            }
        }

        private Boolean checkIfUserExists(string userid)
        {
            if (userid != "" || IsDigitsOnly(userid))
            {
                List<Person> result = dataBaseConnector.selectPersonByID(userid);
                if (result.Count == 0)
                {

                    return false;
                }
                else if (result.Count == 1)
                {

                    activePerson = result[0];
                    return true;
                }
                else
                {
                    MessageBox.Show("User ID Duplikat", "ERROR");
                    return false; 
                }

            }
            else return false; 
        }

        private void RoomSelectButton_Click(object sender, EventArgs e)
        {

            if (checkIfUserExists(RoomBookingUserIDTextbox.Text))
            {
                RoomSelectForm rsform = new RoomSelectForm(RoomBookingUserIDTextbox.Text);
                rsform.ShowDialog();
            }
        }

        private void ReservationButton_Click(object sender, EventArgs e)
        {
            if (checkIfUserExists(ReservationUserIDTextBox.Text))
            {
                ReservationForm rsform = new ReservationForm(ReservationUserIDTextBox.Text);
                rsform.ShowDialog();
            }
            else
            {
                MessageBox.Show("ID nicht in Nutzern gefunden","ERROR");
            }
        }

        private void InventorySearchDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ReservationDisplayTimePicker_ValueChanged(object sender, EventArgs e)
        {
            ReservationDisplayListview.Clear();
            foreach (Reservation res in dataBaseConnector.selectReservationsActiveOnDate(ReservationDisplayTimePicker.Value))
            {

                string[] row1 = { res.enddate.ToString(), res.borrower.getFullName(), Helpers.makeStringFromReservationItems(res.objects), res.staffmember };
                ReservationDisplayListview.Items.Add(res.startdate.ToString()).SubItems.AddRange(row1);

            }
        }


    }
}
