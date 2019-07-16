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
    public partial class FrmTrabajador : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;

        public FrmTrabajador()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese Nombre del Trabajador");
            this.ttMensaje.SetToolTip(this.txtUsuario, "Ingrese Usuario  del Trabajador");
            this.ttMensaje.SetToolTip(this.txtApellidos, "Ingrese Apellido del Trabajador");
            this.ttMensaje.SetToolTip(this.txtPassword, "Ingrese el Password del Trabajador");
            this.ttMensaje.SetToolTip(this.cbAcceso, "Ingrese Nivel de acceso del Trabajador");
            this.ttMensaje.SetToolTip(this.txtNum_Documento, "Ingrese Numero de Documento del Trabajador");
            this.ttMensaje.SetToolTip(this.txtDireccion, "Ingrese Direccion del Trabajador");
        }

        //Mostrar Mensaje de confirmacion
        private void MensajeOk(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //Mostrar Mensaje de Error
        private void MensajeError(string mensaje)
        {

            MessageBox.Show(mensaje, "Sistema de venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtNombre.Text = string.Empty;
            this.txtApellidos.Text = string.Empty;
            this.txtNum_Documento.Text = string.Empty;
            this.txtDireccion.Text = string.Empty;
            this.txtTelefono.Text = string.Empty;
            this.txtCorreo.Text = string.Empty;
            this.txtidtrabajador.Text = string.Empty;
            this.txtUsuario.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
        }

        //habilitar los controles del formulario

        private void Habilitar(bool valor)
        {
            this.txtNombre.ReadOnly = !valor;
            this.txtApellidos.ReadOnly = !valor;
            this.txtDireccion.ReadOnly = !valor;
            this.cbSexo.Enabled = valor;
            this.txtNum_Documento.ReadOnly = !valor;
            this.cbAcceso.Enabled = valor;
            this.txtTelefono.ReadOnly = !valor;
            this.txtCorreo.ReadOnly = !valor;
            this.txtidtrabajador.ReadOnly = !valor;
            this.txtUsuario.ReadOnly = !valor;
            this.txtPassword.ReadOnly = !valor;
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
            this.dataListado.DataSource = NTrabajador.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);

        }

        //Metodo BuscarApellidos

        private void BuscarApellidos()
        {
            this.dataListado.DataSource = NTrabajador.BuscarApellidos(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);

        }

        //Metodo buscarnumn_Documento

        private void BuscarNum_Documento()
        {
            this.dataListado.DataSource = NTrabajador.BuscarNum_Documento(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);

        }

        private void FrmTrabajador_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApellidos();
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
                            Rpta = NTrabajador.Eliminar(Convert.ToInt32(Codigo));

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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (cbBuscar.Text.Equals("Apellidos"))
            {
                this.BuscarApellidos();
            }
            else if (cbBuscar.Text.Equals("Documento"))
            {
                this.BuscarNum_Documento();
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

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            this.txtidtrabajador.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idtrabajador"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtApellidos.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["apellido"].Value);
            this.cbSexo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["sexo"].Value);
            this.dtFechaNac.Value = Convert.ToDateTime(this.dataListado.CurrentRow.Cells["fecha_nac"].Value);
            this.txtNum_Documento.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["num_documento"].Value);
            this.txtDireccion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["direccion"].Value);
            this.txtTelefono.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["telefono"].Value);
            this.txtCorreo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["email"].Value);
            this.cbAcceso.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["acesso"].Value);
            this.txtUsuario.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["usuario"].Value);
            this.txtPassword.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["password"].Value);

            this.tabControl1.SelectedIndex = 1;
           
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = " ";
                if (this.txtNombre.Text == string.Empty || this.txtApellidos.Text == string.Empty ||
                    this.txtDireccion.Text == string.Empty || this.txtNum_Documento.Text == string.Empty
                    || this.txtPassword.Text == string.Empty || this.txtUsuario.Text == string.Empty)
                {
                    MensajeError("Faltan ingresar algunos datos, seran remarcados");
                    erroricono.SetError(txtNombre, "Ingrese Nombres");
                    erroricono.SetError(txtApellidos, "Ingrese Apellido");
                    erroricono.SetError(txtDireccion, "Ingrese Direccion");
                    erroricono.SetError(txtNum_Documento, "Ingrese Numero Documento");
                    erroricono.SetError(txtUsuario, "Ingrese Usuario");
                    erroricono.SetError(txtPassword, "Ingrese Password");
                }
                else
                {
                    if (this.IsNuevo)
                    {
                        rpta = NTrabajador.Insertar(this.txtNombre.Text.Trim().ToUpper(),
                            this.txtApellidos.Text.Trim().ToUpper(),
                            this.cbSexo.Text,this.dtFechaNac.Value, 
                           txtNum_Documento.Text, txtDireccion.Text, txtTelefono.Text,
                            txtCorreo.Text, this.cbAcceso.Text, this.txtUsuario.Text,
                            this.txtPassword.Text);

                    }
                    else
                    {
                        rpta = NTrabajador.Editar(Convert.ToInt32(this.txtidtrabajador.Text),
                           this.txtNombre.Text.Trim().ToUpper(),
                            this.txtApellidos.Text.Trim().ToUpper(),
                            this.cbSexo.Text, this.dtFechaNac.Value,
                            txtNum_Documento.Text, txtDireccion.Text, txtTelefono.Text,
                            txtCorreo.Text, this.cbAcceso.Text, this.txtUsuario.Text, this.txtPassword.Text);


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
            if (!this.txtidtrabajador.Text.Equals(""))
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
            this.txtidtrabajador.Text = string.Empty;
            // this.Habilitar(false);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReporteTrabajador frm = new FrmReporteTrabajador();
            frm.Texto = txtBuscar.Text;
            frm.ShowDialog();
        }

        private void cbBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
