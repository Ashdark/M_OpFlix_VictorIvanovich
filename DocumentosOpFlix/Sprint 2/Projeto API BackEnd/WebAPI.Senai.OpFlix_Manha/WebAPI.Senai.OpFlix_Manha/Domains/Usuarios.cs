using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Senai.OpFlix_Manha.Domains
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        public string Email { get; set; }
        public int? IdTipo { get; set; }

        public TiposUsuarios IdTipoNavigation { get; set; }
        public List<Favoritos> Favoritos { get; set; }
    }
}
