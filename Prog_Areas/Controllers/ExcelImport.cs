using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prog_Areas_Proyecto.Modelos;
using OfficeOpenXml;
using System.IO;
using DevExpress.XtraGrid.Views.Grid;
using System.Data;
using Prog_Areas_Plantilla.Modelos;
using Prog_Areas_Plantilla.Controllers;
using System.Drawing;
using OfficeOpenXml.Style;
using DevExpress.XtraGrid;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using Prog_Areas.ExtensionMethods;
using DevExpress.XtraEditors.Repository;
using System.Collections;
using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Windows.Forms;
using Prog_Areas.Formularios.Test;
using Prog_Areas_Proyecto.Controllers;

namespace Prog_Areas.Controllers
{
    public class ExcelImport
    {
        static readonly List<string> _edificios = new List<string>();
        static List<T_Local> _rooms;
        static readonly List<T_Grupo_Locales> _grupoLocales = new DB_PLANTILLA().GetAllRecords<T_Grupo_Locales>();
        static readonly List<T_Local> _keyRooms = new DB_PLANTILLA().GetAllRecords<T_Local>();
        private static List<Locales_Proyecto> _localesProyecto;
        private static Proyecto _proyecto;

        public static List<Local> GetAllLocalesFromExcel(ref GridView gridview, string filePath, Proyecto proyecto)
        {
            List<Local> _locales = new List<Local>();
            _proyecto = proyecto;
            _localesProyecto = new DB_BIM().GetElements<Locales_Proyecto>(x => x.Proyecto == _proyecto.Id);

            gridview.Columns.View.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseUp;

            gridview.RowCellStyle += Gridview_RowCellStyle;
            gridview.RowCellClick += Gridview_RowCellClick;
            gridview.CellValueChanged += Gridview_CellValueChanged;
            //gridview.CustomSummaryCalculate += Gridview_CustomSummaryCalculate;


            FileInfo _file = new FileInfo(filePath);
            int _index = 0;

            using (var _package = new ExcelPackage(_file))
            {
                var _worksheet = _package.Workbook.Worksheets.FirstOrDefault(x => x.Name == "Detalle");

                if (_worksheet != null)
                {
                    for (int i = 1; i < _worksheet.Dimension.Rows + 1; i++)
                    {
                        if (_worksheet.Cells[i, 1].Value == null) continue;
                        if (!_worksheet.Cells[i, 1].Value.ToString().Contains("PROGRAMA LOCAL DETALLADO")) continue;
                        _index = i;
                        break;
                    }

                    //ProcesarEdificios(_worksheet, _index);
                    FormatTable(ref gridview);
                    

                    var _edificio = "";
                    var _localTipo = "";

                    for (int i = _index; i < _worksheet.Dimension.Rows + _index; i++)
                    {
                        if (_worksheet.Cells[i, 1].Value != null)
                        {
                            if (_worksheet.Cells[i, 1].Value.ToString() == "x")
                            {
                                if (_worksheet.Cells[i, 4].Value != null && _worksheet.Cells[i, 4].Value.ToString() != "")
                                {
                                    var _valor = ProcesarCelda(_worksheet.Cells[i, 4]);
                                    if (_edificios.Any(e => e == _valor))
                                    {
                                        _edificio = _valor;
                                    }
                                    else
                                    {
                                        _localTipo = _valor;
                                    }
                                }
                            }
                            

                            if (_worksheet.Cells[i, 1].Value.ToString().Contains(',') || _worksheet.Cells[i, 1].Value.ToString().Contains('.'))
                            {
                                gridview.AddNewRow();

                                var _rowHandle = gridview.GetRowHandle(gridview.DataRowCount);

                                if (gridview.IsNewItemRow(_rowHandle))
                                {
                                    var _localKeyName = _worksheet.Cells[i, 5].Value.ToString().ProcesarCadena();

                                    if (_localKeyName == "Habitación" || _localKeyName == "Habitacion")
                                    {
                                        _localKeyName = "Dormitorio";
                                    }

                                    var _areaLocal = _worksheet.Cells[i, 10].Value == null ? "1" : _worksheet.Cells[i, 10].Value.ToString();
                                    var _porcientoBD = _worksheet.Cells[i, 11].Value == null ? "1" : _worksheet.Cells[i, 11].Value.ToString();

                                    if (float.Parse(_porcientoBD) > 1)
                                    {
                                        _porcientoBD = (float.Parse(_porcientoBD) / 100).ToString();
                                    }

                                    var _areaCalculo = _areaLocal == "" || _porcientoBD == "" ? 0 : double.Parse(_areaLocal) * double.Parse(_porcientoBD);

                                    var _cod1 = _worksheet.Cells[i, 1].Value.ToString().Replace(',', '.').Trim();
                                    var _grupoLocal = _grupoLocales.FirstOrDefault(x => x.Cod1.Contains(_cod1));
                                    //var _tipo = _localesTipo.Where(x => x.Grupo_Locales == _grupoLocal.Id).FirstOrDefault();
                                    _rooms = _keyRooms.Where(x => x.Grupo_Local == _grupoLocal.Id).ToList();

                                    //var _parentSelection = _rooms.Where(x => x.Local_Tipo == _tipo.Id);

                                    var _roomKeyId = 9999;

                                    if (_rooms.Count() == 1)
                                    {
                                        _roomKeyId = _rooms.First().RoomId;
                                    }

                                    gridview.SetRowCellValue(_rowHandle, "Desglose", _edificio);
                                    gridview.SetRowCellValue(_rowHandle, "LocalTipo", _localTipo);
                                    gridview.SetRowCellValue(_rowHandle, "Local", _localKeyName);
                                    gridview.SetRowCellValue(_rowHandle, "Cod1", _cod1);
                                    gridview.SetRowCellValue(_rowHandle, "Cod2", _worksheet.Cells[i, 2].Value.ToString());
                                    gridview.SetRowCellValue(_rowHandle, "Cod3", _worksheet.Cells[i, 3].Value.ToString());
                                    gridview.SetRowCellValue(_rowHandle, "AreaLocal", _areaLocal);
                                    gridview.SetRowCellValue(_rowHandle, "PorcientoBD", _porcientoBD);
                                    gridview.SetRowCellValue(_rowHandle, "AreaCalculo", _areaCalculo);

                                    var este = _localesProyecto.FirstOrDefault(x => x.Local1.Desglose1.Value == _edificio &&
                                                                             x.Local1.LocalTipo.Value == _localTipo &&
                                                                             x.Local1.Key_Name == _localKeyName);
                                    if (este != null)
                                    {
                                        _roomKeyId = este.Local1.RoomId;
                                    }


                                    gridview.SetRowCellValue(_rowHandle, "RoomID", _roomKeyId);

                                }
                                
                            }
                        }
                    }
                }
            }

            
            return _locales;
        }
        private static void Gridview_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            GridView _view = sender as GridView;
            
