namespace Prog_Areas.Formularios
{
    partial class AddProjectForm
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
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_codigo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numeric_categoria = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_TipoHotel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmb_SubtipoAlojamiento = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmb_TipoAlojamiento = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numeric_MaximaAltura = new System.Windows.Forms.NumericUpDown();
            this.btn_Cancelar = new DevExpress.XtraEditors.SimpleButton();
            this.btn_aceptar = new DevExpress.XtraEditors.SimpleButton();
            this.numeric_cantHabitaciones = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_localizacion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_superficieParcela = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_categoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_MaximaAltura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_cantHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_nombre
            // 
            this.txt_nombre.Enabled = false;
            this.txt_nombre.Location = new System.Drawing.Point(132, 6);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(151, 21);
            this.txt_nombre.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Código";
            // 
            // txt_codigo
            // 
            this.txt_codigo.Enabled = false;
            this.txt_codigo.Location = new System.Drawing.Point(132, 33);
            this.txt_codigo.Name = "txt_codigo";
            this.txt_codigo.Size = new System.Drawing.Size(151, 21);
            this.txt_codigo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cantidad Habitaciones";
            // 
            // numeric_categoria
            // 
            this.numeric_categoria.Location = new System.Drawing.Point(132, 87);
            this.numeric_categoria.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numeric_categoria.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numeric_categoria.Name = "numeric_categoria";
            this.numeric_categoria.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numeric_categoria.Size = new System.Drawing.Size(151, 21);
            this.numeric_categoria.TabIndex = 6;
            this.numeric_categoria.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Categoría";
            // 
            // cmb_TipoHotel
            // 
            this.cmb_TipoHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TipoHotel.FormattingEnabled = true;
            this.cmb_TipoHotel.Items.AddRange(new object[] {
            "Hotel Playa",
            "Hotel Urbano"});
            this.cmb_TipoHotel.Location = new System.Drawing.Point(426, 6);
            this.cmb_TipoHotel.Name = "cmb_TipoHotel";
            this.cmb_TipoHotel.Size = new System.Drawing.Size(151, 21);
            this.cmb_TipoHotel.TabIndex = 8;
            this.cmb_TipoHotel.SelectedIndexChanged += new System.EventHandler(this.cmb_TipoHotel_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(306, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Tipo Hotel";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(306, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Subtipo Hotel";
            // 
            // cmb_SubtipoAlojamiento
            // 
            this.cmb_SubtipoAlojamiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_SubtipoAlojamiento.FormattingEnabled = true;
            this.cmb_SubtipoAlojamiento.Location = new System.Drawing.Point(426, 33);
            this.cmb_SubtipoAlojamiento.Name = "cmb_SubtipoAlojamiento";
            this.cmb_SubtipoAlojamiento.Size = new System.Drawing.Size(151, 21);
            this.cmb_SubtipoAlojamiento.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(306, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Tipo Alojamiento";
            // 
            // cmb_TipoAlojamiento
            // 
            this.cmb_TipoAlojamiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_TipoAlojamiento.FormattingEnabled = true;
            this.cmb_TipoAlojamiento.Items.AddRange(new object[] {
            "Hotel",
            "Villa",
            "Aparthotel",
            "Motel"});
            this.cmb_TipoAlojamiento.Location = new System.Drawing.Point(426, 60);
            this.cmb_TipoAlojamiento.Name = "cmb_TipoAlojamiento";
            this.cmb_TipoAlojamiento.Size = new System.Drawing.Size(151, 21);
            this.cmb_TipoAlojamiento.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(306, 116);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Máxima Altura";
            // 
            // numeric_MaximaAltura
            // 
            this.numeric_MaximaAltura.Location = new System.Drawing.Point(426, 114);
            this.numeric_MaximaAltura.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_MaximaAltura.Name = "numeric_MaximaAltura";
            this.numeric_MaximaAltura.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numeric_MaximaAltura.Size = new System.Drawing.Size(151, 21);
            this.numeric_MaximaAltura.TabIndex = 14;
            this.numeric_MaximaAltura.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.Location = new System.Drawing.Point(502, 152);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancelar.TabIndex = 16;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.Location = new System.Drawing.Point(421, 152);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(75, 23);
            this.btn_aceptar.TabIndex = 17;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.Click += new System.EventHandler(this.btn_aceptar_Click);
            // 
            // numeric_cantHabitaciones
            // 
            this.numeric_cantHabitaciones.Location = new System.Drawing.Point(426, 87);
            this.numeric_cantHabitaciones.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numeric_cantHabitaciones.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_cantHabitaciones.Name = "numeric_cantHabitaciones";
            this.numeric_cantHabitaciones.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.numeric_cantHabitaciones.Size = new System.Drawing.Size(151, 21);
            this.numeric_cantHabitaciones.TabIndex = 18;
            this.numeric_cantHabitaciones.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Localización";
            // 
            // txt_localizacion
            // 
            this.txt_localizacion.Enabled = false;
            this.txt_localizacion.Location = new System.Drawing.Point(132, 60);
            this.txt_localizacion.Name = "txt_localizacion";
            this.txt_localizacion.Size = new System.Drawing.Size(151, 21);
            this.txt_localizacion.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 117);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Superficie Parcela (ha)";
            // 
            // txt_superficieParcela
            // 
            this.txt_superficieParcela.Location = new System.Drawing.Point(132, 114);
            this.txt_superficieParcela.Name = "txt_superficieParcela";
            this.txt_superficieParcela.Size = new System.Drawing.Size(151, 21);
            this.txt_superficieParcela.TabIndex = 21;
            this.txt_superficieParcela.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_superficieParcela_KeyPress);
            // 
            // AddProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 187);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_superficieParcela);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_localizacion);
            this.Controls.Add(this.numeric_cantHabitaciones);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numeric_MaximaAltura);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmb_TipoAlojamiento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmb_SubtipoAlojamiento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmb_TipoHotel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numeric_categoria);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_codigo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_nombre);
            this.Name = "AddProjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddProjectForm";
            ((System.ComponentModel.ISupportInitialize)(this.numeric_categoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_MaximaAltura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_cantHabitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_codigo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numeric_categoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_TipoHotel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmb_SubtipoAlojamiento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmb_TipoAlojamiento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numeric_MaximaAltura;
        private DevExpress.XtraEditors.SimpleButton btn_Cancelar;
        private DevExpress.XtraEditors.SimpleButton btn_aceptar;
        private System.Windows.Forms.NumericUpDown numeric_cantHabitaciones;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_localizacion;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_superficieParcela;
    }
}