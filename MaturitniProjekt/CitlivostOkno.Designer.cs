namespace MaturitniProjekt
{
    partial class CitlivostOkno
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownCervena = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownZelena = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownModra = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonZrusit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCervena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZelena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownModra)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lze zadat hodnotu v intervalu 0-255";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "0 = nejmenší citlivost";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "255 = největší citlivost";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Červená barva:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(13, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "   ";
            // 
            // numericUpDownCervena
            // 
            this.numericUpDownCervena.Location = new System.Drawing.Point(121, 64);
            this.numericUpDownCervena.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownCervena.Name = "numericUpDownCervena";
            this.numericUpDownCervena.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownCervena.TabIndex = 5;
            // 
            // numericUpDownZelena
            // 
            this.numericUpDownZelena.Location = new System.Drawing.Point(121, 97);
            this.numericUpDownZelena.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownZelena.Name = "numericUpDownZelena";
            this.numericUpDownZelena.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownZelena.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(13, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "   ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Zelená barva:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // numericUpDownModra
            // 
            this.numericUpDownModra.Location = new System.Drawing.Point(121, 129);
            this.numericUpDownModra.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDownModra.Name = "numericUpDownModra";
            this.numericUpDownModra.Size = new System.Drawing.Size(54, 20);
            this.numericUpDownModra.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(13, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "   ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Modrá barva:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(19, 167);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(89, 23);
            this.buttonOK.TabIndex = 12;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonZrusit
            // 
            this.buttonZrusit.Location = new System.Drawing.Point(121, 167);
            this.buttonZrusit.Name = "buttonZrusit";
            this.buttonZrusit.Size = new System.Drawing.Size(68, 23);
            this.buttonZrusit.TabIndex = 13;
            this.buttonZrusit.Text = "Zrušit";
            this.buttonZrusit.UseVisualStyleBackColor = true;
            this.buttonZrusit.Click += new System.EventHandler(this.buttonZrusit_Click);
            // 
            // CitlivostOkno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 208);
            this.Controls.Add(this.buttonZrusit);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.numericUpDownModra);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numericUpDownZelena);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDownCervena);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CitlivostOkno";
            this.Text = "Citlivost";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCervena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownZelena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownModra)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownCervena;
        private System.Windows.Forms.NumericUpDown numericUpDownZelena;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDownModra;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonZrusit;
    }
}