using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Senai.OpFlix_Manha.Interfaces;
using WebAPI.Senai.OpFlix_Manha.Repositories;

namespace WebAPI.Senai.OpFlix_Manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces ("application/json")]
    public class TiposSfController : ControllerBase
    {
        private ITipoSf tipoSfRepository { get; set; }
        public TiposSfController()
        {
            tipoSfRepository = new TiposSfRepository();
        }
        /// <summary>
        /// Metodo utilizado para realizar a listagem dos Tipos (Série/Filme), apenas é realizado caso o usuario logado seja um administrador
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles="2")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(tipoSfRepository.Listar());
        }
    }
}