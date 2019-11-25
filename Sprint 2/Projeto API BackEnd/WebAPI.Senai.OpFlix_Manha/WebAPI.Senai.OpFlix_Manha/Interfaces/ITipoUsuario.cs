using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Senai.OpFlix_Manha.Domains;

namespace WebAPI.Senai.OpFlix_Manha.Interfaces
{
    interface ITipoUsuario
    {
        /// <summary>
        /// Metodo utilizado para fazer a listagem de todos os tipos de usuarios do sistema, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        List<TiposUsuarios> Listar();
        /// <summary>
        /// Metodo utilizado para fazer o cadastro de um novo tipo de usuario no sistema, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <param name="tipo">Recebe o modelo como parâmetro</param>
        /// <returns></returns>
        void Cadastrar(TiposUsuarios tipo);
        /// <summary>
        /// Metodo utilizado para realizar a atualização de algum tipo de usuario no sistema, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <param name="id">ID do Tipo</param>
        /// <param name="tipo">Tipo recebido como parâmetro</param>
        /// <returns></returns>
        void Atualizar(TiposUsuarios tipo);
        /// <summary>
        /// Metodo utilizado para remoção de um tipo de usuario do sistema, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void Deletar(int id);
    }
}
