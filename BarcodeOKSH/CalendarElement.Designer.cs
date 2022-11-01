namespace BarcodeOKSH
{
    partial class CalendarElement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarElement));
            this.ElementPanel = new System.Windows.Forms.TableLayoutPanel();
            this.BackButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.CalendarInfoLabel = new System.Windows.Forms.Label();
            this.ElementWrapper = new System.Windows.Forms.GroupBox();
            this.ElementWrapper.SuspendLayout();
            this.SuspendLayout();
            // 
            // ElementPanel
            // 
            resources.ApplyResources(this.ElementPanel, "ElementPanel");
            this.ElementPanel.Name = "ElementPanel";
            // 
            // BackButton
            // 
            resources.ApplyResources(this.BackButton, "BackButton");
            this.BackButton.Name = "BackButton";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // NextButton
            // 
            resources.ApplyResources(this.NextButton, "NextButton");
            this.NextButton.Name = "NextButton";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // CalendarInfoLabel
            // 
            resources.ApplyResources(this.CalendarInfoLabel, "CalendarInfoLabel");
            this.CalendarInfoLabel.Name = "CalendarInfoLabel";
            // 
            // ElementWrapper
            // 
            resources.ApplyResources(this.ElementWrapper, "ElementWrapper");
            this.ElementWrapper.Controls.Add(this.ElementPanel);
            this.ElementWrapper.Name = "ElementWrapper";
            this.ElementWrapper.TabStop = false;
            // 
            // CalendarElement
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ElementWrapper);
            this.Controls.Add(this.CalendarInfoLabel);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.BackButton);
            this.Name = "CalendarElement";
            this.ElementWrapper.ResumeLayout(false);
            this.ElementWrapper.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ElementPanel;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Label CalendarInfoLabel;
        private System.Windows.Forms.GroupBox ElementWrapper;
    }
}
