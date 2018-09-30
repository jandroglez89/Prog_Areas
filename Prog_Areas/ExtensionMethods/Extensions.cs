using OfficeOpenXml;
using Prog_Areas_Proyecto.Controllers;
using Prog_Areas_Plantilla.Controllers;
using Prog_Areas_Plantilla.Modelos;
using Prog_Areas_Proyecto.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Prog_Areas_Proyecto.DataSets;

//using static Prog_Areas_Proyecto.DataSets.DataSetProyectos;

namespace Prog_Areas.ExtensionMethods
{
    static class Extensions
    {
        #region Strings

        public static string ProcesarCadena(this string data)
        {
            var _process = data;

            _process = _process.Replace('á', 'a');
            _process = _process.Replace('é', 'e');
            _process = _process.Replace('í', 'i');
            _process = _process.Replace('ó', 'o');
            _process = _process.Replace('ú', 'u');
            _process = _process.Replace(".", string.Empty);
            _process = _process.Replace(":", string.Empty);
            _process = _process.Trim();

            return _process;
        }

        #endregion



        #region Locales

        public static Local ToProject(this T_Local t_local)
        {
            var grupoLocales = new DB_PLANTILLA().GetSingleRecord<T_Grupo_Locales>(x => x.Id == t_local.Grupo_Local);
            //var localTipo = new DB_PLANTILLA().GetSingleRecord<T_LocalTipo>(x => x.Grupo_Locales == grupoLocales.Id).ToProject();
            var localTipo = new DB_PLANTILLA().GetSingleRecord<T_LocalTipo>(x => x.Id == t_local.LocalTipo).ToProject();

            Local _local = new Local()
            {
                Alojamiento = t_local.Alojamiento,
                Ambiente = t_local.Ambiente,
                Climatizacion = t_local.Climatizacion,
                Coef_Area = t_local.Coef_Area,
                Comunicaciones_TV = t_local.Comunicaciones_TV,
                Habitacion = t_local.Habitacion,
                Key_Name = t_local.Key_Name,
                Local_Tipo = localTipo.Id,
                Grupo_Local = grupoLocales.Id,
                Mod = t_local.Mod,
                Porciento_BD = t_local.Porciento_BD,
                RoomId = t_local.RoomId,
                SubsistemaArea = t_local.SubsistemaArea,
                SubsistemaTipo = t_local.SubsistemaTipo,
                Tipo_Edificio = t_local.Tipo_Edificio
            };

            return _local;
        }

        public static Ambiente ToProject(this T_Ambiente t_ambiente)
        {
            Ambiente _ambiente = new Ambiente()
            {
                Impermeable = t_ambiente.Impermeable,
                Nombre = t_ambiente.Nombre,
                Pared = t_ambiente.Pared,
                Rodapie = t_ambiente.Rodapie,
                Suelo = t_ambiente.Suelo,
                Techo = t_ambiente.Techo
            };

            return _ambiente;
        }

        public static LocalTipo ToProject(this T_LocalTipo t_localTipo)
        {
            LocalTipo _localTipo = new LocalTipo()
            {
                Id = t_localTipo.Id,
                Value = t_localTipo.Value,
                Grupo_Locales = t_localTipo.Grupo_Locales
            };

            return _localTipo;
        }

        public static Climatizacion ToProject(this T_Climatizacion t_climatizacion)
        {
            var _tratamiento = new DB_PLANTILLA().GetSingleRecord<T_Tratamiento>(x => x.Id == t_climatizacion.Tratamiento).Convert<Tratamiento>();
            var _equipamiento = new DB_PLANTILLA().GetSingleRecord<T_Equipamiento>(x => x.Id == t_climatizacion.Equipamiento).Convert<Equipamiento>();
            var _criterio = new DB_PLANTILLA().GetSingleRecord<T_Criterio>(x => x.Id == t_climatizacion.Criterio).Convert<Criterio>();
            var _aireFresco = new DB_PLANTILLA().GetSingleRecord<T_Aire_Fresco>(x => x.Id == t_climatizacion.Aire_Fresco).ToProject();
            var _renovaciones = new DB_PLANTILLA().GetSingleRecord<T_Renovaciones>(x => x.Id == t_climatizacion.Renovaciones).Convert<Renovaciones>();
            var _wAire = new DB_PLANTILLA().GetSingleRecord<T_W_Aire>(x => x.Id == t_climatizacion.W_Aire).Convert<W_Aire>();

            Climatizacion _clima = new Climatizacion()
            {
                Tratamiento1 = _tratamiento,
                Equipamiento1 = _equipamiento,
                Criterio1 = _criterio,
                Aire_Fresco1 = _aireFresco,
                Renovaciones1 = _renovaciones,
                W_Aire1 = _wAire
            };

            return _clima;                       
        }

