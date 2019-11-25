using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Senai.OpFlix_Manha.Domains
{
    public partial class Categorias
    {
        public Categorias()
        {
            Sfs = new HashSet<Sfs>();
        }

        public int IdCat { get; set; }
        [Required]
        public string NomeCat { get; set; }

        public ICollection<Sfs> Sfs { get; set; }
    }
}
