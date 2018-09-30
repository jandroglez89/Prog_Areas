namespace Prog_Areas.Formularios
{
    partial class ProjectListingView
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.dataSetProyectos1 = new Prog_Areas_Proyecto.DataSets.DataSetProyectos();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colidobra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.collocalizacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colcodigo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfechacomienzo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colfechafin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.obrasTableAdapter1 = new Prog_Areas_Proyecto.DataSets.DataSetProyectosTableAdapters.obrasTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProyectos1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataMember = "obras";
            this.gridControl1.DataSource = this.dataSetProyectos1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1272, 540);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // dataSetProyectos1
            // 
            this.dataSetProyectos1.DataSetName = "DataSetProyectos";
            this.dataSetProyectos1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colidobra,
            this.colnombre,
            this.collocalizacion,
            this.colcodigo,
            this.colfechacomienzo,
            this.colfechafin});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupedColumns = true;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colidobra
            // 
            this.colidobra.FieldName = "idobra";
            this.colidobra.Name = "colidobra";
            this.colidobra.Visible = true;
            this.colidobra.VisibleIndex = 0;
            // 
            // colnombre
            // 
            this.colnombre.FieldName = "nombre";
            this.colnombre.Name = "colnombre";
            this.colnombre.Visible = true;
            this.colnombre.VisibleIndex = 1;
            // 
            // collocalizacion
            // 
            this.collocalizacion.FieldName = "localizacion";
            this.collocalizacion.Name = "collocalizacion";
            this.collocalizacion.Visible = true;
            this.collocalizacion.VisibleIndex = 2;
            // 
            // colcodigo
            // 
            this.colcodigo.FieldName = "codigo";
            this.colcodigo.Name = "colcodigo";
            this.colcodigo.Visible = true;
            this.colcodigo.VisibleIndex = 3;
            // 
            // colfechacomienzo
            // 
            this.colfechacomienzo.FieldName = "fechacomienzo";
            this.colfechacomienzo.Name = "colfechacomienzo";
            this.colfechacomienzo.Visible = true;
            this.colfechacomienzo.VisibleIndex = 4;
            // 
            // colfechafin
            // 
            this.colfechafin.FieldName = "fechafin";
            this.colfechafin.Name = "colfechafin";
            this.colfechafin.Visible = true;
            this.colfechafin.VisibleIndex = 5;
            // 
            // obrasTableAdapter1
            // 
            this.obrasTableAdapter1.ClearBeforeFill = true;
            // 
            // ProjectListingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "ProjectListingView";
            this.Size = new System.Drawing.Size(1272, 540);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProyectos1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private Prog_Areas_Proyecto.DataSets.DataSetProyectos dataSetProyectos1;
        private Prog_Areas_Proyecto.DataSets.DataSetProyectosTableAdapters.obrasTableAdapter obrasTableAdapter1;
        private DevExpress.XtraGrid.Columns.GridColumn colidobra;
        private DevExpress.XtraGrid.Columns.GridColumn colnombre;
        private DevExpress.XtraGrid.Columns.GridColumn collocalizacion;
        private DevExpress.XtraGrid.Columns.GridColumn colcodigo;
        private DevExpress.XtraGrid.Columns.GridColumn colfechacomienzo;
        private DevExpress.XtraGrid.Columns.GridColumn colfechafin;
    }
}
