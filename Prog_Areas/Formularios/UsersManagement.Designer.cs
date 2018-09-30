namespace Prog_Areas.Formularios
{
    partial class UsersManagement
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.cmb_access = new System.Windows.Forms.ComboBox();
            this.btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_accept = new DevExpress.XtraEditors.SimpleButton();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre Usuario";
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(106, 21);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(222, 21);
            this.txt_username.TabIndex = 1;
            // 
            // cmb_access
            // 
            this.cmb_access.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_access.FormattingEnabled = true;
            this.cmb_access.Items.AddRange(new object[] {
            "Usuario",
            "Design Manager",
            "BIM"});
            this.cmb_access.Location = new System.Drawing.Point(106, 75);
            this.cmb_access.Name = "cmb_access";
            this.cmb_access.Size = new System.Drawing.Size(222, 21);
            this.cmb_access.TabIndex = 2;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(253, 102);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Cancelar";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_accept
            // 
            this.btn_accept.Location = new System.Drawing.Point(172, 102);
            this.btn_accept.Name = "btn_accept";
            this.btn_accept.Size = new System.Drawing.Size(75, 23);
            this.btn_accept.TabIndex = 4;
            this.btn_accept.Text = "Adicionar";
            this.btn_accept.Click += new System.EventHandler(this.btn_accept_Click);
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(106, 48);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(222, 21);
            this.txt_password.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Acceso";
            // 
            // UsersManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_accept);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.cmb_access);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.label1);
            this.Name = "UsersManagement";
            this.Size = new System.Drawing.Size(353, 146);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.ComboBox cmb_access;
        private DevExpress.XtraEditors.SimpleButton btn_cancel;
        private DevExpress.XtraEditors.SimpleButton btn_accept;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
