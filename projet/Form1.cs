namespace projet
{
    public partial class Gestion : Form
    {
        GestionEtd gsetd=null;
        GestionNotes gsnt = null;
        Consultation cnt = null;
        Bilan bl = null;
        filiere fil = null;
        matiere mat = null;
        public GestionEtd Gsetd { get => gsetd; set => gsetd = value; }
        public GestionNotes Gsnt { get => gsnt; set => gsnt = value; }
        public Consultation Cnt { get => cnt; set => cnt = value; }
        public Bilan Bl { get => bl; set => bl = value; }
        public filiere Fil { get => fil; set => fil = value; }
        public matiere Mat { get => mat; set => mat = value; }

        public Gestion()
        {
            InitializeComponent();
            WindowState= FormWindowState.Maximized;
        }

        private void gESTIONToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void etudiantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gsetd = new GestionEtd(this);
            this.Enabled = false;
            Gsetd.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void notesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Gsnt = new GestionNotes(this);
            this.Enabled = false;
            gsnt.ShowDialog();
        }

        private void affichageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cnt = new Consultation(this);
            this.Enabled = false;
            cnt.ShowDialog();
        }

        private void bilanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bl = new Bilan(this);
            this.Enabled = false;
            Bl.ShowDialog();
        }

        private void filièreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fil = new filiere(this);
            this.Enabled = false;
            Fil.ShowDialog();
        }

        private void matièreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mat = new matiere(this);
            this.Enabled = false;
            Mat.ShowDialog();
        }

        private void Gestion_Load(object sender, EventArgs e)
        {

        }
    }
}