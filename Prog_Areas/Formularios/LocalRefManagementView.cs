using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;


using Prog_Areas_Proyecto.Modelos;

namespace Prog_Areas.Formularios
{
    public partial class LocalRefManagementView : XtraUserControl
    {
        Proyecto _proyecto;
        Local _local;
        bool _new = false;
        public LocalRefManagementView(Proyecto Proyecto)
        {
            InitializeComponent();
            _proyecto = Proyecto;
            //txt_CoefNumHabitaciones.Text = Proyecto.Cant_habitaciones.ToString();
            UpdateCombobox();
            UpdateLocalTipo();
            txt_nombre.Text = cmb_Locales.Text;
            _new = true;

            btn_add.Text = "Adicionar";
            btn_cancel.Visible = false;
            _new = true;
        }

        public LocalRefManagementView(Proyecto Proyecto, Local Local)
        {
            InitializeComponent();
            _proyecto = Proyecto;
            _local = Local;
            //txt_CoefNumHabitaciones.Text = Proyecto.Cant_habitaciones.ToString();
            UpdateCombobox();
            UpdateLocalTipo();
            //cmb_Locales.SelectedIndex = cmb_Locales.FindString(LocalController.GetLocalByRoomId(_local.RoomId.GetValueOrDefault()).Key_Name);

            //cmb_alojamientoTipo.SelectedIndex = _local.Alojamiento_Tipo == null ? 0 : cmb_alojamientoTipo.FindString(AlojamientoController.GetAlojamientoTipoByID(_local.Alojamiento_Tipo.GetValueOrDefault()).Nombre);
            //cmb_alojamientoTipo.SelectedIndex = cmb_alojamientoTipo.FindString(AlojamientoController.GetAlojamientoTipoByID(Local.Alojamiento_Tipo.GetValueOrDefault()).Nombre);

            //cmb_porcientoBD.SelectedIndex = cmb_porcientoBD.FindString(LocalController.GetPorcientoBDById(_local.Porciento_BD.GetValueOrDefault()).Value.ToString());
            //cmb_tipoEdificio.SelectedIndex = cmb_tipoEdificio.FindString(LocalController.GetTipoEdificioByID(_local.Tipo_Edificio.GetValueOrDefault()).Tipo_Edificio1);
            //cmb_tipoEdificio.SelectedIndex = _local.Tipo_Edificio == null ? 0 : cmb_tipoEdificio.FindString(LocalController.GetTipoEdificioByID(_local.Tipo_Edificio.GetValueOrDefault()).Tipo_Edificio1);
            txt_nombre.Text = cmb_Locales.Text;

            //var _acabado = AcabadoController.GetAcabadoById(Local.Acabado.GetValueOrDefault());
            //var _ambiente = AmbienteController.GetAmbienteRefById(_acabado.Ambiente.GetValueOrDefault());

            //cmb_ambientes.SelectedIndex = cmb_ambientes.FindString(_ambiente.Nombre);
            //cmb_techos.SelectedIndex = cmb_techos.FindString(AmbienteController.GetTechoById(_ambiente.Techo.GetValueOrDefault()).Cod);
            //cmb_Pared.SelectedIndex = cmb_Pared.FindString(AmbienteController.GetParedById(_ambiente.Pared.GetValueOrDefault()).Cod);
            //cmb_suelos.SelectedIndex = cmb_suelos.FindString(AmbienteController.GetSueloById(_ambiente.Suelo.GetValueOrDefault()).Cod);
            //cmb_rodapies.SelectedIndex = cmb_rodapies.FindString(AmbienteController.GetRodapieById(_ambiente.Rodapie.GetValueOrDefault()).Cod);
            //cmb_Impermeables.SelectedIndex = cmb_Impermeables.FindString(AmbienteController.GetImpermeableById(_ambiente.Impermeable.GetValueOrDefault()).Cod);

            btn_add.Text = "Modificar";
            btn_cancel.Visible = true;
        }

