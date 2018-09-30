using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prog_Areas_Plantilla.Modelos;
using Prog_Areas_Plantilla.Controllers;


using Prog_Areas.Formularios;



namespace Prog_Areas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Prog_Areas_Proyecto.Modelos.Proyecto _proy = Prog_Areas_Proyecto.Controllers.ProyectoDataBaseController.GetSingleElement<Prog_Areas_Proyecto.Modelos.Proyecto>(new Prog_Areas_Proyecto.Modelos.DB_BIM(), x => x.Id == 49);
            //Form _a = new Prog_Areas.Formularios.Test.ExcelImportForm(_proy);
            //_a.ShowDialog();

            //Clean_And_Refill.CleanAllTemplates();
        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            Program._autenticatedUser = Usuario_Controller.Autenticate(txt_username.Text, txt_password.Text);
            if (Program._autenticatedUser != null)
            {
                //Form _mainView = new MainView();
                Form _mainView = MainView.Instance();
                _mainView.Show();
                _mainView.FormClosed += CloseAll;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
            }       
        }

        private void CloseAll(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
