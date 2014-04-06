namespace MaturitniProjekt
{
    partial class VyberOkno
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
            this.seznamComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.zrusitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // seznamComboBox
            // 
            this.seznamComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.seznamComboBox.FormattingEnabled = true;
            this.seznamComboBox.Location = new System.Drawing.Point(16, 29);
            this.seznamComboBox.Name = "seznamComboBox";
            this.seznamComboBox.Size = new System.Drawing.Size(202, 21);
            this.seznamComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vyberte webkameru:";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(33, 56);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(84, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // zrusitButton
            // 
            this.zrusitButton.Location = new System.Drawing.Point(134, 56);
            this.zrusitButton.Name = "zrusitButton";
            this.zrusitButton.Size = new System.Drawing.Size(75, 23);
            this.zrusitButton.TabIndex = 3;
            this.zrusitButton.Text = "Zrušit";
            this.zrusitButton.UseVisualStyleBackColor = true;
            this.zrusitButton.Click += new System.EventHandler(this.zrusitButton_Click);
            // 
            // VyberOkno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(230, 94);
            this.Controls.Add(this.zrusitButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.seznamComboBox);
            this.Name = "VyberOkno";
            this.Text = "Výběr webkamery";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VyberOkno_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox seznamComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button zrusitButton;
    }
}