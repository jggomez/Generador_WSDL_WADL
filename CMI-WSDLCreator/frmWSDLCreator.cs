using CMI_WSDLCreator.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;

namespace CMI_WSDLCreator
{
    public partial class frmWSDLCreator : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private WSDLManager wsdlManager;
        private Capacity currentCapacity;
        private string basePath;

        public frmWSDLCreator()
        {
            InitializeComponent();
            txtNombreServicio.Focus();
            btnNuevoEntrada.Enabled = false;
            btnNuevoSalida.Enabled = false;
            btnEditarEntrada.Enabled = false;
            btnEliminarEntrada.Enabled = false;
            btnEditarSalida.Enabled = false;
            btnEditar.Enabled = false;
            btnEliminarSalida.Enabled = false;

            wsdlManager = new WSDLManager();
            basePath = ConfigurationManager.AppSettings["BASE_FOLDER__PATH"];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarCapacidad_Click(object sender, EventArgs e)
        {
            if (txtCapacidad.Text.Length > 0)
            {
                Capacity capacity = new Capacity();
                capacity.Name = txtCapacidad.Text.Trim();
                this.wsdlManager.Methods.Add(capacity);

                btnNuevoEntrada.Enabled = false;
                btnNuevoSalida.Enabled = false;

                btnEliminarEntrada.Enabled = false;
                btnEditarEntrada.Enabled = false;

                btnEliminarSalida.Enabled = false;
                btnEditarSalida.Enabled = false;

                txtDocumentacionMetodo.Clear();
                txtCapacidad.Clear();
                lbCapacidades.Items.Clear();

                foreach (var item in wsdlManager.Methods)
                {
                    lbCapacidades.Items.Add(item.Name);
                }
            }
            else
            {
                MessageBox.Show("Debe indicar el nombre de la Capacidad");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerarWSDL_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNombreServicio.Text.Trim().Length >= 0
                    && cboTipoServicio.SelectedIndex != -1
                    && txtDominio.Text.Trim().Length >= 0
                    && txtDocumentacionServicio.Text.Trim().Length >= 0
                    && wsdlManager.Methods.Count > 0)
                {
                    ServiceType type;

                    switch (cboTipoServicio.SelectedItem.ToString())
                    {
                        case "Entidad":
                            type = ServiceType.Entity;
                            break;
                        case "Tarea":
                            type = ServiceType.Task;
                            break;
                        case "Aplicación":
                            type = ServiceType.Application;
                            break;
                        default:
                            type = ServiceType.Process;
                            break;
                    }

                    wsdlManager.Type = type;
                    wsdlManager.Domain = txtDominio.Text.Trim();
                    wsdlManager.Documentation = txtDocumentacionServicio.Text.Trim();
                    wsdlManager.ServiceName = txtNombreServicio.Text.Trim();
                    wsdlManager.CreateWSDL();

                    MessageBox.Show("WSDL creado con exito.");
                }
                else 
                {
                    MessageBox.Show("Debe digitar la información asociada al servicio.");
                }
            }
            catch (Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void lbCapacidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCapacidades.SelectedIndex != -1)
            {

                btnNuevoEntrada.Enabled = true;
                btnNuevoSalida.Enabled = true;

                btnEditarEntrada.Enabled = true;
                btnEliminarEntrada.Enabled = true;

                btnEliminarSalida.Enabled = true;
                btnEditarSalida.Enabled = true;

                btnEditar.Enabled = true;

                this.currentCapacity = wsdlManager.getCapacity(lbCapacidades.SelectedItem.ToString());

                lbParametrosEntrada.Items.Clear();
                lbParametrosSalida.Items.Clear();

                foreach (var item in this.currentCapacity.ParametersIn)
                {
                    lbParametrosEntrada.Items.Add(item.Name);
                }

                foreach (var item in this.currentCapacity.ParametersOut)
                {
                    lbParametrosSalida.Items.Add(item.Name);
                }

                txtDocumentacionMetodo.Text = this.currentCapacity.Documentation;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnEditarEntrada_Click(object sender, EventArgs e)
        {
            if (lbParametrosEntrada.SelectedIndex != -1)
            {
                frmParametersCreator parameter = new frmParametersCreator(currentCapacity, wsdlManager, ParametersType.IN);
                parameter.Param = this.currentCapacity.getParameter(lbParametrosEntrada.SelectedItem.ToString(), ParametersType.IN);
                parameter.ShowDialog();
                lbParametrosEntrada.Items.Clear();

                foreach (var item in this.currentCapacity.ParametersIn)
                {
                    lbParametrosEntrada.Items.Add(item.Name);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un parametro.");
            }
        }

        private void btnAgregarBO_Click(object sender, EventArgs e)
        {

            if(!String.IsNullOrWhiteSpace(txtDominio.Text.ToString()))
            {
                 ofdBO.InitialDirectory = this.basePath;

                DialogResult result = ofdBO.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string file = ofdBO.FileName;
                    FileInfo f = new FileInfo(file);

                    BussinessObject bo = new BussinessObject();
                    bo.Name = Path.GetFileNameWithoutExtension(f.Name);
                    bo.Path = f.Directory.FullName;
                    bo.NameSpace = this.GetSchemaNamespace(file);

                    var arrNamespace = bo.NameSpace.Split('/');

                    int cantidad = 2;

                    if(arrNamespace[arrNamespace.Length - 1].Equals(string.Empty))
                    {
                        cantidad++;
                    }

                    bo.Domain = arrNamespace[arrNamespace.Length - cantidad];
                
                    bo.IsExtern = this.txtDominio.Text.Trim().Equals(bo.Domain) ? false : true;

                    wsdlManager.BussinesObjects.Add(bo);

                    lbBOs.Items.Clear();

                    foreach (var item in wsdlManager.BussinesObjects)
                    {
                        lbBOs.Items.Add(item.Name);
                    }

                }

            }
            else
            {
                MessageBox.Show("Debe indicar un dominio de negocio.");
            }
           
        }

        private string GetSchemaNamespace(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            return doc.GetElementsByTagName("xsd:schema")[0].Attributes["targetNamespace"].Value;
        }

        private void btnNuevoSalida_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminarBO_Click(object sender, EventArgs e)
        {
            if (lbBOs.SelectedIndex != -1)
            {
                wsdlManager.DeleteBO(lbBOs.SelectedItem.ToString());

                lbBOs.Items.Clear();

                foreach (var item in wsdlManager.BussinesObjects)
                {
                    lbBOs.Items.Add(item.Name);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un BO para eliminar");
            }
        }

        private void btnEliminarCapacidad_Click(object sender, EventArgs e)
        {
            if (lbCapacidades.SelectedIndex != -1)
            {
                wsdlManager.DeleteCapacity(lbCapacidades.SelectedItem.ToString());

                CleanParameters();

                lbCapacidades.Items.Clear();

                foreach (var item in wsdlManager.Methods)
                {
                    lbCapacidades.Items.Add(item.Name);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar una capacidad para eliminar");
            }
        }

        private void CleanParameters()
        {
            lbParametrosEntrada.Items.Clear();
            lbParametrosSalida.Items.Clear();

            btnNuevoEntrada.Enabled = false;
            btnNuevoSalida.Enabled = false;
            btnEliminarEntrada.Enabled = false;
            btnEliminarSalida.Enabled = false;
            btnEditarEntrada.Enabled = false;
            btnEditarSalida.Enabled = false;
            btnEditar.Enabled = false;
        }

        private void btnEditarSalida_Click(object sender, EventArgs e)
        {
            if (lbParametrosSalida.SelectedIndex != -1)
            {
                frmParametersCreator parameter = new frmParametersCreator(currentCapacity, wsdlManager, ParametersType.OUT);

                parameter.Param = this.currentCapacity.getParameter(lbParametrosSalida.SelectedItem.ToString(), ParametersType.OUT);

                parameter.ShowDialog();

                lbParametrosSalida.Items.Clear();

                foreach (var item in this.currentCapacity.ParametersOut)
                {
                    lbParametrosSalida.Items.Add(item.Name);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un parametro.");
            }
        }

        private void btnEliminarEntrada_Click(object sender, EventArgs e)
        {
            if (lbParametrosEntrada.SelectedIndex != -1)
            {
                this.currentCapacity.DeleteParameter(lbParametrosEntrada.SelectedItem.ToString(), ParametersType.IN);

                lbParametrosEntrada.Items.Clear();

                foreach (var item in this.currentCapacity.ParametersIn)
                {
                    lbParametrosEntrada.Items.Add(item.Name);
                }

            }
            else
            {
                MessageBox.Show("Debe seleccionar un parametro.");
            }
        }

        private void btnEliminarSalida_Click(object sender, EventArgs e)
        {
            if (lbParametrosSalida.SelectedIndex != -1)
            {
                this.currentCapacity.DeleteParameter(lbParametrosSalida.SelectedItem.ToString(), ParametersType.OUT);

                lbParametrosSalida.Items.Clear();

                foreach (var item in this.currentCapacity.ParametersOut)
                {
                    lbParametrosSalida.Items.Add(item.Name);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un parametro.");
            }
        }

        private void btnNuevoEntrada_Click(object sender, EventArgs e)
        {
            frmParametersCreator parameter = new frmParametersCreator(currentCapacity, wsdlManager, ParametersType.IN);
            parameter.ShowDialog();
            lbParametrosEntrada.Items.Clear();

            foreach (var item in this.currentCapacity.ParametersIn)
            {
                lbParametrosEntrada.Items.Add(item.Name);
            }
        }

        private void btnNuevoSalida_Click_1(object sender, EventArgs e)
        {
            frmParametersCreator parameter = new frmParametersCreator(currentCapacity, wsdlManager, ParametersType.OUT);

            parameter.ShowDialog();

            lbParametrosSalida.Items.Clear();

            foreach (var item in this.currentCapacity.ParametersOut)
            {
                lbParametrosSalida.Items.Add(item.Name);
            }
        }

        private void btnActualizarCapacidad_Click(object sender, EventArgs e)
        {
            
        }

        private void abrirWSDLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ofdBO.InitialDirectory = this.basePath;

            DialogResult result = ofdBO.ShowDialog();

            if (result == DialogResult.OK)
            {
                string file = ofdBO.FileName;
                FileInfo f = new FileInfo(file);

                wsdlManager = new WSDLManager();

                //wsdlManager.UseDirectory = false;
                //wsdlManager.WsdlsPath = f.DirectoryName;

                XmlDocument doc = new XmlDocument();
                doc.Load(file);



                wsdlManager.LoadWSDL(doc);

                CargarDatosWSDL();
            }
            else 
            {
                MessageBox.Show("Debe seleccionar un un archivo");
            }
        }

        private void CargarDatosWSDL()
        {
            txtNombreServicio.Text = wsdlManager.ServiceName;
            txtDominio.Text = wsdlManager.Domain;
            string tipo;

            switch (wsdlManager.Type)
            {
                case ServiceType.Entity:
                    tipo = "Entidad";
                    break;
                case ServiceType.Task:
                    tipo = "Tarea";
                    break;
                case ServiceType.Application:
                    tipo = "Aplicación";
                    break;
                default:
                    tipo = "Proceso";
                    break;
            }


            cboTipoServicio.SelectedItem = tipo;
            txtDocumentacionServicio.Text = wsdlManager.Documentation;

            lbBOs.Items.Clear();

            foreach (var item in wsdlManager.BussinesObjects)
            {
                lbBOs.Items.Add(item.Name);
            }

            lbCapacidades.Items.Clear();

            foreach (var item in wsdlManager.Methods)
            {
                lbCapacidades.Items.Add(item.Name);
            }           

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmMethodDescription parameter = new frmMethodDescription(currentCapacity);

            parameter.ShowDialog();

            this.txtDocumentacionMetodo.Text = this.currentCapacity.Documentation;

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
