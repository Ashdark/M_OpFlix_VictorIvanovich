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
    [Produces ("application/json")]
    public class TiposUsuarioController : ControllerBase
    {
        private ITipoUsuario tipousuarioRepository { get; set; }
        public TiposUsuarioController()
        {
            tipousuarioRepository = new TiposUsuariosRepository();
        }
        /// <summary>
        /// Metodo utilizado para fazer a listagem de todos os tipos de usuarios do sistema, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(tipousuarioRepository.Listar());
        }
        /// <summary>
        /// Metodo utilizado para fazer o cadastro de um novo tipo de usuario no sistema, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <param name="tipo">Recebe o modelo como parâmetro</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(TiposUsuarios tipo)
        {
            try
            {
                tipousuarioRepository.Cadastrar(tipo);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Metodo utilizado para realizar a atualização de algum tipo de usuario no sistema, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <param name="id">ID do Tipo</param>
        /// <param name="tipo">Tipo recebido como parâmetro</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Atualizar (int id, TiposUsuarios tipo)
        {
            try
            {
                tipo.IdTipo = id;
                tipousuarioRepository.Atualizar(tipo);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Metodo utilizado para remoção de um tipo de usuario do sistema, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            try
            {
               tipousuarioRepository.Deletar(id);
               return Ok();
            } catch
            {
                return BadRequest();
            }
        }
    }
}