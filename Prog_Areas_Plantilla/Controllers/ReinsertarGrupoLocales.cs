using Prog_Areas_Plantilla.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_Areas_Plantilla.Controllers
{
    class ReinsertarGrupoLocales
    {
        public static void InsertarGrupoLocales()
        {
            var _allGrupoLocales = ImportarExcel.GetAllGrupoLocales();

            foreach (var item in _allGrupoLocales)
            {
                new DB_PLANTILLA().AddElemento(item.GetType(), item);
            } 
            
        }

        public static void InsertarLocalesTipo()
        {
            var _allLocalesTipo = ImportarExcel.GetAllLocalesTipo();

            foreach (var keys in _allLocalesTipo)
            {
                var _grupoLocalesId = new DB_PLANTILLA().GetSingleRecord<T_Grupo_Locales>(x => x.Cod1 == keys.Key).Id;
                foreach (var value in keys.Value)
                {
                    T_LocalTipo _localTipo = new T_LocalTipo()
                    {
                        Value = value,
                        Grupo_Locales = _grupoLocalesId
                    };

                    new DB_PLANTILLA().AddElemento(_localTipo.GetType(), _localTipo);
                }
            }

            //using (var db = new DB_PLANTILLA())
            //{
                //foreach (var item in _allLocalesTipo)
                //{
                //    var _grupoLocalesId = DataBaseController.GetSingleRecord<T_Grupo_Locales>(new DB_PLANTILLA(), x => x.Cod1 == item.Value).Id;

                //    T_LocalTipo _localTipo = new T_LocalTipo()
                //    {
                //        Value = item.Key,
                //        Grupo_Locales = _grupoLocalesId
                //    };

                //    DataBaseController.AddElemento(new DB_PLANTILLA(), _localTipo.GetType(), _localTipo);
                //} 
            //}
        }
    }
}