        public static CoefArea ToProject(this T_CoefArea t_coefArea)
        {
            CoefArea _coefArea = new CoefArea()
            {
                Value = t_coefArea.Value
            };

            return _coefArea;
        }

        public static Aire_Fresco ToProject(this T_Aire_Fresco t_aireFresco)
        {
            var _persona = new DB_PLANTILLA().GetSingleRecord<T_AF_Persona>(x => x.Id == t_aireFresco.Persona).Convert<AF_Persona>();
            var _metroCuadrado = new DB_PLANTILLA().GetSingleRecord<T_AF_Metro_Cuadrado>(x => x.Id == t_aireFresco.Metro_Cuadrado).Convert<AF_Metro_Cuadrado>();

            Aire_Fresco _af = new Aire_Fresco()
            {
                AF_Persona = _persona,
                AF_Metro_Cuadrado = _metroCuadrado
            };

            return _af;
        }

        public static Comunicaciones_Tv ToProject(this T_Comunicaciones_Tv t_Comunicaciones)
        {
            var _tf = new DB_PLANTILLA().GetSingleRecord<T_TF>(x => x.Id == t_Comunicaciones.Tf).Convert<TF>();
            var _td = new DB_PLANTILLA().GetSingleRecord<T_TD>(x => x.Id == t_Comunicaciones.Td).Convert<TD>();
            var _td_pos = new DB_PLANTILLA().GetSingleRecord<T_TD_Pos>(x => x.Id == t_Comunicaciones.TD_Pos).Convert<TD_Pos>();
            var _upsc = new DB_PLANTILLA().GetSingleRecord<T_UPSC>(x => x.Id == t_Comunicaciones.UPSC).Convert<UPSC>();
            var _ttTv = new DB_PLANTILLA().GetSingleRecord<T_TT_TV>(x => x.Id == t_Comunicaciones.TT_TV).Convert<TT_TV>();
            var _di = new DB_PLANTILLA().GetSingleRecord<T_DI>(x => x.Id == t_Comunicaciones.Di).Convert<DI>();
            var _altv = new DB_PLANTILLA().GetSingleRecord<T_ALTV>(x => x.Id == t_Comunicaciones.Altv).Convert<ALTV>();
            var _upsi = new DB_PLANTILLA().GetSingleRecord<T_UPSI>(x => x.Id == t_Comunicaciones.UPSI).Convert<UPSI>();

            Comunicaciones_Tv _comm = new Comunicaciones_Tv()
            {
                TF1 = _tf,
                TD1 = _td,
                TD_Pos1 = _td_pos,
                UPSC1 = _upsc,
                TT_TV1 = _ttTv,
                DI1 = _di,
                ALTV1 = _altv,
                UPSI1 = _upsi
            };

            return _comm;
        }

        /*public static T Convert<T>(this object obj)
        {
            Type _objectType = obj.GetType();
            Type _targetType = typeof(T);
            var _instance = Activator.CreateInstance(_targetType, false);
            var s = from source in _objectType.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            var d = from source in _targetType.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            //var d = _targetType.GetMembers().Where(mt => mt.MemberType == MemberTypes.Property);
            List<MemberInfo> _members = d.Where(memberInfo => d.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo _propertyInfo;
            object _propertyValue;
            foreach (var item in _members)
            {
                if (item != null)
                {
                    _propertyInfo = typeof(T).GetProperty(item.Name);
                    _propertyValue = obj.GetType().GetProperty(item.Name).GetValue(obj, null);

                    _propertyInfo.SetValue(_instance, _propertyValue, null); 
                }
            }
            return (T)_instance;
        }*/

