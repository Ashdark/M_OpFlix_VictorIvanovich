using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Senai.OpFlix_Manha.Domains;
using WebAPI.Senai.OpFlix_Manha.Interfaces;
using WebAPI.Senai.OpFlix_Manha.Repositories;

namespace WebAPI.Senai.OpFlix_Manha.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacoesController : ControllerBase
    {

        public ILocalizacoes LocalizacaoRepository { get; set; }

        public LocalizacoesController()
        {
            LocalizacaoRepository = new LocalizacoesRepository();
        }

        [HttpPost]
        public IActionResult Cadastrar(Localizacoes localizacoes)
        {
            try
            {
                LocalizacaoRepository.Cadastrar(localizacoes);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest(new { mensagem = e.Message });
            }
        }
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(LocalizacaoRepository.Listar());
            }
            catch (Exception e)
            {

                return BadRequest(new { mensagem = e.Message });
            }
        }

    }
}