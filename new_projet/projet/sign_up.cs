namespace projet
{
    public partial class sign_up : Form
    {
            public sign_up()
        {
            InitializeComponent();
            panel2.Enabled = false;
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        
            panel1.Enabled = true;
            panel2.Enabled = false;
        }

        private void suivant_Click(object sender, EventArgs e)
        {
            if(suivant.Text == "terminer")
            {
                if(c_SGBD.Text.Length>0 && t_SN.Text.Length>0 && t_host.Text.Length>0 && t_port.Text.Length>0 )   {
                    MessageBox.Show("vous avez bien creer un compte ! ");
                
                     this.Close();
                }
                else   MessageBox.Show(" baqi  ");
            }
            if(t_log.Text.Length>0 && t_pwd.Text.Length>0 && t_conf.Text.Length>0 )
            {
                if (t_pwd.Text == t_conf.Text)
                {
                    panel1.Enabled = false;
                    panel2.Enabled = true;
                    suivant.Text = "terminer";
                }
                else MessageBox.Show("le password est incorrecte !!!!!!!!!!!!!!!!");
            }
            else MessageBox.Show("il faut remplir tout le formulaire !!!!!!!!!!!!!!!!");
        }

        private void sign_up_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void sign_up_Load(object sender, EventArgs e)
        {

            System.Object[] ItemObject = new System.Object[2];

            ItemObject[0] = "MySql";
            ItemObject[1] = "Oracle";
            c_SGBD.Items.AddRange(ItemObject);
        }
    }
}
