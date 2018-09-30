using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Prog_Areas_Proyecto.Modelos;
using System.IO;
using OfficeOpenXml;

using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System.Diagnostics;
using DevExpress.XtraGrid;
using Prog_Areas_Plantilla.Controllers;
using Prog_Areas.ExtensionMethods;
using Prog_Areas_Plantilla.Modelos;
using Prog_Areas_Proyecto.Controllers;
using Prog_Areas.Controllers;

namespace Prog_Areas.Formularios.Test
{
    public partial class ExcelImportForm : XtraForm
    {
        Dictionary<string, int> ColumnNumbers = new Dictionary<string, int>();
        public static Local ThisLocal = new Local();

        Proyecto _proyecto;
        public ExcelImportForm(Proyecto proyecto)
        {
            _proyecto = proyecto;

            InitializeComponent();

            this.Text = _proyecto.Cod + " - " + _proyecto.Nombre;

            OpenFileDialog();

        }

        void OpenFileDialog()
        {
            openFileDialog1.ShowHelp = true;
            DialogResult _dialog = openFileDialog1.ShowDialog();
            if (_dialog == DialogResult.OK)
            {
                ExcelImport.GetAllLocalesFromExcel(ref gridPrograma, openFileDialog1.FileName, _proyecto);
                //label1.Text = openFileDialog1.FileName;
                //ImportExcel(openFileDialog1.FileName);
            }
            else
            {
                //label1.Text = "";
            }
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            OpenFileDialog();
        }

        DataTable CreateDataTable(ExcelWorksheet ProgramaPage, int startRow)
        {
            DataTable _dataTable = new DataTable();

            for (int i = 1; i <= ProgramaPage.Dimension.Columns; i++)
            {
                _dataTable.Columns.Add(ProgramaPage.Cells[startRow, i].Value.ToString());
            }

            return _dataTable;
        }

        DataTable CreateDetallesDataTable(ExcelWorksheet DetallesPage, int startRow)
        {
            DataTable _dataTable = new DataTable();

            for(int i = 1; i <= DetallesPage.Dimension.Columns; i++)
            {

                //_dataTable.Columns.Add(DetallesPage.Cells[startRow, i].Value.ToString());

                switch (DetallesPage.Cells[startRow, i].Value.ToString())
                {
                    case "COD 1":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;
                    case "COD 2":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;
                    case "COD 3":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;
                    case "RoomID":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;
                    case "Local":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;
                    case "% Base Diseño":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;
                    case "Tipo Edificio":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;
                    case "Modulos":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;
                    case "Local Tipo":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;
                    case "Alojamiento Tipo":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;
                    case "Área del local [m²]":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;

                        //Acabados


                        //Comunicaciones y TV
                    case "TF":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;
                    case "TD":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;
                    case "TD-POS":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;
                    case "UPSC":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;
                    case "UPSI":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;
                    case "TT+TV":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;
                    case "DI":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;
                    case "ALTV":
                        AddDataTableRecord(_dataTable, DetallesPage, startRow, i);
                        break;
                }
            }

            return _dataTable;
        }

        void AddDataTableRecord(DataTable table, ExcelWorksheet ExcelPage, int startRow, int column)
        {
            table.Columns.Add(ExcelPage.Cells[startRow, column].Value.ToString());
            ColumnNumbers.Add(ExcelPage.Cells[startRow, column].Value.ToString(), column);
        }

