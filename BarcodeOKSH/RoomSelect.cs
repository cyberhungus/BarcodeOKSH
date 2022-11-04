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
    public partial class RoomSelect : UserControl
    {
        List<string> selection = new List<string>();
        public Action<List<string>> OnSelectionChange;

        public RoomSelect()
        {
            InitializeComponent();
            
        }

        


        public void printList()
        {
            foreach (string s in selection)
            {
                Console.WriteLine(s);
            }
        }

        private void TVStudButt_Click(object sender, EventArgs e)
        {
            if (!selection.Contains(sender.ToString()))
            {
                selection.Add(sender.ToString());
            }
            else
            {
                selection.Remove(sender.ToString());
            }
            OnSelectionChange.Invoke(selection);
        }

        private void CutAButt_Click(object sender, EventArgs e)
        {
            if (!selection.Contains(sender.ToString()))
            {
                selection.Add(sender.ToString());
            }
            else
            {
                selection.Remove(sender.ToString());
            }
            OnSelectionChange.Invoke(selection);
        }

        private void CutBButt_Click(object sender, EventArgs e)
        {
            if (!selection.Contains(sender.ToString()))
            {
                selection.Add(sender.ToString());
            }
            else
            {
                selection.Remove(sender.ToString());
            }
            OnSelectionChange.Invoke(selection);
        }

        private void RecButt_Click(object sender, EventArgs e)
        {
            if (!selection.Contains(sender.ToString()))
            {
                selection.Add(sender.ToString());
            }
            else
            {
                selection.Remove(sender.ToString());
            }
            OnSelectionChange.Invoke(selection);
        }

        private void MuFuButt_Click(object sender, EventArgs e)
        {
            if (!selection.Contains(sender.ToString()))
            {
                selection.Add(sender.ToString());
            }
            else
            {
                selection.Remove(sender.ToString());
            }
            OnSelectionChange.Invoke(selection);
        }

        private void RadioCutAButt_Click(object sender, EventArgs e)
        {
            if (!selection.Contains(sender.ToString()))
            {
                selection.Add(sender.ToString());
            }
            else
            {
                selection.Remove(sender.ToString());
            }
            OnSelectionChange.Invoke(selection);
        }

        private void RadioStudButt_Click(object sender, EventArgs e)
        {
            
            if (!selection.Contains(sender.ToString()))
            {
                selection.Add(sender.ToString());
            }
            else
            {
                selection.Remove(sender.ToString());
            }
            OnSelectionChange.Invoke(selection);
        }

        private void RadioCutBButt_Click(object sender, EventArgs e)
        {
            if (!selection.Contains(sender.ToString()))
            {
                selection.Add(sender.ToString());
            }
            else
            {
                selection.Remove(sender.ToString());
            }
            OnSelectionChange.Invoke(selection);
        }

        private void ConfButt_Click(object sender, EventArgs e)
        {
            if (!selection.Contains(sender.ToString()))
            {
                selection.Add(sender.ToString());
            }
            else
            {
                selection.Remove(sender.ToString());
            }
            OnSelectionChange.Invoke(selection);
            
        }


    }
}
