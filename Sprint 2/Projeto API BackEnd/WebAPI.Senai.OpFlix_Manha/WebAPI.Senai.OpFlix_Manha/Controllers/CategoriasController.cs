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
    public class CategoriasController : ControllerBase
    {
        private ICategoria CategoriaRepository { get; set; }
        public CategoriasController()
        {
            CategoriaRepository = new CategoriasRepository();
        }
        /// <summary>
        /// Metodo utilizado para realização da listagem de todas categorias do sistema, apenas é realizada caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        [Authorize()]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CategoriaRepository.Listar());
        }
        [Authorize(Roles = "2")]
        /// <summary>
        /// Metodo utilizado para realização do cadastro de uma nova categoria no sistema, apenas é realizada caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            try
            {
                CategoriaRepository.Cadastrar(categoria);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Metodo utilizado para realização da atualização de alguma categoria no sistema, apenas é realizada caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Categorias categoria)
        {
            try
            {
                categoria.IdCat = id;
                CategoriaRepository.Atualizar(categoria);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        /// <summary>
        /// Metodo utilizado para realização da remoção de alguma categoria do sistema, apenas é realizada caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                CategoriaRepository.Deletar(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}