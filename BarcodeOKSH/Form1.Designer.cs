
using System;

namespace BarcodeOKSH
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Root = new System.Windows.Forms.TabControl();
            this.Lend = new System.Windows.Forms.TabPage();
            this.LendBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ReturnDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ConfirmLendButton = new System.Windows.Forms.Button();
            this.LendListBox = new System.Windows.Forms.ListBox();
            this.Obj_Entry_Button = new System.Windows.Forms.Button();
            this.IDCancelButton = new System.Windows.Forms.Button();
            this.Obj_Entry_Box = new System.Windows.Forms.TextBox();
            this.ID_Box = new System.Windows.Forms.GroupBox();
            this.ScanCardLabel = new System.Windows.Forms.Label();
            this.IDConfirmButton = new System.Windows.Forms.Button();
            this.ID_Entry = new System.Windows.Forms.TextBox();
            this.Return = new System.Windows.Forms.TabPage();
            this.ReturnRepairButton = new System.Windows.Forms.Button();
            this.ReturnItemListBox = new System.Windows.Forms.ListBox();
            this.ReturnListConfirmButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ReturnIDEnterButton = new System.Windows.Forms.Button();
            this.ReturnObjCodeEntryBox = new System.Windows.Forms.TextBox();
            this.Calendar = new System.Windows.Forms.TabPage();
            this.EventListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AdminTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ObjAddButton = new System.Windows.Forms.Button();
            this.ObjCodeBox = new System.Windows.Forms.TextBox();
            this.ObjNameBox = new System.Windows.Forms.TextBox();
            this.LabelObjCode = new System.Windows.Forms.Label();
            this.LabelObjName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DOBPicker = new System.Windows.Forms.DateTimePicker();
            this.PersonIDTextBox = new System.Windows.Forms.TextBox();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.PersonID = new System.Windows.Forms.Label();
            this.DOBLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.FIrstNameLabel = new System.Windows.Forms.Label();
            this.PersonAddButton = new System.Windows.Forms.Button();
            this.checkObjectsTab = new System.Windows.Forms.TabPage();
            this.InventorySearchResultListView = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InventorySearchTermBox = new System.Windows.Forms.TextBox();
            this.InventorySearchButton = new System.Windows.Forms.Button();
            this.InventorySearchDropdown = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Root.SuspendLayout();
            this.Lend.SuspendLayout();
            this.LendBox.SuspendLayout();
            this.ID_Box.SuspendLayout();
            this.Return.SuspendLayout();
            this.Calendar.SuspendLayout();
            this.AdminTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.checkObjectsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // Root
            // 
            this.Root.Controls.Add(this.Lend);
            this.Root.Controls.Add(this.Return);
            this.Root.Controls.Add(this.Calendar);
            this.Root.Controls.Add(this.AdminTab);
            this.Root.Controls.Add(this.checkObjectsTab);
            this.Root.Location = new System.Drawing.Point(4, 12);
            this.Root.Name = "Root";
            this.Root.SelectedIndex = 0;
            this.Root.Size = new System.Drawing.Size(2248, 1323);
            this.Root.TabIndex = 0;
            this.Root.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.Root_Selecting);
            // 
            // Lend
            // 
            this.Lend.Controls.Add(this.LendBox);
            this.Lend.Controls.Add(this.ID_Box);
            this.Lend.Location = new System.Drawing.Point(10, 48);
            this.Lend.Name = "Lend";
            this.Lend.Padding = new System.Windows.Forms.Padding(3);
            this.Lend.Size = new System.Drawing.Size(2228, 1265);
            this.Lend.TabIndex = 0;
            this.Lend.Text = "Verleih";
            this.Lend.UseVisualStyleBackColor = true;
            // 
            // LendBox
            // 
            this.LendBox.Controls.Add(this.label2);
            this.LendBox.Controls.Add(this.ReturnDateTimePicker);
            this.LendBox.Controls.Add(this.ConfirmLendButton);
            this.LendBox.Controls.Add(this.LendListBox);
            this.LendBox.Controls.Add(this.Obj_Entry_Button);
            this.LendBox.Controls.Add(this.IDCancelButton);
            this.LendBox.Controls.Add(this.Obj_Entry_Box);
            this.LendBox.Location = new System.Drawing.Point(13, 105);
            this.LendBox.Name = "LendBox";
            this.LendBox.Size = new System.Drawing.Size(2166, 1052);
            this.LendBox.TabIndex = 3;
            this.LendBox.TabStop = false;
            this.LendBox.Text = "Verleihen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1533, 904);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ausleihen bis:";
            // 
            // ReturnDateTimePicker
            // 
            this.ReturnDateTimePicker.Location = new System.Drawing.Point(1539, 957);
            this.ReturnDateTimePicker.Name = "ReturnDateTimePicker";
            this.ReturnDateTimePicker.Size = new System.Drawing.Size(363, 38);
            this.ReturnDateTimePicker.TabIndex = 8;
            // 
            // ConfirmLendButton
            // 
            this.ConfirmLendButton.Location = new System.Drawing.Point(1932, 954);
            this.ConfirmLendButton.Name = "ConfirmLendButton";
            this.ConfirmLendButton.Size = new System.Drawing.Size(228, 92);
            this.ConfirmLendButton.TabIndex = 7;
            this.ConfirmLendButton.Text = "Verleih bestätigen";
            this.ConfirmLendButton.UseVisualStyleBackColor = true;
            this.ConfirmLendButton.Click += new System.EventHandler(this.ConfirmLendButton_Click);
            // 
            // LendListBox
            // 
            this.LendListBox.FormattingEnabled = true;
            this.LendListBox.ItemHeight = 31;
            this.LendListBox.Location = new System.Drawing.Point(12, 123);
            this.LendListBox.Name = "LendListBox";
            this.LendListBox.Size = new System.Drawing.Size(1183, 872);
            this.LendListBox.TabIndex = 6;
            // 
            // Obj_Entry_Button
            // 
            this.Obj_Entry_Button.Location = new System.Drawing.Point(325, 45);
            this.Obj_Entry_Button.Name = "Obj_Entry_Button";
            this.Obj_Entry_Button.Size = new System.Drawing.Size(129, 58);
            this.Obj_Entry_Button.TabIndex = 4;
            this.Obj_Entry_Button.Text = "Enter";
            this.Obj_Entry_Button.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.Obj_Entry_Button.UseVisualStyleBackColor = true;
            this.Obj_Entry_Button.Click += new System.EventHandler(this.Obj_Entry_Button_Click);
            // 
            // IDCancelButton
            // 
            this.IDCancelButton.Location = new System.Drawing.Point(1932, 18);
            this.IDCancelButton.Name = "IDCancelButton";
            this.IDCancelButton.Size = new System.Drawing.Size(228, 92);
            this.IDCancelButton.TabIndex = 5;
            this.IDCancelButton.Text = "Verleih Abbrechen";
            this.IDCancelButton.UseVisualStyleBackColor = true;
            this.IDCancelButton.Click += new System.EventHandler(this.IDCancelButton_Click);
            // 
            // Obj_Entry_Box
            // 
            this.Obj_Entry_Box.Location = new System.Drawing.Point(12, 65);
            this.Obj_Entry_Box.Name = "Obj_Entry_Box";
            this.Obj_Entry_Box.Size = new System.Drawing.Size(290, 38);
            this.Obj_Entry_Box.TabIndex = 3;
            this.Obj_Entry_Box.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Obj_ID_Entry_KeyDown);
            // 
            // ID_Box
            // 
            this.ID_Box.Controls.Add(this.ScanCardLabel);
            this.ID_Box.Controls.Add(this.IDConfirmButton);
            this.ID_Box.Controls.Add(this.ID_Entry);
            this.ID_Box.Location = new System.Drawing.Point(13, 7);
            this.ID_Box.Name = "ID_Box";
            this.ID_Box.Size = new System.Drawing.Size(1755, 100);
            this.ID_Box.TabIndex = 4;
            this.ID_Box.TabStop = false;
            this.ID_Box.Text = "ID-Entry";
            // 
            // ScanCardLabel
            // 
            this.ScanCardLabel.AutoSize = true;
            this.ScanCardLabel.Location = new System.Drawing.Point(6, 41);
            this.ScanCardLabel.Name = "ScanCardLabel";
            this.ScanCardLabel.Size = new System.Drawing.Size(226, 32);
            this.ScanCardLabel.TabIndex = 1;
            this.ScanCardLabel.Text = "ID-Card scannen";
            // 
            // IDConfirmButton
            // 
            this.IDConfirmButton.Location = new System.Drawing.Point(552, 15);
            this.IDConfirmButton.Name = "IDConfirmButton";
            this.IDConfirmButton.Size = new System.Drawing.Size(129, 58);
            this.IDConfirmButton.TabIndex = 2;
            this.IDConfirmButton.Text = "Enter";
            this.IDConfirmButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.IDConfirmButton.UseVisualStyleBackColor = true;
            this.IDConfirmButton.Click += new System.EventHandler(this.IDConfirmButton_Click);
            // 
            // ID_Entry
            // 
            this.ID_Entry.Location = new System.Drawing.Point(238, 35);
            this.ID_Entry.Name = "ID_Entry";
            this.ID_Entry.Size = new System.Drawing.Size(290, 38);
            this.ID_Entry.TabIndex = 0;
            this.ID_Entry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.IDEntry_KeyDown);
            // 
            // Return
            // 
            this.Return.Controls.Add(this.ReturnRepairButton);
            this.Return.Controls.Add(this.ReturnItemListBox);
            this.Return.Controls.Add(this.ReturnListConfirmButton);
            this.Return.Controls.Add(this.label1);
            this.Return.Controls.Add(this.ReturnIDEnterButton);
            this.Return.Controls.Add(this.ReturnObjCodeEntryBox);
            this.Return.Location = new System.Drawing.Point(10, 48);
            this.Return.Name = "Return";
            this.Return.Padding = new System.Windows.Forms.Padding(3);
            this.Return.Size = new System.Drawing.Size(2228, 1265);
            this.Return.TabIndex = 1;
            this.Return.Text = "Rückgabe";
            this.Return.UseVisualStyleBackColor = true;
            // 
            // ReturnRepairButton
            // 
            this.ReturnRepairButton.Location = new System.Drawing.Point(1389, 4);
            this.ReturnRepairButton.Name = "ReturnRepairButton";
            this.ReturnRepairButton.Size = new System.Drawing.Size(413, 67);
            this.ReturnRepairButton.TabIndex = 9;
            this.ReturnRepairButton.Text = "In Reparatur geben";
            this.ReturnRepairButton.UseVisualStyleBackColor = true;
            this.ReturnRepairButton.Click += new System.EventHandler(this.ReturnRepairButton_Click);
            // 
            // ReturnItemListBox
            // 
            this.ReturnItemListBox.FormattingEnabled = true;
            this.ReturnItemListBox.ItemHeight = 31;
            this.ReturnItemListBox.Location = new System.Drawing.Point(11, 88);
            this.ReturnItemListBox.Name = "ReturnItemListBox";
            this.ReturnItemListBox.Size = new System.Drawing.Size(2214, 1182);
            this.ReturnItemListBox.TabIndex = 8;
            // 
            // ReturnListConfirmButton
            // 
            this.ReturnListConfirmButton.Location = new System.Drawing.Point(1808, 3);
            this.ReturnListConfirmButton.Name = "ReturnListConfirmButton";
            this.ReturnListConfirmButton.Size = new System.Drawing.Size(414, 68);
            this.ReturnListConfirmButton.TabIndex = 7;
            this.ReturnListConfirmButton.Text = "Rückgabe bestätigen";
            this.ReturnListConfirmButton.UseVisualStyleBackColor = true;
            this.ReturnListConfirmButton.Click += new System.EventHandler(this.ReturnListConfirmButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Objekt Scannen";
            // 
            // ReturnIDEnterButton
            // 
            this.ReturnIDEnterButton.Location = new System.Drawing.Point(550, 14);
            this.ReturnIDEnterButton.Name = "ReturnIDEnterButton";
            this.ReturnIDEnterButton.Size = new System.Drawing.Size(129, 58);
            this.ReturnIDEnterButton.TabIndex = 5;
            this.ReturnIDEnterButton.Text = "Enter";
            this.ReturnIDEnterButton.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ReturnIDEnterButton.UseVisualStyleBackColor = true;
            this.ReturnIDEnterButton.Click += new System.EventHandler(this.ReturnIDEnterButton_Click);
            // 
            // ReturnObjCodeEntryBox
            // 
            this.ReturnObjCodeEntryBox.Location = new System.Drawing.Point(237, 15);
            this.ReturnObjCodeEntryBox.Name = "ReturnObjCodeEntryBox";
            this.ReturnObjCodeEntryBox.Size = new System.Drawing.Size(290, 38);
            this.ReturnObjCodeEntryBox.TabIndex = 3;
            this.ReturnObjCodeEntryBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ObjectReturnTextKeyListener);
            // 
            // Calendar
            // 
            this.Calendar.Controls.Add(this.EventListView);
            this.Calendar.Location = new System.Drawing.Point(10, 48);
            this.Calendar.Name = "Calendar";
            this.Calendar.Padding = new System.Windows.Forms.Padding(3);
            this.Calendar.Size = new System.Drawing.Size(2228, 1265);
            this.Calendar.TabIndex = 2;
            this.Calendar.Text = "Ereignisse";
            this.Calendar.UseVisualStyleBackColor = true;
            // 
            // EventListView
            // 
            this.EventListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.EventListView.GridLines = true;
            this.EventListView.HideSelection = false;
            this.EventListView.Location = new System.Drawing.Point(-2, 7);
            this.EventListView.Name = "EventListView";
            this.EventListView.Size = new System.Drawing.Size(2224, 1252);
            this.EventListView.TabIndex = 1;
            this.EventListView.UseCompatibleStateImageBehavior = false;
            this.EventListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 214;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 158;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ausgeliehen von";
            this.columnHeader3.Width = 308;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Rückgabe am";
            this.columnHeader4.Width = 402;
            // 
            // AdminTab
            // 
            this.AdminTab.Controls.Add(this.groupBox3);
            this.AdminTab.Controls.Add(this.groupBox2);
            this.AdminTab.Location = new System.Drawing.Point(10, 48);
            this.AdminTab.Name = "AdminTab";
            this.AdminTab.Padding = new System.Windows.Forms.Padding(3);
            this.AdminTab.Size = new System.Drawing.Size(2228, 1265);
            this.AdminTab.TabIndex = 3;
            this.AdminTab.Text = "Admin";
            this.AdminTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ObjAddButton);
            this.groupBox3.Controls.Add(this.ObjCodeBox);
            this.groupBox3.Controls.Add(this.ObjNameBox);
            this.groupBox3.Controls.Add(this.LabelObjCode);
            this.groupBox3.Controls.Add(this.LabelObjName);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1086, 1269);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Objekt hinzufügen";
            // 
            // ObjAddButton
            // 
            this.ObjAddButton.Location = new System.Drawing.Point(12, 246);
            this.ObjAddButton.Name = "ObjAddButton";
            this.ObjAddButton.Size = new System.Drawing.Size(292, 103);
            this.ObjAddButton.TabIndex = 4;
            this.ObjAddButton.Text = "Hinzufügen";
            this.ObjAddButton.UseVisualStyleBackColor = true;
            this.ObjAddButton.Click += new System.EventHandler(this.ObjAddButton_Click);
            // 
            // ObjCodeBox
            // 
            this.ObjCodeBox.Location = new System.Drawing.Point(196, 167);
            this.ObjCodeBox.Name = "ObjCodeBox";
            this.ObjCodeBox.Size = new System.Drawing.Size(279, 38);
            this.ObjCodeBox.TabIndex = 3;
            // 
            // ObjNameBox
            // 
            this.ObjNameBox.Location = new System.Drawing.Point(196, 88);
            this.ObjNameBox.Name = "ObjNameBox";
            this.ObjNameBox.Size = new System.Drawing.Size(279, 38);
            this.ObjNameBox.TabIndex = 2;
            // 
            // LabelObjCode
            // 
            this.LabelObjCode.AutoSize = true;
            this.LabelObjCode.Location = new System.Drawing.Point(6, 167);
            this.LabelObjCode.Name = "LabelObjCode";
            this.LabelObjCode.Size = new System.Drawing.Size(159, 32);
            this.LabelObjCode.TabIndex = 1;
            this.LabelObjCode.Text = "Objektcode";
            // 
            // LabelObjName
            // 
            this.LabelObjName.AutoSize = true;
            this.LabelObjName.Location = new System.Drawing.Point(6, 94);
            this.LabelObjName.Name = "LabelObjName";
            this.LabelObjName.Size = new System.Drawing.Size(168, 32);
            this.LabelObjName.TabIndex = 0;
            this.LabelObjName.Text = "Objektname";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DOBPicker);
            this.groupBox2.Controls.Add(this.PersonIDTextBox);
            this.groupBox2.Controls.Add(this.LastNameTextBox);
            this.groupBox2.Controls.Add(this.FirstNameTextBox);
            this.groupBox2.Controls.Add(this.PersonID);
            this.groupBox2.Controls.Add(this.DOBLabel);
            this.groupBox2.Controls.Add(this.LastNameLabel);
            this.groupBox2.Controls.Add(this.FIrstNameLabel);
            this.groupBox2.Controls.Add(this.PersonAddButton);
            this.groupBox2.Location = new System.Drawing.Point(1120, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1105, 1259);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Person hinzufügen";
            // 
            // DOBPicker
            // 
            this.DOBPicker.Location = new System.Drawing.Point(193, 229);
            this.DOBPicker.Name = "DOBPicker";
            this.DOBPicker.Size = new System.Drawing.Size(398, 38);
            this.DOBPicker.TabIndex = 8;
            // 
            // PersonIDTextBox
            // 
            this.PersonIDTextBox.Location = new System.Drawing.Point(193, 311);
            this.PersonIDTextBox.Name = "PersonIDTextBox";
            this.PersonIDTextBox.Size = new System.Drawing.Size(398, 38);
            this.PersonIDTextBox.TabIndex = 7;
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.Location = new System.Drawing.Point(193, 168);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(398, 38);
            this.LastNameTextBox.TabIndex = 6;
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(193, 87);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(398, 38);
            this.FirstNameTextBox.TabIndex = 5;
            // 
            // PersonID
            // 
            this.PersonID.AutoSize = true;
            this.PersonID.Location = new System.Drawing.Point(17, 317);
            this.PersonID.Name = "PersonID";
            this.PersonID.Size = new System.Drawing.Size(170, 32);
            this.PersonID.TabIndex = 4;
            this.PersonID.Text = "Personen ID";
            // 
            // DOBLabel
            // 
            this.DOBLabel.AutoSize = true;
            this.DOBLabel.Location = new System.Drawing.Point(17, 236);
            this.DOBLabel.Name = "DOBLabel";
            this.DOBLabel.Size = new System.Drawing.Size(155, 32);
            this.DOBLabel.TabIndex = 3;
            this.DOBLabel.Text = "Geburtstag";
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(17, 167);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(151, 32);
            this.LastNameLabel.TabIndex = 2;
            this.LastNameLabel.Text = "Nachname";
            // 
            // FIrstNameLabel
            // 
            this.FIrstNameLabel.AutoSize = true;
            this.FIrstNameLabel.Location = new System.Drawing.Point(17, 93);
            this.FIrstNameLabel.Name = "FIrstNameLabel";
            this.FIrstNameLabel.Size = new System.Drawing.Size(129, 32);
            this.FIrstNameLabel.TabIndex = 1;
            this.FIrstNameLabel.Text = "Vorname";
            // 
            // PersonAddButton
            // 
            this.PersonAddButton.Location = new System.Drawing.Point(17, 452);
            this.PersonAddButton.Name = "PersonAddButton";
            this.PersonAddButton.Size = new System.Drawing.Size(395, 103);
            this.PersonAddButton.TabIndex = 0;
            this.PersonAddButton.Text = "Hinzufügen";
            this.PersonAddButton.UseVisualStyleBackColor = true;
            this.PersonAddButton.Click += new System.EventHandler(this.PersonAddButton_Click);
            // 
            // checkObjectsTab
            // 
            this.checkObjectsTab.Controls.Add(this.InventorySearchResultListView);
            this.checkObjectsTab.Controls.Add(this.InventorySearchTermBox);
            this.checkObjectsTab.Controls.Add(this.InventorySearchButton);
            this.checkObjectsTab.Controls.Add(this.InventorySearchDropdown);
            this.checkObjectsTab.Controls.Add(this.label3);
            this.checkObjectsTab.Location = new System.Drawing.Point(10, 48);
            this.checkObjectsTab.Name = "checkObjectsTab";
            this.checkObjectsTab.Padding = new System.Windows.Forms.Padding(3);
            this.checkObjectsTab.Size = new System.Drawing.Size(2228, 1265);
            this.checkObjectsTab.TabIndex = 4;
            this.checkObjectsTab.Text = "Inventar Durchsuchen";
            this.checkObjectsTab.UseVisualStyleBackColor = true;
            // 
            // InventorySearchResultListView
            // 
            this.InventorySearchResultListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.InventorySearchResultListView.GridLines = true;
            this.InventorySearchResultListView.HideSelection = false;
            this.InventorySearchResultListView.Location = new System.Drawing.Point(2, 110);
            this.InventorySearchResultListView.Name = "InventorySearchResultListView";
            this.InventorySearchResultListView.Size = new System.Drawing.Size(2224, 1148);
            this.InventorySearchResultListView.TabIndex = 5;
            this.InventorySearchResultListView.UseCompatibleStateImageBehavior = false;
            this.InventorySearchResultListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Name";
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
            // InventorySearchTermBox
            // 
            this.InventorySearchTermBox.Location = new System.Drawing.Point(485, 43);
            this.InventorySearchTermBox.Name = "InventorySearchTermBox";
            this.InventorySearchTermBox.Size = new System.Drawing.Size(451, 38);
            this.InventorySearchTermBox.TabIndex = 4;
            // 
            // InventorySearchButton
            // 
            this.InventorySearchButton.Location = new System.Drawing.Point(962, 43);
            this.InventorySearchButton.Name = "InventorySearchButton";
            this.InventorySearchButton.Size = new System.Drawing.Size(178, 39);
            this.InventorySearchButton.TabIndex = 2;
            this.InventorySearchButton.Text = "Suchen";
            this.InventorySearchButton.UseVisualStyleBackColor = true;
            this.InventorySearchButton.Click += new System.EventHandler(this.InventorySearchButton_Click);
            // 
            // InventorySearchDropdown
            // 
            this.InventorySearchDropdown.FormattingEnabled = true;
            this.InventorySearchDropdown.Items.AddRange(new object[] {
            "Name",
            "Barcode",
            "Status"});
            this.InventorySearchDropdown.Location = new System.Drawing.Point(176, 43);
            this.InventorySearchDropdown.Name = "InventorySearchDropdown";
            this.InventorySearchDropdown.Size = new System.Drawing.Size(283, 39);
            this.InventorySearchDropdown.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 32);
            this.label3.TabIndex = 0;
            this.label3.Text = "Suche nach";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2264, 1347);
            this.Controls.Add(this.Root);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Ausleihsystem OKSH";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyReader_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyReader_KeyPress);
            this.Root.ResumeLayout(false);
            this.Lend.ResumeLayout(false);
            this.LendBox.ResumeLayout(false);
            this.LendBox.PerformLayout();
            this.ID_Box.ResumeLayout(false);
            this.ID_Box.PerformLayout();
            this.Return.ResumeLayout(false);
            this.Return.PerformLayout();
            this.Calendar.ResumeLayout(false);
            this.AdminTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.checkObjectsTab.ResumeLayout(false);
            this.checkObjectsTab.PerformLayout();
            this.ResumeLayout(false);

        }


        private void KeyReader_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            System.Console.Write("Button press: ");
            System.Console.WriteLine(e.KeyCode);

        }


        private void KeyReader_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            System.Console.Write("Button press: ");
            System.Console.WriteLine(e.KeyChar);
        }


        #endregion

        private System.Windows.Forms.TabControl Root;
        private System.Windows.Forms.TabPage Lend;
        private System.Windows.Forms.Label ScanCardLabel;
        private System.Windows.Forms.TextBox ID_Entry;
        private System.Windows.Forms.TabPage Return;
        private System.Windows.Forms.TabPage Calendar;
        private System.Windows.Forms.TabPage AdminTab;
        private System.Windows.Forms.TabPage checkObjectsTab;
        private System.Windows.Forms.GroupBox LendBox;
        private System.Windows.Forms.Button IDConfirmButton;
        private System.Windows.Forms.GroupBox ID_Box;
        private System.Windows.Forms.Button IDCancelButton;
        private System.Windows.Forms.ListBox LendListBox;
        private System.Windows.Forms.Button Obj_Entry_Button;
        private System.Windows.Forms.TextBox Obj_Entry_Box;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ReturnIDEnterButton;
        private System.Windows.Forms.TextBox ReturnObjCodeEntryBox;
        private System.Windows.Forms.Button ConfirmLendButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LabelObjCode;
        private System.Windows.Forms.Label LabelObjName;
        private System.Windows.Forms.Button ObjAddButton;
        private System.Windows.Forms.TextBox ObjCodeBox;
        private System.Windows.Forms.TextBox ObjNameBox;
        private System.Windows.Forms.DateTimePicker DOBPicker;
        private System.Windows.Forms.TextBox PersonIDTextBox;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.Label PersonID;
        private System.Windows.Forms.Label DOBLabel;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Label FIrstNameLabel;
        private System.Windows.Forms.Button PersonAddButton;
        private System.Windows.Forms.TextBox InventorySearchTermBox;
        private System.Windows.Forms.Button InventorySearchButton;
        private System.Windows.Forms.ComboBox InventorySearchDropdown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ReturnListConfirmButton;
        private System.Windows.Forms.ListBox ReturnItemListBox;
        private System.Windows.Forms.Button ReturnRepairButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker ReturnDateTimePicker;
        private System.Windows.Forms.ListView EventListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView InventorySearchResultListView;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
    }



}

