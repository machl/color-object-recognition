using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MCSystem;

namespace MaturitniProjekt
{
    /// <summary>
    /// Okno pro výběr webkamery.
    /// Pokud je v systému rozpoznána pouze jedna webkamera, je vybrána a okno ihned uzavřeno.
    /// </summary>
    public partial class VyberOkno : Form
    {
        CameraDevice vybranaKamera = null;
        CameraDevices kamery = new CameraDevices(true);

        /// <summary>
        /// Vytvoří novou instanci třídy <see cref="VyberOkno"/>.
        /// Zobrazí se okno s možností pro výběr webkamery.
        /// </summary>
        public VyberOkno()
        {
            InitializeComponent();

            if (kamery.Count == 1) // Pokud je pouze jedna, vybere se a okno se zavře
            {
                vybranaKamera = new Camera(kamery[0].Name);
                Close();
            }
            else if (kamery.Count == 0) // V případě nenalezené webkamery zahlaš chybu a ukonči aplikaci
            {
                System.Windows.Forms.MessageBox.Show("Nebyla nalezena žádná webkamera. Aplikace pro svůj chod vyžaduje připojenou webkameru. Připojte prosím do počítače webkameru a aplikaci znovu spusťte.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            else
            {
                seznamComboBox.Items.Clear();
                for (int i = 0; i < kamery.Count; ++i) // Přidá do ComboBoxu všechny rozpoznané webkamery
                {
                    seznamComboBox.Items.Add(kamery[i].Name);
                }
                seznamComboBox.SelectedIndex = 0;
                ShowDialog(); // Zviditelní okno
            }
        }

        /// <summary>
        /// Handles the Click event of the okButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void okButton_Click(object sender, EventArgs e)
        {
            vybranaKamera = new Camera(seznamComboBox.Text);
            this.Close();
        }

        /// <summary>
        /// Vrátí vybranou webkameru.
        /// </summary>
        /// <returns>vybraná webkamera</returns>
        public CameraDevice getKamera()
        {
            return vybranaKamera;
        }


        /// <summary>
        /// Handles the Click event of the zrusitButton control.
        /// Ukončí celou aplikaci.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void zrusitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the FormClosed event of the VyberOkno control.
        /// V případě zavření okna bezpečně ukončím celou aplikaci.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosedEventArgs"/> instance containing the event data.</param>
        private void VyberOkno_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        
    }
}
