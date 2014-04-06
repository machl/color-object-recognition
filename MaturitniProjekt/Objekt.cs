using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MaturitniProjekt
{
    /// <summary>
    /// Abstraktní třída pro snímaný objekt.
    /// Definuje základní vlastnoti pro zjištění pozice objektu, jeho šířky a výšky.
    /// Souřadnice reprezentují rám (obdelník), který obklopuje sledovaný objekt.
    /// </summary>
    abstract class Objekt
    {
        protected int x1, y1, x2, y2;

        /// <summary>
        /// Vrací x pozici levého horního rohu objektu.
        /// </summary>
        /// <returns>x pozice levého horního rohu</returns>
        public int getX1()
        {
            return x1;
        }

        /// <summary>
        /// Vrací y pozici levého horního rohu objektu.
        /// </summary>
        /// <returns>y pozice levého horního rohu</returns>
        public int getY1()
        {
            return y1;
        }

        /// <summary>
        /// Vrací x pozici pravého dolního rohu objektu.
        /// </summary>
        /// <returns>x pozice pravého dolního rohu</returns>
        public int getX2()
        {
            return x2;
        }

        /// <summary>
        /// Vrací y pozici pravého dolního rohu objektu.
        /// </summary>
        /// <returns>y pozice pravého dolního rohu</returns>
        public int getY2()
        {
            return y2;
        }

        /// <summary>
        /// Vrací šířku objektu.
        /// </summary>
        /// <returns>šířka objektu</returns>
        public int getSirka() 
        {
            return getX2()-getX1();
        }

        /// <summary>
        /// Vrací výšku objektu.
        /// </summary>
        /// <returns>výška objektu</returns>
        public int getVyska() 
        {
            return getY2()-getY1();
        }

        /// <summary>
        /// Změní pozici objektu na novou.
        /// </summary>
        /// <param name="x1">x pozice levého horního rohu objektu (západ)</param>
        /// <param name="y1">y pozice levého horního rohu objektu (sever)</param>
        /// <param name="x2">x pozice pravého dolního roku objektu (východ)</param>
        /// <param name="y2">y pozice pravého dolního rohu objektu (jih)</param>
        public void posun(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        /// <summary>
        /// Vrací x souřadnici středu objektu.
        /// </summary>
        /// <returns>x souřadnice středu objektu</returns>
        public int getStredX()
        {
            return getSirka() / 2 + getX1();
        }

        /// <summary>
        /// Vrací y souřadnici středu objektu.
        /// </summary>
        /// <returns>y souřadnice středu objektu</returns>
        public int getStredY()
        {
            return getVyska() / 2 + getY1();
        }
    }

    /// <summary>
    /// Reprezentuje sledovaný objekt v obraze na principu nalezení objektu pomocí barevného kanálu.
    /// Pomocí metod rozpoznavejCervenou(), rozpoznavejZelenou() a rozpoznavejModrou() lze přepínat,
    /// pomocí kterého barevného kanálu má být objekt rozpoznán.
    /// </summary>
    class BarevneRozpoznavany : Objekt
    {
        private static byte rozpoznavat = 0; // Určuje, která z barev má být rozpoznána (0-červená, 1-zelená, 2-modrá).

        /// <summary>
        /// Určuje citlivost, kdy je hodnota kanálu prohlášena za barevnou (prohlášena za součást sledovaného objektu).
        /// </summary>
        public static byte citlivostCervena = 120;
        public static byte citlivostZelena = 100;
        public static byte citlivostModra = 140;
        public static byte aktualniCitlivost = citlivostCervena;

        /// <summary>
        /// Vytvoří novou instanci třídy <see cref="BarevneRozpoznavany"/>.
        /// V parametrech je předávána pozice nalezeného objektu.
        /// </summary>
        /// <param name="x1">x pozice levého horního rohu objektu (západ)</param>
        /// <param name="y1">y pozice levého horního rohu objektu (sever)</param>
        /// <param name="x2">x pozice pravého dolního roku objektu (východ)</param>
        /// <param name="y2">y pozice pravého dolního rohu objektu (jih)</param>
        public BarevneRozpoznavany(int x1, int y1, int x2, int y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }

        /// <summary>
        /// Provede zjištění barevného kanálu z hodnot RGB.
        /// Vrací hodnotu kanálu (0-255), kde větší hodnota znamená větší barevnost. Může také vyjadřovat pravděpodobnost výskytu hledané barvy.
        /// Např. 255 = pixel určitě obsahuje hledanou barvu, 0 = pixel určitě není hledané barvy
        /// </summary>
        /// <param name="r">hodnota červené barvy</param>
        /// <param name="g">hodnota zelené barvy</param>
        /// <param name="b">hodnota modré barvy</param>
        /// <returns>hodnota kanálu</returns>
        public static byte hodnotaKanalu(byte r, byte g, byte b)
        {
            int f = 0;
            if (rozpoznavat == 0)
                f = r * r - g * g - b * b;
            else if (rozpoznavat == 1)
                f = g*g - r*r - b*b;
            else if (rozpoznavat == 2)
                f = b*b - g*g - r*r;
            byte c = f > 0 ? (byte)Math.Sqrt(f) : (byte)0;
            return c;
        }

        /// <summary>
        /// Prohlásí, zda pixel je dostatečně barevný a je tedy součástí hledaného objektu.
        /// </summary>
        /// <param name="hodnotaKanalu">The hodnota kanalu.</param>
        /// <returns></returns>
        public static bool jeDostatecneBarevny(byte hodnotaKanalu)
        {
            return (hodnotaKanalu > aktualniCitlivost);
        }

        /// <summary>
        /// Přepne barevné rozpoznávání na červenou.
        /// </summary>
        public static void rozpoznavejCervenou()
        {
            rozpoznavat = 0;
            aktualniCitlivost = citlivostCervena;
        }

        /// <summary>
        /// Přepne barevné rozpoznávání na zelenou.
        /// </summary>
        public static void rozpoznavejZelenou()
        {
            rozpoznavat = 1;
            aktualniCitlivost = citlivostModra;
        }

        /// <summary>
        /// Přepne barevné rozpoznávání na modrou.
        /// </summary>
        public static void rozpoznavejModrou()
        {
            rozpoznavat = 2;
            aktualniCitlivost = citlivostZelena;
        }

        /// <summary>
        /// Upraví cislivosti barev na nové hodnoty.
        /// </summary>
        /// <param name="cervena">citlivost červené</param>
        /// <param name="zelena">citlivost zelené</param>
        /// <param name="modra">citlivost modré</param>
        public static void setCitlivosti(byte cervena, byte zelena, byte modra)
        {
            citlivostCervena = cervena;
            citlivostZelena = zelena;
            citlivostModra = modra;
            switch (rozpoznavat)
            {
                case 0: aktualniCitlivost = cervena; break;
                case 1: aktualniCitlivost = zelena; break;
                case 2: aktualniCitlivost = modra; break;
            }
        }
    }
    
}
