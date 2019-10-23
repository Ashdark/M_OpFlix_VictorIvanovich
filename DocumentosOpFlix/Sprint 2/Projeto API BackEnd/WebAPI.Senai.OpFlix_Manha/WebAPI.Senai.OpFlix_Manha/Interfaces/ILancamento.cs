using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Senai.OpFlix_Manha.Domains;

namespace WebAPI.Senai.OpFlix_Manha.Interfaces
{
    interface ILancamento
    {
        /// <summary>
        /// Metodo utilizado para a listagem de todos lançamentos do sistema
        /// </summary>
        /// <returns></returns>
        List<Sfs> Listar();
        /// <summary>
        /// Metodo utilizado para o cadastro de um novo lançamento no sistema, só é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <param name="lancamento"></param>
        /// <returns></returns>
        void Cadastrar(Sfs Lancamento);
        /// <summary>
        /// Metodo utilizado para atualização de um lançamento apartir de seu ID, apenas administradores podem executar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void Atualizar(Sfs Lancamento);
        /// <summary>
        /// Metodo utilizado para remoção de um lançamento apartir de seu ID, apenas administradores podem executar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void Deletar(int id);
        /// <summary>
        /// Metodo utilizado para filtragem dos lançamentos de acordo com sua data
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        List<Sfs> FiltrarPorPlataforma(int lol);
        /// <summary>
        /// Metodo utilizado para filtragem dos lançamentos de acordo com suas plataformas
        /// </summary>
        /// <param name="it"></param>
        /// <returns></returns>
        List<Sfs> FiltrarPorData(DateTime xisde);
    }
}
