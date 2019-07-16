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
    public partial class FrmReporteArticulo : Form
    {
        private string _Texto;

        public string Texto
        {
            get { return _Texto; }
            set { _Texto = value; }
        }

        public FrmReporteArticulo()
        {
            InitializeComponent();
        }

        private void FrmReporteArticulo_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_articulo' Puede moverla o quitarla según sea necesario.
                this.spbuscar_articulo_nombreTableAdapter.Fill(this.dsPrincipal.spbuscar_articulo_nombre, Texto);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();
            }
        }

        private void spmostrar_articuloBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void spbuscar_articulo_nombreBindingSource_CurrentChanged(object sender, EventArgs e)
        {
                    }
    }
}
