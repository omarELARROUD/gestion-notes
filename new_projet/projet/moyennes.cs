﻿using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    public  class moyennes:Model
    {
        string code_eleve, code_fil;
        int niveau;
        float moyenne;

        public moyennes()
        {
        }

        public moyennes(string code_eleve, string code_fil, int niveau, float moyenne)
        {
            this.Code_eleve = code_eleve;
            this.Code_fil = code_fil;
            this.Niveau = niveau;
            this.Moyenne = moyenne;
        }
        public void setIdDelete_eleve(string t_Code)
        {
            Dictionary<string, object> dico = new Dictionary<string, object>();
            dico.Add("code_eleve", t_Code);

            foreach (moyennes row in Select(dico))
            {
                Id = row.Id;
                if (Id != 0)
                {
                    try
                    {
                        delete();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }
        }
        public string Code_eleve { get => code_eleve; set => code_eleve = value; }
        public string Code_fil { get => code_fil; set => code_fil = value; }
        public int Niveau { get => niveau; set => niveau = value; }
        public float Moyenne { get => moyenne; set => moyenne = value; }
    }
}
