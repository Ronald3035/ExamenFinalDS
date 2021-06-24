using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenFinalDS2.Models.Datebase
{
    public class Producto
    {
        public int id { get; set; }
        public int usuarioId { get; set; }
        public string correo { get; set; }
        public string nombre { get; set; }
        public string descripcion  { get; set; }
        public string marca { get; set; }
        public bool estado { get; set; }
    }
}


