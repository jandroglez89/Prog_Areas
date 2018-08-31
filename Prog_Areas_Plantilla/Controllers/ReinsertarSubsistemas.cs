using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog_Areas_Plantilla.Modelos;
using System.Reflection;

namespace Prog_Areas_Plantilla.Controllers
{
    class ReinsertarSubsistemas
    {
        public static void InsertarSubsistemas<T>() where T : class
        {
            string _pageName = "";

            switch (typeof(T).Name)
            {
                case "T_Subsistema_Area":
                    _pageName = "SubsistemaArea";
                    break;
                case "T_Subsistema_Tipo":
                    _pageName = "SubsistemaTipo";
                    break;
            }

            var _subAreas = ImportarExcel.GetSubsistema<T>(_pageName);

            using (var db = new DB_PLANTILLA())
            {
                foreach (var item in _subAreas)
                {
                    IList<PropertyInfo> _properties = new List<PropertyInfo>(item.GetType().GetProperties());

                    dynamic _subsistema = Activator.CreateInstance<T>();

                    _subsistema.Value = _properties.FirstOrDefault(p => p.Name == "Value").GetValue(item).ToString();

                    DataBaseController.AddElemento(db, typeof(T), _subsistema);
                }
            }
        }
        
    }
}
