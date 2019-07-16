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
    public partial class FrmReportePresentacion : Form
    {
        private String _Texto;

        public String Texto
        {
            get { return _Texto; }
            set { _Texto = value; }
        }


        public FrmReportePresentacion()
        {
            InitializeComponent();
        }

        private void FrmReportePresentacion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spbuscar_presentacion_nombre' Puede moverla o quitarla según sea necesario.
            try
            {
                this.spbuscar_presentacion_nombreTableAdapter.Fill(this.dsPrincipal.spbuscar_presentacion_nombre, Texto);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
