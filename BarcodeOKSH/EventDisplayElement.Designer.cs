namespace BarcodeOKSH
{
    partial class EventDisplayElement
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

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.DateLabel = new System.Windows.Forms.Label();
            this.BorrowedListView = new System.Windows.Forms.ListView();
            this.ReservedListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.Reserviert = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateLabel.Location = new System.Drawing.Point(3, 0);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(376, 54);
            this.DateLabel.TabIndex = 2;
            this.DateLabel.Text = "Smarch 1st 2099";
            this.DateLabel.Click += new System.EventHandler(this.DateLabel_Click);
            // 
            // BorrowedListView
            // 
            this.BorrowedListView.HideSelection = false;
            this.BorrowedListView.Location = new System.Drawing.Point(0, 120);
            this.BorrowedListView.Name = "BorrowedListView";
            this.BorrowedListView.Size = new System.Drawing.Size(513, 79);
            this.BorrowedListView.TabIndex = 0;
            this.BorrowedListView.UseCompatibleStateImageBehavior = false;
            this.BorrowedListView.View = System.Windows.Forms.View.List;
            // 
            // ReservedListView
            // 
            this.ReservedListView.HideSelection = false;
            this.ReservedListView.Location = new System.Drawing.Point(0, 274);
            this.ReservedListView.Name = "ReservedListView";
            this.ReservedListView.Size = new System.Drawing.Size(513, 75);
            this.ReservedListView.TabIndex = 3;
            this.ReservedListView.UseCompatibleStateImageBehavior = false;
            this.ReservedListView.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 32);
            this.label1.TabIndex = 4;
            this.label1.Text = "Verliehen";
            // 
            // Reserviert
            // 
            this.Reserviert.AutoSize = true;
            this.Reserviert.Location = new System.Drawing.Point(6, 239);
            this.Reserviert.Name = "Reserviert";
            this.Reserviert.Size = new System.Drawing.Size(136, 32);
            this.Reserviert.TabIndex = 5;
            this.Reserviert.Text = "Verliehen";
            // 
            // EventDisplayElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(240F, 240F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.Controls.Add(this.Reserviert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReservedListView);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.BorrowedListView);
            this.Name = "EventDisplayElement";
            this.Size = new System.Drawing.Size(524, 355);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.ListView BorrowedListView;
        private System.Windows.Forms.ListView ReservedListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Reserviert;
    }
}
