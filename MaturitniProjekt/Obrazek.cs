using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MaturitniProjekt
{
    /// <summary>
    /// Reprezentuje datovou strukturu získaného obrázku jako objekt.
    /// Třída je určena k použití jako jedináček, protože některé vlastnosti obrázku se nemění (šířka, výška).
    /// Obnovy obrázku jsou realizovány pomocí metody updateImage().
    /// </summary>
    class Obrazek
    {
        public int sirka, vyska;
        private byte[] data;
        private Objekt snimanyObjekt;

        /// <summary>
        /// Vytvoří novou instanci třídy <see cref="Obrazek"/>.
        /// V parametrech je požadováno rozlišení obrázku.
        /// </summary>
        /// <param name="sirka">Šířka obrázku v pixelech.</param>
        /// <param name="vyska">Výška obrázku v pixelech.</param>
        public Obrazek(int sirka, int vyska)
        {
            this.sirka = sirka;
            this.vyska = vyska;
        }

        /// <summary>
        /// Předá nový obrázek ze zpracování.
        /// Upraví pouze hodnotu barev jednotlivých pixelů. Společné vlastnoti všech obrázků (snímků webkamery) zůstanou.
        /// </summary>
        /// <param name="data">Data ve vstupním formátu pole byte.</param>
        public void updateImage(byte[] data)
        {
            this.data = data;
            updateSnimanehoObjektu();
        }

        /// <summary>
        /// Aplykuje algoritmus pro nalezení objektu v obraze.
        /// Je prováděn automaticky při každé obnově obrázku.
        /// </summary>
        private void updateSnimanehoObjektu()
        {
            // Nastavení hledané oblasti na celý obrázek.
            int x1 = 0;
            int y1 = 0;
            int x2 = sirka;
            int y2 = vyska;

            // Pokud už je již nějaký objekt sledován, upravím hledanou oblast
            // pouze na okolí předcházející pozice nalezeného objektu.
            // Hledaná oblast je z každé strany rozšířena o rozměry objektu.
            if (snimanyObjekt != null)
            {
                x1 = snimanyObjekt.getX1() - snimanyObjekt.getSirka();
                x1 = x1 > 0 ? x1 : 0;
                y1 = snimanyObjekt.getY1() - snimanyObjekt.getVyska();
                y1 = y1 > 0 ? y1 : 0;
                x2 = snimanyObjekt.getX2() + snimanyObjekt.getSirka();
                x2 = x2 < sirka ? x2 : sirka;
                y2 = snimanyObjekt.getY2() + snimanyObjekt.getVyska();
                y2 = y2 < vyska ? y2 : vyska;
            }

            bool nalezen = false;
            int s = 0, j = 0, v = 0, z = 0; // Souřadnice nejsevernějšího, -jižnějšího, -východnějšího a -západnějšího pixelu objektu.

            for (int y = y1; y < y2; y++)
            {
                for (int x = x1; x < x2; x++) // Procházení celé oblasti a hledání objektu v ní.
                {
                    byte r = getR(x, y);
                    byte g = getG(x, y);
                    byte b = getB(x, y); // Zjištění hodnot RGB jednotlivého pixelu.
                    byte c = BarevneRozpoznavany.hodnotaKanalu(r, g, b); // Zjištění hodnoty barevného kanálu pixelu
                    if (BarevneRozpoznavany.jeDostatecneBarevny(c)) // Je objekt dostatečně barevný (např. červený)?
                    {
                        // Provedení zjištění, zda pixel je nej-severnější/jižnější/východnější/západnější
                        if (!nalezen)
                        {
                            s = y;
                            j = y;
                            v = x;
                            z = x;
                            nalezen = true;
                        }
                        if (x < z) z = x;
                        if (x > v) v = x;
                        if (y < s) s = y;
                        if (y > j) j = y;
                    }
                }
            }

            if (nalezen) // V případě rozpoznání objektu...
            {
                if (snimanyObjekt == null) // ... vytvořím nový, pokud jsem dosud žádný objekt nerozpoznal.
                {
                    snimanyObjekt = new BarevneRozpoznavany(z, s, v, j);
                    Console.WriteLine("Nalezen objekt!");
                }
                else // ... provedu změnu pozice snímaného objektu na nově rozpoznanou.
                {
                    snimanyObjekt.posun(z, s, v, j);
                }
            }
            else
            {
                if (snimanyObjekt != null) // Objekt již v tomto snímku není, odstraním jeho sledování
                {
                    snimanyObjekt = null;
                    Console.WriteLine("- Objekt ztracen!");
                }
            }
        }

        /// <summary>
        /// Získání snímaného objekt.
        /// </summary>
        /// <returns></returns>
        public Objekt getObjekt()
        {
            return snimanyObjekt;
        }


        /// <summary>
        /// Získá hodnotu červené barvy pixelu na zadané pozici.
        /// </summary>
        /// <param name="x">x souřadnice pixelu.</param>
        /// <param name="y">y souřadnice pixelu.</param>
        /// <returns></returns>
        protected byte getR(int x, int y)
        {
            return data[data.Length - 1 - (sirka * 3 * y) - (x * 3)];
        }
        /// <summary>
        /// Získá hodnotu zelené barvy pixelu na zadané pozici.
        /// </summary>
        /// <param name="x">x souřadnice pixelu.</param>
        /// <param name="y">y souřadnice pixelu.</param>
        /// <returns></returns>
        protected byte getG(int x, int y)
        {
            return data[data.Length - 1 - (sirka * 3 * y) - (x * 3) - 1];
        }
        /// <summary>
        /// Získá hodnotu modré barvy pixelu na zadané pozici.
        /// </summary>
        /// <param name="x">x souřadnice pixelu.</param>
        /// <param name="y">y souřadnice pixelu.</param>
        /// <returns></returns>
        protected byte getB(int x, int y)
        {
            return data[data.Length - 1 - (sirka * 3 * y) - (x * 3) - 2];
        } 
    }
}
