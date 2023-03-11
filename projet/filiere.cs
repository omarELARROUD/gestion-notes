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
    public partial class filiere : Form
    {
        Gestion f;
        public filiere(Gestion a)
        {
            f = a;
            InitializeComponent();
        }

        private void filiere_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (f.Enabled == false) f.Enabled = true;
            f.Fil = null;
        }

        private void filiere_Load(object sender, EventArgs e)
        {

        }
    }
}
