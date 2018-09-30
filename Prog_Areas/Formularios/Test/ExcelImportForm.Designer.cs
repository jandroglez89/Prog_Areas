namespace Prog_Areas.Formularios.Test
{
    partial class ExcelImportForm
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
            this.gridControlPrograma = new DevExpress.XtraGrid.GridControl();
            this.gridPrograma = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.gridControlDetalle = new DevExpress.XtraGrid.GridControl();
            this.gridDetalle = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPrograma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrograma)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlPrograma
            // 
            this.gridControlPrograma.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlPrograma.Location = new System.Drawing.Point(12, 41);
            this.gridControlPrograma.MainView = this.gridPrograma;
            this.gridControlPrograma.Name = "gridControlPrograma";
            this.gridControlPrograma.Size = new System.Drawing.Size(1196, 565);
            this.gridControlPrograma.TabIndex = 0;
            this.gridControlPrograma.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridPrograma});
            // 
            // gridPrograma
            // 
            this.gridPrograma.GridControl = this.gridControlPrograma;
            this.gridPrograma.Name = "gridPrograma";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Ficheros Excel |*.xls;*.xlsx;*.xlsm";
            // 
            // gridControlDetalle
            // 
            this.gridControlDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlDetalle.Location = new System.Drawing.Point(12, 41);
            this.gridControlDetalle.MainView = this.gridDetalle;
            this.gridControlDetalle.Name = "gridControlDetalle";
            this.gridControlDetalle.Size = new System.Drawing.Size(1196, 565);
            this.gridControlDetalle.TabIndex = 4;
            this.gridControlDetalle.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridDetalle});
            this.gridControlDetalle.Visible = false;
            // 
            // gridDetalle
            // 
            this.gridDetalle.GridControl = this.gridControlDetalle;
            this.gridDetalle.Name = "gridDetalle";
            this.gridDetalle.OptionsView.ColumnAutoWidth = false;
            // 
            // ExcelImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 647);
            this.Controls.Add(this.gridControlDetalle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gridControlPrograma);
            this.Name = "ExcelImportForm";
            this.Text = "ExcelImportForm";
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPrograma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPrograma)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlPrograma;
        private DevExpress.XtraGrid.Views.Grid.GridView gridPrograma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private DevExpress.XtraGrid.GridControl gridControlDetalle;
        private DevExpress.XtraGrid.Views.Grid.GridView gridDetalle;
    }
}