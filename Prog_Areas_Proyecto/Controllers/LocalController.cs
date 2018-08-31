using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog_Areas_Proyecto.Modelos;


namespace Prog_Areas_Proyecto.Controllers
{
    public class LocalController
    {
        public static List<Local> GetAllLocales()
        {
            using (var db = new DB_BIM())
            {
                return db.GetAllElements<Local>();
            }
        }


        public static Comunicaciones_Tv InsertarComunicacionesTV(Comunicaciones_Tv comm)
        {
            using (var db = new DB_BIM())
            {
                return db.AddElemento<Comunicaciones_Tv>(comm.GetType(), comm);
            }
        }

        public static Local UpdatePorcientoBD(Local local)
        {
            using (var db = new DB_BIM())
            {
                var _record = db.GetSingleElement<Local>(x => x.Id == local.Id);
                _record.Porciento_BD = local.Porciento_BD;

                db.SaveChanges();
                return _record;
            }
        }

        public static void AddLocalesProyecto(Locales_Proyecto localProyecto)
        {using (var db = new DB_BIM())
            {
                db.AddElemento<Locales_Proyecto>(localProyecto.GetType(), localProyecto);
                db.Locales_Proyecto.Add(localProyecto);
                db.SaveChanges();
            }
        }


        public static Locales_Proyecto UpdateLocalesProyecto(Locales_Proyecto localProyecto)
        {
            using (var db = new DB_BIM())
            {
                var _record = db.GetSingleElement<Locales_Proyecto>(x => x.Id == localProyecto.Id);
                _record.Local1.RoomId = localProyecto.Local1.RoomId;
                db.Entry(_record).State = EntityState.Modified;
                db.SaveChanges();

                return _record;
            }
        }
    }
}