        void UpdateCombobox()
        {
            cmb_Locales.Items.Clear();

            //var _locales = LocalController.GetAllLocalNames();

            //foreach (var item in _locales)
            //{
            //    cmb_Locales.Items.Add(item);
            //}
            
            //cmb_Locales.SelectedIndex = 0;

            //cmb_alojamientoTipo.Items.Clear();
            //var _alojamientos = AlojamientoController.GetAllAlojamientos();
            //foreach (var item in _alojamientos)
            //{
            //    cmb_alojamientoTipo.Items.Add(item.Nombre);
            //}

            //cmb_alojamientoTipo.SelectedIndex = 0;

            //cmb_porcientoBD.Items.Clear();
            //var _porcientos = LocalController.GetAllPorcientos();
            //foreach (var item in _porcientos)
            //{
            //    cmb_porcientoBD.Items.Add(item.Value.ToString());
            //}
            //cmb_porcientoBD.SelectedIndex = 0;

            //cmb_tipoEdificio.Items.Clear();
            //var _tipos = LocalController.GetAllTipoEdificios();
            //foreach (var item in _tipos)
            //{
            //    cmb_tipoEdificio.Items.Add(item.Tipo_Edificio1);
            //}
            //cmb_tipoEdificio.SelectedIndex = 0;

            //cmb_ambientes.Items.Clear();
            //var _ambientes = AmbienteController.GetAllAmbientes();
            //foreach (var item in _ambientes)
            //{
            //    cmb_ambientes.Items.Add(item.Nombre);
            //}
            //cmb_ambientes.SelectedIndex = 0;

            //Ambiente _ambiente = AmbienteController.GetAmbienteByName(cmb_ambientes.Text);

            //cmb_techos.Items.Clear();
            //var _techos = AmbienteController.GetAllTechos();
            //foreach (var item in _techos)
            //{
            //    cmb_techos.Items.Add(item.Cod);
            //}
            //cmb_techos.SelectedIndex = cmb_techos.FindString(AmbienteController.GetTechoById(_ambiente.Techo.GetValueOrDefault()).Cod);


            //cmb_suelos.Items.Clear();
            //var _suelos = AmbienteController.GetAllSuelos();
            //foreach (var item in _suelos)
            //{
            //    cmb_suelos.Items.Add(item.Cod);
            //}
            //cmb_suelos.SelectedIndex = cmb_suelos.FindString(AmbienteController.GetSueloById(_ambiente.Suelo.GetValueOrDefault()).Cod);

            //cmb_Pared.Items.Clear();
            //var _paredes = AmbienteController.GetAllParedes();
            //foreach (var item in _paredes)
            //{
            //    cmb_Pared.Items.Add(item.Cod);
            //}
            //cmb_Pared.SelectedIndex = cmb_Pared.FindString(AmbienteController.GetParedById(_ambiente.Pared.GetValueOrDefault()).Cod);

            //cmb_Impermeables.Items.Clear();
            //var _impermeables = AmbienteController.GetAllImpermeables();
            //foreach (var item in _impermeables)
            //{
            //    cmb_Impermeables.Items.Add(item.Cod);
            //}
            //cmb_Impermeables.SelectedIndex = cmb_Impermeables.FindString(AmbienteController.GetImpermeableById(_ambiente.Impermeable.GetValueOrDefault()).Cod);

            //cmb_rodapies.Items.Clear();
            //var _rodapies = AmbienteController.GetAllRodapies();
            //foreach (var item in _rodapies)
            //{
            //    cmb_rodapies.Items.Add(item.Cod);
            //}
            //cmb_rodapies.SelectedIndex = cmb_rodapies.FindString(AmbienteController.GetRodapieById(_ambiente.Rodapie.GetValueOrDefault()).Cod);

        }

        void UpdateAcabados()
        {
            if (_new)
            {
                //Ambiente _ambiente = AmbienteController.GetAmbienteByName(cmb_ambientes.Text);

                //cmb_techos.SelectedIndex = cmb_techos.FindString(AmbienteController.GetTechoById(_ambiente.Techo.GetValueOrDefault()).Cod);

                //cmb_suelos.SelectedIndex = cmb_suelos.FindString(AmbienteController.GetSueloById(_ambiente.Suelo.GetValueOrDefault()).Cod);

                //cmb_Pared.SelectedIndex = cmb_Pared.FindString(AmbienteController.GetParedById(_ambiente.Pared.GetValueOrDefault()).Cod);

                //cmb_Impermeables.SelectedIndex = cmb_Impermeables.FindString(AmbienteController.GetImpermeableById(_ambiente.Impermeable.GetValueOrDefault()).Cod);

                //cmb_rodapies.SelectedIndex = cmb_rodapies.FindString(AmbienteController.GetRodapieById(_ambiente.Rodapie.GetValueOrDefault()).Cod); 
            }
        }


