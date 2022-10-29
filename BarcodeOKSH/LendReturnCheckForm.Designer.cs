namespace BarcodeOKSH
{
    partial class LendReturnCheckForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LendReturnCheckForm));
            this.ItemCheckTextLabel = new System.Windows.Forms.Label();
            this.ConfirmItemCheckButton = new System.Windows.Forms.Button();
            this.ItemCheckCancelButton = new System.Windows.Forms.Button();
            this.ItemCheckListBox = new System.Windows.Forms.ListBox();
            this.Staffmembernamelabel = new System.Windows.Forms.Label();
            this.StaffmemberEntryTextbox = new System.Windows.Forms.TextBox();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.SuspendLayout();
            // 
            // ItemCheckTextLabel
            // 
            this.ItemCheckTextLabel.AutoSize = true;
            this.ItemCheckTextLabel.Location = new System.Drawing.Point(12, 9);
            this.ItemCheckTextLabel.Name = "ItemCheckTextLabel";
            this.ItemCheckTextLabel.Size = new System.Drawing.Size(92, 32);
            this.ItemCheckTextLabel.TabIndex = 0;
            this.ItemCheckTextLabel.Text = "label1";
            // 
            // ConfirmItemCheckButton
            // 
            this.ConfirmItemCheckButton.Location = new System.Drawing.Point(1274, 890);
            this.ConfirmItemCheckButton.Name = "ConfirmItemCheckButton";
            this.ConfirmItemCheckButton.Size = new System.Drawing.Size(186, 103);
            this.ConfirmItemCheckButton.TabIndex = 1;
            this.ConfirmItemCheckButton.Text = "Bestätigen";
            this.ConfirmItemCheckButton.UseVisualStyleBackColor = true;
            this.ConfirmItemCheckButton.Click += new System.EventHandler(this.ConfirmItemCheckButton_Click);
            // 
            // ItemCheckCancelButton
            // 
            this.ItemCheckCancelButton.Location = new System.Drawing.Point(12, 890);
            this.ItemCheckCancelButton.Name = "ItemCheckCancelButton";
            this.ItemCheckCancelButton.Size = new System.Drawing.Size(186, 103);
            this.ItemCheckCancelButton.TabIndex = 2;
            this.ItemCheckCancelButton.Text = "Abbrechen";
            this.ItemCheckCancelButton.UseVisualStyleBackColor = true;
            this.ItemCheckCancelButton.Click += new System.EventHandler(this.ItemCheckCancelButton_Click);
            // 
            // ItemCheckListBox
            // 
            this.ItemCheckListBox.FormattingEnabled = true;
            this.ItemCheckListBox.ItemHeight = 31;
            this.ItemCheckListBox.Location = new System.Drawing.Point(12, 61);
            this.ItemCheckListBox.Name = "ItemCheckListBox";
            this.ItemCheckListBox.Size = new System.Drawing.Size(1448, 810);
            this.ItemCheckListBox.TabIndex = 3;
            // 
            // Staffmembernamelabel
            // 
            this.Staffmembernamelabel.AutoSize = true;
            this.Staffmembernamelabel.Location = new System.Drawing.Point(467, 932);
            this.Staffmembernamelabel.Name = "Staffmembernamelabel";
            this.Staffmembernamelabel.Size = new System.Drawing.Size(280, 32);
            this.Staffmembernamelabel.TabIndex = 4;
            this.Staffmembernamelabel.Text = "Bitte digital signieren";
            // 
            // StaffmemberEntryTextbox
            // 
            this.StaffmemberEntryTextbox.Location = new System.Drawing.Point(762, 926);
            this.StaffmemberEntryTextbox.Name = "StaffmemberEntryTextbox";
            this.StaffmemberEntryTextbox.Size = new System.Drawing.Size(476, 38);
            this.StaffmemberEntryTextbox.TabIndex = 5;
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            this.printDialog1.UseEXDialog = true;
            // 
            // LendReturnCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1472, 1005);
            this.Controls.Add(this.StaffmemberEntryTextbox);
            this.Controls.Add(this.Staffmembernamelabel);
            this.Controls.Add(this.ItemCheckListBox);
            this.Controls.Add(this.ItemCheckCancelButton);
            this.Controls.Add(this.ConfirmItemCheckButton);
            this.Controls.Add(this.ItemCheckTextLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LendReturnCheckForm";
            this.Text = "LendReturnCheckForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ItemCheckTextLabel;
        private System.Windows.Forms.Button ConfirmItemCheckButton;
        private System.Windows.Forms.Button ItemCheckCancelButton;
        private System.Windows.Forms.ListBox ItemCheckListBox;
        private System.Windows.Forms.Label Staffmembernamelabel;
        private System.Windows.Forms.TextBox StaffmemberEntryTextbox;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}