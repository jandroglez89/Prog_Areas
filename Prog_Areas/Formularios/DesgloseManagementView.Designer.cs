namespace Prog_Areas.Formularios
{
    partial class DesgloseManagementView
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btn_add = new DevExpress.XtraEditors.SimpleButton();
            this.txt_desglose = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_del = new DevExpress.XtraEditors.SimpleButton();
            this.btn_new = new DevExpress.XtraEditors.SimpleButton();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(18, 93);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(157, 264);
            this.listBox1.TabIndex = 0;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(203, 176);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(30, 30);
            this.btn_add.TabIndex = 1;
            this.btn_add.Text = ">";
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txt_desglose
            // 
            this.txt_desglose.Location = new System.Drawing.Point(71, 9);
            this.txt_desglose.Name = "txt_desglose";
            this.txt_desglose.Size = new System.Drawing.Size(219, 21);
            this.txt_desglose.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Obj. Obra";
            // 
            // btn_del
            // 
            this.btn_del.Location = new System.Drawing.Point(203, 226);
            this.btn_del.Name = "btn_del";
            this.btn_del.Size = new System.Drawing.Size(30, 30);
            this.btn_del.TabIndex = 4;
            this.btn_del.Text = "<";
            this.btn_del.Click += new System.EventHandler(this.btn_del_Click);
            // 
            // btn_new
            // 
            this.btn_new.Location = new System.Drawing.Point(296, 7);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(75, 23);
            this.btn_new.TabIndex = 5;
            this.btn_new.Text = "Añadir";
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(259, 93);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(157, 264);
            this.listBox2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Listado Obj. Obra";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Obj. Obra de Proyecto";
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(341, 363);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 9;
            this.btn_cancel.Text = "Cancelar";
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // DesgloseManagementView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.btn_new);
            this.Controls.Add(this.btn_del);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_desglose);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.listBox1);
            this.Name = "DesgloseManagementView";
            this.Size = new System.Drawing.Size(437, 407);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private DevExpress.XtraEditors.SimpleButton btn_add;
        private System.Windows.Forms.TextBox txt_desglose;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btn_del;
        private DevExpress.XtraEditors.SimpleButton btn_new;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btn_cancel;
    }
}
