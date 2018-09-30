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
using DevExpress.XtraGrid;
using Prog_Areas_Proyecto.Modelos;
using Prog_Areas_Proyecto.Controllers;

namespace Prog_Areas.Formularios
{
    public partial class DesgloseManagementView : DevExpress.XtraEditors.XtraUserControl
    {
        GridControl _gridControl;
        Proyecto _proyecto;
        System.Windows.Forms.ComboBox _cmbDesglose;
        List<Desglose> _allDesglose;
        List<Desglose> _desgloseByProject;

        public DesgloseManagementView(GridControl gridControl, System.Windows.Forms.ComboBox cmbDesglose, Proyecto proyecto)
        {
            InitializeComponent();

            _gridControl = gridControl;
            _proyecto = proyecto;
            _cmbDesglose = cmbDesglose;
            UpdateListBox();
        }

        void UpdateListBox()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            _cmbDesglose.Items.Clear();

            _allDesglose = new DB_BIM().GetAllElements<Desglose>().GroupBy(x => x.Value).Select(x => x.FirstOrDefault()).OrderBy(x => x.Value).ToList();
            _desgloseByProject = new DB_BIM().GetElements<Desglose>(x => x.Proyecto == _proyecto.Id).GroupBy(x => x.Value).Select(x => x.FirstOrDefault()).OrderBy(x => x.Value).ToList();

            foreach (var item in _allDesglose)
            {
                listBox1.Items.Add(item.Value);
            }
            
            foreach (var item in _desgloseByProject)
            {
                listBox2.Items.Add(item.Value);
                _cmbDesglose.Items.Add(item.Value);
            }

            if (listBox1.Items.Count > 0 && listBox2.Items.Count > 0)
            {
                listBox1.SelectedIndex = 0;
                listBox2.SelectedIndex = 0; 
            }

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Hide();
            _gridControl.Visible = true;
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            if (txt_desglose.Text != "")
            {
                Desglose _desglose = new Desglose()
                {
                    Proyecto = _proyecto.Id,
                    Value = txt_desglose.Text
                };

                var _record = new DB_BIM().GetSingleElement<Desglose>(x => x.Value == _desglose.Value && x.Proyecto == _desglose.Proyecto);

                if (_record == null)
                {
                    new DB_BIM().AddElemento<Desglose>(typeof(Desglose), _desglose);
                    UpdateListBox();
                }
            }
            else
            {
                MessageBox.Show("El nuevo desglose debe tener un nombre");
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {

            using (var db = new DB_BIM())
            {
                Desglose _desglose = new Desglose()
                {
                    Proyecto = _proyecto.Id,
                    Value = listBox1.SelectedItem.ToString()
                };

                var _proyectoDesglose = db.GetSingleElement<Desglose>(x => x.Value == _desglose.Value && x.Proyecto == _desglose.Proyecto);
                if (_proyectoDesglose == null)
                {
                    db.AddElemento<Desglose>(typeof(Desglose), _desglose);
                    UpdateListBox();
                }
                    
            }
            
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            using (var db = new DB_BIM())
            {
                Desglose _desglose = new Desglose()
                {
                    Proyecto = _proyecto.Id,
                    Value = listBox2.SelectedItem.ToString()
                };

                db.DeleteElement<Desglose>(x => x.Value == _desglose.Value && x.Proyecto == _desglose.Proyecto, typeof(Desglose));

                UpdateListBox();
            }
        }
    }
}
