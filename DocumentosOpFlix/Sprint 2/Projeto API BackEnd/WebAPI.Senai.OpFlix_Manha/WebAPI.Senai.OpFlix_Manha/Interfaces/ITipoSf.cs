using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Senai.OpFlix_Manha.Domains;

namespace WebAPI.Senai.OpFlix_Manha.Interfaces
{
    interface ITipoSf
    {
        /// <summary>
        /// Metodo utilizado para realizar a listagem dos Tipos (Série/Filme), apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        List<TiposSf> Listar();
    }
}