        public static Local GetLocal(this Locales_Proyecto localProyecto)
        {
            using (var db = new DB_BIM())
            {
                return db.GetSingleElement<Local>(x => x.Id == localProyecto.Local);
            }
        }

        public static Proyecto GetProyecto(this Locales_Proyecto localProyecto)
        {
            using (var db = new DB_BIM())
            {
                return db.GetSingleElement<Proyecto>(x => x.Id == localProyecto.Proyecto);
            }
        }

        public static string CalcularCod2(this Local local)
        {

            var _cod2 = "";
            var _subsistemaTipo = new DB_PLANTILLA().GetSingleRecord<T_Subsistema_Tipo>(x => x.Id == local.SubsistemaTipo).Value;
            var _subsistemaArea = new DB_PLANTILLA().GetSingleRecord<T_Subsistema_Area>(x => x.Id == local.SubsistemaArea).Value;

            switch (_subsistemaTipo)
            {
                case "Alojamiento":
                    _cod2 += "A";
                    break;
                case "Gastronomía":
                    _cod2 += "G";
                    break;
                case "Público-Comercial":
                    _cod2 += "PC";
                    break;
                case "Recreacion en Interiores":
                    _cod2 += "R";
                    break;
                case "Recreación en Exteriores":
                    _cod2 += "R";
                    break;
                case "Administrativo":
                    _cod2 += "A";
                    break;
                case "Otras Areas Exteriores":
                    _cod2 += "R";
                    break;
                default:
                    _cod2 += "";
                    break;
            }

            switch (_subsistemaArea)
            {
                case "Huéspedes":
                    _cod2 += "H";
                    break;
                case "Público":
                    _cod2 += "P";
                    break;
                case "Servicios":
                    _cod2 += "S";
                    break;
                case "Administrativo":
                    _cod2 += "";
                    break;
                case "Varios":
                    _cod2 += "";
                    break;
                default:
                    _cod2 += "";
                    break;
            }


            return _cod2;
        }

        public static string CalcularCod2(this T_Local local)
        {

            var _cod2 = "";
            var _subsistemaTipo = new DB_PLANTILLA().GetSingleRecord<T_Subsistema_Tipo>(x => x.Id == local.SubsistemaTipo).Value;
            var _subsistemaArea = new DB_PLANTILLA().GetSingleRecord<T_Subsistema_Area>(x => x.Id == local.SubsistemaArea).Value;

            switch (_subsistemaTipo)
            {
                case "Alojamiento":
                    _cod2 += "A";
                    break;
                case "Gastronomía":
                    _cod2 += "G";
                    break;
                case "Público-Comercial":
                    _cod2 += "PC";
                    break;
                case "Recreacion en Interiores":
                    _cod2 += "R";
                    break;
                case "Recreación en Exteriores":
                    _cod2 += "R";
                    break;
                case "Administrativo":
                    _cod2 += "A";
                    break;
                case "Otras Areas Exteriores":
                    _cod2 += "R";
                    break;
                default:
                    _cod2 += "";
                    break;
            }

            switch (_subsistemaArea)
            {
                case "Huéspedes":
                    _cod2 += "H";
                    break;
                case "Público":
                    _cod2 += "P";
                    break;
                case "Servicios":
                    _cod2 += "S";
                    break;
                case "Administrativo":
                    _cod2 += "";
                    break;
                case "Varios":
                    _cod2 += "";
                    break;
                default:
                    _cod2 += "";
                    break;
            }


            return _cod2;
        }

        public static string CalcularCod3(this Local local)
        {
            var _porcientoBD = new DB_PLANTILLA().GetSingleRecord<T_Porciento_BD>(x => x.Id == local.Porciento_BD).Value.ToString().Replace('.', ',');

            switch (_porcientoBD)
            {
                case "1,0":
                    return "CC";
                case "1":
                    return "CC";
                case "0,25":
                    return "EX";
                default:
                    return "CA";
            }
        }

