using OfficeOpenXml;
using Prog_Areas_Plantilla.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Prog_Areas_Plantilla.Controllers
{
    static class ReinsertarLocal
    {
        public static void InsertarParametros<T>(int column) where T : class
        {
            var _records = ImportarExcel.GetColumnValues(column);

            var _uniqueRecords = _records.Distinct();

            foreach (var item in _uniqueRecords)
            {
                dynamic _parameter = Activator.CreateInstance(typeof(T));
                
                _parameter.Value = item;

                DataBaseController.AddElemento(new DB_PLANTILLA(), typeof(T), _parameter);
            }
        }

        public static void InsertarParametroInt<T>(int column) where T : class
        {
            var _records = ImportarExcel.GetColumnValues(column);

            var _uniqueRecords = _records.Distinct();

            foreach (var item in _uniqueRecords)
            {
                dynamic _parameter = Activator.CreateInstance(typeof(T));

                _parameter.Value = item == "-" ? 0 : int.Parse(item);

                DataBaseController.AddElemento(new DB_PLANTILLA(), typeof(T), _parameter);
            }
        }

        public static void InsertarParametroFloat<T>(int column) where T : class
        {
            var _records = ImportarExcel.GetColumnValues(column);

            var _uniqueRecords = _records.Distinct();

            foreach (var item in _uniqueRecords)
            {
                dynamic _parameter = Activator.CreateInstance(typeof(T));

                _parameter.Value = item == "-" ? 0.0f : float.Parse(item);

                DataBaseController.AddElemento(new DB_PLANTILLA(), typeof(T), _parameter);
            }
        }

        public static void InsertarAireFresco()
        {
            var _worksheet = ImportarExcel.GetWorkSheetByName("BaseDatos");

            T_Aire_Fresco _af = null;
            for (int i = 2; i < _worksheet.Dimension.Rows + 1; i++)
            {

                var _aireFrescoM = _worksheet.GetSingleCellValue(i, 26);
                var _aireFrescoP = _worksheet.GetSingleCellValue(i, 27);

                using (var db = new DB_PLANTILLA())
                {
                    var _afM = db.GetSingleRecord<T_AF_Metro_Cuadrado>(x => x.Value == _aireFrescoM);
                    var _afP = db.GetSingleRecord<T_AF_Persona>(x => x.Value == _aireFrescoP);

                    var _afRecord = db.GetSingleRecord<T_Aire_Fresco>(x => x.Persona == _afP.Id && x.Metro_Cuadrado == _afM.Id);

                    if (_afRecord == null)
                    {
                        _af = new T_Aire_Fresco()
                        {
                            Metro_Cuadrado = db.GetSingleRecord<T_AF_Metro_Cuadrado>(x => x.Value == _aireFrescoM).Id,
                            Persona = db.GetSingleRecord<T_AF_Persona>(x => x.Value == _aireFrescoP).Id
                        };

                        db.AddElemento(_af.GetType(), _af);
                    }

                    _af = _afRecord;
                }
            }
            
        }

        public static T_Climatizacion InsertarClimatizaciones(int i)
        {
            var _worksheet = ImportarExcel.GetWorkSheetByName("BaseDatos");

            var _tratamiento = _worksheet.GetSingleCellValue(i, 22);
            var _equipamiento = _worksheet.GetSingleCellValue(i, 23);
            var _criterioM = _worksheet.GetSingleCellValue(i, 24);
            var _aireFrescoM = _worksheet.GetSingleCellValue(i, 26);
            var _aireFrescoP = _worksheet.GetSingleCellValue(i, 27);
            var _renovaciones = _worksheet.GetSingleCellValue(i, 28);
            var _wAire = _worksheet.GetSingleCellValue(i, 29);


            using (var db = new DB_PLANTILLA())
            {
                var _afM = db.GetSingleRecord<T_AF_Metro_Cuadrado>(x => x.Value == _aireFrescoM).Id;
                var _afP = db.GetSingleRecord<T_AF_Persona>(x => x.Value == _aireFrescoP).Id;

                var _af = db.GetSingleRecord<T_Aire_Fresco>(x => x.Metro_Cuadrado == _afM && x.Persona == _afP).Id;

                T_Climatizacion _clima = new T_Climatizacion()
                {
                    Tratamiento = db.GetSingleRecord<T_Tratamiento>(x => x.Value == _tratamiento).Id,
                    Equipamiento = db.GetSingleRecord<T_Equipamiento>(x => x.Value == _equipamiento).Id,
                    Criterio = db.GetSingleRecord<T_Criterio>(x => x.Value == _criterioM).Id,
                    Aire_Fresco = _af,
                    Renovaciones = db.GetSingleRecord<T_Renovaciones>(x => x.Value == _renovaciones).Id,
                    W_Aire = db.GetSingleRecord<T_W_Aire>(x => x.Value == _wAire).Id
                };

                var _record = db.GetSingleRecord<T_Climatizacion>(x => x.Tratamiento == _clima.Tratamiento &&
                                                                     x.Equipamiento == _clima.Equipamiento &&
                                                                     x.Criterio == _clima.Criterio &&
                                                                     x.Aire_Fresco == _clima.Aire_Fresco &&
                                                                     x.Renovaciones == _clima.Renovaciones &&
                                                                     x.W_Aire == _clima.W_Aire);

                if (_record == null)
                {
                    db.AddElemento(_clima.GetType(), _clima);
                }
                else
                {
                    _clima = _record;
                }

                return _clima;
            }
        }

        public static T_Comunicaciones_Tv InsertarComunicacionesTV(int i)
        {
            var _worksheet = ImportarExcel.GetWorkSheetByName("BaseDatos");

            var _tf = _worksheet.GetSingleCellValue(i, 30);
            var _td = _worksheet.GetSingleCellValue(i, 31);
            var _tdPos = _worksheet.GetSingleCellValue(i, 32);
            var _upsc = _worksheet.GetSingleCellValue(i, 33);
            var _upsi = _worksheet.GetSingleCellValue(i, 34);
            var _tttv = _worksheet.GetSingleCellValue(i, 35);
            var _di = _worksheet.GetSingleCellValue(i, 36);
            var _altv = _worksheet.GetSingleCellValue(i, 37);

            using (var db = new DB_PLANTILLA())
            {
                T_Comunicaciones_Tv _comm = new T_Comunicaciones_Tv()
                {
                    Tf = db.GetSingleRecord<T_TF>(x => x.Value == _tf).Id,
                    Td = db.GetSingleRecord<T_TD>(x => x.Value == _td).Id,
                    TD_Pos = db.GetSingleRecord<T_TD_Pos>(x => x.Value == _tdPos).Id,
                    UPSC = db.GetSingleRecord<T_UPSC>(x => x.Value == _upsc).Id,
                    UPSI = db.GetSingleRecord<T_UPSI>(x => x.Value == _upsi).Id,
                    TT_TV = db.GetSingleRecord<T_TT_TV>(x => x.Value == _tttv).Id,
                    Di = db.GetSingleRecord<T_DI>(x => x.Value == _di).Id,
                    Altv = db.GetSingleRecord<T_ALTV>(x => x.Value == _altv).Id
                };

                var _record = db.GetSingleRecord<T_Comunicaciones_Tv>(x => x.Tf == _comm.Tf &&
                                                                         x.Td == _comm.Td &&
                                                                         x.TD_Pos == _comm.TD_Pos &&
                                                                         x.UPSC == _comm.UPSC &&
                                                                         x.UPSI == _comm.UPSI &&
                                                                         x.TT_TV == _comm.TT_TV &&
                                                                         x.Di == _comm.Di &&
                                                                         x.Altv == _comm.Altv);

                if (_record == null)
                {
                    db.AddElemento(_comm.GetType(), _comm);
                }
                else
                {
                    _comm = _record;
                }
                    
                return _comm;
            }
        }

        public static T_CoefArea InsertarCoefArea(int i)
        {
            var _worksheet = ImportarExcel.GetWorkSheetByName("BaseDatos");

            var _value = _worksheet.GetSingleCellValue(i, 7);

            using (var db = new DB_PLANTILLA())
            {
                T_CoefArea _coef = new T_CoefArea()
                {
                    Value = _value
                };

                var _record = db.GetSingleRecord<T_CoefArea>(x => x.Value == _coef.Value);

                if (_record == null)
                {
                    db.AddElemento(_coef.GetType(), _coef);
                }
                else
                {
                    _coef = _record;
                }

                return _coef;
            }

            
        }

        
        public static void InsertarLocales()
        {
            var _worksheet = ImportarExcel.GetWorkSheetByName("BaseDatos");

            using (var db = new DB_PLANTILLA())
            {
                for (int i = 2; i < _worksheet.Dimension.Rows + 1; i++)
                {
                    var _temp = "";
                    if (_worksheet.GetSingleCellValue(i, 1) == null || _worksheet.GetSingleCellValue(i, 1) == "-") { break; }
                    var _roomID = int.Parse(_worksheet.GetSingleCellValue(i, 1));
                    var _keyName = _worksheet.GetSingleCellValue(i, 5);
                    var _name = _worksheet.GetSingleCellValue(i, 6);
                    var _habitacion = _worksheet.GetSingleCellValue(i, 10) != "0";
                    _temp = _worksheet.GetSingleCellValue(i, 13);
                    var _subTipo = db.GetSingleRecord<T_Subsistema_Tipo>(x => x.Value == _temp).Id;
                    _temp = _worksheet.GetSingleCellValue(i, 14);
                    var _subArea = db.GetSingleRecord<T_Subsistema_Area>(x => x.Value == _temp).Id;
                    _temp = _worksheet.GetSingleCellValue(i, 3);
                    var _grupoLocales = db.GetSingleRecord<T_Grupo_Locales>(x => x.Cod1 == _temp).Id;
                    var _climatizacion = InsertarClimatizaciones(i).Id;
                    var _comunicaciones = InsertarComunicacionesTV(i).Id;
                    _temp = _worksheet.GetSingleCellValue(i, 16);
                    var _ambiente = db.GetSingleRecord<T_Ambiente>(x => x.Nombre == _temp).Id;
                    var _coefArea = InsertarCoefArea(i).Id;
                    var _tempInt = int.Parse(_worksheet.GetSingleCellValue(i, 11));
                    var _mod = db.GetSingleRecord<T_Mod>(x => x.Value == _tempInt).Id;
                    var _tempFloat = float.Parse(_worksheet.GetSingleCellValue(i, 9));
                    var _porcientoBD = db.GetSingleRecord<T_Porciento_BD>(x => x.Value == _tempFloat).Id;_temp = _worksheet.GetSingleCellValue(i, 15);
                    var _localTipo = db.GetSingleRecord<T_LocalTipo>(x => x.Value == _temp).Id;
                    _temp = _worksheet.GetSingleCellValue(i, 12);
                    var _tipoEdificio = db.GetSingleRecord<T_Tipo_Edificio>(x => x.Value == _temp).Id;

                    T_Local _local = new T_Local()
                    {
                        RoomId = _roomID,
                        Key_Name = _keyName,
                        Name = _name,
                        Habitacion = _habitacion,
                        SubsistemaTipo = _subTipo,
                        SubsistemaArea = _subArea,
                        Climatizacion = _climatizacion,
                        Comunicaciones_TV = _comunicaciones,
                        Ambiente = _ambiente,
                        Coef_Area = _coefArea,
                        Mod = _mod,
                        Porciento_BD = _porcientoBD,
                        LocalTipo = _localTipo,
                        Grupo_Local = _grupoLocales,
                        Tipo_Edificio = _tipoEdificio
                    };

                    db.AddElemento(_local.GetType(), _local);

                } 
            }
        }


        
        
    }
}

