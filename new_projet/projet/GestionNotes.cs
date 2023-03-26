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
    public partial class GestionNotes : Form
    {
       /* Gestion f = null;*/
        GestionEtd f1 = null;
        string code;
     /*   public GestionNotes(Gestion a)
           {
               f = a;
               InitializeComponent();
           }*/
        public GestionNotes(GestionEtd a,string c)
        {
            f1 = a;
            InitializeComponent();
            this.code = c;
        }

        private void GestionNotes_FormClosing(object sender, FormClosingEventArgs e)
        {
           /* if (f.Enabled == false) f.Enabled = true;
            f.Gsnt = null;*/
            if (f1.Enabled == false) f1.Enabled = true;
            f1.Gsnote = null;
        }

        private void GestionNotes_Load(object sender, EventArgs e)
        {
            t_CodeEleve.Text = code;
            t_CodeEleve.Enabled = false;


            matiere fi = new matiere("","","",0);
            var flist = fi.all();
            System.Object[] ItemObject1 = new System.Object[flist.Count];
            int i = 0;
            foreach (matiere frow in flist)
            {
                ItemObject1[i] = frow.Code;
                i++;
            }
            t_Matière.Items.AddRange(ItemObject1);

        }

        private void t_Matière_SelectedIndexChanged(object sender, EventArgs e)
        {
            t_Note.Text = "";
            notes a = new notes();
            Dictionary<string, object> dico = new Dictionary<string, object>();
            dico.Add("code_eleve", t_CodeEleve.Text);
            dico.Add("code_mat", t_Matière.Text);
            foreach (notes row in a.Select(dico))
            {
                t_Note.Text = row.Note.ToString();
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t_Note.Text = "";
            t_Matière.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (t_Matière.Text.Length > 0 && t_Note.Text.Length >0 )
            {
                notes a = new notes(t_Matière.Text,t_CodeEleve.Text,float.Parse(t_Note.Text));
                try
                {
                    a.save();//"func_save_notes"
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                MessageBox.Show("vous avez bien ajouté une note à l'élève "+t_CodeEleve.Text+" ! ");
            }
            else MessageBox.Show("il faut choisir la matière et priciser la note  !!!!!!!!!!!!!!!!!!!");
        }

        private void b_Modifier_Click(object sender, EventArgs e)
        {

            if (t_Matière.Text.Length > 0  && t_Note.Text.Length > 0 )
            {
                notes a = new notes(t_Matière.Text,t_CodeEleve.Text,float.Parse(t_Note.Text));
                Dictionary<string, object> dico = new Dictionary<string, object>();
                dico.Add("code_eleve", t_CodeEleve.Text);
                dico.Add("code_mat ", t_Matière.Text);

                foreach (notes row in a.Select(dico))
                {
                    a.Id = row.Id;
                }
                if (a.Id == 0)
                {
                    MessageBox.Show("la note inéxistante   !!!!!!!!!!!!!!");
                    return;
                }

                try
                {
                    a.save();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                MessageBox.Show("vous avez bien modofié la note  de l'eleve "+t_CodeEleve.Text+" ! ");
            }
            else MessageBox.Show("il faut choisir la matière et specifier la note  !!!!!!!!!!!!!!!!!!!");
        }

        private void b_Supprimer_Click(object sender, EventArgs e)
        {
            if (t_Matière.Text.Length > 0)
            {
                if (MessageBox.Show("vous êtes sÛre de supprimer l'élève " + t_CodeEleve.Text, "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    notes a = new notes(t_Matière.Text,t_CodeEleve.Text,0);
                    Dictionary<string, object> dico = new Dictionary<string, object>();
                    dico.Add("code_eleve", t_CodeEleve.Text);
                    dico.Add("code_mat ", t_Matière.Text);
                    foreach (notes row in a.Select(dico))
                    {
                        a.Id = row.Id;
                    }
                    if (a.Id == 0)
                    {
                        MessageBox.Show("la note  inéxistante  !!!!!!!!!!!!!!");
                        return;
                    }
                    try
                    {
                        a.delete();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                    MessageBox.Show("vous avez supprimé la note de l'eleve "+t_CodeEleve.Text+" ! ");
                }
            }
            else MessageBox.Show("il faut au moins  spécifier le code de matiere   !!!!!!!!!!!!!!!!!!!");
        }
    }
}
