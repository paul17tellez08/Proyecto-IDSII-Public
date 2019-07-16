using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmReporteCliente : Form
    {

        private string _Texto;
        private string _Texto2;

        public string Texto2
        {
            get { return _Texto2; }
            set { _Texto2 = value; }
        }

        public string Texto
        {
            get { return _Texto; }
            set { _Texto = value; }
        }
        public FrmReporteCliente()
        {
            InitializeComponent();
        }

        private void FrmReporteCliente_Load(object sender, EventArgs e)
        {
            try
            {
                this.spbuscar_cliente_apellidoTableAdapter.Fill(this.dsPrincipal.spbuscar_cliente_apellido,Texto);

                this.reportViewer1.RefreshReport();
                
            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
