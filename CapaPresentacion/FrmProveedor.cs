using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Data.SqlClient;

using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FrmProveedor : Form
    {

        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmProveedor()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtRazon_Social, "Ingrese Razon Social del Proveedor");
            this.ttMensaje.SetToolTip(this.txtNum_Documento, "Ingrese Numero de Documento del Proveedor");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese Direccion del Proveedor");
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
            this.txtRazon_Social.Text = string.Empty;
            this.txtNum_Documento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtUrl.Text = string.Empty;
            this.txtCorreo.Text = string.Empty;
            this.txtidproveedor.Text = string.Empty;
        }

        //habilitar los controles del formulario

        private void Habilitar(bool valor)
        {
            this.txtRazon_Social.ReadOnly= !valor;
            this.txtNum_Documento.ReadOnly = !valor;
            this.cbSector_Comercial.Enabled = valor;
            this.cbTipo_Documento.Enabled = valor;
            this.txtDireccion.ReadOnly = !valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtUrl.ReadOnly = !valor;
            this.txtCorreo.ReadOnly = !valor;
            this.txtidproveedor.ReadOnly = !valor;
        }

        //Habilitar los botones

        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar) // Alt + 124
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;

            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }

        }

        //Metodo para ocultar columnas
        private void OcultarColumnas()
        {
            this.dataListado.Columns[0].Visible = false;
            this.dataListado.Columns[1].Visible = false;
            //this.dataListado.Columns[2].Visible = false;
            //this.dataListado.Columns[3].Visible = false;
        }

        //Metodo Mostrar 

        private void Mostrar()
        {
            this.dataListado.DataSource = NProveedor.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);

        }

        //Metodo BuscarRazon_Socail

        private void BuscarRazon_Social()
        {
            this.dataListado.DataSource = NProveedor.BuscarRazon_Social(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);

        }

        //Metodo buscarnumn_Documento

        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = NProveedor.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);

        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            this.txtidproveedor.Enabled = false;
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void cbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbBuscar.Text.Equals("Razon Social")){
                this.BuscarRazon_Social();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Realmente Desea Eliminar los Registros", "Sistema de ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string Rpta = "";

                    foreach (DataGridViewRow row in dataListado.Rows)
                    {

                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            Rpta = NProveedor.Eliminar(Convert.ToInt32(Codigo));

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeError("Se Elimino Correctamente el registro");
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtRazon_Social.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = " ";
                if (this.txtRazon_Social.Text == string.Empty || this.txtNum_Documento.Text==string.Empty || this.txtDireccion.Text ==string.Empty)
                {
                    MensajeError("Faltan ingresar algunos datos, seran remarcados");
                    erroricono.SetError(txtRazon_Social, "Ingrese un nombre");
                    erroricono.SetError(txtNum_Documento, "Ingrese un nombre");
                    erroricono.SetError(txtDireccion, "Ingrese un nombre");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NProveedor.Insertar(this.txtRazon_Social.Text.Trim().ToUpper(),
                            this.cbSector_Comercial.Text,cbTipo_Documento.Text,
                            txtNum_Documento.Text,txtDireccion.Text,txtTelefono.Text,
                            txtCorreo.Text,txtUrl.Text);

                    }
                    else
                    {
                        rpta = NProveedor.Editar(Convert.ToInt32(this.txtidproveedor.Text),
                            this.txtRazon_Social.Text.Trim().ToUpper(),
                            this.cbSector_Comercial.Text,cbTipo_Documento.Text,
                            txtNum_Documento.Text,txtDireccion.Text,txtTelefono.Text,
                            txtCorreo.Text,txtUrl.Text);
                            

                    }
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se inserto de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizo de forma correcta el registro");
                        }
                    }
                    else
                    {
                        this.MensajeError(rpta);
                    }
                    this.IsNuevo = false;
                    this.IsEditar = false;
                    this.Botones();
                    this.Limpiar();
                    this.Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(!this.txtidproveedor.Text.Equals(" "))
            {
                this.IsEditar = true;
                this.Botones();
                this.Habilitar(true);
            }
            else
            {
                this.MensajeError("Debe de seleccionar primero el registro a Modificar");
            }
    }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.IsNuevo = false;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.txtidproveedor.Text=string.Empty;
           // this.Habilitar(false);
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtidproveedor.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idproveedor"].Value);
            this.txtRazon_Social.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["razon_social"].Value);
            this.cbSector_Comercial.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sector_comercial"].Value);
            this.cbTipo_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["tipo_documento"].Value);
            this.txtNum_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["num_documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtCorreo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            this.txtUrl.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["url"].Value);
            
            
            this.tabControl1.SelectedIndex = 1;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Razon Social"))
            {
                this.BuscarRazon_Social();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Razon Social"))
            {
                this.BuscarRazon_Social();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
            }
        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRazon_Social_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtidproveedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void ttMensaje_Popup(object sender, PopupEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cbTipo_Documento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNum_Documento_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void cbSector_Comercial_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReporteProveedores frm = new FrmReporteProveedores();
            frm.Texto = txtBuscar.Text;
            frm.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
