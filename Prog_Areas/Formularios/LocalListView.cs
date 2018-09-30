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
using System.Data.Entity;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Menu;
using DevExpress.Utils.Menu;

namespace Prog_Areas.Formularios
{
    public partial class LocalListView : DevExpress.XtraEditors.XtraUserControl
    {
        //DataSets.DataSetLocales.DataTable1Row _local;

        public LocalListView()
        {
            InitializeComponent();
            //dataTable1TableAdapter.Fill(dataSetLocales.DataTable1);
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            GridView _grid = dataTable1GridControl.FocusedView as GridView;

            //_local = _grid.FocusedRowHandle == -2147483646 ? dataTable1TableAdapter.GetDataByID(int.Parse(gridView1.GetRowCellValue(0, "RoomId").ToString())).FirstOrDefault() : dataTable1TableAdapter.GetDataByID(int.Parse(gridView1.GetRowCellValue(_grid.FocusedRowHandle, "RoomId").ToString())).FirstOrDefault();

            switch (e.MenuType)
            {
                case DevExpress.XtraGrid.Views.Grid.GridMenuType.Row:
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
            //var _thisLocal = LocalController.GetLocalByRoomId(_local.RoomId);
            //MainView.Instance().renderPanel.Controls.Clear();
            //MainView.Instance().renderPanel.Controls.Add(new LocalManagementView(_thisLocal));
            //this.Hide();
        }
    }
}
