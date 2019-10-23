using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Senai.OpFlix_Manha.Domains;
using WebAPI.Senai.OpFlix_Manha.Interfaces;

namespace WebAPI.Senai.OpFlix_Manha.Repositories
{
    public class TiposUsuariosRepository : ITipoUsuario
    {
        public void Atualizar(TiposUsuarios tipo)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                TiposUsuarios tipobuscado = ctx.TiposUsuarios.Find(tipo.IdTipo);
                tipobuscado.Nome = tipo.Nome;
                ctx.TiposUsuarios.Update(tipobuscado);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(TiposUsuarios tipo)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.TiposUsuarios.Add(tipo);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
           using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.TiposUsuarios.Remove(ctx.TiposUsuarios.FirstOrDefault(x => x.IdTipo == id));
                ctx.TiposUsuarios.Remove(ctx.TiposUsuarios.Find(id));
                ctx.SaveChanges();
            }
        }

        public List<TiposUsuarios> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.TiposUsuarios.ToList();
            }
        }
    }
}
