using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraEditors;
using Prog_Areas_Plantilla.Modelos;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;
using Prog_Areas.ExtensionMethods;
using Prog_Areas_Proyecto.DataSets;
using static Prog_Areas_Proyecto.DataSets.DataSetProyectos;
using Prog_Areas.ExtensionMethods;

namespace Prog_Areas.Formularios
{
    public partial class UsersListView : XtraUserControl
    {
        DataSetProyectos.UsuarioRow _row;

        public UsersListView()
        {
            InitializeComponent();
            
            usuarioTableAdapter.FillUsuario(dataSetProyectos.Usuario);

            
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            GridView _grid = gridControl1.FocusedView as GridView;

            if (_grid.FocusedRowHandle == -2147483646 || _grid.FocusedRowHandle == 0)
            {
                _row = usuarioTableAdapter.GetUsuarioDataByID(int.Parse(gridView1.GetRowCellValue(1, "Id").ToString())).FirstOrDefault(); 
            }
            else
            {
                _row = usuarioTableAdapter.GetUsuarioDataByID(int.Parse(gridView1.GetRowCellValue(_grid.FocusedRowHandle, "Id").ToString())).FirstOrDefault();
            }

            switch (e.MenuType)
            {
                case GridMenuType.Row:
                    var menu = e.Menu as GridViewMenu;
                    menu.Items.Clear();
                    menu.Items.Add(CreateItem("Modificar"));
                    break;
            }
        }

        DXMenuItem CreateItem(string name)
        {
            DXMenuItem item = null;
            switch (name)
            {
                case "Modificar":
                    item = new DXMenuItem(name, new EventHandler(MostrarDetalles));
                    break;

            }

            return item;
        }

        void MostrarDetalles(object sender, EventArgs e)
        {
            var _thisUser = usuarioTableAdapter.GetUsuarioDataByID(_row.Id).FirstOrDefault();

            Usuario _user = _thisUser.toUsuario();

            MainView.Instance().renderPanel.Controls.Clear();
            MainView.Instance().renderPanel.Controls.Add(new UsersManagement(_user));
            this.Hide();
        }

        string FiltrarNivelAcceso(int accessLevel)
        {
            switch (accessLevel)
            {
                case 3:
                    return "Master";
                case 2:
                    return "BIM";
                case 1:
                    return "Design Manager";
                default:
                    return "Usuario";
            }
        }

        int FiltrarNivelAcceso(string accessLevel)
        {
            switch (accessLevel)
            {
                case "Master":
                    return 3;
                case "BIM":
                    return 2;
                case "Design Manager":
                    return 1;
                default:
                    return 0;
            }
        }
    }
}
