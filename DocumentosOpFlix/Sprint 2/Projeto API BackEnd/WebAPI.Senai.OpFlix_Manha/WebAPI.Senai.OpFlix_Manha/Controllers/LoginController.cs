using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Senai.OpFlix_Manha.Domains;
using WebAPI.Senai.OpFlix_Manha.Repositories;
using WebAPI.Senai.OpFlix_Manha.ViewModels;

namespace WebAPI.Senai.OpFlix_Manha.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]

    [ApiController]
    public class LoginController : ControllerBase
    {
        LoginRepository UsuarioRepository = new LoginRepository();
        /// <summary>
        /// Metodo utilizado para realização do login no sistema!
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuarios usuarioBuscado = UsuarioRepository.Login(login);
                if (usuarioBuscado == null)
                    return NotFound(new { mensagem = "Usuario ou senha inválida/não conferem." });

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Prn, usuarioBuscado.IdTipo.ToString()),
                    new Claim(JwtRegisteredClaimNames.Acr, usuarioBuscado.Senha),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipo.ToString()),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("opflix-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "Opflix.WebApi",
                    audience: "Opflix.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        [HttpPost("Cadastro")]
        public IActionResult CadastrarUsuarioComum(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.Cadastro(usuario);
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }
    }
}