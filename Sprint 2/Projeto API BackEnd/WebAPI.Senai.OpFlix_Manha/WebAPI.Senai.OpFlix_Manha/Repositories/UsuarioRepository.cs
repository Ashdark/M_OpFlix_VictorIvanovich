using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WebAPI.Senai.OpFlix_Manha.Domains;
using WebAPI.Senai.OpFlix_Manha.Interfaces;

namespace WebAPI.Senai.OpFlix_Manha.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        Hash hash = new Hash(SHA1.Create());
        public void Atualizar(Usuarios usuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Usuarios usuariobuscado = ctx.Usuarios.Find(usuario.IdUsuario);
                usuariobuscado.Email = usuario.Email;
                usuariobuscado.Senha = usuario.Senha;
                usuariobuscado.IdTipo = usuario.IdTipo;
                usuariobuscado.Nome = usuario.Nome;
                ctx.Usuarios.Update(usuariobuscado);
                ctx.SaveChanges();
            }
        }

        public Usuarios BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Usuarios.Find(id);
            }
        }

        public void CadastrarNewUser(Usuarios usuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
              //  usuario.Senha = hash.CriptografarSenha(usuario.Senha);
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void Cadastro(Usuarios usuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
               // usuario.Senha = hash.CriptografarSenha(usuario.Senha);
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Usuarios.Remove(ctx.Usuarios.FirstOrDefault(x => x.IdUsuario == id));
                ctx.Usuarios.Remove(ctx.Usuarios.Find(id));
                ctx.SaveChanges();
            }
        }

        public List<Usuarios> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Usuarios.ToList();
            }
        }
    }
}