            switch (((GridSummaryItem)e.Item).FieldName)
            {
                case "Hab":
                    switch (e.SummaryProcess)
                    {
                        case CustomSummaryProcess.Start:
                            break;
                        case CustomSummaryProcess.Calculate:
                            e.TotalValue = Convert.ToInt32(e.TotalValue) + Convert.ToInt32(e.FieldValue);
                            break;
                        case CustomSummaryProcess.Finalize:
                            break;
                    }
                    break;

                case "AreaLocal":
                    switch (e.SummaryProcess)
                    {
                        case CustomSummaryProcess.Start:
                            break;
                        case CustomSummaryProcess.Calculate:
                            e.TotalValue = Convert.ToDecimal(e.TotalValue) + Convert.ToDecimal(e.FieldValue);
                            break;
                        case CustomSummaryProcess.Finalize:
                            break;
                    }
                    break;
            }
            
        }

        private static void Gridview_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView _view = sender as GridView;

            if (e.Column.FieldName == "AreaLocal")
            {
                var _areaLocal = _view.GetRowCellValue(e.RowHandle, "AreaLocal").ToString() == "" ? 0.00 : double.Parse(_view.GetRowCellValue(e.RowHandle, "AreaLocal").ToString());
                var _porcientoBD = _view.GetRowCellValue(e.RowHandle, "PorcientoBD").ToString() == "" ? 1 : double.Parse(_view.GetRowCellValue(e.RowHandle, "PorcientoBD").ToString());

                _view.SetRowCellValue(e.RowHandle, "AreaCalculo", _areaLocal * _porcientoBD);
            }

