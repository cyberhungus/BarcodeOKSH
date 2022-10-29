namespace BarcodeOKSH
{
    partial class ObjectSearch
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
            this.InventorySearchResultListView = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InventorySearchTermBox = new System.Windows.Forms.TextBox();
            this.InventorySearchButton = new System.Windows.Forms.Button();
            this.InventorySearchDropdown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SearchSelectionLabel = new System.Windows.Forms.Label();
            this.ConfirmSearchSelection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InventorySearchResultListView
            // 
            this.InventorySearchResultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader17});
            this.InventorySearchResultListView.GridLines = true;
            this.InventorySearchResultListView.HideSelection = false;
            this.InventorySearchResultListView.Location = new System.Drawing.Point(12, 116);
            this.InventorySearchResultListView.Name = "InventorySearchResultListView";
            this.InventorySearchResultListView.Size = new System.Drawing.Size(2224, 1148);
            this.InventorySearchResultListView.TabIndex = 6;
            this.InventorySearchResultListView.UseCompatibleStateImageBehavior = false;
            this.InventorySearchResultListView.View = System.Windows.Forms.View.Details;
            this.InventorySearchResultListView.SelectedIndexChanged += new System.EventHandler(this.InventoryListIndexChange);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Objekt";
            this.columnHeader5.Width = 214;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Status";
            this.columnHeader6.Width = 158;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Ausgeliehen von";
            this.columnHeader7.Width = 308;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Rückgabe am";
            this.columnHeader8.Width = 402;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "VerliehenDurch";
            this.columnHeader17.Width = 279;
            // 
            // InventorySearchTermBox
            // 
            this.InventorySearchTermBox.Location = new System.Drawing.Point(491, 12);
            this.InventorySearchTermBox.Name = "InventorySearchTermBox";
            this.InventorySearchTermBox.Size = new System.Drawing.Size(451, 38);
            this.InventorySearchTermBox.TabIndex = 10;
            // 
            // InventorySearchButton
            // 
            this.InventorySearchButton.Location = new System.Drawing.Point(948, 12);
            this.InventorySearchButton.Name = "InventorySearchButton";
            this.InventorySearchButton.Size = new System.Drawing.Size(266, 98);
            this.InventorySearchButton.TabIndex = 9;
            this.InventorySearchButton.Text = "Suchen";
            this.InventorySearchButton.UseVisualStyleBackColor = true;
            this.InventorySearchButton.Click += new System.EventHandler(this.InventorySearchButton_Click);
            // 
            // InventorySearchDropdown
            // 
            this.InventorySearchDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InventorySearchDropdown.FormattingEnabled = true;
            this.InventorySearchDropdown.Items.AddRange(new object[] {
            "Objekt",
            "Barcode",
            "Status",
            "Tags"});
            this.InventorySearchDropdown.Location = new System.Drawing.Point(193, 11);
            this.InventorySearchDropdown.Name = "InventorySearchDropdown";
            this.InventorySearchDropdown.Size = new System.Drawing.Size(283, 39);
            this.InventorySearchDropdown.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "Suche nach";
            // 
            // SearchSelectionLabel
            // 
            this.SearchSelectionLabel.AutoSize = true;
            this.SearchSelectionLabel.Location = new System.Drawing.Point(13, 1283);
            this.SearchSelectionLabel.Name = "SearchSelectionLabel";
            this.SearchSelectionLabel.Size = new System.Drawing.Size(122, 32);
            this.SearchSelectionLabel.TabIndex = 11;
            this.SearchSelectionLabel.Text = "Auswahl";
            // 
            // ConfirmSearchSelection
            // 
            this.ConfirmSearchSelection.Location = new System.Drawing.Point(2139, 1283);
            this.ConfirmSearchSelection.Name = "ConfirmSearchSelection";
            this.ConfirmSearchSelection.Size = new System.Drawing.Size(320, 178);
            this.ConfirmSearchSelection.TabIndex = 12;
            this.ConfirmSearchSelection.Text = "Bestätigen";
            this.ConfirmSearchSelection.UseVisualStyleBackColor = true;
            this.ConfirmSearchSelection.Click += new System.EventHandler(this.ConfirmSearchSelection_Click);
            // 
            // ObjectSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2461, 1466);
            this.Controls.Add(this.ConfirmSearchSelection);
            this.Controls.Add(this.SearchSelectionLabel);
            this.Controls.Add(this.InventorySearchTermBox);
            this.Controls.Add(this.InventorySearchButton);
            this.Controls.Add(this.InventorySearchDropdown);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.InventorySearchResultListView);
            this.Name = "ObjectSearch";
            this.Text = "ObjectSearch";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView InventorySearchResultListView;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.TextBox InventorySearchTermBox;
        private System.Windows.Forms.Button InventorySearchButton;
        private System.Windows.Forms.ComboBox InventorySearchDropdown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SearchSelectionLabel;
        private System.Windows.Forms.Button ConfirmSearchSelection;
    }
}