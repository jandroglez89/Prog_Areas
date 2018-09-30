using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using Prog_Areas_Plantilla.Modelos;
using Prog_Areas_Plantilla.Controllers;
using Prog_Areas_Proyecto.Modelos;

namespace Prog_Areas
{
    static class Program
    {
        public static Usuario _autenticatedUser = new Usuario();
        public static List<Local> _locales = new List<Local>();
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