        void ImportExcel(string fileName)
        {
            FileInfo _file = new FileInfo(fileName);
            using (ExcelPackage _package = new ExcelPackage(_file))
            {
                if (_package.Workbook.Worksheets.Count > 0)
                {
                    var _programaDetalle = _package.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == "Areas. (Detalle)  ");

                    if (/*_programaDetalle != null*/false)
                    {
                        //ImportarTablaDetalle(_programaDetalle);
                    }
                    else
                    {
                        var _programaPage = _package.Workbook.Worksheets.FirstOrDefault(ws => ws.Name == "Programa");

                        int _columns = _programaPage.Dimension.Columns;
                        int _rows = _programaPage.Dimension.Rows;

                        gridControlPrograma.DataSource = CreateDataTable(_programaPage, 11);

                        for (int i = 12; i < _rows; i++)
                        {
                            gridPrograma.AddNewRow();

                            int _rowHandle = gridPrograma.GetRowHandle(gridPrograma.DataRowCount);

                            if (!gridPrograma.IsNewItemRow(_rowHandle)) continue;
                            //Subsistema Tipo
                            gridPrograma.SetRowCellValue(_rowHandle, gridPrograma.Columns[0], (_programaPage.Cells[i, 1].Value ?? (_programaPage.Cells[i, 1].Value = _programaPage.Cells[i - 1, 1].Value)).ToString());
                            //Subsistema Area
                            gridPrograma.SetRowCellValue(_rowHandle, gridPrograma.Columns[1], (_programaPage.Cells[i, 2].Value ?? (_programaPage.Cells[i, 2].Value = _programaPage.Cells[i - 1, 2].Value)).ToString());
                            //Local Tipo
                            gridPrograma.SetRowCellValue(_rowHandle, gridPrograma.Columns[2], (_programaPage.Cells[i, 3].Value ?? (_programaPage.Cells[i, 3].Value = _programaPage.Cells[i - 1, 3].Value)).ToString());
                            //Cod1
                            gridPrograma.SetRowCellValue(_rowHandle, gridPrograma.Columns[3], (_programaPage.Cells[i, 4].Value ?? (_programaPage.Cells[i, 4].Value = _programaPage.Cells[i - 1, 4].Value)).ToString());

                            //Cod2
                            gridPrograma.SetRowCellValue(_rowHandle, gridPrograma.Columns[4], (_programaPage.Cells[i, 5].Value ?? (_programaPage.Cells[i, 5].Value = _programaPage.Cells[i - 1, 5].Value)).ToString());

                            //Cod3
                            gridPrograma.SetRowCellValue(_rowHandle, gridPrograma.Columns[5], (_programaPage.Cells[i, 6].Value ?? (_programaPage.Cells[i, 6].Value = _programaPage.Cells[i - 1, 6].Value)).ToString());
                            //Local
                            gridPrograma.SetRowCellValue(_rowHandle, gridPrograma.Columns[6], (_programaPage.Cells[i, 7].Value ?? (_programaPage.Cells[i, 7].Value = _programaPage.Cells[i - 1, 7].Value)).ToString());
                            //Habitaciones
                            gridPrograma.SetRowCellValue(_rowHandle, gridPrograma.Columns[7], (_programaPage.Cells[i, 8].Value ?? (_programaPage.Cells[i, 8].Value = _programaPage.Cells[i - 1, 8].Value)).ToString());
                            //Area Util
                            gridPrograma.SetRowCellValue(_rowHandle, gridPrograma.Columns[8], (_programaPage.Cells[i, 9].Value ?? (_programaPage.Cells[i, 9].Value = _programaPage.Cells[i - 1, 9].Value)).ToString());
                            //PBD
                            gridPrograma.SetRowCellValue(_rowHandle, gridPrograma.Columns[9], (_programaPage.Cells[i, 10].Value ?? (_programaPage.Cells[i, 10].Value = _programaPage.Cells[i - 1, 10].Value)).ToString());
                            //Area Calculo
                            gridPrograma.SetRowCellValue(_rowHandle, gridPrograma.Columns[10], (_programaPage.Cells[i, 11].Value ?? (_programaPage.Cells[i, 11].Value = _programaPage.Cells[i - 1, 11].Value)).ToString());
                        }

                        for (int i = 12; i < gridPrograma.RowCount; i++)
                        {
                            if (!gridPrograma.GetRowCellValue(i, "Subsistema Tipo").ToString().Contains("Total") &&
                                !gridPrograma.GetRowCellValue(i, "Subsistema Area").ToString().Contains("Total"))
                                continue;
                            gridPrograma.DeleteRow(i);
                            i--;
                        } 
                    }
                }
            }
        }


        void ImportarTablaDetalle(ExcelWorksheet ProgramaDetalle)
        {
            gridControlPrograma.Visible = false;
            gridControlDetalle.Visible = true;

            var _columns = ProgramaDetalle.Dimension.Columns;
            var _rows = ProgramaDetalle.Dimension.Rows;

            gridControlDetalle.DataSource = CreateDetallesDataTable(ProgramaDetalle, 1);

            for (int i = 2; i < _rows; i++)
            {
                gridDetalle.AddNewRow();

                int _rowHandle = gridDetalle.GetRowHandle(gridDetalle.DataRowCount);

                if (gridDetalle.IsNewItemRow(_rowHandle))
                {
                    foreach (var item in ColumnNumbers)
                    {
                        AddCellValue(ProgramaDetalle, item.Key, _rowHandle, i);
                    }
                }
            }
        }

