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
    public partial class Form1 : Form
    {

        private List<LendingObject> itemsToBorrow = new List<LendingObject>();
        Person activePerson;

        private List<LendingObject> itemsToReturn = new List<LendingObject>();


        private List<Person> users = new List<Person>();
        private List<LendingObject> inventory = new List<LendingObject>();
        SQLGetter dataBaseConnector;
        private string resultstring; 


        public Form1()
        {
            InitializeComponent();
            LendBox.Visible = false;
            IDCancelButton.Visible = false;
            dataBaseConnector = new SQLGetter();
            
            Console.WriteLine(dataBaseConnector.selectPerson("SELECT * FROM users;")[0].ToString());
        }





        private void IDConfirmButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Click on lend");
            this.checkIDBox();

        }

        private void checkIDBox()
        {
            if (IsDigitsOnly(ID_Entry.Text)&&ID_Entry.Text!="")
            {
                Boolean retBool = this.CheckIDInput(ID_Entry.Text);
                if (retBool == true)
                {
                    Console.WriteLine("Number was okay, unlock panel ");
                    LendBox.Visible = true;
                    LendBox.Text = "Verleihen an " + activePerson.FirstName + " " + activePerson.LastName;
                    LendBox.Focus();
                    IDCancelButton.Visible = true;
                    ID_Box.Visible = false;
                    ReturnDateTimePicker.Value = DateTime.Now.AddDays(7);
                }
            }
            else
            {
                MessageBox.Show("Falscher Input", "ERROR");
                ID_Entry.Text = "";
            }
        }

        private Boolean CheckIDInput(String id)
        {

            
            List<Person> result = dataBaseConnector.selectPerson("SELECT firstname, lastname,userid FROM users WHERE userid="+id+";");
            if (result.Count == 0 )
            {
               
                return false;
            }
            else
            {
                
                activePerson = result[0];
                return true;
            }


        }

        private void IDEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.checkIDBox();
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
                
            }
        }







        private void ConfirmLendButton_Click(object sender, EventArgs e)
        {
            foreach (LendingObject obj in itemsToBorrow)
            {
                dataBaseConnector.lendObjectToPerson(activePerson.PersonalID, obj.code, makeDateTimeSQLString(ReturnDateTimePicker.Value));
            }
            clearLendingUI();
        }

        private void ObjectReturnTextKeyListener(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                markItemForBorrowByBarcode();
            }
        }


        private void PersonAddButton_Click(object sender, EventArgs e)
        {
            string fn = FirstNameTextBox.Text;
            string ln = LastNameTextBox.Text;
            DateTime dob = DOBPicker.MinDate;
            string id = PersonIDTextBox.Text;

            Person newUser = new Person(fn, ln, id, dob);

            if (fn != "" && ln != "" && id != "")
            {
                users.Add(newUser);

                    dataBaseConnector.insertPerson(fn, ln, id);

                
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
            LendingObject newObj = new LendingObject(name, barcode, "0");
            if (name!="" && barcode != "")
            {
                inventory.Add(newObj);
                dataBaseConnector.insertObject(name, barcode);

            }
            else
            {
                Console.WriteLine("Writing Object Error - not all data");

            }



        }



        private void Obj_Entry_Button_Click(object sender, EventArgs e)
        {

            markItemForBorrowByBarcode();

        }


        private void markItemForBorrowByBarcode()
        {
            string barcode = Obj_Entry_Box.Text;
            List<LendingObject> result = dataBaseConnector.selectObjectByBarcode(barcode);
            if (result.Count == 1)
            {
                if (result[0].status == "0" || result[0].status=="")
                {

                    itemsToBorrow.Add(result[0]);
                    LendListBox.Items.Add(result[0].ToString());
                }

                else {
                    MessageBox.Show("Objekt bereits verliehen", "ERROR");
                }
            }
            else if (result.Count == 0)
            {
                MessageBox.Show("Objekt nicht in Datenbank", "ERROR");
            }
            else if (result.Count >1)
            {
                MessageBox.Show("Objekt Barcode doppelt vorhanden?", "ERROR");
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

                    itemsToReturn.Add(result[0]);
                    ReturnItemListBox.Items.Add(result[0].ToString());
                    ReturnObjCodeEntryBox.Text = "";
                }

                else
                {
                    MessageBox.Show("Objekt nicht verliehen", "ERROR");
                }
            }
            else if (result.Count == 0)
            {
                MessageBox.Show("Objekt nicht in Datenbank", "ERROR");
            }
            else if (result.Count > 1)
            {
                MessageBox.Show("Objekt Barcode doppelt vorhanden?", "ERROR");
            }

        }

        private void ReturnIDEnterButton_Click(object sender, EventArgs e)
        {
            markItemForReturnByBarcode();
        }

        private void ReturnListConfirmButton_Click(object sender, EventArgs e)
        {
            foreach (LendingObject obj in itemsToReturn)
            {
                dataBaseConnector.returnObject(obj.code, "0");
            }
            clearReturnList();
        }

        private void clearReturnList()
        {
            itemsToReturn.Clear();
            ReturnItemListBox.Items.Clear();
        }

        private void ReturnRepairButton_Click(object sender, EventArgs e)
        {
            foreach (LendingObject obj in itemsToReturn)
            {
                dataBaseConnector.returnObject(obj.code, "2");
            }
            clearReturnList();
        }
        private void InventorySearchButton_Click(object sender, EventArgs e)
        {
            int selectedSearchMode = InventorySearchDropdown.SelectedIndex;
            if (selectedSearchMode<0 || selectedSearchMode > 2)
            {
                MessageBox.Show("Falscher Suchmodus", "ERROR");
            }
            else
            {
                //NAME
                if (selectedSearchMode == 0) {
                    InventorySearchResultListView.Items.Clear();
                    foreach (LendingObject obj in dataBaseConnector.selectAllObjects())
                    {
                        string[] row1 = { obj.status, dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName, obj.borrowedUntil.Date.ToString() };
                        InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                    }
                }
                //BARCODE
                else if (selectedSearchMode == 1) { 
                
                }
                //STATUS
                else if (selectedSearchMode == 2) { 
                
                }
            }



        }


        private void Root_Selecting(object sender, TabControlCancelEventArgs e)
        {
            int index = e.TabPageIndex;
            if (index == 4)
            {
                InventorySearchDropdown.SelectedIndex = 0;
                InventorySearchResultListView.Items.Clear();
                foreach (LendingObject obj in dataBaseConnector.selectAllObjects())
                {

                    if (obj.borrower != null)
                    {
                        string[] row1 = { obj.status, dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName, obj.borrowedUntil.Date.ToString() };
                        InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                    }
                    else
                    {
                        string[] row1 = { obj.status, "Verfügbar", obj.borrowedUntil.Date.ToString() };
                        InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                    }

                }
                
            }
            else if (index == 2)
            {
                EventListView.Items.Clear();
                foreach (LendingObject obj in dataBaseConnector.selectObjectByReturnDate(makeDateTimeSQLString(DateTime.Now.AddDays(30)))) 
                {
                    if (obj.status != "0")
                    {
                        string[] row1 = { obj.status, dataBaseConnector.selectPersonByID(obj.borrower)[0].LastName, obj.borrowedUntil.Date.ToString() };
                        InventorySearchResultListView.Items.Add(obj.name).SubItems.AddRange(row1);
                    }
                }
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


    }
}
