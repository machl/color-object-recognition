using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MaturitniProjekt
{
    /// <summary>
    /// Třída reprezentující okno pro změnu citlivosti pro rozpoznávání jednotlivých barev.
    /// </summary>
    public partial class CitlivostOkno : Form
    {
        /// <summary>
        /// Vytvoří novou instanci třídy <see cref="CitlivostOkno"/>.
        /// Spinnerům nastaví aktuálně používanou citlivost.
        /// </summary>
        public CitlivostOkno()
        {
            InitializeComponent();
            numericUpDownCervena.Value = BarevneRozpoznavany.citlivostCervena;
            numericUpDownZelena.Value = BarevneRozpoznavany.citlivostZelena;
            numericUpDownModra.Value = BarevneRozpoznavany.citlivostModra;
        }

        /// <summary>
        /// Kliknutí na tlačítko Zrušit.
        /// Nově nastanené parametry zapomene a okno zavře.
        /// </summary>
        /// <param name="sender">Zdroj události.</param>
        /// <param name="e">Instance třídy <see cref="System.EventArgs"/> obsahující parametry události.</param>
        private void buttonZrusit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Kliknutí na tlačítko OK.
        /// Hodnoty citlivostí uloží a okno zavře.
        /// </summary>
        /// <param name="sender">Zdroj události.</param>
        /// <param name="e">Instance třídy <see cref="System.EventArgs"/> obsahující parametry události.</param>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            BarevneRozpoznavany.setCitlivosti(
                System.Convert.ToByte(numericUpDownCervena.Value),
                System.Convert.ToByte(numericUpDownZelena.Value),
                System.Convert.ToByte(numericUpDownModra.Value)
                );
            Close();
        }
    }
}