        private void AddCellValue(ExcelWorksheet ExcelPage, string ColumnName, int rowHandle, int rowNumber)
        {
            gridDetalle.SetRowCellValue(rowHandle,
                                        gridDetalle.Columns[gridDetalle.Columns.FirstOrDefault(c => c.FieldName == ColumnName).AbsoluteIndex],
                                        ExcelPage.Cells[rowNumber, ColumnNumbers[ColumnName]].Value == null ? "-" : ExcelPage.Cells[rowNumber, ColumnNumbers[ColumnName]].Value.ToString());
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var _selectedGrid = gridControlPrograma.Visible ? gridPrograma : gridDetalle;

            var _subsistemasTipo = new DB_PLANTILLA().GetAllRecords<T_Subsistema_Tipo>();
            var _subsistemasArea = new DB_PLANTILLA().GetAllRecords<T_Subsistema_Area>();
            var _grupoLocales = new DB_PLANTILLA().GetAllRecords<T_Grupo_Locales>();
            var _porcientos = new DB_PLANTILLA().GetAllRecords<T_Porciento_BD>();
            var _coefAreas = new DB_PLANTILLA().GetAllRecords<T_CoefArea>();
            var _locales = new DB_PLANTILLA().GetAllRecords<T_Local>();

            for (int i = 0; i < _selectedGrid.DataRowCount; i++)
            {
                try
                {
                    _selectedGrid.FocusedRowHandle = i;
                    Local _local = new Local();
                    Locales_Proyecto _localProyecto = new Locales_Proyecto();

                    var _subsistemaTipo = "";
                    var _subsistemaArea = "";

                    GetSubsistemas(_selectedGrid.GetRowCellValue(i, "Cod2").ToString(), ref _subsistemaTipo, ref _subsistemaArea, _selectedGrid.GetRowCellValue(i, "Cod1").ToString());
                    //var _subTipoValue = _selectedGrid.GetRowCellValue(i, "Subsistema Tipo").ToString();
                    _local.SubsistemaTipo = _subsistemasTipo.FirstOrDefault(x => x.Value == _subsistemaTipo).Id;

                    //var _subAreaValue = _selectedGrid.GetRowCellValue(i, "Subsistema Area").ToString();
                    _local.SubsistemaArea = _subsistemasArea.FirstOrDefault(x => x.Value == _subsistemaArea).Id;

                    var _localTipoValue = _selectedGrid.GetRowCellValue(i, "LocalTipo").ToString();
                    var _cod1Value = _selectedGrid.GetRowCellValue(i, "Cod1").ToString().Replace(',', '.');
                    var _grupoLocal = _grupoLocales.FirstOrDefault(x => x.Cod1.Contains(_cod1Value)).Id;

                    LocalTipo _localTipo = new LocalTipo()
                    {
                        Grupo_Locales = _grupoLocal,
                        Value = _localTipoValue
                    };

                    var _porcientoBD = double.Parse(_selectedGrid.GetRowCellValue(i, "PorcientoBD").ToString());
                    //_porcientoBD = _porcientoBD / 100;

                    _local.Porciento_BD = _porcientos.FirstOrDefault(x => x.Value == _porcientoBD).Id;
                    

                    var _areaUtil = _selectedGrid.GetRowCellValue(i, "AreaLocal").ToString() == "" ? 0.00 : double.Parse(_selectedGrid.GetRowCellValue(i, "AreaLocal").ToString());
                    CoefArea _coef = new CoefArea()
                    {
                        Area_Local = _areaUtil
                    };

                    var _desgloseValue = _selectedGrid.GetRowCellValue(i, "Desglose").ToString();
                    var _desglose = new DB_BIM().GetSingleElement<Desglose>(x => x.Value == _desgloseValue && x.Proyecto == _proyecto.Id);

                    if (_desglose != null)
                    {
                        _local.Desglose = _desglose.Id;
                    }
                    else
                    {
                        Desglose _newDesglose = new Desglose()
                        {
                            Value = _desgloseValue,
                            Proyecto = _proyecto.Id
                        };

                        _local.Desglose1 = _newDesglose;
                    }
                     
                    var _localID = _locales.FirstOrDefault(x => x.Key_Name == _selectedGrid.GetRowCellValue(i, "RoomID").ToString());

                    var keyName = _selectedGrid.GetRowCellValue(i, "Local").ToString();

                    var localesProyecto = new DB_BIM().GetElements<Locales_Proyecto>(x => x.Proyecto == _proyecto.Id);
                    var realLocal =
                        localesProyecto.FirstOrDefault(
                            x =>
                                x.Local1.Desglose == _local.Desglose && x.Local1.LocalTipo == _localTipo &&
                                x.Local1.Key_Name == keyName);


                    if (realLocal != null)
                    {
                        LocalController.UpdateLocalesProyecto(realLocal);
                    }
                    else
                    {
                        _local.RoomId = _localID.RoomId;
                        _local.CoefArea = _coef;
                        _local.CoefArea.Value = _coefAreas.FirstOrDefault(x => x.Id == _localID.Coef_Area).Value;
                        _local.LocalTipo = _localTipo;
                        _local.Key_Name = keyName;

                        _local.Ambiente1 = _localID.T_Ambiente.ToProject();
                        _local.Comunicaciones_Tv1 = _localID.T_Comunicaciones_Tv.ToProject();
                        _local.Climatizacion1 = _localID.T_Climatizacion.ToProject();

                        _localProyecto.Local1 = _local;
                        _localProyecto.Proyecto = _proyecto.Id;
                        _localProyecto.Cantidad = _selectedGrid.GetRowCellValue(i, "Hab") == null ? 0 : int.Parse(_selectedGrid.GetRowCellValue(i, "Hab").ToString());

                        new DB_BIM().AddElemento<Locales_Proyecto>(typeof(Locales_Proyecto), _localProyecto);
                    }
                }
                catch (Exception ex)
                {
                    Excepciones.Excepciones.EnviarCorreo(ex);
                    //throw;
                }
            }
            
            MessageBox.Show("Completado!");
        }

