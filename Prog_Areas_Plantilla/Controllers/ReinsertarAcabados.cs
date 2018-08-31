using Prog_Areas_Plantilla.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Prog_Areas_Plantilla.Controllers
{
    class ReinsertarAcabados
    {
        public static void AdicionarAll<T>() where T : class
        {
            //ImportarExcel.Singleton();

            string _pageName = "";
            switch (typeof(T).Name)
            {
                case "T_Catalogo_Techo":
                    _pageName = "Techos";
                    break;
                case "T_Catalogo_Pared":
                    _pageName = "Paredes";
                    break;
                case "T_Catalogo_Rodapie":
                    _pageName = "Rodapie";
                    break;
                case "T_Catalogo_Suelo":
                    _pageName = "Suelos";
                    break;
                case "T_Catalogo_Impermeable":
                    _pageName = "Impermeable";
                    break;
            }

            var _workSheet = ImportarExcel.GetWorkSheetByName(_pageName);

            var _acabadosName = ImportarExcel.GetAcabadosName(_workSheet);

            using (var dbp = new DB_PLANTILLA())
            {
                foreach (var item in _acabadosName)
                {
                    var _record = ImportarExcel.GetCatalogoRow(item);
                    IList<PropertyInfo> _properties = new List<PropertyInfo>(_record.GetType().GetProperties());

                    dynamic _acabado = Activator.CreateInstance(typeof(T));
                    _acabado.Cod = _properties.FirstOrDefault(p => p.Name == "Cod").GetValue(_record).ToString();
                    _acabado.CapituloID = _properties.FirstOrDefault(p => p.Name == "Capitulo_ID").GetValue(_record).ToString();
                    _acabado.Capitulo = _properties.FirstOrDefault(p => p.Name == "Capitulo").GetValue(_record).ToString();
                    _acabado.Grupo = _properties.FirstOrDefault(p => p.Name == "Grupo").GetValue(_record).ToString();
                    
                    DataBaseController.AddElemento(dbp, typeof(T), _acabado);
                }
            }
        }

        public static void AdicionarAmbientes()
        {
            //ImportarExcel.Singleton();

            var _allAmbientes = ImportarExcel.GetAllAmbientes();

            foreach (var item in _allAmbientes)
            {
                new DB_PLANTILLA().AddElemento(item.GetType(), item);
            }
            
        }
    }
}
