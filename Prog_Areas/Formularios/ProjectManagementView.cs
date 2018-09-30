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
    public partial class ProjectManagementView : DevExpress.XtraEditors.XtraUserControl
    {
        Proyecto _proyecto;
        public ProjectManagementView(Proyecto proyecto)
        {
            InitializeComponent();

            if (proyecto != null)
            {
                _proyecto = proyecto;
                txt_nombreProyecto.Text = _proyecto.Nombre;
                txt_codigo.Text = _proyecto.Cod;
                txt_cantHabitaciones.Text = _proyecto.Cant_Habitaciones.ToString();
                btn_add.Text = "Actualizar";
            }
            else
            {
                btn_add.Text = "Adicionar";
            }
                
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (_proyecto != null)
            {
                ActualizarProyecto();
                MainView.Instance().renderPanel.Controls.Clear();
                MainView.Instance().renderPanel.Controls.Add(new ProjectListingView());
            }
            else
            {
                AdicionarProyecto();
                txt_nombreProyecto.Text = string.Empty;
                txt_codigo.Text = string.Empty;
                txt_nombreProyecto.Text = string.Empty;
            }
                
        }

        bool CheckIntegrity()
        {
            if (txt_nombreProyecto.Text == "")
                return false;
            if (txt_codigo.Text == "")
                return false;
            if (txt_nombreProyecto.Text == "")
                return false;

            return true;
        }

        private void ActualizarProyecto()
        {
            if (CheckIntegrity())
            {
                try
                {
                    Proyecto _proy = new Proyecto()
                    {
                        Nombre = txt_nombreProyecto.Text,
                        Cod = txt_codigo.Text.ToUpper(), 
                        Cant_Habitaciones = int.Parse(txt_cantHabitaciones.Text)
                    };

                    //ProyectoController.UpdateProyecto(_proy);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }
            }
        }

        void AdicionarProyecto()
        {
            if (CheckIntegrity())
            {
                try
                {
                    //if (ProyectoController.GetProyectoByCode(txt_codigo.Text) == null)
                    //{
                    //    Proyecto _proy = new Proyecto()
                    //    {
                    //        Nombre = txt_nombreProyecto.Text,
                    //        Cod = txt_codigo.Text.ToUpper(),
                    //        Cant_Habitaciones = int.Parse(txt_cantHabitaciones.Text)
                    //    };

                    //    //ProyectoController.InsertarProyecto(_proy);

                    //    txt_nombreProyecto.Text = "";
                    //    txt_nombreProyecto.Focus();
                    //    txt_codigo.Text = "";
                    //    txt_nombreProyecto.Text = "";
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Ese código de proyecto ya existe");
                    //}

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

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            MainView.Instance().renderPanel.Controls.Clear();
            MainView.Instance().renderPanel.Controls.Add(new ProjectListingView());
        }
    }
}