        void UpdateLocalTipo()
        {
            //cmb_localTipo.Items.Clear();

            //var _local_base = LocalController.GetLocalByName(cmb_Locales.Text);

            //var _locales = Grupo_LocalesController.GetLocalesTipoByGrupoId(_local_base.Grupo_Locales.GetValueOrDefault());

            //foreach (var item in _locales)
            //{
            //    cmb_localTipo.Items.Add(item.Value);
            //}
            //cmb_localTipo.SelectedIndex = 0;
        }

        private void cmb_Locales_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txt_cod0.Text = CodController.CalcularCod0(LocalController.GetLocalByName(cmb_Locales.Text).RoomId).ToString();
            //txt_cod2.Text = CodController.CalcularCod2(LocalController.GetLocalByName(cmb_Locales.Text).RoomId);
            //txt_nombre.Text = cmb_Locales.Text;
            //UpdateLocalTipo();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            //Climatizacion _clima = new Climatizacion()
            //{
            //    Tratamiento = ClimatizacionController.InsertarTratamiento(txt_tratamiento.Text).Id,
            //    Equipamiento = ClimatizacionController.InsertarEquipamiento(txt_equipamiento.Text).Id,
            //    Criterio = ClimatizacionController.InsertarCriterio(double.Parse(txt_criterioMetroCuadrado.Text)).Id,
            //    Renovaciones = ClimatizacionController.InsertarRenovaciones(int.Parse(txt_Renovaciones.Text)).Id,
            //    W_Aire = ClimatizacionController.InsertarWAire(float.Parse(txt_WAire.Text)).Id,
            //    Aire_Fresco = AFController.InsertarAireFresco(double.Parse(txt_aireFrescoPersonas.Text), double.Parse(txt_aireFrescoMetros.Text)).Id
            //};

            //Comunicaciones_Tv _comYTv = new Comunicaciones_Tv()
            //{
            //    Tf = Comunicaciones_TVController.InsertarTF(txt_tf.Text).Id,
            //    Td = Comunicaciones_TVController.InsertarTD(txt_TD.Text).Id,
            //    TD_Pos = Comunicaciones_TVController.InsertarTD_Pos(txt_tdpos.Text).Id,
            //    UPSC = Comunicaciones_TVController.InsertarUPSC(txt_upsc.Text).Id,
            //    UPSI = Comunicaciones_TVController.InsertarUPSI(txt_upsi.Text).Id,
            //    TT_TV = Comunicaciones_TVController.InsertarTT_TV(txt_tttv.Text).Id,
            //    Di = Comunicaciones_TVController.InsertarDI(double.Parse(txt_di.Text)).Id,
            //    Altv = Comunicaciones_TVController.InsertarALTV(txt_altv.Text).Id
            //};


            //Ambiente_Ref _ambienteRef = new Ambiente_Ref()
            //{
            //    Nombre = cmb_ambientes.Text,
            //    Techo = AmbienteController.GetTechoByCod(cmb_techos.Text).Id,
            //    Pared = AmbienteController.GetParedByCod(cmb_Pared.Text).Id,
            //    Suelo = AmbienteController.GetSueloByCod(cmb_suelos.Text).Id,
            //    Rodapie = AmbienteController.GetRodapieByCod(cmb_rodapies.Text).Id,
            //    Impermeable = AmbienteController.GetImpermeableByCod(cmb_Impermeables.Text).Id
            //};


            //Acabado _acabado = new Acabado()
            //{
            //    Ambiente = AmbienteController.InsertarAmbienteRef(_ambienteRef).Id
            //};



