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
    public partial class FrmArticulo : Form
    {

        private bool IsNuevo = false;
        private bool IsEditar = false;

        private static FrmArticulo _Instancia;

        public static FrmArticulo GetInstancia()
        {
            if(_Instancia==null){
                _Instancia = new FrmArticulo();
            }
            return _Instancia;
        }

        public void setCategoria(string idcategoria, string nombre)
        {
            this.txtidcategoria.Text = idcategoria;
            this.txtcategoria.Text = nombre;
        }

        public FrmArticulo()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el Nombre de la Categoria");
            this.ttMensaje.SetToolTip(this.txtcategoria, "Seleccione la Categoria del articulo");
            this.ttMensaje.SetToolTip(this.pximagen, "Seleccione la imagen del Categoria");
            this.ttMensaje.SetToolTip(this.cbidpresentacion, "Seleccione la presentacion del articulo");
            this.txtidcategoria.Visible = false;
            this.txtcategoria.ReadOnly = true;
            this.LlenarComboPresentacion();
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
            this.txtcategoria.Text = string.Empty;
            this.txtcodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtidcategoria.Text = string.Empty;
            this.txtIdarticulo.Text = string.Empty;
            this.pximagen.Image = global::CapaPresentacion.Properties.Resources.file;
        }

        //habilitar los controles del formulario

        private void Habilitar(bool valor)
        {
            this.txtcodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.btnbuscarcategoria.Enabled = valor;
            this.cbidpresentacion.Enabled = valor;
            this.btncargar.Enabled = valor;
            this.btnlimpiar.Enabled = valor;
            this.txtIdarticulo.ReadOnly = !valor;
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
            this.dataListado.Columns[6].Visible = false;
            this.dataListado.Columns[8].Visible = false;
        }

        //Metodo Mostrar 

        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulo.Mostrar();
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);

        }

        //Metodo BuscarNombre

        private void BuscarNombre()
        {
            this.dataListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            lblTotal.Text = "Total de Registro: " + Convert.ToString(dataListado.Rows.Count);

        }

        private void LlenarComboPresentacion()
        {
            cbidpresentacion.DataSource = NPresentacion.Mostrar();
            cbidpresentacion.ValueMember = "idpresentacion";
            cbidpresentacion.DisplayMember = "nombre";
        }



        private void FrmArticulo_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Left = 0;

            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
            this.txtIdarticulo.Enabled = false;


        }

        private void btncargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if(result ==DialogResult.OK){
                this.pximagen.SizeMode = PictureBoxSizeMode.StretchImage;
                this.pximagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            this.pximagen.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pximagen.Image = global::CapaPresentacion.Properties.Resources.file;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
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
                            Rpta = NArticulo.Eliminar(Convert.ToInt32(Codigo));

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
            this.txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtNombre.Text == string.Empty || this.txtidcategoria.Text == string.Empty || this.txtcodigo.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, serán remarcados");
                    erroricono.SetError(txtNombre, "Ingrese un Valor");
                    erroricono.SetError(txtcodigo, "Ingrese un Valor");
                    erroricono.SetError(txtidcategoria, "Ingrese un Valor");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    this.pximagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                    byte[] imagen = ms.GetBuffer();


                    if (this.IsNuevo)
                    {
                        rpta = NArticulo.Insertar(this.txtcodigo.Text, this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDescripcion.Text.Trim(), imagen, Convert.ToInt32(this.txtidcategoria.Text),
                            Convert.ToInt32(this.cbidpresentacion.SelectedValue));

                    }
                    else
                    {
                        rpta = NArticulo.Editar(Convert.ToInt32(this.txtIdarticulo.Text),
                            this.txtcodigo.Text, this.txtNombre.Text.Trim().ToUpper(),
                            this.txtDescripcion.Text.Trim(), imagen, Convert.ToInt32(this.txtidcategoria.Text),
                            Convert.ToInt32(this.cbidpresentacion.SelectedValue));
                    }

                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo)
                        {
                            this.MensajeOk("Se Insertó de forma correcta el registro");
                        }
                        else
                        {
                            this.MensajeOk("Se Actualizó de forma correcta el registro");
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
            if (!this.txtIdarticulo.Text.Equals(""))
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
            this.Habilitar(false);
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
            this.txtIdarticulo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idarticulo"].Value);
            this.txtcodigo.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["codigo"].Value);
            this.txtNombre.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            this.txtDescripcion.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);

            byte[] imagenBuffer =(byte[])this.dataListado.CurrentRow.Cells["imagen"].Value;
            System.IO.MemoryStream ms = new System.IO.MemoryStream(imagenBuffer);

            this.pximagen.Image = Image.FromStream(ms);
            this.pximagen.SizeMode = PictureBoxSizeMode.StretchImage;

            this.txtidcategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["idcategoria"].Value);
            this.txtcategoria.Text = Convert.ToString(this.dataListado.CurrentRow.Cells["Categoria"].Value);
            this.cbidpresentacion.SelectedValue = Convert.ToString(this.dataListado.CurrentRow.Cells["idpresentacion"].Value);



            this.tabControl1.SelectedIndex = 1;
        }

        private void btnbuscarcategoria_Click(object sender, EventArgs e)
        {
            FrmVista form = new FrmVista();
            form.ShowDialog();
        }

        private void txtIdarticulo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            FrmReporteArticulo frm = new FrmReporteArticulo();
            frm.Texto = txtBuscar.Text;
            frm.ShowDialog();
        }
    }
}
