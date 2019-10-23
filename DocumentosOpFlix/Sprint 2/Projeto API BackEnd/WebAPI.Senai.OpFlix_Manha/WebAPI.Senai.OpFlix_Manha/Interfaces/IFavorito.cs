using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Senai.OpFlix_Manha.Domains;

namespace WebAPI.Senai.OpFlix_Manha.Interfaces
{
    interface IFavorito
    {
        /// <summary>
        /// Metodo utilizado para favoritar alguma série/filme
        /// </summary>
        /// <returns></returns>
        void Cadastrar(Favoritos favorito);
        /// <summary>
        /// Metodo utilizado para a busca de todos favoritos de um usuario em especifico, só é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <param name="it">ID do usuario</param>
        /// <returns></returns>
        List<Favoritos> BuscarPorUsuario(int it);
        /// <summary>
        /// Metodo utilizado para desfavoritar alguma série/filme
        /// </summary>
        /// <returns></returns>
        void Deletar(int Int, int Int2);

    }
}
