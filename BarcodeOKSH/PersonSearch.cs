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
    public partial class PersonSearch : Form
    {
        SQLGetter dataBaseConnector;
        Main parent;
        int state; 
        public PersonSearch(int state)
        {
            InitializeComponent();
            dataBaseConnector = new SQLGetter();
            PersonSearchModeDropdown.SelectedIndex = 1;
            this.state = state;
        }

        public void setParentForm(Main form)
        {
            this.parent = form; 
        }

        private void SearchPersonButton_Click(object sender, EventArgs e)
        {
            PersonSearchResultListBox.Items.Clear();
            if (PersonSearchTermTextBox.Text != "") { 


            int selectedSearchMode = PersonSearchModeDropdown.SelectedIndex;
            if (selectedSearchMode < 0 || selectedSearchMode > 1)
            {
                MessageBox.Show("Falscher Suchmodus", "ERROR");
            }
            else
            {
                Console.WriteLine(PersonSearchTermTextBox.Text);
                //VOrNAME
                if (selectedSearchMode == 0)
                {
                        List<Person> result = dataBaseConnector.selectPersonByFirstName(PersonSearchTermTextBox.Text);

                        foreach(Person per in result)
                        {

                            PersonSearchResultListBox.Items.Add(per.FirstName + "-" + per.LastName + "-ID:" + per.PersonalID);
                        }

                    }
                //Nachname
                else if (selectedSearchMode == 1)
                {
                        List<Person> result = dataBaseConnector.selectPersonByLastName(PersonSearchTermTextBox.Text);

                        foreach (Person per in result)
                        {

                            PersonSearchResultListBox.Items.Add(per.FirstName + "-" + per.LastName + "-ID:" + per.PersonalID);
                        }

                    }
                else
                {
                    MessageBox.Show("Kein Suchbegriff eingegeben", "ERROR");
                }
            } 
        }
                
                    else
                    {
                        MessageBox.Show("Kein Suchbegriff eingegeben", "ERROR");
                    }
                }

        private void PersonSearchTermTextBox_TextChanged(object sender, EventArgs e)
        {
            SearchPersonButton_Click(null, null);
        }

        private void PersonSearchResultListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PersonSearchResultLabel.Text = PersonSearchResultListBox.SelectedItem.ToString();
        }

        private void PersonAcceptButton_Click(object sender, EventArgs e)
        {
            if (state == 1)
            {
                this.parent.setActivePersonViaID(PersonSearchResultLabel.Text);
            }
            if (state == 2)
            {
                this.parent.searchObjectsByPersonIDandDisplay(PersonSearchResultListBox.Text.Split(':')[1]);
            }
            this.Close();
        }
    }



        }

 
   