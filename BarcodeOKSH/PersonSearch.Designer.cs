namespace BarcodeOKSH
{
    partial class PersonSearch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonSearch));
            this.PersonSearchModeDropdown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SearchPersonButton = new System.Windows.Forms.Button();
            this.PersonSearchTermTextBox = new System.Windows.Forms.TextBox();
            this.PersonSearchResultLabel = new System.Windows.Forms.Label();
            this.PersonSearchResultListBox = new System.Windows.Forms.ListBox();
            this.PersonAcceptButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PersonSearchModeDropdown
            // 
            this.PersonSearchModeDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PersonSearchModeDropdown.FormattingEnabled = true;
            this.PersonSearchModeDropdown.Items.AddRange(new object[] {
            "Vorname",
            "Nachname"});
            this.PersonSearchModeDropdown.Location = new System.Drawing.Point(187, 18);
            this.PersonSearchModeDropdown.Name = "PersonSearchModeDropdown";
            this.PersonSearchModeDropdown.Size = new System.Drawing.Size(344, 39);
            this.PersonSearchModeDropdown.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Suche nach:";
            // 
            // SearchPersonButton
            // 
            this.SearchPersonButton.Location = new System.Drawing.Point(546, 18);
            this.SearchPersonButton.Name = "SearchPersonButton";
            this.SearchPersonButton.Size = new System.Drawing.Size(242, 119);
            this.SearchPersonButton.TabIndex = 2;
            this.SearchPersonButton.Text = "Suchen";
            this.SearchPersonButton.UseVisualStyleBackColor = true;
            this.SearchPersonButton.Click += new System.EventHandler(this.SearchPersonButton_Click);
            // 
            // PersonSearchTermTextBox
            // 
            this.PersonSearchTermTextBox.Location = new System.Drawing.Point(19, 89);
            this.PersonSearchTermTextBox.Name = "PersonSearchTermTextBox";
            this.PersonSearchTermTextBox.Size = new System.Drawing.Size(512, 38);
            this.PersonSearchTermTextBox.TabIndex = 3;
            this.PersonSearchTermTextBox.TextChanged += new System.EventHandler(this.PersonSearchTermTextBox_TextChanged);
            // 
            // PersonSearchResultLabel
            // 
            this.PersonSearchResultLabel.AutoSize = true;
            this.PersonSearchResultLabel.Location = new System.Drawing.Point(13, 500);
            this.PersonSearchResultLabel.Name = "PersonSearchResultLabel";
            this.PersonSearchResultLabel.Size = new System.Drawing.Size(95, 32);
            this.PersonSearchResultLabel.TabIndex = 5;
            this.PersonSearchResultLabel.Text = "Result";
            // 
            // PersonSearchResultListBox
            // 
            this.PersonSearchResultListBox.FormattingEnabled = true;
            this.PersonSearchResultListBox.ItemHeight = 31;
            this.PersonSearchResultListBox.Location = new System.Drawing.Point(19, 159);
            this.PersonSearchResultListBox.Name = "PersonSearchResultListBox";
            this.PersonSearchResultListBox.Size = new System.Drawing.Size(769, 314);
            this.PersonSearchResultListBox.TabIndex = 6;
            this.PersonSearchResultListBox.SelectedIndexChanged += new System.EventHandler(this.PersonSearchResultListBox_SelectedIndexChanged);
            // 
            // PersonAcceptButton
            // 
            this.PersonAcceptButton.Location = new System.Drawing.Point(525, 479);
            this.PersonAcceptButton.Name = "PersonAcceptButton";
            this.PersonAcceptButton.Size = new System.Drawing.Size(263, 109);
            this.PersonAcceptButton.TabIndex = 7;
            this.PersonAcceptButton.Text = "Person auswählen";
            this.PersonAcceptButton.UseVisualStyleBackColor = true;
            this.PersonAcceptButton.Click += new System.EventHandler(this.PersonAcceptButton_Click);
            // 
            // Form2
            // 
            this.AcceptButton = this.PersonAcceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 600);
            this.Controls.Add(this.PersonAcceptButton);
            this.Controls.Add(this.PersonSearchResultListBox);
            this.Controls.Add(this.PersonSearchResultLabel);
            this.Controls.Add(this.PersonSearchTermTextBox);
            this.Controls.Add(this.SearchPersonButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PersonSearchModeDropdown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Personenauswahl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox PersonSearchModeDropdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SearchPersonButton;
        private System.Windows.Forms.TextBox PersonSearchTermTextBox;
        private System.Windows.Forms.Label PersonSearchResultLabel;
        private System.Windows.Forms.ListBox PersonSearchResultListBox;
        private System.Windows.Forms.Button PersonAcceptButton;
    }
}