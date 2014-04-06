using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MCSystem;
using System.Runtime.InteropServices;

namespace MaturitniProjekt
{
    /// <summary>
    /// Hlavní okno aplikace.
    /// Stará se o připojení webkamery, zobrazení webkamery, vykreslení plátna a práci s pamětí.
    /// Připojení webkamery je inicializováno pomocí jednoduché knihovny MCSystem. Tato knihovna mi také
    /// umožňuje efektivně pracovat přímo s pamětí.
    /// </summary>
    public partial class HlavniOkno : Form
    {
        private CameraDevice webcam;
        private Obrazek obrazek;
        private IntPtr scan0 = IntPtr.Zero; // ukazatel na alokované místo v paměti
        private Platno platno;
        private bool fullscreen = false; // Je okno ve fullsreenu?
        private Size defaultVelikost;

        /// <summary>
        /// Vytvoří novou instanci třídy <see cref="HlavniOkno"/>.
        /// Inicializuje všechny komponenty okna, webkameru a časovač.
        /// </summary>
        public HlavniOkno()
        {
            
            InitializeComponent();
            initWebcam();
            // Uložení rozměrů okna včetně okrajů
            this.defaultVelikost = new Size(this.Size.Width, this.Size.Height);
            if (webcam != null)
            {
                obrazek = new Obrazek(webcam.Width, webcam.Height);
                platno = new Platno(obrazek);
                initTimer();
            }
        }

        /// <summary>
        /// Provede inicializaci připojení k webkameře.
        /// </summary>
        private void initWebcam()
        {
            // Zobrazí okno pro výběr webkamery
            VyberOkno oknoVyberu = new VyberOkno();
            webcam = oknoVyberu.getKamera();
            if (webcam is Camera && webcam != null)
            {
                // Kamera musí mít kontrolu nad nějakým PictureBoxem a tam vykreslovat přímo obraz.
                // To já ale nechci (nemohl bych poté vykreslovat cokoliv do PictureBoxu).
                // Vykreslování obrazu z webkamery dělám dále ručně.
                PictureBox temp = new PictureBox();
                (webcam as Camera).VideoPreview.VideoControl = temp;

                webcam.Connect();
                kameraPictureBox.Width = webcam.Width; // Nastavení rozměrů PictureBoxu podle rozlišení webkamery.
                kameraPictureBox.Height = webcam.Height;
                webcam.Start();

                // Alokuje pamět ve velikosti jakou potřebuji (velikost jednoho snímku webkamery)
                scan0 = Marshal.AllocCoTaskMem(webcam.DataLength);
            }
        }

        /// <summary>
        /// Spustí časovač, který volá metodu casovac_Tick(...) každých 30 ms.
        /// </summary>
        private void initTimer()
        {
            casovac.Enabled = true;
        }

        /// <summary>
        /// Zpracovává událost vyvolanou opakovaně časovačem. Defaultně nastaveno na interval 30 ms.
        /// Stará se o získání snímku webkamery, zpracování, vytvoření nové bitmapy založené na snímku webkamery,
        /// vykreslení plátna do bitmapy a předání do PictureBoxu v hlavním okně.
        /// </summary>
        /// <param name="sender">zdroj události</param>
        /// <param name="e">instance třídy <see cref="System.EventArgs"/> obsahující parametry události</param>
        private void casovac_Tick(object sender, EventArgs e)
        {
            casovac.Enabled = false; // Zastaví časovač

            // Vrátí byte pole obsahující hodnoty RGB barevné složky všech pixelů následujícího snímku webkamery.
            byte[] data = webcam.SnapshotByte();
            if (data == null)
                return;

            try
            {
                // Předám snímek ke zpracování
                obrazek.updateImage(data);

                // Na alokovaný ukazatel na místo v paměti nakopíruju nový snímek
                Marshal.Copy(data, 0, scan0, webcam.DataLength);
                if (scan0 == IntPtr.Zero) return;

                // Z dat v paměti vytvořím novou bitmapu o stejném rozlišení a formátu jako webkamera
                Bitmap novy = new Bitmap(webcam.Width, webcam.Height, webcam.Stride, System.Drawing.Imaging.PixelFormat.Format24bppRgb, scan0);
                novy.RotateFlip(RotateFlipType.RotateNoneFlipXY); // Zrcadlení snímku dle osy X a Y

                Graphics g = Graphics.FromImage(novy);
                // Vykreslení plátna do bitmapy (vykreslení kreslených bodů i ovládacích prvků bočního panelu)
                platno.vykresli(g);
                g.Flush();

                /*if (snimat)
                {
                    novy.Save(DateTime.Now.Millisecond + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                    snimat = false;
                }*/

                // Zobrazení snímku v okně pro uživatele
                kameraPictureBox.Image = novy;
            }
            catch (Exception ex)
            {
                // V případě chyby bezpečné odpojení webkamery a uzavření okna
                HlavniOkno_FormClosed(null, null);
                throw ex;
            }

            casovac.Enabled = true; // Znovu obnoví časovač
        }

