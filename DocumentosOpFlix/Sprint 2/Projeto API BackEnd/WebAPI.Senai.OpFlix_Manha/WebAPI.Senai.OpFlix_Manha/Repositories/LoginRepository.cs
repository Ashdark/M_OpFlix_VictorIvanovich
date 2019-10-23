using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WebAPI.Senai.OpFlix_Manha.Domains;
using WebAPI.Senai.OpFlix_Manha.ViewModels;

namespace WebAPI.Senai.OpFlix_Manha.Repositories
{
    public class LoginRepository
    {
        Hash hash = new Hash(SHA1.Create());
        public Usuarios Login(LoginViewModel login)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
              //  login.Senha = hash.CriptografarSenha(login.Senha);
                Usuarios usuariobuscado = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuariobuscado == null)
                {
                    return null;
                }
                return usuariobuscado;
            }
        }
        public void Cadastro(Usuarios usuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                //usuario.Senha = hash.CriptografarSenha(usuario.Senha);
                usuario.IdTipo = 1;
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }
    }
}
