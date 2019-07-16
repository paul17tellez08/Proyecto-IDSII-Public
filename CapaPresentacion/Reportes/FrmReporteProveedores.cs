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
    public partial class FrmReporteProveedores : Form
    {

        private String _Texto;

        public String Texto
        {
            get { return _Texto; }
            set { _Texto = value; }
        }

        public FrmReporteProveedores()
        {
            InitializeComponent();
        }

        private void FrmReporteProveedores_Load(object sender, EventArgs e)
        {
            try
            {


                // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spbuscar_proveedor_razon_social' Puede moverla o quitarla según sea necesario.
                this.spbuscar_proveedor_razon_socialTableAdapter.Fill(this.dsPrincipal.spbuscar_proveedor_razon_social,Texto);

                this.reportViewer1.RefreshReport();

            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
