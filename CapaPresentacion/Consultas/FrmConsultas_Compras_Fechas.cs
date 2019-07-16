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
    public partial class FrmConsultas_Compras_Fechas : Form
    {
        public FrmConsultas_Compras_Fechas()
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
            this.dataListado.DataSource = NIngreso.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        //Método BuscarFechas
        private void BuscarFechas()
        {
            this.dataListado.DataSource = NIngreso.BuscarFechas(this.dtfecha1.Value.ToString("dd/MM/yyyy"),
                this.dtfecha2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void FrmConsultas_Compras_Fechas_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReporteCompras frm = new FrmReporteCompras();
            frm.Texto = Convert.ToString(dtfecha1.Value);
            frm.Texto2 = Convert.ToString(dtfecha2.Value);
            frm.ShowDialog();
        }
    }
}
