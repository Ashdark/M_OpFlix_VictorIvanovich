using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Senai.OpFlix_Manha.Domains;
using WebAPI.Senai.OpFlix_Manha.Interfaces;
using WebAPI.Senai.OpFlix_Manha.Repositories;

namespace WebAPI.Senai.OpFlix_Manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LancamentosController : ControllerBase
    {
        private ILancamento lancamentoRepository { get; set; }
        public LancamentosController()
        {
            lancamentoRepository = new LancamentosRepository();
        }
        /// <summary>
        /// Metodo utilizado para a listagem de todos lançamentos do sistema
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(lancamentoRepository.Listar());
        }
        /// <summary>
        /// Metodo utilizado para o cadastro de um novo lançamento no sistema, só é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <param name="lancamento"></param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Sfs lancamento)
        {
            try
            {
                lancamentoRepository.Cadastrar(lancamento);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Metodo utilizado para atualização de um lançamento apartir de seu ID, apenas administradores podem executar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Sfs lancamento)
        {
            try
            {
                lancamento.IdSf = id;
                lancamentoRepository.Atualizar(lancamento);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Metodo utilizado para remoção de um lançamento apartir de seu ID, apenas administradores podem executar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                lancamentoRepository.Deletar(id);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Metodo utilizado para filtragem dos lançamentos de acordo com sua data
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("data/{Data}")]
        public IActionResult FiltrarPorData(DateTime Data)
        {
            Data.ToShortDateString();
            return Ok(lancamentoRepository.FiltrarPorData(Data));
        }
        /// <summary>
        /// Metodo utilizado para filtragem dos lançamentos de acordo com suas plataformas
        /// </summary>
        /// <param name="it"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("plataforma/{it}")]
        public IActionResult FiltrarPorPlataforma(int it)
        {
            return Ok(lancamentoRepository.FiltrarPorPlataforma(it));
        }
    }
}