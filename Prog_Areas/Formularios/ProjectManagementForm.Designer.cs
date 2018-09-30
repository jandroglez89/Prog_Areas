namespace Prog_Areas.Formularios
{
    partial class ProjectManagementForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectManagementForm));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.numeric_MaximaAltura = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_tipoAlojamiento = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_subtipoAlojamiento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_TipoHotel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Localizacion = new System.Windows.Forms.TextBox();
            this.numeric_Categoria = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numeric_cantHabitaciones = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.btn_updateProject = new DevExpress.XtraEditors.SimpleButton();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btn_importarExcel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btn_importarProyecto = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.dataSetLocal_Proyecto1 = new Prog_Areas_Proyecto.DataSets.DataSetProyectos();
            this.dataSetProyectos1 = new Prog_Areas_Proyecto.DataSets.DataSetProyectos();
            this.localesByProyIDTableAdapter1 = new Prog_Areas_Proyecto.DataSets.DataSetProyectosTableAdapters.LocalesByProyIDTableAdapter();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.label13 = new System.Windows.Forms.Label();
            this.cmb_Desglose = new System.Windows.Forms.ComboBox();
            this.numeric_cantidad = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.bnt_add = new DevExpress.XtraEditors.SimpleButton();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_nombreLocal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmb_LocalTipo = new System.Windows.Forms.ComboBox();
            this.btn_ExportExcel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_MaximaAltura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Categoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_cantHabitaciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetLocal_Proyecto1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProyectos1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_cantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1347, 614);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl1_ProcessGridKey);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelControl1.Controls.Add(this.numeric_MaximaAltura);
            this.panelControl1.Controls.Add(this.label9);
            this.panelControl1.Controls.Add(this.label8);
            this.panelControl1.Controls.Add(this.txt_tipoAlojamiento);
            this.panelControl1.Controls.Add(this.label7);
            this.panelControl1.Controls.Add(this.txt_subtipoAlojamiento);
            this.panelControl1.Controls.Add(this.label6);
            this.panelControl1.Controls.Add(this.txt_TipoHotel);
            this.panelControl1.Controls.Add(this.label5);
            this.panelControl1.Controls.Add(this.txt_Localizacion);
            this.panelControl1.Controls.Add(this.numeric_Categoria);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.numeric_cantHabitaciones);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.txt_codigo);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.txt_nombre);
            this.panelControl1.Controls.Add(this.btn_updateProject);
            this.panelControl1.Location = new System.Drawing.Point(12, 147);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(816, 164);
            this.panelControl1.TabIndex = 1;
            // 
            // numeric_MaximaAltura
            // 
            this.numeric_MaximaAltura.Location = new System.Drawing.Point(564, 86);
            this.numeric_MaximaAltura.Name = "numeric_MaximaAltura";
            this.numeric_MaximaAltura.Size = new System.Drawing.Size(247, 21);
            this.numeric_MaximaAltura.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(450, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Máxima Altura";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(450, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Tipo Alojamiento";
            // 
            // txt_tipoAlojamiento
            // 
            this.txt_tipoAlojamiento.Enabled = false;
            this.txt_tipoAlojamiento.Location = new System.Drawing.Point(564, 59);
            this.txt_tipoAlojamiento.Name = "txt_tipoAlojamiento";
            this.txt_tipoAlojamiento.Size = new System.Drawing.Size(247, 21);
            this.txt_tipoAlojamiento.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(450, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Subtipo Hotel";
            // 
            // txt_subtipoAlojamiento
            // 
            this.txt_subtipoAlojamiento.Enabled = false;
            this.txt_subtipoAlojamiento.Location = new System.Drawing.Point(564, 32);
            this.txt_subtipoAlojamiento.Name = "txt_subtipoAlojamiento";
            this.txt_subtipoAlojamiento.Size = new System.Drawing.Size(247, 21);
            this.txt_subtipoAlojamiento.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(450, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Tipo Hotel";
            // 
            // txt_TipoHotel
            // 
            this.txt_TipoHotel.Enabled = false;
            this.txt_TipoHotel.Location = new System.Drawing.Point(564, 5);
            this.txt_TipoHotel.Name = "txt_TipoHotel";
            this.txt_TipoHotel.Size = new System.Drawing.Size(247, 21);
            this.txt_TipoHotel.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Localización";
            // 
            // txt_Localizacion
            // 
            this.txt_Localizacion.Enabled = false;
            this.txt_Localizacion.Location = new System.Drawing.Point(119, 59);
            this.txt_Localizacion.Name = "txt_Localizacion";
            this.txt_Localizacion.Size = new System.Drawing.Size(247, 21);
            this.txt_Localizacion.TabIndex = 10;
            // 
            // numeric_Categoria
            // 
            this.numeric_Categoria.Location = new System.Drawing.Point(119, 113);
            this.numeric_Categoria.Name = "numeric_Categoria";
            this.numeric_Categoria.Size = new System.Drawing.Size(247, 21);
            this.numeric_Categoria.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Categoría";
            // 
            // numeric_cantHabitaciones
            // 
            this.numeric_cantHabitaciones.Location = new System.Drawing.Point(119, 86);
            this.numeric_cantHabitaciones.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numeric_cantHabitaciones.Name = "numeric_cantHabitaciones";
            this.numeric_cantHabitaciones.Size = new System.Drawing.Size(247, 21);
            this.numeric_cantHabitaciones.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Número Habitaciones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Código";
            // 
            // txt_codigo
            // 
            this.txt_codigo.Enabled = false;
            this.txt_codigo.Location = new System.Drawing.Point(119, 32);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(247, 21);
            this.txt_codigo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Enabled = false;
            this.txt_nombre.Location = new System.Drawing.Point(119, 5);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(247, 21);
            this.txt_nombre.TabIndex = 1;
            // 
            // btn_updateProject
            // 
            this.btn_updateProject.Location = new System.Drawing.Point(736, 136);
            this.btn_updateProject.Name = "btn_updateProject";
            this.btn_updateProject.Size = new System.Drawing.Size(75, 23);
            this.btn_updateProject.TabIndex = 0;
            this.btn_updateProject.Text = "Actualizar";
            this.btn_updateProject.Click += new System.EventHandler(this.btn_updateProject_Click);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btn_importarExcel,
            this.barButtonItem1,
            this.barButtonItem2,
            this.btn_importarProyecto});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 5;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1375, 141);
            // 
            // btn_importarExcel
            // 
            this.btn_importarExcel.Caption = "Importar Excel";
            this.btn_importarExcel.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btn_importarExcel.Id = 1;
            this.btn_importarExcel.Name = "btn_importarExcel";
            this.btn_importarExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_importarExcel_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Modificar Ambientes";
            this.barButtonItem1.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Gestionar Obj. Obra";
            this.barButtonItem2.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barButtonItem2.Id = 3;
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // btn_importarProyecto
            // 
            this.btn_importarProyecto.Caption = "Importar Proyecto";
            this.btn_importarProyecto.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btn_importarProyecto.Id = 4;
            this.btn_importarProyecto.Name = "btn_importarProyecto";
            this.btn_importarProyecto.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_importarProyecto_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Opciones";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_importarExcel);
            this.ribbonPageGroup1.ItemLinks.Add(this.btn_importarProyecto);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Importar";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Acabados";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Obj. Obra";
            // 
            // dataSetLocal_Proyecto1
            // 
            this.dataSetLocal_Proyecto1.DataSetName = "DataSetProyectos";
            this.dataSetLocal_Proyecto1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSetProyectos1
            // 
            this.dataSetProyectos1.DataSetName = "DataSetProyectos";
            this.dataSetProyectos1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // localesByProyIDTableAdapter1
            // 
            this.localesByProyIDTableAdapter1.ClearBeforeFill = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 941);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1351, 23);
            this.progressBar1.TabIndex = 2;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.label13);
            this.panelControl2.Controls.Add(this.cmb_Desglose);
            this.panelControl2.Controls.Add(this.numeric_cantidad);
            this.panelControl2.Controls.Add(this.label12);
            this.panelControl2.Controls.Add(this.bnt_add);
            this.panelControl2.Controls.Add(this.label11);
            this.panelControl2.Controls.Add(this.txt_nombreLocal);
            this.panelControl2.Controls.Add(this.label10);
            this.panelControl2.Controls.Add(this.cmb_LocalTipo);
            this.panelControl2.Location = new System.Drawing.Point(834, 147);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(396, 164);
            this.panelControl2.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Obj. Obra";
            // 
            // cmb_Desglose
            // 
            this.cmb_Desglose.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_Desglose.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_Desglose.FormattingEnabled = true;
            this.cmb_Desglose.Location = new System.Drawing.Point(85, 62);
            this.cmb_Desglose.Name = "cmb_Desglose";
            this.cmb_Desglose.Size = new System.Drawing.Size(306, 21);
            this.cmb_Desglose.TabIndex = 24;
            // 
            // numeric_cantidad
            // 
            this.numeric_cantidad.Location = new System.Drawing.Point(85, 89);
            this.numeric_cantidad.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numeric_cantidad.Name = "numeric_cantidad";
            this.numeric_cantidad.Size = new System.Drawing.Size(306, 21);
            this.numeric_cantidad.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Cantidad";
            // 
            // bnt_add
            // 
            this.bnt_add.Location = new System.Drawing.Point(316, 136);
            this.bnt_add.Name = "bnt_add";
            this.bnt_add.Size = new System.Drawing.Size(75, 23);
            this.bnt_add.TabIndex = 20;
            this.bnt_add.Text = "Adicionar";
            this.bnt_add.Click += new System.EventHandler(this.bnt_add_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 35);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Nombre_Local";
            // 
            // txt_nombreLocal
            // 
            this.txt_nombreLocal.Location = new System.Drawing.Point(85, 32);
            this.txt_nombreLocal.Name = "txt_nombreLocal";
            this.txt_nombreLocal.Size = new System.Drawing.Size(306, 21);
            this.txt_nombreLocal.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Key Rooms";
            // 
            // cmb_LocalTipo
            // 
            this.cmb_LocalTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmb_LocalTipo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmb_LocalTipo.FormattingEnabled = true;
            this.cmb_LocalTipo.Location = new System.Drawing.Point(85, 5);
            this.cmb_LocalTipo.Name = "cmb_LocalTipo";
            this.cmb_LocalTipo.Size = new System.Drawing.Size(306, 21);
            this.cmb_LocalTipo.TabIndex = 0;
            this.cmb_LocalTipo.SelectedIndexChanged += new System.EventHandler(this.cmb_LocalTipo_SelectedIndexChanged);
            // 
            // btn_ExportExcel
            // 
            this.btn_ExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ExportExcel.Image = ((System.Drawing.Image)(resources.GetObject("btn_ExportExcel.Image")));
            this.btn_ExportExcel.Location = new System.Drawing.Point(1288, 236);
            this.btn_ExportExcel.Name = "btn_ExportExcel";
            this.btn_ExportExcel.Size = new System.Drawing.Size(75, 75);
            this.btn_ExportExcel.TabIndex = 6;
            this.btn_ExportExcel.Click += new System.EventHandler(this.btn_ExportExcel_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl3.Controls.Add(this.gridControl1);
            this.panelControl3.Location = new System.Drawing.Point(12, 317);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1351, 618);
            this.panelControl3.TabIndex = 8;
            // 
            // ProjectManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1375, 974);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.btn_ExportExcel);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.panelControl1);
            this.Name = "ProjectManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProjectManagementForm";
            this.Activated += new System.EventHandler(this.ProjectManagementForm_Activated);
            this.Shown += new System.EventHandler(this.ProjectManagementForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_MaximaAltura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Categoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_cantHabitaciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetLocal_Proyecto1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProyectos1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_cantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_nombre;
        private DevExpress.XtraEditors.SimpleButton btn_updateProject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_codigo;
        public DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        //private DataSets.DataSetLocal_Proyecto dataSetLocal_Proyecto1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private System.Windows.Forms.NumericUpDown numeric_MaximaAltura;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_tipoAlojamiento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_subtipoAlojamiento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_TipoHotel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Localizacion;
        private System.Windows.Forms.NumericUpDown numeric_Categoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numeric_cantHabitaciones;
        private DevExpress.XtraBars.BarButtonItem btn_importarExcel;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private Prog_Areas_Proyecto.DataSets.DataSetProyectos dataSetLocal_Proyecto1;
        private Prog_Areas_Proyecto.DataSets.DataSetProyectos dataSetProyectos1;
        private Prog_Areas_Proyecto.DataSets.DataSetProyectosTableAdapters.LocalesByProyIDTableAdapter localesByProyIDTableAdapter1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_nombreLocal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmb_LocalTipo;
        private DevExpress.XtraEditors.SimpleButton bnt_add;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numeric_cantidad;
        private DevExpress.XtraEditors.SimpleButton btn_ExportExcel;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private System.Windows.Forms.ComboBox cmb_Desglose;
        private DevExpress.XtraBars.BarButtonItem btn_importarProyecto;
    }
}