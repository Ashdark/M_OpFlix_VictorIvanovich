using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Senai.OpFlix_Manha.Domains
{
    public partial class Sfs
    {
        public int IdSf { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public DateTime DataLancamento { get; set; }
        [Required]
        public int IdTipo { get; set; }
        [Required]
        public string Sinopse { get; set; }
        [Required]
        public int IdCat { get; set; }
        [Required]
        public string TempoD { get; set; }
        [Required]
        public int? FaixaEtaria { get; set; }
        public string Descricao { get; set; }
        [Required]
        public int? Plataforma { get; set; }

        public Categorias IdCatNavigation { get; set; }
        public TiposSf IdTipoNavigation { get; set; }
        public Plataformas PlataformaNavigation { get; set; }
        public List<Favoritos> Favoritos { get; set; }
    }
}
