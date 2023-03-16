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
    public partial class Bilan : Form
    {
        Gestion f;
        Dictionary<string, object> d = new Dictionary<string, object> ();
        Dictionary<string, object> d1 = new Dictionary<string, object>();
        public Bilan()
        { 
            InitializeComponent();
        }

        private void Bilan_FormClosing(object sender, FormClosingEventArgs e)
        {
         /*   if (f.Enabled == false) f.Enabled = true;
            f.Bl = null*/;
        }

        private void Bilan_Load(object sender, EventArgs e)
        {


            filiere fi = new filiere();
            var flist = fi.all();
            System.Object[] ItemObject1 = new System.Object[flist.Count];
            int i = 0;
            foreach (filiere frow in flist)
            {
                ItemObject1[i] = frow.Code;
                i++;
            }
            t_Filiere.Items.AddRange(ItemObject1);

            eleve mat = new eleve();
            var matlist = mat.all();
            System.Object[] ItemObject11 = new System.Object[matlist.Count];
            i = 0;
            foreach (eleve frow in matlist)
            {
                ItemObject11[i] = frow.Code;
                i++;
            }
            t_Etudiant.Items.AddRange(ItemObject11);

            System.Object[] ItemObject = new System.Object[3];
            for ( i = 0; i < 3; i++)
            {
                ItemObject[i] = i + 1;
            }
            t_Niveau.Items.AddRange(ItemObject);

            load();




            

        }
        void load()
        {
            List<dynamic> res = new List<dynamic>();
            notes moy = new notes();
            module mod = new module();
            matiere mat = new matiere();
            filiere fil = new filiere();

            List<dynamic> lmoy = moy.all();

            if (t_Etudiant.Text.Length > 0)
            {
                lmoy = moy.Select(d);
            }

            List<dynamic> lmod = mod.all();
            if (t_Filiere.Text.Length > 0 || t_Niveau.Text.Length > 0)
            {
                lmod = mod.Select(d1);
            }

            List<dynamic> lmat = mat.all();
            List<dynamic> lfil = fil.all();

            var req = (
from moye in lmoy
join mati in lmat
on moye.Code_mat equals mati.Code
join modu in lmod
on mati.Code_module equals modu.Code
select new MoyEtd(mati.Code, mati.Designation, modu.Semestre, moye.Note, moye.Code_eleve)
);
            foreach (MoyEtd a in req)
            {
                res.Add(a);
            }

            table_Bilan.DataSource = null;
            table_Bilan.DataSource = res;
            table_Bilan.Columns["code_eleve"].Visible = false;
            if (t_Etudiant.Text.Length == 0)
                table_Bilan.Columns["code_eleve"].Visible = true;
        }
        

        private void t_Filiere_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t_Filiere.Text == "AP")
            {
                t_Niveau.Items.Clear();
                System.Object[] ItemObject = new System.Object[2];
                for (int i = 0; i < 2; i++)
                {
                    ItemObject[i] = i + 1;
                }
                t_Niveau.Items.AddRange(ItemObject);
            }else
            {
                t_Niveau.Items.Clear();
                System.Object[] ItemObject = new System.Object[3];
                for (int i = 0; i < 3; i++)
                {
                    ItemObject[i] = i + 1;
                }
                t_Niveau.Items.AddRange(ItemObject);
            }

            if (t_Filiere.Text.Length > 0)
            {
                try
                {
                    d1.Remove("code_fil");
                    d1.Add("code_fil", t_Filiere.Text);
                }
                catch(Exception ex)
                {

                }
            }
            else d1.Remove("code_fil");
         }

        private void t_Etudiant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t_Etudiant.Text.Length > 0)
            {
                try
                {
                    d.Remove("code_eleve");
                    d.Add("code_eleve", t_Etudiant.Text);
                }
                catch(Exception ex) { 
                }
            }
            else d.Remove("code_eleve");
        }

        private void t_Niveau_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (t_Niveau.Text.Length > 0)
            {
                try
                {
                    d1.Remove("niveau");
                    d1.Add("niveau", Int32.Parse(t_Niveau.Text));
                }
                catch (Exception ex) { }
            }
            else d1.Remove("niveau");
        }

        private void b_Rechercher_Click(object sender, EventArgs e)
        {
            load();
            if (t_Etudiant.Text.Length == 0)
            {
                MessageBox.Show("il faut montionner l'eleve  si vous voullez voir son bilan annuel !!!");
                return;
            }
            moyennes moy = new moyennes();
            var m = moy.Select(d);
            foreach(moyennes a in m)
            {
                t_MoyAnn.Text= a.Moyenne.ToString();
            }
         
        }
    }
}
