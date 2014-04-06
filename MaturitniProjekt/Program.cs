using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MaturitniProjekt
{
    static class Program
    {
        /// <summary>
        /// Main metoda aplikace.
        /// Je zavolána jako první při spuštění programu.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HlavniOkno());
        }
    }
}
