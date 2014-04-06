using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MaturitniProjekt
{
    /// <summary>
    /// Reprezentuje kreslící plátno jako obrazovou vrstvu umístěnou nad snímek z webkamery.
    /// Stará se:
    ///     o vykreslení jednotlivých bodů, které zanechává za sebou sledovaný objekt
    ///     o vykreslení ovládacího panelu na pravém okraji
    ///     o vymazání plátna od všech nakreslených bodů
    /// Uchovává také informaci o aktuální barvě štetce a šířce štětce.
    /// </summary>
    class Platno
    {
        private int sirka, vyska; // Rozměry plátna (shodné se snímkem webkamery).
        private int xPanelu, y1Panelu, y2Panelu, y3Panelu;
        private Obrazek obrazek;
        private readonly Pen cervenaCara = new Pen(Color.Red, 3.0f); // Deklarace základního červeného pera pro čáry ovládacího panelu
        private readonly Pen bilaTenka = new Pen(Color.White, 2.0f); // Deklarace základního bílého pera pro obtažení bodu
        private readonly Bod[] bodyPanel;
        private int sirkaStetce = 60;
        private Color barvaStetce = Color.Red;
        private readonly static Image cross = Properties.Resources.cross;
        private static Point crossPozice;

        private IList<Bod> body = new List<Bod>(); // Dynamické pole se všemi nakreslenými body

        /// <summary>
        /// Vytvoří novou instanci třídy <see cref="Platno"/>.
        /// </summary>
        /// <param name="obrazek">Výchozí obrázek, kterému má být plátno přiděleno.</param>
        public Platno(Obrazek obrazek)
        {
            this.sirka = obrazek.sirka;
            this.vyska = obrazek.vyska;
            this.obrazek = obrazek;

            // Pozicování prvků na ovládacím panelu na pravém okraji
            this.xPanelu = sirka - sirka / 6;
            this.y1Panelu = vyska / 4;
            this.y2Panelu = y1Panelu * 2;
            this.y3Panelu = y1Panelu * 3;
            int xBoduPanelu = (sirka-xPanelu)/2 + xPanelu;
            int yPosunBoduPanelu = y1Panelu / 2;
            crossPozice = new Point(xBoduPanelu - 40, y3Panelu + yPosunBoduPanelu - 40);
            // Vytvoření instancí bodů, které budou vykreslovány jako ovládací prvky
            this.bodyPanel = new Bod[] {
                new Bod(xBoduPanelu, yPosunBoduPanelu, sirkaStetce, Color.Red),
                new Bod(xBoduPanelu, y1Panelu+yPosunBoduPanelu, sirkaStetce, Color.Green),
                new Bod(xBoduPanelu, y2Panelu+yPosunBoduPanelu, sirkaStetce, Color.Blue)
            };
        }

        /// <summary>
        /// Zařadí všechny prvky a body plátna do vykreslování.
        /// </summary>
        /// <param name="g">grafika bitmapy</param>
        public void vykresli(Graphics g)
        {
            foreach (Bod b in body) // Zařadí do vykreslování všechny nakreslené body
            {
                b.vykresli(g);
            }

            vykresliPanel(g); // Vykreslí prvky panelu

            Objekt o = obrazek.getObjekt();
            if (o != null) // Pokud právě snímám objekt
            {
                // Vypočítání nové šířky štetce z velikosti snímaného objektu
                sirkaStetce = o.getSirka() > o.getVyska() ? o.getVyska() : o.getSirka();

                if (o.getStredX()+sirkaStetce/2 < xPanelu) // Pokud je pozice objektu mimo boční panel
                {
                    // Vytvoření nového bodu
                    Bod b = new Bod(o.getStredX(), o.getStredY(), sirkaStetce, barvaStetce);
                    b.vykresli(g); // Zarazení do vykreslení na aktuální plátno
                    body.Add(b); // Přidání do pole bodů pro vykreslování při dalších snímcích
                }
                else // Ovládání bočního panelu
                {
                    if (o.getStredY() < y1Panelu)
                    {
                        // Horní políčko
                        setBarvaStetce(Color.Red);
                    }
                    else if (o.getStredY() < y2Panelu)
                    {
                        // Druhé políčko
                        setBarvaStetce(Color.Green);
                    }
                    else if (o.getStredY() < y3Panelu)
                    {
                        // Třetí políčko
                        setBarvaStetce(Color.Blue);
                    }
                    else
                    {
                        // Spodní políčko
                        vycisti();
                    }
                }

                // Zařadí bílé čáry okolo aktuální pozice snímaného objektu
                g.DrawEllipse(bilaTenka, o.getStredX() - sirkaStetce / 2 - 2, o.getStredY() - sirkaStetce / 2 - 2, sirkaStetce + 4, sirkaStetce + 4);
                
            }

            
        }

        /// <summary>
        /// Vymaže všechny nakreslené body z plátna
        /// </summary>
        public void vycisti()
        {
            body.Clear();
        }

        /// <summary>
        /// Nastavení nové barvy štetce.
        /// </summary>
        /// <param name="novaBarva">nová barva</param>
        public void setBarvaStetce(Color novaBarva)
        {
            barvaStetce = novaBarva;
        }
        /// <summary>
        /// Získání aktuální barvy štetce.
        /// </summary>
        /// <returns>aktuální barva štetce</returns>
        public Color getBarvaStetce()
        {
            return barvaStetce;
        }

        /// <summary>
        /// Zařadí do vykreslování pravý boční panel pro ovládání.
        /// </summary>
        /// <param name="g">grafika bitmapy</param>
        private void vykresliPanel(Graphics g)
        {
            // Zařadí do vykreslování čáry okolo ovládacích prvků na panelu
            /*g.DrawLine(cervenaCara, xPanelu, 0, xPanelu, vyska);
            g.DrawLine(cervenaCara, xPanelu, y1Panelu, sirka, y1Panelu);
            g.DrawLine(cervenaCara, xPanelu, y2Panelu, sirka, y2Panelu);
            g.DrawLine(cervenaCara, xPanelu, y3Panelu, sirka, y3Panelu);*/

            // Zařadí body do panelu (červený, zelený a modrý)
            foreach (Bod b in bodyPanel)
            {
                b.vykresli(g);
            }

            // Zvýrazní tu volbu barvy, která je aktuálně aktivní
            if (barvaStetce == Color.Red)
                bodyPanel[0].zvyrazni(bilaTenka, g);
            else if (barvaStetce == Color.Green)
                bodyPanel[1].zvyrazni(bilaTenka, g);
            else if (barvaStetce == Color.Blue)
                bodyPanel[2].zvyrazni(bilaTenka, g);

            g.DrawImage(cross, crossPozice);
        }
    }

    /// <summary>
    /// Reprezentuje jednotlivý nakreslený bod na plátně.
    /// </summary>
    class Bod
    {
        int x, y, sirka;
        Brush b;

        /// <summary>
        /// Vytvoří novou instanci třídy <see cref="Bod"/> na dané pozici, o dané šířce a s danou barvou.
        /// </summary>
        /// <param name="x">x pozice (středu)</param>
        /// <param name="y">y pozice (středu)</param>
        /// <param name="sirka">šířka bodu (použije se i jako výška)</param>
        /// <param name="barva">barva bodu</param>
        public Bod(int x, int y, int sirka, Color barva)
        {
            this.x = x;
            this.y = y;
            this.sirka = sirka;
            b = new SolidBrush(barva);
        }

        /// <summary>
        /// Zařazení bodu do vykreslování.
        /// </summary>
        /// <param name="g">grafika bitmapy</param>
        public void vykresli(Graphics g)
        {
            g.FillEllipse(b, x-sirka/2, y-sirka/2, sirka, sirka);
        }

        /// <summary>
        /// Zvýrazní jednotlivý bod pomocí bílé tenké čáry okolo.
        /// Používá se pro zvýraznění volby barvy v bočním ovládacím panelu, která je právě aktivní.
        /// </summary>
        /// <param name="jak">pero pro vykreslení</param>
        /// <param name="g">grafika bitmapy</param>
        public void zvyrazni(Pen jak, Graphics g)
        {
            g.DrawEllipse(jak, x - sirka / 2 - 2, y - sirka / 2 - 2, sirka + 4, sirka + 4);
        }
    }
}
