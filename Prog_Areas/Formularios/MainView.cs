
using Prog_Areas_Proyecto.Controllers;
using Prog_Areas_Plantilla.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prog_Areas_Plantilla.Controllers;
using DevExpress.XtraSplashScreen;

namespace Prog_Areas.Formularios
{
    public partial class MainView : Form
    {
        private static MainView _mainView;

        public MainView()
        {
            InitializeComponent();

            //backgroundWorker1.RunWorkerAsync();

            switch (Program._autenticatedUser.access_Level)
            {
                case 3:
                    ribbonControl1.Pages.GetPageByName("usuarios_Page").Visible = true;
                    break;
                case 2:
                    ribbonControl1.Pages.GetPageByName("usuarios_Page").Visible = true;
                    break;
                default:
                    ribbonControl1.Pages.GetPageByName("usuarios_Page").Visible = false;
                    break;
            }

            barStaticItem2.Caption = "Hola, " + Program._autenticatedUser.username;

            PageContent("Proyectos");
        }

        public static MainView Instance()
        {
            return _mainView ?? (_mainView = new MainView());
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            renderPanel.Controls.Clear();
            renderPanel.Controls.Add(new LocalManagementView(null));
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            renderPanel.Controls.Clear();
            //renderPanel.Controls.Add(new LocalRefManagementView());
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            renderPanel.Controls.Clear();
            renderPanel.Controls.Add(new ProjectManagementView(null));
        }

        private void ribbonControl1_SelectedPageChanged(object sender, EventArgs e)
        {
            PageContent(ribbonControl1.SelectedPage.Text);
        }

        void PageContent(string tabname)
        {
            switch (tabname)
            {
                case "Proyectos":
                    renderPanel.Controls.Clear();
                    renderPanel.Controls.Add(new ProjectListingView());
                    break;
                case "Control de Usuarios":
                    renderPanel.Controls.Clear();
                    renderPanel.Controls.Add(new UsersListView());
                    break;
                case "Locales":
                    renderPanel.Controls.Clear();
                    break;
                case "Locales Base":
                    renderPanel.Controls.Clear();
                    renderPanel.Controls.Add(new LocalListView());
                    break;
            }
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            renderPanel.Controls.Clear();
            renderPanel.Controls.Add(new UsersManagement(null));
        }

        void CheckLocalList()
        {
            //if (Program._locales.Count < LocalController.GetLastLocalRecord())
            //{
            //    Program._locales.AddRange(LocalController.GetLocalesFromRange(Program._locales.Count));
            //}
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            CheckLocalList();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult _dialog = MessageBox.Show("¿Está seguro que quiere reiniciar las plantillas?", "", MessageBoxButtons.YesNo);
            if (_dialog != DialogResult.Yes) return;
            SplashScreenManager.ShowForm(typeof(WaitScreen));
            Clean_And_Refill.CleanAllTemplates();
            SplashScreenManager.CloseForm();
        }
    }
}
