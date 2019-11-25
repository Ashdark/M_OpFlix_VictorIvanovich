using System;
using System.Collections.Generic;

namespace WebAPI.Senai.OpFlix_Manha.Domains
{
    public partial class TiposSf
    {
        public TiposSf()
        {
            Sfs = new HashSet<Sfs>();
        }

        public int IdTipo { get; set; }
        public string DescricaoTipo { get; set; }

        public ICollection<Sfs> Sfs { get; set; }
    }
}
