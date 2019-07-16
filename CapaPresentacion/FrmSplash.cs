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
    public partial class FrmSplash : Form
    {
        public FrmSplash()
        {
            InitializeComponent();
            this.CenterToParent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            while (this.Opacity > 0)
            {
                this.Opacity -= 0.0001;
            }
            this.Hide();
            FrmLogin lg = new FrmLogin();
            lg.Show();
            timer1.Stop();
        }

        private void FrmSplash_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1500;
            timer1.Start();
        }
    }
}
