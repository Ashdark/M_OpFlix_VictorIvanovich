using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
    public class UsuariosController : ControllerBase
    {
        private IUsuario usuariosRepository { get; set; }
        public UsuariosController()
        {
            usuariosRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Metodo utilizado para realização de listagem dos usuarios apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(usuariosRepository.Listar()); 
        }
        /// <summary>
        /// Metodo utilizado para realização da busca de um determinado usuario apartir de seu id, só é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <param name="id">ID do usuario buscado</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            return Ok(usuariosRepository.BuscarPorId(id));
        }
        /// <summary>
        /// Metodo utilizado para realização do cadastro de um usuario, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                if (usuario.IdTipo == null)
                {
                    usuario.IdTipo = 1;
                    usuariosRepository.CadastrarNewUser(usuario);
                }
                else
                {
                    usuariosRepository.CadastrarNewUser(usuario);
                }
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Metodo utilizado para realização de uma atualização das informações de um usuario, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Usuarios usuario)
        {
            try
            {
                usuario.IdUsuario = id;
                usuariosRepository.Atualizar(usuario);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Metodo utilizado para realização de uma remoção de um usuario, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                usuariosRepository.Deletar(id);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }


    }
}