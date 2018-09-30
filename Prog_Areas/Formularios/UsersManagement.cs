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
using Prog_Areas_Plantilla.Modelos;
using Prog_Areas_Plantilla.Controllers;

namespace Prog_Areas.Formularios
{
    public partial class UsersManagement : DevExpress.XtraEditors.XtraUserControl
    {
        Usuario _usuario;
        public UsersManagement(Usuario usuario)
        {
            InitializeComponent();

            if (usuario != null)
            {
                _usuario = usuario;
                txt_username.Text = usuario.username;
                txt_password.Text = usuario.password;
                cmb_access.SelectedIndex = usuario.access_Level;
                cmb_access.Enabled = true;
                btn_accept.Text = "Actualizar";
            }
            else
            {
                cmb_access.SelectedIndex = 0;
                cmb_access.Enabled = false;
                btn_accept.Text = "Adicionar";
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            MainView.Instance().renderPanel.Controls.Clear();
            MainView.Instance().renderPanel.Controls.Add(new UsersListView());
        }

        private void btn_accept_Click(object sender, EventArgs e)
        {
            if (CheckIntegrity())
            {
                if (_usuario != null)
                {
                    ActualizarUsuario();
                }
                else
                {
                    AdicionarUsuario();
                } 
            }
            else
            {
                MessageBox.Show("Existen Datos Incompletos");
            }
        }

        private void AdicionarUsuario()
        {
            Usuario_Controller.InsertUsuario(txt_username.Text, txt_password.Text);

            txt_username.Text = string.Empty;
            txt_password.Text = string.Empty;
        }

        void ActualizarUsuario()
        {
            _usuario.username = txt_username.Text;
            _usuario.password = txt_password.Text;
            _usuario.access_Level = cmb_access.SelectedIndex;

            Usuario_Controller.UpdateUser(_usuario);

            MainView.Instance().renderPanel.Controls.Clear();
            MainView.Instance().renderPanel.Controls.Add(new UsersListView());
        }

        bool CheckIntegrity()
        {
            if (txt_username.Text == "" || txt_password.Text == "")
            {
                return false;
            }

            return true;
        }
    }
}
