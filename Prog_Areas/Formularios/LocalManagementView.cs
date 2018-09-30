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
    public partial class LocalManagementView : DevExpress.XtraEditors.XtraUserControl
    {
        Local _local;
        public LocalManagementView(Local local)
        {
            InitializeComponent();
            UpdateCombos();

            if (local != null)
            {
                _local = local;
                btn_add.Text = "Actualizar";
                txt_roomID.Text = _local.RoomId.ToString();
                txt_roomName.Text = _local.Key_Name;
                //txt_Cod1.Text = Grupo_LocalesController.GetCod1ByID(local.Grupo_Locales.GetValueOrDefault());

                chk_Habitacion.Checked = local.Habitacion.GetValueOrDefault();

                //cmb_SubTipo.SelectedIndex = cmb_SubTipo.FindString(SubsistemasController.GetSubsistemaTipoNombreByID(local.SubsistemaTipo.GetValueOrDefault()));
                //cmb_SubArea.SelectedIndex = cmb_SubArea.FindString(SubsistemasController.GetSubsistemaAreaNombreByID(local.SubsistemaArea.GetValueOrDefault()));
                //cmb_grupoLocales.SelectedIndex = cmb_grupoLocales.FindString(Grupo_LocalesController.GetGrupo_LocalesByID(local.Grupo_Locales.GetValueOrDefault()).Value);

            }
            else
            {
                btn_add.Text = "Adicionar";
                //txt_roomID.Text = (LocalController.GetLastLocalRecord() + 1).ToString();
                cmb_SubTipo.SelectedIndex = 0;
                cmb_SubArea.SelectedIndex = 0;
                cmb_grupoLocales.SelectedIndex = 0;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (CheckIntegrity())
            {
                try
                {
                    if (_local == null)
                    {
                        AdicionarLocal();

                        MainView.Instance().renderPanel.Controls.Clear();
                        MainView.Instance().renderPanel.Controls.Add(new LocalListView());
                    }
                    else
                    {
                        ActualizarLocal();
                        MainView.Instance().renderPanel.Controls.Clear();
                        MainView.Instance().renderPanel.Controls.Add(new LocalListView());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    //throw;
                } 
            }
            else
            {
                MessageBox.Show("Existen campos vacíos");
            }
        }

        void ActualizarLocal()
        {
            Local _newLocal = new Local()
            {
                RoomId = int.Parse(txt_roomID.Text),
                Key_Name = txt_roomName.Text,
                Habitacion = chk_Habitacion.Checked ? true : false,
                //SubsistemaTipo = SubsistemasController.InsertarSubsistemaTipo(cmb_SubTipo.Text).Id,
                //SubsistemaArea = SubsistemasController.InsertarSubsistemaArea(cmb_SubArea.Text).Id,
                //Grupo_Locales = Grupo_LocalesController.InsertarGrupoLocales(txt_Cod1.Text, cmb_grupoLocales.Text).Id
            };

            //LocalController.UpdateLocal(_newLocal);
        }

        void AdicionarLocal()
        {
            //_local = LocalController.GetLocalByName(txt_roomName.Text);
            if (_local == null)
            {
                //_local = LocalController.GetLocalByRoomId(int.Parse(txt_roomID.Text));
                if (_local == null)
                {
                    Local _newLocal = new Local()
                    {
                        RoomId = int.Parse(txt_roomID.Text),
                        Key_Name = txt_roomName.Text,
                        Habitacion = chk_Habitacion.Checked ? true : false,
                        //SubsistemaTipo = SubsistemasController.InsertarSubsistemaTipo(cmb_SubTipo.Text).Id,
                        //SubsistemaArea = SubsistemasController.InsertarSubsistemaArea(cmb_SubArea.Text).Id,
                        //Grupo_Locales = Grupo_LocalesController.InsertarGrupoLocales(txt_Cod1.Text, cmb_grupoLocales.Text).Id
                    };

                    //LocalController.InsertLocal(_newLocal);
                    ClearAll();
                }
                else
                {
                    MessageBox.Show("Ese Room ID ya existe");
                }
            }
            else
            {
                MessageBox.Show("Ese Room KeyName ya existe");
            }
        }

        void ClearAll()
        {
            txt_Cod1.Text = string.Empty;
            txt_roomID.Text = string.Empty;
            txt_roomName.Text = string.Empty;
            UpdateCombos();
        }

        void UpdateCombos()
        {
            cmb_SubArea.Items.Clear();
            cmb_SubTipo.Items.Clear();
            cmb_grupoLocales.Items.Clear();

            //foreach (var item in SubsistemasController.GetAllSubsistemaTipo())
            //{
            //    cmb_SubTipo.Items.Add(item.Value);
            //}

            //foreach (var item in SubsistemasController.GetAllSubsistemaArea())
            //{
            //    cmb_SubArea.Items.Add(item.Value);
            //}


            //foreach (var item in Grupo_LocalesController.GetAllGrupoLocales())
            //{
            //    cmb_grupoLocales.Items.Add(item.Value);
            //}
        }

        bool CheckIntegrity()
        {
            if (txt_roomName.Text == "")
                return false;

            if (txt_roomID.Text == "")
                return false;

            if (txt_Cod1.Text == "")
                return false;

            if (cmb_SubArea.Text == "")
                return false;

            if (cmb_SubTipo.Text == "")
                return false;

            return true;
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            MainView.Instance().renderPanel.Controls.Clear();
            MainView.Instance().renderPanel.Controls.Add(new LocalListView());
        }
    }
}
