namespace projet
{
    public partial class Gestion : Form
    {
        GestionEtd gsetd=null;
        MenuGestionNotes gsnt = null;
        Consultation cnt = null;
        Bilan bl = null;
        i_filiere fil = null;
        i_matiere mat = null;
        GestionModule gm = null;
        public GestionEtd Gsetd { get => gsetd; set => gsetd = value; }
        public MenuGestionNotes Gsnt { get => gsnt; set => gsnt = value; }
        public Consultation Cnt { get => cnt; set => cnt = value; }
        public Bilan Bl { get => bl; set => bl = value; }
        public i_filiere Fil { get => fil; set => fil = value; }
        public i_matiere Mat { get => mat; set => mat = value; }
        public GestionModule Gm { get => gm; set => gm = value; }

        public Gestion()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
      
    
        }
        

        private void gESTIONToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void etudiantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Gsetd = new GestionEtd(this);
             this.Enabled = false;
             Gsetd.ShowDialog();*/

            if (Gsetd != null && Gsetd.Visible == true) return;
            Gsetd = new GestionEtd();
            Gsetd.MdiParent = this;
            Gsetd.Show();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
          
        }

        private void notesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*  Gsnt = new MenuGestionNotes(this);
              this.Enabled = false;
              gsnt.ShowDialog();*/

            if (Gsnt != null && Gsnt.Visible == true) return;
            Gsnt = new MenuGestionNotes();
            Gsnt.MdiParent = this;
            Gsnt.Show();
        }

        private void affichageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*    cnt = new Consultation(this);
                this.Enabled = false;
                cnt.ShowDialog();*/
            if (cnt != null && cnt.Visible == true) return;
            cnt = new Consultation();
            cnt.MdiParent = this;
            cnt.Show();
        }

        private void bilanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Bl = new Bilan(this);
             this.Enabled = false;
             Bl.ShowDialog();*/
            if (Bl != null && Bl.Visible == true) return;
            Bl = new Bilan();
            Bl.MdiParent = this;
            Bl.Show();
        }

        private void filièreToolStripMenuItem_Click(object sender, EventArgs e)
        {

            /*   
                 fil = new i_filiere(this);   
               this.Enabled = false;
               Fil.ShowDialog();*/
            if (fil != null && fil.Visible == true) return;
            fil = new i_filiere();
            fil.MdiParent = this;
            fil.Show();
        }

        private void matièreToolStripMenuItem_Click(object sender, EventArgs e)
        {


            /* 
                 mat = new i_matiere(this); 
            this.Enabled = false;
          Mat.ShowDialog();*/
            if (mat != null && mat.Visible == true) return;
             mat = new i_matiere();
            mat.MdiParent = this;
            mat.Show();

        }

        private void Gestion_Load(object sender, EventArgs e)
        {
            MessageBox.Show("bienvenue !");
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
             
                if (mat != null && mat.Visible == true) mat.Close();
                if (Gsetd != null && Gsetd.Visible == true) Gsetd.Close();
                if (Gsnt != null && Gsnt.Visible == true) Gsnt.Close();
                if (cnt != null && cnt.Visible == true) cnt.Close();
                if (Bl != null && Bl.Visible == true) Bl.Close();
                if (fil != null && fil.Visible == true) fil.Close();
                if (Gm != null && Gm.Visible == true) Gm.Close();
            return;
        

         
        }

        private void moduleToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (Gm != null && Gm.Visible == true) return;
            Gm = new GestionModule();
            Gm.MdiParent = this;
            Gm.Show();
        }
    }
}