        public static string CalcularCod3(this string porcientoBD)
        {
            switch (porcientoBD.Replace('.', ','))
            {
                case "1,0":
                    return "CC";
                case "1":
                    return "CC";
                case "0,25":
                    return "EX";
                default:
                    return "CA";
            }
        }

        #endregion

        #region Coef

        public static int GetCoefNumHab(this Local local, int cantHab)
        {
            var _coef = new DB_BIM().GetSingleElement<CoefArea>(x => x.Id == local.Coef_Area);
            var _localBase = new DB_PLANTILLA().GetSingleRecord<T_Local>(x => x.RoomId == local.RoomId);

            if (_coef.Value == null)
            {
                _coef.Value = "0";
            }

            if (_localBase == null)
            {
                return cantHab;
            }


                if (float.Parse(_coef.Value) < 2 && !_localBase.Key_Name.Contains("Closet"))
            {
                return cantHab;
            }

            return 1;
        }

        public static float CalcularArea(this Local local, int cantHab)
        {
            //var _coef = DataBaseController.GetSingleRecord<T_CoefArea>(new DB_PLANTILLA(), x => x.Id == local.Coef_Area);
            var _coef = new DB_BIM().GetSingleElement<CoefArea>(x => x.Id == local.Coef_Area);
            var _localBase = new DB_PLANTILLA().GetSingleRecord<T_Local>(x => x.RoomId == local.RoomId);

            if (float.Parse(_coef.Value) <= 2 && _localBase.Key_Name.Contains("Closet"))
            {
                return float.Parse(_coef.Value) * cantHab;
            }

            return float.Parse(_coef.Value);

        }

        #endregion



        #region Cod1



        #endregion

        #region Usuario
        public static Usuario toUsuario(this DataSetProyectos.UsuarioRow obj)
        {
            var _return = new Usuario()
            {
                Id = obj.Id,
                username = obj.username,
                password = obj.password,
                access_Level = obj.access_Level
            };
            return _return;
        }
        #endregion

        #region ExcelWorksheet

        public static string getCellValue(this ExcelWorksheet _worksheet, int row, int col)
        {
            return _worksheet.Cells[row, col].Value == null ? "-" : _worksheet.Cells[row, col].Value.ToString();
        }

        public static int getCellValueInt(this ExcelWorksheet _worksheet, int row, int col)
        {
            var _temp = _worksheet.Cells[row, col].Value == null ? "0" : _worksheet.Cells[row, col].Value.ToString();
            return int.Parse(_temp);
        }

        public static float getCellValueFloat(this ExcelWorksheet _worksheet, int row, int col)
        {
            var _temp = _worksheet.Cells[row, col].Value == null ? "0.0" : _worksheet.Cells[row, col].Value.ToString();
            return float.Parse(_temp);
        }

        #endregion

        #region Tipos

        public static float ReturnOne(this float Value)
        {
            return 1;
        }

        public static T Convert<T>(this object obj) where T : class
        {
            dynamic _temp = Activator.CreateInstance(typeof(T));

            var _prop = obj.GetType().GetProperty("Value");
            var _itemValue = _prop.GetValue(obj, null);

            _temp.Value = _itemValue.ToString();

            return _temp;
        }

        public static T ConvertInt<T>(this object obj) where T : class
        {
            dynamic _temp = Activator.CreateInstance(typeof(T));

            var _prop = obj.GetType().GetProperty("Value");
            var _itemValue = _prop.GetValue(obj, null);

            _temp.Value = int.Parse(_itemValue.ToString());

            return _temp;
        }

        public static T ConvertFloat<T>(this object obj) where T : class
        {
            dynamic _temp = Activator.CreateInstance(typeof(T));

            var _prop = obj.GetType().GetProperty("Value");
            var _itemValue = _prop.GetValue(obj, null);

            _temp.Value = float.Parse(_itemValue.ToString());

            return _temp;
        }

        #endregion


    }
}
