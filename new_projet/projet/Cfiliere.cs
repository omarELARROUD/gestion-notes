using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    public  class filiere : Model
    {
         
        string code, designation;

        public filiere()
        {
        }

        public filiere( string code, string designation)
        {
            Code = code;
            Designation = designation;
            
        }

        public void delete_1(string t_Code)
        {
            Dictionary<string, object> dico = new Dictionary<string, object>();
            dico.Add("code_fil", t_Code);
            eleve a = new eleve();
            foreach (eleve row in Select(dico))
            {
                Id = row.Id;
                if (Id != 0)
                {
                    try
                    {
                        a.delete_1(a.Code);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }

            Dictionary<string, object> dico1 = new Dictionary<string, object>();
            dico1.Add("code_fil", t_Code);
            module b = new module();
            foreach (module row in Select(dico))
            {
                Id = row.Id;
                if (Id != 0)
                {
                    try
                    {
                        b.delete_1(b.Code);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
            }




            delete();
        }

        public string Code { get => code; set => code = value; }
        public string Designation { get => designation; set => designation = value; }
    }
}
