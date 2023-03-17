using DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet
{
    public  class matiere : Model
    {
        string code, designation, code_module;
        int vh;

        public matiere()
        {
        }

        public matiere(string code, string designation, string code_module, int vh)
        {
            this.Code = code;
            this.Designation = designation;
            this.Code_module = code_module;
            this.Vh = vh;
        }

        public string Code { get => code; set => code = value; }
        public string Designation { get => designation; set => designation = value; }
        public string Code_module { get => code_module; set => code_module = value; }
        public int Vh { get => vh; set => vh = value; }






    }
}