            if (e.Column.FieldName == "PorcientoBD")
            {
                var _areaLocal = _view.GetRowCellValue(e.RowHandle, "AreaLocal").ToString() == "" ? 0.00 : double.Parse(_view.GetRowCellValue(e.RowHandle, "AreaLocal").ToString());
                var _porcientoBD = _view.GetRowCellValue(e.RowHandle, "PorcientoBD").ToString() == "" ? 1 : double.Parse(_view.GetRowCellValue(e.RowHandle, "PorcientoBD").ToString());

                var _Hab = _view.GetRowCellValue(e.RowHandle, "Hab").ToString() == "" || _view.GetRowCellValue(e.RowHandle, "Hab").ToString() == "0" ? 1 : int.Parse(_view.GetRowCellValue(e.RowHandle, "Hab").ToString());

                _view.SetRowCellValue(e.RowHandle, "AreaCalculo", _areaLocal * _porcientoBD);

                var _cod3 = _view.GetRowCellValue(e.RowHandle, "PorcientoBD").ToString().CalcularCod3();
                _view.SetRowCellValue(e.RowHandle, "Cod3", _cod3);
            }

            if (e.Column.FieldName == "RoomID")
            {
                if (e.Value.ToString() != "9999")
                {
                    int n = 0;
                    T_Local _room = null;
                    if (int.TryParse(e.Value.ToString(), out n))
                    {
                        var _roomID = int.Parse(_view.GetRowCellValue(e.RowHandle, "RoomID").ToString());
                        _room = _keyRooms.FirstOrDefault(x => x.RoomId == _roomID);
                        _view.SetRowCellValue(e.RowHandle, "RoomID", _room.Key_Name);
                    }
                    else
                    {
                        var _roomName = _view.GetRowCellValue(e.RowHandle, "RoomID").ToString();
                        _room = _keyRooms.FirstOrDefault(x => x.Key_Name == _roomName);

                        AddSingleRoom(ref _view, e.RowHandle, _room);

                    }

                    var _hab = _room.Habitacion.GetValueOrDefault() ? 1 : 0;
                    _view.SetRowCellValue(e.RowHandle, "Hab", _hab.ToString());
                    _view.SetRowCellValue(e.RowHandle, "Cod2", _room.CalcularCod2());
                }
            }
        }

        

        private static void Gridview_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (e.Column.FieldName == "RoomID")
            {
                GridView _view = sender as GridView;

                var _cod1 = _view.GetRowCellValue(e.RowHandle, "Cod1").ToString().Replace(',', '.');

                List<T_Local> _rooms = new List<T_Local>();

                var _grupoLocal = _grupoLocales.Where(x => x.Cod1.Contains(_cod1));
                foreach (var grupo in _grupoLocal)
                {
                    _rooms.AddRange(_keyRooms.Where(x => x.Grupo_Local == grupo.Id));

                    //var _tipoLocal = _localesTipo.Where(x => x.Grupo_Locales == grupo.Id);
                    //foreach (var tipo in _tipoLocal)
                    //{
                    //    _rooms.AddRange(_keyRooms.Where(x => x.Local_Tipo == tipo.Id));
                    //}
                }
                
                

                RepositoryItemComboBox _repo = new RepositoryItemComboBox();
                foreach (var item in _rooms)
                {
                    _repo.Items.Add(item.Key_Name);
                }

                _view.Columns["RoomID"].ColumnEdit = _repo;
            }
        }

        private static void Gridview_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView _view = sender as GridView;

            if (e.CellValue.ToString() == "9999" && e.Column.FieldName == "RoomID")
            {
                e.Appearance.BackColor = Color.Red;
            }
        }

        static string ProcesarCelda(ExcelRangeBase celda)
        {
            if (!celda.Value.ToString().ToLower().Contains("total") && !celda.Value.ToString().ToLower().Contains("tipos"))
            {
                var _cellValue = celda.Value.ToString().Split('(').First();

                if (_cellValue.Trim().Replace(" ", string.Empty).All(char.IsUpper))
                {
                    _edificios.Add(_cellValue);
                    return _cellValue;
                }
                else
                {
                    return _cellValue;
                }
            }

            return string.Empty;
        }

        public static void FormatTable(ref GridView gridview)
        {
            gridview.GridControl.DataSource = MakeColumns();

            gridview.OptionsView.GroupFooterShowMode = GroupFooterShowMode.VisibleAlways;

            GridGroupSummaryItem _summaryAreaLocal = new GridGroupSummaryItem();
            _summaryAreaLocal.FieldName = "AreaLocal";
            //_summaryAreaLocal.SummaryType = SummaryItemType.Custom;
            _summaryAreaLocal.SummaryType = SummaryItemType.Sum;
            _summaryAreaLocal.DisplayFormat = "Total: {0:0.00}";
            _summaryAreaLocal.ShowInGroupColumnFooter = gridview.Columns["AreaLocal"];
            gridview.GroupSummary.Add(_summaryAreaLocal);

            GridGroupSummaryItem _summaryAreaCalculo = new GridGroupSummaryItem();
            _summaryAreaCalculo.FieldName = "AreaCalculo";
            _summaryAreaCalculo.SummaryType =  SummaryItemType.Sum;
            _summaryAreaCalculo.DisplayFormat = "Total: {0:0.00}";
            _summaryAreaCalculo.ShowInGroupColumnFooter = gridview.Columns["AreaCalculo"];
            gridview.GroupSummary.Add(_summaryAreaCalculo);

            GridGroupSummaryItem _summaryHab = new GridGroupSummaryItem();
            _summaryHab.FieldName = "Hab";
            _summaryHab.SummaryType = SummaryItemType.Sum;
            //_summaryHab.SummaryType = SummaryItemType.Custom;
            _summaryHab.DisplayFormat = "Total: {0}";
            _summaryHab.ShowInGroupColumnFooter = gridview.Columns["Hab"];
            gridview.GroupSummary.Add(_summaryHab);


            

            gridview.Columns["AreaLocal"].FieldName = "AreaLocal";
            gridview.Columns["AreaLocal"].UnboundType = UnboundColumnType.Decimal;

            RepositoryItemComboBox _repository = new RepositoryItemComboBox();
            var _allPorcientos = new DB_PLANTILLA().GetAllRecords<T_Porciento_BD>();

            foreach (var item in _allPorcientos)
            {
                _repository.Items.Add(item.Value);
            }

            gridview.Columns["PorcientoBD"].ColumnEdit = _repository;

            //gridview.Columns["PorcientoBD"].FieldName = "PorcientoBD";
            //gridview.Columns["PorcientoBD"].UnboundType = UnboundColumnType.Decimal;
            //gridview.Columns["RoomID"].Visible = false;

            gridview.Columns["AreaCalculo"].OptionsColumn.AllowEdit = false;
            gridview.Columns["Cod2"].OptionsColumn.AllowEdit = false;
            gridview.Columns["Cod3"].OptionsColumn.AllowEdit = false;


            gridview.Columns["Desglose"].GroupIndex = 1;
            gridview.Columns["LocalTipo"].GroupIndex = 2;

            gridview.GroupLevelStyle += (s, e) => {
                if (e.Level == 0)
                {
                    e.LevelAppearance.ForeColor = Color.WhiteSmoke;
                    e.LevelAppearance.BackColor = Color.Gray;
                }
                if (e.Level == 1)
                {
                    e.LevelAppearance.ForeColor = Color.Black;
                    e.LevelAppearance.BackColor = Color.LightGray;
                }
            };
        }

        static DataTable MakeColumns()
        {
            DataTable _table = new DataTable();

            _table.Columns.Add("Desglose");
            _table.Columns.Add("LocalTipo");
            _table.Columns.Add("Local");
            _table.Columns.Add("Cod1");
            _table.Columns.Add("Cod2");
            _table.Columns.Add("Cod3");
            _table.Columns.Add("Hab");
            //_table.Columns.Add("SubsistemaTipo");
            //_table.Columns.Add("SubsistemaArea");
            _table.Columns.Add("AreaLocal");
            _table.Columns.Add("PorcientoBD");
            _table.Columns.Add("AreaCalculo");
            _table.Columns.Add("RoomID");
            
            return _table;
        }


        private static void AddSingleRoom(ref GridView selectedGrid, int i, T_Local KeyRoom)
        {
            if (i != -2147483647)
            {
                try
                {

                    using (var db = new DB_BIM())
                    {
                        selectedGrid.FocusedRowHandle = i;

                        Local local = new Local();
                        Locales_Proyecto localProyecto = new Locales_Proyecto();

                        var subsistemaTipo = "";
                        var subsistemaArea = "";

                        ExcelImportForm.GetSubsistemas(selectedGrid.GetRowCellValue(i, "Cod2").ToString(), ref subsistemaTipo, ref subsistemaArea, selectedGrid.GetRowCellValue(i, "Cod1").ToString());

                        local.SubsistemaTipo =
                            new DB_PLANTILLA().GetSingleRecord<T_Subsistema_Tipo>(x => x.Value == subsistemaTipo).Id;

                        local.SubsistemaArea =
                            new DB_PLANTILLA().GetSingleRecord<T_Subsistema_Area>(x => x.Value == subsistemaArea).Id;

                        var localTipoValue = selectedGrid.GetRowCellValue(i, "LocalTipo").ToString();




                        var cod1 = selectedGrid.GetRowCellValue(i, "Cod1").ToString().Replace(',', '.');
                        var grupoLocal = _grupoLocales.FirstOrDefault(x => x.Cod1.Contains(cod1)).Id;

                        var localTipo = db.GetSingleElement<LocalTipo>(x => x.Value == localTipoValue) ?? new LocalTipo()
                        {
                            Grupo_Locales = grupoLocal,
                            Value = localTipoValue
                        };


                        var porcientoBD = double.Parse(selectedGrid.GetRowCellValue(i, "PorcientoBD").ToString());
                        local.Porciento_BD = new DB_PLANTILLA().GetSingleElement<T_Porciento_BD>(x => x.Value == porcientoBD).Id;

                        var areaUtil = selectedGrid.GetRowCellValue(i, "AreaLocal").ToString() == "" ? 0.00 : double.Parse(selectedGrid.GetRowCellValue(i, "AreaLocal").ToString());
                        CoefArea coef = new CoefArea()
                        {
                            Area_Local = areaUtil
                        };


                        var desgloseValue = selectedGrid.GetRowCellValue(i, "Desglose").ToString();
                        var desglose = db.GetSingleElement<Desglose>(x => x.Value == desgloseValue && x.Proyecto == _proyecto.Id);

                        if (desglose != null)
                        {
                            local.Desglose = desglose.Id;
                        }
                        else
                        {
                            Desglose _newDesglose = new Desglose()
                            {
                                Value = desgloseValue,
                                Proyecto = _proyecto.Id
                            };
                            desglose = _newDesglose;
                            local.Desglose1 = _newDesglose;
                        }

                        //var roomKeyValue = selectedGrid.GetRowCellValue(i, "RoomID").ToString();
                        //var localID = new DB_PLANTILLA().GetSingleElement<T_Local>(x => x.Key_Name == roomKeyValue);
                        var localID = KeyRoom;
                        local.RoomId = localID.RoomId;
                        local.CoefArea = coef;
                        local.CoefArea.Value = new DB_PLANTILLA().GetSingleElement<T_CoefArea>(x => x.Id == localID.Coef_Area).Value;
                        local.LocalTipo = localTipo;

                        local.Key_Name = selectedGrid.GetRowCellValue(i, "Local").ToString();

                        local.Ambiente1 = localID.T_Ambiente.ToProject();
                        local.Comunicaciones_Tv1 = localID.T_Comunicaciones_Tv.ToProject();
                        local.Climatizacion1 = localID.T_Climatizacion.ToProject();

                        localProyecto.Local1 = local;
                        localProyecto.Proyecto = _proyecto.Id;
                        localProyecto.Cantidad = selectedGrid.GetRowCellValue(i, "Hab") == null || selectedGrid.GetRowCellValue(i, "Hab").ToString() == "" ? 0 : int.Parse(selectedGrid.GetRowCellValue(i, "Hab").ToString());

                        var localesProyecto =
                            db.GetSingleElement<Locales_Proyecto>(x =>
                                x.Proyecto1.Cod == _proyecto.Cod &&
                                x.Local1.Desglose == desglose.Id &&
                                x.Local1.Local_Tipo == localTipo.Id &&
                                x.Local1.Key_Name == local.Key_Name);

                        if (localesProyecto == null)
                        {
                            //new DB_BIM().AddElemento<Locales_Proyecto>(typeof(Locales_Proyecto), localProyecto);
                            //LocalController.AddLocalcesProyecto(localProyecto);
                            //LocalController.AddLocalesProyecto(localProyecto);
                            db.Locales_Proyecto.Add(localProyecto);
                            db.SaveChanges();
                        }
                        else
                        {
                            localProyecto.Id = localesProyecto.Id;
                            LocalController.UpdateLocalesProyecto(localProyecto);
                        } 
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //Excepciones.Excepciones.EnviarCorreo(ex);
                    //throw;
                } 
            }
        }
    }
}
