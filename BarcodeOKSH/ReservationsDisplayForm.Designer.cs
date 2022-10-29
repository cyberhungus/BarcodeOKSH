namespace BarcodeOKSH
{
    partial class ReservationsDisplayForm
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
            this.ReservationDisplayListview = new System.Windows.Forms.ListView();
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReservationInfoLabel = new System.Windows.Forms.Label();
            this.AcknowlegdeButton = new System.Windows.Forms.Button();
            this.OverwriteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ReservationDisplayListview
            // 
            this.ReservationDisplayListview.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader22});
            this.ReservationDisplayListview.HideSelection = false;
            this.ReservationDisplayListview.Location = new System.Drawing.Point(19, 74);
            this.ReservationDisplayListview.Name = "ReservationDisplayListview";
            this.ReservationDisplayListview.Size = new System.Drawing.Size(1454, 681);
            this.ReservationDisplayListview.TabIndex = 7;
            this.ReservationDisplayListview.UseCompatibleStateImageBehavior = false;
            this.ReservationDisplayListview.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Startdatum";
            this.columnHeader18.Width = 324;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Enddatum";
            this.columnHeader19.Width = 364;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Person";
            this.columnHeader20.Width = 542;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "Objekte";
            this.columnHeader21.Width = 326;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Signatur";
            this.columnHeader22.Width = 400;
            // 
            // ReservationInfoLabel
            // 
            this.ReservationInfoLabel.AutoSize = true;
            this.ReservationInfoLabel.Location = new System.Drawing.Point(13, 13);
            this.ReservationInfoLabel.Name = "ReservationInfoLabel";
            this.ReservationInfoLabel.Size = new System.Drawing.Size(92, 32);
            this.ReservationInfoLabel.TabIndex = 8;
            this.ReservationInfoLabel.Text = "label1";
            // 
            // AcknowlegdeButton
            // 
            this.AcknowlegdeButton.Location = new System.Drawing.Point(1142, 784);
            this.AcknowlegdeButton.Name = "AcknowlegdeButton";
            this.AcknowlegdeButton.Size = new System.Drawing.Size(327, 126);
            this.AcknowlegdeButton.TabIndex = 9;
            this.AcknowlegdeButton.Text = "Okay";
            this.AcknowlegdeButton.UseVisualStyleBackColor = true;
            this.AcknowlegdeButton.Click += new System.EventHandler(this.Acknowledge_Click);
            // 
            // OverwriteButton
            // 
            this.OverwriteButton.Location = new System.Drawing.Point(19, 784);
            this.OverwriteButton.Name = "OverwriteButton";
            this.OverwriteButton.Size = new System.Drawing.Size(327, 126);
            this.OverwriteButton.TabIndex = 10;
            this.OverwriteButton.Text = "Overwrite";
            this.OverwriteButton.UseVisualStyleBackColor = true;
            this.OverwriteButton.Click += new System.EventHandler(this.OverwriteButton_Click);
            // 
            // ReservationsDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1481, 940);
            this.Controls.Add(this.OverwriteButton);
            this.Controls.Add(this.AcknowlegdeButton);
            this.Controls.Add(this.ReservationInfoLabel);
            this.Controls.Add(this.ReservationDisplayListview);
            this.Name = "ReservationsDisplayForm";
            this.Text = "ReservationsDisplayForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ReservationDisplayListview;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.Label ReservationInfoLabel;
        private System.Windows.Forms.Button AcknowlegdeButton;
        private System.Windows.Forms.Button OverwriteButton;
    }
}