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
    public partial class FrmReporteTrabajador : Form
    {

        private String _Texto;

        public String Texto
        {
            get { return _Texto; }
            set { _Texto = value; }
        }
        public FrmReporteTrabajador()
        {
            InitializeComponent();
        }

        private void FrmReporteTrabajador_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spbuscar_trabajador_apellido' Puede moverla o quitarla según sea necesario.
                this.spbuscar_trabajador_apellidoTableAdapter.Fill(this.dsPrincipal.spbuscar_trabajador_apellido,Texto);

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                this.reportViewer1.RefreshReport();
            }
        }

        private void spbuscar_trabajador_apellidoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
