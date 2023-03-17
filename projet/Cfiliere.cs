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

        public string Code { get => code; set => code = value; }
        public string Designation { get => designation; set => designation = value; }
    }
}
