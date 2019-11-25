using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Senai.OpFlix_Manha.Domains
{
    public partial class Plataformas
    {
        public Plataformas()
        {
            Sfs = new HashSet<Sfs>();
        }

        public int IdPlataforma { get; set; }
        [Required]
        public string Nome { get; set; }

        public ICollection<Sfs> Sfs { get; set; }
    }
}
