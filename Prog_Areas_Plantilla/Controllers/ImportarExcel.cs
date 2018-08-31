using OfficeOpenXml;
using Prog_Areas_Plantilla.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog_Areas_Plantilla.Controllers
{
    static class ImportarExcel
    {
        static ExcelPackage _excel;

        public static ExcelPackage Singleton()
        {
            if (_excel == null)
            {
                OpenFileDialog _fileDialog = new OpenFileDialog();
                DialogResult _dialogResult = _fileDialog.ShowDialog();
                if (_dialogResult == DialogResult.OK)
                {
                    var _fileInfo = new FileInfo(_fileDialog.FileName);
                    _excel = new ExcelPackage(_fileInfo);
                    return _excel;
                }
            }

            return _excel;
        }

        public static ExcelWorksheet GetWorkSheetByName(string wsName)
        {
            return _excel.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == wsName);
        }

        public static List<string> GetAcabadosName(ExcelWorksheet acabadosPage)
        {
            List<string> nombres = new List<string>();
            for (int i = 4; i < acabadosPage.Dimension.Rows + 3; i++)
            {
                nombres.Add(acabadosPage.Cells[i, 1].Value.ToString());
            }

            return nombres;
        }

        public static List<T_Ambiente> GetAllAmbientes()
        {
            var ambientesPage = GetWorkSheetByName("Ambientes");

            List<T_Ambiente> _allAmbientes = new List<T_Ambiente>();

            for (int i = 2; i < ambientesPage.Dimension.Rows + 1; i++)
            {
                var _id = ambientesPage.Cells[i, 1].Value.ToString();
                var _suelo = ambientesPage.Cells[i, 3].Value.ToString();
                var _rodapie = ambientesPage.Cells[i, 4].Value.ToString();
                var _pared = ambientesPage.Cells[i, 5].Value.ToString();
                var _techo = ambientesPage.Cells[i, 6].Value.ToString();
                var _impermeable = ambientesPage.Cells[i, 7].Value.ToString();
                T_Ambiente _ambiente = new T_Ambiente()
                {
                    Id = int.Parse(_id),
                    Nombre = ambientesPage.Cells[i, 2].Value.ToString(),
                    Suelo = new DB_PLANTILLA().GetSingleRecord<T_Catalogo_Suelo>(x => x.Cod == _suelo).Id,
                    Pared = new DB_PLANTILLA().GetSingleRecord<T_Catalogo_Pared>(x => x.Cod == _pared).Id,
                    Rodapie = new DB_PLANTILLA().GetSingleRecord<T_Catalogo_Rodapie>(x => x.Cod == _rodapie).Id,
                    Techo = new DB_PLANTILLA().GetSingleRecord<T_Catalogo_Techo>(x => x.Cod == _techo).Id,
                    Impermeable = new DB_PLANTILLA().GetSingleRecord<T_Catalogo_Impermeable>(x => x.Cod == _impermeable).Id
                };

                _allAmbientes.Add(_ambiente);
            }

            return _allAmbientes;
        }

        public static object GetCatalogoRow(string codigo)
        {
            var _worksheet = GetWorkSheetByName("Catalogo");
            object _record = new ExpandoObject();

            for (int i = 2; i < _worksheet.Dimension.Rows + 1; i++)
            {
                if (_worksheet.Cells[i, 1].Value != null)
                {
                    if (_worksheet.Cells[i, 1].Value.ToString() == codigo)
                    {
                        _record = new
                        {
                            Cod = _worksheet.Cells[i, 1].Value,
                            Capitulo_ID = _worksheet.Cells[i, 2].Value,
                            Capitulo = _worksheet.Cells[i, 3].Value,
                            Grupo = _worksheet.Cells[i, 4].Value
                        };
                    } }
            }

            return _record;
        }

        public static List<object> GetSubsistema<T>(string pageName) where T : class
        {
            var _worksheet = GetWorkSheetByName(pageName);
            List<object> _allSubsistemas = new List<object>();
            object _record = new ExpandoObject();

            for (int i = 2; i < _worksheet.Dimension.Rows + 1; i++)
            {
                _record = new
                {
                    Value = _worksheet.Cells[i, 1].Value
                };

                _allSubsistemas.Add(_record);
            }

            return _allSubsistemas;
        }

        public static List<T_Alojamiento> GetAlojamientos()
        {
            var _worksheet = GetWorkSheetByName("AlojamientoTipo");
            List<T_Alojamiento> _allAlojamientos = new List<T_Alojamiento>();

            for (int i = 2; i < _worksheet.Dimension.Rows + 1; i++)
            {
                T_Alojamiento _alojamiento = new T_Alojamiento()
                {
                    Value = _worksheet.Cells[i, 1].Value.ToString()
                };

                _allAlojamientos.Add(_alojamiento);
            }

            return _allAlojamientos;
        }

        public static List<T_Grupo_Locales> GetAllGrupoLocales()
        {
            var _worksheet = GetWorkSheetByName("Cod1");
            List<T_Grupo_Locales> _allGrupoLocales = new List<T_Grupo_Locales>();

            for (int i = 2; i < _worksheet.Dimension.Rows + 1; i++)
            {
                T_Grupo_Locales _gL = new T_Grupo_Locales()
                {
                    Value = _worksheet.GetSingleCellValue(i, 1),
                    Cod1 = _worksheet.GetSingleCellValue(i, 2)
                };

                _allGrupoLocales.Add(_gL);
            }

            return _allGrupoLocales;
        }

        public static Dictionary<string, List<string>> GetAllLocalesTipo()
        {
            var _worksheet = GetWorkSheetByName("LocalTipo");
            Dictionary<string, List<string>> _allLocalesTipo = new Dictionary<string, List<string>>();

            for (int i = 2; i < _worksheet.Dimension.Rows + 1; i++)
            {
                //_allLocalesTipo.Add(_worksheet.GetSingleCellValue(i, 1), _worksheet.GetSingleCellValue(i, 3));
                if (_allLocalesTipo.ContainsKey(_worksheet.GetSingleCellValue(i, 3)))
                {
                    _allLocalesTipo[_worksheet.GetSingleCellValue(i, 3)].Add(_worksheet.GetSingleCellValue(i, 1));
                }
                else
                {
                    var _lista = new List<string> {_worksheet.GetSingleCellValue(i, 1)};
                    _allLocalesTipo.Add(_worksheet.GetSingleCellValue(i, 3), _lista);
                }
            }

            return _allLocalesTipo;
        }

        public static List<string> GetColumnValues(int column)
        {
            var _worksheet = GetWorkSheetByName("BaseDatos");
            List<string> _records = new List<string>();
            
            for (int i = 2; i < _worksheet.Dimension.Rows + 1; i++)
            {
                _records.Add(_worksheet.Cells[i, column].Value == null ? "-" : _worksheet.Cells[i, column].Value.ToString());
            }

            return _records;
        }


        public static string GetSingleCellValue(this ExcelWorksheet worksheet, int row, int col)
        {
            return worksheet.Cells[row, col].Value == null ? "-" : worksheet.Cells[row, col].Value.ToString();
        }

    }
}
