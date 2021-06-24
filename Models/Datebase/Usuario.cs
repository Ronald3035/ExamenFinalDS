using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinalDS2.Models.Datebase
{
    public class Usuario
    {

        public int id { get; set; }
        public string correo { get; set; }
        public string password { get; set; }
        public string username { get; set; }

        public bool estado { get; set; }


    }
}




