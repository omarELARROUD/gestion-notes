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
    public partial class Consultation : Form
    {
        Gestion f=null;
        public Consultation(Gestion a)
        {
            f=a;
            InitializeComponent();
        }

        private void Consultation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (f.Enabled == false) f.Enabled = true;
            f.Cnt = null;
        }
    }
}
