namespace BarcodeOKSH
{
    partial class ReservationForm
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
            this.ReservationBox = new System.Windows.Forms.GroupBox();
            this.SignatureTextBox = new System.Windows.Forms.TextBox();
            this.SignatureLabel = new System.Windows.Forms.Label();
            this.AddObjectButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ReserveFromTimePicker = new System.Windows.Forms.DateTimePicker();
            this.LendListBox = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.ReturnDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ConfirmLendButton = new System.Windows.Forms.Button();
            this.IDCancelButton = new System.Windows.Forms.Button();
            this.ReservationBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReservationBox
            // 
            this.ReservationBox.Controls.Add(this.SignatureTextBox);
            this.ReservationBox.Controls.Add(this.SignatureLabel);
            this.ReservationBox.Controls.Add(this.AddObjectButton);
            this.ReservationBox.Controls.Add(this.label1);
            this.ReservationBox.Controls.Add(this.ReserveFromTimePicker);
            this.ReservationBox.Controls.Add(this.LendListBox);
            this.ReservationBox.Controls.Add(this.label2);
            this.ReservationBox.Controls.Add(this.ReturnDateTimePicker);
            this.ReservationBox.Controls.Add(this.ConfirmLendButton);
            this.ReservationBox.Controls.Add(this.IDCancelButton);
            this.ReservationBox.Location = new System.Drawing.Point(3, 12);
            this.ReservationBox.Name = "ReservationBox";
            this.ReservationBox.Size = new System.Drawing.Size(2166, 1052);
            this.ReservationBox.TabIndex = 5;
            this.ReservationBox.TabStop = false;
            this.ReservationBox.Text = "Vormerken";
            // 
            // SignatureTextBox
            // 
            this.SignatureTextBox.Location = new System.Drawing.Point(1566, 858);
            this.SignatureTextBox.Name = "SignatureTextBox";
            this.SignatureTextBox.Size = new System.Drawing.Size(363, 38);
            this.SignatureTextBox.TabIndex = 15;
            // 
            // SignatureLabel
            // 
            this.SignatureLabel.AutoSize = true;
            this.SignatureLabel.Location = new System.Drawing.Point(1566, 799);
            this.SignatureLabel.Name = "SignatureLabel";
            this.SignatureLabel.Size = new System.Drawing.Size(225, 32);
            this.SignatureLabel.TabIndex = 14;
            this.SignatureLabel.Text = "Digitale Signatur";
            // 
            // AddObjectButton
            // 
            this.AddObjectButton.Location = new System.Drawing.Point(35, 53);
            this.AddObjectButton.Name = "AddObjectButton";
            this.AddObjectButton.Size = new System.Drawing.Size(424, 51);
            this.AddObjectButton.TabIndex = 13;
            this.AddObjectButton.Text = "Objekt Hinzufügen";
            this.AddObjectButton.UseVisualStyleBackColor = true;
            this.AddObjectButton.Click += new System.EventHandler(this.AddObjectButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1560, 549);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "Vormerken von:";
            // 
            // ReserveFromTimePicker
            // 
            this.ReserveFromTimePicker.Location = new System.Drawing.Point(1566, 602);
            this.ReserveFromTimePicker.Name = "ReserveFromTimePicker";
            this.ReserveFromTimePicker.Size = new System.Drawing.Size(363, 38);
            this.ReserveFromTimePicker.TabIndex = 11;
            // 
            // LendListBox
            // 
            this.LendListBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader15});
            this.LendListBox.GridLines = true;
            this.LendListBox.HideSelection = false;
            this.LendListBox.Location = new System.Drawing.Point(35, 110);
            this.LendListBox.Name = "LendListBox";
            this.LendListBox.Size = new System.Drawing.Size(1440, 885);
            this.LendListBox.TabIndex = 10;
            this.LendListBox.UseCompatibleStateImageBehavior = false;
            this.LendListBox.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Name";
            this.columnHeader9.Width = 285;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Status";
            this.columnHeader10.Width = 125;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Tags";
            this.columnHeader15.Width = 408;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1560, 665);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 32);
            this.label2.TabIndex = 9;
            this.label2.Text = "Vormerken bis:";
            // 
            // ReturnDateTimePicker
            // 
            this.ReturnDateTimePicker.Location = new System.Drawing.Point(1566, 718);
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
            this.ConfirmLendButton.Text = "Vormerken bestätigen";
            this.ConfirmLendButton.UseVisualStyleBackColor = true;
            this.ConfirmLendButton.Click += new System.EventHandler(this.ConfirmLendButton_Click);
            // 
            // IDCancelButton
            // 
            this.IDCancelButton.Location = new System.Drawing.Point(1932, 18);
            this.IDCancelButton.Name = "IDCancelButton";
            this.IDCancelButton.Size = new System.Drawing.Size(228, 92);
            this.IDCancelButton.TabIndex = 5;
            this.IDCancelButton.Text = "Vormerken Abbrechen";
            this.IDCancelButton.UseVisualStyleBackColor = true;
            this.IDCancelButton.Click += new System.EventHandler(this.IDCancelButton_Click);
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2172, 1079);
            this.Controls.Add(this.ReservationBox);
            this.Name = "ReservationForm";
            this.Text = "Objekte vormerken";
            this.ReservationBox.ResumeLayout(false);
            this.ReservationBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox ReservationBox;
        private System.Windows.Forms.ListView LendListBox;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker ReturnDateTimePicker;
        private System.Windows.Forms.Button ConfirmLendButton;
        private System.Windows.Forms.Button IDCancelButton;
        private System.Windows.Forms.Button AddObjectButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker ReserveFromTimePicker;
        private System.Windows.Forms.TextBox SignatureTextBox;
        private System.Windows.Forms.Label SignatureLabel;
    }
}