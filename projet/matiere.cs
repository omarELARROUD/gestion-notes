﻿using System;
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
    public partial class matiere : Form
    {
        Gestion f;
        public matiere(Gestion a)
        {
            f = a;
            InitializeComponent();
        }

        private void matiere_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (f.Enabled == false) f.Enabled = true;
            f.Mat = null;
        }
    }
}
