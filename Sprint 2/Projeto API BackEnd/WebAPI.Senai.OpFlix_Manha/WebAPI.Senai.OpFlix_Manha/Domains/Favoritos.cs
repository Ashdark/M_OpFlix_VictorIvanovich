using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Senai.OpFlix_Manha.Domains
{
    public class Favoritos
    {
        public int IdUsuario { get; set; }
        public Usuarios Usuario { get; set; }
        public int IdSf { get; set; }
        public Sfs SF { get; set; }
    }
}
