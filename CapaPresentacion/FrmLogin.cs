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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            lblHora.Text = DateTime.Now.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DataTable Datos = CapaNegocio.NTrabajador.Login(this.txtusuario.Text, this.txtpassword.Text);
            if(Datos.Rows.Count==0){
                MessageBox.Show("No Tiene Acceso al Sistema","Sistema de Ventas",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }else{
                FrmPrincipal prin = new FrmPrincipal();
                prin.Idtrabajador = Datos.Rows[0][0].ToString();
                prin.Apellidos = Datos.Rows[0][1].ToString();
                prin.Nombre = Datos.Rows[0][2].ToString();
                prin.Acceso = Datos.Rows[0][3].ToString();

                prin.Show();
                 this.Hide();

            }

         
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
