using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Senai.OpFlix_Manha.Domains;

namespace WebAPI.Senai.OpFlix_Manha.Interfaces
{
    interface IPlataforma
    {
        /// <summary>
        /// Metodo utilizado para realização da listagem de todas plataformas do sistema, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        List<Plataformas> Listar();
        /// <summary>
        /// Metodo utilizado para realização do cadastro de uma nova plataforma no sistema, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        void Cadastrar(Plataformas plataforma);
        /// <summary>
        /// Metodo utilizado para realização da atualização de alguma plataforma no sistema, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        void Atualizar(Plataformas plataforma);
        /// <summary>
        /// Metodo utilizado para realização da remoção de alguma plataforma do sistema, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        void Deletar(int id);

    }
}