        /// <summary>
        /// Zajištuje přepnutí do režimu celé obrazovky a zpět.
        /// </summary>
        private void fullscreenPrepni()
        {
            if (fullscreen) // pokud je režim celé obrazovky aktivován, přepne se zpět do okna
            {
                this.Bounds = Screen.PrimaryScreen.Bounds;
                kameraPictureBox.Location = new Point(0, 24);
                kameraPictureBox.Size = new Size(webcam.Width, webcam.Height);
                this.menuStrip1.Show();
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.WindowState = FormWindowState.Normal;
                this.Size = new Size(defaultVelikost.Width, defaultVelikost.Height);
                this.TopMost = false;

                fullscreen = false;
            }
            else // přepnutí do režimu celé obrazovky
            {
                Bounds = Screen.PrimaryScreen.Bounds;
                this.menuStrip1.Hide(); // skryje panel nabídek
                this.FormBorderStyle = FormBorderStyle.None; // odstraní okrajovou grafiku okna
                this.WindowState = FormWindowState.Maximized; // maximalizuje okno
                this.TopMost = true; // okno bude vždy zobrazeno nejvýše (před všemi okny)

                if (this.Size.Width > this.Size.Height) // otočení obrazovky je landscape (na šířku)
                {
                    double pomer = (double)this.Size.Height / (double)webcam.Height;
                    int novaSirka = Convert.ToInt32(webcam.Width * pomer);
                    kameraPictureBox.Size = new Size(novaSirka, this.Size.Height); // rozšíření na velikost celé obrazovky (zachován poměr obrazu)
                    kameraPictureBox.Location = new Point(this.Size.Width / 2 - novaSirka / 2, 0); // umístění roztáhnutého pictureboxu na střed
                }
                else // obrazovka je portrait (na výšku)
                {
                    double pomer = (double)this.Size.Width / (double)webcam.Width;
                    int novaVyska = Convert.ToInt32(webcam.Height * pomer);
                    kameraPictureBox.Size = new Size(this.Size.Width, novaVyska);
                    kameraPictureBox.Location = new Point(0, this.Size.Height / 2 - novaVyska / 2);
                }

                fullscreen = true;
            }
        }


        /// <summary>
        /// Handles the Click event of the červenouToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void červenouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BarevneRozpoznavany.rozpoznavejCervenou();
        }

        /// <summary>
        /// Handles the Click event of the zelenouToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void zelenouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BarevneRozpoznavany.rozpoznavejZelenou();
        }

        /// <summary>
        /// Handles the Click event of the modrouToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void modrouToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BarevneRozpoznavany.rozpoznavejModrou();
        }

        /// <summary>
        /// Handles the Click event of the vyčistitPlátkoToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void vyčistitPlátkoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            platno.vycisti();
        }

        /// <summary>
        /// Handles the Click event of the změnitBarvuToolStripMenuItem control.
        /// Zobrazí okno pro výběr barvy a vybranou barvu nastaví štětci.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void změnitBarvuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oknoVyberBarvy.Color = platno.getBarvaStetce(); // Nastavím dialogu aktuální barvu
            DialogResult v = oknoVyberBarvy.ShowDialog(); // 
            if (v == DialogResult.OK)
            {
                platno.setBarvaStetce(oknoVyberBarvy.Color);
            }
            // http://www.c-sharpcorner.com/UploadFile/mahesh/ColrDialogHowtouse12012005001424AM/ColrDialogHowtouse.aspx
        }

        /// <summary>
        /// Handles the DoubleClick event of the kameraPictureBox control.
        /// Obstarává dvojklik na obraz (PictureBox) a přepnutí na fullscreen a zpět.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void kameraPictureBox_DoubleClick(object sender, EventArgs e)
        {
            fullscreenPrepni();
        }

        /// <summary>
        /// Handles the DoubleClick event of the HlavniOkno control.
        /// Obstarává dvojklik na černou plochu okolo (PictureBox) a přepnutí zpět z fullscreenu.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void HlavniOkno_DoubleClick(object sender, EventArgs e)
        {
            fullscreenPrepni();
        }

        /// <summary>
        /// Handles the FormClosed event of the HlavniOkno control.
        /// Obstará bezpečné odpojení od webkamery, uvolnění alokované paměti, zastaví časovač a zavře okno.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosedEventArgs"/> instance containing the event data.</param>
        private void HlavniOkno_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (webcam != null)
             webcam.Stop();
            if (scan0 != IntPtr.Zero)
            {
                Marshal.FreeCoTaskMem(scan0);
            } 
            scan0 = IntPtr.Zero;
            if (webcam != null)
             webcam.Disconnect();
            casovac.Enabled = false;
        }

        /// <summary>
        /// Handles the Click event of the změnaCitlivostiToolStripMenuItem control.
        /// Zobrazí okno s nastavením citlivosti barev.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void změnaCitlivostiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new CitlivostOkno().ShowDialog(this);
        }
    }
}
