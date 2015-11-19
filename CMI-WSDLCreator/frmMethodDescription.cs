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
    public partial class frmMethodDescription : Form
    {
        private Capacity capacity;

        public frmMethodDescription(Capacity capacity)
        {
            InitializeComponent();

            this.capacity = capacity;

            this.txtObservaciones.Text = this.capacity.Documentation;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            this.capacity.Documentation = this.txtObservaciones.Text.Trim();

            this.Close();
        }
    }
}
