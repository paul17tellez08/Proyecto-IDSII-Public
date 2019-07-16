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

namespace CapaPresentacion
{
    public partial class FrmIngreso : Form
    {
        public int Idtrabajador;
        private bool IsNuevo;
        private DataTable dtDetalle;
        private decimal totalPagado = 0;
        private static FrmIngreso _instancia;

        public static FrmIngreso GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia=new FrmIngreso();
            }
            return _instancia;
        }

        public void setProveedor(string idproveedor,string nombre)
        {
            this.txtidproveedor.Text = idproveedor;
            this.txtproveedor.Text = nombre;
        }

        public void setArticulo(string idarticulo, string nombre)
        {
            this.txtidarticulo.Text = idarticulo;
            this.txtarticulo.Text = nombre;
        }


        public FrmIngreso()
        { 
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtproveedor,"Seleccione el Proveedor");
            this.ttMensaje.SetToolTip(this.txtserie, "Ingrese la serie del comprobante");
            this.ttMensaje.SetToolTip(this.txtcorrelativo, "Ingrese el numero del comprobante");
            this.ttMensaje.SetToolTip(this.txtstock, "Ingrese la cantidad de compra");
            this.ttMensaje.SetToolTip(this.txtarticulo, "Seleccione el Articulo de compra");
            this.txtidproveedor.Visible = false;
            this.txtidarticulo.Visible = false;
            this.txtproveedor.ReadOnly = true;
            this.txtarticulo.ReadOnly = true;


        }

        //Mostrar Mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {

            MessageBox.Show(mensaje, "Sistema de venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtIdIngreso.Text = string.Empty;
            this.txtidproveedor.Text = string.Empty;
            this.txtproveedor.Text = string.Empty;
            this.txtserie.Text = string.Empty;
            this.txtcorrelativo.Text = string.Empty;
            this.txtIGV.Text = string.Empty;

            this.lblTotalPagado.Text = "0.0";
            this.txtIGV.Text = "18";
            this.crearTabla();
        }

        private void limpiarDetalle()
        {
            this.txtidarticulo.Text = string.Empty;
            this.txtarticulo.Text = string.Empty;
            this.txtstock.Text = string.Empty;
            this.txtPrecioCompra.Text = string.Empty;
            this.txtPrecioVenta.Text = string.Empty;
        }

        //habilitar los controles del formulario

        private void Habilitar(bool valor)
        {
            this.txtIdIngreso.ReadOnly = !valor;
            this.txtserie.ReadOnly = !valor;
            this.txtcorrelativo.ReadOnly = !valor;
            this.txtIGV.ReadOnly = !valor;
            this.dtFecha.Enabled = valor;
            this.cbComprobante.Enabled = valor;
            this.txtstock.ReadOnly = !valor;
            this.txtPrecioCompra.ReadOnly = !valor;
            this.txtPrecioVenta.ReadOnly = !valor;
            this.dtFecha_Produccion.Enabled = valor;
            this.dtFecha_Vencimiento.Enabled = valor;

            this.btnbuscararticulo.Enabled = valor;
            this.btnbuscarproveedor.Enabled = valor;
            this.btnAgregar.Enabled = valor;
            this.btnQuitar.Enabled = valor;
        }

        //Habilitar los botones

        private void Botones()
        {
            if (this.IsNuevo) // Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
               // this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;

            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = true;
                //this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

        }

        //Metodo para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            //this.dataListado.Columns[6].Visible = false;
            //this.dataListado.Columns[8].Visible = false;
        }

        //Metodo Mostrar 

        private void Mostrar()
        {
            this.dataListado.DataSource = NIngreso.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);

        }

        //Metodo BuscarNombre

        private void BuscarFechas()
        {
            this.dataListado.DataSource = NIngreso.BuscarFechas(this.dtfecha1.Value.ToString("dd/MM/yyyy"),
            this.dtfecha2.Value.ToString("dd/MM/yyyy"));
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);

        }

        private void MostrarDetalle()
        {
            this.dataListadoDetalle.DataSource = NIngreso.MostrarDetalle(this.txtIdIngreso.Text);
        }

        private void crearTabla()
        {
            this.dtDetalle = new DataTable("Detalle");
            this.dtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.dtDetalle.Columns.Add("precio_compra", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("stock_inicial", System.Type.GetType("System.Int32"));
            this.dtDetalle.Columns.Add("fecha_produccion", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("fecha_vencimiento", System.Type.GetType("System.DateTime"));
            this.dtDetalle.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
            this.dtDetalle.Columns.Add("Impuesto", System.Type.GetType("System.Decimal"));
            //Relacionar nuestro DataGRidView con nuestro DataTable
            this.dataListadoDetalle.DataSource = this.dtDetalle;
        }



        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.crearTabla();
            this.txtIdIngreso.Enabled = false;

        }

        private void FrmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instancia = null;
        }

        private void btnbuscarproveedor_Click(object sender, EventArgs e)
        {
            FrmVistaProveedor_Ingreso vista = new FrmVistaProveedor_Ingreso();
            vista.ShowDialog();
        }

        private void btnbuscararticulo_Click(object sender, EventArgs e)
        {
            FrmVistaArticulo_Ingreso vista = new FrmVistaArticulo_Ingreso();
            vista.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarFechas();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtIdIngreso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idingreso"].Value);
            this.txtproveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["proveedor"].Value);
            this.dtFecha.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha"].Value);
            this.cbComprobante.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_comprobante"].Value);
            this.txtserie.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["serie"].Value);
            this.txtcorrelativo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["correlativo"].Value);
            this.lblTotalPagado.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["total"].Value);
           // this.txtIGV.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Impuesto"].Value);
            this.MostrarDetalle();
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Anular los Registros", "Sistema de ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {

                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NIngreso.Anular(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeError("Se Anulo Correctamente el ingreso");
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Mostrar();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                this.dataListado.Columns[0].Visible = true;
            }
            else
            {
                this.dataListado.Columns[0].Visible = false;
            }
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtserie.Focus();
            this.limpiarDetalle();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(false);
            this.limpiarDetalle();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtidproveedor.Text == string.Empty || this.txtserie.Text == string.Empty
                    || this.txtcorrelativo.Text == string.Empty || this.txtIGV.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    erroricono.SetError(txtidproveedor, "Ingrese un Valor");
                    erroricono.SetError(txtserie, "Ingrese un Valor");
                    erroricono.SetError(txtcorrelativo, "Ingrese un Valor");
                    erroricono.SetError(txtIGV, "Ingrese un Valor");
                }
                else
                {

                    if (this.IsNuevo)
                    {
                        rpta = NIngreso.Insertar(Idtrabajador, Convert.ToInt32(this.txtidproveedor.Text),
                            dtFecha.Value, cbComprobante.Text, txtserie.Text, txtcorrelativo.Text,
                            Convert.ToDecimal(txtIGV.Text), "EMITIDO", dtDetalle);

                    }


                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }


                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }

                    this.IsNuevo = false;
                    this.Botones();
                    this.Limpiar();
                    this.limpiarDetalle();
                    this.Mostrar();



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.txtidarticulo.Text == string.Empty || this.txtstock.Text == string.Empty
                    || this.txtPrecioCompra.Text == string.Empty || this.txtPrecioVenta.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    erroricono.SetError(txtidarticulo, "Ingrese un Valor");
                    erroricono.SetError(txtstock, "Ingrese un Valor");
                    erroricono.SetError(txtPrecioCompra, "Ingrese un Valor");
                    erroricono.SetError(txtPrecioVenta, "Ingrese un Valor");
                }
                else
                {
                    bool registrar = true;
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        if (Convert.ToInt32(row["idarticulo"]) == Convert.ToInt32(this.txtidarticulo.Text))
                        {
                            registrar = false;
                            this.MensajeError("YA se encuentra el artículo en el detalle");
                        }
                    }
                    if (registrar)
                    {
                        decimal subTotal = Convert.ToDecimal(this.txtstock.Text) * Convert.ToDecimal(this.txtPrecioCompra.Text);
                        totalPagado = totalPagado + subTotal;
                        this.lblTotalPagado.Text = totalPagado.ToString("#0.00#");
                        //Agregar ese detalle al datalistadoDetalle
                        DataRow row = this.dtDetalle.NewRow();
                        row["idarticulo"] = Convert.ToInt32(this.txtidarticulo.Text);
                        row["articulo"] = this.txtarticulo.Text;
                        row["precio_compra"] = Convert.ToDecimal(this.txtPrecioCompra.Text);
                        row["precio_venta"] = Convert.ToDecimal(this.txtPrecioVenta.Text);
                        row["stock_inicial"] = Convert.ToInt32(this.txtstock.Text);
                        row["fecha_produccion"] = dtFecha_Produccion.Value;
                        row["fecha_vencimiento"] = dtFecha_Vencimiento.Value;
                        row["subtotal"] = subTotal;
                        this.dtDetalle.Rows.Add(row);
                        this.limpiarDetalle();

                    }




                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                int indiceFila = this.dataListadoDetalle.CurrentCell.RowIndex;
                DataRow row = this.dtDetalle.Rows[indiceFila];
                //Dismiuir el total pagado
                this.totalPagado = this.totalPagado - Convert.ToDecimal(row["subtotal"].ToString());
                this.lblTotalPagado.Text = totalPagado.ToString("#0.00#");
                //Removemos la fija
                this.dtDetalle.Rows.Remove(row);
            }
            catch (Exception ex)
            {
                MensajeError("No hay fila para remover");
            }
        }

        private void dataListadoDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
