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
using Prog_Areas_Proyecto.Controllers;
using System.Linq.Expressions;
using Prog_Areas_Plantilla.Modelos;
using Prog_Areas_Plantilla.Controllers;
using DevExpress.XtraSplashScreen;

namespace Prog_Areas.Formularios.Test
{
    public partial class SuggestionForm : XtraForm
    {
        Proyecto _proyecto;
        Prog_Areas_Proyecto.DataSets.DataSetProyectosTableAdapters.LocalesByProyIDTableAdapter _localesById;
        List<Locales_Proyecto> _localesByProject;
        List<Proyecto> _proyectos;

        public SuggestionForm(Proyecto Proyecto)
        {
            InitializeComponent();
            _proyecto = Proyecto;
            _localesById = new Prog_Areas_Proyecto.DataSets.DataSetProyectosTableAdapters.LocalesByProyIDTableAdapter();

            _proyectos = new DB_BIM().GetAllElements<Proyecto>().ToList();

            if (_proyectos.Count >= 1)
            {
                foreach (var item in _proyectos)
                {
                    cmb_proyectos.Items.Add(item.Cod + " - " + item.Nombre);
                }
            }

            gridControl1.DataSource = CreateColumns();
        }

        void FillData()
        {
            SplashScreenManager.ShowForm(typeof(WaitScreen));
            gridControl1.DataSource = CreateColumns();

            using (var db = new DB_PLANTILLA())
            {
                var _locales = db.GetAllRecords<T_Local>();
                var _subTipos = db.GetAllElements<T_Subsistema_Tipo>();
                var _subAreas = db.GetAllElements<T_Subsistema_Area>();
                var _coefs = db.GetAllElements<T_CoefArea>();
                var _porcientos = db.GetAllElements<T_Porciento_BD>();
                

                foreach (var item in _localesByProject)
                {
                    gridView1.AddNewRow();

                    int _rowHandle = gridView1.GetRowHandle(gridView1.DataRowCount);

                    if (gridView1.IsNewItemRow(_rowHandle))
                    {
                        var _local = new DB_BIM().GetSingleRecord<Local>(x => x.Id == item.Local);
                        gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["RoomID"], _local.RoomId);
                        gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["KeyName"], _local.Key_Name);
                        var _subTipo = new DB_PLANTILLA().GetSingleRecord<T_Subsistema_Tipo>(x => x.Id == _local.SubsistemaTipo);
                        gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["SubTipo"], _subTipo.Value.ToString());
                        var _subArea = new DB_PLANTILLA().GetSingleRecord<T_Subsistema_Area>(x => x.Id == _local.SubsistemaArea);
                        gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["SubArea"], _subArea.Value.ToString());
                        var _coefArea = new DB_BIM().GetSingleElement<CoefArea>(x => x.Id == _local.Coef_Area);
                        gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["Coef"], _coefArea.Value);
                        var _porcientoBD = new DB_PLANTILLA().GetSingleRecord<T_Porciento_BD>(x => x.Id == _local.Porciento_BD);
                        gridView1.SetRowCellValue(_rowHandle, gridView1.Columns["PorcientoBD"], _porcientoBD.Value);
                    }
                } 
            }
            SplashScreenManager.CloseForm();
        }

        DataTable CreateColumns()
        {
            DataTable _newDatable = new DataTable();

            _newDatable.Columns.Add("RoomID"); //0
            _newDatable.Columns.Add("KeyName"); //1
            _newDatable.Columns.Add("SubTipo"); //2
            _newDatable.Columns.Add("SubArea"); //3
            _newDatable.Columns.Add("Coef"); //4
            _newDatable.Columns.Add("PorcientoBD"); //5

            return _newDatable;
        }

        private void btn_Acept_Click(object sender, EventArgs e)
        {
            var _desgloses = new DB_BIM().GetAllElements<Desglose>();

            foreach (var item in _localesByProject)
            {
                var _desglose = _desgloses.FirstOrDefault(x => x.Id == item.Local1.Desglose);
                var _desgloseProyecto = _proyecto.Desglose;
                Desglose _a = null;
                if (_desglose != null && _proyecto.Desglose.FirstOrDefault(x => x.Value == _desglose.Value) == null)
                {
                    var _nuevoDesglose = new Desglose()
                    {
                        Proyecto = _proyecto.Id,
                        Value = _desglose.Value
                    };
                    _a = new DB_BIM().AddElemento<Desglose>(typeof(Desglose), _nuevoDesglose);
                }
                else
                {
                    _a = _proyecto.Desglose.FirstOrDefault(x => x.Value == _desglose.Value);
                }

                var _itemLocal = new DB_BIM().GetSingleElement<Local>(x => x.Id == item.Local);

                var _local = new Local()
                {
                    Key_Name = _itemLocal.Key_Name,
                    Ambiente = _itemLocal.Ambiente,
                    Climatizacion = _itemLocal.Climatizacion,
                    Coef_Area = _itemLocal.Coef_Area,
                    Comunicaciones_TV = _itemLocal.Comunicaciones_TV,
                    Desglose = _a.Id,
                    Habitacion = _itemLocal.Habitacion,
                    Local_Tipo = _itemLocal.Local_Tipo,
                    Mod = _itemLocal.Mod,
                    Porciento_BD = _itemLocal.Porciento_BD,
                    RoomId = _itemLocal.RoomId,
                    SubsistemaArea = _itemLocal.SubsistemaArea,
                    SubsistemaTipo = _itemLocal.SubsistemaTipo
                };

                new DB_BIM().AddElemento<Local>(typeof(Local), _local);


                Locales_Proyecto _localProyecto = new Locales_Proyecto()
                {
                    Local = _local.Id,
                    Proyecto = _proyecto.Id,
                    Cantidad = item.Cantidad
                };
                new DB_BIM().AddElemento<Locales_Proyecto>(typeof(Locales_Proyecto), _localProyecto);
            }

            MessageBox.Show("Todos los locales fueron importados!");
            this.Close();
        }

        private void SuggestionForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //ProjectManagementForm _managementForm = new ProjectManagementForm(_proyecto);
            //_managementForm.ShowDialog();
            //_managementForm.Focus();
        }

        private void cmb_proyectos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var _codigo = cmb_proyectos.SelectedItem.ToString().Split('-').First().Trim();
            var _newProyecto = _proyectos.FirstOrDefault(x => x.Cod == _codigo);
            _localesByProject = new DB_BIM().GetElements<Locales_Proyecto>(x => x.Proyecto == _newProyecto.Id);
            FillData();
        }
    }
}