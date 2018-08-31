using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog_Areas_Proyecto.Modelos;


namespace Prog_Areas_Proyecto.Controllers
{
    public class ProyectoController
    {
        public static bool IsNewProject(int id)
        {
            using (var db = new DB_BIM())
            {
                var _record = db.GetSingleElement<Proyecto>(x => x.Id == id);

                if (_record == null)
                {
                    return true;
                }

                return false;
            }
        }

        public static Proyecto UpdateProyecto(DataSets.DataSetProyectos.obrasRow obra)
        {
            using (var db = new DB_BIM())
            {
                var _record = db.GetSingleElement<Proyecto>(x => x.Id == obra.idobra);

                _record.Nombre = obra.nombre;
                _record.Cod = obra.codigo;
                _record.Localizacion = obra.localizacion;
                //_record.Fecha_Comienzo = obra.fechacomienzo;
                //_record.Fecha_Fin = obra.fechafin;

                return db.UpdateElement<Proyecto>(x => x.Id == _record.Id, _record.GetType(), _record);
            }
        }

        public static Proyecto UpdateProyecto(Proyecto proyecto)
        {
            using (var db = new DB_BIM())
            {
                var _record = db.GetSingleElement<Proyecto>(x => x.Id == proyecto.Id);

                _record.Nombre = proyecto.Nombre;
                _record.Cod = proyecto.Cod;
                _record.Localizacion = proyecto.Localizacion;
                _record.Fecha_Comienzo = proyecto.Fecha_Comienzo;
                _record.Fecha_Fin = proyecto.Fecha_Fin;
                _record.Cant_Habitaciones = proyecto.Cant_Habitaciones;

                db.SaveChanges();
                return _record;
            }
        }

        public static CoefArea UpdateCoefArea(CoefArea coef)
        {
            using (var db = new DB_BIM())
            {
                var _record = db.GetSingleElement<CoefArea>(x => x.Id == coef.Id);

                _record.Value = coef.Value;
                _record.Area_Programa = coef.Area_Programa;
                _record.Area_Local = coef.Area_Local;

                db.SaveChanges();
                return _record;
            }
        }

    }
}
