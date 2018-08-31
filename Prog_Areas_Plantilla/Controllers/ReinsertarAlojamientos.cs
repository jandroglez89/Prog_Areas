using Prog_Areas_Plantilla.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_Areas_Plantilla.Controllers
{
    class ReinsertarAlojamientos
    {
        public static void InsertarAlojamiento()
        {
            var _alojamientos = ImportarExcel.GetAlojamientos();

            using (var db = new DB_PLANTILLA())
            {
                foreach (var item in _alojamientos)
                {
                    db.AddElemento(item.GetType(), item);
                }
            }
        }
    }
}
