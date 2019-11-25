using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Senai.OpFlix_Manha.Domains;

namespace WebAPI.Senai.OpFlix_Manha.Interfaces
{
    interface IUsuario
    {
        /// <summary>
        /// Metodo utilizado para realização de listagem dos usuarios apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        List<Usuarios> Listar();
        /// <summary>
        /// Metodo utilizado para realização da busca de um determinado usuario apartir de seu id, só é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <param name="id">ID do usuario buscado</param>
        /// <returns></returns>
        Usuarios BuscarPorId(int id);
        /// <summary>
        /// Metodo utilizado para realização do cadastro de um usuario, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        void Deletar(int id);
        /// <summary>
        /// Metodo utilizado para realização de uma atualização das informações de um usuario, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        void CadastrarNewUser(Usuarios usuario);
        /// <summary>
        /// Metodo utilizado para realização de uma remoção de um usuario, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void Atualizar(Usuarios usuario);
        /// <summary>
        /// Metodo utilizado para realização de um cadastro de novo usuario tipo comum.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        void Cadastro(Usuarios usuario);
    }
}
