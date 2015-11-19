namespace CMI_WSDLCreator
{
    partial class frmParametersCreator
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
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblMinOccurs = new System.Windows.Forms.Label();
            this.lblMaxOccurs = new System.Windows.Forms.Label();
            this.cboMinOccurs = new System.Windows.Forms.ComboBox();
            this.cboMaxOccurs = new System.Windows.Forms.ComboBox();
            this.lblRuta = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cboBO = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLista = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtContenedor = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboTipo
            // 
            this.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "int",
            "string",
            "double",
            "boolean",
            "base64Binary"});
            this.cboTipo.Location = new System.Drawing.Point(106, 61);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(186, 21);
            this.cboTipo.TabIndex = 0;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(12, 11);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(106, 8);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(186, 20);
            this.txtNombre.TabIndex = 3;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(12, 64);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(31, 13);
            this.lblTipo.TabIndex = 4;
            this.lblTipo.Text = "Tipo:";
            // 
            // lblMinOccurs
            // 
            this.lblMinOccurs.AutoSize = true;
            this.lblMinOccurs.Location = new System.Drawing.Point(12, 91);
            this.lblMinOccurs.Name = "lblMinOccurs";
            this.lblMinOccurs.Size = new System.Drawing.Size(88, 13);
            this.lblMinOccurs.TabIndex = 5;
            this.lblMinOccurs.Text = "Cantidad Minima:";
            // 
            // lblMaxOccurs
            // 
            this.lblMaxOccurs.AutoSize = true;
            this.lblMaxOccurs.Location = new System.Drawing.Point(12, 115);
            this.lblMaxOccurs.Name = "lblMaxOccurs";
            this.lblMaxOccurs.Size = new System.Drawing.Size(91, 13);
            this.lblMaxOccurs.TabIndex = 6;
            this.lblMaxOccurs.Text = "Cantidad Maxima:";
            // 
            // cboMinOccurs
            // 
            this.cboMinOccurs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMinOccurs.FormattingEnabled = true;
            this.cboMinOccurs.Items.AddRange(new object[] {
            "0",
            "1",
            "unbounded"});
            this.cboMinOccurs.Location = new System.Drawing.Point(106, 88);
            this.cboMinOccurs.Name = "cboMinOccurs";
            this.cboMinOccurs.Size = new System.Drawing.Size(186, 21);
            this.cboMinOccurs.TabIndex = 7;
            // 
            // cboMaxOccurs
            // 
            this.cboMaxOccurs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMaxOccurs.FormattingEnabled = true;
            this.cboMaxOccurs.Items.AddRange(new object[] {
            "0",
            "1",
            "unbounded"});
            this.cboMaxOccurs.Location = new System.Drawing.Point(106, 115);
            this.cboMaxOccurs.Name = "cboMaxOccurs";
            this.cboMaxOccurs.Size = new System.Drawing.Size(186, 21);
            this.cboMaxOccurs.TabIndex = 8;
            // 
            // lblRuta
            // 
            this.lblRuta.AutoSize = true;
            this.lblRuta.Location = new System.Drawing.Point(12, 37);
            this.lblRuta.Name = "lblRuta";
            this.lblRuta.Size = new System.Drawing.Size(25, 13);
            this.lblRuta.TabIndex = 11;
            this.lblRuta.Text = "BO:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cboBO
            // 
            this.cboBO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBO.FormattingEnabled = true;
            this.cboBO.Location = new System.Drawing.Point(106, 34);
            this.cboBO.Name = "cboBO";
            this.cboBO.Size = new System.Drawing.Size(186, 21);
            this.cboBO.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Contenedor:";
            // 
            // txtLista
            // 
            this.txtLista.Location = new System.Drawing.Point(369, 34);
            this.txtLista.Name = "txtLista";
            this.txtLista.Size = new System.Drawing.Size(184, 20);
            this.txtLista.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(298, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Lista:";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(255, 150);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 20;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtContenedor
            // 
            this.txtContenedor.FormattingEnabled = true;
            this.txtContenedor.Location = new System.Drawing.Point(369, 7);
            this.txtContenedor.Name = "txtContenedor";
            this.txtContenedor.Size = new System.Drawing.Size(183, 21);
            this.txtContenedor.TabIndex = 21;
            // 
            // frmParametersCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 185);
            this.Controls.Add(this.txtContenedor);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.cboBO);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtLista);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.cboMaxOccurs);
            this.Controls.Add(this.lblRuta);
            this.Controls.Add(this.lblMinOccurs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboMinOccurs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblMaxOccurs);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmParametersCreator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Parametros";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblMinOccurs;
        private System.Windows.Forms.Label lblMaxOccurs;
        private System.Windows.Forms.ComboBox cboMinOccurs;
        private System.Windows.Forms.ComboBox cboMaxOccurs;
        private System.Windows.Forms.Label lblRuta;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cboBO;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLista;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ComboBox txtContenedor;
    }
}