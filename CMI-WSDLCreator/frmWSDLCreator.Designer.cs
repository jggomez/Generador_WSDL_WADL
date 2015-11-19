namespace CMI_WSDLCreator
{
    partial class frmWSDLCreator
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
            this.txtCapacidad = new System.Windows.Forms.TextBox();
            this.lblCapacidad = new System.Windows.Forms.Label();
            this.lbCapacidades = new System.Windows.Forms.ListBox();
            this.lblCapacidades = new System.Windows.Forms.Label();
            this.btnAgregarCapacidad = new System.Windows.Forms.Button();
            this.lblNombreServicio = new System.Windows.Forms.Label();
            this.txtNombreServicio = new System.Windows.Forms.TextBox();
            this.btnGenerarWSDL = new System.Windows.Forms.Button();
            this.lblDominio = new System.Windows.Forms.Label();
            this.lblDocumentacionServicio = new System.Windows.Forms.Label();
            this.txtDocumentacionServicio = new System.Windows.Forms.TextBox();
            this.lblParametrosEntrada = new System.Windows.Forms.Label();
            this.lbParametrosEntrada = new System.Windows.Forms.ListBox();
            this.btnEditarEntrada = new System.Windows.Forms.Button();
            this.lblDocumentacionMetodo = new System.Windows.Forms.Label();
            this.txtDocumentacionMetodo = new System.Windows.Forms.TextBox();
            this.btnEditarSalida = new System.Windows.Forms.Button();
            this.lbParametrosSalida = new System.Windows.Forms.ListBox();
            this.lblParametrosSalida = new System.Windows.Forms.Label();
            this.lblBOs = new System.Windows.Forms.Label();
            this.btnAgregarBO = new System.Windows.Forms.Button();
            this.btnEliminarBO = new System.Windows.Forms.Button();
            this.ofdBO = new System.Windows.Forms.OpenFileDialog();
            this.lbBOs = new System.Windows.Forms.ListBox();
            this.btnEliminarCapacidad = new System.Windows.Forms.Button();
            this.btnEliminarEntrada = new System.Windows.Forms.Button();
            this.btnEliminarSalida = new System.Windows.Forms.Button();
            this.btnNuevoEntrada = new System.Windows.Forms.Button();
            this.btnNuevoSalida = new System.Windows.Forms.Button();
            this.cboTipoServicio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirWSDLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtDominio = new System.Windows.Forms.ComboBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCapacidad
            // 
            this.txtCapacidad.Location = new System.Drawing.Point(93, 184);
            this.txtCapacidad.Name = "txtCapacidad";
            this.txtCapacidad.Size = new System.Drawing.Size(110, 20);
            this.txtCapacidad.TabIndex = 1;
            // 
            // lblCapacidad
            // 
            this.lblCapacidad.AutoSize = true;
            this.lblCapacidad.Location = new System.Drawing.Point(26, 187);
            this.lblCapacidad.Name = "lblCapacidad";
            this.lblCapacidad.Size = new System.Drawing.Size(61, 13);
            this.lblCapacidad.TabIndex = 2;
            this.lblCapacidad.Text = "Capacidad:";
            // 
            // lbCapacidades
            // 
            this.lbCapacidades.FormattingEnabled = true;
            this.lbCapacidades.Location = new System.Drawing.Point(27, 226);
            this.lbCapacidades.Name = "lbCapacidades";
            this.lbCapacidades.Size = new System.Drawing.Size(321, 264);
            this.lbCapacidades.TabIndex = 5;
            this.lbCapacidades.SelectedIndexChanged += new System.EventHandler(this.lbCapacidades_SelectedIndexChanged);
            // 
            // lblCapacidades
            // 
            this.lblCapacidades.AutoSize = true;
            this.lblCapacidades.Location = new System.Drawing.Point(27, 210);
            this.lblCapacidades.Name = "lblCapacidades";
            this.lblCapacidades.Size = new System.Drawing.Size(72, 13);
            this.lblCapacidades.TabIndex = 6;
            this.lblCapacidades.Text = "Capacidades:";
            // 
            // btnAgregarCapacidad
            // 
            this.btnAgregarCapacidad.Location = new System.Drawing.Point(209, 182);
            this.btnAgregarCapacidad.Name = "btnAgregarCapacidad";
            this.btnAgregarCapacidad.Size = new System.Drawing.Size(66, 23);
            this.btnAgregarCapacidad.TabIndex = 7;
            this.btnAgregarCapacidad.Text = "Agregar";
            this.btnAgregarCapacidad.UseVisualStyleBackColor = true;
            this.btnAgregarCapacidad.Click += new System.EventHandler(this.btnAgregarCapacidad_Click);
            // 
            // lblNombreServicio
            // 
            this.lblNombreServicio.AutoSize = true;
            this.lblNombreServicio.Location = new System.Drawing.Point(21, 40);
            this.lblNombreServicio.Name = "lblNombreServicio";
            this.lblNombreServicio.Size = new System.Drawing.Size(88, 13);
            this.lblNombreServicio.TabIndex = 9;
            this.lblNombreServicio.Text = "Nombre Servicio:";
            // 
            // txtNombreServicio
            // 
            this.txtNombreServicio.Location = new System.Drawing.Point(118, 37);
            this.txtNombreServicio.Name = "txtNombreServicio";
            this.txtNombreServicio.Size = new System.Drawing.Size(227, 20);
            this.txtNombreServicio.TabIndex = 8;
            // 
            // btnGenerarWSDL
            // 
            this.btnGenerarWSDL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarWSDL.ForeColor = System.Drawing.Color.Red;
            this.btnGenerarWSDL.Location = new System.Drawing.Point(294, 496);
            this.btnGenerarWSDL.Name = "btnGenerarWSDL";
            this.btnGenerarWSDL.Size = new System.Drawing.Size(112, 23);
            this.btnGenerarWSDL.TabIndex = 10;
            this.btnGenerarWSDL.Text = "Generar WSDL";
            this.btnGenerarWSDL.UseVisualStyleBackColor = true;
            this.btnGenerarWSDL.Click += new System.EventHandler(this.btnGenerarWSDL_Click);
            // 
            // lblDominio
            // 
            this.lblDominio.AutoSize = true;
            this.lblDominio.Location = new System.Drawing.Point(370, 37);
            this.lblDominio.Name = "lblDominio";
            this.lblDominio.Size = new System.Drawing.Size(48, 13);
            this.lblDominio.TabIndex = 12;
            this.lblDominio.Text = "Dominio:";
            // 
            // lblDocumentacionServicio
            // 
            this.lblDocumentacionServicio.AutoSize = true;
            this.lblDocumentacionServicio.Location = new System.Drawing.Point(24, 86);
            this.lblDocumentacionServicio.Name = "lblDocumentacionServicio";
            this.lblDocumentacionServicio.Size = new System.Drawing.Size(85, 13);
            this.lblDocumentacionServicio.TabIndex = 13;
            this.lblDocumentacionServicio.Text = "Documentación:";
            // 
            // txtDocumentacionServicio
            // 
            this.txtDocumentacionServicio.Location = new System.Drawing.Point(27, 102);
            this.txtDocumentacionServicio.Multiline = true;
            this.txtDocumentacionServicio.Name = "txtDocumentacionServicio";
            this.txtDocumentacionServicio.Size = new System.Drawing.Size(321, 68);
            this.txtDocumentacionServicio.TabIndex = 14;
            // 
            // lblParametrosEntrada
            // 
            this.lblParametrosEntrada.AutoSize = true;
            this.lblParametrosEntrada.Location = new System.Drawing.Point(370, 210);
            this.lblParametrosEntrada.Name = "lblParametrosEntrada";
            this.lblParametrosEntrada.Size = new System.Drawing.Size(103, 13);
            this.lblParametrosEntrada.TabIndex = 15;
            this.lblParametrosEntrada.Text = "Parametros Entrada:";
            // 
            // lbParametrosEntrada
            // 
            this.lbParametrosEntrada.FormattingEnabled = true;
            this.lbParametrosEntrada.Location = new System.Drawing.Point(373, 226);
            this.lbParametrosEntrada.Name = "lbParametrosEntrada";
            this.lbParametrosEntrada.Size = new System.Drawing.Size(207, 82);
            this.lbParametrosEntrada.TabIndex = 16;
            // 
            // btnEditarEntrada
            // 
            this.btnEditarEntrada.Location = new System.Drawing.Point(581, 255);
            this.btnEditarEntrada.Name = "btnEditarEntrada";
            this.btnEditarEntrada.Size = new System.Drawing.Size(79, 23);
            this.btnEditarEntrada.TabIndex = 18;
            this.btnEditarEntrada.Text = "Editar";
            this.btnEditarEntrada.UseVisualStyleBackColor = true;
            this.btnEditarEntrada.Click += new System.EventHandler(this.btnEditarEntrada_Click);
            // 
            // lblDocumentacionMetodo
            // 
            this.lblDocumentacionMetodo.AutoSize = true;
            this.lblDocumentacionMetodo.Location = new System.Drawing.Point(370, 414);
            this.lblDocumentacionMetodo.Name = "lblDocumentacionMetodo";
            this.lblDocumentacionMetodo.Size = new System.Drawing.Size(139, 13);
            this.lblDocumentacionMetodo.TabIndex = 19;
            this.lblDocumentacionMetodo.Text = "Documentación Capacidad:";
            // 
            // txtDocumentacionMetodo
            // 
            this.txtDocumentacionMetodo.Location = new System.Drawing.Point(373, 430);
            this.txtDocumentacionMetodo.Multiline = true;
            this.txtDocumentacionMetodo.Name = "txtDocumentacionMetodo";
            this.txtDocumentacionMetodo.ReadOnly = true;
            this.txtDocumentacionMetodo.Size = new System.Drawing.Size(207, 60);
            this.txtDocumentacionMetodo.TabIndex = 20;
            // 
            // btnEditarSalida
            // 
            this.btnEditarSalida.Location = new System.Drawing.Point(581, 358);
            this.btnEditarSalida.Name = "btnEditarSalida";
            this.btnEditarSalida.Size = new System.Drawing.Size(79, 23);
            this.btnEditarSalida.TabIndex = 24;
            this.btnEditarSalida.Text = "Editar";
            this.btnEditarSalida.UseVisualStyleBackColor = true;
            this.btnEditarSalida.Click += new System.EventHandler(this.btnEditarSalida_Click);
            // 
            // lbParametrosSalida
            // 
            this.lbParametrosSalida.FormattingEnabled = true;
            this.lbParametrosSalida.Location = new System.Drawing.Point(373, 329);
            this.lbParametrosSalida.Name = "lbParametrosSalida";
            this.lbParametrosSalida.Size = new System.Drawing.Size(207, 82);
            this.lbParametrosSalida.TabIndex = 22;
            // 
            // lblParametrosSalida
            // 
            this.lblParametrosSalida.AutoSize = true;
            this.lblParametrosSalida.Location = new System.Drawing.Point(373, 313);
            this.lblParametrosSalida.Name = "lblParametrosSalida";
            this.lblParametrosSalida.Size = new System.Drawing.Size(95, 13);
            this.lblParametrosSalida.TabIndex = 21;
            this.lblParametrosSalida.Text = "Parametros Salida:";
            // 
            // lblBOs
            // 
            this.lblBOs.AutoSize = true;
            this.lblBOs.Location = new System.Drawing.Point(370, 78);
            this.lblBOs.Name = "lblBOs";
            this.lblBOs.Size = new System.Drawing.Size(98, 13);
            this.lblBOs.TabIndex = 26;
            this.lblBOs.Text = "BOs Relacionados:";
            // 
            // btnAgregarBO
            // 
            this.btnAgregarBO.Location = new System.Drawing.Point(505, 73);
            this.btnAgregarBO.Name = "btnAgregarBO";
            this.btnAgregarBO.Size = new System.Drawing.Size(75, 23);
            this.btnAgregarBO.TabIndex = 27;
            this.btnAgregarBO.Text = "Agregar";
            this.btnAgregarBO.UseVisualStyleBackColor = true;
            this.btnAgregarBO.Click += new System.EventHandler(this.btnAgregarBO_Click);
            // 
            // btnEliminarBO
            // 
            this.btnEliminarBO.Location = new System.Drawing.Point(585, 73);
            this.btnEliminarBO.Name = "btnEliminarBO";
            this.btnEliminarBO.Size = new System.Drawing.Size(75, 23);
            this.btnEliminarBO.TabIndex = 28;
            this.btnEliminarBO.Text = "Eliminar";
            this.btnEliminarBO.UseVisualStyleBackColor = true;
            this.btnEliminarBO.Click += new System.EventHandler(this.btnEliminarBO_Click);
            // 
            // lbBOs
            // 
            this.lbBOs.FormattingEnabled = true;
            this.lbBOs.Location = new System.Drawing.Point(373, 102);
            this.lbBOs.Name = "lbBOs";
            this.lbBOs.Size = new System.Drawing.Size(287, 69);
            this.lbBOs.TabIndex = 29;
            // 
            // btnEliminarCapacidad
            // 
            this.btnEliminarCapacidad.Location = new System.Drawing.Point(279, 182);
            this.btnEliminarCapacidad.Name = "btnEliminarCapacidad";
            this.btnEliminarCapacidad.Size = new System.Drawing.Size(66, 23);
            this.btnEliminarCapacidad.TabIndex = 30;
            this.btnEliminarCapacidad.Text = "Eliminar";
            this.btnEliminarCapacidad.UseVisualStyleBackColor = true;
            this.btnEliminarCapacidad.Click += new System.EventHandler(this.btnEliminarCapacidad_Click);
            // 
            // btnEliminarEntrada
            // 
            this.btnEliminarEntrada.Location = new System.Drawing.Point(581, 285);
            this.btnEliminarEntrada.Name = "btnEliminarEntrada";
            this.btnEliminarEntrada.Size = new System.Drawing.Size(79, 23);
            this.btnEliminarEntrada.TabIndex = 31;
            this.btnEliminarEntrada.Text = "Eliminar";
            this.btnEliminarEntrada.UseVisualStyleBackColor = true;
            this.btnEliminarEntrada.Click += new System.EventHandler(this.btnEliminarEntrada_Click);
            // 
            // btnEliminarSalida
            // 
            this.btnEliminarSalida.Location = new System.Drawing.Point(581, 388);
            this.btnEliminarSalida.Name = "btnEliminarSalida";
            this.btnEliminarSalida.Size = new System.Drawing.Size(79, 23);
            this.btnEliminarSalida.TabIndex = 32;
            this.btnEliminarSalida.Text = "Eliminar";
            this.btnEliminarSalida.UseVisualStyleBackColor = true;
            this.btnEliminarSalida.Click += new System.EventHandler(this.btnEliminarSalida_Click);
            // 
            // btnNuevoEntrada
            // 
            this.btnNuevoEntrada.Location = new System.Drawing.Point(581, 226);
            this.btnNuevoEntrada.Name = "btnNuevoEntrada";
            this.btnNuevoEntrada.Size = new System.Drawing.Size(79, 23);
            this.btnNuevoEntrada.TabIndex = 33;
            this.btnNuevoEntrada.Text = "Nuevo";
            this.btnNuevoEntrada.UseVisualStyleBackColor = true;
            this.btnNuevoEntrada.Click += new System.EventHandler(this.btnNuevoEntrada_Click);
            // 
            // btnNuevoSalida
            // 
            this.btnNuevoSalida.Location = new System.Drawing.Point(581, 329);
            this.btnNuevoSalida.Name = "btnNuevoSalida";
            this.btnNuevoSalida.Size = new System.Drawing.Size(79, 23);
            this.btnNuevoSalida.TabIndex = 34;
            this.btnNuevoSalida.Text = "Nuevo";
            this.btnNuevoSalida.UseVisualStyleBackColor = true;
            this.btnNuevoSalida.Click += new System.EventHandler(this.btnNuevoSalida_Click_1);
            // 
            // cboTipoServicio
            // 
            this.cboTipoServicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoServicio.FormattingEnabled = true;
            this.cboTipoServicio.Items.AddRange(new object[] {
            "Entidad",
            "Tarea",
            "Proceso",
            "Aplicación"});
            this.cboTipoServicio.Location = new System.Drawing.Point(118, 63);
            this.cboTipoServicio.Name = "cboTipoServicio";
            this.cboTipoServicio.Size = new System.Drawing.Size(227, 21);
            this.cboTipoServicio.TabIndex = 35;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Tipo:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(672, 24);
            this.menuStrip1.TabIndex = 38;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirWSDLToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // abrirWSDLToolStripMenuItem
            // 
            this.abrirWSDLToolStripMenuItem.Name = "abrirWSDLToolStripMenuItem";
            this.abrirWSDLToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abrirWSDLToolStripMenuItem.Text = "Abrir WSDL";
            this.abrirWSDLToolStripMenuItem.Click += new System.EventHandler(this.abrirWSDLToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // txtDominio
            // 
            this.txtDominio.FormattingEnabled = true;
            this.txtDominio.Items.AddRange(new object[] {
            "Facturacion",
            "Comun",
            "GerenciaClinica",
            "Comercial",
            "GestionHumana",
            "Suministros"});
            this.txtDominio.Location = new System.Drawing.Point(424, 34);
            this.txtDominio.Name = "txtDominio";
            this.txtDominio.Size = new System.Drawing.Size(236, 21);
            this.txtDominio.TabIndex = 39;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(581, 428);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(79, 23);
            this.btnEditar.TabIndex = 40;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            // 
            // frmWSDLCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 524);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.txtDominio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboTipoServicio);
            this.Controls.Add(this.btnNuevoSalida);
            this.Controls.Add(this.btnNuevoEntrada);
            this.Controls.Add(this.btnEliminarSalida);
            this.Controls.Add(this.btnEliminarEntrada);
            this.Controls.Add(this.btnEliminarCapacidad);
            this.Controls.Add(this.lbBOs);
            this.Controls.Add(this.btnEliminarBO);
            this.Controls.Add(this.btnAgregarBO);
            this.Controls.Add(this.lblBOs);
            this.Controls.Add(this.btnEditarSalida);
            this.Controls.Add(this.lbParametrosSalida);
            this.Controls.Add(this.lblParametrosSalida);
            this.Controls.Add(this.txtDocumentacionMetodo);
            this.Controls.Add(this.lblDocumentacionMetodo);
            this.Controls.Add(this.btnEditarEntrada);
            this.Controls.Add(this.lbParametrosEntrada);
            this.Controls.Add(this.lblParametrosEntrada);
            this.Controls.Add(this.txtDocumentacionServicio);
            this.Controls.Add(this.lblDocumentacionServicio);
            this.Controls.Add(this.lblDominio);
            this.Controls.Add(this.btnGenerarWSDL);
            this.Controls.Add(this.lblNombreServicio);
            this.Controls.Add(this.txtNombreServicio);
            this.Controls.Add(this.btnAgregarCapacidad);
            this.Controls.Add(this.lblCapacidades);
            this.Controls.Add(this.lbCapacidades);
            this.Controls.Add(this.lblCapacidad);
            this.Controls.Add(this.txtCapacidad);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWSDLCreator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CMI - WSDL";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCapacidad;
        private System.Windows.Forms.Label lblCapacidad;
        private System.Windows.Forms.ListBox lbCapacidades;
        private System.Windows.Forms.Label lblCapacidades;
        private System.Windows.Forms.Button btnAgregarCapacidad;
        private System.Windows.Forms.Label lblNombreServicio;
        private System.Windows.Forms.TextBox txtNombreServicio;
        private System.Windows.Forms.Button btnGenerarWSDL;
        private System.Windows.Forms.Label lblDominio;
        private System.Windows.Forms.Label lblDocumentacionServicio;
        private System.Windows.Forms.TextBox txtDocumentacionServicio;
        private System.Windows.Forms.Label lblParametrosEntrada;
        private System.Windows.Forms.ListBox lbParametrosEntrada;
        private System.Windows.Forms.Button btnEditarEntrada;
        private System.Windows.Forms.Label lblDocumentacionMetodo;
        private System.Windows.Forms.TextBox txtDocumentacionMetodo;
        private System.Windows.Forms.Button btnEditarSalida;
        private System.Windows.Forms.ListBox lbParametrosSalida;
        private System.Windows.Forms.Label lblParametrosSalida;
        private System.Windows.Forms.Label lblBOs;
        private System.Windows.Forms.Button btnAgregarBO;
        private System.Windows.Forms.Button btnEliminarBO;
        private System.Windows.Forms.OpenFileDialog ofdBO;
        private System.Windows.Forms.ListBox lbBOs;
        private System.Windows.Forms.Button btnEliminarCapacidad;
        private System.Windows.Forms.Button btnEliminarEntrada;
        private System.Windows.Forms.Button btnEliminarSalida;
        private System.Windows.Forms.Button btnNuevoEntrada;
        private System.Windows.Forms.Button btnNuevoSalida;
        private System.Windows.Forms.ComboBox cboTipoServicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirWSDLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ComboBox txtDominio;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
    }
}

