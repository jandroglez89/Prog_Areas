using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Prog_Areas_Plantilla.Modelos;
using Prog_Areas_Plantilla.Controllers;
using Prog_Areas.ExtensionMethods;

namespace Prog_Areas.Formularios.Test
{
    public partial class SelectLocalBaseForm : XtraForm
    {
        public string MyLocal { get; set; }
        /*
        public SelectLocalBaseForm(string roomName, string Cod)
        {
            InitializeComponent();

            label1.Text = roomName;

            var _grupos = DataBaseController.GetSingleRecord<T_Grupo_Locales>(new DB_PLANTILLA(), x => x.Cod1 == Cod).Id;
            var _localesTipobyCod = DataBaseController.GetRecordsBy<T_LocalTipo>(new DB_PLANTILLA(), x => x.Grupo_Locales == _grupos);

            if (_localesTipobyCod.Count == 0)
            {
                var _locales = DataBaseController.GetAllRecords<T_Local>(new DB_PLANTILLA());
                foreach (var local in _locales)
                {
                    comboBox1.Items.Add(local.Key_Name);
                }
            }


            foreach (var item in _localesTipobyCod)
            {
                var _locales = DataBaseController.GetRecordsBy<T_Local>(new DB_PLANTILLA(), x => x.Local_Tipo == item.Id);
                foreach (var local in _locales)
                {
                    comboBox1.Items.Add(local.Key_Name);
                }
            }

            comboBox1.SelectedIndex = 0;

            
        }*/

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyLocal = comboBox1.Text;
            ExcelImportForm.ThisLocal = DataBaseController.GetSingleRecord<T_Local>(new DB_PLANTILLA(), x => x.Key_Name == MyLocal).ToProject();
        }
    }
}