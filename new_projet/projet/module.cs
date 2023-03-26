using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    public  class module : Model
    {

        string code, designation, code_fil;
        int niveau, semestre;

        public module()
        {
        }

        public module(string code, string designation, string code_fil, int niveau, int semestre)
        {
            this.Code = code;
            this.Designation = designation;
            this.Niveau = niveau;
            this.Semestre = semestre;
            this.Code_fil = code_fil;
        }
        public void delete_1(string t_Code)
        {
            matiere an = new matiere();
            an.setIdDelete_matiere(t_Code);
            delete();
        }
    /*    public void setter(Dictionary<string, object> dico)
        {
            try { Niveau = Int32.Parse(dico["niveau"].ToString()); } catch (Exception e) { }
            try { Code_fil = dico["code_fil"].ToString(); } catch (Exception e) { }
            try { Designation = dico["designation"].ToString(); } catch (Exception e) { }
            try { Semestre = Int32.Parse( dico["semestre"].ToString()); } catch (Exception e) { }


        }*/
        public string Designation { get => designation; set => designation = value; }
        public string Code_fil { get => code_fil; set => code_fil = value; }
        public int Niveau { get => niveau; set => niveau = value; }
        public int Semestre { get => semestre; set => semestre = value; }
        public string Code { get => code; set => code = value; }
    }
}
