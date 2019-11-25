using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Senai.OpFlix_Manha.Domains;

namespace WebAPI.Senai.OpFlix_Manha.Interfaces
{
    interface ICategoria
    {
        /// <summary>
        /// Metodo utilizado para realização da listagem de todas categorias do sistema, apenas é realizada caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        List<Categorias> Listar();
        /// <summary>
        /// Metodo utilizado para realização do cadastro de uma nova categoria no sistema, apenas é realizada caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        void Cadastrar(Categorias categoria);
        /// <summary>
        /// Metodo utilizado para realização da atualização de alguma categoria no sistema, apenas é realizada caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        void Atualizar(Categorias categoria);
        /// <summary>
        /// Metodo utilizado para realização da remoção de alguma categoria do sistema, apenas é realizada caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        void Deletar(int id);
    }
}
