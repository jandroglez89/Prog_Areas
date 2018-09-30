using System;
using System.Collections.Generic;
using System.Linq;
using Prog_Areas_Proyecto.Controllers;
using System.Windows.Forms;
using Prog_Areas_Proyecto.Modelos;
using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Menu;
using Prog_Areas.Formularios.Test;
using System.Data;
using Prog_Areas_Plantilla.Controllers;
using Prog_Areas_Plantilla.Modelos;
using System.Threading;
using Prog_Areas.ExtensionMethods;
using DevExpress.Utils;
using OfficeOpenXml;
using System.IO;
using OfficeOpenXml.Style;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using Prog_Areas.Controllers;
using System.Drawing;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid;
using DevExpress.Data;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraSplashScreen;

namespace Prog_Areas.Formularios
{
    public partial class ProjectManagementForm : DevExpress.XtraEditors.XtraForm
    {
        public static ProjectManagementForm _projectManagementForm;
        Proyecto _proyecto;
        List<Locales_Proyecto> _localesByProject;
        
        public ProjectManagementForm(Proyecto proyecto)
        {
            InitializeComponent();
            //gridControl1.ForceInitialize();

            _proyecto = new DB_BIM().GetSingleElement<Proyecto>(x => x.Id == proyecto.Id);
            this.Text = string.Format("{0} - {1}", _proyecto.Cod, _proyecto.Nombre);

            backgroundWorker1.WorkerReportsProgress = true;

            txt_nombre.Text = _proyecto.Nombre;
            txt_codigo.Text = _proyecto.Cod;
            txt_Localizacion.Text = _proyecto.Localizacion;
            txt_tipoAlojamiento.Text = _proyecto.Tipo_Alojamiento;
            txt_subtipoAlojamiento.Text = _proyecto.Subtipo_Alojamiento;
            txt_TipoHotel.Text = _proyecto.Tipo_Hotel;
            numeric_cantHabitaciones.Value = Convert.ToDecimal(_proyecto.Cant_Habitaciones);
            numeric_Categoria.Value = Convert.ToDecimal(_proyecto.Categoria);
            numeric_MaximaAltura.Value = Convert.ToDecimal(_proyecto.Maxima_Altura);

            _projectManagementForm = this;

            var _locales = new DB_PLANTILLA().GetAllRecords<T_Local>();

            foreach (var item in _locales)
            {
                cmb_LocalTipo.Items.Add(item.Key_Name);
            }

            //var _desgloses = new DB_BIM().GetElements<Desglose>(x => x.Proyecto == _proyecto.Id);
            var _desgloses = new DB_BIM().GetElements<Desglose>(x => x.Proyecto == _proyecto.Id).GroupBy(x => x.Value).Select(x => x.FirstOrDefault()).OrderBy(x => x.Value).ToList(); ;
            cmb_Desglose.Items.Clear();

            foreach (var item in _desgloses)
            {
                cmb_Desglose.Items.Add(item.Value);
            }
        }

        DataTable Porcientos()
        {
            var _porcientos = new DB_PLANTILLA().GetAllRecords<T_Porciento_BD>();

            DataTable _a = new DataTable();

            foreach (var item in _porcientos)
            {
                _a.Columns.Add(item.Value.GetValueOrDefault().ToString());
            }

            return _a;
        }

