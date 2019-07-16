using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;

namespace CapaPresentacion.Consultas
{
    public partial class FrmConsultas_Ventas_Fechas : Form
    {
        public FrmConsultas_Ventas_Fechas()
        {
            InitializeComponent();
        }

        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;

        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NVenta.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarFechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NVenta.BuscarFechas(this.dtFecha1.Value.ToString("dd/MM/yyyy"),
                this.dtFecha2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

      

        private void FrmConsultas_Ventas_Fechas_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
           // this.Mostrar();
            //this.Habilitar(false);
            //this.Botones();
            //this.crearTabla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmReporteVentas frm = new FrmReporteVentas();
            frm.Texto = Convert.ToString(dtFecha1.Value);
            frm.Texto2 = Convert.ToString(dtFecha2.Value);
            frm.ShowDialog();
        }
    }
}
