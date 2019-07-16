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
    public partial class FrmPrincipal : Form
    {
        private int childFormNumber = 0;

        public string Idtrabajador = "";
        public string Apellidos = "";
        public string Nombre = "";
        public string Acceso = "";


        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Ventana " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCategoria cat = new FrmCategoria();
            cat.MdiParent = this;
            cat.Show();
        }

        private void presentacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPresentacion cat = new FrmPresentacion();
            cat.MdiParent = this;
            cat.Show();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmArticulo art = FrmArticulo.GetInstancia();
            art.MdiParent = this;
            art.Show();
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmIngreso art = FrmIngreso.GetInstancia();
            art.MdiParent = this;
            art.Show();
            art.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmProveedor pro = new FrmProveedor();
            pro.MdiParent = this;
            pro.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCliente pro = new FrmCliente();
            pro.MdiParent = this;
            pro.Show();
        }

        private void trabajadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTrabajador pro = new FrmTrabajador();
            pro.MdiParent = this;
            pro.Show();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            GestionUsuario();
        }

        private void GestionUsuario()
        {
            if(Acceso =="Administrador"){
                this.mnuAlmacen.Enabled = true;
                this.mnuCompras.Enabled = true;
                this.mnuVentas.Enabled = true;
                this.mnuMantenimiento.Enabled = true;
                this.mnuConsultas.Enabled = true;
                this.mnuHerramienta.Enabled = true;
                this.TsCompras.Enabled = true;
                this.TsVentas.Enabled = true;

            }
            else
            {
                if(Acceso == "Vendedor"){
                    this.mnuAlmacen.Enabled = false;
                    this.mnuCompras.Enabled = false;
                    this.mnuVentas.Enabled = true;
                    this.mnuMantenimiento.Enabled = false;
                    this.mnuConsultas.Enabled = true;
                    this.mnuHerramienta.Enabled = false;
                    this.TsCompras.Enabled = false;
                    this.TsVentas.Enabled = true;
                }
                else
                {
                    if(Acceso=="Almacen"){
                        this.mnuAlmacen.Enabled = true;
                        this.mnuCompras.Enabled = true;
                        this.mnuVentas.Enabled = false;
                        this.mnuMantenimiento.Enabled = false;
                        this.mnuConsultas.Enabled = true;
                        this.mnuHerramienta.Enabled = true;
                        this.TsCompras.Enabled = true;
                        this.TsVentas.Enabled = false;

                    }
                    else
                    {
                        this.mnuAlmacen.Enabled = false;
                        this.mnuCompras.Enabled = false;
                        this.mnuVentas.Enabled = false;
                        this.mnuMantenimiento.Enabled = false;
                        this.mnuConsultas.Enabled = false;
                        this.mnuHerramienta.Enabled = false;
                        this.TsCompras.Enabled = false;
                        this.TsVentas.Enabled = false;
                    }
                }
            }

        }

        private void ventasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmVenta frm = FrmVenta.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void stockDeArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas.FrmConsultas_Stock_Articulos frm = new Consultas.FrmConsultas_Stock_Articulos();
            frm.MdiParent = this;
            frm.Show();
        }

        private void TsVentas_Click(object sender, EventArgs e)
        {
            FrmVenta frm = FrmVenta.GetInstancia();
            frm.MdiParent = this;
            frm.Show();
            frm.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void TsCompras_Click(object sender, EventArgs e)
        {
            FrmIngreso art = FrmIngreso.GetInstancia();
            art.MdiParent = this;
            art.Show();
            art.Idtrabajador = Convert.ToInt32(this.Idtrabajador);
        }

        private void ventasPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas.FrmConsultas_Ventas_Fechas frm = new Consultas.FrmConsultas_Ventas_Fechas();
            frm.MdiParent = this;
            frm.Show();

        }

        private void comprasPorFechaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Consultas.FrmConsultas_Compras_Fechas frm = new Consultas.FrmConsultas_Compras_Fechas();
            frm.MdiParent = this;
            frm.Show();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
            frm.MdiParent = this;
        }
    }
}