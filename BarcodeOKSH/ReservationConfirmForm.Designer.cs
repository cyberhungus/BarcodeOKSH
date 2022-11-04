namespace BarcodeOKSH
{
    partial class ReservationConfirmForm
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
            this.ResDisplayElement = new BarcodeOKSH.ReservationDisplayElement();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ResDisplayElement
            // 
            this.ResDisplayElement.AutoSize = true;
            this.ResDisplayElement.Location = new System.Drawing.Point(8, -1);
            this.ResDisplayElement.Name = "ResDisplayElement";
            this.ResDisplayElement.Size = new System.Drawing.Size(780, 879);
            this.ResDisplayElement.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 963);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(780, 71);
            this.button1.TabIndex = 1;
            this.button1.Text = "Bestätigen";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReservationConfirmForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 1037);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ResDisplayElement);
            this.Name = "ReservationConfirmForm";
            this.Text = "ReservationConfirmForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReservationDisplayElement ResDisplayElement;
        private System.Windows.Forms.Button button1;
    }
}