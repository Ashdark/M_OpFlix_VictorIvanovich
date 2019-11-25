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
    [Produces ("application/json")]
    public class FavoritosController : ControllerBase
    {
        private IFavorito favoritoRepository { get; set; }
        public FavoritosController()
        {
            favoritoRepository = new FavoritosRepository();
        }

        //[HttpGet]
        //public IActionResult Listar()
        //{
        //    return Ok(favoritoRepository.Listar());
        //}
        /// <summary>
        /// Metodo utilizado para favoritar alguma série/filme
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpDelete("{Int2}")]
        public IActionResult Desfavoritar(int Int,int Int2)
        {
            try
            {
                Int = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                favoritoRepository.Deletar(Int,Int2);
                return Ok();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        [Authorize]
        [HttpPost]
        public IActionResult Cadastrar(Favoritos favorito)
        {
            try
            {
                int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
                favorito.IdUsuario = IdUsuario;
                favoritoRepository.Cadastrar(favorito);

                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
        /// <summary>
        /// Metodo utilizado para a busca de todos favoritos de um usuario em especifico, só é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <param name="it">ID do usuario</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpGet("{it}")]
        public IActionResult BuscarPorUsuario(int it)
        {
            return Ok(favoritoRepository.BuscarPorUsuario(it));
        }

        //[HttpGet("data/{data}")]
        //public IActionResult FiltrarPorData(DateTime data)
        //{
        //    data.ToShortDateString();
        //    return Ok(favoritoRepository.FiltrarPorData(data));
        //}
        //[HttpGet("plataforma/{lol}")]
        //public IActionResult FiltrarPorPlataforma(int lol)
        //{
        //    return Ok(favoritoRepository.FiltrarPorPlataforma(lol));
        //}
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(favoritoRepository.Listar());
        }
    }
}