            if (_new)
            {
                //Local_Ref _localRef = new Local_Ref()
                //{
                //    Cod_0 = int.Parse(txt_cod0.Text),
                //    Cod_2 = txt_cod2.Text,
                //    Cod3 = txt_cod3.Text,
                //    RoomId = LocalController.GetLocalByName(cmb_Locales.Text).RoomId,
                //    Local_Nombre = LocalController.InsertarLocal_Nombre(txt_nombre.Text).Id,
                //    Porciento_BD = LocalController.InsertarPorcientoBD(float.Parse(cmb_porcientoBD.Text)).Id,
                //    Tipo_Edificio = LocalController.InsertarTipoEdificio(cmb_tipoEdificio.Text).Id,
                //    Mod = LocalController.InsertarMod(int.Parse(txt_mod.Text)).Id,
                //    Local_Tipo = LocalController.InsertarLocalTipo(cmb_localTipo.Text, LocalController.GetParent(cmb_localTipo.Text)).Id,
                //    //Acabado = AcabadoController.InsertarAcabado(_acabado).Id,
                //    Alojamiento_Tipo = AlojamientoController.InsertarAlojamiento_Tipo(txt_alojamiento.Text, cmb_alojamientoTipo.Text).Id,
                //    Climatizacion = ClimatizacionController.InsertarClimatizacion(_clima).Id,
                //    Comunicaciones_TV = Comunicaciones_TVController.InsertarComunicacionesTV(_comYTv).Id,
                //    CoefNumHab = LocalController.InsertarCoefNumHabitaciones(txt_CoefNumHabitaciones.Text).Id,
                //    Coef = LocalController.InsertarCoef(float.Parse(txt_coef.Text)).Id
                //};

                //LocalController.InsertarLocal_Ref(_localRef);
                //LocalProyectoController.InsertLocalProyecto(_localRef, _proyecto, int.Parse(txt_CantidadRooms.Text));

            }
            else
            {
                //_local.Cod_0 = int.Parse(txt_cod0.Text);
                //_local.Cod_2 = txt_cod2.Text;
                //_local.Cod3 = txt_cod3.Text;
                //_local.RoomId = LocalController.GetLocalByName(cmb_Locales.Text).RoomId;
                //_local.Local_Nombre = LocalController.InsertarLocal_Nombre(txt_nombre.Text).Id;
                //_local.Porciento_BD = LocalController.InsertarPorcientoBD(float.Parse(cmb_porcientoBD.Text)).Id;
                //_local.Tipo_Edificio = LocalController.InsertarTipoEdificio(cmb_tipoEdificio.Text).Id;
                //_local.Mod = LocalController.InsertarMod(int.Parse(txt_mod.Text)).Id;
                //_local.Local_Tipo = LocalController.InsertarLocalTipo(cmb_localTipo.Text, LocalController.GetParent(cmb_localTipo.Text)).Id;
                ////_local.Acabado = AcabadoController.InsertarAcabado(_acabado).Id;
                //_local.Alojamiento_Tipo = AlojamientoController.InsertarAlojamiento_Tipo(txt_alojamiento.Text, cmb_alojamientoTipo.Text).Id;
                //_local.Climatizacion = ClimatizacionController.InsertarClimatizacion(_clima).Id;
                //_local.Comunicaciones_TV = Comunicaciones_TVController.InsertarComunicacionesTV(_comYTv).Id;
                //_local.CoefNumHab = LocalController.InsertarCoefNumHabitaciones(txt_CoefNumHabitaciones.Text).Id;
                //_local.Coef = LocalController.InsertarCoef(float.Parse(txt_coef.Text)).Id;

                //LocalController.UpdateLocalRef(_local);
                //LocalProyectoController.UpdateLocalProyecto(_local, _proyecto, int.Parse(txt_CantidadRooms.Text));
            }



            ProjectManagementForm._projectManagementForm.UpdateGridControl();
            ClearAll();
        }

        void ClearAll()
        {
            cmb_Locales.SelectedIndex = 0;
            //txt_CoefNumHabitaciones.Text = _proyecto.Cant_habitaciones.ToString();
            cmb_porcientoBD.SelectedIndex = 0;
            cmb_tipoEdificio.SelectedIndex = 0;
            cmb_localTipo.SelectedIndex = 0;
            cmb_alojamientoTipo.SelectedIndex = 0;
            txt_CantidadRooms.Text = "1";
            txt_coef.Text = "0,033";
            txt_mod.Text = "0";

            btn_add.Text = "Adicionar";
            btn_cancel.Visible = false;
            _new = true;
            _local = null;
        }

        private void cmb_alojamientoTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_alojamiento.Text = cmb_alojamientoTipo.Text;
        }

        private void cmb_porcientoBD_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb_porcientoBD.Text)
            {
                case "1":
                    txt_cod3.Text = "CC";
                    break;
                case "0,25":
                    txt_cod3.Text = "EX";
                    break;
                default:
                    txt_cod3.Text = "CA";
                    break;
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void txt_mod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_coef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar))
            {
                if (e.KeyChar == ',' || e.KeyChar == '\b')
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void cmb_ambientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAcabados();


        }
    }
}
