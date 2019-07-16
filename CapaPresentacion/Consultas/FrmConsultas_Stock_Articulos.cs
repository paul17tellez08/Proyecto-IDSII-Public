﻿using System;
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
    public partial class FrmConsultas_Stock_Articulos : Form
    {
        public FrmConsultas_Stock_Articulos()
        {
            InitializeComponent();
        }
        //Método para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;

        }

        //Método Mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulo.Stock_Articulos();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void FrmConsultas_Stock_Articulos_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReporteStock frm = new FrmReporteStock();
            frm.ShowDialog();
        }
    }
}
