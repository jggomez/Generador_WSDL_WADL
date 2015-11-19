using CMI_WSDLCreator.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMI_WSDLCreator
{
    public partial class frmParametersCreator : Form
    {
        private Capacity capacity;
        private bool editar;
        private ParametersType parametersType;
        List<BussinessObject> bOs;
        WSDLManager wsdlManager;
        private Parameter param;

        public Parameter Param
        {
            get { return param; }
            set { param = value; LoadParameter(); }
        }

        public bool Editar
        {
            get { return editar; }
            set { editar = value; }
        }

        private void LoadParameter()
        {
            if (this.param.Type != null)
            {
                cboTipo.SelectedItem = this.param.Type;
            }

            if (this.param.Obj != null)
            {
                cboBO.SelectedItem = this.param.Obj.Name;
            }

            txtLista.Text = this.param.ListName;
            txtContenedor.Text = this.param.Container;
            txtNombre.Text = this.param.Name;
            cboMinOccurs.SelectedItem = this.param.MinOccurs;
            cboMaxOccurs.SelectedItem = this.param.MaxOccurs;
        }

        public frmParametersCreator(Capacity capacity, WSDLManager wsdlManager, ParametersType parametersType)
        {
            InitializeComponent();
            this.capacity = capacity;
            this.bOs = wsdlManager.BussinesObjects;
            this.wsdlManager = wsdlManager;
            this.parametersType = parametersType;
            CargarBOs();
            LoadContainers();
        }

        private void LoadContainers()
        {
            List<string> containers = new List<string>();

            foreach (var capacity in this.wsdlManager.Methods)
            {
                foreach (var parameter in capacity.ParametersIn)
                {

                    if( !containers.Contains(parameter.Container))
                    {
                        containers.Add(parameter.Container);
                    }
                    
                }

                foreach (var parameter in capacity.ParametersOut)
                {

                    if (!containers.Contains(parameter.Container))
                    {
                        containers.Add(parameter.Container);
                    }

                }


                txtContenedor.Items.Clear();

                foreach (var item in containers)
                {
                    txtContenedor.Items.Add(item);
                }
                
            }
        }

        private void CargarBOs()
        {
            cboBO.Items.Clear();

            foreach (var item in this.bOs)
            {
                cboBO.Items.Add(item.Name);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Parameter parameter = null;

            if (this.Param != null)
            {
                parameter = this.param;
            }
            else
            {
                parameter = new Parameter();
            }

            if (txtNombre.Text.Trim().Length > 0 && cboMinOccurs.SelectedIndex != -1 && cboMaxOccurs.SelectedIndex != -1)
            {
                if (cboBO.SelectedIndex != -1)
                {
                    parameter.Obj = wsdlManager.getBO(cboBO.SelectedItem.ToString());
                }

                if (cboTipo.SelectedIndex != -1)
                {
                    parameter.Type = cboTipo.SelectedItem.ToString();
                }

                parameter.Name = txtNombre.Text.Trim();
                parameter.MaxOccurs = cboMaxOccurs.SelectedItem.ToString();
                parameter.MinOccurs = cboMinOccurs.SelectedItem.ToString();
                parameter.Container = txtContenedor.Text;
                parameter.ListName = txtLista.Text;


                if (this.param == null)
                {
                    if (this.parametersType == ParametersType.IN)
                    {
                        capacity.ParametersIn.Add(parameter);
                    }
                    else
                    {
                        capacity.ParametersOut.Add(parameter);
                    }
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Debe seleccionar todos los parametros para continuar.");
            }

        }
    }
}
