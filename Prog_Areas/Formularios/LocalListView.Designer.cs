namespace Prog_Areas.Formularios
{
    partial class LocalListView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataTable1GridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRoomId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKey_Name = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHabitacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubsistemaTipo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSubsistemaArea = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrupoLocales = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataTable1BindingSource
            // 
            this.dataTable1BindingSource.DataMember = "DataTable1";
            // 
            // dataTable1GridControl
            // 
            this.dataTable1GridControl.DataSource = this.dataTable1BindingSource;
            this.dataTable1GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTable1GridControl.Location = new System.Drawing.Point(0, 0);
            this.dataTable1GridControl.MainView = this.gridView1;
            this.dataTable1GridControl.Name = "dataTable1GridControl";
            this.dataTable1GridControl.Size = new System.Drawing.Size(1131, 547);
            this.dataTable1GridControl.TabIndex = 1;
            this.dataTable1GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRoomId,
            this.colKey_Name,
            this.colHabitacion,
            this.colSubsistemaTipo,
            this.colSubsistemaArea,
            this.colGrupoLocales});
            this.gridView1.GridControl = this.dataTable1GridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            // 
            // colRoomId
            // 
            this.colRoomId.FieldName = "RoomId";
            this.colRoomId.Name = "colRoomId";
            this.colRoomId.OptionsColumn.AllowEdit = false;
            this.colRoomId.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colRoomId.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colRoomId.OptionsColumn.AllowMove = false;
            this.colRoomId.OptionsColumn.AllowShowHide = false;
            this.colRoomId.OptionsColumn.AllowSize = false;
            this.colRoomId.Visible = true;
            this.colRoomId.VisibleIndex = 0;
            // 
            // colKey_Name
            // 
            this.colKey_Name.FieldName = "Key_Name";
            this.colKey_Name.Name = "colKey_Name";
            this.colKey_Name.OptionsColumn.AllowEdit = false;
            this.colKey_Name.Visible = true;
            this.colKey_Name.VisibleIndex = 1;
            // 
            // colHabitacion
            // 
            this.colHabitacion.FieldName = "Habitacion";
            this.colHabitacion.Name = "colHabitacion";
            this.colHabitacion.OptionsColumn.AllowEdit = false;
            this.colHabitacion.Visible = true;
            this.colHabitacion.VisibleIndex = 2;
            // 
            // colSubsistemaTipo
            // 
            this.colSubsistemaTipo.FieldName = "Subsistema Tipo";
            this.colSubsistemaTipo.Name = "colSubsistemaTipo";
            this.colSubsistemaTipo.OptionsColumn.AllowEdit = false;
            this.colSubsistemaTipo.Visible = true;
            this.colSubsistemaTipo.VisibleIndex = 3;
            // 
            // colSubsistemaArea
            // 
            this.colSubsistemaArea.FieldName = "Subsistema Area";
            this.colSubsistemaArea.Name = "colSubsistemaArea";
            this.colSubsistemaArea.OptionsColumn.AllowEdit = false;
            this.colSubsistemaArea.Visible = true;
            this.colSubsistemaArea.VisibleIndex = 4;
            // 
            // colGrupoLocales
            // 
            this.colGrupoLocales.FieldName = "Grupo Locales";
            this.colGrupoLocales.Name = "colGrupoLocales";
            this.colGrupoLocales.OptionsColumn.AllowEdit = false;
            this.colGrupoLocales.Visible = true;
            this.colGrupoLocales.VisibleIndex = 5;
            // 
            // LocalListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataTable1GridControl);
            this.Name = "LocalListView";
            this.Size = new System.Drawing.Size(1131, 547);
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        //private DataSets.DataSetLocales dataSetLocales;
        private System.Windows.Forms.BindingSource dataTable1BindingSource;
        //private DataSets.DataSetLocalesTableAdapters.DataTable1TableAdapter dataTable1TableAdapter;
        //private DataSets.DataSetLocalesTableAdapters.TableAdapterManager tableAdapterManager;
        private DevExpress.XtraGrid.GridControl dataTable1GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colRoomId;
        private DevExpress.XtraGrid.Columns.GridColumn colKey_Name;
        private DevExpress.XtraGrid.Columns.GridColumn colHabitacion;
        private DevExpress.XtraGrid.Columns.GridColumn colSubsistemaTipo;
        private DevExpress.XtraGrid.Columns.GridColumn colSubsistemaArea;
        private DevExpress.XtraGrid.Columns.GridColumn colGrupoLocales;
    }
}
