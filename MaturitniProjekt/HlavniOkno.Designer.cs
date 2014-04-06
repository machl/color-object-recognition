namespace MaturitniProjekt
{
    partial class HlavniOkno
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
            this.components = new System.ComponentModel.Container();
            this.kameraPictureBox = new System.Windows.Forms.PictureBox();
            this.casovac = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.barvaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.červenouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zelenouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modrouToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.změnaCitlivostiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.platnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vyčistitPlátkoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.štětecToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.změnitBarvuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oknoVyberBarvy = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.kameraPictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // kameraPictureBox
            // 
            this.kameraPictureBox.BackColor = System.Drawing.Color.Black;
            this.kameraPictureBox.Location = new System.Drawing.Point(0, 24);
            this.kameraPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.kameraPictureBox.Name = "kameraPictureBox";
            this.kameraPictureBox.Size = new System.Drawing.Size(576, 432);
            this.kameraPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.kameraPictureBox.TabIndex = 0;
            this.kameraPictureBox.TabStop = false;
            this.kameraPictureBox.DoubleClick += new System.EventHandler(this.kameraPictureBox_DoubleClick);
            // 
            // casovac
            // 
            this.casovac.Interval = 30;
            this.casovac.Tick += new System.EventHandler(this.casovac_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barvaToolStripMenuItem,
            this.platnoToolStripMenuItem,
            this.štětecToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(623, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // barvaToolStripMenuItem
            // 
            this.barvaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.červenouToolStripMenuItem,
            this.zelenouToolStripMenuItem,
            this.modrouToolStripMenuItem,
            this.toolStripSeparator1,
            this.změnaCitlivostiToolStripMenuItem});
            this.barvaToolStripMenuItem.Name = "barvaToolStripMenuItem";
            this.barvaToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.barvaToolStripMenuItem.Text = "Rozpoznávat";
            // 
            // červenouToolStripMenuItem
            // 
            this.červenouToolStripMenuItem.Name = "červenouToolStripMenuItem";
            this.červenouToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.červenouToolStripMenuItem.Text = "Červenou";
            this.červenouToolStripMenuItem.Click += new System.EventHandler(this.červenouToolStripMenuItem_Click);
            // 
            // zelenouToolStripMenuItem
            // 
            this.zelenouToolStripMenuItem.Name = "zelenouToolStripMenuItem";
            this.zelenouToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.zelenouToolStripMenuItem.Text = "Zelenou";
            this.zelenouToolStripMenuItem.Click += new System.EventHandler(this.zelenouToolStripMenuItem_Click);
            // 
            // modrouToolStripMenuItem
            // 
            this.modrouToolStripMenuItem.Name = "modrouToolStripMenuItem";
            this.modrouToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.modrouToolStripMenuItem.Text = "Modrou";
            this.modrouToolStripMenuItem.Click += new System.EventHandler(this.modrouToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // změnaCitlivostiToolStripMenuItem
            // 
            this.změnaCitlivostiToolStripMenuItem.Name = "změnaCitlivostiToolStripMenuItem";
            this.změnaCitlivostiToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.změnaCitlivostiToolStripMenuItem.Text = "Změna citlivosti";
            this.změnaCitlivostiToolStripMenuItem.Click += new System.EventHandler(this.změnaCitlivostiToolStripMenuItem_Click);
            // 
            // platnoToolStripMenuItem
            // 
            this.platnoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vyčistitPlátkoToolStripMenuItem});
            this.platnoToolStripMenuItem.Name = "platnoToolStripMenuItem";
            this.platnoToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.platnoToolStripMenuItem.Text = "Plátno";
            // 
            // vyčistitPlátkoToolStripMenuItem
            // 
            this.vyčistitPlátkoToolStripMenuItem.Name = "vyčistitPlátkoToolStripMenuItem";
            this.vyčistitPlátkoToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.vyčistitPlátkoToolStripMenuItem.Text = "Vyčistit plátno";
            this.vyčistitPlátkoToolStripMenuItem.Click += new System.EventHandler(this.vyčistitPlátkoToolStripMenuItem_Click);
            // 
            // štětecToolStripMenuItem
            // 
            this.štětecToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.změnitBarvuToolStripMenuItem});
            this.štětecToolStripMenuItem.Name = "štětecToolStripMenuItem";
            this.štětecToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.štětecToolStripMenuItem.Text = "Štětec";
            // 
            // změnitBarvuToolStripMenuItem
            // 
            this.změnitBarvuToolStripMenuItem.Name = "změnitBarvuToolStripMenuItem";
            this.změnitBarvuToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.změnitBarvuToolStripMenuItem.Text = "Změnit barvu";
            this.změnitBarvuToolStripMenuItem.Click += new System.EventHandler(this.změnitBarvuToolStripMenuItem_Click);
            // 
            // oknoVyberBarvy
            // 
            this.oknoVyberBarvy.Color = System.Drawing.Color.Red;
            this.oknoVyberBarvy.FullOpen = true;
            // 
            // HlavniOkno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(623, 479);
            this.Controls.Add(this.kameraPictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HlavniOkno";
            this.Text = "Rozpoznání objektů v obraze";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HlavniOkno_FormClosed);
            this.DoubleClick += new System.EventHandler(this.HlavniOkno_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.kameraPictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer casovac;
        /// <summary>
        /// Hlavní komponenta pro vykreslení obrazu webkamery
        /// </summary>
        public System.Windows.Forms.PictureBox kameraPictureBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem barvaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem červenouToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zelenouToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modrouToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem platnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vyčistitPlátkoToolStripMenuItem;
        private System.Windows.Forms.ColorDialog oknoVyberBarvy;
        private System.Windows.Forms.ToolStripMenuItem štětecToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem změnitBarvuToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem změnaCitlivostiToolStripMenuItem;
    }
}

