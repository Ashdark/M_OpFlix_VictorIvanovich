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
    [Produces("application/json")]
    [ApiController]
    public class PlataformasController : ControllerBase
    {
        private IPlataforma plataformaRepository { get; set; }
        public PlataformasController()
        {
            plataformaRepository = new PlataformasRepository();
        }
        /// <summary>
        /// Metodo utilizado para realização da listagem de todas plataformas do sistema, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        [Authorize()]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(plataformaRepository.Listar());
        }
        [Authorize(Roles = "2")]
        /// <summary>
        /// Metodo utilizado para realização do cadastro de uma nova plataforma no sistema, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Plataformas plataforma)
        {
            try
            {
                plataformaRepository.Cadastrar(plataforma);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Metodo utilizado para realização da atualização de alguma plataforma no sistema, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Plataformas plataforma)
        {
            try
            {
                plataforma.IdPlataforma = id;
                plataformaRepository.Atualizar(plataforma);
                return Ok();
            } catch
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Metodo utilizado para realização da remoção de alguma plataforma do sistema, apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                plataformaRepository.Deletar(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}