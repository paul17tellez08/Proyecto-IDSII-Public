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
    public partial class FrmReporteCategoria : Form
    {
        private String _Texto;

        public String Texto
        {
            get { return _Texto; }
            set { _Texto = value; }
        }
        public FrmReporteCategoria()
        {
            InitializeComponent();
        }

        private void FrmReporteCategoria_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_categoria' Puede moverla o quitarla según sea necesario.
            try
            {
                this.spbuscar_categoriaTableAdapter.Fill(this.dsPrincipal.spbuscar_categoria, Texto);

                this.reportViewer1.RefreshReport();
            }
            catch
            {
               

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