        public static void GetSubsistemas(string Cod2, ref string SubTipo, ref string SubArea, string Cod1)
        {
            #region old Code
            /*if (Cod2 == "TM")
            {
                SubTipo = "Técnico - Mantenimiento";
                SubArea = "Servicios";
            }
            else
            {
                if (Cod2.Length > 1)
                {
                    var _subarea = Cod2[Cod2.Length - 1];
                    var _subtipo = "";

                    for (int i = 0; i < Cod2.Length - 1; i++)
                    {
                        _subtipo += Cod2[i];
                    }

                    switch (_subarea)
                    {
                        case 'H':
                            SubArea = "Huéspedes";
                            break;
                        case 'P':
                            SubArea = "Público";
                            break;
                        case 'S':
                            SubArea = "Servicios";
                            break;
                        case 'A':
                            SubArea = "Administrativo";
                            break;
                        case 'V':
                            SubArea = "Varios";
                            break;
                        default:
                            SubArea = " ";
                            break;
                    }

                    switch (_subtipo)
                    {
                        case "G":
                            SubTipo = "Gastronomía";
                            break;
                        case "PC":
                            SubTipo = "Público-Comercial";
                            break;
                        case "TM":
                            SubTipo = "Técnico - Mantenimiento";
                            break;
                        case "A":
                            SubTipo = "Administrativo";
                            SubArea = "Administrativo";
                            break;
                        case "R":
                            SubTipo = ManejarRecreacion(Cod1, ref SubArea);
                            break;
                        default:
                            SubTipo = " ";
                            break;
                    }
                }
                else
                {
                    var _subtipo = "";
                    switch (Cod2)
                    {
                        case "G":
                            SubTipo = "Gastronomía";
                            break;
                        case "PC":
                            SubTipo = "Público-Comercial";
                            break;
                        case "TM":
                            SubTipo = "Técnico - Mantenimiento";
                            break;
                        case "A":
                            SubTipo = "Administrativo";
                            SubArea = "Administrativo";
                            break;
                        case "R":
                            SubTipo = ManejarRecreacion(Cod1, ref SubArea);
                            break;

                    }
                } 
            }*/
            #endregion

            if (Cod1 == "1.1" || Cod1 == "1.2" || Cod1 == "1.3" || Cod1 == "1.4" || Cod1 == "1.5" || Cod1 == "1.6")
            {
                SubTipo = "Alojamiento";
                SubArea = "Huéspedes";
                return;}

            if (Cod1 == "2.1" || Cod1 == "2.2" || Cod1 == "2.3" || Cod1 == "2.4" || Cod1 == "2.5")
            {
                SubTipo = "Gastronomía";
                SubArea = "Público";
                return;
            }

            if (Cod1 == "3.1" || Cod1 == "3.2" || Cod1 == "3.3" || Cod1 == "3.4" || Cod1 == "3.5" || Cod1 == "3.6" || Cod1 == "3.7" || Cod1 == "3.8" || Cod1 == "3.9" || Cod1 == "3.10")
            {
                SubTipo = "Público-Comercial";
                SubArea = "Público";
                return;
            }

            if (Cod1 == "4.1" || Cod1 == "4.2" || Cod1 == "4.3" || Cod1 == "4.4" || Cod1 == "4.5" || Cod1 == "4.6" || Cod1 == "4.7" || Cod1 == "4.8" || Cod1 == "4.9" || Cod1 == "4.10" || Cod1 == "4.11" || Cod1 == "4.12")
            {
                SubTipo = "Recreacion en Interiores";
                SubArea = "Público";
                return;
            }

            if (Cod1 == "5.1" || Cod1 == "5.2")
            {
                SubTipo = "Recreación en Exteriores";
                SubArea = "Público";
                return;
            }

            if (Cod1 == "6.1" || Cod1 == "6.2" || Cod1 == "6.3")
            {
                SubTipo = "Alojamiento";
                SubArea = "Servicios";
                return;
            }

            if (Cod1 == "7.1" || Cod1 == "7.2" || Cod1 == "7.3" || Cod1 == "7.4" || Cod1 == "7.5" || Cod1 == "7.6" || Cod1 == "7.7")
            {
                SubTipo = "Gastronomía";
                SubArea = "Servicios";
                return;
            }

            if (Cod1 == "8.1" || Cod1 == "8.2")
            {
                SubTipo = "Público-Comercial";
                SubArea = "Servicios";
                return;
            }

            if (Cod1 == "9.1" || Cod1 == "9.2")
            {
                SubTipo = "Técnico - Mantenimiento";
                SubArea = "Servicios";
                return;
            }

            if (Cod1 == "10.1" || Cod1 == "10.2" || Cod1 == "10.3" || Cod1 == "10.4" || Cod1 == "10.5" || Cod1 == "10.6" || Cod1 == "10.7")
            {
                SubTipo = "Administrativo";
                SubArea = "Administrativo";
                return;
            }

            if (Cod1 == "11.1" || Cod1 == "11.2" || Cod1 == "11.3" || Cod1 == "11.4" || Cod1 == "11.5" || Cod1 == "11.6" || Cod1 == "11.7" || Cod1 == "11.8")
            {
                SubTipo = "Otras Areas Exteriores";
                SubArea = "Varios";
                return;
            }
        }

        static string ManejarRecreacion(string Cod1, ref string SubArea)
        {
            switch (Cod1)
            {
                case "2.4":
                    SubArea = "Público";
                    return "Gastronomía";
                case "9.2":
                    SubArea = "Servicios";
                    return "Técnico - Mantenimiento";
                case "11.1":
                    SubArea = "Varios";
                    return "Otras Areas Exteriores";
                case "11.6":
                    SubArea = "Varios";
                    return "Otras Areas Exteriores";
                case "11.7":
                    SubArea = "Varios";
                    return "Otras Areas Exteriores";
                case "11.8":
                    SubArea = "Varios";
                    return "Recreación en Exteriores";
                
            }

            var _codigo = Cod1.Split('.').First();
            switch (_codigo)
            {
                case "4":
                    return "Recreacion en Interiores";
                case "5":
                    return "Recreación en Exteriores";
                default:
                    return "";
            }
        }
    }
}