        void GenerateTable()
        {
            SplashScreenManager.ShowForm(typeof(WaitScreen));
            if (gridControl1.DataSource != null)
            {
                gridControl1.DataSource = null;
            }

            gridControl1.DataSource = CreateColumns();
            gridView1.Columns["SubsistemaTipo"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["SubsistemaArea"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["LocalTipo"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["Cod1"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["Cod1"].Width = 45;
            gridView1.Columns["Cod2"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["Cod2"].Width = 40;
            gridView1.Columns["Cod3"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["Cod3"].Width = 40;
            gridView1.Columns["Local"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["Local"].Width = 200;
            //gridView1.Columns["Hab"].OptionsColumn.AllowEdit = false;
            //gridView1.Columns["Coef/Area"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["Coef/Num.Habitaciones"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["Área Útil [m²]"].OptionsColumn.AllowEdit = false;
            //gridView1.Columns["Promedio de % Base Diseño"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["Áreas De Cálculo [m²]"].OptionsColumn.AllowEdit = false;

            RepositoryItemComboBox _repository = new RepositoryItemComboBox();

            var _allPorcientos = new DB_PLANTILLA().GetAllRecords<T_Porciento_BD>();

            foreach (var item in _allPorcientos)
            {
                _repository.Items.Add(item.Value);
            }

            gridView1.Columns["Promedio de % Base Diseño"].ColumnEdit = _repository;
            gridView1.Columns["RoomID"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["RoomID"].Visible = false;
            gridView1.Columns["ID"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["ID"].Visible = false;

            gridView1.Columns["Obj. Obra"].GroupIndex = 1;
            gridView1.Columns["LocalTipo"].GroupIndex = 2;

            gridView1.GroupLevelStyle += (s, e) => {
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

            GridGroupSummaryItem _summaryAreaLocal = new GridGroupSummaryItem
            {
                FieldName = "Área Útil [m²]",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "Total: {0:0.00}",
                ShowInGroupColumnFooter = gridView1.Columns["Área Útil [m²]"]
            };
            gridView1.GroupSummary.Add(_summaryAreaLocal);

            GridGroupSummaryItem _summaryAreaCalculo = new GridGroupSummaryItem
            {
                FieldName = "Áreas De Cálculo [m²]",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "Total: {0:0.00}",
                ShowInGroupColumnFooter = gridView1.Columns["Áreas De Cálculo [m²]"]
            };
            gridView1.GroupSummary.Add(_summaryAreaCalculo);

            GridGroupSummaryItem _summaryHabitaciones = new GridGroupSummaryItem
            {
                FieldName = "Hab",
                SummaryType = SummaryItemType.Sum,
                DisplayFormat = "Total: {0}",
                ShowInGroupColumnFooter = gridView1.Columns["Hab"]
            };
            gridView1.GroupSummary.Add(_summaryHabitaciones);

            _localesByProject = new DB_BIM().GetElements<Locales_Proyecto>(x => x.Proyecto == _proyecto.Id);
            foreach (var item in _localesByProject)
            {
                AddGridViewRow(item);
            }
            SplashScreenManager.CloseForm();
        }

        DataTable CreateColumns()
        {
            DataTable _newDatable = new DataTable();

            _newDatable.Columns.Add("Obj. Obra");
            _newDatable.Columns.Add("SubsistemaTipo"); 
            _newDatable.Columns.Add("SubsistemaArea");
            _newDatable.Columns.Add("Cod1");
            _newDatable.Columns.Add("Cod2");
            _newDatable.Columns.Add("Cod3");
            _newDatable.Columns.Add("LocalTipo");
            _newDatable.Columns.Add("Local");
            _newDatable.Columns.Add("Hab");
            _newDatable.Columns.Add("Cantidad");
            _newDatable.Columns.Add("Coef/Area");
            _newDatable.Columns.Add("Coef/Num.Habitaciones");
            _newDatable.Columns.Add("Área Útil [m²]");
            _newDatable.Columns.Add("Promedio de % Base Diseño");
            _newDatable.Columns.Add("Áreas De Cálculo [m²]");
            _newDatable.Columns.Add("RoomID");
            _newDatable.Columns.Add("ID");
          
            return _newDatable;
        }

        void AddGridViewRow(Locales_Proyecto localProyecto)
        {
            var _local = localProyecto.GetLocal();
            var _proyecto = localProyecto.GetProyecto();
            var _subsistemasTipo = new DB_PLANTILLA().GetAllRecords<T_Subsistema_Tipo>();
            var _subsistemasArea = new DB_PLANTILLA().GetAllRecords<T_Subsistema_Area>();
            var _localesTipo = new DB_BIM().GetAllElements<LocalTipo>();
            var _grupoLocales = new DB_PLANTILLA().GetAllRecords<T_Grupo_Locales>();
            var _cod1 = _grupoLocales.FirstOrDefault(x => x.Id == _localesTipo.FirstOrDefault(y => y.Id == _local.Local_Tipo).Grupo_Locales).Cod1;
            var _porcientos = new DB_PLANTILLA().GetAllRecords<T_Porciento_BD>();
            var _coeficientes = new DB_BIM().GetAllElements<CoefArea>();
            var _desgloses = new DB_BIM().GetElements<Desglose>(x => x.Proyecto == _proyecto.Id);

            gridView1.AddNewRow();
            var _rowHandle = gridView1.GetRowHandle(gridView1.DataRowCount);

            if (gridView1.IsNewItemRow(_rowHandle))
            {
                var _coef = _coeficientes.FirstOrDefault(x => x.Id == _local.Coef_Area);

                if (_coef.Value == null)
                {
                    _coef.Value = "0";
                }



                //var _coefValue = float.Parse(_coef.Value);

                var _coefCalc = AddNewRoom(_local.RoomId);

                var _coefValue = 0f;

                _coefValue = float.Parse(_coefCalc.Area_Programa?.ToString() ?? _coef.Value);

                //var _coefValue = float.Parse(_coef.Value);

                //var _coefValue = _local.CoefArea == null ? float.Parse(_coef.Value) : float.Parse(_local.CoefArea.Value);

                //var _coefValue = _coef.Value == null ? 0.0 : float.Parse(_coef.Value);
                var _coefNumHab = _local.GetCoefNumHab(_proyecto.Cant_Habitaciones.GetValueOrDefault());
                var _porciento = _porcientos.FirstOrDefault(x => x.Id == _local.Porciento_BD).Value;
                var _areaPrograma = (_coefValue * _coefNumHab);
                var _areaCalculo = (_areaPrograma * _porciento).GetValueOrDefault().ToString("#.##");

                gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["Obj. Obra"], _desgloses.FirstOrDefault(x => x.Id == _local.Desglose).Value);
                gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["RoomID"], _local.RoomId);
                gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["ID"], _local.Id);
                gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["Local"], _local.Key_Name);
                gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["SubsistemaTipo"], _subsistemasTipo.FirstOrDefault(x => x.Id == _local.SubsistemaTipo).Value);
                gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["SubsistemaArea"], _subsistemasArea.FirstOrDefault(x => x.Id == _local.SubsistemaArea).Value);
                gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["LocalTipo"], _localesTipo.FirstOrDefault(x => x.Id == _local.Local_Tipo).Value);
                gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["Cod1"], _cod1);
                gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["Cod2"], _local.CalcularCod2());
                gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["Cod3"], _local.CalcularCod3());
                gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["Hab"], localProyecto.Local1.Habitacion.GetValueOrDefault() ? "1" : "0");
                gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["Cantidad"], localProyecto.Cantidad);
                gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["Coef/Area"], _coef.Area_Programa);
                gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["Coef/Num.Habitaciones"], _coefNumHab);
                gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["Área Útil [m²]"], _coef.Area_Local);
                gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["Promedio de % Base Diseño"], _porciento);
                gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["Áreas De Cálculo [m²]"], _areaCalculo);

            }

            gridView1.Focus();
        }

        public void UpdateGridControl()
        {
            //FillData();
        }

        private void btn_updateProject_Click(object sender, EventArgs e)
        {
            _proyecto.Cod = txt_codigo.Text;
            _proyecto.Nombre = txt_nombre.Text;
            _proyecto.Localizacion = txt_Localizacion.Text;
            _proyecto.Tipo_Alojamiento = txt_tipoAlojamiento.Text;
            _proyecto.Subtipo_Alojamiento = txt_subtipoAlojamiento.Text;
            _proyecto.Tipo_Hotel = txt_TipoHotel.Text;
            _proyecto.Cant_Habitaciones = Convert.ToInt32(numeric_cantHabitaciones.Value);
            _proyecto.Categoria = Convert.ToInt32(numeric_Categoria.Value);
            _proyecto.Maxima_Altura = Convert.ToInt32(numeric_MaximaAltura.Value);

            ProyectoController.UpdateProyecto(_proyecto);

            GenerateTable();
        }

        private void btn_importarExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                gridView1.DeleteRow(i);
            }

            Form _excelForm = new ExcelImportForm(_proyecto);
            _excelForm.ShowDialog();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }
        

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            var _percent = progressBar1.Maximum / 100;
            progressBar1.Value += progressBar1.Value >= 150 ? 0 : _percent;
            gridView1.AddNewRow();
        }

        private void ProjectManagementForm_Load(object sender, EventArgs e)
        {
            GenerateTable();
            gridView1.CellValueChanged += gridView1_CellValueChanged;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            //for (int i = 0; i < gridView1.DataRowCount; i++)
            //{
            //    if (gridView1.GetRowCellValue(i, "SubsistemaTipo").ToString() == "")
            //    {
            //        gridView1.DeleteRow(i);
            //        i--;
            //    }
            //}

            MessageBox.Show("Completado!" + gridView1.DataRowCount);
        }

        private void cmb_LocalTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_nombreLocal.Text = cmb_LocalTipo.Text;
        }

        private void bnt_add_Click(object sender, EventArgs e)
        {
            if (cmb_LocalTipo.Text != "" && txt_nombreLocal.Text != "")
            {
                try
                {
                    using (var db = new DB_BIM())
                    {
                        var _localKeyName = cmb_LocalTipo.Text;
                        var _local = new DB_PLANTILLA().GetSingleRecord<T_Local>(x => x.Key_Name == _localKeyName).ToProject();

                        _local.Key_Name = txt_nombreLocal.Text;
                        var _climatizacionID = _local.Climatizacion;
                        var _climatizacion = new DB_PLANTILLA().GetSingleRecord<T_Climatizacion>(x => x.Id == _climatizacionID).ToProject();
                        _local.Climatizacion1 = _climatizacion;

                        var _ambienteID = _local.Ambiente;
                        var _ambiente = new DB_PLANTILLA().GetSingleRecord<T_Ambiente>(x => x.Id == _ambienteID).ToProject();
                        _local.Ambiente1 = _ambiente;

                        var _comunicacionesID = _local.Comunicaciones_TV;
                        var _comunicaciones = new DB_PLANTILLA().GetSingleRecord<T_Comunicaciones_Tv>(x => x.Id == _comunicacionesID).ToProject();
                        _local.Comunicaciones_Tv1 = _comunicaciones;


                        //Esto viene de la BD, aun asi se sobrescribe con el valor del excel, considerar como codigo sobrante.
                        var _coef = new DB_PLANTILLA().GetSingleRecord<T_CoefArea>(x => x.Id == _local.Coef_Area).ToProject();
                        _local.CoefArea = _coef;

                        var _localTipo = new DB_PLANTILLA().GetSingleRecord<T_LocalTipo>(x => x.Id == _local.Local_Tipo).ToProject();
                        _local.LocalTipo = _localTipo;
                        
                        var _desgloseName = cmb_Desglose.Text;
                        var _desglose = db.GetSingleElement<Desglose>(x => x.Value == _desgloseName && x.Proyecto == _proyecto.Id);
                        _local.Desglose = _desglose.Id;

                        var coef = AddNewRoom(_local.RoomId);

                        if (coef != null)
                        {
                            _local.CoefArea.Area_Programa = coef.Area_Programa;
                        }

                        Locales_Proyecto _localProyecto = new Locales_Proyecto()
                        {
                            Proyecto = _proyecto.Id,
                            Local1 = _local,
                            Cantidad = int.Parse(numeric_cantidad.Value.ToString())
                        };
                        
                        _localProyecto = db.AddElemento<Locales_Proyecto>(typeof(Locales_Proyecto), _localProyecto);
                        AddGridViewRow(_localProyecto); 
                    }
                }
                catch (Exception ex)
                {
                    //Excepciones.Excepciones.EnviarCorreo(ex);
                    throw;
                } 
            }
            else
            {
                MessageBox.Show("Existen campos sin completar");
            }
        }

        public CoefArea AddNewRoom(int localId)
        {
            string excelfile = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "*.xls").FirstOrDefault(x => x.Contains(_proyecto.Cod + "_ProgramaHoteleroCoeficientes"));

            if (excelfile != null)
            {
                FileInfo file = new FileInfo(excelfile);
                using (ExcelPackage _package = new ExcelPackage(file))
                {
                    var DatosGeneralesPage = _package.Workbook.Worksheets.FirstOrDefault(x => x.Name == "Datos Generales");

                    if (int.Parse(DatosGeneralesPage.Cells[8, 3].Value.ToString()) != _proyecto.Cant_Habitaciones)
                    {
                        DialogResult dialog = MessageBox.Show("La cantidad de habitaciones del proyecto no coincide con las del excel.\n¿Desea actualizar el proyecto?", "", MessageBoxButtons.YesNo);

                        if (dialog == DialogResult.Yes)
                        {
                            _proyecto.Cant_Habitaciones = int.Parse(DatosGeneralesPage.Cells[8, 3].Value.ToString());
                            numeric_cantHabitaciones.Value = int.Parse(DatosGeneralesPage.Cells[8, 3].Value.ToString());
                            numeric_cantHabitaciones.Update();
                            btn_updateProject.PerformClick();
                        }
                    }

                    foreach (var cell in _package.Workbook.Worksheets.Select(sheet => sheet.Cells["A2:A"]).SelectMany(firstColumn => firstColumn.Where(cell => cell.Value != null && cell.Value.ToString() == localId.ToString())))
                    {
                        var rowValue = cell.Start.Row;
                        var columnValue = cell.Worksheet.Dimension.End.Column;

                        while (cell.Worksheet.Cells[rowValue, columnValue].Value == null)
                        {
                            columnValue--;
                        }

                        var coefAreaValue = cell.Worksheet.Cells[rowValue, columnValue].Value.ToString();

                        var coefArea = new CoefArea()
                        {
                            Area_Programa = double.Parse(coefAreaValue)
                        };

                        return coefArea;
                    }
                }
            }

            return new CoefArea();

        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "Coef/Area")
            {
                var _localID = int.Parse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["ID"]).ToString());
                var _local = new DB_BIM().GetSingleElement<Local>(x => x.Id == _localID);
                var _porcientoBD = new DB_PLANTILLA().GetSingleRecord<T_Porciento_BD>(x => x.Id == _local.Porciento_BD).Value;
                var _coef = float.Parse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Coef/Area"]).ToString());

                var _coefNumHab = (_coef < 2 && !_local.Key_Name.Contains("Closet")) ? _proyecto.Cant_Habitaciones : 1;
                    
                gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["Coef/Num.Habitaciones"], _coefNumHab);

                gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["Área Útil [m²]"], (_coef * _coefNumHab).ToString());

                var _area = gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Área Útil [m²]"]).ToString() == "" ? "1" : gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Área Útil [m²]"]).ToString();
                var _areaUtil = float.Parse(_area);
                var _porciento = float.Parse(_porcientoBD.ToString());

                var _AreaPrograma = (_areaUtil * _porciento).ToString("#.##");

                gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["Promedio de % Base Diseño"], _porciento);

                var _coefEntity = new DB_BIM().GetSingleElement<CoefArea>(x => x.Id == _local.Coef_Area);
                _coefEntity.Value = _coef.ToString();
                _coefEntity.Area_Local = _areaUtil;
                _coefEntity.Area_Programa = _AreaPrograma == "" ? double.Parse("0") : double.Parse(_AreaPrograma);
                
                ProyectoController.UpdateCoefArea(_coefEntity);

                gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["Áreas De Cálculo [m²]"], _AreaPrograma);
                gridView1.UpdateCurrentRow();
                gridView1.RefreshRow(e.RowHandle);
            }

            if (e.Column.FieldName == "Promedio de % Base Diseño" && gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Áreas De Cálculo [m²]"]) != null)
            {
                var _localID = int.Parse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["ID"]).ToString());
                var _local = new DB_BIM().GetSingleElement<Local>(x => x.Id == _localID);
                var _porcientoValue = float.Parse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Promedio de % Base Diseño"]).ToString());
                var _areaUtil = float.Parse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["Área Útil [m²]"]).ToString());
                var _areaPrograma = (_areaUtil * _porcientoValue);
                gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["Áreas De Cálculo [m²]"], _areaPrograma);
                gridView1.UpdateCurrentRow();
                gridView1.RefreshRow(e.RowHandle);

                var _coefEntity = new DB_BIM().GetSingleElement<CoefArea>(x => x.Id == _local.Coef_Area);
                _coefEntity.Area_Programa = double.Parse(_areaPrograma.ToString());

                var _porcientoEntity = new DB_PLANTILLA().GetSingleRecord<T_Porciento_BD>(x => x.Value == _porcientoValue);
                _local.Porciento_BD = _porcientoEntity.Id;

                ProyectoController.UpdateCoefArea(_coefEntity);
                LocalController.UpdatePorcientoBD(_local);
            }

            if (e.Column.FieldName == "Hab")
            {
                var _localID = int.Parse(gridView1.GetRowCellValue(e.RowHandle, gridView1.Columns["ID"]).ToString());
                var _localProyecto = new DB_BIM().GetSingleElement<Locales_Proyecto>(x => x.Local == _localID && x.Proyecto == _proyecto.Id);
                _localProyecto.Cantidad = int.Parse(gridView1.GetRowCellValue(e.RowHandle, "Hab").ToString());
                LocalController.UpdateLocalesProyecto(_localProyecto);
            }

        }

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {
            
        }

        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {

            /*//MessageBox.Show(Directory.GetFiles(@"\\10.72.221.18\02-PROYECTOS\").ToString());
            var _path = @"Z:\02-PROYECTOS";
            var _folders = Directory.GetDirectories(_path, "*", SearchOption.TopDirectoryOnly);

            var _this = "";
            foreach (var item in _folders)
            {
                var _depth1 = Directory.GetDirectories(Path.Combine(_path, item), "*", SearchOption.TopDirectoryOnly);
                foreach (var item2 in _depth1)
                {
                    if (item2.Contains("P70"))
                        _this += item2 + "\n";
                }
            }

            MessageBox.Show(_this);*/

            SaveFileDialog _dialog = new SaveFileDialog();
            _dialog.RestoreDirectory = true;
            _dialog.InitialDirectory = @"Z:\02-PROYECTOS";
            _dialog.Filter = "Excel File|*.xls";
            _dialog.FileName = _proyecto.Cod + "_" + "BaseDatos.xlsx";
            _dialog.Title = @"Guardar en: ...\01 Doc graficos\01 BIM\20_Recursos\02_Datos\";
            DialogResult _result = _dialog.ShowDialog();

            if (_result == DialogResult.OK)
            {
                //var _filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/" + _proyecto.Cod + "_" + "BaseDatos.xlsx";
                var _filepath = _dialog.FileName;
                var _file = new FileInfo(_filepath);

                using (var _excelPackage = new ExcelPackage(_file))
                {
                    if (_excelPackage.Workbook.Worksheets.FirstOrDefault(x => x.Name == "BaseDatos") != null)
                    {
                        _excelPackage.Workbook.Worksheets.Delete("BaseDatos");
                    }

                    ExcelWorksheet _worksheet = _excelPackage.Workbook.Worksheets.Add("BaseDatos");
                    _worksheet.Cells["A1:AK10000"].AutoFilter = true;

                    #region Encabezados
                    //Encabezados
                    //RoomID
                    MakeHeader(ref _worksheet, 1, "RoomID");

                    //Cod0
                    MakeHeader(ref _worksheet, 2, "Cod0");

                    //Cod1
                    MakeHeader(ref _worksheet, 3, "Cod1");

                    //Cod2
                    MakeHeader(ref _worksheet, 4, "Cod2");

                    //KeyName
                    MakeHeader(ref _worksheet, 5, "Key Name");

                    //Name
                    MakeHeader(ref _worksheet, 6, "Name");

                    //Coef/Area
                    MakeHeader(ref _worksheet, 7, "CoeficienteArea");

                    //Coef/NumHab
                    MakeHeader(ref _worksheet, 8, "CoeficienteNumHab");

                    //PorcientoBD
                    MakeHeader(ref _worksheet, 9, "PorcientoBD");

                    //Habitacion
                    MakeHeader(ref _worksheet, 10, "Habitacion");

                    //Modulo
                    MakeHeader(ref _worksheet, 11, "Modulo");

                    //TipoEdificio
                    MakeHeader(ref _worksheet, 12, "TipoEdificio");

                    //SubsistemaTipo
                    MakeHeader(ref _worksheet, 13, "SubsistemaTipo");

                    //SubsistemaArea
                    MakeHeader(ref _worksheet, 14, "SubsistemaArea");

                    //LocalTipo
                    MakeHeader(ref _worksheet, 15, "LocalTipo");

                    //AmbienteClave
                    MakeHeader(ref _worksheet, 16, "AmbienteClave");

                    //Floor
                    MakeHeader(ref _worksheet, 17, "Floor");

                    //Rodapie
                    MakeHeader(ref _worksheet, 18, "Rodapie");

                    //WallFinish
                    MakeHeader(ref _worksheet, 19, "WallFinish");

                    //CeilingFinish
                    MakeHeader(ref _worksheet, 20, "CeilingFinish");

                    //BaseFinish
                    MakeHeader(ref _worksheet, 21, "BaseFinish");

                    //Tratamiento
                    MakeHeader(ref _worksheet, 22, "Tratamiento");

                    //Equipamiento
                    MakeHeader(ref _worksheet, 23, "Equipamiento");

                    //Criterio[m²/ kW]
                    MakeHeader(ref _worksheet, 24, "Criterio[m²/ kW]");

                    //Criterio [W/m²]
                    MakeHeader(ref _worksheet, 25, "Criterio [W/m²]");

                    //Aire Fresco [m³/h*m²]
                    MakeHeader(ref _worksheet, 26, "Aire Fresco [m³/h*m²]");

                    //Aire Fresco [m³/h*personas]
                    MakeHeader(ref _worksheet, 27, "Aire Fresco [m³/h*personas]");

                    //Renovaciones[Cambios / hr]
                    MakeHeader(ref _worksheet, 28, "Renovaciones[Cambios / hr]");

                    //W_Aire
                    MakeHeader(ref _worksheet, 29, "W_Aire");

                    //TF
                    MakeHeader(ref _worksheet, 30, "TF");

                    //TD
                    MakeHeader(ref _worksheet, 31, "TD");

                    //TD_POS
                    MakeHeader(ref _worksheet, 32, "TD_POS");

                    //UPSC
                    MakeHeader(ref _worksheet, 33, "UPSC");

                    //UPSI
                    MakeHeader(ref _worksheet, 34, "UPSI");

                    //TT_TV
                    MakeHeader(ref _worksheet, 35, "TT_TV");

                    //DI
                    MakeHeader(ref _worksheet, 36, "DI");

                    //ALTV
                    MakeHeader(ref _worksheet, 37, "ALTV");
                    #endregion

                    var _locales = new DB_PLANTILLA().GetAllRecords<T_Local>();
                    var _grupoLocales = new DB_PLANTILLA().GetAllRecords<T_Grupo_Locales>();
                    var _porcientos = new DB_PLANTILLA().GetAllRecords<T_Porciento_BD>();
                    var _suelos = new DB_PLANTILLA().GetAllRecords<T_Catalogo_Suelo>();
                    var _rodapie = new DB_PLANTILLA().GetAllRecords<T_Catalogo_Rodapie>();
                    var _pared = new DB_PLANTILLA().GetAllRecords<T_Catalogo_Pared>();
                    var _techos = new DB_PLANTILLA().GetAllRecords<T_Catalogo_Techo>();
                    var _impermeables = new DB_PLANTILLA().GetAllRecords<T_Catalogo_Impermeable>();

                    SplashScreenManager.ShowForm(typeof(WaitScreen));
                    for (int i = 0; i < _localesByProject.Count; i++)
                    {
                        var _local = _locales.FirstOrDefault(x => x.RoomId == _localesByProject[i].Local1.RoomId);
                        _worksheet.Cells[i + 2, 1].Value = _localesByProject[i].Local1.RoomId;
                        var _cod1 = _grupoLocales.FirstOrDefault(x => x.Id == _localesByProject[i].Local1.LocalTipo.Grupo_Locales).Cod1;
                        _worksheet.Cells[i + 2, 2].Value = _cod1.Split('.').First();
                        _worksheet.Cells[i + 2, 3].Value = _cod1;
                        _worksheet.Cells[i + 2, 4].Value = _localesByProject[i].Local1.CalcularCod2();
                        _worksheet.Cells[i + 2, 5].Value = _local.Key_Name;
                        _worksheet.Column(5).AutoFit();
                        _worksheet.Cells[i + 2, 6].Value = _localesByProject[i].Local1.Key_Name;
                        _worksheet.Column(6).AutoFit();
                        _worksheet.Cells[i + 2, 7].Value = _localesByProject[i].Local1.CoefArea.Value;
                        _worksheet.Cells[i + 2, 8].Value = _localesByProject[i].Local1.GetCoefNumHab(_proyecto.Cant_Habitaciones.GetValueOrDefault());
                        _worksheet.Cells[i + 2, 9].Value = _porcientos.FirstOrDefault(x => x.Id == _localesByProject[i].Local1.Porciento_BD).Value.GetValueOrDefault().ToString("#,##");
                        _worksheet.Cells[i + 2, 10].Value = _local.Habitacion.GetValueOrDefault() ? "1" : "0";
                        _worksheet.Cells[i + 2, 11].Value = _local.Mod.GetValueOrDefault();
                        _worksheet.Cells[i + 2, 12].Value = _local.T_Tipo_Edificio.Value;
                        _worksheet.Column(12).AutoFit();
                        _worksheet.Cells[i + 2, 13].Value = _local.T_Subsistema_Tipo.Value;
                        _worksheet.Column(13).AutoFit();
                        _worksheet.Cells[i + 2, 14].Value = _local.T_Subsistema_Area.Value;
                        _worksheet.Column(14).AutoFit();
                        _worksheet.Cells[i + 2, 15].Value = _localesByProject[i].Local1.LocalTipo.Value;
                        _worksheet.Column(15).AutoFit();
                        _worksheet.Cells[i + 2, 16].Value = _localesByProject[i].Local1.Ambiente1.Nombre;
                        _worksheet.Column(16).AutoFit();
                        _worksheet.Cells[i + 2, 17].Value = _suelos.FirstOrDefault(x => x.Id == _localesByProject[i].Local1.Ambiente1.Suelo).Cod;
                        _worksheet.Cells[i + 2, 18].Value = _rodapie.FirstOrDefault(x => x.Id == _localesByProject[i].Local1.Ambiente1.Rodapie).Cod;
                        _worksheet.Cells[i + 2, 19].Value = _pared.FirstOrDefault(x => x.Id == _localesByProject[i].Local1.Ambiente1.Pared).Cod;
                        _worksheet.Cells[i + 2, 20].Value = _techos.FirstOrDefault(x => x.Id == _localesByProject[i].Local1.Ambiente1.Techo).Cod;
                        _worksheet.Cells[i + 2, 21].Value = _impermeables.FirstOrDefault(x => x.Id == _localesByProject[i].Local1.Ambiente1.Impermeable).Cod;
                        _worksheet.Cells[i + 2, 22].Value = _localesByProject[i].Local1.Climatizacion1.Tratamiento1.Value;
                        _worksheet.Cells[i + 2, 23].Value = _localesByProject[i].Local1.Climatizacion1.Equipamiento1.Value;
                        var _criterio = _localesByProject[i].Local1.Climatizacion1.Criterio1.Value == "-" ? 0 : float.Parse(_localesByProject[i].Local1.Climatizacion1.Criterio1.Value);
                        _worksheet.Cells[i + 2, 24].Value = _criterio;
                        _worksheet.Cells[i + 2, 25].Value = _criterio / 1000;
                        _worksheet.Cells[i + 2, 26].Value = _localesByProject[i].Local1.Climatizacion1.Aire_Fresco1.AF_Metro_Cuadrado.Value;
                        _worksheet.Cells[i + 2, 27].Value = _localesByProject[i].Local1.Climatizacion1.Aire_Fresco1.AF_Persona.Value;
                        _worksheet.Cells[i + 2, 28].Value = _localesByProject[i].Local1.Climatizacion1.Renovaciones1.Value;
                        _worksheet.Cells[i + 2, 28].Value = _localesByProject[i].Local1.Climatizacion1.W_Aire1.Value;
                        _worksheet.Cells[i + 2, 29].Value = _localesByProject[i].Local1.Comunicaciones_Tv1.TF1.Value;
                        _worksheet.Cells[i + 2, 30].Value = _localesByProject[i].Local1.Comunicaciones_Tv1.TD1.Value;
                        _worksheet.Cells[i + 2, 31].Value = _localesByProject[i].Local1.Comunicaciones_Tv1.TD_Pos1.Value;
                        _worksheet.Cells[i + 2, 32].Value = _localesByProject[i].Local1.Comunicaciones_Tv1.UPSC1.Value;
                        _worksheet.Cells[i + 2, 33].Value = _localesByProject[i].Local1.Comunicaciones_Tv1.UPSI1.Value;
                        _worksheet.Cells[i + 2, 34].Value = _localesByProject[i].Local1.Comunicaciones_Tv1.TT_TV1.Value;
                        _worksheet.Cells[i + 2, 35].Value = _localesByProject[i].Local1.Comunicaciones_Tv1.DI1.Value;
                        _worksheet.Cells[i + 2, 36].Value = _localesByProject[i].Local1.Comunicaciones_Tv1.ALTV1.Value;
                    }

                    if (_excelPackage.Workbook.Worksheets.FirstOrDefault(x => x.Name == DateTime.Now.ToString("yyyyMMdd") + "-Programa") != null)
                    {
                        _excelPackage.Workbook.Worksheets.Delete(DateTime.Now.ToString("yyyyMMdd") + "-Programa");
                    }

                    _worksheet = _excelPackage.Workbook.Worksheets.Add(DateTime.Now.ToString("yyyyMMdd") + "-Programa");

                    MakeHeader(ref _worksheet, 1, "Cod1");
                    MakeHeader(ref _worksheet, 2, "Cod2");
                    MakeHeader(ref _worksheet, 3, "Cod3");
                    MakeHeader(ref _worksheet, 4, "Obj. Obra");
                    MakeHeader(ref _worksheet, 5, "Local Tipo");
                    MakeHeader(ref _worksheet, 6, "Nombre");
                    MakeHeader(ref _worksheet, 7, "Cantidad");
                    MakeHeader(ref _worksheet, 8, "Área Útil");
                    MakeHeader(ref _worksheet, 9, "Porciento BD");
                    MakeHeader(ref _worksheet, 10, "Área Calculo");

                    var orderedList = _localesByProject.OrderBy(l => l.Local1.Desglose1.Value).ThenBy(l => l.Local1.LocalTipo.Value).ToList();

                    var desglose = "";
                    var localTipo = "";



                    for (int i = 0; i < orderedList.Count; i++)
                    {

                        _worksheet.Cells[i + 2, 1].Value = _locales.FirstOrDefault(l => l.RoomId == orderedList[i].Local1.RoomId).T_Grupo_Locales.Cod1; ;
                        _worksheet.Cells[i + 2, 2].Value = orderedList[i].Local1.CalcularCod2();
                        _worksheet.Cells[i + 2, 3].Value = orderedList[i].Local1.CalcularCod3();
                        _worksheet.Cells[i + 2, 4].Value = orderedList[i].Local1.Desglose1.Value.ToUpper();
                        _worksheet.Cells[i + 2, 5].Value = orderedList[i].Local1.LocalTipo.Value.ToUpper();
                        _worksheet.Cells[i + 2, 6].Value = orderedList[i].Local1.Key_Name;
                        _worksheet.Cells[i + 2, 6].AutoFitColumns();
                        _worksheet.Cells[i + 2, 7].Value = orderedList[i].Cantidad;
                        float coefArea = float.Parse(orderedList[i].Local1.CoefArea.Value);

                        var areaUtil = orderedList[i].Local1.CalcularArea(_proyecto.Cant_Habitaciones.GetValueOrDefault());
                        _worksheet.Cells[i + 2, 8].Value = areaUtil;
                        double porcientos = double.Parse(_porcientos.FirstOrDefault(p => p.Id == orderedList[i].Local1.Porciento_BD).Value.ToString());
                        _worksheet.Cells[i + 2, 9].Value = ModificarPorcientos(_porcientos.FirstOrDefault(p => p.Id == orderedList[i].Local1.Porciento_BD).Value.ToString().Replace('.', ','));
                        var areaCalculo = areaUtil * porcientos;
                        _worksheet.Cells[i + 2, 10].Value = areaCalculo;

                        #region codigo viejo
                        //if (orderedList[i].Local1.Desglose1.Value == desglose)
                        //{
                        //    if (orderedList[i].Local1.LocalTipo.Value == localTipo)
                        //    {
                        //        _worksheet.Cells[i + 1, 1].Value = _locales.FirstOrDefault(l => l.RoomId == orderedList[i].Local1.RoomId).T_Grupo_Locales.Cod1; ;
                        //        _worksheet.Cells[i + 1, 2].Value = orderedList[i].Local1.CalcularCod2();
                        //        _worksheet.Cells[i + 1, 3].Value = orderedList[i].Local1.CalcularCod3();
                        //        _worksheet.Cells[i + 1, 5].Value = orderedList[i].Local1.Key_Name;
                        //        _worksheet.Cells[i + 1, 5].AutoFitColumns();
                        //        _worksheet.Cells[i + 1, 6].Value = orderedList[i].Cantidad;
                        //        float coefArea = float.Parse(orderedList[i].Local1.CoefArea.Value);

                        //        var areaUtil = orderedList[i].Local1.CalcularArea(_proyecto.Cant_Habitaciones.GetValueOrDefault());
                        //        //_worksheet.Cells[i + 1, 7].Value = coefArea;
                        //        _worksheet.Cells[i + 1, 7].Value = areaUtil;
                        //        double porcientos = double.Parse(_porcientos.FirstOrDefault(p => p.Id == orderedList[i].Local1.Porciento_BD).Value.ToString());
                        //        _worksheet.Cells[i + 1, 8].Value = ModificarPorcientos(_porcientos.FirstOrDefault(p => p.Id == orderedList[i].Local1.Porciento_BD).Value.ToString().Replace('.',','));
                        //        //var areaUtil = coefArea*porcientos;
                        //        var areaCalculo = areaUtil * porcientos;
                        //        _worksheet.Cells[i + 1, 9].Value = areaCalculo;

                        //    }
                        //    else
                        //    {
                        //        localTipo = orderedList[i].Local1.LocalTipo.Value;
                        //        _worksheet.Cells[i + 1, 4].Value = localTipo.ToUpper();
                        //    }
                        //}
                        //else
                        //{
                        //    desglose = orderedList[i].Local1.Desglose1.Value;
                        //    _worksheet.Cells[i + 1, 4].Value = desglose.ToUpper();
                        //}
                        #endregion
                    }
                    SplashScreenManager.CloseForm();

                    _excelPackage.Save();
                    MessageBox.Show("¡Exportado con éxito!");

                } 
            }
        }

        private string ModificarPorcientos(string valor)
        {
            switch (valor)
            {
                case "1":
                    return "100";
                case "0,75":
                    return "75";
                case "0,50":
                    return "50";
                default:
                    return "25";
            }
        }

        void MakeHeader(ref ExcelWorksheet worksheet, int col)
        {
            worksheet.Cells[1, col].Value = gridView1.Columns[col - 1].FieldName;
            worksheet.Cells[1, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells[1, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
        }

        void MakeHeader(ref ExcelWorksheet worksheet, int col, string colName)
        {
            worksheet.Cells[1, col].Value = colName;
            worksheet.Cells[1, col].Style.Fill.PatternType = ExcelFillStyle.Solid;
            worksheet.Cells[1, col].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridControl1.Visible = false;
            panelControl3.Controls.Add(new DesgloseManagementView(gridControl1, cmb_Desglose, _proyecto));
        }

        private void btn_importarProyecto_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form _suggestionForm = new SuggestionForm(_proyecto);
            _suggestionForm.ShowDialog();
        }

        private void ProjectManagementForm_Activated(object sender, EventArgs e)
        {
            if (_localesByProject != null)
            {
                var _newLocales = new DB_BIM().GetElements<Locales_Proyecto>(x => x.Proyecto == _proyecto.Id);
                if (_newLocales.Count != _localesByProject.Count)
                {
                    GenerateTable();
                } 
            }
            
        }

        Local _local = null;

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            GridView _grid = gridControl1.FocusedView as GridView;

            var _rowHandle = _grid.FocusedRowHandle == -2147483646 ? 0 : _grid.FocusedRowHandle;
            var _localID = int.Parse(gridView1.GetRowCellValue(_rowHandle, "ID").ToString());
            _local = new DB_BIM().GetSingleElement<Local>(x => x.Id == _localID);

            switch (e.MenuType)
            {
                case GridMenuType.Row:
                    var menu = e.Menu as GridViewMenu;
                    menu.Items.Clear();
                    menu.Items.Add(CreateItem("Eliminar"));
                    break;
            }
        }

        DXMenuItem CreateItem(string name)
        {
            DXMenuItem item = null;
            switch (name)
            {
                case "Eliminar":
                    item = new DXMenuItem(name, new EventHandler(Eliminar));
                    break;

            }

            return item;
        }

        void Eliminar(object sender, EventArgs e)
        {
            DialogResult _dialog = MessageBox.Show("¿Seguro que quiere eliminar este local?", "", MessageBoxButtons.YesNo);
            if (_dialog == DialogResult.Yes)
            {
                using (var db = new DB_BIM())
                {
                    var _localProyecto = db.GetSingleElement<Locales_Proyecto>(x => x.Local == _local.Id && x.Proyecto == _proyecto.Id);
                    db.Locales_Proyecto.Remove(_localProyecto);
                    db.SaveChanges();
                    GenerateTable();
                }
            }
        }
    }
}