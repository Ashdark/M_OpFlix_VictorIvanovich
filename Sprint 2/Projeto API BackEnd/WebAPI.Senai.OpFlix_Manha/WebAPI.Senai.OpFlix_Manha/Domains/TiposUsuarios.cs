using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Senai.OpFlix_Manha.Domains
{
    public partial class TiposUsuarios
    {
        public TiposUsuarios()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int IdTipo { get; set; }
        [Required]
        public string Nome { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
