using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projet
{
    public partial class GestionEtd : Form
    {
        Gestion f;
        public GestionEtd(Gestion a)
        {
            f = a;
            InitializeComponent();
        }

     

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GestionEtd_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            if (f.Enabled == false) f.Enabled = true;
            f.Gsetd = null;
        }
    }
}
