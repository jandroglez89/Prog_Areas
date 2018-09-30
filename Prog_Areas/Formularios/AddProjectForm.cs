using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Prog_Areas_Proyecto.Modelos;
using Prog_Areas_Proyecto.Controllers;
using Prog_Areas_Proyecto.DataSets;

using Prog_Areas.Formularios.Test;

namespace Prog_Areas.Formularios
{
    public partial class AddProjectForm : DevExpress.XtraEditors.XtraForm
    {
        DataSetProyectos.obrasRow _obra;
        public AddProjectForm(DataSetProyectos.obrasRow obra)
        {
            InitializeComponent();

            _obra = obra;

            txt_nombre.Text = obra.nombre;
            txt_codigo.Text = obra.codigo;
            txt_localizacion.Text = obra.localizacion;

            cmb_TipoHotel.SelectedIndex = 0;
            cmb_TipoAlojamiento.SelectedIndex = 0;
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            if (CheckIntegrity())
            {
                DialogResult _decision = MessageBox.Show("¿Todos los datos son correctos?", "", MessageBoxButtons.YesNo);
                if (_decision == DialogResult.Yes)
                {
                    Proyecto _proyecto = new Proyecto()
                    {
                        Id = _obra.idobra,
                        Nombre = _obra.nombre,
                        Cod = _obra.codigo,
                        Localizacion = _obra.localizacion,
                        Superficie_Parcela = double.Parse(txt_superficieParcela.Text),
                        Categoria = Convert.ToInt32(numeric_categoria.Value),
                        Cant_Habitaciones = Convert.ToInt32(numeric_cantHabitaciones.Value),
                        Tipo_Hotel = cmb_TipoHotel.Text,
                        Subtipo_Alojamiento = cmb_SubtipoAlojamiento.Text,
                        Tipo_Alojamiento = cmb_TipoAlojamiento.Text,
                        Maxima_Altura = Convert.ToInt32(numeric_MaximaAltura.Value)
                    };

                    new DB_BIM().AddElemento<Proyecto>(typeof(Proyecto), _proyecto);

                    Form _managementForm = new ProjectManagementForm(_proyecto);
                    _managementForm.ShowDialog();
                    this.Hide();
                } 
            }
            else
            {
                MessageBox.Show("Existen datos incompletos");
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cmb_TipoHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmb_TipoHotel.Text)
            {
            	case "Hotel Playa":
                    cmb_SubtipoAlojamiento.Items.Clear();
                    cmb_SubtipoAlojamiento.Items.Add("Disperso");
                    cmb_SubtipoAlojamiento.Items.Add("Semicompacto");
                    cmb_SubtipoAlojamiento.SelectedIndex = 0;
                    break;
                case "Hotel Urbano":
                    cmb_SubtipoAlojamiento.Items.Clear();
                    cmb_SubtipoAlojamiento.Items.Add("Reforma");
                    cmb_SubtipoAlojamiento.Items.Add("Nueva Construcción");
                    cmb_SubtipoAlojamiento.SelectedIndex = 0;
                    break;
            }
        }

        bool CheckIntegrity()
        {
            return txt_superficieParcela.Text != "";
        }

        private void txt_superficieParcela_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}